using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyObject : MonoBehaviour
{
    private StatesManager statesManager;
    private DrawShape drawShape;

    private ICommand[] stateCommands = new ICommand[4];
    private ICommand[] poolCommands = new ICommand[4];
    
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

        stateCommands[0] = new SetStateCommand(statesManager, 0);
        stateCommands[1] = new SetStateCommand(statesManager, 1);
        stateCommands[2] = new SetStateCommand(statesManager, 2);
        stateCommands[3] = new SetStateCommand(statesManager, 3);
        
        poolCommands[0] = new PoolActivateCommand(drawShape, 100);
        poolCommands[1] = new PoolActivateCommand(drawShape, 1000);
        poolCommands[2] = new PoolDeactivateCommand(drawShape, 100);
        poolCommands[3] = new PoolDeactivateCommand(drawShape, 1000);
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

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 70, 150, 50), "State 1"))
        {
            stateCommands[0].Execute();
        }

        if (GUI.Button(new Rect(170, 70, 150, 50), "State 2"))
        {
            stateCommands[1].Execute();
        }
        
        if (GUI.Button(new Rect(330, 70, 150, 50), "State 3"))
        {
            stateCommands[2].Execute();
        }
        
        if (GUI.Button(new Rect(490, 70, 150, 50), "State 4"))
        {
            stateCommands[3].Execute();
        }
        
        if (GUI.Button(new Rect(10, 10, 150, 50), "Activate 100 object"))
        {
            poolCommands[0].Execute();
        }
        
        if (GUI.Button(new Rect(170, 10, 150, 50), "Activate 1000 objects"))
        {
            poolCommands[1].Execute();
        }
    
        if (GUI.Button(new Rect(330, 10, 150, 50), "Deactivate 100 object"))
        {
            poolCommands[2].Execute();
        }
        
        if (GUI.Button(new Rect(490, 10, 150, 50), "Deactivate 1000 objects"))
        {
            poolCommands[3].Execute();
        }
    }
}
