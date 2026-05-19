using UnityEngine;

public class PlayerLocomotion : MonoBehaviour


{
    ImputManager inputManager;

    Vector3 moveDirecton;
    Transform CameraObject;
    Rigidbody playerRigidBody;

    public float movementSpeed = 7;
    public float RotationSpeed = 15;


    private void Awake()
    {
        inputManager=GetComponent<ImputManager>();
        playerRigidBody=GetComponent<Rigidbody>();
        CameraObject = Camera.main.transform;
    }


    public void HandleAllMovement()
    {
        HandleMovement();
        rotation();
    }

    private void HandleMovement()
    {

        moveDirecton = CameraObject.forward * inputManager.verticalInput;
        moveDirecton= moveDirecton+ CameraObject.right * inputManager.horizontalInput;
        moveDirecton.Normalize();
        moveDirecton.y = 0;
        moveDirecton = moveDirecton * movementSpeed;

        Vector2 movementVelocity = moveDirecton;
        playerRigidBody.linearVelocity=movementVelocity;

    }
    private void rotation() //get rotated idiot
    
    {
        Vector3 targetDirection = Vector3.zero;

        targetDirection=CameraObject.forward * inputManager.verticalInput;
        targetDirection = targetDirection+CameraObject.right * inputManager.horizontalInput; targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
            targetDirection = transform.forward;




        Quaternion targetRotaton = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotaton, RotationSpeed* Time.deltaTime);
        
        transform.rotation = playerRotation;
    }



}
