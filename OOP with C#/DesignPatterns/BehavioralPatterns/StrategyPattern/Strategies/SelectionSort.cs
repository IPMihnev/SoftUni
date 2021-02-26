using System;
using System.Collections.Generic;

namespace StrategyPattern.Strategies
{
    public class SelectionSort : ISortingStrategy
    {
        public void Sort(List<int> collection)
        {
            Console.WriteLine("Selection sort");
        }
    }
}
