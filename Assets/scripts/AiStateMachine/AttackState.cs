using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateInterface<ZombieMachine>
{

    static readonly AttackState instance = new AttackState();
    public static AttackState Instance
    {
        get
        {
            return instance;
        }
    }
    public override void Enter(ZombieMachine entity)
    {
        entity.agent.velocity = new Vector3(0,0,0);
        entity.Zombie.Move(Vector3.zero, false);
        entity.Zombie.Anim.SetBool("attack", true);
    }
    public override void Execute(ZombieMachine entity)
    {
        float dist = Vector3.Distance(entity.Target, entity.transform.position);

        if (dist > 2f)
        {
            entity.ChangeState(ChaseState.Instance);
        }
    }
    public override void Exit(ZombieMachine entity)
    {
        entity.Zombie.Anim.SetBool("attack", false);
    }
}
