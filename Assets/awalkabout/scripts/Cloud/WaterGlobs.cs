using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGlobs : MonoBehaviour {
    /* 
     * WaterGlobs.cs: The cloud spews good and bad globs of water
     * which the patient needs to catch with their controller
     * Catching good globs increases 
     */

    public int goodGlobsCaught;
    public AudioSource audioManager;
    public AudioClip goodGlobClip;
    public float destructionTime = 3.0f;

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
            audioManager.PlayOneShot(goodGlobClip);
            goodGlobsCaught += 1;
        }
    }


}
