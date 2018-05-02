using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decision/LookDx")]
public class LookDxDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool lookDecision = LookDx(controller);
        return lookDecision;
    }

    private bool LookDx(StateController controller)
    {
        RaycastHit hit;

        Quaternion rot = Quaternion.AngleAxis(controller.carStats.rayCastDxSxAngle, controller.transform.up.normalized);

        Debug.DrawRay(controller.transform.position, rot * controller.transform.forward * controller.carStats.rayCastDxSxLength, Color.green);


        if (Physics.Raycast(controller.eyes.position, rot * controller.eyes.forward, out hit, controller.carStats.rayCastDxSxLength))
        {
            if (hit.collider.tag.StartsWith("Wall"))
            {
                return true;
            }
        }

        return false;
    }
}
