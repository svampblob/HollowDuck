﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            SceneManager.LoadScene("StartMenu");

        }
    }
}
