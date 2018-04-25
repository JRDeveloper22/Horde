﻿using System;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof(HumaniodMovement))]
public class ZombieMachine :MonoBehaviour {
    //navMesh//
    public UnityEngine.AI.NavMeshAgent agent { get; private set; }
    public HumaniodMovement Zombie { get; private set; }
    //SearchVariables//
    float cooldown;
    float radius = 10;
    public float fieldOfViewAngle = 110f;
    //target//
    //public Transform Player;
    public Vector3 Target;
    private StateMachine<ZombieMachine> myMachine;
    [HideInInspector]
    public Player PlayerInfo;
    Animation Anim;
    void Awake()
    {
        PlayerInfo = FindObjectOfType<Player>();
        //navmesh Setup//
        agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updatePosition = true;
        //movement
        Zombie = GetComponent<HumaniodMovement>();
        //StateMachine Setup//
        myMachine = new StateMachine<ZombieMachine>();
        myMachine.Configure(this, SearchState.Instance);
        //Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    //StateMachine Specific////////////////
    public void ChangeState(StateInterface<ZombieMachine> e)
    {
        myMachine.ChangeState(e);
    }
    public void RevertState()
    {
        myMachine.RevertToPreviousState();
    }
    void Update()
    {
        myMachine.Update();
    }
    //////////// Target ///////////////////
    public Vector3 SetTarget(Vector3 T)
    {
        return this.Target = T;
    }
    public void SearchPosition()
    {
        cooldown -= Time.deltaTime;
        if (cooldown < 0)
        {
            cooldown += UnityEngine.Random.Range(3, 5);
            SetTarget(new Vector3((transform.position.x + UnityEngine.Random.Range(-radius, radius)),
                   0, transform.position.z + UnityEngine.Random.Range(-radius, radius)));
        }
    }
    public void Movement()
    {
        if (Target != null)
        {
            agent.SetDestination(Target);
        }
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            if (agent.isOnOffMeshLink == true)
            {
                Zombie.Anim.SetBool("jump", true);
            }
            else Zombie.Anim.SetBool("jump", false);


            //set animation speed   anim["example"].speed= -1.0f; //
            Zombie.Move(agent.desiredVelocity, false);
            Zombie.Anim.SetFloat("move", agent.velocity.magnitude);
        }
        else
            Zombie.Move(Vector3.zero, false);
    }
}
