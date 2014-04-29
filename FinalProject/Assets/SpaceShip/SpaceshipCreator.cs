using UnityEngine;
using System.Collections;

public class SpaceshipCreator : MonoBehaviour {

	public Transform spaceship;

	// Use this for initialization
	void Start () {
		Network.Instantiate(spaceship, transform.position, transform.rotation, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
