using UnityEngine;

public class CameraController : MonoBehaviour
{
    //public GameObject groundPoint;
    public float desiredGroundDistance;
    public Transform giraffe;

    public float smoothSpeed = 0.125f;
    public float raycastMaxDistance = 50f;
    [SerializeField]
    private LayerMask layersToHit;
    float rayDistanceFromCameraC;
    float rayPointY;

    private Vector2 direction;
    private Vector2 startingPosition;

    void FixedUpdate()
    {
        GetRayInfo();
        Vector3 desiredPosition = new Vector3(transform.position.x, rayPointY + desiredGroundDistance, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    private RaycastHit2D GroundLevel()
    {
        direction = new Vector2(0, -1);
        startingPosition = new Vector2(giraffe.position.x, transform.position.y);

        Debug.DrawRay(startingPosition, direction, Color.red, 3f);
        return Physics2D.Raycast(startingPosition, direction, raycastMaxDistance, layersToHit);
    }

    private void GetRayInfo()
    {
        RaycastHit2D hit = GroundLevel();

        if (!hit.collider)
            Debug.LogError("The ray did not hit any GameObject in the \'Ground\' Layer.");

        rayDistanceFromCameraC = hit.distance;
        rayPointY = hit.point.y;
        Debug.Log("The ray hit at: " + hit.collider.name);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(startingPosition, direction);
    }
}
