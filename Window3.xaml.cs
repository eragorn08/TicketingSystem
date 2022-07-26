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
    public partial class Window3 : Window
    {
        string server = "localhost";
        string database = "ticketingsystemdb";
        string username = "root";
        string password = "Mac&see19";

        string titledb, cus_problemdb;
        private object read_show;
        string namepass = Uname.name;

        public Window3()
        {
            InitializeComponent();
            Fillcombo();

        }
        void Fillcombo()
        {
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("Select * from tb_mainstaff Where ass_user=@namepass", conn);
            cmd.Parameters.Add("@namepass", MySqlDbType.String).Value = namepass;
            conn.Open();
            MySqlDataReader read_id = cmd.ExecuteReader();

            while (read_id.Read())
            {
                String TicketIDs = read_id.GetString("ticket_id");
                cbTicketID.Items.Add(TicketIDs);
            }
        }
        private void bShow_Click(object sender, RoutedEventArgs e)
        {
            string selection = this.cbTicketID.Text;

            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("Select * from tb_mainstaff Where ticket_id=@selection", conn);
            cmd.Parameters.Add("@selection", MySqlDbType.String).Value = selection;
            conn.Open();
            MySqlDataReader read_id = cmd.ExecuteReader();

            while (read_id.Read())
            {
                titledb = read_id.GetString("prob_title");
                cus_problemdb = read_id.GetString("problem");
                tbSolution.Text = read_id.GetString("solution");

            }

            tbProblemTitle.Text = titledb;
            tbProblem.Text = cus_problemdb;
        }

        private void bConfirm_Click(object sender, RoutedEventArgs e)
        {
            string selection = this.cbTicketID.Text;
            string sSolution = tbSolution.Text;
            string sStatus = cbStatus.Text;
            string sDateTime = DateTime.Now.ToString("yyyy-MM-dd");

            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("Update tb_mainstaff Set solution=@sSolution,solu_by=@namepass,stat=@sStatus,datetime=@sDateTime Where tb_mainstaff.ticket_id=@selection", conn);
            cmd.Parameters.Add("@selection", MySqlDbType.String).Value = selection;
            cmd.Parameters.Add("@sSolution", MySqlDbType.String).Value = sSolution;
            cmd.Parameters.Add("@sStatus", MySqlDbType.String).Value = sStatus;
            cmd.Parameters.Add("@sDateTime", MySqlDbType.String).Value = sDateTime;
            cmd.Parameters.Add("@namepass", MySqlDbType.String).Value = namepass;
            conn.Open();
            MySqlDataReader read_id = cmd.ExecuteReader();

            MessageBoxResult mesSolved = MessageBox.Show("The Status of the Probem has been changed to " + sStatus, "Status");

            cbTicketID.Text = "";
            tbProblemTitle.Text = "Problem Title";
            tbProblem.Text = "";
            tbSolution.Text = "";
            cbStatus.Text = "";
        }



        private void tbSolution_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cbTicketID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mn = new MainWindow();
            mn.Show();
            this.Hide();
        }

        private void cbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
