using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    ImputManager imputManager;
    public Transform targetTransform; //follow traget
    public Transform cameraPivot;
    public Transform cameraTransform;
    private Vector3 cameraFollowVelocity = Vector3.zero;
    private Vector3 cameraVectorPosition;


    public float cameraCollisonsOffSet = 0.2f;
    public float minimimumCollisonsOffSet = 0.2f;
    public float cameraCollisonsRadius= 0.2f ;
    private float defaultPosition;
    public LayerMask collisionLayers;
    public float FollowSpeed=0.2f;
    public float cameraLookspeed=2;
    public float cameraPivotSpeed = 2;


    public float lookAngle;
    public float pivotAngle;
    public float minimimumPivotAngle = -35;
    public float maximimumPivotAngle= 35;

    private void Awake()
    {

        imputManager= FindObjectOfType<ImputManager>();
        targetTransform = Object.FindObjectOfType<Playermanager>().transform;
        cameraTransform= Camera.main.transform;
        defaultPosition = cameraTransform.localPosition.z;
    }
    public void HandleCamera()
    {
        followTarget();
        RotateCamera();
        HandleCameraCollisions();
    }
    private void followTarget()
    {
        Vector3 targetposition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, FollowSpeed);
        transform.position = targetposition;
    }


    private void RotateCamera()
    { Vector3 rotation;

        Quaternion targetRotation;


        lookAngle = lookAngle + (imputManager.cameraInputX * cameraLookspeed);
        pivotAngle = pivotAngle - (imputManager.cameraInputY * cameraPivotSpeed);
        pivotAngle=Mathf.Clamp(pivotAngle, minimimumPivotAngle, maximimumPivotAngle);

        rotation= Vector3.zero;
        rotation.y = lookAngle;
        targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        rotation=Vector3.zero;
        rotation.x = pivotAngle;

        targetRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation=targetRotation;
    }

    private void HandleCameraCollisions()
    {
        float targetPosition = defaultPosition;
        RaycastHit hit;
        Vector3 direction= cameraTransform.position- cameraPivot.position;
        direction.Normalize();


        if (Physics.SphereCast
            (cameraPivot.transform.position, cameraCollisonsRadius , direction,out hit,Mathf.Abs(targetPosition),collisionLayers))
        {
            float distance = Vector3.Distance(cameraPivot.position,hit.point);
            targetPosition = targetPosition - (distance - cameraCollisonsOffSet);

        }

        if (Mathf.Abs(targetPosition) > minimimumCollisonsOffSet)
        {
            targetPosition = targetPosition - minimimumCollisonsOffSet;
        }



        cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, 0.2f);
        cameraTransform.localPosition = cameraVectorPosition;


    }

}
