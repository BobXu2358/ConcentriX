using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour {

    public string levelToLoad = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gm = GameObject.Find("Game Manager");
        GameObject chip1 = GameObject.Find("Chip_1");
        GameObject chip2 = GameObject.Find("Chip_2");
        GameObject chip3 = GameObject.Find("Chip_3");

        if (chip1 != null)
            gm.GetComponent<GameManager>().chip1 = true;
        if (chip2 != null)
            gm.GetComponent<GameManager>().chip2 = true;
        if (chip3 != null)
            gm.GetComponent<GameManager>().chip3 = true;

        Application.LoadLevel(levelToLoad);
    }
}
