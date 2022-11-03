using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager : MonoBehaviour
{

    public static InfoManager Instance;

    public Color playerOneColor;
    public Color playerTwoColor;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void StorePlayerOneColour(Color p1Color)
    {
        playerOneColor = p1Color;
    }

    void StorePlayerTwoColour(Color p2Color)
    {
        playerTwoColor = p2Color;
    }
}
