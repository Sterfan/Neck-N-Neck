using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCenterer : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("hi");
        }
    }
}
