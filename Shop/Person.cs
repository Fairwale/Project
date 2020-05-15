using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public abstract class Person
    {
        public string Name { get; set; }
        public double Money { get; set; }

        public Person(string name, int money)
        {
            Name = name;
            Money = money;
        }

        protected ulong GenerateCreditCardNumber()
        {
            StringBuilder sb = new StringBuilder();
            Random r = new Random();
            for(int i = 0; i < 16; i++)
            {
                sb.Append(r.Next(0, 10));
            }
            return Convert.ToUInt64(sb.ToString());
        }


    }
}
