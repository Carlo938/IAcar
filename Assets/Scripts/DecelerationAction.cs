using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Action/Deceleration")]
public class DecelerationAction : Action
{
    public override void Act(StateController controller)
    {
        Deceleration(controller);
    }

    private void Deceleration(StateController controller)
    {
        if (controller.carStats.acceleration > controller.carStats.decelerationMax)
        {
            controller.carStats.deceleration += Time.deltaTime; 
            controller.rb.AddForce(-controller.transform.forward * controller.carStats.deceleration, ForceMode.Acceleration);
        }
        if (controller.carStats.deceleration >= controller.carStats.decelerationMax)
        {
            controller.carStats.deceleration = controller.carStats.decelerationMax;
        }

    }


}
