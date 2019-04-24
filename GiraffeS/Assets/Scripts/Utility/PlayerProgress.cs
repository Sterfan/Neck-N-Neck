using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public GameObject countdownTimer;
    float gameTime;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (countdownTimer.GetComponent<CountdownTimer>().startGame == true)
        {
            gameTime += Time.deltaTime;
        }

    }
}
