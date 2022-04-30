
using MusicManagerDb;
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

namespace MusicManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MusikManager db;

        public MainWindow(MusikManager db)
        {
            
            InitializeComponent();
            this.db = db;
            MusicViewModel viewmodel = new MusicViewModel(db);
            this.DataContext = viewmodel;
            db.Database.EnsureCreated();
            
        }

    }
}
