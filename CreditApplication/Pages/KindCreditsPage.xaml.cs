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
using CreditApplication.Pages;

namespace CreditApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для KindCreditsPage.xaml
    /// </summary>
    public partial class KindCreditsPage : Page
    {
        public KindCreditsPage()
        {
            InitializeComponent();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DataGridKindCredits.ItemsSource = CreditsEntities.GetContext().KindCredits.ToList();
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
    }
}
