using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 10.0f;

    private Vector3 startPosition;

    private float newPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        newPosition += Time.deltaTime * scrollSpeed;
        transform.position = startPosition + Vector3.left * newPosition;
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
