using SchoolLanguage.Entities;
using SchoolLanguage.Utils;
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

namespace SchoolLanguage.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            textBoxLogin.Text = "admin";
            passwordBoxPass.Password = "0000";
        }

        private void btnAuthorization_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxLogin.Text != "" && passwordBoxPass.Password != "")
            {
                try
                {
                    var user = LanguageSchoolEntities.GetContext().User.Where(p => p.Login == textBoxLogin.Text && p.Password == passwordBoxPass.Password).FirstOrDefault();
                    if (user != null)
                    {
                        Manager.user = user;
                        MessageBox.Show("Вы успешно авторизовались", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        StartWindow startWindow = new StartWindow();
                        startWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не правильные данные для авторизации", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch
                {
                    MessageBox.Show($"Ошибка: соединения с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }                
            }
            else
            {
                MessageBox.Show("Поле логина и пароля не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
