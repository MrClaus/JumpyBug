using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text Score;

    // Show score in menu
    void Start()
    {
        if (PlayerPrefs.HasKey("JumpyBagScore"))
        {
            int score = PlayerPrefs.GetInt("JumpyBagScore");
            Score.text = "" + score;
        }
    }
}
