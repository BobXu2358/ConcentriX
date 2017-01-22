using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public bool chase;
    float speed;
    Vector3 previousPosition;
    Animator animator;

    public float maxSpeed;
    public Transform Player;

    // Use this for initialization
    void Start () {
        //GameObject;
        chase = false;
        speed = maxSpeed;
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (chase) {
            //transform.rotation = Quaternion.LookRotation(Player.position - transform.position);
            //transform.rotation = Quaternion.AngleAxis(Vector3.Angle(transform.up, Player.position - transform.position), transform.forward);
            //transform.rotation = Quaternion.Euler(0, 0, Vector3.Angle(transform.up, Player.position - transform.position) * Vector3.Dot(transform.up, Player.position - transform.position));
            //transform.rotation = Quaternion.FromToRotation(transform.up, (Player.position - transform.position));
            Vector3 vectorToTarget = Player.position - transform.position;
            //float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); //Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
            //vectorToTarget.y = transform.position.y;
            transform.rotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);

            transform.Translate(transform.up * speed * Time.deltaTime);
        }

        if (previousPosition.Equals(transform.position))
            animator.SetInteger("state", 0);
        else animator.SetInteger("state", 1);

        previousPosition = transform.position;
    }
}
