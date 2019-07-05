﻿
using UnityEngine;

public class GameManger : MonoBehaviour
{
    private bool gameEnded = false;

    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
            return;
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game End");
        // add functionality later
    }
}