﻿using UnityEngine;
using System.Collections;

public class SeekerCode : MonoBehaviour {

	public Transform tempTarget;
	PathFinder pathFinder;
	// Use this for initialization
	void Start () {
		tempTarget = GameObject.Find("target").transform;
		pathFinder = new PathFinder(tempTarget, this.transform);

	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<CharacterController>().Move(100f * Time.deltaTime * pathFinder.findPath());
	}

	public void setTarget(Transform newTarget) {
		tempTaget = newTarget;
		pathFinder = new PathFinder(tempTarget, this.transform);
	}
	


}
