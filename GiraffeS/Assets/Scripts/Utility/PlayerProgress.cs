using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProgress : MonoBehaviour
{
    public GameObject countdownTimer;
    public GameObject Background1;
    public GameObject Backgrounds;
    public GameObject otherGiraffeTracker;
    public GameObject branchTracker;
    public GameObject Giraffe;
    public GameObject FinishLine;
    public GameObject ScoreManager;
    public GameObject DustyParticles;

    //public RectTransform branchyTracker;

    public Image position;

    public Sprite first;
    public Sprite second;

    float gameTime = 0;
    Vector2 startPos;
    float endPos;
    //Vector3[] branchCorners;
    float percentProgress;
    float distanceTraveled;
    float distanceRemaining;
    float height;
    float width;
    float trackLength;
    float pizzaDistance;
    public float yPos = 5.7f;

    public Text timer;
    public Text resultText;

    public bool isFinished = false;
    public bool winner = false;
    bool scored = false;


    void Start()
    {
        //Camera cam = Camera.main;
        //height = 2f * cam.orthographicSize;
        //width = height * cam.aspect;
        //startPos = cam.transform.position.x - (width / 4);
        startPos = gameObject.GetComponent<RectTransform>().position;
        endPos = branchTracker.GetComponent<RectTransform>().rect.width /** branchTracker.GetComponent<RectTransform>().localScale.x*/;
        pizzaDistance = branchTracker.GetComponent<RectTransform>().rect.width;
        //endPos = cam.transform.position.x - (width / 4);
        //endPos = gameObject.GetComponent<RectTransform>().offsetMax;
        //branchyTracker.GetWorldCorners(branchCorners);
        //Debug.Log(branchCorners);
        //gameObject.transform.position = new Vector2(startPos, yPos);
        trackLength = FinishLine.transform.position.x - Giraffe.transform.position.x;
        //Debug.Log(trackLength);
    }

    void LateUpdate()
    {

        if (countdownTimer.GetComponent<CountdownTimer>().startGame == true)
        {
            percentProgress = Background1.GetComponent<BackgroundScroller>().GetPercentCompleted();
            distanceTraveled = Background1.GetComponent<BackgroundScroller>().GetDistanceTraveled();
            distanceRemaining = FinishLine.transform.position.x - Giraffe.transform.position.x;

            if (isFinished == false)
            {
                gameTime += Time.deltaTime;
                //if (distanceTraveled < otherGiraffeTracker.GetComponent<PlayerProgress>().distanceTraveled)
                if (distanceRemaining < otherGiraffeTracker.GetComponent<PlayerProgress>().distanceRemaining)
                {
                    //Debug.Log("Should change to second");
                    position.sprite = first;
                    otherGiraffeTracker.GetComponent<PlayerProgress>().ChangePosSprite();
                }
                //if (distanceTraveled == otherGiraffeTracker.GetComponent<PlayerProgress>().distanceTraveled)
                if (distanceRemaining == otherGiraffeTracker.GetComponent<PlayerProgress>().distanceRemaining)
                {
                    position.sprite = first;
                }
            }

            //gameObject.transform.position = new Vector2(startPos + (width / 2 * percentProgress / 100), yPos);
            gameObject.transform.position = new Vector2(startPos.x + pizzaDistance * 0.98f * percentProgress / 100, startPos.y);
            timer.text = gameTime.ToString("n2");

            if (isFinished == true)
            {
                DustyParticles.SetActive(false);
                Giraffe.GetComponent<Animator>().SetBool("IsFinished", true);
                Backgrounds.GetComponent<BGSpeedMultiplier>().SetSpeedMultiplier(0.0f);
                if (scored == false)
                {
                    ScoreManager.GetComponent<ScoreBoard>().NewScore(gameTime); // CALL THIS ONLY ONCE
                    scored = true;
                    if (Giraffe.GetComponentInChildren<HeadMovement2>().xGiraffe == true)
                    {
                        PlayerPrefs.SetFloat("xScore", gameTime);
                    }
                    else if (Giraffe.GetComponentInChildren<HeadMovement2>().yGiraffe == true)
                    {
                        PlayerPrefs.SetFloat("yScore", gameTime);
                    }
                }
            }

            if (isFinished == true && otherGiraffeTracker.GetComponent<PlayerProgress>().isFinished == false)
            {
                winner = true;
                //Giraffe.GetComponent<Animator>().SetBool("IsWinner", true);
                Invoke("SetBoolWinner", 1.5f);
            }
            if (winner == true)
            {
                position.sprite = first;
                resultText.text = "WINNER";
            }
            if (otherGiraffeTracker.GetComponent<PlayerProgress>().winner == true)
            {
                position.sprite = second;
            }
            if (isFinished == true && winner == false)
            {
                resultText.text = "SECOND WINNER";
                Giraffe.GetComponent<Animator>().SetBool("IsLoser", true);
            }
        }
    }

    public void ChangePosSprite()
    {
        position.sprite = second;
    }

    public void SetBoolWinner()
    {
        Giraffe.GetComponent<Animator>().SetBool("IsWinner", true);
    }
}
