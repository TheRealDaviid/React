using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class appletext : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Random random1;
    // Start is called before the first frame update
    void Start()
    {
        int random1 = Random.Range(1, 10);
        text.text = random1.ToString();
    }
}
