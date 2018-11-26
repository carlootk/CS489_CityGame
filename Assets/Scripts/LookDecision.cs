using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : Decision
{

    public override bool Decide(StateController controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;
    }

    private bool Look(StateController controller)
    {
        RaycastHit hit;

        foreach (Transform eye in controller.eyes)
        {
            Debug.DrawRay(eye.position, eye.forward.normalized * controller.enemyStats.lookRange, Color.green);

            if (Physics.SphereCast(eye.position, controller.enemyStats.lookSphereCastRadius, eye.forward, out hit, controller.enemyStats.lookRange) && hit.collider.CompareTag("Player"))
            {
                controller.chaseTarget = hit.transform;
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;

        
    }

}
