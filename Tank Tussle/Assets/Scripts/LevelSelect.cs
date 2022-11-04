using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public GameObject map1Selected;
    public GameObject map2Selected;
    public GameObject map3Selected;
    public GameObject playButtonSelected;

    private int selection = 1;

    public SceneLoader SceneLoader;

    public GameObject fader;

    void Start()
    {
        selection = 2;
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
            playButtonSelected.SetActive(true);
            StartCoroutine(StartGame(selection));
        }
    }

    IEnumerator StartGame(int selection)
    {
        AudioManager.instance.Play("Menu_Confirm");
        AudioManager.instance.Stop("BG_MainMenu");
        yield return new WaitForSeconds(2);

        if (selection == 1)
        {
            SceneLoader.LoadLevel("Game_Cafe");
        }
        if (selection == 2)
        {
            SceneLoader.LoadLevel("Game_Factory");
        }
        if (selection == 3)
        {
            SceneLoader.LoadLevel("Game_Boardwalk");
        }
        yield return null;
    }
    

    void UpdateSelection()
    {
        AudioManager.instance.Play("Menu_Move");
        map1Selected.SetActive(false);
        map2Selected.SetActive(false);
        map3Selected.SetActive(false);

        if (selection == 1)
        {
            map1Selected.SetActive(true);
        }
        if (selection == 2)
        {
            map2Selected.SetActive(true);
        }
        if (selection == 3)
        {
            map3Selected.SetActive(true);
        }
    }
}
