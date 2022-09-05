using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class racket : MonoBehaviour
{

    Rigidbody rb;
    public Transform controller;
    [Range(0.0f, 360.0f)]
    public float rotateBy = 200f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(controller.position);
        //rb.MoveVelocity(controller.velocity);
        rb.MoveRotation(controller.rotation * Quaternion.Euler(rotateBy, 0, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        //other.GetComponent<Rigidbody>().velocity =  new Vector3(0, 5, 0); //new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z) * 13 +
        Debug.Log("Collision");
        Debug.Log(transform.rotation.eulerAngles.x);
        Debug.Log(transform.rotation.eulerAngles.y);
        Debug.Log(transform.rotation.eulerAngles.z);
        //add force to the ball plus some upward force according to the shot being played

    }
}
