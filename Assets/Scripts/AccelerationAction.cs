using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Action/Acceleration")]
public class AccelerationAction : Action
{
    public override void Act(StateController controller)
    {
        Acceleration(controller);
    }

    private void Acceleration(StateController controller)
    {
        if(controller.carStats.acceleration < controller.carStats.accelerationMax)
        {
            controller.carStats.acceleration += Time.deltaTime;
            //controller.rb.AddForce(controller.transform.forward * controller.carStats.speed * controller.carStats.acceleration, ForceMode.Acceleration);
        }
        else if(controller.carStats.acceleration >= controller.carStats.accelerationMax)
        {
            controller.carStats.acceleration = controller.carStats.accelerationMax;
        }
        
    }


}
