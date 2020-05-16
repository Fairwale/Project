using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public abstract class StatsUpdater
    {
        protected string FilePath { get; set; }

        public StatsUpdater(string filePath)
        {
            FilePath = filePath;
        }

        public virtual void Update(Dictionary<string, int> cart, string name, double money)
        {

        }


    }
}
