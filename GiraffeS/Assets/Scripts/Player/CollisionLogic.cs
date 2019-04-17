using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLogic : MonoBehaviour
{
    public GameObject Background;
    bool shouldSpeedUp = false;
    float scrollSpeed;
    float acceleration = 0.2f;


    private void FixedUpdate()
    {
        if (shouldSpeedUp == true)
        {
            scrollSpeed += acceleration;
            Background.GetComponent<BackgroundScroller>().SetSpeed(scrollSpeed);
            if (scrollSpeed >= 10.0f)
            {
                scrollSpeed = 10.0f;
                shouldSpeedUp = false;
            }
            Debug.Log(scrollSpeed);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            scrollSpeed = 5.0f;
            Background.GetComponent<BackgroundScroller>().SetSpeed(scrollSpeed);
        }
        //Background.GetComponent<BackgroundScroller>().InvokeReset();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            shouldSpeedUp = true;
        }
    }

}
