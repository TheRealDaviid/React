using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnde : MonoBehaviour
{
    // Start is called before the first frame update
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene("Menu");
        }

        if (collision.tag == "Player 2")
        {
            SceneManager.LoadScene("Menu");
        }


    }
}
