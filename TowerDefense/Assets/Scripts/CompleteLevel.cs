using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public string nextLevel = "Level02";
    public int levelToUnlock = 2;
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";
    
    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        if (Application.CanStreamedLevelBeLoaded(nextLevel))
        {
            sceneFader.FadeTo(nextLevel);
        }
        else
        {
            Debug.Log("There is no more levels to load.");
            sceneFader.FadeTo("LevelSelect");            
        }
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
