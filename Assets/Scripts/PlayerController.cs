﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float speed;
    public float maxSpeed = 20f;
    Animator animator;
    private int rot = 0;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
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
            animator.SetInteger("state", 0);
        else animator.SetInteger("state", 1);

        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetInteger("state", 2);
            GetComponent<WaveManager>().Emit();
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("cast"))
            speed *= 0.5f;

        //float minDistance = GetComponent<BoxCollider2D>().size.x/2;
        transform.Translate(dir * speed * Time.deltaTime);
        //if (!map.GetComponent<CollisionController>().isPositionTranslatable(transform.position + new Vector3(dir.x, dir.y)*minDistance))
        //    transform.Translate(-dir * speed * Time.deltaTime);
    }
}
