using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersInGame : MonoBehaviour
{
    ReadyUp readyUp;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;

    public int player1;
    public int player2;
    public int player3;
    public int player4;



    // Start is called before the first frame update
    void Start()
    {
        player1 = PlayerPrefs.GetInt("player1");
        player2 = PlayerPrefs.GetInt("player2");
        player3 = PlayerPrefs.GetInt("player3");
        player4 = PlayerPrefs.GetInt("player4");

        if (player1 == 0) 
        {
            Destroy(Player1);
        }
        if (player2 == 0)
        {
            Destroy(Player2);
        }
        if (player3 == 0)
        {
            Destroy(Player3);
        }
        if (player4 == 0)
        {
            Destroy(Player4);
        }

    }

}
