using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject PickUPSpawner;
    private bool player1finished;
    private bool player2finished;
    // Start is called before the first frame update
    void Start()
    {
        player1finished = false;
        player2finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerFinished(PlayerInteractions playerInteractions)
    {
        if(playerInteractions.player==GameConstants.Players.Player1)
        {
            player1finished = true;
        }
        if(playerInteractions.player==GameConstants.Players.Player2)
        {
            player2finished = true;
        }
        if(player1finished==true && player2finished==true)
        {
            SceneManager.LoadScene(1);
        }
    }

}
