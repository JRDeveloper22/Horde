using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : StateInterface<ZombieMachine>
{
    static readonly ChaseState instance = new ChaseState();
    public static ChaseState Instance
    {
        get
        {
            return instance;
        }
    }

    public override void Enter(ZombieMachine entity)
    {
        if (entity.Target == null)
        {
            entity.ChangeState(SearchState.Instance);
        }
    }
    public override void Execute(ZombieMachine entity)
    {
        entity.SetTarget(entity.PlayerInfo.hitInfo);

        entity.agent.speed = 10;
        entity.Movement();
        if (!entity.agent.pathPending)
        {
            if (entity.agent.remainingDistance <= entity.agent.stoppingDistance)
            {
                if (!entity.agent.hasPath || entity.agent.velocity.sqrMagnitude == 0f)
                {
                    entity.ChangeState(SearchState.Instance);
                }
            }
        }
    }
    public override void Exit(ZombieMachine entity)
    {

    }
}
