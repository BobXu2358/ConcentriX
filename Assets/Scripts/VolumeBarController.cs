using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeBarController : MonoBehaviour {

    public Sprite on = null;
    public Sprite off = null;
    public float soundLv = 0;
    public bool isOn = false;
    private bool changeFlag = false;

    // Use this for initialization
    void Start () {
        drawSoundBar();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUpAsButton()
    {
        if (!isOn)
        {
            GetComponent<SpriteRenderer>().sprite = on;
        }

        AudioListener.volume = soundLv / 10f;
        isOn = !isOn;

        Debug.Log(AudioListener.volume);
    }

    private void drawSoundBar()
    {
        if (AudioListener.volume >= soundLv)
        {
            GetComponent<SpriteRenderer>().sprite = on;
            isOn = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = off;
            isOn = false;
        }
    }
}
