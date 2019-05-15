﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class pButtonFunctions
{
    public static void GetFunction(int index)
    {
        switch(index)
        {
            case 1:
                NextScene();
                break;
            case 2:
                Debug.Log("Button 2 works as well hehe");
                break;
            default:
                Debug.LogError("No button function passed in the switch function in the pButtonFunctions script.");
                break;
        }
    }


    public static void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}