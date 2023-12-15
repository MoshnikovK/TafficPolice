using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace My_BD
{
    /// <summary>
    /// Логика взаимодействия для AdminForm.xaml
    /// </summary>
    public partial class AdminForm : Window
    {
        public AdminForm()
        {
            InitializeComponent();
        }
        private void btnMenuOpen_Click(object sender, RoutedEventArgs e)
        {
            AdminMenuForm adminMenuForm = new AdminMenuForm();
            this.Close();
            adminMenuForm.Show();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddEditPage page = new AddEditPage(this, null, false);
            page.Show();
            this.Close();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            AddEditPage page = new AddEditPage(this, (sender as Button).DataContext as Автомобили, true);
            page.Show();
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var removing = DGCars.SelectedItems.Cast<Автомобили>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {removing.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    MKE_LABEntities.GetContext().Автомобили.RemoveRange(removing);
                    MKE_LABEntities.GetContext().SaveChanges();
                    this.Visibility = Visibility.Visible;
                    MessageBox.Show("Данные удалены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                this.Show();
            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            using (MKE_LABEntities db = new MKE_LABEntities())
            {
                MKE_LABEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DGCars.ItemsSource = MKE_LABEntities.GetContext().Автомобили.Where(a => a.Данные_в_архив == false).ToList();
                RowCount.Content = DGCars.Items.Count.ToString();
            }
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxFilter.IsChecked == true)
            {
                using (MKE_LABEntities db = new MKE_LABEntities())
                {
                    var result = db.Автомобили.Where(a => a.Данные_в_архив == true).ToList();
                    DGCars.ItemsSource = result;
                    RowCount.Content = DGCars.Items.Count.ToString();
                }
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (checkBoxFilter.IsChecked == false)
            {
                using (MKE_LABEntities db = new MKE_LABEntities())
                {
                    var result = db.Автомобили.Where(a => a.Данные_в_архив == false).ToList();
                    DGCars.ItemsSource = result;
                    RowCount.Content = DGCars.Items.Count.ToString();
                }
            }
        }
    }
}
