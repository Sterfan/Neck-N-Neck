using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private float mainTimer;
    [SerializeField] private GameObject three;
    [SerializeField] private GameObject two;
    [SerializeField] private GameObject one;
    [SerializeField] private GameObject go;

    public bool startGame = false;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;


    private void Start()
    {
        timer = mainTimer;
    }

    private void Update()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            if (timer > 2.0f)
            {
                three.SetActive(true);
            }
            if (timer > 1.0f && timer <= 2.0f)
            {
                three.SetActive(false);
                two.SetActive(true);

            }
            if (timer > 0.0f && timer <= 1.0f)
            {
                two.SetActive(false);
                one.SetActive(true);

            }
        }
        else if (timer <= 0.0f && !doOnce)
        {
            startGame = true;
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
        go.SetActive(false);
    }
}
