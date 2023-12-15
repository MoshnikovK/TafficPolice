using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace My_BD
{
    /// <summary>
    /// Логика взаимодействия для UserMenuForm.xaml
    /// </summary>
    public partial class UserMenuForm : Window
    {
        public UserMenuForm()
        {
            InitializeComponent();
            MKE_LABEntities db = new MKE_LABEntities();
            Avtorization avtorization = new Avtorization();

            var image = new BitmapImage(new Uri("H:\\Новая папка\\My_BD\\user1.jpg", UriKind.Absolute));
            ImageUser.Source = image;

        }
        private void btnFormViolations_Click(object sender, RoutedEventArgs e)
        {
            UserForm userForm = new UserForm();
            this.Close();
            userForm.Show();
        }
        private void btnOpenAvtorization_Click(object sender, RoutedEventArgs e)
        {
            Avtorization avtorization = new Avtorization();
            this.Close();
            avtorization.Show();
        }
    }
}
