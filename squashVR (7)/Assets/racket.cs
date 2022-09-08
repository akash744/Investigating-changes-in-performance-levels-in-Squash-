using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Valve.VR;


public class racket : MonoBehaviour
{

    Rigidbody rb;
    public Transform controller;
    [Range(0.0f, 360.0f)]
    public float rotateBy = 200f;

    public SteamVR_Action_Vibration hapticAction;

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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ball") {

            Pulse(1, 150, 75, SteamVR_Input_Sources.RightHand);
            Vector3 dir = controller.localPosition;
            Debug.Log(rb.rotation.eulerAngles.normalized);
            rb.velocity = controller.right * 30 + new Vector3(0, 20, 0); // (other.contacts[0].normal) (rb.rotation.eulerAngles.normalized) controller.forward dir.normalized * 6 + new Vector3(0, 4, 0);  //new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z) * 13 +
            Debug.Log("Collision");
            Debug.Log(transform.rotation.eulerAngles.x);
            Debug.Log(transform.rotation.eulerAngles.y);
            Debug.Log(transform.rotation.eulerAngles.z);
            //add force to the ball plus some upward force according to the shot being played
        }


    }

    void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source) {
        hapticAction.Execute(0, duration, frequency, amplitude, source);
    }
}
