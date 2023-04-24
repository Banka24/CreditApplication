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
using System.Windows.Shapes;
using CreditApplication.Entities;

namespace CreditApplication.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddOrEditClient.xaml
    /// </summary>
    public partial class AddOrEditClient : Window {

        private Client _currentClient = new Client();
        public AddOrEditClient(Client client)
        {
            InitializeComponent();
            if(client != null)
                _currentClient = client;
            DataContext = _currentClient;
            ComboBoxKindProperty.ItemsSource = CreditsEntities.GetContext().KindProperties.ToList();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = CheckField();
                if(error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                    return;
                }
                if(_currentClient.ClientId == 0)
                {
                    CreditsEntities.GetContext().Clients.Add(_currentClient);
                }
                CreditsEntities.GetContext().SaveChanges();
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private StringBuilder CheckField()
        {
            StringBuilder str = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentClient.ClientName))
                str.AppendLine("Поле название клиента введено некорректно");
            if (string.IsNullOrWhiteSpace(_currentClient.Adress))
                str.AppendLine("Поле адрес введен некорректно");
            if (string.IsNullOrWhiteSpace(_currentClient.ContactFace))
                str.AppendLine("Поле контактное лицо введено некорректно");
            if (string.IsNullOrWhiteSpace(_currentClient.Phone))
                str.AppendLine("Поле телефон введен некорректно");
            if (ComboBoxKindProperty.SelectedItem == null)
                str.AppendLine("Выберите вид собственности");
            return str;
        }
    }
}
