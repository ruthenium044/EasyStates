public class PoolDeactivateCommand : ICommand
{
    private readonly int amount;
    private readonly DrawShape drawShape;
    
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