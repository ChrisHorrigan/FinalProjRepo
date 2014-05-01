using UnityEngine;
using System.Collections;

public class LazerCode : MonoBehaviour {

	public float timeLeft;

	// Use this for initialization
	void Start () {
		timeLeft = 15f;
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<CharacterController>().Move(20f * Time.deltaTime * this.transform.forward);

		timeLeft -= Time.deltaTime;
		if(timeLeft < 0f) {
			Destroy(this.gameObject);
		}
	}

	public void setForwardVector( Vector3 newV) {
		this.transform.forward = newV;
	}
}
