using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesManager : MonoBehaviour, IState
{
    private readonly List<IState> states = new();
    private IState currentState;
    
    public StatesManager AddState(IState state)
    {
        states.Add(state);
        return this;
    }

    private IState GetState(int index)
    {
        return states[index];
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
    
    public void SetState(int index)
    {
        if (currentState != GetState(index))
        {
            currentState.ExitState();
            currentState = GetState(index);
            currentState.EnterState();
        }
    }

}
