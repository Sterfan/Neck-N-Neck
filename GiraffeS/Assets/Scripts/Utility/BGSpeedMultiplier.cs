using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpeedMultiplier : MonoBehaviour
{
    float speedMultiplier = 1.0f;

    public float GetSpeedMultiplier()
    {
        return speedMultiplier;
    }

    public void SetSpeedMultiplier(float speed)
    {
        speedMultiplier = speed;
    }
}
