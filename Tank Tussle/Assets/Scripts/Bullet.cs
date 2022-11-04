using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    IEnumerator Kill()
    {
        yield return new WaitForSeconds(3);
        Destroy(this);
    }

    void OnCollisionEnter2D()
    {
        Destroy(this);
    }
}
