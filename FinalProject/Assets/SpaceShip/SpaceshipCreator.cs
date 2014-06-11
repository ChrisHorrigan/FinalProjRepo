using UnityEngine;
using System.Collections;

public class SpaceshipCreator : MonoBehaviour {
	Transform tempShip;
	public Transform spaceship;
	public Transform planet;
	public Transform flag1;
	public Transform teacher;
	public Transform boxUp;
	public string name;
	public static bool gameOn;
	public PlayerManager thisManager;
	public MenuScript thisMenu;
	public Vector3 team1Spawn = new Vector3 (0, 0,0);
	public Vector3 team2Spawn = new Vector3 (0, 0,0);
	public int alignment;
	public PlayerManager managerOfPlayers;
	// Use this for initialization

	void Start () {
		thisMenu=GameObject.Find ("MenuManager").GetComponent<MenuScript>();
		alignment = 0;
		if (Network.isServer) {
						Network.Instantiate (boxUp, new Vector3 (0, 0, 0), transform.rotation, 0);
			//thisMenu.scoreKeeper=boxUp.GetComponent<PlayerManager>();
//			GameObject.Instantiate(boxUp,new Vector3 (0, 0, 0), transform.rotation, 0);
				}


		if(Network.isServer) {
			//team1=0;
			//team2=0;
			//Transform tempShip = Network.Instantiate(spaceship, transform.position, transform.rotation, 0) as Transform;
			//Network.Instantiate(spaceship, transform.position, transform.rotation, 0);
			//Camera.main.transform.parent = tempShip.transform;
			name=GetName ();
			print (name+" has connected.");

			//thisManager.AddPlayer(this);
			//tempShip.GetComponent<SpaceCode>().sendName(GetName ());
			if(thisMenu.tutorial)
				Network.Instantiate(teacher,new Vector3(0,0,0),transform.rotation,0);
			if(!thisMenu.tutorial){
				Network.Instantiate(planet, new Vector3(1000, 0, 0), transform.rotation, 0);
				Network.Instantiate(flag1, new Vector3(0, 0, 10), transform.rotation, 0);

//				
			}
//	
		}
		//managerOfPlayers=GameObject.Find ("PlayerBox(Clone)").GetComponent<PlayerManager> ();

	}
	int getTeam(){
		if (thisManager.team1.Contains (Network.player.ToString ()))
						return 1;
				else
						return 2;
		}
	[RPC]
	void Initialize(){
		gameOn = true;
		thisManager = GameObject.Find ("PlayerBox(Clone)").GetComponent<PlayerManager> ();//this might have to move
		if(getTeam ()==1)
			tempShip = Network.Instantiate(spaceship, team1Spawn, transform.rotation, 0) as Transform;
		else 
			tempShip = Network.Instantiate(spaceship, team2Spawn, transform.rotation, 0) as Transform;
		Camera.main.transform.localPosition = tempShip.transform.localPosition + Camera.main.transform.localPosition;
		Camera.main.transform.parent = tempShip.transform;
		tempShip.GetComponent<SpaceCode>().sendName(GetName ());
		//print (name + " is on team " + getTeam ());
		}
	public void RoundStart(){
		//gameOn = true;
		networkView.RPC ("Initialize", RPCMode.AllBuffered);
		//Initialize ();
	}
	[RPC] 
	void NotifyNameCon(string Pname){
		print (Pname + " has connected.");
		}
	[RPC]
	void NotifyNameDis(string Pname){
		print (Pname + " has left the game.");
		}
	void OnConnectedToServer() {
		//Transform tempShip = Network.Instantiate(spaceship, transform.position, transform.rotation, 0) as Transform;
		name=GetName ();
		networkView.RPC ("NotifyNameCon", RPCMode.AllBuffered,name);

//		Network.Instantiate(spaceship, transform.position, transform.rotation, 0);
//		Camera.main.transform.parent = tempShip.transform;//THIS IS WEIRD
//		tempShip.GetComponent<SpaceCode>().sendName(GetName ());
	}
	public void BeforeLeaving(){
		networkView.RPC ("NotifyNameDis", RPCMode.AllBuffered, name);
	
		}
	void OnDisconnectedFromServer(){

		Application.LoadLevel (0);
		}
	// Update is called once per frame
	void Update () {

	}

	void OnPlayerDisconnected(NetworkPlayer player) {
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects(player);
	}
	string GetName(){


		string name = thisMenu.getName ();
		return name;
		}
	           
}
