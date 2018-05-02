using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="PluggableAI/Stats")]
public class CarStats : ScriptableObject
{
    public float speed;
    public float rotSpeed;
    public float angleRotation;
    public float accelerationMax;
    public float decelerationMax;
    public float acceleration;
    public float deceleration;
    public float rayCastDxSxLength;
    public float rayCastDxSxAngle;
    public float rayCastCenterLength;
    public float radius;
    public List<State> listState = new List<State>();
    public Dictionary<string, State> stateDictionary = new Dictionary<string, State>();

    private void OnEnable()
    {
        for(int i =0;i< listState.Count; i++)
        {
            stateDictionary.Add(listState[i].name, listState[i]);
        }
    }
}
