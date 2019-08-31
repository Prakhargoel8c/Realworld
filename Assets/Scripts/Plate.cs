using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plate : MonoBehaviour
{
    public GameConstants.Players player;
    private PlayerInteractions playerInteractions;
    private Text platetext;
    private string vegetable
    {
        get
        {
            if(platetext.text=="---")
            {
                return null;
            }
            else
            {
                return platetext.text;
            }
        }
        set
        {
            if(value==null)
            {
                platetext.text = "---";
            }
            else
            {
                platetext.text = value;
            }
        }
    }
    void Start()
    {
        platetext = transform.Find("Text").GetComponent<Text>();
    }
    public void OnInteract(GameObject playerobject)
    {
        playerInteractions = playerobject.GetComponent<PlayerInteractions>();
        if(playerInteractions.player==this.player)
        {
            if(vegetable==null && playerInteractions.GetVegetable(0)!=null)
            {
                vegetable = playerInteractions.RemoveVegetable();
            }
            else if(playerInteractions.GetVegetable(1)==null)
            {
                playerInteractions.AddVegetable(vegetable);
                vegetable = null;
            }
        }
    }
}

    

