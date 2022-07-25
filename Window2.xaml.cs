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
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {

        //For the Connection to the Database
        string server = "localhost";
        string database = "ticketingsystemdb";
        string username = "root";
        string password = "Mac&see19";

        


        string name, email, title, cus_problem;
        string namedb, emaildb, titledb, cus_problemdb;
        string assignment, prob_solve, showprob;

        public Window2()
        {
            InitializeComponent();

            //Eto ung Server wahahahha
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

            //ASSIGN TO STAFF MEMBERS
            MySqlConnection conn2 = new MySqlConnection(constring);
            MySqlCommand stf = new MySqlCommand("Select ass_user from tb_mainstaff", conn2);
            conn2.Open();
            MySqlDataReader read_assign = stf.ExecuteReader();
            //Assign to Staff Members
            while(read_assign.Read())
            {
                cmbAssign.Items.Add(read_assign.GetString("ass_user"));
            }
           
            //ASSIGN TO TICKET ID AGAIN
            MySqlConnection conn3 = new MySqlConnection(constring);
            MySqlCommand cmd2 = new MySqlCommand("Select ticket_id from tb_mainstaff", conn3);
            conn3.Open();
            MySqlDataReader read_id2 = cmd2.ExecuteReader();
            //Assign to Solve Ticket ID
            while(read_id2.Read())
            {
                cmbTicketIDSolve.Items.Add(read_id2.GetString("ticket_id"));
            }

            //ASSIGN TO SOLVE TICKET
            //Change Status to Solve Ticket ID
            cmbStatusChange.Items.Add("Pending");
            cmbStatusChange.Items.Add("Solved");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Generate Ticket
        private void btnConfirmGenerate_Click(object sender, RoutedEventArgs e)
        {
            //Eto ubg Server whahahah
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);

            //Add Column to Table

            name = txtName.Text;
            email = txtEmail.Text;
            title = txtTitle.Text;
            cus_problem = txtProblem.Text;
            string datetime = DateTime.Now.ToString("yyyy-MM-dd");
            MessageBoxResult msgSure = MessageBox.Show("The Message has been Inputted Successfully!", "Confirmation");

            //PARA MA UPDATE UNG DB
            MySqlCommand cmd = new MySqlCommand("INSERT INTO tb_mainstaff(ticket_id,cust_name,cust_email,prob_title,problem,ass_user,solution,solu_by,stat,datetime) Values(NULL,@name,@email,@title,@cus_problem,'','','','Pending',@datetime);", conn);
            cmd.Parameters.Add("@name", MySqlDbType.String).Value = name;
            cmd.Parameters.Add("@email", MySqlDbType.String).Value = email;
            cmd.Parameters.Add("@title", MySqlDbType.String).Value = title;
            cmd.Parameters.Add("@cus_problem", MySqlDbType.String).Value = cus_problem;
            cmd.Parameters.Add("@datetime", MySqlDbType.String).Value = datetime;
            conn.Open();
            MySqlDataReader read_gen = cmd.ExecuteReader();

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

            //ASSIGN TO TICKET ID AGAIN
            //remove muna nung luma syempre
            cmbTicketIDSolve.Items.Clear();
            MySqlConnection conn3 = new MySqlConnection(constring);
            MySqlCommand cmd3 = new MySqlCommand("Select ticket_id from tb_mainstaff", conn3);
            conn3.Open();
            MySqlDataReader read_id2 = cmd3.ExecuteReader();
            //Assign to Solve Ticket ID
            while (read_id2.Read())
            {
                cmbTicketIDSolve.Items.Add(read_id2.GetString("ticket_id"));
            }

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Show Ticket
        private void btShowTicketAssign_Click(object sender, RoutedEventArgs e)
        {
            string selection = this.cmbTicketID.Text;

            //SQL CONNECTION
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
        }

        private void txtTicketProblem_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtTicketSolution_TextChanged(object sender, TextChangedEventArgs e)
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
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("Update tb_mainstaff Set ass_user=@assignment Where tb_mainstaff.ticket_id=@selection", conn);
            cmd.Parameters.Add("@selection", MySqlDbType.String).Value = selection;
            cmd.Parameters.Add("@assignment", MySqlDbType.String).Value = assignment;
            conn.Open();
            MySqlDataReader read_show = cmd.ExecuteReader();

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
            }

            //Full Problem Stuff
            showprob = "Email: " + emaildb + "\n\nName of Customer: " + namedb + "\n\nProblem:\n" + cus_problemdb;

            //ung title sa db to
            lblTicketTitleSolve.Content = titledb;
            txtTicketProblemSolve.Text = showprob;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Confirm The Solve Problem
        private void btnConfirmSolve_Click(object sender, RoutedEventArgs e)
        { 
            //Eto magiging String ng Solution
            prob_solve = txtTicketSolution.Text;
            string status = cmbStatusChange.Text;
            string selection = this.cmbTicketIDSolve.Text;
            string datetime = DateTime.Now.ToString("yyyy-MM-dd");

            //SQL CONNECTION
            string constring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection conn = new MySqlConnection(constring);

            //Ayusin dapat kung sino nagsolve nito
            MySqlCommand cmd = new MySqlCommand("Update tb_mainstaff Set solution=@prob_solve,solu_by='MainStaff',stat=@status,datetime=@datetime Where tb_mainstaff.ticket_id=@selection", conn);
            cmd.Parameters.Add("@prob_solve", MySqlDbType.String).Value = prob_solve;
            cmd.Parameters.Add("@selection", MySqlDbType.String).Value = selection;
            cmd.Parameters.Add("@status", MySqlDbType.String).Value = status;
            cmd.Parameters.Add("@datetime", MySqlDbType.String).Value = datetime;
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
