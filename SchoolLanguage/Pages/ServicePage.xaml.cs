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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolLanguage.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        public ServicePage()
        {
            InitializeComponent();
        }

        private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Service> currentServices = LanguageSchoolEntities.GetContext().Service.ToList();
            currentServices = currentServices.Where(p => p.Title.ToLower().Contains(textBoxSearch.Text.ToLower()) || p.Description != null && p.Description.ToLower().Contains(textBoxSearch.Text.ToLower())).ToList();
            LViewServices.ItemsSource = currentServices;
        }

        private void btnAddService_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.user.Role.Title == "admin")
            {
                try
                {
                    if (MessageBox.Show("Вы действительно хотите удалить данную услугу", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        //Service service = LanguageSchoolEntities.GetContext().Service.Where(p => p.ID == service.ID).First();
                        //LanguageSchoolEntities.GetContext().Service.Remove(service);
                        //LanguageSchoolEntities.GetContext().SaveChanges();
                        //MessageBox.Show("Услуга удалена", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка соединения с базой", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                MessageBox.Show("У вас не достаточно прав", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                LViewServices.ItemsSource = LanguageSchoolEntities.GetContext().Service.ToList();
            }
            catch
            {
                MessageBox.Show("Ошибка получения данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
