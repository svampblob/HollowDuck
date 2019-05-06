using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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



    public int score;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;

    private void Awake()
    {
        kills1 = Player1.GetComponent<Kills>();
        kills2 = Player2.GetComponent<Kills>();
        kills3 = Player3.GetComponent<Kills>();
        kills4 = Player4.GetComponent<Kills>();


    }
    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        text1.text = "Player 1 score is " + kills1.score;
        text2.text = "Player 2 score is " + kills2.score;
        text3.text = "Player 3 score is " + kills3.score;
        text4.text = "Player 4 score is " + kills4.score;


    }
    void AddToScore()
    {
        score = score + 1;
        
        
    }

}
