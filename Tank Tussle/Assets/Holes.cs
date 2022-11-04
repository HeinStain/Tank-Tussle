using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holes : MonoBehaviour
{
    public float killTime = 1;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == ("Player"))
        {
            StartCoroutine(PlayerFall(col));
        }
    }

    IEnumerator PlayerFall(Collider2D col)
    {
        yield return new WaitForSeconds(killTime);
        col.SendMessage("FallToDeath");
    }

    void OnTriggerExit2D()
    {
        StopAllCoroutines();
    }
}
