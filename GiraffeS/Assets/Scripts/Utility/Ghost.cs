using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Transform grff;
    public bool leaves = false;

    float grffYOrigin;
    float shadowYOrigin;
    float cameraXOrigin;
    float leavesXOrigin;

    private void Awake()
    {
        grffYOrigin = grff.position.y;
        shadowYOrigin = transform.position.y;
        cameraXOrigin = grff.position.x;
        leavesXOrigin = transform.position.x;
    }

    void FixedUpdate()
    {
        if(leaves)
            transform.position = new Vector2(LeavesX(), ShadowY());
        else
            transform.position = new Vector2(grff.position.x, ShadowY());
    }

    float ShadowY()
    {
        float difference = grffYOrigin - grff.position.y;
        return shadowYOrigin - difference;
    }

    float LeavesX()
    {
        float difference = cameraXOrigin - grff.position.x;
        return leavesXOrigin - difference;
    }
}
