using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float speed = 0.1f;    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
        // transform.Translate(Vector2.right * Time.deltaTime * 30);

    }
}
