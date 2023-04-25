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
    /// Логика взаимодействия для AddOrEditKindCredit.xaml
    /// </summary>
    public partial class AddOrEditKindCredit : Window
    {
        private KindCredit _currentKindCredit = new KindCredit();
        private int term = 0, rate = 0;
        public AddOrEditKindCredit(KindCredit kindCredit)
        {
            InitializeComponent();
            if(kindCredit != null)            
                _currentKindCredit = kindCredit;            
            DataContext = _currentKindCredit;
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
                if (_currentKindCredit.KindCreditId == 0)
                {
                    CreditsEntities.GetContext().KindCredits.Add(_currentKindCredit);
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
            if (string.IsNullOrWhiteSpace(_currentKindCredit.KindCreditName))
                str.AppendLine("Поле вид кредита клиента введено некорректно");
            if (string.IsNullOrWhiteSpace(_currentKindCredit.Conditions))
                str.AppendLine("Поле условие введен некорректно");
            if (!int.TryParse(TbRate.Text, out rate))
                str.AppendLine("Поле ставка только число");
            else if (rate < 0)
                str.AppendLine("Ставка не может быть отрицательной");
            if (!int.TryParse(TbTerm.Text, out term))
                str.AppendLine("Поле срок только число");
            else if (term < 0)
                str.AppendLine("Срок не может быть отрицательным");
            return str;
        }
    }
}
