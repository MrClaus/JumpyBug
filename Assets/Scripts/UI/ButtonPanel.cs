using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPanel : MonoBehaviour
{    
    public void ReloadScene()
    {
        BarLine.Restart();
        WheelControl.setNumHit(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GotoMenu()
    {
        BarLine.Restart();
        WheelControl.setNumHit(1);
        GotoScene.toScene = "MenuScene";
        SceneManager.LoadScene("LoadScene");
    }
}
