using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decision/LookSx")]
public class LookSxDecision : Decision
{
    public override int Decide(StateController controller)
    {
        int lookDecision = LookSx(controller);
        return lookDecision;
    }

    private int LookSx(StateController controller)
    {
        RaycastHit hit;

        Quaternion negrot = Quaternion.AngleAxis(-controller.carStats.rayCastDxSxAngle, controller.transform.up.normalized);

        Debug.DrawRay(controller.transform.position, negrot * controller.transform.forward * controller.carStats.rayCastDxSxLength, Color.green);


        if (Physics.Raycast(controller.eyes.position, negrot * controller.eyes.forward, out hit, controller.carStats.rayCastDxSxLength))
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
