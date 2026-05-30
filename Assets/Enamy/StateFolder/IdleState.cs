using UnityEngine;

public class IdleState : State
{  public ChaseState chaseState;
    public bool canseePlayer;

    public override State RunCurrentState()
    {
        if (canseePlayer)
        {
            return chaseState;
        }
        else
        {

            return this;
        }
    }

}
