using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Input.GetJoystickNames().Length
    bool player1;
    bool player2;
    bool player3;
    bool player4;

    public void ReadyUp()
    {
        if (Input.GetJoystickNames().Length == 1)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                player1 = true;
            }
            if (player1 == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        if (Input.GetJoystickNames().Length == 2)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                player1 = true;
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button0))
            {
                player2 = true;
            }
            if (player1 == true && player2 == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

        }
        if (Input.GetJoystickNames().Length == 3)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                player1 = true;
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button0))
            {
                player2 = true;
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button0))
            {
                player3 = true;
            }
            if (player1 == true && player2 == true && player3 == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        if (Input.GetJoystickNames().Length == 4)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                player1 = true;
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button0))
            {
                player2 = true;
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button0))
            {
                player3 = true;
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button0))
            {
                player4 = true;
            }
            if (player1 == true && player2 == true && player3 == true && player4 == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    public void Lobby()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quittingGame");
    }
}