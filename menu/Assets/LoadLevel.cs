﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string sceneToLoad;
    void Start()
    {

    }

    void Update()
    {

    }

    // Start is called before the first frame update
    
    public void playGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

  
}
