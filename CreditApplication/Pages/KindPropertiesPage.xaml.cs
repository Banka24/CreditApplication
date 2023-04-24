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
    /// Логика взаимодействия для KindPropertiesPage.xaml
    /// </summary>
    public partial class KindPropertiesPage : Page
    {
        public KindPropertiesPage()
        {
            InitializeComponent();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DataGridKindProperties.ItemsSource = CreditsEntities.GetContext().KindProperties.ToList();
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
