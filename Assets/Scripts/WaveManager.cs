using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    GameObject companionWave;
    public float timeSinceLastWave;
    
    public bool alwaysOn;
    public bool enableEdgeCollision;
    public bool destroyRayOnCollision;
    public bool drawWaveSegments;
    public int numberOfRays;
    public float decayAlpha;
    public float edgeGlowObjectLifespan;
    public float frequency;  // waves per second
    public float initialRadius;
    public float radiusIncrementMultiplier;
    public Transform waveObject;
    public Transform waveSegmentObject;
    public Transform edgeGlowObject;

    // Use this for initialization
    void Start () {
        companionWave = null;
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
        } else if (alwaysOn) {
            if (companionWave == null) companionWave = Emit();
            companionWave.transform.position = transform.position;
        } else if (companionWave != null)
            companionWave.GetComponent<ConcentrxWave>().DestroyAll();
    }

    public GameObject Emit() {
        GameObject waveInstance = Instantiate(waveObject, transform.position, transform.rotation).gameObject;
        waveInstance.GetComponent<ConcentrxWave>().Initialize(enableEdgeCollision, destroyRayOnCollision, drawWaveSegments, numberOfRays, decayAlpha, edgeGlowObjectLifespan, radiusIncrementMultiplier, edgeGlowObject, waveSegmentObject);
        waveInstance.GetComponent<ConcentrxWave>().SetRadius(initialRadius);
        return waveInstance;
    }
}
