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
    public partial class Admin_dashboard : Form
    {
        public Admin_dashboard()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Login_dashboard lg1 = new Login_dashboard();
            lg1.Show();
            this.Hide();
        }

        private void receptionButton_Click(object sender, EventArgs e)
        {
            Reception_Form rfm = new Reception_Form();
            rfm.Show();
            this.Hide();
        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            Customer_Form csf = new Customer_Form();
            csf.Show();
            this.Hide();
        }

        private void driverButton_Click(object sender, EventArgs e)
        {
            Driver_Form drf = new Driver_Form();
            drf.Show();
            this.Hide();
        }

        private void vehicleButton_Click(object sender, EventArgs e)
        {
            Vehicle_Form vef = new Vehicle_Form();
            vef.Show();
            this.Hide();
        }
    }
}
