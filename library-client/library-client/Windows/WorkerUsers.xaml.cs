using library_client.Enums;
using library_client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для WorkerUsers.xaml
    /// </summary>
    public partial class WorkerUsers : Window
    {
        private readonly User user;
        private readonly HttpClient client;
        private readonly string baseUrl;

        public WorkerUsers(User user, HttpClient client, string baseUrl)
        {
            InitializeComponent();
            this.user = user;
            this.client = client;
            this.baseUrl = baseUrl;
            api();
            FillFioComboBox();
            FillBirthComboBox();
        }
        public async void api()
        {
            usersDataGrid.ItemsSource = await FillDataGrid();
        }
        public async Task<List<User>> FillDataGrid()
        {
            var response = await client.GetAsync($"{baseUrl}/User");
            var content = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<User>>(content);

            var response1 = users.Where(p => p.roleId == (int)Roles.User).ToList();
            return response1;
        }
        public async void FillFioComboBox()
        {
            var response = await client.GetAsync($"{baseUrl}/User");
            var content = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<User>>(content);

            var response1 = users.Where(p => p.roleId == (int)Roles.User).ToList();
            FioComboBox.ItemsSource = response1;
        }
        public async void FillBirthComboBox()
        {
            var response = await client.GetAsync($"{baseUrl}/User");
            var content = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<User>>(content);

            var response1 = users.Where(p => p.roleId == (int)Roles.User).ToList();
            BirthComboBox.ItemsSource = response1;
        }

        private async void FioComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FioComboBox.SelectedItem is null) return;
            var users = await FillDataGrid();
            var response = users.Where(p=>p.fio==FioComboBox.SelectedValue.ToString());
            usersDataGrid.ItemsSource = response;
        }

        private async void BirthComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BirthComboBox.SelectedItem is null) return;
            var users = await FillDataGrid();
            var response = users.Where(p => p.birthDate == BirthComboBox.SelectedValue.ToString());
            usersDataGrid.ItemsSource = response;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            api();
            FillFioComboBox();
            FillBirthComboBox();
            TicketNumberComboBox.Text = string.Empty;
            FioComboBox.SelectedItem = null;
            BirthComboBox.SelectedItem = null;
        }

        private void CreateUserButton_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new CreateUserWindow(client,baseUrl);
            wnd.ShowDialog();
        }
    }
}
