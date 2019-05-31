using UnityEngine;
using System.Collections;

public class ExitBufferSceneorsomeshtlikethat : MonoBehaviour
{
    bool started;

    public bool HasStarted { set { started = value; } }
    void Update()
    {
        StartCoroutine("SuckMyAss");
    }

    IEnumerator SuckMyAss()
    {
        yield return new WaitForSeconds(10);
        GetComponent<FadeOut>().StartCoroutine("fadeOut");
    }

}
