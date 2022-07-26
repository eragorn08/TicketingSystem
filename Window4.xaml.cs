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

            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
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
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `tb_mainstaff` GROUP BY stat", conn);
            conn.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "loaddatabinding");
            dgOaR.DataContext = ds;
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

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mn = new MainWindow();
            mn.Show();
            this.Hide();
        }
    }
}