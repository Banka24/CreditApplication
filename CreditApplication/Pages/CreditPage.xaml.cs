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
using CreditApplication.Windows;

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
            CreditsEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DataGridCredit.ItemsSource = CreditsEntities.GetContext().Credits.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditCredit addOrEditCredit = new AddOrEditCredit(null);
            addOrEditCredit.Show();
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridCredit.SelectedItem is Credit credit)
            {
                AddOrEditCredit addOrEditCredit = new AddOrEditCredit(credit);
                addOrEditCredit.Show();
            }
        }
        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridCredit.SelectedItem is Credit credit)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Удалить данную запись?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result == MessageBoxResult.Yes)
                    {
                        CreditsEntities.GetContext().Credits.Remove(credit);
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
