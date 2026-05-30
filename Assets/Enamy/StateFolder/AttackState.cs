using UnityEngine;

public class AttackState : State
{

    public AttackState attackState;
    public bool isAttackRange;


    public override State RunCurrentState()
    {

        Debug.Log("hit");
            return this;
    }
        
}
