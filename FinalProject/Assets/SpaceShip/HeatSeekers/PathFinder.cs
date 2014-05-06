using UnityEngine;
using System.Collections;

public class PathFinder {

	private Transform target;
	private Transform seeker;

	public PathFinder() {

	}

	public PathFinder(Transform tar, Transform seek) {
		target = tar;
		seeker = seek;
	}

	public void updateParameters(Transform tar, Transform seek) {
		target = tar;
		seeker = seek;
	}

	//Physics.Raycast(transform.position, right, out hit);
	//Physics.Raycast(transform.position, down, transform.localScale.y / 2 * raycastModifier)

	public Vector3 findPath() {
		Vector3 direct = target.localPosition - seeker.localPosition;
		RaycastHit hit;
		Physics.Raycast(seeker.localPosition, direct, out hit);
		if(Physics.Raycast(seeker.localPosition, direct, 100f)) {


			return new Vector3(0f, 0f, 0f);
		} else {
			return direct;
		}
	}
	

}
