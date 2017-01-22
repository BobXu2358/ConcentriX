using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float maxSpeed = 1f;
    float speed = 1f;
    Animator anim;
    private int rot = 0;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<WaveManager>().transform.position = this.transform.position;
        speed = maxSpeed;

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
        else {
            anim.SetInteger("state", 1);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            anim.SetInteger("state", 2);
            GetComponent<WaveManager>().Emit();
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("cast"))
            speed *= 0.4f;
            
        //float minDistance = GetComponent<BoxCollider2D>().size.x/2;
        transform.Translate(dir * speed * Time.deltaTime);
        //if (!map.GetComponent<CollisionController>().isPositionTranslatable(transform.position + new Vector3(dir.x, dir.y)*minDistance))
        //    transform.Translate(-dir * speed * Time.deltaTime);
    }
}
