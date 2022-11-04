using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoHealth : MonoBehaviour
{
    public GameManager GameManager;
    private PlayerTwoController PlayerTwoController;

    void Start()
    {
        GameManager = GameObject.FindObjectOfType<GameManager>();
        PlayerTwoController = this.gameObject.GetComponent<PlayerTwoController>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet")
        {
            GameManager.PlayerTwoHit();
            PlayerTwoController.Respawn();
            Debug.Log("PlayerTwoHit");
        }
    }
}
