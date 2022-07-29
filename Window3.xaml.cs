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
        //Encapsulation
        private string Server;
        private string Database;
        private string Username;
        public string server { get { return Server; } set { Server = value; } }
        public string database { get { return Database; } set { Database = value; } }
        public string username { get { return Username; } set { Username = value; } }
        public string password = "Mac&see19";

        private string Titledb;
        private string Cus_problemdb;

        public string titledb{ get { return Titledb; } set { Titledb = value; } }
        public string cus_problemdb { get { return Cus_problemdb; } set { Cus_problemdb = value; } }

        private object read_show;
        string namepass = Uname.name;

        public Window3()
        {
            InitializeComponent();
            Fillcomboticket();
        }
        void Fillcomboticket()
        {
            server = "localhost";
            database = "ticketingsystemdb";
            username = "root";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("Select * from tb_mainstaff WHERE ass_user=@namepass", conn);
            cmd.Parameters.Add("@namepass", MySqlDbType.String).Value = namepass;
            conn.Open();
            MySqlDataReader read_id = cmd.ExecuteReader();

            while (read_id.Read())
            {
                String TicketIDs = read_id.GetString("ticket_id");
                cbTicketID.Items.Add(TicketIDs);
            }
            conn.Close();
        }




        private void bShow_Click(object sender, RoutedEventArgs e)
        {
            string selection = this.cbTicketID.Text;

            server = "localhost";
            database = "ticketingsystemdb";
            username = "root";
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
                cbStatus.Text = read_id.GetString("stat");
            }

            tbProblemTitle.Text = titledb;
            tbProblem.Text = cus_problemdb;
            conn.Close();
        }

        private void bConfirm_Click(object sender, RoutedEventArgs e)
        {
            string selection = this.cbTicketID.Text;
            string sSolution = tbSolution.Text;
            string sStatus = cbStatus.Text;
            string sSolveTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

            server = "localhost";
            database = "ticketingsystemdb";
            username = "root";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("Update tb_mainstaff Set solution=@sSolution,solu_by=@namepass,stat=@sStatus,solved_on=@sSolveTime Where tb_mainstaff.ticket_id=@selection", conn);
            cmd.Parameters.Add("@selection", MySqlDbType.String).Value = selection;
            cmd.Parameters.Add("@sSolution", MySqlDbType.String).Value = sSolution;
            cmd.Parameters.Add("@sStatus", MySqlDbType.String).Value = sStatus;
            cmd.Parameters.Add("@sSolveTime", MySqlDbType.String).Value = sSolveTime;
            cmd.Parameters.Add("@namepass", MySqlDbType.String).Value = namepass;
            conn.Open();
            MySqlDataReader read_id = cmd.ExecuteReader();

            MessageBoxResult mesSolved = MessageBox.Show("The Status of the Probem has been changed to " + sStatus, "Status");

            cbTicketID.Text = "";
            tbProblemTitle.Text = "Problem Title";
            tbProblem.Text = "";
            tbSolution.Text = "";
            cbStatus.Text = "";
            conn.Close();
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
