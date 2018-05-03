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

        Vector3 sideSensorPos = new Vector3(0, 0, 1f);

        Vector3 RightStartPos = controller.transform.position;
        RightStartPos += controller.transform.right * sideSensorPos.z;

        Quaternion rot = Quaternion.AngleAxis(controller.carStats.rayCastDxSxAngle, controller.transform.up.normalized);

        Debug.DrawRay(RightStartPos, controller.transform.forward * controller.carStats.rayCastCenterLength, Color.green);
        Debug.DrawRay(RightStartPos, rot * controller.transform.forward * controller.carStats.rayCastDxSxLength, Color.green);


        if (Physics.Raycast(controller.transform.position, rot * controller.transform.forward, out hit, controller.carStats.rayCastDxSxLength) || Physics.Raycast(RightStartPos,controller.transform.forward, out hit, controller.carStats.rayCastDxSxLength))
        {
            if (hit.collider.tag.StartsWith("Wall") || hit.collider.tag.StartsWith("Enemy"))
            {
                return 0;
            }

        }

        return 1;
    }
}
