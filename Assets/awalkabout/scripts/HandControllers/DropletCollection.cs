using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropletCollection : MonoBehaviour {
    public string thisController = "R";

    public GameObject TrainingManager;

	// Use this for initialization
	void Start () {
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "goodGlob") {
            TrainingManager.GetComponent<VirtualPT>().GoodGlobCollected(thisController);
            Destroy(other.gameObject, 0.0f);

        }
        if (other.gameObject.tag == "badGlob") {
            TrainingManager.GetComponent<VirtualPT>().BadGlobCollected(thisController);
            Destroy(other.gameObject, 0.0f);
        }
    }
}
