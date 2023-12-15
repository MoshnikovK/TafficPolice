using System.Linq;
using System.Windows;

namespace My_BD
{
    /// <summary>
    /// Логика взаимодействия для UserForm.xaml
    /// </summary>
    public partial class UserForm : Window
    {
        public UserForm()
        {
            InitializeComponent();


            using (MKE_LABEntities db = new MKE_LABEntities())
            {
                MKE_LABEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                var result = db.Автомобили.Where(a => a.Данные_в_архив == false).ToList();
                DGCars.ItemsSource = result;
                RowCount.Content = DGCars.Items.Count.ToString();
            }
        }
        private void btnMenuOpen_Click(object sender, RoutedEventArgs e)
        {
            UserMenuForm userMenuForm = new UserMenuForm();
            this.Close();
            userMenuForm.Show();
        }
    }
}
