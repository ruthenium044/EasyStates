using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Properties
{
    //kill me
}

public class StatesManager : MonoBehaviour, IState
{
    private readonly List<IState> states = new List<IState>();
    private IState currentState;
    
    public StatesManager AddState(IState state)
    {
        states.Add(state);
        return this;
    }
    
    public IState GetState(int index)
    {
        return states[index];
    }

    public void SetColor(int index, Color color)
    {
        //fucking kill me right here
        //states[index].newColor = color;
    }

    public void EnterState()
    {
        currentState.EnterState();
    }

    public void UpdateState()
    {
        currentState.UpdateState();
    }

    public void ExitState()
    {
        currentState.ExitState();
    }

    public void SetStartState(int index)
    {
        currentState = GetState(index);      
        currentState.EnterState();
    }
    
    private void SetState(int index)
    {
        if (currentState != GetState(index))
        {
            currentState.ExitState();
            currentState = GetState(index);
            currentState.EnterState();
        }
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
}
