using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    void Start()
    {
        Invoke("Goto", 1f); 
    }

    void Goto()
    {
        string name_scene = GotoScene.toScene;
        SceneManager.LoadScene(name_scene);
    }
}
