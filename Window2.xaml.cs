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

        //Declare for Ticket IDs
        //cmbTicketIDSolve
        public string tid;
        //btnConfirmSolve (for logs)
        public string ticket_id, cust_name, cust_email, prob_title, problem, ass_user, solution, statdb;

        public Window2()
        {
            InitializeComponent();

            //Eto ung Server
            server = "localhost";
            database = "ticketingsystemdb";
            username = "root";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            

            //GENERATE TICKET - TICKET ID SHOW
            MySqlConnection connt = new MySqlConnection(constring);
            MySqlCommand cmdt = new MySqlCommand("Select * from tb_mainstaff order by ticket_id desc limit 1", connt);
            connt.Open();
            MySqlDataReader read_t = cmdt.ExecuteReader();
            //Assign to Ticket ID
            while (read_t.Read())
            {
                string ticketstr = read_t.GetString("ticket_id");
                int nf_ticketint = (int)Int64.Parse(ticketstr);
                int nf2_ticketint = nf_ticketint + 1;
                string st_ticketint = nf2_ticketint.ToString();
                txtID.Text = st_ticketint;
            }
            connt.Close();



            //ASSIGN TO STAFF MEMBERS
            MySqlConnection conn2 = new MySqlConnection(constring);
            MySqlCommand stf = new MySqlCommand("Select Username from empuser Where Permission!='Admin'", conn2);
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
            MySqlCommand cmd2 = new MySqlCommand("Select * from tb_mainstaff Where ass_user=@uname1 AND stat='Pending'", conn3);
            cmd2.Parameters.Add("@uname1", MySqlDbType.String).Value = uname1;
            conn3.Open();
            MySqlDataReader read_id2 = cmd2.ExecuteReader();
            //Assign to Solve Ticket ID
            while(read_id2.Read())
            {
                cmbTicketIDSolve.Items.Add(read_id2.GetString("prob_title"));
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

                //GENERATE TICKET - TICKET ID SHOW
                txtID.Clear();
                MySqlConnection connt = new MySqlConnection(constring);
                MySqlCommand cmdt = new MySqlCommand("Select * from tb_mainstaff order by ticket_id desc limit 1", connt);
                connt.Open();
                MySqlDataReader read_t = cmdt.ExecuteReader();
                //Assign to Ticket ID
                while (read_t.Read())
                {
                    string ticketstr = read_t.GetString("ticket_id");
                    int nf_ticketint = (int)Int64.Parse(ticketstr);
                    int nf2_ticketint = nf_ticketint + 1;
                    string st_ticketint = nf2_ticketint.ToString();
                    txtID.Text = st_ticketint;
                }
                connt.Close();

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
            DataGrid_Assign winassg = new DataGrid_Assign();
            winassg.Show();
            
        }
        private void btShowContent_Click(object sender, RoutedEventArgs e)
        {
            string selection = AssignString.assign_id;

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
                statdb = read_show.GetString("stat");
            }

            //Full Problem Stuff
            showprob = "Email: " + emaildb + "\n\nName of Customer: " + namedb + "\n\nProblem:\n" + cus_problemdb + "\n\nStatus: " + statdb;

            //mashoshow sa window ung problem stuff
            txtTicketID_assign.Text = selection;
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
            string selection = AssignString.assign_id;
            assignment = cmbAssign.Text;
            MessageBoxResult msgAssignment = MessageBox.Show("The Ticket " +title+" Has been assigned to User "+assignment, "Assigned");

            //SQL CONNECTION
            server = "localhost";
            database = "ticketingsystemdb";
            username = "root";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("Update tb_mainstaff Set ass_user=@assignment, stat='Pending' Where tb_mainstaff.ticket_id=@selection", conn);
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
            MySqlCommand cmd2 = new MySqlCommand("Select * from tb_mainstaff Where ass_user=@uname1 AND stat='Pending'", conn3);
            cmd2.Parameters.Add("@uname1", MySqlDbType.String).Value = uname1;
            conn3.Open();
            MySqlDataReader read_id2 = cmd2.ExecuteReader();
            //Assign to Solve Ticket ID
            while (read_id2.Read())
            {
                cmbTicketIDSolve.Items.Add(read_id2.GetString("prob_title"));
            }
            conn3.Close();


            //Para maclear ung laman
            //cmbTicketID.Text = "";
            txtTicketID_assign.Text = "";
            cmbAssign.Text = "";
            lblTicketTitle.Content = "Ticket Title";
            txtTicketProblem.Clear();

        }
        private void btnCancelAssign_Click(object sender, RoutedEventArgs e)
        {
            //Para maclear ung laman
            //cmbTicketID.Text = "";
            cmbAssign.Text = "";
            lblTicketTitle.Content = "Ticket Title";
            txtTicketProblem.Clear();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Show para sa Solve Ticket
        private void btnShowSolve_Click(object sender, RoutedEventArgs e)
        {
            string selection = cmbTicketIDSolve.Text;

            //SQL CONNECTION
            server = "localhost";
            database = "ticketingsystemdb";
            username = "root";
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("Select * from tb_mainstaff Where prob_title=@selection", conn);
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

            MySqlCommand cmd = new MySqlCommand("Update tb_mainstaff Set solution=@prob_solve,solu_by=@unames,stat=@status,solved_on=@solvetime Where tb_mainstaff.prob_title=@selection", conn);
            cmd.Parameters.Add("@prob_solve", MySqlDbType.String).Value = prob_solve;
            cmd.Parameters.Add("@selection", MySqlDbType.String).Value = selection;
            cmd.Parameters.Add("@status", MySqlDbType.String).Value = status;
            cmd.Parameters.Add("@solvetime", MySqlDbType.String).Value = solvetime;
            cmd.Parameters.Add("@unames", MySqlDbType.String).Value = unames;
            conn.Open();
            MySqlDataReader read_show = cmd.ExecuteReader();

            //Log Instance
            if (cmbStatusChange.Text == "Pending")
            {
                string pending = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");


                //Get the Data
                MySqlConnection conn0 = new MySqlConnection(constring);
                MySqlCommand cmd0 = new MySqlCommand("Select * From tb_mainstaff WHERE tb_mainstaff.prob_title=@selection", conn0);
                cmd0.Parameters.Add("@selection", MySqlDbType.String).Value = selection;
                conn0.Open();
                MySqlDataReader read_log0 = cmd0.ExecuteReader();
                while (read_log0.Read())
                {

                    ticket_id = read_log0.GetString("ticket_id");
                    cust_name = read_log0.GetString("cust_name");
                    cust_email = read_log0.GetString("cust_email");
                    prob_title = read_log0.GetString("prob_title");
                    problem = read_log0.GetString("problem");
                    ass_user = read_log0.GetString("ass_user");
                    solution = read_log0.GetString("solution");

                }


                //Add the Logs
                MySqlConnection conn1 = new MySqlConnection(constring);
                MySqlCommand cmd1 = new MySqlCommand("Insert into tb_logs (ticket_id, cust_name, cust_email, prob_title, problem, ass_user, solution, pending_on) Values (@ticket_id, @cust_name, @cust_email, @prob_title, @problem, @ass_user, @solution, @pending)", conn1);
                cmd1.Parameters.Add("@ticket_id", MySqlDbType.String).Value = ticket_id;
                cmd1.Parameters.Add("@cust_name", MySqlDbType.String).Value = cust_name;
                cmd1.Parameters.Add("@cust_email", MySqlDbType.String).Value = cust_email;
                cmd1.Parameters.Add("@prob_title", MySqlDbType.String).Value = prob_title;
                cmd1.Parameters.Add("@problem", MySqlDbType.String).Value = problem;
                cmd1.Parameters.Add("@ass_user", MySqlDbType.String).Value = ass_user;
                cmd1.Parameters.Add("@solution", MySqlDbType.String).Value = solution;
                cmd1.Parameters.Add("@pending", MySqlDbType.String).Value = pending;
                conn1.Open();
                MySqlDataReader read_log1 = cmd1.ExecuteReader();
            }

            else if (cmbStatusChange.Text == "Pending")
            {
                string solved = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");


                //Get the Data
                MySqlConnection conn0 = new MySqlConnection(constring);
                MySqlCommand cmd0 = new MySqlCommand("Select * From tb_mainstaff WHERE tb_mainstaff.prob_title=@selection", conn0);
                cmd0.Parameters.Add("@selection", MySqlDbType.String).Value = selection;
                conn0.Open();
                MySqlDataReader read_log0 = cmd0.ExecuteReader();
                while (read_log0.Read())
                {

                    ticket_id = read_log0.GetString("ticket_id");
                    cust_name = read_log0.GetString("cust_name");
                    cust_email = read_log0.GetString("cust_email");
                    prob_title = read_log0.GetString("prob_title");
                    problem = read_log0.GetString("problem");
                    ass_user = read_log0.GetString("ass_user");
                    solution = read_log0.GetString("solution");

                }


                //Add the Logs
                MySqlConnection conn1 = new MySqlConnection(constring);
                MySqlCommand cmd1 = new MySqlCommand("Insert into tb_logs (ticket_id, cust_name, cust_email, prob_title, problem, ass_user, solution, solved_on) Values (@ticket_id, @cust_name, @cust_email, @prob_title, @problem, @ass_user, @solution, @solved)", conn1);
                cmd1.Parameters.Add("@ticket_id", MySqlDbType.String).Value = ticket_id;
                cmd1.Parameters.Add("@cust_name", MySqlDbType.String).Value = cust_name;
                cmd1.Parameters.Add("@cust_email", MySqlDbType.String).Value = cust_email;
                cmd1.Parameters.Add("@prob_title", MySqlDbType.String).Value = prob_title;
                cmd1.Parameters.Add("@problem", MySqlDbType.String).Value = problem;
                cmd1.Parameters.Add("@ass_user", MySqlDbType.String).Value = ass_user;
                cmd1.Parameters.Add("@solution", MySqlDbType.String).Value = solution;
                cmd1.Parameters.Add("@solved", MySqlDbType.String).Value = solved;
                conn1.Open();
                MySqlDataReader read_log1 = cmd1.ExecuteReader();
            }




            //Messagebox para maconfirm
            MessageBoxResult mesSolved = MessageBox.Show("The Status of the Probem has been changed to "+status,"Status");

            //clear na lahat ulet
            cmbTicketIDSolve.Text = "";
            lblTicketTitleSolve.Content = "Ticket Title";
            txtTicketProblemSolve.Clear();
            txtTicketSolution.Clear();
            cmbStatusChange.Text = "";
            conn.Close();

            //Refresh Combobox
            //ASSIGN TO TICKET ID AGAIN
            cmbTicketIDSolve.Items.Clear();
            string uname1 = Uname.name;
            MySqlConnection conn3 = new MySqlConnection(constring);
            MySqlCommand cmd2 = new MySqlCommand("Select * from tb_mainstaff Where ass_user=@uname1 AND stat='Pending'", conn3);
            cmd2.Parameters.Add("@uname1", MySqlDbType.String).Value = uname1;
            conn3.Open();
            MySqlDataReader read_id2 = cmd2.ExecuteReader();
            //Assign to Solve Ticket ID
            while (read_id2.Read())
            {
                cmbTicketIDSolve.Items.Add(read_id2.GetString("prob_title"));
            }
            conn3.Close();
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
