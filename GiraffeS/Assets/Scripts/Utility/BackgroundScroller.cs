using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public GameObject countdownTimer;
    public GameObject finishLine;
    public GameObject BGManager;
    //public GameObject giraffe;

    public float scrollSpeed = 10.0f;
    float speedMultiplier;

    private Vector2 startPosition;
    private Vector2 endPosition;

    float totalDistance;
    float distanceTraveled;
    float percentCompleted;

    public bool slowStart = false;
    public bool isMainBg;

    public bool testPurposes;

    bool dashing = false;


    private float newPosition;

    void Start()
    {
        //startPosition = new Vector2(transform.position.x + giraffe.transform.position.x, transform.position.y);
        if (isMainBg)
        {
            startPosition = transform.position;
            endPosition = finishLine.transform.position;
            totalDistance = endPosition.x - startPosition.x;
        }
    }


    void Update()
    {
        speedMultiplier = BGManager.GetComponent<BGSpeedMultiplier>().GetSpeedMultiplier();

        if (countdownTimer.GetComponent<CountdownTimer>().startGame == true)
        {
            newPosition += Time.deltaTime * scrollSpeed * speedMultiplier;
            transform.position = startPosition + Vector2.left * newPosition;
            if (isMainBg)
            {
                distanceTraveled = totalDistance - (startPosition.x - transform.position.x);
                percentCompleted = (1 - (distanceTraveled / totalDistance)) * 100;
            }
        }
        if (testPurposes == true)
        {
            Debug.Log(Time.deltaTime * scrollSpeed * speedMultiplier);
        }
    }

    public void SetSpeed(float speed)
    {
        scrollSpeed = speed;
    }

    public void SetSpeedMultiplier(float multiplier)
    {
        speedMultiplier = multiplier;
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

    public float GetDistanceTraveled()
    {
        return distanceTraveled;
    }

    public void Dash(float dashSpeed)
    {
        speedMultiplier *= dashSpeed;
        dashing = true;
    }
}
