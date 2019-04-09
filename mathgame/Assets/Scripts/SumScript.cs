using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using Mono.Data.Sqlite;

public class SumScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI textF;
    public TextMeshProUGUI textW;

    private static TextMeshProUGUI t1;
    private static TextMeshProUGUI t2;
    private static TextMeshProUGUI t3;

    static private int score;
    static public int fragenCounter = 0;
    static private int counter;
    static private int PR1;
    static private int PR2;
    static private int rightCounter = 0;
    private static int i = 0;

    public static System.DateTime theDate = new System.DateTime(System.DateTime.Today.Year, System.DateTime.Today.Month, System.DateTime.Today.Day);
    void Start()
    {
        t1 = text;
        t2 = textF;
        t3 = textW;
        UpdateQuestion();
        score = 0;
        counter = 0;
        UpdateScore();
    }

    public static int Count()
    {
        i++;
        if (i == 10)
        {
            i = 1;
        }
        return i;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (counter == 0)
        {
            //zehnerstelle zuerst fangen einerstelle dazu addieren
            score += int.Parse(collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text.ToString());
            score *= 10;
            counter++;
        }
        else
        {
            score += int.Parse(collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text.ToString());
        }

        if (score > (PR1 + PR2))
        {
            score = 0;
            counter = 0;
            UpdateQuestion();
        }
        else
        {
            text.text = score.ToString();
        }
        UpdateScore();
    }

    static void UpdateQuestion()
    {
        score = 0;
        int random1 = Random.Range(1, 50);
        int random2 = Random.Range(9, 50);
        PR1 = random1;
        PR2 = random2;
        string newTextF = $"{random1} + {random2} = ";
        t3.text = string.Join("", "Richtig: ", rightCounter.ToString());

        if (fragenCounter == 4)
        {
            Debug.Log("wir sind fertig");
            Highscore.Start();
            Highscore.InsertScore((Highscore.GetLastID() + 1).ToString(), 0, theDate.ToString(),rightCounter,3-rightCounter,2,2);
            
        }
        t2.text = newTextF;
    }

    public static void UpdateScore()
    {
        
        if (score == (PR1 + PR2)&& PlayerMovement.check==true)
        {
            score = 0;
            counter = 0;
            PlayerMovement.check = false;
            t1.text = score.ToString();
            UpdateQuestion();
            rightCounter++;
            t3.text = string.Join("", "Richtig: ", rightCounter.ToString());
        }
        if (score > (PR1 + PR2)&&PlayerMovement.check==true)
        {
            score = 0;
            counter = 0;
            t1.text = score.ToString();
            PlayerMovement.check = false;
            UpdateQuestion();
        }
        if (score < (PR1 + PR2) && PlayerMovement.check == true)
        {
            score = 0;
            counter = 0;
            t1.text = score.ToString();
            PlayerMovement.check = false;
            UpdateQuestion();
        }
        else
        {
            t1.text = score.ToString();
        }
    }
}
