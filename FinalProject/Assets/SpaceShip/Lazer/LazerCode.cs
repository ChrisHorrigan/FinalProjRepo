using UnityEngine;
using System.Collections;

public class LazerCode : DestructableObject {
	private float speed = 400f;
	private float timeLeft = 1f;
	private CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = gameObject.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	public virtual void Update () {
		controller.Move(speed * Time.deltaTime * Camera.main.transform.forward);
		//transform.Translate(100f * Time.deltaTime * this.transform.forward);

		timeLeft -= Time.deltaTime;
		if(timeLeft < 0f) {
			Destroy(this.gameObject);
		}

		/*RaycastHit hit;
		Physics.Raycast(this.transform.localPosition, this.transform.forward, out hit);
		if(Physics.Raycast(this.transform.localPosition, this.transform.forward, this.transform.localScale.z)) {
			print (hit.collider.name);
			if (hit.collider.transform.GetComponent<MonoBehaviour>() is DestructableObject) {
				(hit.collider.transform.GetComponent<MonoBehaviour>() as DestructableObject).hit();
				this.hit();
			}
		}*/
		base.Update();
	}

	public void setForwardVector( Vector3 newV) {
		this.transform.forward = newV;
	}

	public void setTimeLeft(float a) {
		timeLeft = a;
	}

	protected override void innitializeHealth() {
		this.health = 100;
	}
	protected override void damageEffect() {
		timeLeft -= Random.Range(0f, 3f);
	}
	protected override void destructionEffect() {
		Destroy(this.gameObject);
	}
}
