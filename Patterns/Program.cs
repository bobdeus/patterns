using System;

namespace Patterns
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            Patterns patterns = new Patterns();
            patterns.StateExample();
            //patterns.ObserverExample();
            // patterns.StrategyExample();
        }
    }

    internal class Patterns
    {
        public void StateExample()
        {
            StateExample stateExample = new StateExample();
            Console.ReadKey();
        }

        internal void ObserverExample()
        {
            ObserverExample observerExample = new ObserverExample();
            Console.ReadKey();
        }

        internal void StrategyExample()
        {
            StrategyExample strategyExample = new StrategyExample();
            Console.ReadKey();
        }
    }
}
