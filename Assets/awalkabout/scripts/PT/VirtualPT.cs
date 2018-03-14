using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualPT : MonoBehaviour {

    AudioSource audioManager;

    public AudioClip goodGlobSound;
    public AudioClip badGlobSound;
    public AudioClip mushroomSquishSound;

    public int goodGlobsCollected;
    public int badGlobsCollected;
    public int obstaclesCrushed;

    int rightControllerGlobs;
    int leftControllerGlobs;
	// Use this for initialization
    void Start () {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioSource>();
	}

    public void GoodGlobCollected(string controller) {
        goodGlobsCollected += 1;
        audioManager.PlayOneShot(goodGlobSound);

        if (controller == "R") {
            rightControllerGlobs += 1;
        } else {
            leftControllerGlobs += 1;
        }
    }

    public void BadGlobCollected(string controller) {
        badGlobsCollected += 1;
        audioManager.PlayOneShot(badGlobSound);
    }

    public void ObstacleEncountered() {
        audioManager.PlayOneShot(mushroomSquishSound);
    }
}
