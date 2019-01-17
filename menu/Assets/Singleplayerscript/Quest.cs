using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Quest : MonoBehaviour
{
    Transform player;
    int check = 0;
    public GameObject Questbox1;
    bool checkifdone = false;
    GameObject freezePlayer;
    Button lösen;
    // Start is called before the first frame update
    void Start()
    {
        freezePlayer = GameObject.Find("Cube");
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name.StartsWith("Cube"))
        {
            
                if (check == 0)
                {
                    Questbox1.SetActive(true);
                    freezePlayer.SetActive(false);
                }   
        }
        
    }

    

    void Close()
    {
        Questbox1.SetActive(false);
        freezePlayer.SetActive(true);
    }

    
}
