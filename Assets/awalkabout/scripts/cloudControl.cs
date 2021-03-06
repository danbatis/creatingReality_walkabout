﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class cloudControl : MonoBehaviour {
	
	NavMeshAgent navAgent;
	Transform myTransform;
	bool walking;
	public List<Transform> destinies;
	public int currentDest;
	public float nextCheckpointDist = 2.0f;
	public Transform playerTransform;
	public float maxPlayerDist = 2.0f;
	Slider cloudSpeedSlider;

	public float oscilFreq = 2.0f;
	public float oscilAmp = 0.1f;
	Transform cloudMesh;
	Vector3 cloudPos;
	float initialCloudHeight;

	// Use this for initialization
	void Start () {
		navAgent = GetComponent<NavMeshAgent>();	
		navAgent.SetDestination(destinies[currentDest].position);
		myTransform = transform;
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		cloudSpeedSlider = GameObject.Find ("GUI/Panel/cloudSpeed").GetComponent<Slider>();
		cloudMesh = GameObject.Find (gameObject.name+"/CloudSpawnner").transform;
		cloudPos = cloudMesh.localPosition;
		initialCloudHeight = cloudPos.y;
	}
	
	// Update is called once per frame
	void Update () {
		navAgent.speed = cloudSpeedSlider.value;
		cloudPos.y = initialCloudHeight + oscilAmp * Mathf.Sin(oscilFreq * Time.time);
		cloudMesh.localPosition = cloudPos;

		/*
		if(Input.GetKeyDown (KeyCode.P)){
			if(walking)
				walking = false;
			else
				walking = true;
		}
		*/

		if(Vector3.ProjectOnPlane(destinies[currentDest].position - myTransform.position, Vector3.up).magnitude < nextCheckpointDist){
			currentDest++;
			if (currentDest >= destinies.Count)
				currentDest = 0;
			navAgent.SetDestination(destinies[currentDest].position);
		}

		if (Vector3.ProjectOnPlane(playerTransform.position - myTransform.position, Vector3.up).magnitude >= maxPlayerDist) {
			walking = false;
		}
		else{
			walking = true;
		}

		navAgent.isStopped = !walking;
		//Debug.Log("<color=blue>player dist:"+Vector3.Distance(playerTransform.position, myTransform.position).ToString()+"</color>");
	}
}
