using System;

namespace ChainOfResponsibilityPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Approver teamLead = new TeamLead();
            Approver manager = new Manager();

            teamLead.SetNext(manager);
            Console.WriteLine(teamLead.HandleRequest(400));
            Console.WriteLine(teamLead.HandleRequest(600));
            Console.WriteLine(teamLead.HandleRequest(6000));
            Console.WriteLine(teamLead.HandleRequest(0));

        }
    }
}
