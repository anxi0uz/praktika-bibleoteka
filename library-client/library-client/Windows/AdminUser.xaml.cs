using library_client.Enums;
using library_client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace library_client.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminUser.xaml
    /// </summary>
    public partial class AdminUser : Window
    {
        private readonly User user;
        private readonly HttpClient client;
        private readonly string baseUrl;
        private readonly bool isWorker;

        public AdminUser(User user, HttpClient client, string baseUrl, bool isWorker)
        {
            InitializeComponent();
            this.user = user;
            this.client = client;
            this.baseUrl = baseUrl;
            this.isWorker = isWorker;
            api();
        }
        public async void api()
        {
            if (isWorker)
                UsersDataGrid.ItemsSource = await FillDataGrid1();
            else
                UsersDataGrid.ItemsSource = await FillDataGrid();
        }
        public async Task<List<User>> FillDataGrid()
        {
            var response = await client.GetAsync($"{baseUrl}/User");
            var content = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<User>>(content);

            var response1 = users.Where(p => p.roleId == (int)Roles.User).ToList();
            return response1;
        }
        public async Task<List<User>> FillDataGrid1()
        {
            var response = await client.GetAsync($"{baseUrl}/User");
            var content = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<User>>(content);

            var response1 = users.Where(p => p.roleId == (int)Roles.Worker).ToList();
            return response1;
        }

        private void CreateUser_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new CreateUserWindow(client, baseUrl, false, isWorker);
            wnd.Show();
        }

        private void UpdateUserButton_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new CreateUserWindow(client, baseUrl, true, isWorker);
            wnd.Show();
        }

        private void UpdateDataGrid_Click(object sender, RoutedEventArgs e)
        {
            api();
        }

        private async void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            var response = await client.DeleteAsync($"{baseUrl}/User/{idTextBoxForDelete.Text}");
            if (!isWorker)
                if (response.IsSuccessStatusCode) MessageBox.Show("Читатель удален");
            else 
                if (response.IsSuccessStatusCode) MessageBox.Show("Сотрудник удален");
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new AdminWindow(user, client, baseUrl);
            wnd.Show();
            this.Close();
        }
    }
}
