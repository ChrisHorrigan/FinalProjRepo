using UnityEngine;
using System.Collections;

public abstract class DestructableObject : MonoBehaviour {

	protected int health;
	// Use this for initialization
	void Start () {
		health = 1;
		innitializeHealth();
	}
	
	// Update is called once per frame
	public virtual void Update () {
		if(health <= 0f) {
			//destructionEffect();
		}
	}

	/*
	void OnTriggerEnter(Collider other) {
		if (other.collider.transform.GetComponent<MonoBehaviour>() is DestructableObject) {
			hit();
		}
	} 

	void OnControllerColliderHit(ControllerColliderHit hitt) {
		print ("call1 - " + hitt.gameObject.name);
		if (hitt.gameObject.transform.GetComponent<MonoBehaviour>() is DestructableObject) {
			print ("call2");
			hit();
		}
	} */

	public float returnHealth() {
		return health;
	}

	public void dealDamage(int dmg) {
		health -= dmg;
		damageEffect();
	}

	public void hit() {
		health -= Random.Range(1, 3);
		damageEffect();
	}


	protected abstract void innitializeHealth();
	protected abstract void damageEffect();
	protected abstract void destructionEffect();
}
