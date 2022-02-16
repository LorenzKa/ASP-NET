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
using Microsoft.AspNetCore.SignalR.Client;
using PasswordCrackerApi.Dtos;

namespace PasswordCracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public HubConnection connection;
        public MainWindow()
        {
            InitializeComponent();
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7200/crack")
                .Build();
            connection.On<int>("progress", progress =>
            {
                progressBar.Value = progress;
            });
            connection.On<string>("result", result =>
            {
                progressBar.Visibility = Visibility.Hidden;
                lblResult.Visibility = Visibility.Visible;
                lblResult.Content = result;
            });
        }
        
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await connection.StartAsync();
            if (connection.State.HasFlag(HubConnectionState.Connected))
            {
                Console.WriteLine(connection.State.ToString());
                lblHubError.Visibility = Visibility.Hidden;
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Visibility = Visibility.Hidden;
            progressBar.Visibility = Visibility.Visible;
            progressBar.Value = 0;
            if(txtLength.Text == "")
            {
                await connection.InvokeAsync("Bruteforce", new CrackRequestDto
                {
                    Alphabet = txtAlphabet.Text,
                    HashCode = txtPassword.Text,
                    Length = 0
                });
                return;
            }
            await connection.InvokeAsync("Bruteforce", new CrackRequestDto
            {
                Alphabet = txtAlphabet.Text,
                HashCode = txtPassword.Text,
                Length = int.Parse(txtLength.Text)
            });
        }
        private void ProgressBarHandler()
        {
            
        }

    }
}
