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
        List<BaseAnimal> animals = new List<BaseAnimal>();
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
            
            var greenfoodUsage = 0.0;
            var meatUsage = 0.0;
            foreach (var animal in animals)
            {
                var usages = animal switch
                {
                    Carnivore c => greenfoodUsage += c.GreenfoodUsage,
                    Herbivore h => meatUsage += h.MeatUsage,
                    _ => throw new NotImplementedException()
                };
            }
            lblGreenfood.Content = "Bedarf Grünfutter/Tag [kg]: "+ greenfoodUsage;
            lblMeat.Content = "Bedarf Fleischfutter/Tag [kg]: " + meatUsage;
            lblTotal.Content = "Gesamtwert [€]: " + animals.Select(x => x.Price).Sum();
            var animalCounterList = new List<string>();
            foreach(BaseAnimal animal in animals.DistinctBy(x => x.Name).ToList())
            {
                animalCounterList.Add(animals.Where(x => x.Name == animal.Name).Count()+"x "+animal.Name);
            }
            lstAnimals.ItemsSource = animalCounterList;
        }
    }
}
