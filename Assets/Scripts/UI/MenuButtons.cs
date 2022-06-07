using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

    public GameObject MenuBlur;
    public GameObject MenuPanel;
    public GameObject ExitLay;
    private static bool isActiveClose;

    public void OpenInfo()
    {
        MenuPanel.GetComponent<Animator>().Play("InfoOpen");
        MenuBlur.GetComponent<Animator>().Play("MenuBlur");
        Invoke("StateInfo", 1f);
    }

    public void CloseInfo()
    {
        if (isActiveClose)
        {
            isActiveClose = false;
            MenuPanel.GetComponent<Animator>().Play("InfoClose");
            MenuBlur.GetComponent<Animator>().Play("MenuDeBlur");
        }
    }

    private void StateInfo()
    {
        isActiveClose = true;
    }

    public void Play()
    {
        if (!isActiveClose)
        {
            GotoScene.toScene = "GameScene";
            SceneManager.LoadScene("LoadScene");
        }        
    }

    public void Exit()
    {
        isActiveClose = true;
        ExitLay.SetActive(true);
        Invoke("Quit", 0.6f);
    }

    private void Quit()
    {
        Application.Quit();
    }
}
