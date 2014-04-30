using UnityEngine;
using System.Collections;

public class SpaceshipCreator : MonoBehaviour {

	public Transform spaceship;
	public Transform planet;

	// Use this for initialization
	void Start () {
		if(Network.isServer) {
			Transform tempShip = Network.Instantiate(spaceship, transform.position, transform.rotation, 0) as Transform;
			//Network.Instantiate(spaceship, transform.position, transform.rotation, 0);
			Camera.main.transform.parent = tempShip.transform;

			Network.Instantiate(planet, new Vector3(1000, 0, 0), transform.rotation, 0);


		}
	}

	void OnConnectedToServer() {
		Transform tempShip = Network.Instantiate(spaceship, transform.position, transform.rotation, 0) as Transform;
		//Network.Instantiate(spaceship, transform.position, transform.rotation, 0);
		Camera.main.transform.parent = tempShip.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
