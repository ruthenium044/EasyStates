using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyObject : MonoBehaviour
{
    List<State> states = new List<State>();
    private State currentState;
    
    private DrawShape drawShape;
    
    private float t;
    public float dt;
    
    void Awake()
    {
        states.Add(GetComponent<MovementState>());
        states.Add(GetComponent<RotationState>());
        currentState = states[0];
        
        drawShape = GetComponent<DrawShape>();
    }

    private void Start()
    {
        drawShape.InitializeObjects();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentState = states[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentState = states[1];
        }
        
        currentState.UpdateState();
        t += dt;
        drawShape.UpdateSphere(t);
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 70, 150, 50), "State 1"))
        {
            currentState = states[0];
        }

        if (GUI.Button(new Rect(170, 70, 150, 50), "State 2"))
        {
            currentState = states[1];
        }
    }
}
