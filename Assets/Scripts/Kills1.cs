using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Kills1 : MonoBehaviour
{

    public int playedMatches;

    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    public Kills1 kills1;
    public Kills1 kills2;
    public Kills1 kills3;
    public Kills1 kills4;
    public int NmbrOfPlayers;
    public GameObject scoreScreen;



    public int score;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;

    public bool player1Null;
    public bool player2Null;
    public bool player3Null;
    public bool player4Null;

    private void Awake()
    {
        kills1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Kills1>();
        kills2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Kills1>();
        kills3 = GameObject.FindGameObjectWithTag("Player3").GetComponent<Kills1>();
        kills4 = GameObject.FindGameObjectWithTag("Player4").GetComponent<Kills1>();

    }
    private void Start()
    {
        Player1 = GameObject.FindGameObjectWithTag("Player1");
        Player2 = GameObject.FindGameObjectWithTag("Player2");
        Player3 = GameObject.FindGameObjectWithTag("Player3");
        Player4 = GameObject.FindGameObjectWithTag("Player4");
        kills1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Kills1>();
        kills2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Kills1>();
        kills3 = GameObject.FindGameObjectWithTag("Player3").GetComponent<Kills1>();
        kills4 = GameObject.FindGameObjectWithTag("Player4").GetComponent<Kills1>();
      

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
        scoreScreen.SetActive(false);

        scoreScreen.transform.SetAsFirstSibling();
        text1.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(-950f, 400f);
        text1.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(-750f, 500f);
        text2.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(-350f, 400f);
        text2.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(-175f, 500f);
        text3.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(175f, 400f);
        text3.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(350f, 500f);
        text4.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(750, 400f);
        text4.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(950, 500f);


    }
    // Update is called once per frame
    void Update()
    {
        if (Player1 != null && playedMatches <= 3)
        {
            text1.text = "P1 kills: " + kills1.score;

        }
        if (Player2 != null && playedMatches <= 3)
        {
            text2.text = "P2 kills: " + kills2.score;
        }
        if (Player3 != null && playedMatches <= 3)
        {

            text3.text = "P3 kills: " + kills3.score;

        }
        if (Player4 != null && playedMatches <= 3)
        {
            text4.text = "p4 kills: " + kills4.score;

        }

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
            PlayerPrefs.SetInt("Player1", kills1.score);
            PlayerPrefs.SetInt("Player2", kills2.score);
            PlayerPrefs.SetInt("Player3", kills3.score);
            PlayerPrefs.SetInt("Player4", kills4.score);
            if (playedMatches <= 3)
            {
               Invoke("VictorySequence", 3);

            }
            else
            {
                text1.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(-450f, -110f);
                text1.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(-5f, -20f);
                text2.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(-265f, -110f);
                text2.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(-5f, -20f);
                text3.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(0f, -110f);
                text3.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(150f, -20f);
                text4.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(235, -110f);
                text4.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(500, -20f);
                Time.timeScale = 0f;
                scoreScreen.SetActive(true);
                text1.text = "" + kills1.score;
                text2.text = "" + kills1.score;
                text3.text = "" + kills1.score;
                text4.text = "" + kills1.score;
                Invoke("VictorySequence2", 10);
            }

        }
        if (NmbrOfPlayers <= 0)
        {
            PlayerPrefs.SetInt("Player1", kills1.score);
            PlayerPrefs.SetInt("Player2", kills2.score);
            PlayerPrefs.SetInt("Player3", kills3.score);
            PlayerPrefs.SetInt("Player4", kills4.score);
            if (playedMatches <= 3)
            {
                Invoke("VictorySequence", 3);

            }
            else
            {
                text1.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(-450f, -110f);
                text1.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(-5f, -20f);
                text2.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(-265f, -110f);
                text2.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(-5f, -20f);
                text3.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(0f, -110f);
                text3.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(150f, -20f);
                text4.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(235, -110f);
                text4.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(500, -20f);
                Time.timeScale = 0f;
                scoreScreen.SetActive(true);
                text1.text = "" + kills1.score;
                text2.text = "" + kills1.score;
                text3.text = "" + kills1.score;
                text4.text = "" + kills1.score;
                Invoke("VictorySequence2", 10);
            }

        }
    
    }
    //efter varje match
    public void VictorySequence()
    {
        playedMatches++;
        SceneManager.LoadScene(Random.Range(5, 7));
        PlayerPrefs.SetInt("MatchesPlayed", playedMatches);
            Time.timeScale = 1f;
        scoreScreen.SetActive(false);
    }
    //sequence efter 3 matcher
    public void VictorySequence2()
    {
        SceneManager.LoadScene(Random.Range(5, 7));
        Time.timeScale = 1f;
        scoreScreen.SetActive(false);
        PlayerPrefs.SetInt("MatchesPlayed", 0);
            //text1
        text1.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(-950f, 400f);
        text1.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(-750f, 500f);
        //text2
        text2.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(-350f, 400f);
        text2.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(-175f, 500f);
        //text3
        text3.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(175f, 400f);
        text3.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(350f, 500f);
        //text4
        text4.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(750, 400f);
        text4.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(950, 500f);
    }
    void AddToScore()
    {
        score ++;
    }

}
