using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    public LevelManager levelmanager;



    
    private Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        levelmanager = FindObjectOfType<LevelManager>();


      

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            levelmanager.currentCheckpoint = gameObject;
            Debug.Log("Checkpoint Player 1");

        }
        if (collision.gameObject.tag == "Player 2")
        {
            levelmanager.currentCheckpoint2 = gameObject;
            Debug.Log("Checkpoint Player 2");

        }
    }

}


