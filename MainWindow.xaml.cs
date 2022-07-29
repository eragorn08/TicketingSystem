using System;
using System.Collections.Generic;
using System.Data;
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
using MySql.Data.MySqlClient;

namespace Ticketing_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    static class Uname
    {
        public static string name;
    }

    public partial class MainWindow : Window
    {
        private string Server;
        private string Database;
        private string Username;
        public string server { get { return Server; } set { Server = value; } }
        public string database { get { return Database; } set { Database = value; } }
        public string username { get { return Username; } set { Username = value; } }
        public string password = "Eragorn110800";

        string name = Uname.name;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            uname.Text = "";
            passw.Password = "";
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            server = "localhost";
            database = "ticketingsystemdb";
            username = "root";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);

            user loginuser = new user();

            int i = 0;
            int log_perm = 0;
            loginuser.Username = uname.Text;
            loginuser.UPassword = passw.Password;
            MySqlDataReader perm;

            //Dinagdag ko to alex
            Uname.name = uname.Text;

            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from empuser where Username=@name and Password=@pass";
            cmd.Parameters.Add("@name", MySqlDbType.String).Value = loginuser.Username;
            cmd.Parameters.Add("@pass", MySqlDbType.String).Value = loginuser.UPassword;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            perm = cmd.ExecuteReader();

            while (perm.Read())
            {
                log_perm = perm.GetInt32("Permission");
            }

            if (i == 0)
            {
                MessageBoxResult msgSure = MessageBox.Show("No Account Associated with Inputted Username and Password!", "Confirmation");
            }
            else
            {
                if(log_perm == 1)
                {
                    Window4 win4 = new Window4();
                    win4.Show();
                    this.Hide();
                }
                if(log_perm == 2)
                {
                    Window2 win2 = new Window2();
                    win2.Show();
                    this.Hide();
                }
                if(log_perm == 3)
                {
                    Window3 win3 = new Window3();
                    win3.Show();
                    this.Hide();
                }
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            win1.Show();
            this.Hide();
        }
    }
}
