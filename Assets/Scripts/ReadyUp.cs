using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyUp : MonoBehaviour
{
    bool player1;
    bool player2;
    bool player3;
    bool player4;
    public SpriteRenderer spriteRenderer1;
    public SpriteRenderer spriteRenderer2;
    public SpriteRenderer spriteRenderer3;
    public SpriteRenderer spriteRenderer4;


   
    private void Update()
    {
        Players1();
        Players2();
        Players3();
        Players4();
        if (Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            SceneManager.LoadScene(Random.Range(5, 7));


        }
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            SceneManager.LoadScene("StartMenu");

        }
    }

    public void Players1()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            player1 = !player1;
            spriteRenderer1.enabled = player1;
        }
    }
    public void Players2()
    {
        if (Input.GetKeyDown(KeyCode.Joystick2Button0))
        {
            player2 = !player2;
            spriteRenderer2.enabled = player2;
        }
    }
    public void Players3()
    {
        if (Input.GetKeyDown(KeyCode.Joystick3Button0))
        {
            player3 = !player3;
            spriteRenderer3.enabled = player3;
        }
    }
    public void Players4()
    {
        if (Input.GetKeyDown(KeyCode.Joystick4Button0))
        {
            player4 = !player4;
            spriteRenderer4.enabled = player4;
        }

    }
}
