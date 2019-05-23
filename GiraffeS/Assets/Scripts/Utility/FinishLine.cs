using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject theCamera;
    public GameObject progressTracker;
    bool endOfRace = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Giraffe"))
        {
            progressTracker.GetComponent<PlayerProgress>().isFinished = true;
            endOfRace = true;
        }
    }

    void FixedUpdate()
    {
        if (endOfRace)
        {
            theCamera.GetComponent<CameraMover>().enabled = false;
            theCamera.GetComponent<CameraController>().enabled = false;
        }
    }
}
