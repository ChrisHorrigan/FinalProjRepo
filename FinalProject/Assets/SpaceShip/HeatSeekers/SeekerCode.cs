using UnityEngine;
using System.Collections;

public class SeekerCode : DestructableObject {

	public Transform tempTarget;
	PathFinder pathFinder;

	private float exploding;
	// Use this for initialization
	void Start () {
		exploding = -1f;
		//tempTarget = GameObject.Find("target").transform;
		//pathFinder = new PathFinder(tempTarget, this.transform);

	}
	
	// Update is called once per frame
	void Update () {
		if(exploding >= 0f) {
			exploding += Time.deltaTime;
			if(exploding >= .45f) {
				GameObject[] all = GameObject.FindObjectsOfType<GameObject>();
				foreach (GameObject stepOne in all) {

				}
				Destroy(this.gameObject);
			}
		} else {
			if (!pathFinder.Equals(null)) {
				this.GetComponent<CharacterController>().Move(10f * Time.deltaTime * pathFinder.findPath());
			}
			if(pathFinder.getDistance() < 5f) {
				explode ();
			}
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
		exploding = 0.0001f;
		this.GetComponent<ParticleSystem>().Play();
		//Destroy(this.gameObject);
	}
	


}
