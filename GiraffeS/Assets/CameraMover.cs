using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public GameObject CountdownTimer;
    public float speed = 0.1f;    
    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (CountdownTimer.GetComponent<CountdownTimer>().startGame == true)
            transform.position += Vector3.right * Time.deltaTime * speed;
        // transform.Translate(Vector2.right * Time.deltaTime * 30);

    }
}
