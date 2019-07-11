using UnityEngine;

public class LevelSelecter : MonoBehaviour
{
    public SceneFader fader;

    public void SelectLevel(string levelName)
    {
        fader.FadeTo(levelName);
    }

}
