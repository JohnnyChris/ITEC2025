using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject canvas;
    private bool active = false;

    public void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
           
            if (!active)
            {
                canvas.SetActive(true);
                Time.timeScale = 0f;
                active = true;

            }
            else
            {
                canvas.SetActive(false);
                Time.timeScale = 1f;
                active = false;
            }
        }
    }



    public void returnToMainMenu()
    {
        canvas.SetActive(false);
        Time.timeScale = 1f;
        active = false;
        SceneManager.LoadScene(0);
    }

    public void returnToGame()
    {
        canvas.SetActive(false);
        Time.timeScale = 1f;
        active = false;
    }
}
