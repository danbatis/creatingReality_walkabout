using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadWaterGlobs : MonoBehaviour {

    public int goodGlobsCaught;
    public AudioSource audioManager;
    public AudioClip badGlobClip;
    public float destructionTime = 3.0f;
    public float gravityMultiplier = 0.3f;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, destructionTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "player") {
            // If the player catches this water glob, 
            // then play the bad glob sound and inform the manager
            audioManager.PlayOneShot(badGlobClip);
        }
    }

    private void FixedUpdate()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(Physics.gravity * gravityMultiplier);
    }
}
