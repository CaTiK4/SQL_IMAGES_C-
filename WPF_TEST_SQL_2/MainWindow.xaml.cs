using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
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

namespace WPF_TEST_SQL_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int idUser;
        public MainWindow()
        {
            InitializeComponent();

            get_json();
            ent.entities = new Airport_TNSEntities13();

            dataGrid.ItemsSource = ent.entities.User.ToList();
            refresh_grid();
        }

        private void DataGridRow_Selected(object sender, RoutedEventArgs e)
        {
            var dgrow = (DataGridRow)sender;
            var context = dgrow.DataContext as User;
           // MessageBox.Show("Ena уже рядом!");

            idUser = context.id;
            tbID.Text = context.id.ToString();
            tbEmail.Text = context.email;
            tbPassword.Text = context.password;
            refresh_grid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = ent.entities.User.FirstOrDefault(x => x.id == idUser);
            user.email = tbEmail.Text;
            user.password = tbPassword.Text;
            ent.entities.SaveChanges();
            refresh_grid();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            idUser = Convert.ToInt32(tbID.Text);
            var user = ent.entities.User.FirstOrDefault(x => x.id == idUser);
            ent.entities.User.Remove(user);
            ent.entities.SaveChanges();
            refresh_grid();
        }
        private void refresh_grid()
        {
            dataGrid.ItemsSource = ent.entities.User.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.email = tbEmail.Text;
            user.password = tbNewPassword.Text;
            user.birthdate = datePickerBD.SelectedDate;
            user.idRole = Convert.ToInt32(tbNewRole.Text);

            ent.entities.User.Add(user);
            ent.entities.SaveChanges();
            refresh_grid();
        }
        private async void get_json()
        {
            string url = "https://jsonplaceholder.typicode.com/comments";
            HttpClient http = new HttpClient();

            var responce = await http.GetAsync(url);
            var responcecontent = await responce.Content.ReadAsStringAsync();

            if (responce.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<CommentsModel> commentsModels = JsonConvert.DeserializeObject<List<CommentsModel>>(responcecontent);
                apiDataGrid.ItemsSource = commentsModels;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a picture";
           
            openFileDialog.ShowDialog();

            string filepath = openFileDialog.FileName;
            string filename = System.IO.Path.GetFileName(filepath);
            string fullpath = System.IO.Path.GetFullPath("..\\Images\\") + filename;

            ent.entities.User.FirstOrDefault(x => x.id == idUser).image = "..\\Images\\" + filename;
            ent.entities.SaveChanges();
            refresh_grid();
            System.IO.File.Copy(filepath, fullpath, true);
        }
    }
}
