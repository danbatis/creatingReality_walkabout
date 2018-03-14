using System.Collections;
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

	// Use this for initialization
	void Start () {
		navAgent = GetComponent<NavMeshAgent>();	
		navAgent.SetDestination(destinies[currentDest].position);
		myTransform = transform;
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		cloudSpeedSlider = GameObject.Find ("GUI/Panel/cloudSpeed").GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
		navAgent.speed = cloudSpeedSlider.value;

		/*
		if(Input.GetKeyDown (KeyCode.P)){
			if(walking)
				walking = false;
			else
				walking = true;
		}
		*/

		if(Vector3.Distance(destinies[currentDest].position, myTransform.position) < nextCheckpointDist){
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
