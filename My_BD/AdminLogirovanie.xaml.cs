using System.Linq;
using System.Windows;

namespace My_BD
{
    /// <summary>
    /// Логика взаимодействия для AdminLogirovanie.xaml
    /// </summary>
    public partial class AdminLogirovanie : Window
    {
        public AdminLogirovanie()
        {
            InitializeComponent();
            DBLogirovanie.ItemsSource = MKE_LABEntities.GetContext().Логирование.ToList();
            RowCount.Content = DBLogirovanie.Items.Count.ToString();
        }
        private void btnMenuOpen_Click(object sender, RoutedEventArgs e)
        {
            AdminMenuForm adminMenuForm = new AdminMenuForm();
            this.Close();
            adminMenuForm.Show();
        }
    }
}
