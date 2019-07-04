
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text livesText;

    void Update()
    {
        // if you want to do this on a mobile phone
        // it is more efficient to use a co-routine
        livesText.text = PlayerStats.Lives.ToString() + " LIVES";
    }
}
