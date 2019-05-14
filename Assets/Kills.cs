using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Kills : MonoBehaviour
{
    private Animator anim;

    public int playedMatches;

    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    private Kills kills1;
    private Kills kills2;
    private Kills kills3;
    private Kills kills4;
    public int NmbrOfPlayers;


    public int score;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;

    private bool player1Null;
    private bool player2Null;
    private bool player3Null;
    private bool player4Null;

    private void Awake()
    {
        kills1 = Player1.GetComponent<Kills>();
        kills2 = Player2.GetComponent<Kills>();
        kills3 = Player3.GetComponent<Kills>();
        kills4 = Player4.GetComponent<Kills>();



    }
    private void Start()
    {
        if (Player1 != null)
        {
            NmbrOfPlayers++;
            player1Null = false;

        }
        if (Player2 != null)
        {
            NmbrOfPlayers++;
            player2Null = false;

        }
        if (Player3 != null)
        {
            NmbrOfPlayers++;
            player3Null = false;

        }
        if (Player4 != null)
        {
            NmbrOfPlayers++;
            player4Null = false;

        }
        kills1.score = PlayerPrefs.GetInt("Player1");
        kills2.score = PlayerPrefs.GetInt("Player2");
        kills3.score = PlayerPrefs.GetInt("Player3");
        kills4.score = PlayerPrefs.GetInt("Player4");
        anim = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        text1.text = "Player 1 kills " + kills1.score;
        text2.text = "Player 2 kills " + kills2.score;
        text3.text = "Player 3 kills " + kills3.score;
        text4.text = "Player 4 kills " + kills4.score;

        if (Player1 == null && player1Null == false)
        {
            NmbrOfPlayers = NmbrOfPlayers - 1;
            player1Null = true;
        }
        if (Player2 == null && player2Null == false)
        {
            NmbrOfPlayers = NmbrOfPlayers - 1;
            player2Null = true;

        }
        if (Player3 == null && player3Null == false)
        {
            NmbrOfPlayers = NmbrOfPlayers - 1;
            player3Null = true;

        }
        if (Player4 == null && player4Null == false)
        {
            NmbrOfPlayers = NmbrOfPlayers - 1;
            player4Null = true;


        }
        if (NmbrOfPlayers <= 1)
        {
            Invoke("VictorySequence", 3);
            PlayerPrefs.SetInt("Player1", kills1.score);
            PlayerPrefs.SetInt("Player2", kills2.score);
            PlayerPrefs.SetInt("Player3", kills3.score);
            PlayerPrefs.SetInt("Player4", kills4.score);

        }
        if (NmbrOfPlayers <= 0)
        {
            Invoke("VictorySequence", 3);
            PlayerPrefs.SetInt("Player1", kills1.score);
            PlayerPrefs.SetInt("Player2", kills2.score);
            PlayerPrefs.SetInt("Player3", kills3.score);
            PlayerPrefs.SetInt("Player4", kills4.score);

        }
        if (playedMatches == 3)
        {
            Time.timeScale = 0f;

            Invoke("VictorySequence", 10);

        }


    }
    public void VictorySequence()
    {
        SceneManager.LoadScene(Random.Range(5, 7));
        playedMatches++;
        Time.timeScale = 1f;
    }
    void AddToScore()
    {
        score = score + 1;
    }

}
