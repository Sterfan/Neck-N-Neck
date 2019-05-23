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
    float startOffset;
    float currentOffset;
    [SerializeField] bool isCamera;
    bool speedChanged = false;


    private void Start()
    {
        if (isCamera)
        {
            float CamX = gameObject.transform.position.x;
            float GrffX = Giraffe.transform.position.x;
            startOffset = CamX - GrffX;
        }
    }

    private void Update()
    {
        float CamX = gameObject.transform.position.x;
        float GrffX = Giraffe.transform.position.x;
        currentOffset = CamX - GrffX;
        if (isCamera == true)
        {
            if (Giraffe.GetComponent<PlayerController>().GetPlayerState() == PlayerController.PlayerStates.Dashing)
            {
                speed = 10.0f;
            }
            if (Giraffe.GetComponent<PlayerController>().GetPlayerState() != PlayerController.PlayerStates.Dashing)
            {
                if (startOffset > currentOffset)
                {
                    if (currentOffset <= 10.0f)
                    {
                        speed += 0.3f;
                    }
                    if (currentOffset > 10.0f && speed > 14.0f)
                    {
                        speed -= 0.3f;
                    }
                }
                else
                {
                    speed = SpeedController.GetComponent<MainSpeed>().GetSpeed();
                }
                //Invoke("MakeSpeed", 0.5f);
            }
            //else
            //{
            //    speed = SpeedController.GetComponent<MainSpeed>().GetSpeed();
            //}
        }
        //if (isCamera == true/*&& speedChanged == true*/)
        //{
        //    if (Giraffe.GetComponent<PlayerController>().GetPlayerState() != PlayerController.PlayerStates.Dashing)
        //    {
        //        if (startOffset > (CamX - GrffX))
        //        {
        //            speed = 35.0f;
        //        }
        //    }
        //}
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
        //if (isCamera)
        //{
        //    Debug.Log(speed);

        //}
    
        // transform.Translate(Vector2.right * Time.deltaTime * 30);

    }

    //void CatchUp()
    //{
    //    speed = 35.0f;
    //}

    void MakeSpeed()
    {
        //speed = SpeedController.GetComponent<MainSpeed>().GetSpeed();
        speedChanged = true;
    }

    void SetSpeed(float x)
    {
            speed = x;
    }
}