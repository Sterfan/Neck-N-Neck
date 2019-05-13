using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLogic : MonoBehaviour
{
    public GameObject Backgrounds;
    public GameObject Giraffe;
    public GameObject LeafParticles;
    public GameObject TimeController;
    public GameObject ProgressTracker;
    bool shouldSpeedUp = false;
    float scrollSpeed;
    float multiplier;
    float timeSinceHit = 0.0f;
    float overSpeedAcceleration = 0.1f;
    [SerializeField] float acceleration = 0.15f;


    private void Start()
    {
        //scrollSpeed = Backgrounds.GetComponent<BGSpeedMultiplier>().GetSpeedMultiplier();
        multiplier = Backgrounds.GetComponent<BGSpeedMultiplier>().GetSpeedMultiplier();
        //LeafParticles.GetComponent<ParticleSystem>().Stop();
    }

    private void Update()
    {
        if (TimeController.GetComponent<CountdownTimer>().startGame == true && ProgressTracker.GetComponent<PlayerProgress>().isFinished == false)
        {
            timeSinceHit += Time.deltaTime;
            if (timeSinceHit >= 6.0f && multiplier < 1.3f)
            {
                multiplier += overSpeedAcceleration * Time.deltaTime;
                Backgrounds.GetComponent<BGSpeedMultiplier>().SetSpeedMultiplier(multiplier);
            }
        }

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
        if (collision.CompareTag("Obstacle"))
        {
            //LeafParticles.SetActive(true);
            if (LeafParticles.GetComponent<ParticleSystem>().isEmitting == false)
            {
                LeafParticles.GetComponent<ParticleSystem>().Play();
            }
            FindObjectOfType<AudioManager>().Play("Leaves");
            if (multiplier >= 0.5f && Giraffe.GetComponent<PlayerController>().Dashing == false)
            {
                multiplier = 0.5f;
                Backgrounds.GetComponent<BGSpeedMultiplier>().SetSpeedMultiplier(multiplier);
                timeSinceHit = 0.0f;

            }
            //Background.GetComponent<BackgroundScroller>().SetSpeedMultiplier(multiplier);
        }
        if (collision.CompareTag("DashAmmo"))
        {
            Giraffe.GetComponent<PlayerController>().SetDashAmmo(1.0f);
            Destroy(collision.gameObject);
        }
        //Background.GetComponent<BackgroundScroller>().InvokeReset();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") && Giraffe.GetComponent<PlayerController>().Dashing == false)
        {
            //LeafParticles.SetActive(true);
            //LeafParticles.GetComponent<ParticleSystem>().Play();
            timeSinceHit = 0.0f;
            if (multiplier >= 0.25f)
            {
                multiplier *= 0.99f;
                Backgrounds.GetComponent<BGSpeedMultiplier>().SetSpeedMultiplier(multiplier);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") && Giraffe.GetComponent<PlayerController>().Dashing == false)
        {
            timeSinceHit = 0.0f;
            shouldSpeedUp = true;
            FindObjectOfType<AudioManager>().StopMusic("Leaves");
            LeafParticles.GetComponent<ParticleSystem>().Stop();
        }
    }

}
