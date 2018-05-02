using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Action/TurnSx")]
public class TurnToSx : Action
{
    public override void Act(StateController controller)
    {
        TurnAround(controller);
    }

    public void TurnAround(StateController controller)
    {
        controller.transform.Rotate(controller.transform.up, -controller.carStats.angleRotation * controller.carStats.rotSpeed * Time.deltaTime);
        controller.rb.AddTorque(controller.transform.up * -controller.carStats.angleRotation * controller.carStats.rotSpeed);
    }
}
