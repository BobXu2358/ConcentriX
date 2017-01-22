using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    Animator anim = null;

	// Use this for initialization
	void Start () {
        //get child gameobject
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        anim.SetBool("selected", true);
    }

    private void OnMouseExit()
    {
        anim.SetBool("selected", false);
    }
}
