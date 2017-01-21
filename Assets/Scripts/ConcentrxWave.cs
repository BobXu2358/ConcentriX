using UnityEngine;
using System.Collections;

public class ConcentrxWave : MonoBehaviour {

    bool enableEdgeCollision;
    bool[] blacklist;
    int numberOfRays;
    float decayAlpha;
    float edgeGlowObjectLifespan;
    float radiusIncrementMultiplier;
    float radius;
    Transform edgeGlowObject;
    SpriteRenderer sp;
    Quaternion[] angles;

    // Use this for initialization
    void Start () {
        radius = 0f;
        sp = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        radius += Time.deltaTime * radiusIncrementMultiplier;
        
        sp.transform.localScale = new Vector3(radius, radius, 0);
        sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, sp.color.a - Time.deltaTime * decayAlpha);

        if (enableEdgeCollision)
            CheckCollision(sp.bounds.size.x / 2 * 0.87f, 1 >> LayerMask.NameToLayer("Default"));

        if (sp.color.a <= 0) {
            Destroy(gameObject);
        }
	}

    public void Initialize(bool enableEdgeCollision, int numberOfRays, float decayAlpha, float edgeGlowObjectLifespan, float radiusIncrementMultiplier, Transform edgeGlowObject) {
        this.enableEdgeCollision = enableEdgeCollision;
        this.numberOfRays = numberOfRays;
        this.decayAlpha = decayAlpha;
        this.edgeGlowObjectLifespan = edgeGlowObjectLifespan;
        this.radiusIncrementMultiplier = radiusIncrementMultiplier;
        this.edgeGlowObject = edgeGlowObject;

        this.SetupRayAngles();
    }

    void CheckCollision(float collisionRadius, int layerMask) {
        GameObject instanciatedObject;

        for (int i = 0; i < numberOfRays - 1; i++)
        {
            this.transform.rotation = angles[i];
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, transform.up, collisionRadius, layerMask);
            //Debug.DrawLine(center, hit.point, Color.yellow, 0.1f);
            if (hit.collider != null && !blacklist[i])
            {
                //Debug.DrawRay(this.transform.position, transform.up * magnitude, Color.yellow, 0.1f);
                blacklist[i] = true;
                instanciatedObject = Instantiate(edgeGlowObject, hit.point, Quaternion.FromToRotation(edgeGlowObject.up, hit.normal)).gameObject;
                Destroy(instanciatedObject, edgeGlowObjectLifespan);
            }
        }
    }

    void SetupRayAngles() {
        blacklist = new bool[numberOfRays - 1];
        angles = new Quaternion[numberOfRays - 1];

        float angle = 0f, angleIncrement = 360f / (float)numberOfRays;
        for (int i = 0; i < angles.Length; i++)
        {
            blacklist[i] = false;
            angles[i] = Quaternion.AngleAxis(angle, Vector3.forward);
            angle += angleIncrement;
        }
    }
}
