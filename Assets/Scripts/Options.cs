using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetMainVolume (float MainVolume)
    {
        audioMixer.SetFloat("MainVolume", MainVolume);
    }
    public void SetMusic(float music)
    {
        audioMixer.SetFloat("MusicVolume", music);
    }
    public void SetSFX(float sfx)
    {
        audioMixer.SetFloat("SFXVolume", sfx);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
         
    }
}
