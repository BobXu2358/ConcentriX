using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    public float timeSinceLastWave;

    public bool enableEdgeCollision;
    public int numberOfRays;
    public float decayAlpha;
    public float edgeGlowObjectLifespan;
    public float radiusIncrementMultiplier;
    public float frequency;  // waves per second
    public Transform waveObject;
    public Transform waveSegmentObject;
    public Transform edgeGlowObject;

    // Use this for initialization
    void Start () {
        timeSinceLastWave = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (frequency > 0) {
            timeSinceLastWave += Time.deltaTime;
            if (timeSinceLastWave >= 1f / frequency) {
                Emit();
                timeSinceLastWave = 0f;
            }
        }
	}

    public void Emit() {
        GameObject waveInstance = Instantiate(waveObject, transform.position, transform.rotation).gameObject;
        waveInstance.GetComponent<ConcentrxWave>().Initialize(enableEdgeCollision, numberOfRays, decayAlpha, edgeGlowObjectLifespan, radiusIncrementMultiplier, edgeGlowObject, waveSegmentObject);
    }
}
