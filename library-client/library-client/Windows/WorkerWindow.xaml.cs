using library_client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace library_client.Windows
{
    /// <summary>
    /// Логика взаимодействия для WorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : Window
    {
        private readonly User user;
        private readonly HttpClient client;
        private readonly string baseUrl;

        public WorkerWindow(User user, HttpClient client, string baseUrl)
        {
            InitializeComponent();
            this.user = user;
            this.client = client;
            this.baseUrl = baseUrl;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new MainWindow();
            wnd.Show();
            this.Close();
        }

        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new WorkerUsers(user,client,baseUrl);
            wnd.Show();
            this.Hide();
        }

        private void BooksButton_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new WorkerBooks(user,client,baseUrl);
            wnd.Show();
            this.Hide();
        }
    }
}
