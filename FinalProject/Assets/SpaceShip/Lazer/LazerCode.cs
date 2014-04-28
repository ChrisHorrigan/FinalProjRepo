using UnityEngine;
using System.Collections;

public class LazerCode : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<CharacterController>().Move(20f * Time.deltaTime * this.transform.forward);
	}
}
