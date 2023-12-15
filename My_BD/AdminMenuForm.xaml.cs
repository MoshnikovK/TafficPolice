using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace My_BD
{
    /// <summary>
    /// Логика взаимодействия для AdminMenuForm.xaml
    /// </summary>
    public partial class AdminMenuForm : Window
    {
        public AdminMenuForm()
        {
            InitializeComponent();

            var image = new BitmapImage(new Uri("H:\\Новая папка\\My_BD\\admin.jpg", UriKind.Absolute));
            imageAdmin.Source = image;
        }
        private void btnFormLogirovanie_Click(object sender, RoutedEventArgs e)
        {
            AdminLogirovanie adminLogirovanie = new AdminLogirovanie();
            this.Close();
            adminLogirovanie.Show();
        }
        private void btnFormViolationsCRUD_Click(object sender, RoutedEventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            this.Close();
            adminForm.Show();
        }
        private void btnOpenAvtorization_Click(object sender, RoutedEventArgs e)
        {
            Avtorization avtorization = new Avtorization();
            this.Close();
            avtorization.Show();
        }
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }
    }
}
