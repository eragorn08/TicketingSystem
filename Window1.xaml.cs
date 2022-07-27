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
        public string password = "root";

        string name, uname, pass, cpass;
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

            name = rName.Text;
            uname = rUName.Text;
            pass = rPass.Text;
            cpass = rCPass.Text;

            if (name == "")
            {
                nname.Content = "Please Input Name";
            } 
            if (uname == "")
            {
                nuname.Content = "Please Input Username";
            }
            if (pass == "")
            {
                npass.Content = "Please Input Password";
            }
            if (cpass == "")
            {
                ncpass.Content = "Please Repeat Password";
            }
            if(name != "" && uname != "" && pass != "" && cpass != "")
            {
                if (pass == cpass)
                {
                    string datetime = DateTime.Now.ToString("yyyy-MM-dd");

                    MySqlCommand cmd = new MySqlCommand("INSERT INTO empuser(Name,Username,Password,Permission,AddedOn) Values(@name,@uname,@pass,3,@datetime);", conn);
                    cmd.Parameters.Add("@name", MySqlDbType.String).Value = name;
                    cmd.Parameters.Add("@uname", MySqlDbType.String).Value = uname;
                    cmd.Parameters.Add("@pass", MySqlDbType.String).Value = pass;
                    cmd.Parameters.Add("@datetime", MySqlDbType.String).Value = datetime;
                    conn.Open();
                    MySqlDataReader read_gen = cmd.ExecuteReader();

                    MessageBoxResult msgSure = MessageBox.Show("User Registered!", "Confirmation");
                    rName.Text = "";
                    rPass.Text = "";
                    rUName.Text = "";
                    rCPass.Text = "";
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
