using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image backInBlack;

    private void Start()
    {
        StartCoroutine("fadeIn");
    }

    IEnumerator fadeIn()
    {
        while (true)
        {
            backInBlack.color -= new Color(0f, 0f, 0f, 0.02f);
            yield return null;
            if (backInBlack.color.a <= 0f)
            {
                Destroy(this);
            }
        }
    }
}
