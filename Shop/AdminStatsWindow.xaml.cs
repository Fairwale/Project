using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Newtonsoft.Json;

namespace Shop
{
    /// <summary>
    /// Логика взаимодействия для AdminStatsWindow.xaml
    /// </summary>
    public partial class AdminStatsWindow : Window
    {
        public AdminStatsWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string password = tb1.Text;
            if (password == "valid") // Эмитируем проверку пароля
            {
                lb1.Items.Clear();
                bool compact = (bool)cb1.IsChecked;
                string path = compact ? "../../sells_short.json" : "../../sells.json";

                SellsList obj = JsonConvert.DeserializeObject<SellsList>(File.ReadAllText(path));
                foreach (Sell s in obj.Sells)
                {
                    lb1.Items.Add("Время: " + s.Time);
                    lb1.Items.Add("Имя: " + s.Name);
                    lb1.Items.Add("Куплено на сумму: " + s.Cost);
                    foreach (string name in s.Goods.Keys)
                    {
                        lb1.Items.Add(name + ": " + s.Goods[name]);
                    }
                    lb1.Items.Add("");
                }
            }
        }

    }
}
