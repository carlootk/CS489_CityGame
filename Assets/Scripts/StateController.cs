using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Complete;

public class StateController : MonoBehaviour
{


    public EnemyStats enemyStats;
    public Transform[] eyes;
    public Transform[] groundEyes;
    public Transform turret;
    public State currentState;
    public State remainState;
    public bool stopped = false;

    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public Complete.TankShooting tankShooting;
    [HideInInspector] public GunController gunTankShooting;
    public List<Transform> wayPointList;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public float stateTimeElapsed;

    private bool aiActive;


    void Awake()
    {
        tankShooting = GetComponent<Complete.TankShooting>();
        gunTankShooting = GetComponent<GunController>();
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
            foreach (Transform eye in eyes)
            {
                Gizmos.DrawWireSphere(eye.position, enemyStats.lookSphereCastRadius);
            }
            foreach (Transform eye in groundEyes)
            {
                Gizmos.DrawWireSphere(eye.position, enemyStats.lookSphereCastRadius);
            }
            
        }
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
            OnExitState();
        }
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }

}