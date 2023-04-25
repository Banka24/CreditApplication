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
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CreditsEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DataGridClients.ItemsSource = CreditsEntities.GetContext().Clients.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditClient addOrEditClient = new AddOrEditClient(null);
            addOrEditClient.Show();
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(DataGridClients.SelectedItem is Client client) {
                AddOrEditClient addOrEditClient = new AddOrEditClient(client);
                addOrEditClient.Show();
            }            
        }
        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            if(DataGridClients.SelectedItem is Client client)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Удалить данную запись?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if(result == MessageBoxResult.Yes)
                    {
                        CreditsEntities.GetContext().Clients.Remove(client);
                        CreditsEntities.GetContext().SaveChanges();
                        Page_IsVisibleChanged(null, default(DependencyPropertyChangedEventArgs));
                        MessageBox.Show("Запись удалена");
                    }
                }
                catch(Exception ex)
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
