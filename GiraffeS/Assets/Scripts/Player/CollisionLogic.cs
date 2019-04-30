using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLogic : MonoBehaviour
{
    public GameObject BGManager;
    public GameObject Background;
    bool shouldSpeedUp = false;
    float scrollSpeed;
    float multiplier;
    [SerializeField] float acceleration = 0.15f;


    private void Start()
    {
        scrollSpeed = Background.GetComponent<BackgroundScroller>().scrollSpeed;
    }

    private void Update()
    {
        multiplier = Background.GetComponent<BackgroundScroller>().speedMultiplier;

        if (shouldSpeedUp == true && scrollSpeed * multiplier < scrollSpeed)
        {
            multiplier += acceleration * Time.deltaTime;
            Background.GetComponent<BackgroundScroller>().SetSpeedMultiplier(multiplier);
            if (multiplier >= 1.0f)
            {
                shouldSpeedUp = false;
                multiplier = 1.0f;
            }
            //Debug.Log(scrollSpeed);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            multiplier = 0.5f;
            Background.GetComponent<BackgroundScroller>().SetSpeedMultiplier(multiplier);
            FindObjectOfType<AudioManager>().Play("Leaves");
        }
        //Background.GetComponent<BackgroundScroller>().InvokeReset();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            shouldSpeedUp = true;
            FindObjectOfType<AudioManager>().StopMusic("Leaves");
        }
    }

}
