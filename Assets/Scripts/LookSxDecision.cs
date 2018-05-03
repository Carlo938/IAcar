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

        Vector3 sideSensorPos = new Vector3(0, 0, 1f);
        Vector3 LeftStartPos = controller.transform.position;
        LeftStartPos -= controller.transform.right * sideSensorPos.z;

        Quaternion negrot = Quaternion.AngleAxis(-controller.carStats.rayCastDxSxAngle, controller.transform.up.normalized);

        Debug.DrawRay(LeftStartPos, controller.transform.forward * controller.carStats.rayCastCenterLength, Color.green);
        Debug.DrawRay(LeftStartPos, negrot * controller.transform.forward * controller.carStats.rayCastDxSxLength, Color.green);


        if (Physics.Raycast(controller.transform.position, negrot * controller.transform.forward, out hit, controller.carStats.rayCastDxSxLength) || Physics.Raycast(LeftStartPos, controller.transform.forward, out hit, controller.carStats.rayCastDxSxLength))
        {
            if (hit.collider.tag.StartsWith("Wall") || hit.collider.tag.StartsWith("Enemy"))
            {
                return 0;
            }
            

        }

        return 1;

    }
}
