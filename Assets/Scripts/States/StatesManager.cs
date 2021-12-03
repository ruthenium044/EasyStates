using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesManager : MonoBehaviour
{
    private readonly List<IState> states = new List<IState>();
    
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
        //states[index].newColor = color;
    }
    
}
