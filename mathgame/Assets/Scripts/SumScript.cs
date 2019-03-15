using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class SumScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI textF;
    public TextMeshProUGUI textW;

    private int score;
    //private int fragenCounter = 0;
    private int counter;
    private int PR1;
    private int PR2;
    private int rightCounter = 0;
    private static int i = 0;
    
    void Start()
    {
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

    void UpdateQuestion()
    {
        score = 0;
        int random1 = Random.Range(1, 50);
        int random2 = Random.Range(9, 50);
        PR1 = random1;
        PR2 = random2;
        string newTextF = $"{random1} + {random2} = ";
        textW.text = string.Join("", "Richtig: ", rightCounter.ToString());
        textF.text = newTextF;
    }

    void UpdateScore()
    {
        //if (fragenCounter==11)
        //{

        //}
        if (score == (PR1 + PR2))
        {
            score = 0;
            counter = 0;
            UpdateQuestion();
            rightCounter++;
            textW.text = string.Join("", "Richtig: ", rightCounter.ToString());
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
    }
}
