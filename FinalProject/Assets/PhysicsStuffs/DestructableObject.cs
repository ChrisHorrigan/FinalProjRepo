using UnityEngine;
using System.Collections;

public abstract class DestructableObject : MonoBehaviour {

	protected float health;
	// Use this for initialization
	void Start () {
		health = 1f;
		this.innitializeHealth();
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0f) {
			destructionEffect();
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.collider.transform.GetComponent<MonoBehaviour>() is DestructableObject) {
			health -= Random.Range(.5f, 1.5f);
			damageEffect();
		}
	}

	public float returnHealth() {
		return health;
	}

	public void dealDamage(float dmg) {
		health -= dmg;
		damageEffect();
	}

	protected abstract void innitializeHealth();
	protected abstract void damageEffect();
	protected abstract void destructionEffect();
}
