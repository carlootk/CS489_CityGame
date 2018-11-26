using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action
{
    public override void Act(StateController controller)
    {
        Patrol(controller);
    }

    private void Patrol(StateController controller)
    {
        controller.navMeshAgent.stoppingDistance = 0;
        RaycastHit hit;

        if (Physics.SphereCast(controller.groundEyes[Random.Range(0, controller.groundEyes.Length - 1)].position, controller.enemyStats.lookSphereCastRadius, controller.groundEyes[Random.Range(0, controller.groundEyes.Length - 1)].forward, out hit, controller.enemyStats.lookRange)
            && hit.collider.CompareTag("FloorTile")
            && hit.collider.GetComponent<Renderer>().sharedMaterial != controller.GetComponent<EnemyMovementAnimation>().tankMaterial)
        {
            controller.navMeshAgent.destination = hit.transform.position;
        }
        //else if (Physics.SphereCast(controller.groundEyes[1].position, controller.enemyStats.lookSphereCastRadius, controller.groundEyes[1].forward, out hit, controller.enemyStats.lookRange)
        //  && hit.collider.CompareTag("FloorTile")
        //  && hit.collider.GetComponent<Renderer>().sharedMaterial != controller.GetComponent<EnemyMovementAnimation>().tankMaterial)
        //{
        //    controller.navMeshAgent.destination = hit.transform.position;
        //}
        //else if (Physics.SphereCast(controller.groundEyes[2].position, controller.enemyStats.lookSphereCastRadius, controller.groundEyes[2].forward, out hit, controller.enemyStats.lookRange)
        //  && hit.collider.CompareTag("FloorTile")
        //  && hit.collider.GetComponent<Renderer>().sharedMaterial != controller.GetComponent<EnemyMovementAnimation>().tankMaterial)
        //{
        //    controller.navMeshAgent.destination = hit.transform.position;
        //}
        //else if (Physics.SphereCast(controller.groundEyes[3].position, controller.enemyStats.lookSphereCastRadius, controller.groundEyes[3].forward, out hit, controller.enemyStats.lookRange)
        //   && hit.collider.CompareTag("FloorTile")
        //   && hit.collider.GetComponent<Renderer>().sharedMaterial != controller.GetComponent<EnemyMovementAnimation>().tankMaterial)
        //{
        //    controller.navMeshAgent.destination = hit.transform.position;
        //}
        //else if (Physics.SphereCast(controller.groundEyes[4].position, controller.enemyStats.lookSphereCastRadius, controller.groundEyes[4].forward, out hit, controller.enemyStats.lookRange)
        //    && hit.collider.CompareTag("FloorTile")
        //    && hit.collider.GetComponent<Renderer>().sharedMaterial != controller.GetComponent<EnemyMovementAnimation>().tankMaterial)
        //{
        //    controller.navMeshAgent.destination = hit.transform.position;
        //}
        //else if (Physics.SphereCast(controller.groundEyes[5].position, controller.enemyStats.lookSphereCastRadius, controller.groundEyes[5].forward, out hit, controller.enemyStats.lookRange)
        //    && hit.collider.CompareTag("FloorTile")
        //    && hit.collider.GetComponent<Renderer>().sharedMaterial != controller.GetComponent<EnemyMovementAnimation>().tankMaterial)
        //{
        //    controller.navMeshAgent.destination = hit.transform.position;
        //}
        //else if (Physics.SphereCast(controller.groundEyes[6].position, controller.enemyStats.lookSphereCastRadius, controller.groundEyes[6].forward, out hit, controller.enemyStats.lookRange)
        //    && hit.collider.CompareTag("FloorTile")
        //    && hit.collider.GetComponent<Renderer>().sharedMaterial != controller.GetComponent<EnemyMovementAnimation>().tankMaterial)
        //{
        //    controller.navMeshAgent.destination = hit.transform.position;
        //}
        //else if (Physics.SphereCast(controller.groundEyes[7].position, controller.enemyStats.lookSphereCastRadius, controller.groundEyes[7].forward, out hit, controller.enemyStats.lookRange)
        //    && hit.collider.CompareTag("FloorTile")
        //    && hit.collider.GetComponent<Renderer>().sharedMaterial != controller.GetComponent<EnemyMovementAnimation>().tankMaterial)
        //{
        //    controller.navMeshAgent.destination = hit.transform.position;
        //}
        else
        {
            controller.navMeshAgent.destination = controller.wayPointList[Random.Range(0, controller.wayPointList.Count - 1)].position;
        }

        //foreach (Transform eye in controller.groundEyes)
        //{
        //    Debug.DrawRay(eye.position, eye.forward.normalized * controller.enemyStats.lookRange, Color.green);
        //    if (Physics.SphereCast(eye.position, controller.enemyStats.lookSphereCastRadius, eye.forward, out hit, controller.enemyStats.lookRange)
        //        && hit.collider.CompareTag("FloorTile")
        //        && hit.collider.GetComponent<Renderer>().sharedMaterial != controller.GetComponent<EnemyMovementAnimation>().tankMaterial)
        //    {
        //        Debug.Log("Roomba");
        //        controller.navMeshAgent.destination = hit.transform.position;
        //    }
        //    else
        //    {
        //        controller.stopped = true;
        //    }

        //}

        //if (controller.stopped)
        //{
        //    Debug.Log("Static");

        //    controller.navMeshAgent.destination = controller.wayPointList[controller.nextWayPoint].position;
        //    controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
        //    controller.stopped = false;
        //}

        //controller.navMeshAgent.destination = controller.wayPointList[controller.nextWayPoint].position;
        //controller.navMeshAgent.isStopped = false;

        //if (controller.navMeshAgent.remainingDistance < controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending)
        //{
        //    controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
        //}
    }
}
