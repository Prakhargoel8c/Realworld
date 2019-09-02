using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScores : MonoBehaviour
{
    private Text winText;
    private Text Player1Score;
    private Text Player2Score;
    // Start is called before the first frame update
    void Start()
    {
        winText = transform.Find("Player Victory").GetComponent<Text>();
        Player1Score = transform.Find("Score1").GetComponent<Text>();
        Player2Score = transform.Find("Score2").GetComponent<Text>();
        Player1Score.text = GameConstants.Player1Score.ToString();
        Player2Score.text = GameConstants.Player2Score.ToString();
        if(GameConstants.Player1Score > GameConstants.Player2Score)
        {
            winText.text = "Player 1 Won";
        }
        else if (GameConstants.Player1Score < GameConstants.Player2Score)
        {
            winText.text = "Player 2 Won";
        }
        else
        {
            winText.text = "Tie";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
