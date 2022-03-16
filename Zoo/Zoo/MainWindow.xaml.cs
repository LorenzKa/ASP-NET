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
using ZooData;

namespace Zoo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Animal> animals = new List<Animal>();
        Factory factory = new Factory();
        public MainWindow()
        {
            InitializeComponent();
            cmbAnimals.ItemsSource = factory.animals.Values.Select(x => x.Name);
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < int.Parse(txtCount.Text); i++)
            {
                animals.Add(factory.cloneAnimal((Animal)cmbAnimals.SelectedValue));
            }
        }
    }
}
