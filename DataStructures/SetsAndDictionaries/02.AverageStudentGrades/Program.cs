using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);
                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<decimal>());
                    students[name].Add(grade);
                }
                else
                {
                    students[name].Add(grade);
                }
            }
            foreach (var item in students)
            {
                string result = string.Empty;
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < item.Value.Count; i++)
                {
                    sb.Append($"{item.Value[i]:f2} ");
                }
                result = sb.ToString();
                Console.WriteLine($"{item.Key} -> {result}(avg: {item.Value.Average():f2})");
            }
        }
    }
}
