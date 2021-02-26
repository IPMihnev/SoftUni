using System.Collections.Generic;
using StrategyPattern.Strategies;

namespace StrategyPattern
{
    public class Sorter
    {
        private ISortingStrategy strategy;
        public Sorter(ISortingStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void Sort(List<int> collection)
        {
            strategy.Sort(collection);
        }
    }
}
