using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoCannonControls : MonoBehaviour
{
    public GameObject point;
    public GameObject shotOrigin;

    public GameObject bulletPrefab;
    public float bulletForce = 10;
    public float rotateSpeed = 30;

    public float bulletInterval = 1.1f;
    public bool shootable = true;

    public InfoManager InfoManager;
    public GameObject playerTwoShotCharge;

    void Start()
    {
        point = this.transform.GetChild(0).gameObject;
        shotOrigin = this.transform.GetChild(1).gameObject;

        bulletPrefab = (GameObject)Resources.Load("Bullet", typeof(GameObject));
        InfoManager = GameObject.FindObjectOfType<InfoManager>();
        playerTwoShotCharge = GameObject.FindWithTag("PlayerTwoCharge");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Shoot();
        }

        if (Input.GetKey(KeyCode.L))
        {;
            transform.RotateAround(point.transform.position, -transform.forward, rotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.K))
        {
            transform.RotateAround(point.transform.position, transform.forward, rotateSpeed * Time.deltaTime);
        }
            
    }

    void Shoot()
    {
        if (shootable)
        {
            GameObject bullet = Instantiate(bulletPrefab, shotOrigin.transform.position, shotOrigin.transform.rotation);
            bullet.GetComponent<SpriteRenderer>().color = InfoManager.playerTwoColor;
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
        playerTwoShotCharge.GetComponent<Animator>().SetTrigger("Charging");
        yield return new WaitForSeconds(bulletInterval);
        shootable = true;
    }
}
