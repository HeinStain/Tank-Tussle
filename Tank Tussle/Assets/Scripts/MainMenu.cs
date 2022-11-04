using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject playSelected;
    public GameObject tutorialSelected;
    public GameObject quitSelected;

    private int selection = 1;

    public SceneLoader SceneLoader;

    void Start()
    {
        selection = 1;
        UpdateSelection();

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (selection <= 3)
            {
                selection++;
            }
            if (selection > 3)
            {
                selection = 1;
            }
            UpdateSelection();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (selection >= 1)
            {
                selection--;
            }
            if (selection < 1)
            {
                selection = 3;
            }
            UpdateSelection();
        }  
        if (Input.GetKeyDown(KeyCode.F))
        {
            FindObjectOfType<AudioManager>().Play("Menu_Confirm");
            if (selection == 1)
            {
                SceneLoader.LoadLevel("Character Select");
            }
            if (selection == 2)
            {
                SceneLoader.LoadLevel("Tutorial");
            }
            if (selection == 3)
            {
                SceneLoader.Quit();
            }
        }
    }


    void UpdateSelection()
    {
        FindObjectOfType<AudioManager>().Play("Menu_Move");
        playSelected.SetActive(false);
        tutorialSelected.SetActive(false);
        quitSelected.SetActive(false);

        if (selection == 1)
        {
            playSelected.SetActive(true);
        }
        if (selection == 2)
        {
            tutorialSelected.SetActive(true);
        }
        if (selection == 3)
        {
            quitSelected.SetActive(true);
        }
    }
} 
