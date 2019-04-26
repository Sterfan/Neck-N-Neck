using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject groundPoint;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, groundPoint.transform.position.y, transform.position.z);
    }
}
