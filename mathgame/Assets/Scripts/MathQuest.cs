using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MathQuest : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {       
        //appletext app = new appletext();
        
        int random1 = Random.Range(1, 50);
        int random2 = Random.Range(1, 50);
        string newText = $"{random1} + {random2} = ";
        text.text = newText;
    }
}
