using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneController : MonoBehaviour
{
    
    public Rigidbody2D rb2D;
    public float thrust = 0.1f;
    

    public float currentSpeed;
    public float maxSpeed = 1;

    public int angularChangeInDegrees = -20;

    [SerializeField] private int leftInput = 0;
    [SerializeField] private int rightInput = 0;

    void FixedUpdate()
    {   
        //Check Speed
        var vel = rb2D.velocity;
        currentSpeed = vel.magnitude; 
        //Lock Speed
        if (currentSpeed > maxSpeed)
        {
            currentSpeed = maxSpeed;
        }


        //Controls
        if (Input.GetKey(KeyCode.W))
        {
            leftInput = 1;
        } 
        else if (Input.GetKey(KeyCode.S))
        {
            leftInput = -1;
        }
        else 
        {
            leftInput = 0;
        }


        if (Input.GetKey(KeyCode.Y))
        {
            rightInput = 1;
        } 
        else if (Input.GetKey(KeyCode.G))
        {
            rightInput = -1;
        }
        else 
        {
            rightInput = 0;
        }

        //Left Positive  +   +  Right Positive
        if (leftInput == 1 && rightInput == 1)
        {
            //Go Forward
            rb2D.AddForce(transform.up * thrust);
        }

        //Left Negative  -   -  Right Negative
        if (leftInput == -1 && rightInput == -1)
        {
            //Go Backward
            rb2D.AddForce(-transform.up * thrust);
        }

        //Left Positive  +   o  Right Neutral
        if (leftInput == 1 && rightInput == 0)
        {
            //Right Ease
            rb2D.AddForce(transform.up * thrust);
            var impulse = (angularChangeInDegrees * Mathf.Deg2Rad) * rb2D.inertia;
            rb2D.AddTorque(impulse, ForceMode2D.Impulse);
        }

        //Left Neutral   o   +  Right Positive
        if (leftInput == 0 && rightInput == 1)
        {
            //Left Ease
            rb2D.AddForce(transform.up * thrust);
            var impulse = -(angularChangeInDegrees * Mathf.Deg2Rad) * rb2D.inertia;
            rb2D.AddTorque(impulse, ForceMode2D.Impulse);
        }

        //Left Negative  -   o  Right Neutral
        if (leftInput == -1 && rightInput == 0)
        {
            //Back Right Ease
            rb2D.AddForce(-transform.up * thrust);
            var impulse = -(angularChangeInDegrees * Mathf.Deg2Rad) * rb2D.inertia;
            rb2D.AddTorque(impulse, ForceMode2D.Impulse);
        }

        //Left Neutral   o   -  Right Negative
        if (leftInput == 0 && rightInput == -1)
        {
            //Back Left Ease
            rb2D.AddForce(-transform.up * thrust);
            var impulse = (angularChangeInDegrees * Mathf.Deg2Rad) * rb2D.inertia;
            rb2D.AddTorque(impulse, ForceMode2D.Impulse);
        }

        //Left Positive  +   -  Right Negative
        if (leftInput == 1 && rightInput == -1)
        {
            //Right Rotate
            var impulse = (angularChangeInDegrees * Mathf.Deg2Rad) * rb2D.inertia;
            rb2D.AddTorque(impulse * 2, ForceMode2D.Impulse);
        }

        //Left Negative  -   +  Right Positive
        if (leftInput == -1 && rightInput == 1)
        {
            //Left Rotate
            var impulse = -(angularChangeInDegrees * Mathf.Deg2Rad) * rb2D.inertia;
            rb2D.AddTorque(impulse * 2, ForceMode2D.Impulse);
        }
    }
    
}
