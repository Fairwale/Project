using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Newtonsoft.Json;

namespace Shop
{
    class Obj
    {
        public List<Dictionary<string, string>> Goods { get; set; }
    }

    public static class SettingsManager
    {
        public static  string BackgroundColor { get; set; }
        public static Dictionary<string, int> Goods { get; set; } = new Dictionary<string, int>();

        static SettingsManager()
        {
            try
            {
                string str = File.ReadAllText("settings.cfg");
                BackgroundColor = str.Substring(str.IndexOf(":") + 2);

                Obj deserialized = JsonConvert.DeserializeObject<Obj>(File.ReadAllText("goods.json"));
                for (int i = 0; i < deserialized.Goods.Count; i++)
                {
                    Goods.Add(deserialized.Goods[i].ElementAt(0).Value, Convert.ToInt32(deserialized.Goods[i].ElementAt(1).Value));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Инициализация приложения невозможна. Ошибка: " + ex.Message);
            }
        }


    }
}
