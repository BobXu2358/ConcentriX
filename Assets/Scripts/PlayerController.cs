using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 1f;
    Animator anim;
    private int rot = 0;
    public Transform wave;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 dir = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            dir = Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
            dir = Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            dir = Vector2.up;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.AngleAxis(270, Vector3.forward);
            dir = Vector2.up;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.AngleAxis(45, Vector3.forward);
            dir = Vector2.up;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.AngleAxis(315, Vector3.forward);
            dir.x = 1;
            dir.y = 1;
            dir = Vector2.up;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.AngleAxis(135, Vector3.forward);
            dir.x = -1;
            dir.y = -1;
            dir = Vector2.up;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.AngleAxis(225, Vector3.forward);
            dir.x = 1;
            dir.y = -1;
            dir = Vector2.up;
        }


        if (dir.Equals(Vector2.zero))
            anim.SetInteger("state", 0);
        else
        {
            anim.SetInteger("state", 1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetInteger("state", 2);
            Emit();
        }

        transform.Translate(dir * speed * Time.deltaTime);
    }

    void Emit() {
        GameObject waveObject = Instantiate(wave).gameObject;
        waveObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 8);
    }
}
