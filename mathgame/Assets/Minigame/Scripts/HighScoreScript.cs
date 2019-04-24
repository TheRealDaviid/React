using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{


    public GameObject rank;
    public GameObject Name;
    public GameObject Datum;
    public GameObject richtige;
    public GameObject falsche;
    public GameObject Score;

    public void SetScore(string rank, string name, int score, string datum, int richtig, int falsch)
    {
        this.rank.GetComponent<Text>().text = rank.ToString();
        this.Name.GetComponent<Text>().text = name.ToString();
        this.Score.GetComponent<Text>().text = score.ToString();
        this.Datum.GetComponent<Text>().text = datum.ToString();
        this.richtige.GetComponent<Text>().text = richtig.ToString();
        this.falsche.GetComponent<Text>().text = falsch.ToString();
    }
}
