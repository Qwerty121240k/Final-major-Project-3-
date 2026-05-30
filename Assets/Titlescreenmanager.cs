using UnityEngine;
using UnityEngine.SceneManagement;

public class Titlescreenmanager : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();

        
    }

    public int scene;
    public void GoToScene()
    {
        SceneManager.LoadScene(scene);
    }
}
