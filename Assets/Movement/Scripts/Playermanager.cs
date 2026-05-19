using UnityEngine;

public class Playermanager : MonoBehaviour


{

    ImputManager imputManager;
    PlayerLocomotion locomotion;

    private void Awake()
    {
        imputManager=GetComponent<ImputManager>();
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
}
