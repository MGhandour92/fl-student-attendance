using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_8_Attendance
{
    public partial class Home_LoggedIn : Form
    {
        public Home_LoggedIn()
        {
            InitializeComponent();
        }

        //When Form Loads
        private void Home_LoggedIn_Load(object sender, EventArgs e)
        {
            label1.Text += Home.UserName + " !";
        }

        private void logOutLB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Hide the Current form
            Hide();

            //Go to the next form
            Home HomePage = new Home();
            HomePage.Show();

            //This will close the old form
            HomePage.Closed += (s, args) => Close();
            HomePage.Show();
        }
    }
}
