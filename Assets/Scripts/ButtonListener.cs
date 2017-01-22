using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListener : MonoBehaviour {

    public bool isExit = false;
    public string SceneToLoad = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUpAsButton()
    {
        if (isExit)
            Application.Quit();
        else
            Application.LoadLevel(SceneToLoad);
    }
}
