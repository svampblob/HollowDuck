﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
    public void ToMainMenu()
    {
        SceneManager.LoadScene("StartMenu");

    }
}
