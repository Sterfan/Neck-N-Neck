using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    public Image backInBlack;
    public string nextScene;

    IEnumerator fadeOut()
    {
        HasStarted();
        if (SceneManager.GetActiveScene().name == "Axel's Scene")
            yield return new WaitForSeconds(4f);
        while (true)
        {
            backInBlack.color += new Color(0f, 0f, 0f, 0.02f);
            yield return null;
            if (backInBlack.color.a >= 1f)
            {
                SceneManager.LoadScene(nextScene);
                break;
            }
        }
    }

    void HasStarted()
    {
        if (SceneManager.GetActiveScene().name == "Axel's Scene" || SceneManager.GetActiveScene().name == "Axel's Scene Single")
            GetComponent<TheEnd>().HasStarted = true;
        if(SceneManager.GetActiveScene().name == "Leaderboard")
            GetComponent<exitLeaderboard>().HasStarted = true;
    }
}
