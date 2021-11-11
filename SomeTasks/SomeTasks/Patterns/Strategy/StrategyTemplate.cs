namespace SomeTasks.Patterns.Strategy
{
    public interface IStrategy
    {
        void Algorithm();
    }
    public class ConcreteStrategy1 : IStrategy
    {
        public void Algorithm()
        {
            
        }
    }
    public class ConcreteStrategy2 : IStrategy
    {
        public void Algorithm()
        {
            
        }
    }

    public class Context
    {
        public IStrategy CurrentStrategy { get; set; }

        public Context(IStrategy strategy)
        {
            CurrentStrategy = strategy;
        }

        public void ExecuteAlgorithm()
        {
            CurrentStrategy.Algorithm();
        }
    }
}