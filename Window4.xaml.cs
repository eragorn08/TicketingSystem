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
        string server = "localhost";
        string database = "ticketingsystemdb";
        string username = "root";
        string password = "Mac&see19";

        public Window4()
        {
            InitializeComponent();
            FillcomboUser();
        }
        void FillcomboUser()
        {
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("Select * from empuser", conn);
            conn.Open();
            MySqlDataReader read_id = cmd.ExecuteReader();

            while (read_id.Read())
            {
                String empname = read_id.GetString("Name");
                cbUser.Items.Add(empname);
            }
        }

        private void bSLA_Click(object sender, RoutedEventArgs e)
        {
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
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(ticket_id) AS Number_of_Tickets, ass_user, stat FROM `tb_mainstaff` GROUP BY stat", conn);
            conn.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "loaddatabinding");
            dgNoT.DataContext = ds;
        }

        private void bOaR_Click(object sender, RoutedEventArgs e)
        {
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

            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("Update empuser Set Permission=@sPermission Where empuser.Name=@selection", conn);
            cmd.Parameters.Add("@selection", MySqlDbType.String).Value = selection;
            cmd.Parameters.Add("@sPermission", MySqlDbType.String).Value = sPermission;

            conn.Open();
            MySqlDataReader read_id = cmd.ExecuteReader();

            MessageBoxResult mesSolved = MessageBox.Show("The User permission has been changed to " + sPermission);

            MySqlConnection conn2 = new MySqlConnection(constring);
            MySqlCommand cmd2 = new MySqlCommand("Select EmpID, Name, Username, Password, Permission, AddedOn From empuser", conn2);
            conn2.Open();
            MySqlDataAdapter adp2 = new MySqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2, "loaddatabinding");
            dgUser.DataContext = ds2;
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