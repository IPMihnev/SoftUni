using System.Collections.Generic;

namespace StrategyPattern.Strategies
{
    public interface ISortingStrategy
    {
        void Sort(List<int> collection);
    }
}
