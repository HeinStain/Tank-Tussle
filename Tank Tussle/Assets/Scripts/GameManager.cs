using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private InfoManager InfoManager;

    public GameObject playerPrefab;
    
    public GameObject playerOneSpawnPoint;
    public GameObject playerTwoSpawnPoint;

    void Start()
    {

        InfoManager = GameObject.FindObjectOfType<InfoManager>();

        SpawnPlayerOne();
        SpawnPlayerTwo();
        
    }


    void SpawnPlayerOne()
    {
        //Instantiate Player One, Color Them, Apply Script
        GameObject playerOne = Instantiate(playerPrefab, playerOneSpawnPoint.transform.position, Quaternion.identity);
        playerOne.AddComponent<PlayerOneController>();

        Color playerOneColor = InfoManager.playerOneColor;
        GameObject playerOneBase = playerOne.transform.GetChild(0).GetChild(2).gameObject;
        GameObject playerOneCannon = playerOne.transform.GetChild(0).GetChild(3).gameObject;
        
        playerOneBase.GetComponent<SpriteRenderer>().color = playerOneColor;
        playerOneCannon.GetComponent<SpriteRenderer>().color = playerOneColor;
    }

    void SpawnPlayerTwo()
    {
        //Instantiate Player Two, Color Them, Apply Script
        GameObject playerTwo = Instantiate(playerPrefab, playerTwoSpawnPoint.transform.position, Quaternion.identity);
        playerTwo.AddComponent<PlayerTwoController>();

        Color playerTwoColor = InfoManager.playerTwoColor;
        GameObject playerTwoBase = playerTwo.transform.GetChild(0).GetChild(2).gameObject;
        GameObject playerTwoCannon = playerTwo.transform.GetChild(0).GetChild(3).gameObject;
        
        playerTwoBase.GetComponent<SpriteRenderer>().color = playerTwoColor;
        playerTwoCannon.GetComponent<SpriteRenderer>().color = playerTwoColor;
    }
}

