using MySql.Data.MySqlClient;
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

namespace Ticketing_System
{
    
    public partial class Window2 : Window
    {

        //Encapsulation For the Connection to the Database
        private string Server;
        private string Database;
        private string Username;
        public string server { get { return Server; } set { Server = value; } }
        public string database { get { return Database; } set { Database = value; } }
        public string username { get { return Username; } set { Username = value; } }
        
        public string password = "root";
        

        //Encapsulation for the Values of Input
        private string Name;
        private string Email;
        private string Title;
        private string Cus_Problem;
        public string name { get { return Name; } set { Name = value; } }
        public string email { get { return Email; } set { Email = value; } }
        public string title { get { return Title; } set { Title = value; } }
        public string cus_problem { get { return Cus_Problem; } set { Cus_Problem = value; } }

        //Encapsulation for the Vaues of Database Reads
        private string Namedb;
        private string Emaildb;
        private string Titledb;
        private string Cus_problemdb;
        private string Assignment;
        private string Prob_solve;
        private string Showprob;
        public string namedb { get { return Namedb; } set { Namedb = value; } }
        public string emaildb { get { return Emaildb; } set { Emaildb = value; } }
        public string titledb { get { return Titledb; } set { Titledb = value; } }
        public string cus_problemdb { get { return Cus_problemdb; } set { Cus_problemdb = value; } }
        public string assignment { get { return Assignment; } set { Assignment = value; } }
        public string prob_solve { get { return Prob_solve; } set { Prob_solve = value; } }
        public string showprob { get { return Showprob; } set { Showprob = value; } }

        public Window2()
        {
            InitializeComponent();

            //Eto ung Server
            server = "localhost";
            database = "ticketingsystemdb";
            username = "root";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            

            //ASSIGN TO TICKET ID
            //Selecting column from table
            MySqlCommand cmd = new MySqlCommand("Select * from tb_mainstaff", conn);
            conn.Open();
            MySqlDataReader read_id = cmd.ExecuteReader();
            //Assign to Ticket ID
            while (read_id.Read())
            {
                String TicketIDVal = read_id.GetString("ticket_id");
                cmbTicketID.Items.Add(TicketIDVal);
            }
            conn.Close();

            //ASSIGN TO STAFF MEMBERS
            MySqlConnection conn2 = new MySqlConnection(constring);
            MySqlCommand stf = new MySqlCommand("Select Username from empuser", conn2);
            conn2.Open();
            MySqlDataReader read_assign = stf.ExecuteReader();
            //Assign to Staff Members
            while(read_assign.Read())
            {
                cmbAssign.Items.Add(read_assign.GetString("Username"));
            }
            conn2.Close();

            //ASSIGN TO TICKET ID AGAIN
            string uname1 = Uname.name;
            MySqlConnection conn3 = new MySqlConnection(constring);
            MySqlCommand cmd2 = new MySqlCommand("Select * from tb_mainstaff Where ass_user=@uname1", conn3);
            cmd2.Parameters.Add("@uname1", MySqlDbType.String).Value = uname1;
            conn3.Open();
            MySqlDataReader read_id2 = cmd2.ExecuteReader();
            //Assign to Solve Ticket ID
            while(read_id2.Read())
            {
                cmbTicketIDSolve.Items.Add(read_id2.GetString("ticket_id"));
            }
            conn3.Close();

            //ASSIGN TO SOLVE TICKET
            //Change Status to Solve Ticket ID
            cmbStatusChange.Items.Add("Pending");
            cmbStatusChange.Items.Add("Solved");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Generate Ticket
        private void btnConfirmGenerate_Click(object sender, RoutedEventArgs e)
        {
            //Eto ubg Server
            server = "localhost";
            database = "ticketingsystemdb";
            username = "root";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);

            //Add Column to Table

            name = txtName.Text;
            email = txtEmail.Text;
            title = txtTitle.Text;
            cus_problem = txtProblem.Text;

            if (name == "")
            {
                MessageBox.Show("Please Enter Name First!", "Error");
            }
            else if (email == "")
            {
                MessageBox.Show("Please Enter Email First!", "Error");
            }
            else if (title == "")
            {
                MessageBox.Show("Please Enter Title First!", "Error");
            }
            else if (cus_problem == "")
            {
                MessageBox.Show("Please Enter Problem First!", "Error");
            }
            else
            {
                string datetime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                MessageBoxResult msgSure = MessageBox.Show("The Message has been Inputted Successfully!", "Confirmation");

                //PARA MA UPDATE UNG DB
                MySqlCommand cmd = new MySqlCommand("INSERT INTO tb_mainstaff(ticket_id,cust_name,cust_email,prob_title,problem,ass_user,solution,solu_by,stat,datetime,solved_on) Values(NULL,@name,@email,@title,@cus_problem,'','','','Pending',@datetime,'0000-00-00 00:00:00');", conn);
                cmd.Parameters.Add("@name", MySqlDbType.String).Value = name;
                cmd.Parameters.Add("@email", MySqlDbType.String).Value = email;
                cmd.Parameters.Add("@title", MySqlDbType.String).Value = title;
                cmd.Parameters.Add("@cus_problem", MySqlDbType.String).Value = cus_problem;
                cmd.Parameters.Add("@datetime", MySqlDbType.String).Value = datetime;
                conn.Open();
                MySqlDataReader read_gen = cmd.ExecuteReader();
                conn.Close();

                //ASSIGN TO TICKET ID
                //remove muna nung luma syempre
                cmbTicketID.Items.Clear();
                //Selecting column from table
                MySqlConnection conn2 = new MySqlConnection(constring);
                MySqlCommand cmd2 = new MySqlCommand("Select * from tb_mainstaff", conn2);
                conn2.Open();
                MySqlDataReader read_id = cmd2.ExecuteReader();
                //Assign to Ticket ID
                while (read_id.Read())
                {
                    String TicketIDVal = read_id.GetString("ticket_id");
                    cmbTicketID.Items.Add(TicketIDVal);
                }
                conn2.Close();

                txtName.Text = "";
                txtEmail.Text = "";
                txtTitle.Text = "";
                txtProblem.Text = "";
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Show Ticket
        private void btShowTicketAssign_Click(object sender, RoutedEventArgs e)
        {
            string selection = this.cmbTicketID.Text;

            //SQL CONNECTION
            server = "localhost";
            database = "ticketingsystemdb";
            username = "root";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("Select * from tb_mainstaff Where ticket_id=@selection", conn);
            cmd.Parameters.Add("@selection", MySqlDbType.String).Value = selection;
            conn.Open();
            MySqlDataReader read_show = cmd.ExecuteReader();
           
            //Dito nya kukunin ung mga laman nung stuff :)
            while(read_show.Read())
            {
                titledb = read_show.GetString("prob_title");
                emaildb = read_show.GetString("cust_email");
                namedb = read_show.GetString("cust_name");
                cus_problemdb = read_show.GetString("problem");
            }

            //Full Problem Stuff
            showprob = "Email: " + emaildb + "\n\nName of Customer: " + namedb + "\n\nProblem:\n" + cus_problemdb;

                //mashoshow sa window ung problem stuff
                txtTicketProblem.Text = showprob;
                lblTicketTitle.Content = titledb;
            conn.Close();
        }

        private void txtTicketProblem_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtTicketSolution_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cmbTicketIDSolve_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Assign Ticket
        private void btnAssign_Click(object sender, RoutedEventArgs e)
        {
            //To Assign
            string selection = this.cmbTicketID.Text;
            assignment = cmbAssign.Text;
            MessageBoxResult msgAssignment = MessageBox.Show("The Ticket " +title+" Has been assigned to User "+assignment, "Assigned");

            //SQL CONNECTION
            server = "localhost";
            database = "ticketingsystemdb";
            username = "root";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("Update tb_mainstaff Set ass_user=@assignment Where tb_mainstaff.ticket_id=@selection", conn);
            cmd.Parameters.Add("@selection", MySqlDbType.String).Value = selection;
            cmd.Parameters.Add("@assignment", MySqlDbType.String).Value = assignment;
            conn.Open();
            MySqlDataReader read_show = cmd.ExecuteReader();
            conn.Close();

            //Para marefresh ang data
            //ASSIGN TO TICKET ID AGAIN
            cmbTicketIDSolve.Items.Clear();
            string uname1 = Uname.name;
            MySqlConnection conn3 = new MySqlConnection(constring);
            MySqlCommand cmd2 = new MySqlCommand("Select * from tb_mainstaff Where ass_user=@uname1", conn3);
            cmd2.Parameters.Add("@uname1", MySqlDbType.String).Value = uname1;
            conn3.Open();
            MySqlDataReader read_id2 = cmd2.ExecuteReader();
            //Assign to Solve Ticket ID
            while (read_id2.Read())
            {
                cmbTicketIDSolve.Items.Add(read_id2.GetString("ticket_id"));
            }
            conn3.Close();


            //Para maclear ung laman
            cmbTicketID.Text = "";
            cmbAssign.Text = "";
            lblTicketTitle.Content = "Ticket Title";
            txtTicketProblem.Clear();
            

            


        }
        private void btnCancelAssign_Click(object sender, RoutedEventArgs e)
        {
            //Para maclear ung laman
            cmbTicketID.Text = "";
            cmbAssign.Text = "";
            lblTicketTitle.Content = "Ticket Title";
            txtTicketProblem.Clear();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Show para sa Solve Ticket
        private void btnShowSolve_Click(object sender, RoutedEventArgs e)
        {
            string selection = this.cmbTicketIDSolve.Text;

            //SQL CONNECTION
            server = "localhost";
            database = "ticketingsystemdb";
            username = "root";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("Select * from tb_mainstaff Where ticket_id=@selection", conn);
            cmd.Parameters.Add("@selection", MySqlDbType.String).Value = selection;
            conn.Open();
            MySqlDataReader read_show = cmd.ExecuteReader();

            //Dito nya kukunin ung mga laman nung stuff :)
            while (read_show.Read())
            {
                titledb = read_show.GetString("prob_title");
                emaildb = read_show.GetString("cust_email");
                namedb = read_show.GetString("cust_name");
                cus_problemdb = read_show.GetString("problem");
                txtTicketSolution.Text = read_show.GetString("solution");
                cmbStatusChange.Text = read_show.GetString("stat");
            }

            //Full Problem Stuff
            showprob = "Email: " + emaildb + "\n\nName of Customer: " + namedb + "\n\nProblem:\n" + cus_problemdb;

            //ung title sa db to
            lblTicketTitleSolve.Content = titledb;
            txtTicketProblemSolve.Text = showprob;

            conn.Close();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Confirm The Solve Problem
        private void btnConfirmSolve_Click(object sender, RoutedEventArgs e)
        { 
            //Eto magiging String ng Solution
            prob_solve = txtTicketSolution.Text;
            string status = cmbStatusChange.Text;
            string selection = this.cmbTicketIDSolve.Text;
            string solvetime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

            //SQL CONNECTION
            server = "localhost";
            database = "ticketingsystemdb";
            username = "root";
            string unames = Uname.name;
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);

            MySqlCommand cmd = new MySqlCommand("Update tb_mainstaff Set solution=@prob_solve,solu_by=@unames,stat=@status,solved_on=@solvetime Where tb_mainstaff.ticket_id=@selection", conn);
            cmd.Parameters.Add("@prob_solve", MySqlDbType.String).Value = prob_solve;
            cmd.Parameters.Add("@selection", MySqlDbType.String).Value = selection;
            cmd.Parameters.Add("@status", MySqlDbType.String).Value = status;
            cmd.Parameters.Add("@solvetime", MySqlDbType.String).Value = solvetime;
            cmd.Parameters.Add("@unames", MySqlDbType.String).Value = unames;
            conn.Open();
            MySqlDataReader read_show = cmd.ExecuteReader();




            //add to logs na database to
            Console.WriteLine("The Problem of:\n " + showprob + "\n\nis solved by this Solution:\n" + prob_solve + "\n\nWith Status: " + status + "\n\nBy user: " + assignment);

            //Messagebox para maconfirm
            MessageBoxResult mesSolved = MessageBox.Show("The Status of the Probem has been changed to "+status,"Status");

            //clear na lahat ulet
            cmbTicketIDSolve.Text = "";
            lblTicketTitleSolve.Content = "Ticket Title";
            txtTicketProblemSolve.Clear();
            txtTicketSolution.Clear();
            cmbStatusChange.Text = "";
            conn.Close();
        }
        private void btnCancelSolve_Click(object sender, RoutedEventArgs e)
        {
            //clear na lahat ulet
            cmbTicketIDSolve.Text = "";
            lblTicketTitleSolve.Content = "Ticket Title";
            txtTicketProblemSolve.Clear();
            txtTicketSolution.Clear();
            cmbStatusChange.Text = "";
        }

        private void cmbTicketID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
   
        }

        private void btnCancelGenerate_Click(object sender, RoutedEventArgs e)
        {
            txtName.Clear();
            txtEmail.Clear();
            txtTitle.Clear();
            txtProblem.Clear();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mwin = new MainWindow();
            mwin.Show();
            this.Hide();
        }

    }
}
