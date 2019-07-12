
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;
    public GameObject gameOverUI;
    public string nextLevel = "Level02";
    public int levelToUnlock = 2;
    public SceneFader scenFader;

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

    public void WinLevel ()
    {
        Debug.Log("LEVEL WON!");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        scenFader.FadeTo(nextLevel);
    }
}
