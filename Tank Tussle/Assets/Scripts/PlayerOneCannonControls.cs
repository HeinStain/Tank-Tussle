using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class PlayerOneCannonControls : MonoBehaviour
{
    public GameObject point;
    public GameObject shotOrigin;

    public GameObject bulletPrefab;
    public float bulletForce = 10;
    public float rotateSpeed = 30;

    public float bulletInterval = 1.1f;
    public bool shootable = true;

    public InfoManager InfoManager;
    public GameObject playerOneShotCharge;

    private SerialPort stream = new SerialPort("COM2", 9600);
    private string arduinoInput;

    void Start()
    {
        stream.Open();
        
        point = this.transform.GetChild(0).gameObject;
        shotOrigin = this.transform.GetChild(1).gameObject;

        bulletPrefab = (GameObject)Resources.Load("Bullet", typeof(GameObject));
        InfoManager = GameObject.FindObjectOfType<InfoManager>();
        playerOneShotCharge = GameObject.FindWithTag("PlayerOneCharge");
        
    }
    void Update()
    {
        arduinoInput = stream.ReadLine();

        if (Input.GetKeyDown(KeyCode.F))  
        {
            Shoot();
        }

        if (int.Parse(arduinoInput) == 1) //if var = 1
        {
            transform.RotateAround(point.transform.position, -transform.forward, rotateSpeed * Time.deltaTime);
        }
        else if (int.Parse(arduinoInput) == 0) //if var = 0
        {
            transform.RotateAround(point.transform.position, transform.forward, rotateSpeed * Time.deltaTime);
        }
    }

    void Shoot()
    {
        if (shootable)
        {
            AudioManager.instance.Play("Shot");
            GameObject bullet = Instantiate(bulletPrefab, shotOrigin.transform.position, shotOrigin.transform.rotation);
            bullet.GetComponent<SpriteRenderer>().color = InfoManager.playerOneColor;
            Rigidbody2D bulletRigidbody2D = bullet.GetComponent<Rigidbody2D>();

            bulletRigidbody2D.AddForce(shotOrigin.transform.up * bulletForce, ForceMode2D.Impulse);
            StartCoroutine("ShootInterval");
        } 
        else
        {
            return;
        }
    }

    IEnumerator ShootInterval()
    {
        shootable = false;
        playerOneShotCharge.GetComponent<Animator>().SetTrigger("Charging");
        yield return new WaitForSeconds(bulletInterval);
        shootable = true;
    }
}
