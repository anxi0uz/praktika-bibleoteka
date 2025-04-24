using library_client.Enums;
using library_client.Models;
using library_client.Windows;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace library_client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string baseUrl = "http://localhost:5271";
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void AuthorizeButton_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            var user = new UserAuthorizeRequest { Login = loginTextBox.Text, Password = passwordTextbox.Text };
            var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/User/authorize")
            {
                Content = content
            };
            try
            {
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {

                    var responsebody = await response.Content.ReadAsStringAsync();
                    var user1 = JsonSerializer.Deserialize<User>(responsebody);

                    if (user1.roleId == (int)Roles.Admin)
                    {
                        var wnd = new AdminWindow(user1,client,baseUrl);
                        wnd.Show();
                        this.Hide();
                    }
                    else if (user1.roleId == (int)Roles.Worker)
                    {
                        var wnd = new WorkerWindow(user1, client, baseUrl);
                        wnd.Show();
                        this.Hide();
                    }
                    else if (user1.roleId == (int)Roles.User)
                    {
                        var wnd = new UserWindow(user1, client, baseUrl);
                        wnd.Show();
                        this.Hide();
                    }
                }
            }
            catch (JsonException ex)
            {
                MessageBox.Show("Логин и пароль неверны", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Ошибка в подключении");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex}");
            }
        }
    }
}
