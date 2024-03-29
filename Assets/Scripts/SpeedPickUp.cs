﻿using UnityEngine;
using UnityEngine.UI;

public class SpeedPickUp : MonoBehaviour
{
    private GameConstants.Players Player;
    [HideInInspector] public PlayerInteractions playerInteractions;
    private Image image;
    // Start is called before the first frame update
    public void SetUi()
    {
        image = GetComponent<Image>();
        image.color = playerInteractions.color;
        Player = playerInteractions.player;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnInteract(GameObject playerobject)
    {
        playerInteractions = playerobject.GetComponent<PlayerInteractions>();
        if (playerInteractions.player == Player)
        {
            playerInteractions.IncreaseSpeed();
            Destroy(gameObject);
        }
    }
}
