using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieWhenFallDown : MonoBehaviour
{
    public LevelManager levelmanager;

    void Start()
    {
        levelmanager = FindObjectOfType<LevelManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            levelmanager.respawnOrNot("Player");
            Debug.Log("diewhenfalldown");

        }
        if (collision.gameObject.tag == "Player 2")
        {
            levelmanager.respawnOrNot("Player 2");
            Debug.Log("diewhenfalldown");

        }
    }
}
