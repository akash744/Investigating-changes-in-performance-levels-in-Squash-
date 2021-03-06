using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playableChar : MonoBehaviour
{
      /*
         Create a variable called 'rb' that will represent the
         rigid body of this object.
         */
         private Rigidbody rb;

         // Create a public variable for the cameraTarget object
         public GameObject cameraTarget;
         /*
         You will need to set the cameraTarget object in Unity.
         The direction this object is facing will be used to determine
         the direction of forces we will apply to our player.
         */
         public float movementIntensity;
         /*
         Creates a public variable that will be used to set
         the movement intensity (from within Unity)
         */

         void Start()
         {
         	// make our rb variable equal the rigid body component
             rb = GetComponent<Rigidbody>();
         }

         void Update()
         {
         	/*
         	Establish some directions
         	based on the cameraTarget object's orientation
         	*/
             var ForwardDirection = cameraTarget.transform.forward;
             var RightDirection = cameraTarget.transform.right;

             // Move Forwards
             if (Input.GetKey(KeyCode.W))
             {
                 rb.velocity = ForwardDirection * movementIntensity;
                 /* You may want to try using velocity rather than force.
                 This allows for a more responsive control of the movement
                 possibly better suited to first person controls, eg: */
                 //rb.velocity = ForwardDirection * movementIntensity;
             }
             // Move Backwards
             else if (Input.GetKey(KeyCode.S))
             {
                 // Adding a negative to the direction reverses it
                 rb.velocity = (-ForwardDirection * movementIntensity);
             }
             // Move Rightwards (eg Strafe. *We are using A & D to swivel)
             else if (Input.GetKey(KeyCode.E))
             {
                rb.velocity = (RightDirection * movementIntensity);
             }
             // Move Leftwards
             else if (Input.GetKey(KeyCode.Q))
             {
                rb.velocity = (-RightDirection * movementIntensity);
             }

             else {
                rb.Sleep();
             }
         }
}
