using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public GameObject grff;
    void Update()
    {
        //Debug.Log("E dis graff ie posshan " + grff.transform.position.x + " = " + transform.position.x);
        transform.position = new Vector2(grff.transform.position.x, transform.position.y);
        //Debug.Log(transform.position.x);
    }
}
