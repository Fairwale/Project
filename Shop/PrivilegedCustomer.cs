using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class PrivilegedCustomer : Customer
    {
        public ulong CreditCardNumber { get; set; }
        public double Discount { get; set; }

        public PrivilegedCustomer(string name, int money) : base(name, money)
        {
            CreditCardNumber = GenerateCreditCardNumber();
            Discount = 0.07;
        }

        public override void updateCredits(double money)
        {
            this.Money -= money * (1 - Discount);
        }
    }
}
