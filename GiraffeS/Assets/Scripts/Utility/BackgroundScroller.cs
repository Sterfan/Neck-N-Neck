using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private GameObject countdownTimer;

    public float scrollSpeed = 10.0f;

    private Vector3 startPosition;

    private float newPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (countdownTimer.GetComponent<CountdownTimer>().startGame == true)
        {
            newPosition += Time.deltaTime * scrollSpeed;
            transform.position = startPosition + Vector3.left * newPosition;
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
}
