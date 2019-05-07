using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Kills : MonoBehaviour
{
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

    }
    // Update is called once per frame
    void Update()
    {
        text1.text = "Player 1 score is " + kills1.score;
        text2.text = "Player 2 score is " + kills2.score;
        text3.text = "Player 3 score is " + kills3.score;
        text4.text = "Player 4 score is " + kills4.score;

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
            Invoke("VictorySequence", 2);
        }
      

    }
    public void VictorySequence()
    {
        SceneManager.LoadScene(Random.Range(5, 7));
    }
    void AddToScore()
    {
        score = score + 1;
        
        
    }

}
