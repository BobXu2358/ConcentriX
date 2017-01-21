using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<WaveManager>().transform.position = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
