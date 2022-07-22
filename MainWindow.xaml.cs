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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ticketing_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            uname.Text = "";
            passw.Password = "";
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            if(uname.Text == "123" && passw.Password == "123")
            {
                Window2 win2 = new Window2();
                win2.Show();
                this.Hide();
            }
            if(uname.Text == "123" && passw.Password != "123")
            {
                nouname.Content = "";
            }
            if (uname.Text != "123" && passw.Password == "123")
            {
                nopass.Content = "";
            }
            if (uname.Text == "")
            {
                nouname.Content = "Please Input Username";
            }
            else if(uname.Text != "123")
            {
                nouname.Content = "Wrong Username";

            }
            if (passw.Password == "")
            {
                nopass.Content = "Please Input Password";
            }
            else if(passw.Password != "123")
            {
                nopass.Content = "Wrong Password";
            }
        }
    }
}
