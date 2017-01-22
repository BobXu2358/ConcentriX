using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaController : MonoBehaviour {

    float decayRate;

    public float alpha;
    public float lifespan;  // in seconds

	// Use this for initialization
	void Start () {
        decayRate = this.GetComponent<SpriteRenderer>().color.a / lifespan;
    }
	
	// Update is called once per frame
	void Update () {
        Color sc = this.GetComponent<SpriteRenderer>().color;
        this.GetComponent<SpriteRenderer>().color = new Color(sc.r, sc.g, sc.b, sc.a - decayRate * Time.deltaTime);  // Linear decay
        alpha = this.GetComponent<SpriteRenderer>().color.a;

        if (alpha <= 0)
            Destroy(gameObject);
    }

    void Initialize (float lifespan) {
        this.lifespan = lifespan;
    }
}
