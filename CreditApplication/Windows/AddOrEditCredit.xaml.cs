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
using System.Windows.Shapes;

namespace CreditApplication.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddOrEditCredit.xaml
    /// </summary>
    public partial class AddOrEditCredit : Window
    {
        private Credit _currentCredit = new Credit();
        private decimal creditSumm = 0;
        public AddOrEditCredit(Credit credit)
        {
            InitializeComponent();
            if(credit != null)
            _currentCredit = credit;
            DataContext = _currentCredit;
            ComboBoxClient.ItemsSource = CreditsEntities.GetContext().Clients.ToList();
            ComboBoxKindCredit.ItemsSource = CreditsEntities.GetContext().KindCredits.ToList();
        }
        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = CheckField();
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                    return;
                }
                if (_currentCredit.CreditId == 0)                
                    CreditsEntities.GetContext().Credits.Add(_currentCredit);                
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
            if(ComboBoxKindCredit.SelectedItem == null)
                str.AppendLine("Выберите вид кредита");
            if (ComboBoxKindCredit.SelectedItem == null)
                str.AppendLine("Выберите клиента");            
            if (_currentCredit.CreditSumm < 0)
                str.AppendLine("Сумма кредита не может быть отрицательной");
            return str;
        }
    }

}
