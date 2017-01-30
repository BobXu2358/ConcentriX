using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool chip1 = false;
    public bool chip2 = false;
    public bool chip3 = false;
    public int hp = 1;
    public int maxEnergy = 3;
    public int chances = 3;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "splash")
        {
            Application.LoadLevel("menu");
        }
		if(chip1 && chip2 && chip3)
        {
            Application.LoadLevel("accomplish");
        }
        if(hp <= 0)
        {
            chances--;
            Application.LoadLevel("fail");
        }
        if(chances <= 0)
        {
            Application.LoadLevel("dead");
        }
	}
}
