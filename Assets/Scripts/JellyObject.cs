using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyObject : MonoBehaviour
{
    private StatesManager statesManager;
    private IState currentState;
    
    private DrawShape drawShape;
    
    private float t;
    [HideInInspector] public float dt;
    
    void Awake()
    {
        statesManager = GetComponent<StatesManager>();
        statesManager.AddState(GetComponent<MovementState>()).AddState(GetComponent<RotationState>()).AddState(GetComponent<RotationBackState>()).AddState(GetComponent<ColorState>());
        
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
        currentState = statesManager.GetState(index);      
        currentState.EnterState();
    }
    
    private void SetState(int index)
    {
        if (currentState != statesManager.GetState(index))
        {
            currentState.ExitState();
            currentState = statesManager.GetState(index);
            currentState.EnterState();
        }
    }
    
}
