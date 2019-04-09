using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Appletext : MonoBehaviour
{
    public TextMeshProUGUI text;
    
    public int wert;
    public int i;

    void Start()
    {
        wert = SumScript.Count();
        SetText();
    }

    void SetText()
    {
        text.text = wert.ToString();
    }
}
