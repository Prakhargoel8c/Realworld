using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dustbin : MonoBehaviour
{

    private PlayerInteractions playerInteractions;
    public void OnInteract(GameObject playerobject)
    {
        playerInteractions = playerobject.GetComponent<PlayerInteractions>();
        if(playerInteractions.combination!=null)
        {
            playerInteractions.combination = null;
            playerInteractions.GetUI.AddScore(GameConstants.combinationtrash);
        }
        else if(playerInteractions.GetVegetable(0)!=null)
        {
            playerInteractions.RemoveVegetable();
            playerInteractions.GetUI.AddScore(GameConstants.vegetabletrash);
        }
    }
}
