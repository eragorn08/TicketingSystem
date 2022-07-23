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

        string name, email, title, cus_problem;
        string assignment, prob_solve, showprob;

        public Window2()
        {
            InitializeComponent();

            //Kailangan naka loop to based sa db
            //Assign to Ticket ID
            cmbTicketID.Items.Add("001");

            //Assign to Staff Members
            cmbAssign.Items.Add("Main Staff");

            //Assign to Solve Ticket ID
            cmbTicketIDSolve.Items.Add("001");

            //Change Status to Solve Ticket ID
            cmbStatusChange.Items.Add("Pending");
            cmbStatusChange.Items.Add("Solved");
        }

        //Generate Ticket
        private void btnConfirmGenerate_Click(object sender, RoutedEventArgs e)
        {
            name = txtName.Text;
            email = txtEmail.Text;
            title = txtTitle.Text;
            cus_problem = txtProblem.Text;
            MessageBoxResult msgSure = MessageBox.Show("The Message has been Inputted Successfully!", "Confirmation");

            //Instead of Writeline, ang nandito dapat is iiinput sa db
            Console.WriteLine("Name: " + name + "\nEmail: " + email + "\nProblem Title: " + title + "\nProblem Content: " + cus_problem);
        }

        //Show Ticket
        private void btShowTicketAssign_Click(object sender, RoutedEventArgs e)
        {
            string selection = this.cmbTicketID.Text;

            //if selection == to value sa db dapat, hindi lang 1
            if (selection == "001")
            {
                //show contents ng Db sana to.
                showprob = "Email: " + email + "\nName of Customer: " + name + "\nProblem:\n" + cus_problem;

                //mashoshow sa window ung problem stuff
                txtTicketProblem.Text = showprob;
                lblTicketTitle.Content = title;
            }
        }

        //Assign Ticket
        private void btnAssign_Click(object sender, RoutedEventArgs e)
        {
            //To Assign
            assignment = cmbAssign.Text;
            MessageBoxResult msgAssignment = MessageBox.Show("The Ticket " +title+" Has been assigned to User "+assignment, "Assigned");
            //kulang pa to since di ko alam pano mag assign dapat may db

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

        //Show para sa Solve Ticket
        private void btnShowSolve_Click(object sender, RoutedEventArgs e)
        {
            string selection = this.cmbTicketIDSolve.Text;

            //if selection == to value sa db dapat, hindi lang 1
            if (selection == "001")
            {
                //show contents ng Db sana to.
                showprob = "Email: " + email + "\nName of Customer: " + name + "\nProblem:\n" + cus_problem;

                //ung title sa db to
                lblTicketTitleSolve.Content = title;
                txtTicketProblemSolve.Text = showprob;
            }
        }
        //Confirm The Solve Problem
        private void btnConfirmSolve_Click(object sender, RoutedEventArgs e)
        {
            //Eto magiging String ng Solution
            prob_solve = txtTicketSolution.Text;
            string status = cmbStatusChange.Text;

            //add to db instead of print to
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
