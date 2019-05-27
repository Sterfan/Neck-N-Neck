using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour
{
    public FinishLine finishline1;
    public FinishLine finishline2;

    bool started;
    void Update()
    {
        if (!started && finishline1.GetEndOfRace && finishline2.GetEndOfRace)
            GetComponent<FadeOut>().StartCoroutine("fadeOut");
    }

    public bool HasStarted { set { started = value; } }
}
