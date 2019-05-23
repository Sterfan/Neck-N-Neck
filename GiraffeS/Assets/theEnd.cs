using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class theEnd : MonoBehaviour
{
    public FinishLine finishline1;
    public FinishLine finishline2;
    public Image backInBlack;

    bool started;
    void Update()
    {
        if (!started && finishline1.GetEndOfRace && finishline2.GetEndOfRace)
            StartCoroutine("TheEnd");
    }

    IEnumerator TheEnd()
    {
        yield return new WaitForSeconds(4f);
        while (true)
        {
            backInBlack.color += new Color(0f, 0f, 0f, 0.001f);
            yield return null;
            if (backInBlack.color.a >= 1f)
            {
                SceneManager.LoadScene("Leaderboard");
                break;
            }
        }
    }
}
