using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int playerOneHealth = 3;
    public int playerTwoHealth = 3;
    
    public GameObject p1Heart3;
    public GameObject p1Heart2;
    public GameObject p1Heart1;

    public GameObject p2Heart3;
    public GameObject p2Heart2;
    public GameObject p2Heart1;

    public SceneLoader SceneLoader;
    public InfoManager InfoManager;
    public Canvas victoryCanvas;
    public Text victoryText;

    private bool endScreen = false;
    
    void Start()
    {
        InfoManager = GameObject.FindObjectOfType<InfoManager>();
    }
    void Update()
    {
        if (endScreen)
        {
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.G))
            {
                Destroy(InfoManager.gameObject);
                SceneLoader.ResetGame();
            }
        }
        
    }

    public void PlayerOneHit()
    {
        playerOneHealth--;
        Debug.Log(playerOneHealth);

        //Player1
        if (playerOneHealth == 2)
        {
            p1Heart3.SetActive(false);
        }
        if (playerOneHealth == 1)
        {
            p1Heart2.SetActive(false);
        }
        if (playerOneHealth == 0)
        {
            p1Heart1.SetActive(false);
            //player 2 Wins
            victoryText.text = ("Player Two Wins!");
            victoryCanvas.enabled = true;
            victoryCanvas.gameObject.SetActive(true);
            endScreen = true;
        }
        
    }

    public void PlayerTwoHit()
    {
        playerTwoHealth--;
        Debug.Log(playerTwoHealth);

        //Player2
        if (playerTwoHealth == 2)
        {
            p2Heart3.SetActive(false);
        }
        if (playerTwoHealth == 1)
        {
            p2Heart2.SetActive(false);
        }
        if (playerTwoHealth == 0)
        {
            p2Heart1.SetActive(false);
            victoryText.text = ("Player One Wins!");
            victoryCanvas.gameObject.SetActive(true);
            endScreen = true;

        }
    }
}
