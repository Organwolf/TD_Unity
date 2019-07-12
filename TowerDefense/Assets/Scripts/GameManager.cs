
using UnityEngine;


// Github:
// https://github.com/Brackeys/Tower-Defense-Tutorial/tree/master/Tower%20Defense%20Unity%20Project/Assets

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    private void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {

        GameIsOver = true;
        gameOverUI.SetActive(true);
        Debug.Log("Game End");
    }

    public void WinLevel ()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
