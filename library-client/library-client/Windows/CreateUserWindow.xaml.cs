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
        public async Task<User?> GetUserById(int id)
        {
            var response = await client.GetAsync($"{baseUrl}/User");
            var content = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<User>>(content);
            if (users is not null)
            {
                var response1 = users.Where(p => p.roleId == (int)Roles.User).ToList();
                return response1.Where(p => p.id == id).FirstOrDefault();
            }
            else return null;
        }
        public async Task<User?> GetWorkerById(int id)
        {
            var response = await client.GetAsync($"{baseUrl}/User");
            var content = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<User>>(content);
            if (users is not null)
            {
                var response1 = users.Where(p => p.roleId == (int)Roles.Worker).ToList();
                return response1.Where(p => p.id == id).FirstOrDefault();
            }
            else return null;

        }
        private async void CreateUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isChange)
            {
                if (!isWorker)
                {
                    try
                    {
                        if (PhoneTextBox.Text.Length <= 12)
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
                            MessageBox.Show("Номер телефона не может быть длиннее 12 символов");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        if (PhoneTextBox.Text.Length <= 12)
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
                        else
                        {
                            MessageBox.Show("Номер телефона не может быть длиннее 12 символов");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (isChange)
            {
                if (int.TryParse(idTextBox.Text, out int id))
                {
                    if (PhoneTextBox.Text.Length <= 12)
                    {
                        var user1 = await GetUserById(id);
                        if (user1 != null)
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
                                var response = await client.PutAsync($"{baseUrl}/User/{id}", content);
                                if (response.IsSuccessStatusCode)
                                {
                                    MessageBox.Show("Читатель обновлен");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Такого читателя не существует");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Номер телефона не может быть длиннее 12 символов");
                    }
                }
                else
                {
                    MessageBox.Show("Айдишник должен быть числом");
                }

            }
            else
            {
                if (int.TryParse(idTextBox.Text, out int id))
                {
                    if (PhoneTextBox.Text.Length <= 12)
                    {
                        var user1 = await GetWorkerById(id);
                        if (user1 != null)
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
                        else
                        {
                            MessageBox.Show("Такого сотрудника не сущесвует");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Номер телефона не может быть длинее 12 символов");
                    }
                }
                else
                {
                    MessageBox.Show("Айдишник должен быть числом");
                }
            }
        }
    }
}
