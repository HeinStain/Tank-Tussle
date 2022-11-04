using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneController : MonoBehaviour
{
    
    public Rigidbody2D rb2D;
    public float thrust = 35;

    public float currentSpeed;
    public float maxSpeed = 1;

    public int angularChangeInDegrees = -45;

    [SerializeField] private int leftInput = 0;
    [SerializeField] private int rightInput = 0;

    private Animator leftTrackAnim;
    private Animator rightTrackAnim;

    public GameObject playerOneSpawnPoint;
    public GameManager GameManager;
    
    void Start()
    {
        rb2D = this.gameObject.GetComponent<Rigidbody2D>();
        leftTrackAnim = this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Animator>();
        rightTrackAnim = this.gameObject.transform.GetChild(0).GetChild(1).GetComponent<Animator>();
        playerOneSpawnPoint = GameObject.FindWithTag("PlayerOneSpawn");
        GameManager = GameObject.FindObjectOfType<GameManager>();
        AudioManager.instance.Play("Engine");
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
        if (Input.GetKey(KeyCode.RightArrow))
        {
            leftInput = 1;
            leftTrackAnim.SetTrigger("Forward");
        } 
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftInput = -1;
            leftTrackAnim.SetTrigger("Backward");
        }
        else 
        {
            leftInput = 0;
            leftTrackAnim.SetTrigger("Idle");
            
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            rightInput = 1;
            rightTrackAnim.SetTrigger("Forward");
        } 
        else if (Input.GetKey(KeyCode.DownArrow))
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
            AudioManager.instance.PitchUp("Engine");
        }

        //Left Negative  -   -  Right Negative
        if (leftInput == -1 && rightInput == -1)
        {
            //Go Backward
            rb2D.AddForce(-transform.up * thrust);
            AudioManager.instance.PitchUp("Engine");
        }

        //Left Positive  +   o  Right Neutral
        if (leftInput == 1 && rightInput == 0)
        {
            //Right Ease
            rb2D.AddForce(transform.up * thrust);
            var impulse = (angularChangeInDegrees * Mathf.Deg2Rad) * rb2D.inertia;
            rb2D.AddTorque(impulse, ForceMode2D.Impulse);
            AudioManager.instance.PitchUp("Engine");
        }

        //Left Neutral   o   +  Right Positive
        if (leftInput == 0 && rightInput == 1)
        {
            //Left Ease
            rb2D.AddForce(transform.up * thrust);
            var impulse = -(angularChangeInDegrees * Mathf.Deg2Rad) * rb2D.inertia;
            rb2D.AddTorque(impulse, ForceMode2D.Impulse);
            AudioManager.instance.PitchUp("Engine");
        }

        //Left Negative  -   o  Right Neutral
        if (leftInput == -1 && rightInput == 0)
        {
            //Back Right Ease
            rb2D.AddForce(-transform.up * thrust);
            var impulse = -(angularChangeInDegrees * Mathf.Deg2Rad) * rb2D.inertia;
            rb2D.AddTorque(impulse, ForceMode2D.Impulse);
            AudioManager.instance.PitchUp("Engine");
        }

        //Left Neutral   o   -  Right Negative
        if (leftInput == 0 && rightInput == -1)
        {
            //Back Left Ease
            rb2D.AddForce(-transform.up * thrust);
            var impulse = (angularChangeInDegrees * Mathf.Deg2Rad) * rb2D.inertia;
            rb2D.AddTorque(impulse, ForceMode2D.Impulse);
            AudioManager.instance.PitchUp("Engine");
        }

        //Left Positive  +   -  Right Negative
        if (leftInput == 1 && rightInput == -1)
        {
            //Right Rotate
            var impulse = (angularChangeInDegrees * Mathf.Deg2Rad) * rb2D.inertia;
            rb2D.AddTorque(impulse * 2, ForceMode2D.Impulse);
            AudioManager.instance.PitchUp("Engine");
        }

        //Left Negative  -   +  Right Positive
        if (leftInput == -1 && rightInput == 1)
        {
            //Left Rotate
            var impulse = -(angularChangeInDegrees * Mathf.Deg2Rad) * rb2D.inertia;
            rb2D.AddTorque(impulse * 2, ForceMode2D.Impulse);
            AudioManager.instance.PitchUp("Engine");
        }
        
        //Left Negative  o   o  Right Positive
        if (leftInput == 0 && rightInput == 0)
        {
            AudioManager.instance.PitchDown("Engine");
        }

    }


    //Falling in Holes Logic
    void FallToDeath()
    {
        Debug.Log("Fell to death");
        rb2D.isKinematic = true;
        rb2D.velocity = new Vector2(0,0);
        currentSpeed = 0;
        iTween.ScaleTo(this.gameObject, new Vector3(0,0,0), 2);
        StartCoroutine(Fall());
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(2);
        Respawn();
        yield return null;
    }

    public void Respawn()
    {
        Debug.Log("Respawning");
        AudioManager.instance.Play("Spawn");
        iTween.ScaleTo(this.gameObject, new Vector3(1.25f,1.25f,1f), 0);
        iTween.RotateTo(this.gameObject, new Vector3(0,0,0), 0);
        rb2D.bodyType = RigidbodyType2D.Dynamic;
        transform.position = playerOneSpawnPoint.transform.position;
        GameManager.PlayerOneHit();
        
    }
}
