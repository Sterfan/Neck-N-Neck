using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public GameObject countdownTimer;
    public GameObject finishLine;
    public GameObject Backgrounds;
    public GameObject giraffe;

    public float scrollSpeed = 10.0f;
    float speedMultiplier = 1.0f;

    private Vector2 BGStartPos;
    private Vector2 giraffeStartPos;
    private Vector2 endPosition;

    float totalDistance;
    float distanceTraveled;
    float percentCompleted;

    public bool slowStart = false;
    public bool isMainBg;

    public bool cameraScrolling;
    public bool testPurposes;

    //bool dashing = false;


    private float newPosition;

    void Start()
    {
        //startPosition = new Vector2(transform.position.x + giraffe.transform.position.x, transform.position.y);
        giraffeStartPos = giraffe.transform.position;
        BGStartPos = transform.position;
        if (isMainBg)
        {
            endPosition = finishLine.transform.position;
            totalDistance = endPosition.x - giraffeStartPos.x;
        }
    }

    void Update()
    {
        speedMultiplier = Backgrounds.GetComponent<BGSpeedMultiplier>().GetSpeedMultiplier();

        //Vector3 deltaPos = Time.deltaTime * Vector2.left * 14.0f;
        //transform.Translate(deltaPos);

        //// transform.position += deltaPos;
        if (countdownTimer.GetComponent<CountdownTimer>().startGame == true)
        {
            newPosition += Time.deltaTime * scrollSpeed * speedMultiplier;
            if (!cameraScrolling)
                transform.position = BGStartPos + Vector2.left * newPosition;
            if (cameraScrolling)
                transform.position = BGStartPos + Vector2.right * newPosition;
            if (isMainBg)
            {
                distanceTraveled = totalDistance - (giraffe.transform.position.x - giraffeStartPos.x);
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
        //dashing = true;
    }
}
