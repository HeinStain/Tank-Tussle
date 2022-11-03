using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoController : MonoBehaviour
{
    
    public Rigidbody2D rb2D;
    public float thrust = 25;

    public float currentSpeed;
    public float maxSpeed = 1;

    public int angularChangeInDegrees = -45;

    [SerializeField] private int leftInput = 0;
    [SerializeField] private int rightInput = 0;

    private Animator leftTrackAnim;
    private Animator rightTrackAnim;

    void Start()
    {
        rb2D = this.gameObject.GetComponent<Rigidbody2D>();
        leftTrackAnim = this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Animator>();
        rightTrackAnim = this.gameObject.transform.GetChild(0).GetChild(1).GetComponent<Animator>();
    }

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
        if (Input.GetKey(KeyCode.E))
        {
            leftInput = 1;
            leftTrackAnim.SetTrigger("Forward");
        } 
        else if (Input.GetKey(KeyCode.D))
        {
            leftInput = -1;
            leftTrackAnim.SetTrigger("Backward");
        }
        else 
        {
            leftInput = 0;
            leftTrackAnim.SetTrigger("Idle");
        }


        if (Input.GetKey(KeyCode.U))
        {
            rightInput = 1;
            rightTrackAnim.SetTrigger("Forward");
        } 
        else if (Input.GetKey(KeyCode.H))
        {
            rightInput = -1;
            rightTrackAnim.SetTrigger("Backward");
        }
        else 
        {
            rightInput = 0;
            rightTrackAnim.SetTrigger("Idle");
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
