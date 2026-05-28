using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public Transform targetTransform; //follow traget
    private Vector3 cameraFollowVelocity = Vector3.zero;

    public float FollowSpeed=0.2f;
     
    private void Awake()
    {
        targetTransform = Object.FindObjectOfType<Playermanager>().transform;
    }

    public void followTarget()
    {
        Vector3 targetposition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, FollowSpeed);
        transform.position = targetposition;
    }
}
