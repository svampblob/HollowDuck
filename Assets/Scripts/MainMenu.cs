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

    }
        public void AmountPlayers()
        {
        Debug.Log("" + Input.GetJoystickNames().Length);
        }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quittingGame");
    }
}