using UnityEngine;
using System.Collections;

public class LazerCode : DestructableObject {

	public float timeLeft;

	// Use this for initialization
	void Start () {
		timeLeft = 8f;
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<CharacterController>().Move(100f * Time.deltaTime * this.transform.forward);

		timeLeft -= Time.deltaTime;
		if(timeLeft < 0f) {
			Destroy(this.gameObject);
		}
	}

	public void setForwardVector( Vector3 newV) {
		this.transform.forward = newV;
	}

	protected override void innitializeHealth() {
		this.health = 100f;
	}
	protected override void damageEffect() {
		timeLeft -= Random.Range(0f, 3f);
	}
	protected override void destructionEffect() {
		Destroy(this.gameObject);
	}
}
