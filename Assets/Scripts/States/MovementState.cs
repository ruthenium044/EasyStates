using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : MonoBehaviour, State
{
    private JellyObject jellyObject;
    private Movement movement;

    private void Awake()
    {
        jellyObject = GetComponent<JellyObject>();
        movement = GetComponent<Movement>();
    }

    public void UpdateState()
    {
        jellyObject.dt = 0;
        movement.MoveObject(Time.deltaTime);
    }
}
