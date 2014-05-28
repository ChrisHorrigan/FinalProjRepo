using UnityEngine;
using System.Collections;

public class AsteroidCode : DestructableObject {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public virtual void Update () {

		base.Update();
	}

	protected override void innitializeHealth() {
		this.health = .5f;
	}
	protected override void damageEffect() {
		Destroy(this.gameObject);
	}
	protected override void destructionEffect() {
		
	}
}
