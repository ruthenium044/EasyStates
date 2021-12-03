using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyObject : MonoBehaviour
{
    private StatesManager statesManager;
    private DrawShape drawShape;
    
    private float t;
    [HideInInspector] public float dt;
    
    void Awake()
    {
        statesManager = GetComponent<StatesManager>().
                        AddState(GetComponent<MovementState>()).
                        AddState(GetComponent<RotationState>()).
                        AddState(GetComponent<RotationBackState>()).
                        AddState(GetComponent<ColorState>());
        
        drawShape = GetComponent<DrawShape>();
    }

    private void Start()
    {
        statesManager.SetStartState(0);
        drawShape.InitializeObjects();
    }
    
    void Update()
    {
        statesManager.UpdateState();
        t += dt;
        drawShape.UpdateSphere(t);
    }
    
}
