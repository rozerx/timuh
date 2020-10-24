using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMove : MonoBehaviour
{
    public Transform[] target;
    public Transform[] points;
    Animator animator;

    public float speed = 2f;

    private int waypointIndex = 0;

    private void Start()
    {
        transform.position = points[waypointIndex].transform.position;
    }



    void Update()
    {
        Move();
        //animator.SetBool("isWalking", true);
        //if (transform.position != target[current].position)
        //{
        //    Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
        //    GetComponent<Rigidbody>().MovePosition(pos);
        //}
        //else current = (current + 1) % target.Length;
    }

    private void Move()
    {
        if(waypointIndex <= points.Length - 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[waypointIndex].transform.position, speed * Time.deltaTime);

            if (transform.position == points[waypointIndex].transform.position)
                waypointIndex += 1;
        }
    }
}
