﻿using UnityEngine;
using System.Collections;

public class ExitBufferSceneorsomeshtlikethat : MonoBehaviour
{
    bool started;
    [SerializeField] float secondsToWait = 3.7f;

    public bool HasStarted { set { started = value; } }
    void Update()
    {
        StartCoroutine("SuckMyAss");
    }

    IEnumerator SuckMyAss()
    {
        yield return new WaitForSeconds(secondsToWait);
        GetComponent<FadeOut>().StartCoroutine("fadeOut");
    }

}