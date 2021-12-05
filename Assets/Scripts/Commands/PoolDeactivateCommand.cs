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