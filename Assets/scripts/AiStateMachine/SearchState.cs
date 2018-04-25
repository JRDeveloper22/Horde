using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : StateInterface<ZombieMachine>
{
    float cooldown;
    float radius = 10;
    Vector3 Target;
    static readonly SearchState instance = new SearchState();
    public static SearchState Instance
    {
        get
        {
            return instance;
        }
    }
    public override void Enter(ZombieMachine entity)
    {

    }
    public override void Execute(ZombieMachine entity)
    {
        entity.SearchPosition();
        entity.Movement();
        entity.agent.speed = 1;
        if(entity.PlayerInfo.clicked == true)
        {
            entity.ChangeState(ChaseState.Instance);
        }
    }
    public override void Exit(ZombieMachine entity)
    {

    }
}
