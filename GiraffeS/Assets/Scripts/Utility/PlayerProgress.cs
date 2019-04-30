using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProgress : MonoBehaviour
{
    public GameObject countdownTimer;
    public GameObject background;
    public GameObject otherGiraffeTracker;

    public Image position;

    public Sprite first;
    public Sprite second;

    float gameTime = 0;
    float startPos;
    float endPos;
    float percentProgress;
    float distanceTraveled;
    float height;
    float width;
    public float yPos = 5.7f;

    public Text timer;
    public Text resultText;

    public bool isFinished = false;
    public bool winner = false;


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
            distanceTraveled = background.GetComponent<BackgroundScroller>().GetDistanceTraveled();

            if (isFinished == false)
            {
                gameTime += Time.deltaTime;
                if (distanceTraveled <= otherGiraffeTracker.GetComponent<PlayerProgress>().distanceTraveled)
                {
                    position.sprite = first;
                }
                if (distanceTraveled > otherGiraffeTracker.GetComponent<PlayerProgress>().distanceTraveled)
                {
                    position.sprite = second;
                }
            }

            gameObject.transform.position = new Vector2(startPos + (width / 2 * percentProgress / 100), yPos);
            timer.text = gameTime.ToString("n2");

            if (isFinished == true && otherGiraffeTracker.GetComponent<PlayerProgress>().isFinished == false)
            {
                winner = true;
            }
            if (winner == true)
            {
                position.sprite = first;
                resultText.text = "WINNER";
            }
            if (otherGiraffeTracker.GetComponent<PlayerProgress>().winner == true)
            {
                position.sprite = second;
            }
            if (isFinished == true && winner == false)
            {
                resultText.text = "SECOND WINNER";
            }
        }
    }
}
