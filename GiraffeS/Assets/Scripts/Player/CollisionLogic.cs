using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLogic : MonoBehaviour
{
    public GameObject Background;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Background.GetComponent<BackgroundScroller>().SetSpeed(5.0f);
        //Background.GetComponent<BackgroundScroller>().InvokeReset();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Background.GetComponent<BackgroundScroller>().SetSpeed(10.0f);
    }
}
