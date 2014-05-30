using UnityEngine;
using System.Collections;

public class AsteroidCode : DestructableObject {

	// Use this for initialization
	void Start () {
		health = 1;
	}
	
	// Update is called once per frame
	public virtual void Update () {

		base.Update();
	}

	protected override void innitializeHealth() {

	}
	protected override void damageEffect() {
		Destroy(this.gameObject);
	}
	protected override void destructionEffect() {
		
	}
}
