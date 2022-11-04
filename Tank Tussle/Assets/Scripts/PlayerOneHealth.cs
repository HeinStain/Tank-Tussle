using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneHealth : MonoBehaviour
{
    public GameManager GameManager;
    private PlayerOneController PlayerOneController;

    void Start()
    {
        GameManager = GameObject.FindObjectOfType<GameManager>();
        PlayerOneController = this.gameObject.GetComponent<PlayerOneController>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet")
        {
            GameManager.PlayerOneHit();
            PlayerOneController.Respawn();

            Debug.Log("PlayerOneHit");
        }
    }
}
