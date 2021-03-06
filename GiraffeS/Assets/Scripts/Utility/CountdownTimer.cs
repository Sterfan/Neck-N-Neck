﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float mainTimer;
    public GameObject three;
    public GameObject two;
    public GameObject one;
    public GameObject go;
    public GameObject assFlamesTop;
    public GameObject assFlamesBot;
    public GameObject GiraffeTOP;
    public GameObject GiraffeBOT;
    //public TMPro.TextMeshProUGUI text;

    public bool startGame = false;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;
    private bool hasFired = false;
    private bool hasSounded = false;
    bool threeSound = false;
    bool twoSound = false;
    bool oneSound = false;

    Vector3 startScale;

    private void Awake()
    {
        Cursor.visible = false;
    }

    private void Start()
    {
        timer = mainTimer;
        startScale = assFlamesBot.transform.localScale;
    }

    private void Update()
    {
        //Debug.Log(startGame);
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            if (timer <= 3.5f && hasSounded == false)
            {
                FindObjectOfType<AudioManager>().Play("CarRevs");
                hasSounded = true;
            }
            if (timer <= 3.0f && timer > 2.0f)
            {
                if (threeSound == false)
                {
                    FindObjectOfType<AudioManager>().Play("3");
                    threeSound = true;
                }
                //text.text = "3";
                three.SetActive(true);
                if (hasFired == false)
                {
                    Invoke("AssFire", 0.1f);
                }

            }
            if (timer > 1.0f && timer <= 2.0f)
            {
                if (twoSound == false)
                {
                    FindObjectOfType<AudioManager>().Play("2");
                    twoSound = true;
                }
                Invoke("AssFire", 0.1f);
                //three.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0, 0, 0, 0);
                three.SetActive(false);
                two.SetActive(true);

            }
            if (timer > 0.0f && timer <= 1.0f)
            {
                if (oneSound == false)
                {
                    FindObjectOfType<AudioManager>().Play("1");
                    oneSound = true;
                }
                RescaleFlames();
                //two.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0, 0, 0, 0);
                two.SetActive(false);
                one.SetActive(true);

            }
        }
        else if (timer <= 0.0f && !doOnce)
        {
            //Debug.Log("Should be true");
            FindObjectOfType<AudioManager>().Play("Go");
            startGame = true;
            GiraffeTOP.GetComponent<PlayerController>().StartGame();
            GiraffeBOT.GetComponent<PlayerController>().StartGame();
            //one.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0, 0, 0, 0);
            one.SetActive(false);
            go.SetActive(true);
            Invoke("SetGoFalse", 0.5f);
            canCount = false;
            doOnce = true;
            timer = 0.0f;
            FindObjectOfType<AudioManager>().Play("GiraffeWalk");
        }
    }

    void SetGoFalse()
    {
        //go.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(0, 0, 0, 0);
        go.SetActive(false);
    }

    public bool GetStartGame()
    {
        return startGame;
    }

    void ScaleUpFlames()
    {
        assFlamesBot.transform.localScale = new Vector3(1, 1, 1);
        assFlamesTop.transform.localScale = new Vector3(1, 1, 1);
    }

    void ScaleDownFlames()
    {
        assFlamesTop.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        assFlamesBot.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
    }

    void RescaleFlames()
    {
        assFlamesTop.transform.localScale = startScale;
        assFlamesBot.transform.localScale = startScale;
    }

    void ActivateFIRE()
    {
        assFlamesTop.SetActive(true);
        assFlamesBot.SetActive(true);
    }

    void DeactivateFIRE()
    {
        assFlamesTop.SetActive(false);
        assFlamesBot.SetActive(false);
    }

    void AssFire()
    {
        ScaleDownFlames();
        ActivateFIRE();
        Invoke("DeactivateFIRE", 0.1f);
        Invoke("ActivateFIRE", 0.15f);
        Invoke("DeactivateFIRE", 0.25f);
        Invoke("ActivateFIRE", 0.27f);
        Invoke("DeactivateFIRE", 0.32f);
        Invoke("ActivateFIRE", 0.35f);
        Invoke("RescaleFlames", 0.4f);
        Invoke("DeactivateFIRE", 0.6f);
        hasFired = true;
    }
}
