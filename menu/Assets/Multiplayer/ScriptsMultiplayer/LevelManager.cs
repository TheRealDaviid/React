using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;
    public GameObject currentCheckpoint2;

    public GameObject player1;
    public GameObject player2;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //PauseMenü //Spiel beenden
        }
    }
    public void respawnOrNot(string player)
    {
        if (player == "Player")
        {
            player1.transform.position = currentCheckpoint.transform.position;
            Debug.Log("Checkpoint Player 1");

        }
        if (player == "Player 2")
        {
            player2.transform.position = currentCheckpoint2.transform.position;
            Debug.Log("Checkpoint Player 2");

        }
        //Spieler an den Checkpoint bringen wenn Matheaufgabe flasch wenn richtig weiterspielen lassen.
        //player.transform.position = currentCheckpoint.transform.position; // darauf is zu achten das die Checkpoints sich auf der selben z-achsen position wie der spieler befinden
        //if (true) //richtig
        //{
        
     
        //}
        //else //falsch
        //{
        //    player.transform.position = currentCheckpoint.transform.position;
        //}

        Debug.Log("Respawn Mehtod");
    }
}
