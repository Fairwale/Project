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
    public class ShortStatsUpdater : StatsUpdater
    {
        public ShortStatsUpdater(string filePath) : base(filePath)
        {

        }

        public override void Update(Dictionary<string, int> cart, string name, double money)
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
                        Cost = money
                    };

                    SellsList obj = new SellsList();
                    obj.Sells.Add(s);

                    File.WriteAllText(FilePath, JsonConvert.SerializeObject(obj));
                }
                else
                {
                    SellsList obj = JsonConvert.DeserializeObject<SellsList>(File.ReadAllText(FilePath));

                    string time = DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute;
                    Sell s = new Sell()
                    {
                        Time = time,
                        Name = name,
                        Cost = money
                    };

                    obj.Sells.Add(s);

                    File.WriteAllText(FilePath, JsonConvert.SerializeObject(obj));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка записи о совершённой покупке. Ошибка: " + ex.Message);
            }
        }


    }
}
