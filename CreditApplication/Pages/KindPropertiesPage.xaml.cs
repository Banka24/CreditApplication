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
using CreditApplication.Windows;

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
            CreditsEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DataGridKindProperties.ItemsSource = CreditsEntities.GetContext().KindProperties.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditProperty addOrEditProperty = new AddOrEditProperty(null);
            addOrEditProperty.Show();
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridKindProperties.SelectedItem is KindProperty kindProperty)
            {
                AddOrEditProperty addOrEditProperty = new AddOrEditProperty(kindProperty);
                addOrEditProperty.Show();
            }
        }
        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridKindProperties.SelectedItem is KindProperty kindProperty)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Удалить данную запись?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result == MessageBoxResult.Yes)
                    {
                        CreditsEntities.GetContext().KindProperties.Remove(kindProperty);
                        CreditsEntities.GetContext().SaveChanges();
                        Page_IsVisibleChanged(null, default(DependencyPropertyChangedEventArgs));
                        MessageBox.Show("Запись удалена");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Page_IsVisibleChanged(null, default(DependencyPropertyChangedEventArgs));
        }
        
    }
}
