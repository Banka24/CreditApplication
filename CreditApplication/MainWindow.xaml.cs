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
using CreditApplication.Pages;
using CreditApplication.Entities;

namespace CreditApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new CreditPage();
        }

        public void BtnClients_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ClientsPage();
        }
        public void BtnKindProperty_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new KindPropertiesPage();
        }
        public void BtnKindCredit_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new KindCreditsPage();
        }
        public void BtnCredits_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new CreditPage();
        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
