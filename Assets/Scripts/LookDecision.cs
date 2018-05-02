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

        Debug.DrawRay(controller.transform.position, controller.transform.forward * controller.carStats.rayCastCenterLength, Color.green);
        
        if (Physics.Raycast(controller.eyes.position, controller.eyes.forward, out hit, controller.carStats.rayCastCenterLength))
        {
            if (hit.collider.tag.StartsWith("Wall"))
            {
                return 0;
            }
            else if( hit.collider.tag.StartsWith("Enemy"))
            {
                return 2;
            }
            
        }
       

        return 1;
    }
}
