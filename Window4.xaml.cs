using MySql.Data.MySqlClient;
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
using System.Windows.Shapes;

namespace Ticketing_System
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        private string Server;
        private string Database;
        private string Username;
        public string server { get { return Server; } set { Server = value; } }
        public string database { get { return Database; } set { Database = value; } }
        public string username { get { return Username; } set { Username = value; } }
        public string password = "root";

        public Window4()
        {
            InitializeComponent();
            FillcomboUser();
        }
        void FillcomboUser()
        {
            server = "localhost";
            database = "ticketingsystemdb";
            username = "root";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("Select * from empuser", conn);
            conn.Open();
            MySqlDataReader read_id = cmd.ExecuteReader();

            while (read_id.Read())
            {
                String username = read_id.GetString("Username");
                cbUser.Items.Add(username);
            }
        }

        private void bSLA_Click(object sender, RoutedEventArgs e)
        {
            server = "localhost";
            database = "ticketingsystemdb";
            username = "root";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("Select ticket_id, cust_email, prob_title, ass_user, solution, solu_by, stat, datetime From tb_mainstaff", conn);
            conn.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "loaddatabinding");
            dgSLA.DataContext = ds;
        }

        private void bNoT_Click(object sender, RoutedEventArgs e)
        {
            server = "localhost";
            database = "ticketingsystemdb";
            username = "root";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(ticket_id) AS Number_of_Tickets, ass_user, stat FROM `tb_mainstaff` GROUP BY ass_user", conn);
            conn.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "loaddatabinding");
            dgNoT.DataContext = ds;
        }

        private void bOaR_Click(object sender, RoutedEventArgs e)
        {
            server = "localhost";
            database = "ticketingsystemdb";
            username = "root";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("Select ticket_id, cust_name, cust_email, prob_title, problem, ass_user, solution, solu_by, stat, datetime From tb_mainstaff Where stat= 'Solved'", conn);
            conn.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "loaddatabinding");
            dgOaR.DataContext = ds;
            conn.Close();

            MySqlConnection conn2 = new MySqlConnection(constring);
            MySqlCommand cmd2 = new MySqlCommand("Select ticket_id, cust_name, cust_email, prob_title, problem, ass_user, solution, solu_by, stat, datetime From tb_mainstaff Where stat= 'Pending'", conn2);
            conn2.Open();
            MySqlDataAdapter adp2 = new MySqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2, "loaddatabinding");
            dgOaR2.DataContext = ds2;
            conn2.Close();

        }
        private void bUser_LoadTable_Click(object sender, RoutedEventArgs e)
        {
            server = "localhost";
            database = "ticketingsystemdb";
            username = "root";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("Select EmpID, Name, Username, Password, Permission, AddedOn From empuser", conn);
            conn.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "loaddatabinding");
            dgUser.DataContext = ds;
        }
        private void bUserConfirm_Click(object sender, RoutedEventArgs e)
        {
            string selection = this.cbUser.Text;
            string sPermission = cbPermission.Text;

            server = "localhost";
            database = "ticketingsystemdb";
            username = "root";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("Update empuser Set Permission=@sPermission Where empuser.Name=@selection", conn);
            cmd.Parameters.Add("@selection", MySqlDbType.String).Value = selection;
            cmd.Parameters.Add("@sPermission", MySqlDbType.String).Value = sPermission;

            conn.Open();
            MySqlDataReader read_id = cmd.ExecuteReader();

            

            MySqlConnection conn2 = new MySqlConnection(constring);
            MySqlCommand cmd2 = new MySqlCommand("Select EmpID, Name, Username, Password, Permission, AddedOn From empuser", conn2);
            conn2.Open();
            MySqlDataAdapter adp2 = new MySqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2, "loaddatabinding");
            dgUser.DataContext = ds2;

            if (cbPermission.Text == sPermission)
            {
                MessageBox.Show("It is alread in permission "+ sPermission);
            }
            else
            {
                MessageBoxResult mesSolved = MessageBox.Show("The User permission has been changed to " + sPermission);
            }

            cbUser.Text = "";
            cbPermission.Text = "";
        }

        private void dgOaR_CellDoubleClick(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = (DataRowView)dgOaR.SelectedItems[0];
            string r = (string)row["ticket_id"];

            Console.WriteLine(r);
        }
        private void dgSLA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void dgNoT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgOaR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void cbUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void cbPermission_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mn = new MainWindow();
            mn.Show();
            this.Hide();
        }

        private void dgUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgOaR2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}