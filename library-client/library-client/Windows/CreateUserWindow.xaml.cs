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
    /// Логика взаимодействия для CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        private readonly HttpClient client;
        private readonly string baseUrl;
        private readonly bool isChange;
        private readonly bool isWorker;

        public CreateUserWindow(HttpClient client, string baseUrl, bool isChange, bool isWorker)
        {
            InitializeComponent();
            this.client = client;
            this.baseUrl = baseUrl;
            this.isChange = isChange;
            this.isWorker = isWorker;
            if (isChange)
            {
                idlabel.Visibility = Visibility.Visible;
                idTextBox.Visibility = Visibility.Visible;
            }
        }

        private async void CreateUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isChange)
            {
                if (!isWorker)
                {
                    var user = new User2()
                    {
                        adress = AdressTextBox.Text,
                        birthday = BirthTextBox.Text,
                        phone = PhoneTextBox.Text,
                        fio = FioTextBox.Text,
                        login = LoginTextBox.Text,
                        password = PasswordTextbox.Text,
                        role = (int)Roles.User,
                    };
                    var userJson = JsonSerializer.Serialize(user);
                    var content = new StringContent(userJson, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{baseUrl}/User", content);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Читатель добавлен!");
                    }
                }
                else
                {
                    var user = new User2()
                    {
                        adress = AdressTextBox.Text,
                        birthday = BirthTextBox.Text,
                        phone = PhoneTextBox.Text,
                        fio = FioTextBox.Text,
                        login = LoginTextBox.Text,
                        password = PasswordTextbox.Text,
                        role = (int)Roles.Worker,
                    };
                    var userJson = JsonSerializer.Serialize(user);
                    var content = new StringContent(userJson, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{baseUrl}/User", content);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Сотрудник добавлен!");
                    }
                }
            }
            else if (isChange)
            {
                if (!isWorker)
                {
                    var user = new User2()
                    {
                        adress = AdressTextBox.Text,
                        birthday = BirthTextBox.Text,
                        phone = PhoneTextBox.Text,
                        fio = FioTextBox.Text,
                        login = LoginTextBox.Text,
                        password = PasswordTextbox.Text,
                        role = (int)Roles.User,
                    };
                    var userJson = JsonSerializer.Serialize(user);
                    var content = new StringContent(userJson, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync($"{baseUrl}/User/{idTextBox.Text}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Читатель обновлен");
                    }
                }
                else
                {
                    var user = new User2()
                    {
                        adress = AdressTextBox.Text,
                        birthday = BirthTextBox.Text,
                        phone = PhoneTextBox.Text,
                        fio = FioTextBox.Text,
                        login = LoginTextBox.Text,
                        password = PasswordTextbox.Text,
                        role = (int)Roles.Worker,
                    };
                    var userJson = JsonSerializer.Serialize(user);
                    var content = new StringContent(userJson, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync($"{baseUrl}/User/{idTextBox.Text}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Сотрудник обновлен");
                    }
                }
            }
        }
    }
}
