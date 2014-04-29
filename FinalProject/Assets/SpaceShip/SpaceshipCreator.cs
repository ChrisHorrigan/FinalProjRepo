using UnityEngine;
using System.Collections;

public class SpaceshipCreator : MonoBehaviour {

	public Transform spaceship;

	// Use this for initialization
	void Start () {
		if(Network.isServer) {
			//GameObject tempShip = Network.Instantiate(spaceship, transform.position, transform.rotation, 0) as GameObject;
			Network.Instantiate(spaceship, transform.position, transform.rotation, 0);
			//Camera.main.transform.parent = tempShip.transform;
		}
	}

	void OnConnectedToServer() {
		Network.Instantiate(spaceship, transform.position, transform.rotation, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
