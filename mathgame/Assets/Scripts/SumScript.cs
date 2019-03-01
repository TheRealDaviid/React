using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SumScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int score;
  
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        score += int.Parse(collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text.ToString());
        UpdateScore();
    }
    // Update is called once per frame
    void UpdateScore()
    {       
        text.text = score.ToString();
    }
}
