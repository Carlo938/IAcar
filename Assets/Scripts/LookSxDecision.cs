using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decision/LookSx")]
public class LookSxDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool lookDecision = LookSx(controller);
        return lookDecision;
    }

    private bool LookSx(StateController controller)
    {
        RaycastHit hit;

        Quaternion negrot = Quaternion.AngleAxis(-controller.carStats.rayCastDxSxAngle, controller.transform.up.normalized);

        Debug.DrawRay(controller.transform.position, negrot * controller.transform.forward * controller.carStats.rayCastDxSxLength, Color.green);


        if (Physics.Raycast(controller.eyes.position, negrot * controller.eyes.forward, out hit, controller.carStats.rayCastDxSxLength))
        {
            if (hit.collider.tag.StartsWith("Wall"))
            {
                return true;
            }
        }

        return false;

    }
}
