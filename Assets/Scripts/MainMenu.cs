using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            SceneManager.LoadScene("OpenScreen");
        }
    }
    public void ToLobby()
    {
        SceneManager.LoadScene("PregameLobby");

    }
    public void ToHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");

    }
    public void ToOptions()
    {
        SceneManager.LoadScene("Options");

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quittingGame");
    }
}