using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="PluggableAI/State")]
public class State : ScriptableObject
{
    public Action[] actions;
    public Transition[] transitions;
    public Color gizmosColor = Color.grey;

    public void UpdateState(StateController controller)
    {
        DoActions(controller);
        CheckTransition(controller);
    }

    private void DoActions(StateController controller)
    {
        for(int i = 0; i < actions.Length;i++)
        {
            actions[i].Act(controller);
        }
    }

    private void CheckTransition(StateController controller)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            int decisionChosen = transitions[i].decision.Decide(controller);

            controller.TransitionState(transitions[i].possibleState[decisionChosen]);

            //if (decisionSucceded)
            //{
            //    controller.TransitionState(transitions[i].);
            //}
            //else
            //{
            //    controller.TransitionState(transitions[i].falseState);
            //}
        }
    }
}
