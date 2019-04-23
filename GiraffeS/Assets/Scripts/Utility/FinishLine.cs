using UnityEngine;

public class FinishLine : MonoBehaviour
{
    GameObject backgroundScrl;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Giraffe"))
        {
            backgroundScrl = collision.gameObject;
            Debug.Log("We all up in this bitch");
            gameObject.GetComponentInParent<BackgroundScroller>().enabled = false;
        }
    }
}
