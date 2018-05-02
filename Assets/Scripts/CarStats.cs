﻿using System.Collections;
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
}
