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
    public float startAngle = -180f;
    public float endAngle = 180f;
    public float decayAlpha;
    public float edgeGlowObjectLifespan;
    public float frequency;  // waves per second
    public float initialRadius;
    public float radiusIncrementMultiplier;
    public float[] diameters;
    public Color waveColor;
    public Transform waveObject;
    public Transform waveSegmentObject;
    public Transform edgeGlowObject;
    public Transform[] sprites;

    // Use this for initialization
    void Start() {
        companionWave = null;
        timeSinceLastWave = 0f;

        SetupSprites();
        if (startAngle > endAngle) {
            float t = startAngle;
            startAngle = endAngle;
            endAngle = t;
        }
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
        waveInstance.GetComponent<ConcentrxWave>().SetRadius(initialRadius);
        waveInstance.GetComponent<ConcentrxWave>().SetSprites(diameters, sprites);
        waveInstance.GetComponent<ConcentrxWave>().SetAngles(startAngle, endAngle);
        waveInstance.GetComponent<ConcentrxWave>().Initialize(enableEdgeCollision, destroyRayOnCollision, drawWaveSegments, numberOfRays, decayAlpha, edgeGlowObjectLifespan, radiusIncrementMultiplier, edgeGlowObject, waveSegmentObject);
        return waveInstance;
    }

    void SetupSprites() {
        for (int i=0; i < sprites.Length; i++) {
            diameters[i] /= sprites[i].GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
            sprites[i].GetComponent<SpriteRenderer>().color = waveColor;
        }
    }

    public bool isHittingObject() {
        return companionWave.GetComponent<ConcentrxWave>().isHittingObject();
    }
}
