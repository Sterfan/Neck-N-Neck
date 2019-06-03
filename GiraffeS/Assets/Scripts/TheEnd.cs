using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour
{
    public bool singlePlayer;

    public FinishLine finishline1;
    public FinishLine finishline2;

    bool started;
    void Update()
    {
        if (!singlePlayer)
        {
            if (!started && finishline1.GetEndOfRace && finishline2.GetEndOfRace)
                GetComponent<FadeOut>().StartCoroutine("fadeOut");
        }
        else if(!started && finishline1.GetEndOfRace || finishline2.GetEndOfRace)
            GetComponent<FadeOut>().StartCoroutine("fadeOut");
    }

    public bool HasStarted { set { started = value; } }
}
