using UnityEngine;

public class FinishLine : MonoBehaviour
{
    GameObject backgroundScrl;
    public GameObject progressTracker;
    public GameObject giraffe;
    bool endOfRace = false;
    Vector2 newPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Giraffe"))
        {
            backgroundScrl = collision.gameObject;
            //Debug.Log("We all up in this bitch");
            gameObject.GetComponentInParent<BackgroundScroller>().scrollSpeed = 0.0f;
            progressTracker.GetComponent<PlayerProgress>().isFinished = true;
            endOfRace = true;
        }
    }

    void Start()
    {
        newPosition = giraffe.GetComponent<Rigidbody2D>().position;
    }

    void FixedUpdate()
    {
        if (endOfRace)
        {
            Debug.Log("desosdfalk?");
            newPosition = newPosition + new Vector2(0.5f, 0);
            giraffe.GetComponent<Rigidbody2D>().MovePosition(newPosition);
        }
    }
}
