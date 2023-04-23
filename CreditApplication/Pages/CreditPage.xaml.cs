using CreditApplication.Entities;
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

namespace CreditApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreditPage.xaml
    /// </summary>
    public partial class CreditPage : Page
    {
        public CreditPage()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DataGridCredit.ItemsSource = CreditsEntities.GetContext().Credits.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
