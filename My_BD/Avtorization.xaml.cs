using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace My_BD
{
    /// <summary>
    /// Логика взаимодействия для Avtorization.xaml
    /// </summary>
    public partial class Avtorization : Window
    {
        public Avtorization()
        {
            InitializeComponent();
        }
        public string login { get; set; }
        public string password { get; set; }
        private void GenerateAndShowCaptcha()
        {
            // Генерация CAPTCHA
            string captcha = GenerateCaptcha();

            // Отображение CAPTCHA на форме (не забудьте добавить соответствующий элемент управления для отображения CAPTCHA)
            txtCaptcha.Text = captcha;
        }

        private string GenerateCaptcha()
        {
            // Генерация случайных символов для CAPTCHA
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void BlockLoginWithTimer()
        {
            // Блокировка кнопки входа и установка таймера на 3 минуты
            btnLogin.IsEnabled = false;

            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 3, 0); // 3 минуты
            timer.Tick += (o, args) =>
            {
                btnLogin.IsEnabled = true;
                timer.Stop();
            };
            timer.Start();
        }
        private int captchaAttempts = 0;
        private bool isCaptchaVerified = false;
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
             login = txtLogin.Text;
             password = txtPassword_.Password;
            AdminMenuForm adminMenuForm = new AdminMenuForm();
            UserMenuForm userMenuForm = new UserMenuForm();
            if (isPasswordVisible)
            {
                password = txtPassword_.Password;
            }
            else
            {
                password = txtPassword.Text;
            }
                // Проверка заполнения полей
                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
                return;
            }

            using (MKE_LABEntities db = new MKE_LABEntities())
            {
                // Поиск пользователя по логину и паролю
                Пользователи user = db.Пользователи.FirstOrDefault(u => u.Логин == login && u.Пароль == password);

                // Проверка наличия пользователя
                if (user != null)
                {
                    if (txtCaptchaVod.Text != txtCaptcha.Text)
                    {

                        MessageBox.Show("Неверно введена капча.");
                        // Добавление записи в таблицу логов
                        Логирование log = new Логирование();
                        log.Логин = login;
                        log.Время_входа = DateTime.Now;
                        log.Зашол_или_нет = false;
                        log.Примечание = "Неверно введена капча.";
                        db.Логирование.Add(log);
                        db.SaveChanges();
                        GenerateAndShowCaptcha(); // Сгенерировать новую капчу для следующей попытки
                    }
                    else
                    {
                        // После проверки капчи и если пользователь введет логин и пароль правильно
                        isCaptchaVerified = true;
                        if (user.Роль == "Администратор")
                        {
                            MessageBox.Show("Вы вошли как администратор");
                            // Добавление записи в таблицу логов
                            Логирование log = new Логирование();
                            log.Логин = login;
                            log.Время_входа = DateTime.Now;
                            log.Зашол_или_нет = true;
                            log.Примечание = "Вы вошли как администратор.";
                            db.Логирование.Add(log);
                            db.SaveChanges();
                            this.Close();
                            adminMenuForm.Show();
                        }
                        else if (user.Роль == "Водитель")
                        {
                            MessageBox.Show("Вы вошли как пользователь");
                            // Добавление записи в таблицу логов
                            Логирование log = new Логирование();
                            log.Логин = login;
                            log.Время_входа = DateTime.Now;
                            log.Зашол_или_нет = true;
                            log.Примечание = "Вы вошли как пользователь.";
                            db.Логирование.Add(log);
                            db.SaveChanges();
                            this.Close();
                            userMenuForm.Show();
                        }
                        else if (user.Роль == "Инспектор_ДПС")
                        {
                            MessageBox.Show("Вы вошли как пользователь");
                            // Добавление записи в таблицу логов
                            Логирование log = new Логирование();
                            log.Логин = login;
                            log.Время_входа = DateTime.Now;
                            log.Зашол_или_нет = true;
                            log.Примечание = "Вы вошли как пользователь.";
                            db.Логирование.Add(log);
                            db.SaveChanges();
                            this.Close();
                            userMenuForm.Show();
                        }
                        captchaAttempts = 0; // Сбросить счетчик попыток
                    }
                }
                else
                {
                    // Неверные логин или пароль
                    captchaAttempts++;
                    if (captchaAttempts == 1)
                    {
                        // Показ CAPTCHA при первой ошибке
                        txtCaptcha.Visibility = Visibility.Visible;
                        _captha.Visibility = Visibility.Visible;
                        txtCaptchaVod.Visibility = Visibility.Visible;
                        btnRegenCupcha.Visibility = Visibility.Visible;
                        GenerateAndShowCaptcha();
                        MessageBox.Show("Неверно логин или пароль.");
                        // Добавление записи в таблицу логов
                        Логирование log = new Логирование();
                        log.Логин = login;
                        log.Время_входа = DateTime.Now;
                        log.Зашол_или_нет = false;
                        log.Примечание = "Неверно логин или пароль.";
                        db.Логирование.Add(log);
                        db.SaveChanges();
                    }
                    else if (captchaAttempts == 2 && !isCaptchaVerified)
                    {
                        // Проверка CAPTCHA при третьей ошибке, если капча еще не проверена
                        if (txtCaptchaVod.Text != txtCaptcha.Text)
                        {
                            MessageBox.Show("Неверно введена капча.");
                            // Добавление записи в таблицу логов
                            Логирование log = new Логирование();
                            log.Логин = login;
                            log.Время_входа = DateTime.Now;
                            log.Зашол_или_нет = false;
                            log.Примечание = "Неверно введена капча.";
                            db.Логирование.Add(log);
                            db.SaveChanges();
                            GenerateAndShowCaptcha(); // Сгенерировать новую капчу для следующей попытки
                        }
                        else
                        {
                            isCaptchaVerified = true;
                            captchaAttempts = 0;
                        }
                    }
                    else if (captchaAttempts >= 3)
                    {
                        // Блокировка возможности входа и установка таймера на 3 минуты при четвертой ошибке
                        // Добавление записи в таблицу логов
                        Логирование log = new Логирование();
                        log.Логин = login;
                        log.Время_входа = DateTime.Now;
                        log.Зашол_или_нет = false;
                        log.Примечание = "Слишком много попыток авторизации. Попробуйте войти позже.";
                        db.Логирование.Add(log);
                        db.SaveChanges();
                        MessageBox.Show("Слишком много попыток авторизации. Попробуйте войти позже.");
                        txtCaptcha.Visibility = Visibility.Collapsed;
                        _captha.Visibility = Visibility.Collapsed;
                        txtCaptchaVod.Visibility = Visibility.Collapsed;
                        btnRegenCupcha.Visibility = Visibility.Collapsed;
                        BlockLoginWithTimer();
                        captchaAttempts = 0; // Сбросить счетчик попыток
                    }
                }
            }
        }
        private void btnRegenCupcha_Click(object sender, RoutedEventArgs e)
        {
            GenerateAndShowCaptcha();
        }
        private bool isPasswordVisible = true;
        private void btnHidePassword_Click(object sender, RoutedEventArgs e)
        {
            if (isPasswordVisible)
            {
                txtPassword.Visibility= Visibility.Visible; // Показать TextBox
                txtPassword.Text = txtPassword_.Password; // Показать реальные символы пароля
                txtPassword_.Visibility = Visibility.Collapsed; // Скрыть PasswordBox
                var image = new BitmapImage(new Uri("H:\\Новая папка\\My_BD\\open.png", UriKind.Absolute));
                btnHidePasswordImage.Source = image;
            }
            else
            {
                var image = new BitmapImage(new Uri("H:\\Новая папка\\My_BD\\close.png", UriKind.Absolute));
                btnHidePasswordImage.Source = image;
                if (txtPassword.Text != "")
        {
                    txtPassword_.Password = txtPassword.Text; // Перенести текст из TextBox в PasswordBox
                }
                txtPassword_.Visibility = Visibility.Visible; // Показать PasswordBox
                txtPassword.Visibility = Visibility.Collapsed; // Скрыть TextBox
            }
            isPasswordVisible = !isPasswordVisible;
        }
    }
}

