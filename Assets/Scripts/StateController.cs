﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Complete;

public class StateController : MonoBehaviour
{


    public EnemyStats enemyStats;
    public Transform eyes;
    public State currentState;
    public State remainState;

    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public Complete.TankShooting tankShooting;
    public List<Transform> wayPointList;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;

    private bool aiActive;


    void Awake()
    {
        tankShooting = GetComponent<Complete.TankShooting>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void SetupAI(bool aiActivationFromTankManager, List<Transform> wayPointsFromTankManager)
    {
        aiActive = true;
        if (aiActive)
        {
            navMeshAgent.enabled = true;
        }
        else
        {
            navMeshAgent.enabled = false;
        }
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    private void OnDrawGizmos()
    {
        if (currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(eyes.position, enemyStats.lookSphereCastRadius);
        }
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }

}