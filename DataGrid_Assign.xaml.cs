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
    /// Interaction logic for DataGrid_Assign.xaml
    /// </summary>
    /// 

    //Class for Assign
    public static class AssignString
    {
        public static string assign_id;
    }

    public partial class DataGrid_Assign : Window
    {

        


        //Encapsulation For the Connection to the Database
        private string Server;
        private string Database;
        private string Username;
        public string server { get { return Server; } set { Server = value; } }
        public string database { get { return Database; } set { Database = value; } }
        public string username { get { return Username; } set { Username = value; } }

        public string password = "root";
        
        public DataGrid_Assign()
        {
            InitializeComponent();

            server = "localhost";
            database = "ticketingsystemdb";
            username = "root";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";"+"Convert Zero Datetime=True;";
            // Data Grid for Assigning Ticket (Pending)
            MySqlConnection conn = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("Select ticket_id, cust_name, cust_email, prob_title, datetime, stat From tb_mainstaff where stat='Pending'", conn);
            conn.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "loaddatabinding");
            dgAssign.DataContext = ds;
            conn.Close();

            // Data Grid for Assigning Ticket (ReAssign)
            MySqlConnection conn2 = new MySqlConnection(constring);
            MySqlCommand cmd2 = new MySqlCommand("Select * From tb_mainstaff where stat='Solved'", conn2);
            conn2.Open();
            MySqlDataAdapter adp2 = new MySqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2, "loaddatabinding");
            dgReAssign.DataContext = ds2;
            conn.Close();
        }

        private void dgAssign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgReAssign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnShow_Unsolved_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowSelected = dgAssign.SelectedItem as DataRowView;
            if (rowSelected != null)
            {

                AssignString.assign_id = rowSelected["ticket_id"].ToString();
            }
            this.Close();
        }

        private void btnShow_ReAssign_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowSelected = dgReAssign.SelectedItem as DataRowView;
            if (rowSelected != null)
            {

                AssignString.assign_id = rowSelected["ticket_id"].ToString();
            }
            this.Close();
        }
    }
}
