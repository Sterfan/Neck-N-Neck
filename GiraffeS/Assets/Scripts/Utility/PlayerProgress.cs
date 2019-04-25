﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProgress : MonoBehaviour
{
    public GameObject countdownTimer;
    public GameObject background;
    float gameTime = 0;
    float startPos;
    float endPos;
    float percentProgress;
    float height;
    float width;
    public float yPos = 5.7f;

    public Text topTimer;
    public Text botTimer;

    bool top;
    bool bottom;


    void Start()
    {
        Camera cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        startPos = cam.transform.position.x - (width / 4);
        endPos = cam.transform.position.x - (width / 4);
        gameObject.transform.position = new Vector2(startPos, yPos);
    }

    void FixedUpdate()
    {
        if (countdownTimer.GetComponent<CountdownTimer>().startGame == true)
        {
            percentProgress = background.GetComponent<BackgroundScroller>().GetPercentCompleted();
            gameTime += Time.deltaTime;

            gameObject.transform.position = new Vector2(startPos + (width / 2 * percentProgress / 100), yPos);

            if (top)
            {
                topTimer.text = gameTime.ToString();
            }
            if (bottom)
            {
                botTimer.text = gameTime.ToString();
            }
        }

    }
}
