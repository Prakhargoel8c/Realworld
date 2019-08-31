using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    private Text combinationText;
    private PlayerInteractions playerInteractions;
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
        SetCombination();
    }
    // Start is called before the first frame update
    void SetCombination()
    {
        combinationText = transform.Find("Image").Find("Text").GetComponent<Text>();
        int noOfItems = UnityEngine.Random.Range(1, GameConstants.maxitems);
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

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CorrectCombination()
    {
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
