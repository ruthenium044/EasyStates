
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





