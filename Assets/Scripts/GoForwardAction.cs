using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Action/GoForward")]
public class GoForwardAction : Action
{
    public override void Act(StateController controller)
    {
        GoForward(controller);
    }

    public void GoForward(StateController controller)
    {
        controller.rb.AddForce(controller.transform.forward * controller.carStats.speed * controller.carStats.acceleration ,ForceMode.Acceleration);
    }
}
