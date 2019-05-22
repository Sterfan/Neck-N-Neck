using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public GameObject Giraffe;
    public GameObject CountdownTimer;
    public GameObject SpeedController;
    public GameObject Backgrounds;
    [SerializeField]float speed;
    float delayedSpeed;
    float speedMultiplier;
    [SerializeField] bool isCamera;


    private void Start()
    {
        if (isCamera)
        {
            float CamX = gameObject.transform.position.x;
            float GrffX = Giraffe.transform.position.x;
            float startOffset = CamX - GrffX;
        }
    }

    private void Update()
    {
        if (isCamera == true && Giraffe.GetComponent<PlayerController>().GetPlayerState() == PlayerController.PlayerStates.Dashing)
        {
            Invoke("MakeSpeed", 0.3f);
        }
        else
        {
            speed = SpeedController.GetComponent<MainSpeed>().GetSpeed();
        }

        speedMultiplier = Backgrounds.GetComponent<BGSpeedMultiplier>().GetSpeedMultiplier();
        //Debug.Log(CountdownTimer.GetComponent<CountdownTimer>().startGame == true);
    }

    void LateUpdate()
    {
        if (CountdownTimer.GetComponent<CountdownTimer>().startGame == true)
            transform.position += Vector3.right * Time.deltaTime * speed * speedMultiplier;
        // transform.Translate(Vector2.right * Time.deltaTime * 30);

    }

    void MakeSpeed()
    {
        speed = SpeedController.GetComponent<MainSpeed>().GetSpeed();
    }

    void SetSpeed(float x)
    {
            speed = x;
    }
}