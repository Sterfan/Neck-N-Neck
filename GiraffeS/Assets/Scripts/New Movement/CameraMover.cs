using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public GameObject CountdownTimer;
    public GameObject SpeedController;
    public GameObject Backgrounds;
    [SerializeField]float speed;
    float speedMultiplier;

    private void Update()
    {
        speed = SpeedController.GetComponent<MainSpeed>().GetSpeed();
        speedMultiplier = Backgrounds.GetComponent<BGSpeedMultiplier>().GetSpeedMultiplier();
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