using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour {

    public float secondsForDestruction;

    float startTime;

	// Use this for initialization
	void Start () {
        // startTime = Time.realtimeSinceStartup;
        Destroy(gameObject, secondsForDestruction);
	}
	
	// Update is called once per frame
	void Update () {
        //float curTime = Time.realtimeSinceStartup;
		//if (curTime >= startTime + secondsForDestruction) {
        //    Destroy(this,)
        //}
	}
}
