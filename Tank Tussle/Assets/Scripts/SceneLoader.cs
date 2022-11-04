using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    

    ////TEMPORARY////
    public Canvas gameOverCanvas;
    public Canvas gameCanvas;

    //Load Level (Called by various buttons)
    public void LoadLevel(string targetScene)
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene(targetScene);
    }

    //Quit Game (Only called by quit button)
    public void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }


    ////TEMPORARY////
    public void OpenGameOverScreen()
    {  
        gameCanvas.enabled = false;
        gameOverCanvas.enabled = true;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}