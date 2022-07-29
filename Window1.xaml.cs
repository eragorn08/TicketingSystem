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
using MySql.Data.MySqlClient;

namespace Ticketing_System
{
    public partial class Window1 : Window
    {
        //SQL Status
        //Encapsulation
        private string Server;
        private string Database;
        private string Username;
        public string server { get { return Server; } set { Server = value; } }
        public string database { get { return Database; } set { Database = value; } }
        public string username { get { return Username; } set { Username = value; } }
        public string password = "Mac&see19";

        string cpass;
        public Window1()
        {
            InitializeComponent();
            string server = "localhost";
            string database = "ticketingsystemdb";
            string username = "root";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);

        }

        private void _return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwin = new MainWindow();
            mainwin.Show();
            this.Hide();
        }
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            rName.Text = "";
            rPass.Text = "";
            rUName.Text = "";
            rCPass.Text = "";
        }
        private void reg_Click(object sender, RoutedEventArgs e)
        {
            server = "localhost";
            database = "ticketingsystemdb";
            username = "root";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            user registeruser = new user();
            registeruser.Name = rName.Text;
            registeruser.Username = rUName.Text;
            registeruser.UPassword = rPass.Text;
            cpass = rCPass.Text;

            if (registeruser.Name == "")
            {
                nname.Content = "Please Input Name";
            } else
            {
                nname.Content = "";
            }
            if (registeruser.Username == "")
            {
                nuname.Content = "Please Input Username";
            }else
            {
                nuname.Content = "";
            }
            if (registeruser.UPassword == "")
            {
                npass.Content = "Please Input Password";
            }else
            {
                npass.Content = "";
            }
            if (cpass == "")
            {
                ncpass.Content = "Please Repeat Password";
            }else
            {
                ncpass.Content = "";
            }
            if (registeruser.Name != "" && registeruser.Username != "" && registeruser.UPassword != "" && cpass != "")
            {
                if (registeruser.UPassword == cpass)
                {
                    string datetime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

                    MySqlCommand cmd = new MySqlCommand("INSERT INTO empuser(Name,Username,Password,Permission,AddedOn) Values(@name,@uname,@pass,3,@datetime);", conn);
                    cmd.Parameters.Add("@name", MySqlDbType.String).Value = registeruser.Name;
                    cmd.Parameters.Add("@uname", MySqlDbType.String).Value = registeruser.Username;
                    cmd.Parameters.Add("@pass", MySqlDbType.String).Value = registeruser.UPassword;
                    cmd.Parameters.Add("@datetime", MySqlDbType.String).Value = datetime;
                    conn.Open();
                    MySqlDataReader read_gen = cmd.ExecuteReader();

                    MessageBoxResult msgSure = MessageBox.Show("User Registered!", "Confirmation");
                    rName.Text = "";
                    rPass.Text = "";
                    rUName.Text = "";
                    rCPass.Text = "";

                    MainWindow mainwin = new MainWindow();
                    mainwin.Show();
                    this.Hide();
                }
                else
                {
                    MessageBoxResult msgSure = MessageBox.Show("Password is not the same with Confirm Password", "Confirmation");

                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void rUName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void rPass_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void rCPass_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}
