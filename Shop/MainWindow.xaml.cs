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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Shop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] names = { "Пётр", "Иван", "Василий", "Елена", "Ирина", "Екатерина", "Сергей", "Николай" };
        private Customer customer;
        private double money = 0;
        private Dictionary<string, int> cart = new Dictionary<string, int>();

        public MainWindow()
        {
            InitializeComponent();

            Background = (Brush) new BrushConverter().ConvertFromString(SettingsManager.BackgroundColor);

            customer = new PrivilegedCustomer(GetRandomName(), 2000);
            text1.Text = customer.Name;
            text2.Text = customer.Money.ToString();

            ImagePool pool = new ImagePool();
            foreach(string s in Directory.GetFiles("../../images"))
            {
                string name = s.Substring(s.IndexOf("\\") + 1);
                name = name.Substring(0, name.IndexOf(".jpg"));
                pool.AddImage(name);
            }

            Dictionary<string, Image> images = pool.GetImages();
            foreach(string name in images.Keys)
            {
                StackPanel sp = new StackPanel();
                sp.Orientation = Orientation.Vertical;
                sp.Margin = new Thickness(0, 0, 0, 15);
                StackPanel sp1 = new StackPanel(); // Название и цена продукта
                sp1.Orientation = Orientation.Horizontal;
                StackPanel sp2 = new StackPanel(); // Кол-во в корзине
                sp2.Orientation = Orientation.Horizontal;

                TextBlock t1 = new TextBlock();
                t1.Text = name + " ";
                TextBlock t2 = new TextBlock();
                t2.Text = SettingsManager.Goods[name].ToString();
                sp1.Children.Add(t1);
                sp1.Children.Add(t2);
                sp1.HorizontalAlignment = HorizontalAlignment.Center;

                TextBlock t3 = new TextBlock();
                t3.Text = "Количество: ";
                TextBox t4 = new TextBox();
                t4.Width = 20;
                t4.Tag = name;
                t4.TextChanged += T4_TextChanged;
                t4.Text = 0.ToString();
                sp2.Children.Add(t3);
                sp2.Children.Add(t4);
                sp2.HorizontalAlignment = HorizontalAlignment.Center;

                Image im = images[name];
                sp.Children.Add(sp1);
                sp.Children.Add(sp2);
                sp.Children.Add(im);
                sp0.Children.Add(sp);
            }

           
        }

        private void T4_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text.StartsWith("-"))
                t.Text = t.Text.Substring(1);

            if (t.Text == "")
                cart[t.Tag.ToString()] = 0;
            else
                cart[t.Tag.ToString()] = Convert.ToInt32(t.Text);

            UpdateCart();
        }

        private string GetRandomName()
        {
            Random r = new Random();
            return names[r.Next(0, names.Length)];
        }

        private void UpdateCart()
        {
            money = 0;
            foreach(string name in cart.Keys)
            {
                money += SettingsManager.Goods[name] * cart[name];
            }
            text3.Text = money.ToString();

            lb1.Items.Clear();
            foreach (string name in cart.Keys)
            {
                if(cart[name] != 0)
                    lb1.Items.Add(name + ": " + cart[name]);
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if(customer.Money >= money)
            {
                customer.updateCredits(money);
                text2.Text = customer.Money.ToString();

                ClearCart();
            }
            else
            {
                MessageBox.Show("Недостаточно средств для покупки");
            }
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            ClearCart();
        }

        private void ClearCart()
        {
            // Обнуление количества каждого товара
            var goodsSP = sp0.Children.OfType<StackPanel>();
            foreach (StackPanel sp in goodsSP)
            {
                var goodsContentSP = sp.Children.OfType<StackPanel>();
                (goodsContentSP.ElementAt(1).Children.OfType<TextBox>()).ElementAt(0).Text = "0";
            }
        }


    }
}
