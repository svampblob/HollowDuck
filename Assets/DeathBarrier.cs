using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBarrier : MonoBehaviour
{
    public string levelToLoad = "SampleScene";
    private void OnCollisionEnter2D(Collision2D collision)
    {
    if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(levelToLoad);
        }

    }

}
