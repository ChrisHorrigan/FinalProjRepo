using UnityEngine;
using System.Collections;

public class SpaceshipCreator : MonoBehaviour {
	Transform tempShip;
	public Transform spaceship;
	public Transform planet;
	public Transform flag1;
	public Transform teacher;
	public string name;
	public static bool gameOn;
	public PlayerManager thisManager;
	public MenuScript thisMenu;
	// Use this for initialization
	void Start () {
		thisMenu=GameObject.Find ("MenuManager").GetComponent<MenuScript>();
		thisManager = GameObject.Find ("GameManager").GetComponent<PlayerManager> ();
		if(Network.isServer) {
			gameOn=false;

			//Transform tempShip = Network.Instantiate(spaceship, transform.position, transform.rotation, 0) as Transform;
			//Network.Instantiate(spaceship, transform.position, transform.rotation, 0);
			//Camera.main.transform.parent = tempShip.transform;
			name=GetName ();
			print (name+" has connected.");
			thisManager.AddPlayer(this);
			//tempShip.GetComponent<SpaceCode>().sendName(GetName ());
			if(thisMenu.tutorial)
				Network.Instantiate(teacher,new Vector3(0,0,0),transform.rotation,0);
			if(!thisMenu.tutorial){
				Network.Instantiate(planet, new Vector3(1000, 0, 0), transform.rotation, 0);
				Network.Instantiate(flag1, new Vector3(0, 0, 10), transform.rotation, 0);
			}
		}

	}
	[RPC]
	void Initialize(){
		tempShip = Network.Instantiate(spaceship, transform.position, transform.rotation, 0) as Transform;
		Camera.main.transform.parent = tempShip.transform;
		tempShip.GetComponent<SpaceCode>().sendName(GetName ());
		}
	public void RoundStart(){
		gameOn = true;
		networkView.RPC ("Initialize", RPCMode.AllBuffered);//the game manager does not have a network view...
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
		thisManager.AddPlayer(this);
		//Network.Instantiate(spaceship, transform.position, transform.rotation, 0);
		//Camera.main.transform.parent = tempShip.transform;
		//tempShip.GetComponent<SpaceCode>().sendName(GetName ());
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
