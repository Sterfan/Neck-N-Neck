using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLogic : MonoBehaviour
{
    public GameObject Backgrounds;
    public GameObject Giraffe;
    public GameObject LeafParticles;
    public GameObject ThornParticles;
    public GameObject CountdownTimer;
    public GameObject ProgressTracker;
    public GameObject HeadSpeedLines1;
    public GameObject BodySpeedLines1;
    public GameObject HeadSpeedLines2;
    public GameObject BodySpeedLines2;
    public GameObject HeadSpeedLines3;
    public GameObject BodySpeedLines3;

    //GameObject[] FirstSpeedLines;
    //GameObject[] SecondSpeedLines;
    //GameObject[] ThirdSpeedLines;

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
        //FirstSpeedLines = GameObject.FindGameObjectsWithTag("FirstSpeedLines");
        //SecondSpeedLines = GameObject.FindGameObjectsWithTag("SecondSpeedLines");
        //ThirdSpeedLines = GameObject.FindGameObjectsWithTag("ThirdSpeedLines");
        //FirstSpeedLines[0] = HeadSpeedLines1;
        //FirstSpeedLines[1] = BodySpeedLines1;
        //SecondSpeedLines[0] = HeadSpeedLines2;
        //SecondSpeedLines[1] = BodySpeedLines2;
        //ThirdSpeedLines[0] = BodySpeedLines3;
        //ThirdSpeedLines[1] = HeadSpeedLines3;


        //LeafParticles.GetComponent<ParticleSystem>().Stop();
    }

    private void Update()
    {
        //Debug.Log(multiplier);
        //Debug.Log(CountdownTimer.GetComponent<CountdownTimer>().startGame == true);
        if (CountdownTimer.GetComponent<CountdownTimer>().GetStartGame() == true && ProgressTracker.GetComponent<PlayerProgress>().isFinished == false)
        {
            timeSinceHit += Time.deltaTime;
            //Debug.Log(timeSinceHit);
            if (timeSinceHit >= 6.0f && multiplier <= 1.3f)
            {
                //Debug.Log("Should speed up");
                multiplier += overSpeedAcceleration * Time.deltaTime;
                Backgrounds.GetComponent<BGSpeedMultiplier>().SetSpeedMultiplier(multiplier);
                //if (multiplier <= 1.15f)
                //{
                Debug.Log("First Lines");
                //StartSpeedLines(FirstSpeedLines);
                HeadSpeedLines1.SetActive(true);
                BodySpeedLines1.SetActive(true);
                //}
                if (multiplier >= 1.13f)
                {
                    Debug.Log("Second Lines");

                    HeadSpeedLines2.SetActive(true);
                    BodySpeedLines2.SetActive(true);
                    if (multiplier > 1.15f)
                    {
                        HeadSpeedLines1.SetActive(false);
                        BodySpeedLines1.SetActive(false);
                    }
                    //StartSpeedLines(SecondSpeedLines);
                    //StopSpeedLines(FirstSpeedLines);
                }
                if (multiplier >= 1.23f)
                {
                    Debug.Log("Third Lines");

                    HeadSpeedLines3.SetActive(true);
                    BodySpeedLines3.SetActive(true);
                    if (multiplier > 1.25f)
                    {
                        HeadSpeedLines2.SetActive(false);
                        BodySpeedLines2.SetActive(false);
                    }
                    //StartSpeedLines(ThirdSpeedLines);
                    //StopSpeedLines(SecondSpeedLines);
                }
            }
        }
        if (multiplier <= 1.0f)
        {
            HeadSpeedLines1.SetActive(false);
            BodySpeedLines1.SetActive(false);
            HeadSpeedLines2.SetActive(false);
            BodySpeedLines2.SetActive(false);
            HeadSpeedLines3.SetActive(false);
            BodySpeedLines3.SetActive(false);
            //StopSpeedLines(FirstSpeedLines);
            //StopSpeedLines(SecondSpeedLines);
            //StopSpeedLines(ThirdSpeedLines);
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
        if (collision.CompareTag("HeadObstacle") || collision.CompareTag("LegObstacle"))
        {
            //LeafParticles.SetActive(true);
            //if (Giraffe.GetComponent<PlayerController>().Dashing == false)
            //{
                if (collision.CompareTag("HeadObstacle") && LeafParticles.GetComponent<ParticleSystem>().isEmitting == false)
                {
                    LeafParticles.GetComponent<ParticleSystem>().Play();
                }
                if (collision.CompareTag("LegObstacle") && ThornParticles.GetComponent<ParticleSystem>().isEmitting == false)
                {
                    ThornParticles.GetComponent<ParticleSystem>().Play();
                }

            //}
            FindObjectOfType<AudioManager>().Play("Leaves");
            if (multiplier >= 0.7f/* && Giraffe.GetComponent<PlayerController>().Dashing == false*/)
            {
                multiplier = 0.7f;
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
        //if (Giraffe.GetComponent<PlayerController>().Dashing == false)
        //{
            if (collision.CompareTag("HeadObstacle") || collision.CompareTag("LegObstacle"))
            //LeafParticles.SetActive(true);
            //LeafParticles.GetComponent<ParticleSystem>().Play();
            timeSinceHit = 0.0f;
            if (multiplier >= 0.25f)
            {
                multiplier *= 0.98f;
                Backgrounds.GetComponent<BGSpeedMultiplier>().SetSpeedMultiplier(multiplier);
            }
        //}

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (Giraffe.GetComponent<PlayerController>().Dashing == false)
        //{
            if (collision.CompareTag("HeadObstacle") || collision.CompareTag("LegObstacle"))
            {
                timeSinceHit = 0.0f;
                shouldSpeedUp = true;
                FindObjectOfType<AudioManager>().StopMusic("Leaves");
                if (collision.CompareTag("HeadObstacle"))
                {
                    LeafParticles.GetComponent<ParticleSystem>().Stop();
                }
                if (collision.CompareTag("LegObstacle"))
                {
                    ThornParticles.GetComponent<ParticleSystem>().Stop();
                }
            }
        //}
    }

    public void SetSpeedUpFalse()
    {
        shouldSpeedUp = false;
    }

    public void StartSpeedLines(GameObject[] speedlines)
    {
        for (int i = 0; i < 2; i++)
        {
            //speedlines[i].GetComponent<ParticleSystem>().Play();
            speedlines[i].SetActive(true);
        }
    }

    public void StopSpeedLines(GameObject[] speedlines)
    {
        for (int i = 0; i < 2; i++)
        {
            speedlines[i].SetActive(false);
            //speedlines[i].GetComponent<ParticleSystem>().Clear();
            //speedlines[i].GetComponent<ParticleSystem>().Stop();

        }
    }

    //void UpgradeParticles()
    //{
    //    FirstSpeedLines[1].GetComponent<ParticleSystem>().emission
    //}
}
