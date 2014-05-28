using UnityEngine;
using System.Collections;

public class SeekerCode : DestructableObject {

	public Transform tempTarget;
	PathFinder pathFinder;

	private float blastRadius = 9f;
	private int blastDamage = 3;

	private float exploding = -1f;
	// Use this for initialization
	//void Start () {
		//exploding = -1f;
		//tempTarget = GameObject.Find("target").transform;
		//pathFinder = new PathFinder(tempTarget, this.transform);

	//}
	
	// Update is called once per frame
	public override void Update () {
		if(exploding >= 0f) {
			exploding += Time.deltaTime;
			if(exploding >= .45f) {
				GameObject[] all = GameObject.FindObjectsOfType<GameObject>();
				foreach (GameObject stepOne in all) {
					if((stepOne.GetComponent<MonoBehaviour>() is DestructableObject) && ((stepOne.transform.localPosition - this.transform.localPosition).magnitude < blastRadius) && !this.Equals(stepOne)) {
						for(int i = 0; i < blastDamage; i++) {
							(stepOne.GetComponent<MonoBehaviour>() as DestructableObject).hit();
						}
					}
				}
				Destroy(this.gameObject);
			}
		} else {
			if(tempTarget.Equals(null)) {
				explode ();
			} else {
				if (!pathFinder.Equals(null)) {
					this.GetComponent<CharacterController>().Move(.1f * Time.deltaTime * pathFinder.findPath());
				}
				if(pathFinder.getDistance() < 5f) {
					explode ();
				}
			}
		}
		base.Update();
	}

	public void setTarget(Transform newTarget) {
		tempTarget = newTarget;
		pathFinder = new PathFinder(tempTarget, this.transform);
	}

	protected override void innitializeHealth() {
		this.health = 1f;
		print("innit");
	}
	protected override void damageEffect() {
		print("k23 " + this.health);

	}
	protected override void destructionEffect() {
		print ("k4444");
		explode();
	}

	public void explode() {
		exploding = 0.0001f;
		this.GetComponent<ParticleSystem>().Play();
		//Destroy(this.gameObject);
	}
	


}
