using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int timesPlayed = 0;
    private void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    //Call this in PlayerProgress, find a place to input name

    public void AddScore(string name, float score)
    {
        float newScore;
        string newName;
        float oldScore;
        string oldName;
        newScore = score;
        newName = name;

        for (int i = 0; i < timesPlayed; i++)
        {
            if (PlayerPrefs.HasKey(i + "HScore"))
            {
                if (PlayerPrefs.GetInt(i+"HScore") > newScore)
                {
                    oldScore = PlayerPrefs.GetInt(i + "HScore");
                    oldName = PlayerPrefs.GetString(i + "HScoreName");
                    PlayerPrefs.SetFloat(i + "HScore", newScore);
                    PlayerPrefs.SetString(i + "HScoreName", newName);
                    newScore = oldScore;
                    newName = oldName;
                    timesPlayed++;
                }
            }
            else
            {
                PlayerPrefs.SetFloat(i + "HScore", newScore);
                PlayerPrefs.SetString(i + "HScoreName", newName);
                newScore = 999;
                newName = "";
                timesPlayed++;
            }
        }
    }


    public void NewScore(float score)
    {
        float newScore;
        float oldScore;
        newScore = score;

        if (PlayerPrefs.HasKey("timesPlayed"))
        {
            PlayerPrefs.SetInt("timesPlayed", PlayerPrefs.GetInt("timesPlayed") + 1);
            timesPlayed = PlayerPrefs.GetInt("timesPlayed");
            for (int i = 0; i < timesPlayed ; i++)
            {
                if (PlayerPrefs.HasKey(i + "HScore"))
                {
                    if (newScore < PlayerPrefs.GetFloat(i+"HScore")) //Change the sign to "NS < OS" here since we want lowest time
                    {
                        oldScore = PlayerPrefs.GetFloat(i + "HScore");
                        PlayerPrefs.SetFloat(i + "HScore", newScore);
                        newScore = oldScore;
                    }
                }
                else
                {
                    PlayerPrefs.SetFloat(i + "HScore", newScore);
                    newScore = 999; //Set this to something high
                }
            }

        }
        else
        {
            PlayerPrefs.SetInt("timesPlayed", 0);
            NewScore(score);
        }
    }
}
