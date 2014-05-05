using UnityEngine;
using System.Collections;

public class SpaceshipCreator : MonoBehaviour {

	public Transform spaceship;
	public Transform planet;
	public Transform flag1;

	// Use this for initialization
	void Start () {
		if(Network.isServer) {
			Transform tempShip = Network.Instantiate(spaceship, transform.position, transform.rotation, 0) as Transform;
			//Network.Instantiate(spaceship, transform.position, transform.rotation, 0);
			Camera.main.transform.parent = tempShip.transform;
		
			tempShip.GetComponent<SpaceCode>().sendName(GetName ());
			Network.Instantiate(planet, new Vector3(1000, 0, 0), transform.rotation, 0);
			Network.Instantiate(flag1, new Vector3(0, 0, 10), transform.rotation, 0);
		}




	}

	void OnConnectedToServer() {
		Transform tempShip = Network.Instantiate(spaceship, transform.position, transform.rotation, 0) as Transform;
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
	string GetName(){
		MenuScript menuInstance=GameObject.Find ("MenuManager").GetComponent<MenuScript>();
		string name = menuInstance.getName ();
		return name;
		}
	           
}
