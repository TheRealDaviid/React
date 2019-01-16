using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int scoreCounter; //private damit nicht manipulierbar
    public Text scoreText;
    public Text highScore;

    public InputField ergebnis;
    public GameObject aufgabe;
    public Text rechnung;
    public GameObject player;
    void Start()
    {
        scoreCounter = 0;
        //lade akt. Highscore
        highScore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();
        //Playerprefs funktioniert wie Bibliothek

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if(collision.tag == "Checkpoint" || collision.tag == "Enemy")
        {
            player.SetActive(false);
            aufgabe.SetActive(true);
            int random1 = Random.Range(1, 90);
            int random2 = Random.Range(1, 90);
            int erg = 0;
            int randomoperator = Random.Range(1, 2);
            
            if (randomoperator == 1)
            {
                erg = random1 + random2;
                rechnung.text = random1 + " + " + random2;
            }
            if (randomoperator == 2)
            {
                if (random1 > random2)
                {
                    erg = random1 - random2;
                    rechnung.text = random1 + " - " + random2;
                }
                else
                {
                    erg = random2 - random1;
                    rechnung.text = random2 + " - " + random1;
                }
            }
            if (scoreCounter > PlayerPrefs.GetInt("Highscore"))
            {
                PlayerPrefs.SetInt("Highscore", scoreCounter);
                highScore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();
            }
            
            if (erg == int.Parse(ergebnis.text))
            {
                scoreCounter++;
                scoreText.text = "Score: " + scoreCounter.ToString(); //geht auch ohne ToString() ist aber sicherer
            }
            else
            {
                scoreCounter--;
                scoreText.text = "Score: " + scoreCounter.ToString(); //geht auch ohne ToString() ist aber sicherer
            }


            
        }
        
    }
    public void Close()
    {
        aufgabe.SetActive(false);
        player.SetActive(true);
    }
}
