using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyUp : MonoBehaviour
{
    Kills kills;
    public bool player1;
    public bool player2;
    public bool player3;
    public bool player4;

    public SpriteRenderer Player1;
    public SpriteRenderer Player2;
    public SpriteRenderer Player3;
    public SpriteRenderer Player4;
    public SpriteRenderer noPlayer1;
    public SpriteRenderer noPlayer2;
    public SpriteRenderer noPlayer3;
    public SpriteRenderer noPlayer4;
    public SpriteRenderer Ready1;
    public SpriteRenderer Ready2;
    public SpriteRenderer Ready3;
    public SpriteRenderer Ready4;


    private void Start()
    {



        player1 = false;
        player2 = false;
        player3 = false;
        player4 = false;
    }


    private void Update()
    {
        Players1();
        Players2();
        Players3();
        Players4();
        if (Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            SceneManager.LoadScene(Random.Range(5, 8));
            PlayerPrefs.DeleteAll();
            kills.playedMatches = 0;


        }
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            SceneManager.LoadScene("StartMenu");

        }
        //Player1
        Player1.enabled = player1;
        noPlayer1.enabled = !player1;
        Ready1.enabled = player1;
        //Player2
        Player2.enabled = player2;
        noPlayer2.enabled = !player2;
        Ready2.enabled = player2;
        //Player3
        Player3.enabled = player3;
        noPlayer3.enabled = !player3;
        Ready3.enabled = player3;
        //Player4
        Player4.enabled = player4;
        noPlayer4.enabled = !player4;
        Ready4.enabled = player4;
    }

    public void Players1()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            player1 = !player1;
        }

    }
    public void Players2()
    {
        if (Input.GetKeyDown(KeyCode.Joystick2Button0))
        {
            player2 = !player2;
        }

    }
    public void Players3()
    {
        if (Input.GetKeyDown(KeyCode.Joystick3Button0))
        {
            player3 = !player3;
        }

    }
    public void Players4()
    {
        if (Input.GetKeyDown(KeyCode.Joystick4Button0))
        {
            player4 = !player4;
        }

    }
}
