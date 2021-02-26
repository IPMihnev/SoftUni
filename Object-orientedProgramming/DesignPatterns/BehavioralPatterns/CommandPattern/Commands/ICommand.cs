namespace CommandPattern.Commands
{
    public abstract class ICommand
    {
        protected int operand;

        public ICommand(int operand)
        {
            this.operand = operand;
        }
        public abstract int Calculate(int currentValue);
        public abstract int UndoCalculation(int currentValue);
    }
}
