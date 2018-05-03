using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decision/Look")]
public class LookDecision : Decision
{
    public override int Decide(StateController controller)
    {
        int lookDecision = Look(controller);
        return lookDecision;
    }

    private int Look(StateController controller)
    {
        RaycastHit hit;
        Vector3 sideSensorPos = new Vector3(0,0, 1f);
        
        Vector3 centralStartPos = controller.transform.position;
        centralStartPos = controller.transform.position * new Vector3(0,0,1).z;

        Vector3 LeftStartPos = controller.transform.position;
        LeftStartPos -= controller.transform.right * sideSensorPos.z;

        Vector3 RightStartPos = controller.transform.position;
        RightStartPos += controller.transform.right * sideSensorPos.z;

        Debug.DrawRay(RightStartPos, controller.transform.forward * controller.carStats.rayCastCenterLength, Color.green);
        Debug.DrawRay(LeftStartPos, controller.transform.forward * controller.carStats.rayCastCenterLength, Color.green);
        Debug.DrawRay(centralStartPos, controller.transform.forward * controller.carStats.rayCastCenterLength, Color.green);
        
        if(Physics.Raycast(LeftStartPos, controller.transform.forward, out hit, controller.carStats.rayCastDxSxLength))
        {
            if (hit.collider.tag.StartsWith("Wall") || hit.collider.tag.StartsWith("Enemy"))
            {
                return 0;
            }
        }
        else if (Physics.Raycast(RightStartPos, controller.transform.forward, out hit, controller.carStats.rayCastDxSxLength))
        {
            if (hit.collider.tag.StartsWith("Wall") || hit.collider.tag.StartsWith("Enemy"))
            {
                return 1;
            }
        }
        else if (Physics.Raycast(controller.transform.position, controller.transform.forward, out hit, controller.carStats.rayCastCenterLength) && Physics.Raycast(RightStartPos, controller.transform.forward, out hit, controller.carStats.rayCastDxSxLength) && Physics.Raycast(LeftStartPos, controller.transform.forward, out hit, controller.carStats.rayCastDxSxLength))
        {
            if (hit.collider.tag.StartsWith("Wall"))
            {
                if (hit.normal.x < -0.1f)
                {
                    return 0;
                }
                else if (hit.normal.x > 0.1f)
                {
                    return 1;
                }
            }
            
        }

        return 2;
    }
}
