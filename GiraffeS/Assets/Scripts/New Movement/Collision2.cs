using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision2 : MonoBehaviour
{
    public GameObject BackgroundManager;
    public GameObject SpeedController;
    public GameObject Giraffe;
    public GameObject LeafParticles;
    public GameObject TimeController;
    public GameObject ProgressTracker;
    bool shouldSpeedUp = false;
    float startSpeed;
    float multiplier;
    float currentSpeed;
    float timeSinceHit = 0.0f;
    [SerializeField] float overSpeedAcceleration = 0.1f;
    [SerializeField] float acceleration = 3.0f;


    private void Start()
    {
        multiplier = BackgroundManager.GetComponent<BGSpeedMultiplier>().GetSpeedMultiplier();
        startSpeed = SpeedController.GetComponent<MainSpeed>().GetSpeed();
        currentSpeed = startSpeed;
        //LeafParticles.GetComponent<ParticleSystem>().Stop();
    }

    private void Update()
    {
        if (TimeController.GetComponent<CountdownTimer>().startGame == true && ProgressTracker.GetComponent<PlayerProgress>().isFinished == false)
        {
            timeSinceHit += Time.deltaTime;
            if (timeSinceHit >= 6.0f && multiplier < startSpeed * 1.3f)
            {
                currentSpeed += overSpeedAcceleration * Time.deltaTime;
                SpeedController.GetComponent<MainSpeed>().SetSpeed(currentSpeed);
            }
        }

        if (shouldSpeedUp == true && currentSpeed <= startSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
            SpeedController.GetComponent<MainSpeed>().SetSpeed(currentSpeed);
            if (currentSpeed >= startSpeed)
            {
                shouldSpeedUp = false;
                currentSpeed = startSpeed;
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
            if (currentSpeed >= 0.5f * startSpeed && Giraffe.GetComponent<PlayerController>().Dashing == false)
            {
                BackgroundManager.GetComponent<BGSpeedMultiplier>().SetSpeedMultiplier(0.5f);
                currentSpeed = 0.5f * startSpeed;
                SpeedController.GetComponent<MainSpeed>().SetSpeed(currentSpeed);
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
            if (currentSpeed >= 0.25f * startSpeed)
            {
                BackgroundManager.GetComponent<BGSpeedMultiplier>().SetSpeedMultiplier(0.5f);
                currentSpeed *= 0.99f;
                SpeedController.GetComponent<MainSpeed>().SetSpeed(currentSpeed);
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
