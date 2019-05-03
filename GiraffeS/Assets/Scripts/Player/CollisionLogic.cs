using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLogic : MonoBehaviour
{
    public GameObject Backgrounds;
    public GameObject Giraffe;
    bool shouldSpeedUp = false;
    float scrollSpeed;
    float multiplier;
    [SerializeField] float acceleration = 0.15f;


    private void Start()
    {
        //scrollSpeed = Backgrounds.GetComponent<BGSpeedMultiplier>().GetSpeedMultiplier();
        multiplier = Backgrounds.GetComponent<BGSpeedMultiplier>().GetSpeedMultiplier();
    }

    private void Update()
    {

        if (shouldSpeedUp == true && multiplier <= 1.0f)
        {
            multiplier += acceleration * Time.deltaTime;
            Backgrounds.GetComponent<BGSpeedMultiplier>().SetSpeedMultiplier(multiplier);
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
        if (collision.CompareTag("Obstacle") && Giraffe.GetComponent<PlayerController>().Dashing == false)
        {
            multiplier = 0.5f;
            Backgrounds.GetComponent<BGSpeedMultiplier>().SetSpeedMultiplier(multiplier);
            //Background.GetComponent<BackgroundScroller>().SetSpeedMultiplier(multiplier);
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
