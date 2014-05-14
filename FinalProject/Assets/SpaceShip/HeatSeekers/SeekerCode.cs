using UnityEngine;
using System.Collections;

public class SeekerCode : DestructableObject {

	public Transform tempTarget;
	PathFinder pathFinder;
	// Use this for initialization
	void Start () {
		//tempTarget = GameObject.Find("target").transform;
		//pathFinder = new PathFinder(tempTarget, this.transform);

	}
	
	// Update is called once per frame
	void Update () {
		if (!pathFinder.Equals(null)) {
			this.GetComponent<CharacterController>().Move(10f * Time.deltaTime * pathFinder.findPath());
		}
		if(pathFinder.getDistance() < 5f) {
			explode ();
		}
	}

	public void setTarget(Transform newTarget) {
		tempTarget = newTarget;
		pathFinder = new PathFinder(tempTarget, this.transform);
	}

	protected override void innitializeHealth() {
		this.health = 1f;
	}
	protected override void damageEffect() {

	}
	protected override void destructionEffect() {
		explode();
	}

	public void explode() {




		Destroy(this.gameObject);
	}
	


}
