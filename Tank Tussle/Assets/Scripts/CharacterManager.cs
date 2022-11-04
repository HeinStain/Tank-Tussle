using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{

    public SceneLoader SceneLoader;
    public InfoManager InfoManager;

    public Text countdownText;

    //Player 1
    public GameObject playerOneBody;
    public GameObject playerOneTurret;
    public GameObject playerOneReadyBox;
    public int playerOneSelection;
    private Color playerOneSelectedColor;
    private bool playerOneReady = false;
    

    //Player 1 Colors
    public GameObject p1_1Selected;
    public GameObject p1_2Selected;
    public GameObject p1_3Selected;
    public GameObject p1_4Selected;
    public GameObject p1_5Selected;
    public GameObject p1_6Selected;
    public GameObject p1_7Selected;
    public GameObject p1_8Selected;


    //Player 2
    public GameObject playerTwoBody;
    public GameObject playerTwoTurret;
    public GameObject playerTwoReadyBox;
    public int playerTwoSelection;
    private Color playerTwoSelectedColor;
    private bool playerTwoReady = false;

    //Player 2 Colors
    public GameObject p2_1Selected;
    public GameObject p2_2Selected;
    public GameObject p2_3Selected;
    public GameObject p2_4Selected;
    public GameObject p2_5Selected;
    public GameObject p2_6Selected;
    public GameObject p2_7Selected;
    public GameObject p2_8Selected;
    
 

    void Start()
    {
        InfoManager = GameObject.FindObjectOfType<InfoManager>();
        playerOneSelection = 1;
        UpdatePlayerOneColor(playerOneSelection);

        playerTwoSelection = 1;
        UpdatePlayerTwoColor(playerTwoSelection);
    }

    void Update()
    {
        //Player One Controls
        if (!playerOneReady)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (playerOneSelection <= 8)
                {
                    playerOneSelection++;
                }
                if (playerOneSelection > 8)
                {
                    playerOneSelection = 1;
                }
                UpdatePlayerOneColor(playerOneSelection);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (playerOneSelection >= 1)
                {
                    playerOneSelection--;
                }
                if (playerOneSelection < 1)
                {
                    playerOneSelection = 8;
                }
                UpdatePlayerOneColor(playerOneSelection);
            }       
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            playerOneReady = true;
            playerOneReadyBox.GetComponent<Image>().color = new Color32(62, 162, 27, 255);
        }


         //Player Two Controls
        if (!playerTwoReady)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (playerTwoSelection <= 8)
                {
                    playerTwoSelection++;
                }
                if (playerTwoSelection > 8)
                {
                    playerTwoSelection = 1;
                }
                UpdatePlayerTwoColor(playerTwoSelection);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (playerTwoSelection >= 1)
                {
                    playerTwoSelection--;
                }
                if (playerTwoSelection < 1)
                {
                    playerTwoSelection = 8;
                }
                UpdatePlayerTwoColor(playerTwoSelection);
            }       
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            playerTwoReady = true;
            playerTwoReadyBox.GetComponent<Image>().color = new Color32(62, 162, 27, 255);
        }

        //Final Ready Check
        if (playerOneReady && playerTwoReady && nextLevelCountdown == null)
        {
            nextLevelCountdown = StartCoroutine(StartNextLevel());
            //InfoManager.StorePlayerOneColour(playerOneSelectedColor); 
            InfoManager.SendMessage("StorePlayerOneColour", playerOneSelectedColor);
            InfoManager.SendMessage("StorePlayerTwoColour", playerTwoSelectedColor);
        }
    }

    Coroutine nextLevelCountdown;

    IEnumerator StartNextLevel()
    {
        countdownText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        countdownText.text = "2";
        yield return new WaitForSeconds(1);
        countdownText.text = "1";
        yield return new WaitForSeconds(1);
        countdownText.text = "0";
        yield return new WaitForSeconds(1);

        nextLevelCountdown = null;
        SceneLoader.LoadLevel("Level Select");
    }

    //Change the current color of Player 1
    public void UpdatePlayerOneColor(int playerOneSelection)
    {
         p1_1Selected.GetComponent<Image>().enabled = false;
         p1_2Selected.GetComponent<Image>().enabled = false;
         p1_3Selected.GetComponent<Image>().enabled = false;
         p1_4Selected.GetComponent<Image>().enabled = false;
         p1_5Selected.GetComponent<Image>().enabled = false;
         p1_6Selected.GetComponent<Image>().enabled = false;
         p1_7Selected.GetComponent<Image>().enabled = false;
         p1_8Selected.GetComponent<Image>().enabled = false;
         
        if (playerOneSelection == 1) 
        { 
            p1_1Selected.GetComponent<Image>().enabled = true;
            playerOneSelectedColor = new Color32(122, 195, 0, 255);
        }
        if (playerOneSelection == 2) 
        { 
            p1_2Selected.GetComponent<Image>().enabled = true;
            playerOneSelectedColor = new Color32(255, 0, 36, 255); 
        }
        if (playerOneSelection == 3) 
        { 
            p1_3Selected.GetComponent<Image>().enabled = true;
            playerOneSelectedColor = new Color32(0, 33, 255, 255); 
        }        
        if (playerOneSelection == 4) 
        { 
            p1_4Selected.GetComponent<Image>().enabled= true;
            playerOneSelectedColor = new Color32(255, 247, 0, 255); 
        }      
        if (playerOneSelection == 5)
        { 
            p1_5Selected.GetComponent<Image>().enabled = true;
            playerOneSelectedColor = new Color32(255, 0, 247, 255); 
        }     
        if (playerOneSelection == 6) 
        { 
            p1_6Selected.GetComponent<Image>().enabled = true;
            playerOneSelectedColor = new Color32(0, 255, 235, 255); 
        }     
        if (playerOneSelection == 7) 
        { 
            p1_7Selected.GetComponent<Image>().enabled = true;
            playerOneSelectedColor = new Color32(255, 147, 0, 255); 
        }      
        if (playerOneSelection == 8) 
        { 
            p1_8Selected.GetComponent<Image>().enabled = true;
            playerOneSelectedColor = new Color32(136, 0, 255, 255); 
        }
        
        playerOneBody.GetComponent<Image>().color = playerOneSelectedColor;
        playerOneTurret.GetComponent<Image>().color = playerOneSelectedColor;
    }

    //Change the current color of Player 1
    public void UpdatePlayerTwoColor(int playerTwoSelection)
    {
         p2_1Selected.GetComponent<Image>().enabled = false;
         p2_2Selected.GetComponent<Image>().enabled = false;
         p2_3Selected.GetComponent<Image>().enabled = false;
         p2_4Selected.GetComponent<Image>().enabled = false;
         p2_5Selected.GetComponent<Image>().enabled = false;
         p2_6Selected.GetComponent<Image>().enabled = false;
         p2_7Selected.GetComponent<Image>().enabled = false;
         p2_8Selected.GetComponent<Image>().enabled = false;
         
        if (playerTwoSelection == 1) 
        { 
            p2_1Selected.GetComponent<Image>().enabled = true;
            playerTwoSelectedColor = new Color32(122, 195, 0, 255);
        }
        if (playerTwoSelection == 2) 
        { 
            p2_2Selected.GetComponent<Image>().enabled = true;
            playerTwoSelectedColor = new Color32(255, 0, 36, 255); 
        }
        if (playerTwoSelection == 3) 
        { 
            p2_3Selected.GetComponent<Image>().enabled = true;
            playerTwoSelectedColor = new Color32(0, 33, 255, 255); 
        }        
        if (playerTwoSelection == 4) 
        { 
            p2_4Selected.GetComponent<Image>().enabled= true;
            playerTwoSelectedColor = new Color32(255, 247, 0, 255); 
        }      
        if (playerTwoSelection == 5)
        { 
            p2_5Selected.GetComponent<Image>().enabled = true;
            playerTwoSelectedColor = new Color32(255, 0, 247, 255); 
        }     
        if (playerTwoSelection == 6) 
        { 
            p2_6Selected.GetComponent<Image>().enabled = true;
            playerTwoSelectedColor = new Color32(0, 255, 235, 255); 
        }     
        if (playerTwoSelection == 7) 
        { 
            p2_7Selected.GetComponent<Image>().enabled = true;
            playerTwoSelectedColor = new Color32(255, 147, 0, 255); 
        }      
        if (playerTwoSelection == 8) 
        { 
            p2_8Selected.GetComponent<Image>().enabled = true;
            playerTwoSelectedColor = new Color32(136, 0, 255, 255); 
        }
        
        playerTwoBody.GetComponent<Image>().color = playerTwoSelectedColor;
        playerTwoTurret.GetComponent<Image>().color = playerTwoSelectedColor;
    }
}
