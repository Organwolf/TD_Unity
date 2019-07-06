
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static bool gameIsOver;
    public GameObject gameOverUI;

    private void Start()
    {
        gameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsOver)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {

        gameIsOver = true;
        gameOverUI.SetActive(true);
        Debug.Log("Game End");
    }
}
