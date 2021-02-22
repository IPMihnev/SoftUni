using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            for (int i = 0; i < 10; i++)
            {
                list.AddHead(new Node(i));
            }
            list.PrintList();

            list.ReversePrint();
        }
    }
}
