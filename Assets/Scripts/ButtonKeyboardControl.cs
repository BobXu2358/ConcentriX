using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonKeyboardControl : MonoBehaviour {

    GameObject play = null;
    GameObject option = null;
    GameObject exit = null;

    Animator playAnim = null;
    Animator optionAnim = null;
    Animator exitAnim = null;

	// Use this for initialization
	void Start () {
        play = transform.Find("play").gameObject;
        option = transform.Find("option").gameObject;
        exit = transform.Find("exit").gameObject;

        playAnim = play.GetComponent<Animator>();
        optionAnim = option.GetComponent<Animator>();
        exitAnim = exit.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!playAnim.GetBool("selected") && !optionAnim.GetBool("selected") && !exitAnim.GetBool("selected"))
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                playAnim.SetBool("selected", true);
        }
        else if (playAnim.GetBool("selected"))
        {
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                playAnim.SetBool("selected", false);
                optionAnim.SetBool("selected", true);
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                playAnim.SetBool("selected", false);
                exitAnim.SetBool("selected", true);
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Application.LoadLevel("level1");
            }
        }
        else if (optionAnim.GetBool("selected"))
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                optionAnim.SetBool("selected", false);
                playAnim.SetBool("selected", true);
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Application.LoadLevel("option");
            }
        }
        else if (exitAnim.GetBool("selected"))
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                exitAnim.SetBool("selected", false);
                playAnim.SetBool("selected", true);
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Application.Quit();
            }
        }
    }
}
