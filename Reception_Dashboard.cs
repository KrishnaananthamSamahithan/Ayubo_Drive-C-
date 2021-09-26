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
    public partial class Reception_Dashboard : Form
    {
        public Reception_Dashboard()
        {
            InitializeComponent();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Login_dashboard lgd = new Login_dashboard();
            lgd.Show();
            this.Hide();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            Reception_Customer_Form rcf = new Reception_Customer_Form();
            rcf.Show();
            this.Hide();
        }

        private void driverButton_Click(object sender, EventArgs e)
        {
            Reception_Driver_Form rdf = new Reception_Driver_Form();
            rdf.Show();
            this.Hide();
        }

        private void vehicleButton_Click(object sender, EventArgs e)
        {
            Reception_Vehicle_Form rvf = new Reception_Vehicle_Form();
            rvf.Show();
            this.Hide();
        }
    }
}
