using ElementLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace ShoppingCart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Good> cart = new ObservableCollection<Good>();
        ObservableCollection<Good> bag = new ObservableCollection<Good>();

        public MainWindow()
        {
            InitializeComponent();
            lstBag.ItemsSource = bag;
            lstCart.ItemsSource = cart;
        }

        private void panButtons_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd(object sender, RoutedEventArgs e)
        {
            if (rdoBeverage.IsChecked == true)
            {
                var beverage = new Beverage();
                beverage.Name = txtName.Text;
                beverage.PricePerUnit = double.Parse(txtPricePerUnit.Text);
                beverage.NrUnits = (int)sldUnits.Value;
                beverage.Weight = (int)sldWeight.Value;
                beverage.Calories = new Random().Next(50, 500);
                beverage.Alcohol = new Random().NextDouble();
                addObjectToList(beverage);
            }
            if (rdoCosmetic.IsChecked == true)
            {
                var beverage = new Cosmetic();
                beverage.Name = txtName.Text;
                beverage.PricePerUnit = double.Parse(txtPricePerUnit.Text);
                beverage.NrUnits = (int)sldUnits.Value;
                beverage.Weight = (int)sldWeight.Value;
                addObjectToList(beverage);
            }
            if (rdoFood.IsChecked == true)
            {
                var beverage = new Food();
                beverage.Name = txtName.Text;
                beverage.PricePerUnit = double.Parse(txtPricePerUnit.Text);
                beverage.NrUnits = (int)sldUnits.Value;
                beverage.Weight = (int)sldWeight.Value;
                beverage.Calories = new Random().Next(50, 500);
                addObjectToList(beverage);
            }
        }
        private void addObjectToList(Good toAdd)
        {
            if (rdoCart.IsChecked == true)
            {
                cart.Add(toAdd);
                return;
            }
            bag.Add(toAdd);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void btnAlc_Click(object sender, RoutedEventArgs e)
        {
            var visitor = new VisitorAlcohol();
            visitor.Reset();
            var joinedList = cart.ToList();
            joinedList.AddRange(bag.ToList());
            foreach (var item in joinedList)
            {
                item.Accept(visitor);
            }
            lblResult.Text = visitor.value.ToString();
        }

        private void btnCalories_Click(object sender, RoutedEventArgs e)
        {
            
            var visitor = new VisitorCalories();
            visitor.Reset();
            var joinedList = cart.ToList();
            joinedList.AddRange(bag.ToList());
            foreach (var item in joinedList)
            {
                item.Accept(visitor);
            }
            lblResult.Text = visitor.value.ToString();

        }


        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var visitorAlc = new VisitorRegister();
            visitorAlc.Reset();
            var joinedList = cart.ToList();
            joinedList.AddRange(bag.ToList());
            foreach (var item in joinedList)
            {
                item.Accept(visitorAlc);
            }
            lblResult.Text = visitorAlc.value.ToString();

        }

        private void btnRenderHtml_Click(object sender, RoutedEventArgs e)
        {
            var joinedList = cart.ToList();
            joinedList.AddRange(bag.ToList());
            var html = "<table>";
            foreach(var item in joinedList)
            {
                html += item.GetHtml();
            }
            html += "</table>";
            lblResult.Text = html;
        }

        private void btnScale_Click(object sender, RoutedEventArgs e)
        {
            var joinedList = cart.ToList();
            joinedList.AddRange(bag.ToList());
            var weight = 0.0;
            foreach (var item in joinedList)
            {
                weight += item.Weight;
            }
            lblResult.Text = weight.ToString();
        }
    }

}
