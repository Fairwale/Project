using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Customer : Person
    {
        public ulong CreditCardNumber { get; set; }

        public Customer(string name, int money) : base(name, money)
        {
            CreditCardNumber = GenerateCreditCardNumber();
        }

        public virtual void updateCredits(double money)
        {
            this.Money -= money;
        }


    }
}
