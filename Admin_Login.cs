using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayubo_Drive
{
    public partial class Admin_Login : Form
    {
        public Admin_Login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (userName.Text == "Admin" && password.Text == "admin")
            {
                Admin_dashboard adm = new Admin_dashboard();
                adm.Show();
                this.Hide();
            }
            else if (userName.Text == "Admin" && password.Text == "")
            {
                MessageBox.Show ("Password not entered");
            }

             else if (userName.Text == "" && password.Text == "admin")
            {
                MessageBox.Show ("Username not entered");
            }
             else if (userName.Text == "" && password.Text == "")
            {
                MessageBox.Show ("Enter UserName and Password");
            }
            else
            {
                MessageBox.Show("Enter the Correct Username or Password");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Login_dashboard lgd = new Login_dashboard();
            lgd.Show();
            this.Hide();
        }
    }
}
