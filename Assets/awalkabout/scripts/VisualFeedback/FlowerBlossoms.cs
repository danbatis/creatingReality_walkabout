using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBlossoms : MonoBehaviour {
    public GameObject[] flowersLayer1;
    public GameObject[] flowersLayer2;
    public GameObject[] flowersLayer3;
    public GameObject[] flowersLayer4;
    public GameObject[] flowersLayer5;
    public GameObject[] flowersLayer6;
    public GameObject[] flowersLayer7;

    public float growthDuration = 3.0f;

    Vector3 finalSize = new Vector3(1.0f, 1.0f, 1.0f);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GrowFlowers(int layer) {
        // default is flower layer 1
        GameObject[] flowerLayer = flowersLayer1;
        switch (layer)
        {
            case(1):
                flowerLayer = flowersLayer1;
                break;
            case (2):
                flowerLayer = flowersLayer2;
                break;
            case (3):
                flowerLayer = flowersLayer3;
                break;
            case (4):
                flowerLayer = flowersLayer4;
                break;
            case (5):
                flowerLayer = flowersLayer5;
                break;
            case (6):
                flowerLayer = flowersLayer6;
                break;
            case (7):
                flowerLayer = flowersLayer7;
                break;
            default:
                break;
        }
        foreach (GameObject flower in flowerLayer) {
            flower.transform.localScale = Vector3.Lerp(flower.transform.localScale, finalSize, Time.deltaTime * growthDuration);
        }
    }
}
