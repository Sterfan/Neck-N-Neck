using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public GameObject countdownTimer;
    public GameObject finishLine;

    public float scrollSpeed = 10.0f;

    private Vector3 startPosition;
    private Vector3 endPosition;

    float totalDistance;
    float distanceTraveled;
    float percentCompleted;


    private float newPosition;

    void Start()
    {
        startPosition = transform.position;
        endPosition = finishLine.transform.position;
        totalDistance = endPosition.x - startPosition.x;
    }

    void FixedUpdate()
    {
        if (countdownTimer.GetComponent<CountdownTimer>().startGame == true)
        {
            newPosition += Time.deltaTime * scrollSpeed;
            transform.position = startPosition + Vector3.left * newPosition;
            distanceTraveled = totalDistance - (startPosition.x - transform.position.x);
            percentCompleted = (1 - (distanceTraveled / totalDistance)) * 100;
            // Get camera size and set position to a % of x screen size I guess
        }
    }

    public void SetSpeed(float speed)
    {
        scrollSpeed = speed;
    }

    public void ResetSpeed()
    {
        scrollSpeed = 10.0f;
    }

    public void InvokeReset()
    {
        Invoke("ResetSpeed", 0.25f);
    }

    public float GetPercentCompleted()
    {
        return percentCompleted;
    }
}
