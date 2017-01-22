using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour {

    public Sprite on = null;
    public Sprite off = null;
    float volume;
    GameObject[] bar = new GameObject[10];
    Animator backAni = null;

	// Use this for initialization
	void Start () {
        backAni = GameObject.Find("back").GetComponent<Animator>();
        //set bars to off first
        for (int i = 0; i < 10; i++)
        {
            bar[i] = transform.Find("bar" + i).gameObject;
            bar[i].GetComponent<SpriteRenderer>().sprite = off;
        }
        draw();

    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
            if (AudioListener.volume >= 0.1f)
                AudioListener.volume -= 0.1f;
            else
                AudioListener.volume = 0;


            backAni.SetBool("selected", false);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            
            if (AudioListener.volume <= 0.9f)
                AudioListener.volume += 0.1f;
            else
                AudioListener.volume = 1f;
                

            backAni.SetBool("selected", false);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            backAni.SetBool("selected", true);
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter)) && backAni.GetBool("selected"))
            Application.LoadLevel("menu");

        for (int i = 0; i < 10; i++)
        {
            bar[i] = transform.Find("bar" + i).gameObject;
            bar[i].GetComponent<SpriteRenderer>().sprite = off;
        }
        draw();
    }
    
    private void draw()
    {
        volume = AudioListener.volume;
        //then draw "on" based on current volume
        
        if (volume >= 0.99f)
            drawBar(10);
        else if (volume >= 0.89f && volume < 0.99f)
            drawBar(9);
        else if (volume >= 0.79f && volume < 0.89f)
            drawBar(8);
        else if (volume >= 0.69f && volume < 0.79f)
            drawBar(7);
        else if (volume >= 0.59f && volume < 0.69f)
            drawBar(6);
        else if (volume >= 0.49f && volume < 0.59f)
            drawBar(5);
        else if (volume >= 0.39f && volume < 0.49f)
            drawBar(4);
        else if (volume >= 0.29f && volume < 0.39f)
            drawBar(3);
        else if (volume >= 0.19f && volume < 0.29f)
            drawBar(2);
        else if (volume >= 0.09f && volume < 0.19f)
            drawBar(1);
            
  

    }
    //draw "on" volume bars based on volume
    private void drawBar(int count)
    {

        for(int i = 0; i < count; i++)
        {
            bar[i].GetComponent<SpriteRenderer>().sprite = on;
        }
    }
}
