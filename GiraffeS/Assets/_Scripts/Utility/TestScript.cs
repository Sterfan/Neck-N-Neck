﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log(gameObject.GetComponent<Renderer>().bounds.size.x);
    }
}
