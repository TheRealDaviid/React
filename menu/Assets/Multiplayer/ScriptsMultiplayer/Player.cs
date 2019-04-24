using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static int scoreCounter = 0; //private damit nicht manipulierbar
    public static int rightCounter = 0; //private damit nicht manipulierbar
    public static int falseCounter = 0; //private damit nicht manipulierbar
    public Text scoreText;
   

    public InputField ergebnis;
    public GameObject aufgabe;
    public Text rechnung;
    public GameObject player;

    public int erg = 0;
    public static System.DateTime theDate = new System.DateTime(System.DateTime.Today.Year, System.DateTime.Today.Month, System.DateTime.Today.Day);
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

            if (collision.gameObject.tag == "Checkpoint")
            {

                Debug.Log("Collision");
                Debug.Log(aufgabe.activeInHierarchy);
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
                


            }

        }
    public void Close()
    {

        if (erg == int.Parse(ergebnis.text))
        {
            scoreCounter++;
            rightCounter++;
            scoreText.text = "Score: " + scoreCounter.ToString(); //geht auch ohne ToString() ist aber sicherer
            Debug.Log(scoreCounter);
        }
        else
        {
            scoreCounter--;
            falseCounter++;
            scoreText.text = "Score: " + scoreCounter.ToString(); //geht auch ohne ToString() ist aber sicherer
            Debug.Log(scoreCounter);
        }
        Debug.Log(aufgabe.activeSelf);
        aufgabe.SetActive(false);
       

    }

    public static void LevelEnd(int name)
    {
        Debug.Log("affe");
        HighscoreMultiplayer.Start();
        HighscoreMultiplayer.InsertScore((HighscoreMultiplayer.GetLastID() + 1).ToString(), scoreCounter, theDate.ToString(), rightCounter,  falseCounter, name, 2);
        Debug.Log("affe8888888888");

    }

}
    



   
