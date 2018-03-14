using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanGlobs : MonoBehaviour {

    public Rigidbody goodGlob;
    public Rigidbody badGlob;
    public float ratioOfGoodToBadGlobs;
    public float spawnSpeedMin = 1.0f;
    public float spawnSpeedMax = 5.0f;
    public Vector3 spawnScale = new Vector3(1.0f, 1.0f, 1.0f);
    public float directionPreference = 0.5f;
    
    public float yVelocity = 1.0f;
	Transform playerTransform;
	Transform myTransform;
	public float dclose = 0.3f;
	public float dfar = 1.0f;
	public float dropletSpeed = 0.5f;

	// Use this for initialization
	void Start () {
        StartCoroutine(InstantiateGlobs());
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		myTransform = transform;
	}

    IEnumerator InstantiateGlobs()
    {
        // The globs should be spawned at random intervals
        yield return new WaitForSeconds(Random.Range(spawnSpeedMin, spawnSpeedMax));

        // Set the initial position of the glob to be the position of the cloud, 
        // and spawn the glob from that point
        Vector3 newPosition = this.gameObject.transform.position;

        // Randomly spawn good and bad globs
        if (ratioOfGoodToBadGlobs > Random.Range(0.0f, 1.0f)) {
            SpawnGoodGlob(newPosition);
        } else {
            SpawnBadGlob(newPosition);
        }

        StartCoroutine(InstantiateGlobs());
    }

    void SpawnGoodGlob(Vector3 pos) {
        // Instantiate the rigidbody
        Rigidbody goodGlobInstance = Instantiate(goodGlob, pos, Quaternion.identity);
        SpeedAndSizeOfGlob(goodGlobInstance);
    }

    void SpawnBadGlob(Vector3 pos)
    {
        // Instantiate the rigidbody
        Rigidbody badGlobInstance = Instantiate(badGlob, pos, Quaternion.identity);
        SpeedAndSizeOfGlob(badGlobInstance);
    }

    void SpeedAndSizeOfGlob(Rigidbody glob){

        glob.gameObject.transform.localScale = spawnScale;

		//in xz plane, we calculate direction
		Vector3 dropletVel = Vector3.ProjectOnPlane (playerTransform.position - myTransform.position, Vector3.up);
		if (directionPreference >= Random.Range(0.0f, 1.0f))
        {
			dropletVel += Random.Range (dclose, dfar) * playerTransform.right;
        }
        else
        {
			dropletVel += (-1)*Random.Range (dclose, dfar) * playerTransform.right;
        }
		//adjust speed
		dropletVel = dropletSpeed*dropletVel.normalized;
		//in y direction
		dropletVel.y = -1.0f * yVelocity;

		glob.velocity = dropletVel;
    }
}
