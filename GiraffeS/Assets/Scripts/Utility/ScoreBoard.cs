using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{

    //Call this in PlayerProgress, find a place to input name

    public void AddScore(string name, float score)
    {
        float newScore;
        string newName;
        float oldScore;
        string oldName;
        newScore = score;
        newName = name;

        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey(i + "HScore"))
            {
                if (PlayerPrefs.GetInt(i+"HScore") < newScore)
                {
                    oldScore = PlayerPrefs.GetInt(i + "HScore");
                    oldName = PlayerPrefs.GetString(i + "HScoreName");
                    PlayerPrefs.SetFloat(i + "HScore", newScore);
                    PlayerPrefs.SetString(i + "HScoreName", newName);
                    newScore = oldScore;
                    newName = oldName;
                }
            }
            else
            {
                PlayerPrefs.SetFloat(i + "HScore", newScore);
                PlayerPrefs.SetString(i + "HScoreName", newName);
                newScore = 0;
                newName = "";
            }
        }
    }


    public void NewScore(float score)
    {
        float newScore;
        //string newName;
        float oldScore;
        //string oldName;
        newScore = score;
        //newName = name;

        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey(i + "HScore"))
            {
                if (PlayerPrefs.GetInt(i+"HScore") < newScore)
                {
                    oldScore = PlayerPrefs.GetInt(i + "HScore");
                    //oldName = PlayerPrefs.GetString(i + "HScoreName");
                    PlayerPrefs.SetFloat(i + "HScore", newScore);
                    //PlayerPrefs.SetString(i + "HScoreName", newName);
                    newScore = oldScore;
                    //newName = oldName;
                }
            }
            else
            {
                PlayerPrefs.SetFloat(i + "HScore", newScore);
                //PlayerPrefs.SetString(i + "HScoreName", newName);
                newScore = 0;
                //newName = "";
            }
        }
    }
}
