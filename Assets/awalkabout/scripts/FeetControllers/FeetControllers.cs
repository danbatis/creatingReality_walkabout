using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetControllers : MonoBehaviour {
    /* 
     * Feet Control, detects if feet touch any obstacles
     */
    // Use this for initialization
    public GameObject TrainingManager;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle") {
            TrainingManager.GetComponent<VirtualPT>().ObstacleEncountered();
        }
    }
}
