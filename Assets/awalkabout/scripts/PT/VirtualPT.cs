using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualPT : MonoBehaviour {

    AudioSource audioManager;

    public AudioClip goodGlobSound;
    public AudioClip badGlobSound;
    public AudioClip mushroomSquishSound;

    public GameObject mountainFeedback;

    public int goodGlobsCollected;
    public int badGlobsCollected;
    public int obstaclesCrushed;
    public int feedbackLayer = 0;
    public int maxFeedbackLayer = 7;

    public int feedbackAfterNumberOfGlobsConnected;

    int rightControllerGlobs;
    int leftControllerGlobs;
	// Use this for initialization
    void Start () {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioSource>();
	}

    public void GoodGlobCollected(string controller) {
		Debug.Log ("collected good glob");
        goodGlobsCollected += 1;
        audioManager.PlayOneShot(goodGlobSound);

        if (controller == "R") {
            rightControllerGlobs += 1;
        } else {
            leftControllerGlobs += 1;
        }
        if (goodGlobsCollected % feedbackAfterNumberOfGlobsConnected == 0) {
            // then show the feedback on the mountains
            if (feedbackLayer < maxFeedbackLayer) {
                feedbackLayer += 1;
                mountainFeedback.GetComponent<FlowerBlossoms>().GrowFlowers(feedbackLayer);
            }
        }

    }

	public void BadGlobCollected(string controller) {
		Debug.Log ("collected bad glob");
        badGlobsCollected += 1;
        audioManager.PlayOneShot(badGlobSound);
    }

    public void ObstacleEncountered() {
        audioManager.PlayOneShot(mushroomSquishSound);
    }
}
