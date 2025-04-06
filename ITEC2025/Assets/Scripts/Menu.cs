using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public int sceneToLoad = 1;

    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
