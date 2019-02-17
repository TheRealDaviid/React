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

    public int erg = 0;
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

        if (collision.tag == "Player")
        {
            Debug.Log("Collision");
            Debug.Log(aufgabe.activeSelf);
            aufgabe.SetActive(true);
            Debug.Log(aufgabe.activeSelf);
            int random1 = Random.Range(1, 50);
            int random2 = Random.Range(1, 50);
            
            int randomoperator = Random.Range(1, 3);

            if (randomoperator == 1)
            {
                erg = random1 + random2;
                rechnung.text = random1 + " + " + random2;
                Debug.Log(erg);
            }
            if (randomoperator == 2)
            {
                if (random1 > random2)
                {
                    erg = random1 - random2;
                    rechnung.text = random1 + " - " + random2;
                    Debug.Log(erg);
                }
                else
                {
                    erg = random2 - random1;
                    rechnung.text = random2 + " - " + random1;
                    Debug.Log(erg);
                }
            }
            if (scoreCounter > PlayerPrefs.GetInt("Highscore"))
            {
                PlayerPrefs.SetInt("Highscore", scoreCounter);
                highScore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();
            }


            


        }

    }
    public void Close()
    {

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
        Debug.Log(aufgabe.activeSelf);
        aufgabe.SetActive(false);


       
    }
}

   
