using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private Text ScoreText;
    private Text TimeText;
    public int CurrentScore { get; private set; }
    public float CurrentTime { get; private set; }
    private PlayerInteractions playerInteractions;


    // Start is called before the first frame update
    public void SetUi(PlayerInteractions interactions)
    {
        playerInteractions = interactions;
        CurrentTime = 0;
        CurrentScore = 0;
        ScoreText = transform.Find("Score").GetComponent<Text>();
        TimeText = transform.Find("Time").GetComponent<Text>();
        ResetScore();
    }

    public void AddScore(int Scorechange)
    {
        CurrentScore += Scorechange;
        ScoreText.text = "Score:" + CurrentScore.ToString();
    }

    public void ResetScore()
    {
        CurrentScore = 0;
        ScoreText.text= "Score:" + CurrentScore.ToString();
    }
    public void AddTime(int time)
    {
        CurrentTime += time;
        TimeText.text="Time:" + Mathf.FloorToInt(CurrentTime).ToString()+"s";
    }
    public void SetTime(float time)
    {
        CurrentTime = time;
        TimeText.text= "Time:" + Mathf.FloorToInt(CurrentTime).ToString() + "s";
    }
    private void FixedUpdate()
    {
        if (CurrentTime > 0f)
        {
            CurrentTime -= Time.fixedDeltaTime;
            SetTime(CurrentTime);
            if(CurrentTime<=0)
            {
                Debug.Log("Time Over");
                playerInteractions.StopPlayer();
            }
        }
    }
}
