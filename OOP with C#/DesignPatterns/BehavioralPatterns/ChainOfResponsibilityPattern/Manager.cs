using System;

namespace ChainOfResponsibilityPattern
{
    public class Manager : Approver
    {
        public override bool HandleRequest(int amount)
        {
            if (amount <= 5000)
            {
                Console.WriteLine("Manager can approve.");
                return true;
            }

            Console.WriteLine("Manager cannot approve.");
            return false;
        }
    }
}
