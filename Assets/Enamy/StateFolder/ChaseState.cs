using UnityEngine;

public class ChaseState : State
{
    public AttackState AttackState;
    public bool isAttackRange;


    public override State RunCurrentState()
    {

        if (isAttackRange)

        {
            return AttackState;
        }
        else
        {
            return this;
        }
    }

}
