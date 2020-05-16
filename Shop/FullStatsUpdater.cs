using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows;

namespace Shop
{
    class Obj2
    {
        public List<Sell> Sells { get; set; } = new List<Sell>();
    }

    class Sell
    {
        public string Time { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public Dictionary<string, int> Goods { get; set; } = new Dictionary<string, int>();
    }

    public class FullStatsUpdater : StatsUpdater
    {
        public FullStatsUpdater(string filePath) : base(filePath)
        {

        }

        public override void Update(Dictionary<string, int> cart, string name, int money)
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    string time = DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute;
                    Sell s = new Sell()
                    {
                        Time = time,
                        Name = name,
                        Cost = money,
                        Goods = cart
                    };

                    Obj2 obj = new Obj2();
                    obj.Sells.Add(s);

                    File.WriteAllText(FilePath, JsonConvert.SerializeObject(obj));
                }
                else
                {
                    Obj2 obj = JsonConvert.DeserializeObject<Obj2>(File.ReadAllText(FilePath));

                    string time = DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute;
                    Sell s = new Sell()
                    {
                        Time = time,
                        Name = name,
                        Cost = money,
                        Goods = cart
                    };

                    obj.Sells.Add(s);

                    File.WriteAllText(FilePath, JsonConvert.SerializeObject(obj));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка записи о совершённой покупке. Ошибка: " + ex.Message);
            }
        }


    }
}
