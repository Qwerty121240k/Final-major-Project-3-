using UnityEngine;

public abstract class State : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public abstract State RunCurrentState();
}
