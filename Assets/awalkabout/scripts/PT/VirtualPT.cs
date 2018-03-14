using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualPT : MonoBehaviour {

    AudioSource audioManager;

    public AudioClip goodGlobSound;
    public AudioClip badGlobSound;
    public AudioClip mushroomSquishSound;

    public GameObject remoteObstacle;

    public GameObject mountainFeedback;
    public GameObject UDPClient;

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

    void Update() {
        if (UDPClient != null)
        {
            if (UDPClient.GetComponent<UDPReceive>().MessageBool == true)
            {
                remoteObstacle.SetActive(true);
            }
            else
            {

                remoteObstacle.SetActive(false);
            }
        }
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

        Debug.Log("Checking if we can make flowers grow");
        if (goodGlobsCollected % feedbackAfterNumberOfGlobsConnected == 0) {
            // then show the feedback on the mountains
            if (feedbackLayer < maxFeedbackLayer) {
                feedbackLayer += 1;
                Debug.Log("Make flowers grow");
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

    public void AddObstacle() {
        Debug.Log("Added obstacle");
        remoteObstacle.SetActive(true);
    }

    public void RemoveObstacle()
    {
        Debug.Log("Remove obstacle");
        remoteObstacle.SetActive(false);
    }
}
