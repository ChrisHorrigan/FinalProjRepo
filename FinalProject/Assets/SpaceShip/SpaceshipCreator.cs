using UnityEngine;
using System.Collections;

public class SpaceshipCreator : MonoBehaviour {

	public Transform spaceship;
	public Transform planet;
	public string playerName;
	// Use this for initialization
	void Start () {

		if(Network.isServer) {
			Transform tempShip = Network.Instantiate(spaceship, transform.position, transform.rotation, 0) as Transform;
			//Network.Instantiate(spaceship, transform.position, transform.rotation, 0);
			Camera.main.transform.parent = tempShip.transform;
			playerName=GetName ();
			tempShip.GetComponent<SpaceCode>().sendName(GetName ());
			Network.Instantiate(planet, new Vector3(1000, 0, 0), transform.rotation, 0);
		}




	}

	void OnConnectedToServer() {
		Transform tempShip = spaceship;
			//Network.Instantiate(spaceship, transform.position, transform.rotation, 0) as Transform;//this is the real one
		//Network.Instantiate(spaceship, transform.position, transform.rotation, 0);
		Camera.main.transform.parent = tempShip.transform;
		tempShip.GetComponent<SpaceCode>().sendName(GetName ());

	}
	void OnDisconnectedFromServer(){
		Application.LoadLevel (0);
		}
	// Update is called once per frame
	void Update () {

	}

	void RoundStart(){

	}
	string GetName(){
		MenuScript menuInstance=GameObject.Find ("MenuManager").GetComponent<MenuScript>();
		string name = menuInstance.getName ();
		return name;
		}
	           
}
