using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public GameObject countdownTimer;
    public GameObject background;
    float gameTime;
    float startPos;
    float endPos;
    float percentProgress;
    float height;
    float width;
    public float yPos = 5.7f;

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
        top = gameObject.CompareTag("Top Background");
        bottom = gameObject.CompareTag("Bottom Background");
    }

    void FixedUpdate()
    {
        if (countdownTimer.GetComponent<CountdownTimer>().startGame == true)
        {
            percentProgress = background.GetComponent<BackgroundScroller>().GetPercentCompleted();
            gameTime += Time.deltaTime;

            gameObject.transform.position = new Vector2(startPos + (width / 2 * percentProgress / 100), yPos);

        }

    }
}
