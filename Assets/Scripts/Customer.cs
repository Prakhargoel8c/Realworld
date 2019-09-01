using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    private GameManager gameManager;
    private Text combinationText;
    private PlayerInteractions playerInteractions;
    private Image Bar;
    private float CustomerTime;
    private float TimeLeft;
    private float currentrate;
    private int[] playerwrongcombo;
    private string combination
    {
        get
        {
            return combinationText.text;
        }
        set
        {
            combinationText.text = value;
        }
    }

    private void Start()
    {
        combinationText = transform.Find("Image").Find("Text").GetComponent<Text>();
        CustomerTime = 0f;
        Bar = transform.Find("Bar").GetComponent<Image>();
        Bar.fillAmount = 0;
        SetCombination();
        gameManager = GameObject.Find("GameManger").GetComponent<GameManager>();
    }
    private void Update()
    {
        if(TimeLeft>0)
        {
            TimeLeft -= Time.deltaTime * currentrate;
            if(TimeLeft<=0)
            {
                TimeUp();
            }
            Bar.fillAmount = TimeLeft / CustomerTime;
        }
    }
    void SetCombination()
    {
        playerwrongcombo = new int[2] { 0, 0 };
        int noOfItems = UnityEngine.Random.Range(1, GameConstants.maxitems);
        CustomerTime = noOfItems * GameConstants.ItemTime;
        TimeLeft = CustomerTime;
        currentrate = GameConstants.NormalRate;
        Bar.color = GameConstants.NormalColor;
        Bar.fillAmount = 1;
        for (int i = 0; i < noOfItems; i++)
        {
            if (combination.Length>0)
            {
                combination += "," + GameConstants.vegetablenames[UnityEngine.Random.Range(0, GameConstants.vegetablenames.Length - 1)];
            }
            else
            {
                combination =GameConstants.vegetablenames[UnityEngine.Random.Range(0, GameConstants.vegetablenames.Length - 1)];
            }
        }
    }

    public void OnInteract(GameObject playerobject)
    {
        playerInteractions = playerobject.GetComponent<PlayerInteractions>();
        if(playerInteractions.combination!=null)
        {
            if(SameCombination(combination,playerInteractions.combination))
            {
                Debug.Log("correct item");
                CorrectCombination();
            }
            else
            {
                Debug.Log("wrong item");
                WrongItem();
            }
            playerInteractions.combination = null;
        }

    }
    private bool SameCombination(string str1,string str2)
    {
        char[] ch1 = str1.ToLower().ToCharArray();
        char[] ch2 = str2.ToLower().ToCharArray();
        Array.Sort(ch1);
        Array.Sort(ch2);
        string val1 = new string(ch1);
        string val2 = new string(ch2);

        if (val1.Equals(val2))
        {
            return true;
            
        }
        else
        {
            return false;
        }
    }

    private void CorrectCombination()
    {
        if(Bar.fillAmount>=0.3)
        {
            //playerInteractions.SpawnPickUp();
        }
        StartCoroutine(Wait());
        playerInteractions.GetUI.AddScore(GameConstants.correctcomboScore);
        Bar.fillAmount = 0;
        TimeLeft = 0;
    }
    private void WrongItem()
    {
        currentrate = GameConstants.AngryRate;
        Bar.color = GameConstants.AngryColor;
        if(playerInteractions.player==GameConstants.Players.Player1)
        {
            playerwrongcombo[0] = 1;
        }
        else if (playerInteractions.player == GameConstants.Players.Player2)
        {
            playerwrongcombo[1] = 1;
        }
            playerInteractions.GetUI.AddScore(GameConstants.wrongcomboScore);
    }
    private void TimeUp()
    {
        if(currentrate==GameConstants.NormalRate)
        {
            gameManager.player1.GetComponent<PlayerInteractions>().GetUI.AddScore(GameConstants.normalcustomerleave);
            gameManager.player2.GetComponent<PlayerInteractions>().GetUI.AddScore(GameConstants.normalcustomerleave);
        }
        else
        {
            if(playerwrongcombo[0]==1)
            {
                gameManager.player1.GetComponent<PlayerInteractions>().GetUI.AddScore(GameConstants.angrycustomerleave);
            }
            if(playerwrongcombo[1]==1)
            {
                gameManager.player2.GetComponent<PlayerInteractions>().GetUI.AddScore(GameConstants.angrycustomerleave);
            }
        }
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        gameObject.GetComponent<Image>().enabled = false;
        combination = "";
        yield return new WaitForSeconds(GameConstants.nextCustomerTime);
        SetCombination();
        gameObject.GetComponent<Image>().enabled = true;
        
    }
}
