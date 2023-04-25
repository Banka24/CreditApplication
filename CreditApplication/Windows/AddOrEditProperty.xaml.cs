using CreditApplication.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для AddOrEditProperty.xaml
    /// </summary>
    public partial class AddOrEditProperty : Window
    {
        private KindProperty _currentKindProperty = new KindProperty();
        public AddOrEditProperty(KindProperty kindProperty)
        {
            InitializeComponent();
            if(kindProperty != null)
                _currentKindProperty = kindProperty;
            DataContext = _currentKindProperty;
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
                if (_currentKindProperty.KindPropertyId == 0)
                {
                    CreditsEntities.GetContext().KindProperties.Add(_currentKindProperty);
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
            if (string.IsNullOrWhiteSpace(_currentKindProperty.KindPropertyName))
                str.AppendLine("Поле вид собственности введено некорректно");            
            return str;
        }
    }
}
