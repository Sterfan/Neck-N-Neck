using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public GameObject CountdownTimer;
    public GameObject SpeedController;
    [SerializeField]float speed;
    float speedMultiplier;

    private void Update()
    {
        speedMultiplier = SpeedController.GetComponent<BGSpeedMultiplier>().GetSpeedMultiplier();
    }

    void LateUpdate()
    {
        if (CountdownTimer.GetComponent<CountdownTimer>().startGame == true)
            transform.position += Vector3.right * Time.deltaTime * speed * speedMultiplier;
        // transform.Translate(Vector2.right * Time.deltaTime * 30);

    }


    void SetSpeed(float x)
    {
        speed = x;
    }
}
