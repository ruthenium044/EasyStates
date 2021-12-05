
public class PoolActivateCommand : ICommand
{
    private readonly int amount;
    private readonly DrawShape drawShape;
    
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

