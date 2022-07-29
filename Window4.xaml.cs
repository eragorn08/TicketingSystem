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

            server = "localhost";
            database = "ticketingsystemdb";
            username = "root";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";

            // SLA Compliance Data Grid
            MySqlConnection conn = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("Select ticket_id, cust_email, prob_title, ass_user, solution, solu_by, stat, datetime From tb_mainstaff", conn);
            conn.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "loaddatabinding");
            dgSLA.DataContext = ds;
            conn.Close();

            // Number of Tickets Data Grid
            MySqlConnection conn1 = new MySqlConnection(constring);
            MySqlCommand cmd1 = new MySqlCommand("SELECT COUNT(ticket_id) AS Number_of_Tickets, ass_user, stat FROM `tb_mainstaff` GROUP BY ass_user", conn1);
            conn.Open();
            MySqlDataAdapter adp1 = new MySqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1, "loaddatabinding");
            dgNoT.DataContext = ds1;
            conn1.Close();

            // Open and Resolved Tickets Data Grid
            MySqlConnection conn2 = new MySqlConnection(constring);
            MySqlCommand cmd2 = new MySqlCommand("Select ticket_id, cust_name, cust_email, prob_title, problem, ass_user, solution, solu_by, stat, datetime From tb_mainstaff Where stat='Solved'", conn2);
            conn2.Open();
            MySqlDataAdapter adp2 = new MySqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2, "loaddatabinding");
            dgOaR.DataContext = ds2;
            conn2.Close();

            // Open and Resolved Tickets 2 Data Grid
            MySqlConnection conn3 = new MySqlConnection(constring);
            MySqlCommand cmd3 = new MySqlCommand("Select ticket_id, cust_name, cust_email, prob_title, problem, ass_user, solution, solu_by, stat, datetime From tb_mainstaff Where stat='Pending'", conn3);
            conn3.Open();
            MySqlDataAdapter adp3 = new MySqlDataAdapter(cmd3);
            DataSet ds3 = new DataSet();
            adp3.Fill(ds3, "loaddatabinding");
            dgOaR2.DataContext = ds3;
            conn3.Close();

            // User Date Grid
            MySqlConnection conn4 = new MySqlConnection(constring);
            MySqlCommand cmd4 = new MySqlCommand("Select EmpID, Name, Username, Password, Permission, AddedOn From empuser", conn4);
            conn4.Open();
            MySqlDataAdapter adp4 = new MySqlDataAdapter(cmd4);
            DataSet ds4 = new DataSet();
            adp4.Fill(ds4, "loaddatabinding");
            dgUser.DataContext = ds4;
            conn4.Close();

            // User Combo Box
            MySqlConnection conn5 = new MySqlConnection(constring);
            MySqlCommand cmd5 = new MySqlCommand("Select * from empuser", conn5);
            conn5.Open();
            MySqlDataReader read_id = cmd5.ExecuteReader();

            while (read_id.Read())
            {
                String username = read_id.GetString("Username");
                cbUser.Items.Add(username);
            }
            conn5.Close();
        }
        private void bUserConfirm_Click(object sender, RoutedEventArgs e)
        {
            string selection = cbUser.Text;
            string sPermission = cbPermission.Text;
            string Permission;

            if (cbUser.Text == "")
            {
                MessageBox.Show("You forgot to choose a User. Please try again", "Failed");
            }
            else
            {

                string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";

                MySqlConnection conn = new MySqlConnection(constring);
                MySqlCommand cmd = new MySqlCommand("Select * from empuser where Username=@selection", conn);
                cmd.Parameters.Add("@selection", MySqlDbType.String).Value = selection;
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                Permission = reader.GetString("Permission");

                if (cbUser.Text == "")
                {
                    MessageBox.Show("You forgot to choose a User. Please try again", "Failed");
                }
                else if (cbPermission.Text == "")
                {
                    MessageBox.Show("You forgot to choose the Permission. Please try again", "Failed");
                }
                else if (cbPermission.Text == Permission)
                {
                    MessageBox.Show("The Permission of " + cbUser.Text + " is already set to " + Permission, "Failed");
                }
                else
                {
                    // Update Database
                    MySqlConnection conn1 = new MySqlConnection(constring);
                    MySqlCommand cmd1 = new MySqlCommand("Update empuser Set Permission=@sPermission Where empuser.Username=@selection", conn1);
                    cmd1.Parameters.Add("@selection", MySqlDbType.String).Value = selection;
                    cmd1.Parameters.Add("@sPermission", MySqlDbType.String).Value = sPermission;
                    conn1.Open();
                    MySqlDataReader read_id1 = cmd1.ExecuteReader();
                    conn1.Close();

                    MessageBox.Show("The Permission of " + cbUser.Text + " is changed to " + cbPermission.Text, "Sucess");
                }
                // Update User Data Grid
                MySqlConnection conn2 = new MySqlConnection(constring);
                MySqlCommand cmd2 = new MySqlCommand("Select EmpID, Name, Username, Password, Permission, AddedOn From empuser", conn2);
                conn2.Open();
                MySqlDataAdapter adp2 = new MySqlDataAdapter(cmd2);
                DataSet ds2 = new DataSet();
                adp2.Fill(ds2, "loaddatabinding");
                dgUser.DataContext = ds2;
                conn2.Close();

                cbUser.Text = "";
                cbPermission.Text = "";
            }
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void dgSLA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void dgNoT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void dgOaR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void dgOaR2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void cbUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void cbPermission_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void dgUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mn = new MainWindow();
            mn.Show();
            this.Hide();
        }
    }
}