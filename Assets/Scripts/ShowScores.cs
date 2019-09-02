using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShowScores : MonoBehaviour
{
    private Text winText;
    private Text Player1Score;
    private Text Player2Score;
    private int WinScore;
    private int[] HighScores;
    private Vector3 Location;
    public float ydiffrence=41f;
    private int noOfHighScores;
    public GameObject ScorePrefab;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        HighScores= new int[10];
        winText = transform.Find("Player Victory").GetComponent<Text>();
        Player1Score = transform.Find("Score1").GetComponent<Text>();
        Player2Score = transform.Find("Score2").GetComponent<Text>();
        Player1Score.text = GameConstants.Player1Score.ToString();
        Player2Score.text = GameConstants.Player2Score.ToString();
        if(GameConstants.Player1Score > GameConstants.Player2Score)
        {
            winText.text = "Player 1 Won";
            WinScore = GameConstants.Player1Score;
        }
        else if (GameConstants.Player1Score < GameConstants.Player2Score)
        {
            winText.text = "Player 2 Won";
            WinScore = GameConstants.Player2Score;
        }
        else
        {
            winText.text = "Tie";
            WinScore= GameConstants.Player2Score;
        }
        GameObject spawnTemplate = GameObject.FindGameObjectWithTag("Canvas").transform.Find("ScoreTemplate").gameObject;
        Location = spawnTemplate.transform.localPosition;
        Destroy(spawnTemplate);
        StartCoroutine(HighScrores());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator HighScrores()
    {
        yield return LoadHighScores();
    }
    private bool LoadHighScores()
    {
        if(!PlayerPrefs.HasKey("HighScoreLength"))
        {
            PlayerPrefs.SetInt("HighScoreLength", 0);
            noOfHighScores = 0;
            
        }
        else
        {
            noOfHighScores = PlayerPrefs.GetInt("HighScoreLength");
            for (int i=0; i<noOfHighScores;i++)
            {
                HighScores[i] = PlayerPrefs.GetInt("HighScore" + (i+1).ToString());
                Debug.Log(PlayerPrefs.GetInt("HighScore" + (i + 1).ToString()));
            }
        }
        AddScore(WinScore);
        return true;
    }
    private void AddScore(int Score)
    {
        if(noOfHighScores<10)
        {
            HighScores[noOfHighScores] = Score;
           noOfHighScores++;
           
        }
        else if(Score>HighScores[9])
        {
            HighScores[9] = Score;
        }
        Array.Sort(HighScores);
        Array.Reverse(HighScores);
        PlayerPrefs.SetInt("HighScoreLength", noOfHighScores);
        for (int i = 1; i <= noOfHighScores; i++)
        {
            PlayerPrefs.SetInt("HighScore" + i.ToString(),HighScores[i-1]);
            GameObject CurrentScore= Instantiate(ScorePrefab, transform.parent.transform);
            CurrentScore.transform.localPosition = Location;
            CurrentScore.transform.Find("Index").GetComponent<Text>().text = i.ToString();
            CurrentScore.transform.Find("Score").GetComponent<Text>().text = HighScores[i - 1].ToString();
            Location.y -= ydiffrence;
            //Debug.Log(HighScores[i-1]);
        }
        PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetInt("HighScore" + (noOfHighScores).ToString()));
    }
}
