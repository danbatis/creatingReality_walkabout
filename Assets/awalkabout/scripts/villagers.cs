using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class villagers : MonoBehaviour {
	NavMeshAgent navAgent;
	Transform myTransform;
	public List<Transform> destinies;
	public int currentDest;
	public float nextCheckpointDist = 2.0f;

	public float maxPlayerDist = 2.0f;

	// Use this for initialization
	void Start () {
		navAgent = GetComponent<NavMeshAgent>();	
		navAgent.SetDestination(destinies[currentDest].position);
		navAgent.isStopped = false;
		myTransform = transform;
	}

	// Update is called once per frame
	void Update(){
		if(Vector3.ProjectOnPlane(destinies[currentDest].position - myTransform.position, Vector3.up).magnitude < nextCheckpointDist){
			currentDest++;
			if (currentDest >= destinies.Count)
				currentDest = 0;
			navAgent.SetDestination(destinies[currentDest].position);
		}
	}
}
