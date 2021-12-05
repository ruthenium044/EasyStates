using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    void Execute();
}

public interface IStateObject
{
    void SetState(int index);
}

public class SettingState
{
    readonly ICommand switchToIndex;

    public SettingState(ICommand switchToIndex)
    {
        this.switchToIndex = switchToIndex;
    }
    
    public void SetState(int index)
    {
        switchToIndex.Execute();
    }
}

public class SetStateCommand : ICommand
{
    private readonly StatesManager stateManager;
    private int index;

    public SetStateCommand(StatesManager stateManagerObject, int i)
    {
        stateManager = stateManagerObject;
        index = i;
    }

    public void Execute()
    {
        stateManager.SetState(index);
    }
}

public class PoolActivateCommand : ICommand
{
    private int amount;
    private DrawShape drawShape;
    
    public PoolActivateCommand(DrawShape drawShape, int i)
    {
        amount = i;
        this.drawShape = drawShape;
    }

    public void Execute()
    {
        drawShape.Activate(amount);
    }
}

public class PoolDeactivateCommand : ICommand
{
    private int amount;
    private DrawShape drawShape;
    
    public PoolDeactivateCommand(DrawShape drawShape, int i)
    {
        amount = i;
        this.drawShape = drawShape;
    }

    public void Execute()
    {
        drawShape.Deactivate(amount);
    }
}



