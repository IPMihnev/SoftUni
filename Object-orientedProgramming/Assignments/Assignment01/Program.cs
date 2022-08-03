using System;
using System.Linq;
using System.Collections.Generic;

namespace Assignment01
{
    public class Program
    {
        public static void Main()
        {
            var sol = new Solution();
            var input = Console.ReadLine();
            while(input != "end")
            {
               var numbers = input.Split(",")
                             .Where(x => !string.IsNullOrWhiteSpace(x))
                             .Select(x => int.Parse(x.Trim()))
                             .ToArray();
               var result = sol.solution(numbers);
               Console.WriteLine(result);
               input = Console.ReadLine();
            }
        }

        public class Solution 
        { 
            public int solution(int[] A)
            {
               var set = new HashSet<int>();
               int maxElement = 0;
           
               for (int i = 0; i < A.Length; i++)
               {
                   set.Add(A[i]);
                   maxElement = Math.Max(maxElement, A[i]);
               }
           
               if (maxElement != A.Length)
               {
                   return 0;
               }
           
               if (set.Count == A.Length)
               {
                   return 1;
               }
               return 0;
            }
        }
    }
}
