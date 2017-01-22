using UnityEngine;
using System.Collections;

public class ConcentrxWave : MonoBehaviour {

    bool enableEdgeCollision;
    bool destroyRayOnCollision;
    bool drawWaveSegments;
    bool[] blacklist;
    int numberOfRays;
    float alpha;
    float decayAlpha;
    float edgeGlowObjectLifespan;
    float radiusIncrementMultiplier;
    float radius;
    Transform edgeGlowObject;
    Transform waveSegmentObject;
    Quaternion[] angles;
    GameObject[] segments;

    // Use this for initialization
    void Start() {
        alpha = 1f;
    }
	
	// Update is called once per frame
	void Update () {
        radius += Time.deltaTime * radiusIncrementMultiplier;

        if (enableEdgeCollision)
            CheckCollision(radius, 1 >> LayerMask.NameToLayer("Default"));

        UpdateWaveSegments();

        if (alpha <= 0f) {
            DestroyAll();
        }

        alpha -= Time.deltaTime * decayAlpha;
	}

    public void Initialize(bool enableEdgeCollision, bool destroyRayOnCollision, bool drawWaveSegments, int numberOfRays, float decayAlpha, float edgeGlowObjectLifespan, float radiusIncrementMultiplier, Transform edgeGlowObject, Transform waveSegmentObject) {
        this.enableEdgeCollision = enableEdgeCollision;
        this.destroyRayOnCollision = destroyRayOnCollision;
        this.drawWaveSegments = drawWaveSegments;
        this.numberOfRays = numberOfRays;
        this.decayAlpha = decayAlpha;
        this.edgeGlowObjectLifespan = edgeGlowObjectLifespan;
        this.radiusIncrementMultiplier = radiusIncrementMultiplier;
        this.edgeGlowObject = edgeGlowObject;
        this.waveSegmentObject = waveSegmentObject;

        this.SetupRayAngles();
        this.SetupWaveSegments();
    }

    void CheckCollision(float collisionRadius, int layerMask) {
        GameObject instanciatedObject;

        for (int i = 0; i < numberOfRays - 1; i++) {
            this.transform.rotation = angles[i];
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, transform.up, collisionRadius, layerMask);
            //Debug.DrawLine(center, hit.point, Color.yellow, 0.1f);
            if (hit.collider != null && !blacklist[i]) {
                //Debug.DrawRay(this.transform.position, transform.up * magnitude, Color.yellow, 0.1f);
                if (destroyRayOnCollision)
                    blacklist[i] = true;
                instanciatedObject = Instantiate(edgeGlowObject, hit.point, Quaternion.FromToRotation(edgeGlowObject.up, hit.normal)).gameObject;
                instanciatedObject.GetComponent<AlphaController>().Initialize(edgeGlowObjectLifespan);
            }
        }
    }

    void SetupRayAngles() {
        blacklist = new bool[numberOfRays - 1];
        angles = new Quaternion[numberOfRays - 1];

        float angle = 0f, angleIncrement = 360f / (float)numberOfRays;
        for (int i = 0; i < angles.Length; i++) {
            blacklist[i] = false;
            angles[i] = Quaternion.AngleAxis(angle, Vector3.forward);
            angle += angleIncrement;
        }
    }

    void SetupWaveSegments() {
        segments = new GameObject[numberOfRays - 1];
        for (int i = 0; i < numberOfRays - 1; i++) {
            segments[i] = Instantiate(waveSegmentObject, transform.position + angles[i] * transform.up * radius, angles[i]).gameObject;
            if (!drawWaveSegments) segments[i].GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void UpdateWaveSegments() {
        for (int i = 0; i < numberOfRays - 1; i++) {
            if (!blacklist[i]) {
                Color sc = segments[i].GetComponent<SpriteRenderer>().color;
                segments[i].transform.position = transform.position + angles[i] * transform.up * radius;
                segments[i].GetComponent<SpriteRenderer>().color = new Color(sc.r, sc.g, sc.b, alpha);
            } else segments[i].GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void SetRadius(float radius) {
        this.radius = radius;
    }

    public void DestroyAll() {
        for (int i = 0; i < numberOfRays - 1; i++)
            Destroy(segments[i]);
        Destroy(gameObject);
    }
}
