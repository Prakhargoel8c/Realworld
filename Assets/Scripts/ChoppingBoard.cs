using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoppingBoard : MonoBehaviour
{
    public GameConstants.Players player;
    private PlayerInteractions playerInteractions;
    private Text boardText;
    private string combination
    {
        get
        {
            if(boardText.text=="---")
            {
                return null;
            }
            else
            {
                return boardText.text;
            }
        }
        set
        {
            if (value != null)
            {
                boardText.text = value;
            }
            else
            {
                boardText.text = "---";
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        boardText = transform.Find("Vegetable").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnInteract(GameObject playerobject)
    {
        playerInteractions = playerobject.GetComponent<PlayerInteractions>();
        if (playerInteractions.player==player)//Get vegetable chopped
        {
            if (playerInteractions.GetVegetable() != null)
            {
                combination += playerInteractions.RemoveVegetable()+",";
                playerInteractions.StartCooking();
            }
            else if(playerInteractions.GetVegetable()==null && playerInteractions.combination==null && combination!=null)//pickup up combo
            {
                playerInteractions.combination = combination;
                combination = null;
            }
            else if(playerInteractions.GetVegetable()==null && playerInteractions.combination!=null && combination==null)//place combo on choppingboard
            {
                combination = playerInteractions.combination;
                playerInteractions.combination = null;
            }
        }
    }
}
