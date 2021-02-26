using System;

namespace ChainOfResponsibilityPattern
{
    public class TeamLead : Approver
    {
        public override bool HandleRequest(int amount)
        {
            if (amount <= 500)
            {
                Console.WriteLine("TeamLead can approve");
                return true;
            }
            else
            {
                Console.WriteLine("TeamLead cannot approve");
                return Next.HandleRequest(amount);
            }
        }
    }
}
