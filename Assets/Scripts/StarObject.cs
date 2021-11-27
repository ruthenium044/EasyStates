using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarObject : MonoBehaviour
{
    List<State> states = new List<State>();
    private State currentState;
    
    private Movement movement;
    private Rotation rotation;
    
    void Awake()
    {
        states.Add(GetComponent<RotationState>());
        states.Add(GetComponent<MovementState>());
        currentState = states[0];
        
        movement = GetComponent<Movement>();
        rotation = GetComponent<Rotation>();
    }

    private void Start()
    {
        rotation.RotateRandom();
    }

    void Update()
    {
        movement.MoveObject();
    }

    State GetState(int i)
    {
        return states[i];
    }
}
