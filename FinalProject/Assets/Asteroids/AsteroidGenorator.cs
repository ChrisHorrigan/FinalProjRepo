using UnityEngine;
using System.Collections;

public class AsteroidGenorator : MonoBehaviour {

	public Transform genericAsteroid;

	private float currentTime;

	// Use this for initialization
	void Start () {
		currentTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		if (currentTime > .1f) {
			createAsteroids();
			currentTime = 0f;
		}
	
	}

	private void createAsteroids() {
		Transform temp = (Transform) Instantiate(genericAsteroid);
		float x = this.transform.localPosition.x + Random.Range(-10f, 10f);
		float y = this.transform.localPosition.y + Random.Range(-10f, 10f);
		float z = this.transform.localPosition.z + Random.Range(-10f, 10f);
		temp.localPosition = new Vector3(x, y, z);

	}

}
