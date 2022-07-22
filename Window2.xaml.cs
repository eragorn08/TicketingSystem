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
        public Window2()
        {
            InitializeComponent();
        }
        

        //Generate Ticket
        private void btnConfirmGenerate_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string title = txtTitle.Text;
            string cus_problem = txtProblem.Text;

            
        }

        private void btnCancelGenerate_Click(object sender, RoutedEventArgs e)
        {
            txtName.Clear();
            txtEmail.Clear();
            txtTitle.Clear();
            txtProblem.Clear();
        }
    }
}
