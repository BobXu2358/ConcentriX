using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPosition : MonoBehaviour {

    public Transform player;

	// Use this for initialization
	void Start () {
        player.transform.position = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
