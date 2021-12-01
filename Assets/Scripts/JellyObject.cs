using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyObject : MonoBehaviour
{
    readonly List<State> states = new List<State>();
    private State currentState;
    
    private DrawShape drawShape;
    
    private float t;
    [HideInInspector] public float dt;
    
    void Awake()
    {
        states.Add(GetComponent<MovementState>());
        states.Add(GetComponent<RotationState>());
        states.Add(GetComponent<RotationBackState>());
        states.Add(GetComponent<ColorState>());
        
        drawShape = GetComponent<DrawShape>();
    }

    private void Start()
    {
        SetStartState(0);
        drawShape.InitializeObjects();
    }
    
    void Update()
    {
        currentState.UpdateState();
        t += dt;
        drawShape.UpdateSphere(t);
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 70, 150, 50), "State 1"))
        {
            SetState(0);
        }

        if (GUI.Button(new Rect(170, 70, 150, 50), "State 2"))
        {
            SetState(1);
        }
        
        if (GUI.Button(new Rect(330, 70, 150, 50), "State 3"))
        {
            SetState(2);
        }
        
        if (GUI.Button(new Rect(490, 70, 150, 50), "State 4"))
        {
            SetState(3);
        }
    }

    private void SetStartState(int index)
    {
        currentState = states[index];
        currentState.EnterState();
    }
    
    private void SetState(int index)
    {
        if (currentState != states[index])
        {
            currentState.ExitState();
            currentState = states[index];
            currentState.EnterState();
        }
    }
    
}
