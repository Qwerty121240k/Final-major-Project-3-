using UnityEngine;

public class Playermanager : MonoBehaviour


{

    ImputManager imputManager;
    CameraManager cameraManager;
    PlayerLocomotion locomotion;

    private void Awake()
    {
        imputManager=GetComponent<ImputManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        locomotion=GetComponent<PlayerLocomotion>();


    }

    private void Update()
    {
        imputManager.HandleAllInputs();
    }
    private void FixedUpdate()
    {
        locomotion.HandleAllMovement();
    }
    private void LateUpdate()
    {
        cameraManager.HandleCamera();
    }
}
