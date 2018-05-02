using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decision/LookDx")]
public class LookDxDecision : Decision
{
    public override int Decide(StateController controller)
    {
        int lookDecision = LookDx(controller);
        return lookDecision;
    }

    private int LookDx(StateController controller)
    {
        RaycastHit hit;

        Quaternion rot = Quaternion.AngleAxis(controller.carStats.rayCastDxSxAngle, controller.transform.up.normalized);

        Debug.DrawRay(controller.transform.position, rot * controller.transform.forward * controller.carStats.rayCastDxSxLength, Color.green);


        if (Physics.Raycast(controller.eyes.position, rot * controller.eyes.forward, out hit, controller.carStats.rayCastDxSxLength))
        {
            if (hit.collider.tag.StartsWith("Wall"))
            {
                return 0;
            }
            else if (hit.collider.tag.StartsWith("Enemy"))
            {
                return 2;
            }

        }

        return 1;
    }
}
