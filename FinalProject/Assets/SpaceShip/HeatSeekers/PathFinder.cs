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
		Vector3 direct = Vector3.Normalize(target.localPosition - seeker.localPosition);
		RaycastHit hit;
		Physics.Raycast(seeker.localPosition, direct, out hit);
		if(Physics.Raycast(seeker.localPosition, direct, 100f)) {
			float deflection = Mathf.Atan(1f / hit.distance);
			float MaxDist = -1f;
			Vector3 actualShot = new Vector3(0, 0, 1);
			Vector3 testShot;
			for(float tryPhi = 0; tryPhi < 2 * Mathf.PI; tryPhi += Mathf.PI / 6) {
				testShot =  Mathf.Sin(deflection) * Mathf.Cos(tryPhi) * getAssginedZeroRotationalVector(direct) + Mathf.Sin(deflection) * Mathf.Sin(tryPhi) * Vector3.Cross(direct, getAssginedZeroRotationalVector(direct)) + Mathf.Cos(deflection) * direct;
				Physics.Raycast(seeker.localPosition, testShot, out hit);
				if(hit.distance >= MaxDist) {
					MaxDist = hit.distance;
					actualShot = testShot;
				}
			}
			return Vector3.Normalize(actualShot);
		} else {
			return direct;
		}
	}

	private Vector3 getAssginedZeroRotationalVector(Vector3 input) {
		Vector3 output = Vector3.Cross(input, new Vector3(0, 0, 1));
		if(output.magnitude == 0f) {
			return new Vector3(1, 0, 0);
		} else {
			return Vector3.Normalize(output);
		}
	}
	

}
