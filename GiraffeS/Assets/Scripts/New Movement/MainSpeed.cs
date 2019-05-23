using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSpeed : MonoBehaviour
{
    [SerializeField] float speed = 7.0f;


    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float x)
    {
        speed = x;
    }
}
