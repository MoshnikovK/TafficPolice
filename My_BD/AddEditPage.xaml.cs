using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Windows;

namespace My_BD
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Window
    {

        private Автомобили автомобили;
        private AdminForm adminForm;
        private bool change;
        public AddEditPage(AdminForm adminForm, Автомобили автомобили, bool change)
        {
            InitializeComponent();
            if (автомобили != null)
                this.автомобили = автомобили;
            else
                this.автомобили = new Автомобили();
            DataContext = this.автомобили;
            this.adminForm = adminForm;
            this.change = change;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!change)
            {
                MKE_LABEntities.GetContext().Автомобили.Add(автомобили);
            }
            try
            {
                MKE_LABEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
                AdminForm adminForm = new AdminForm();
                adminForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                AdminForm adminForm = new AdminForm();
                adminForm.Show();
            }
        }
    }
}
