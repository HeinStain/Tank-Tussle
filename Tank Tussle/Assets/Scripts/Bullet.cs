using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Kill());
    }
    IEnumerator Kill()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {   
        if (col.gameObject.tag == "Walls")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
