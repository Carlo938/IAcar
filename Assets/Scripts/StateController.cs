using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{

    public State currentState;
    public Transform eyes;
    public CarStats carStats;
    public State remainState;
    public bool aiActive = true;


    [HideInInspector] public Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update ()
    {
		if(!aiActive)
        {
            return;
        }

        currentState.UpdateState(this);
	}

    private void OnDrawGizmos()
    {
        if (currentState != null && eyes != null)
        {
            Gizmos.color = currentState.gizmosColor;

            Gizmos.DrawSphere(eyes.transform.position, carStats.radius);
        }
    }

    public void TransitionState(State nextState)
    {
        if(nextState != remainState)
        {
            currentState = nextState;
        }
    }
}
