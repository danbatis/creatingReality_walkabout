using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class cloudControl : MonoBehaviour {
	
	NavMeshAgent navAgent;
	Transform myTransform;
	bool walking;
	public List<Transform> destinies;
	int currentDest;
	public float nextCheckpointDist = 2.0f;
	public Transform playerTransform;
	public float maxPlayerDist = 2.0f;


	// Use this for initialization
	void Start () {
		navAgent = GetComponent<NavMeshAgent>();	
		navAgent.SetDestination(destinies[currentDest].position);
		myTransform = transform;
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
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

		if (Vector3.Distance (playerTransform.position, myTransform.position) >= maxPlayerDist) {
			walking = false;
		}
		else{
			walking = true;
		}

		navAgent.isStopped = !walking;
	}
}
