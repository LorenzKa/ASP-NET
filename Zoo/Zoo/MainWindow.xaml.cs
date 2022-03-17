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
        Factory factory = Factory.Instance;
        public MainWindow()
        {
            InitializeComponent();
            cmbAnimals.ItemsSource = factory.Spezies.Values.Select(x => x.Name);
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < int.Parse(txtCount.Text); i++)
            {
                animals.Add(factory.FactoryMethod((string)cmbAnimals.SelectedValue));
            }
            updateData();
        }

        private void updateData()
        {
            lblGreenfood.Content = "Bedarf Grünfutter/Tag [kg]: "+ animals.Select(x => x.GreenfoodUsage).Sum();
            lblMeat.Content = "Bedarf Fleischfutter/Tag [kg]: " + animals.Select(x => x.MeatUsage).Sum();
            lblTotal.Content = "Gesamtwert [€]: " + animals.Select(x => x.Price).Sum();
            var animalCounterList = new List<string>();
            foreach(Animal animal in animals.DistinctBy(x => x.Name).ToList())
            {
                animalCounterList.Add(animals.Where(x => x.Name == animal.Name).Count()+"x "+animal.Name);
            }
            lstAnimals.ItemsSource = animalCounterList;
        }
    }
}
