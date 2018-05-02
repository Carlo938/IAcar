using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Action/TurnDx")]
public class TurnToDx : Action
{
    public override void Act(StateController controller)
    {
        TurnAround(controller);
    }

    public void TurnAround(StateController controller)
    {
        controller.transform.Rotate(controller.transform.up, controller.carStats.angleRotation * controller.carStats.rotSpeed * Time.deltaTime);
        controller.rb.AddTorque(Vector3.up * controller.carStats.angleRotation * controller.carStats.rotSpeed * Time.deltaTime);
    }
}
