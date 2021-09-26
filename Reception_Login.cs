using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ayubo_Drive
{
    public partial class Reception_Login : Form
    {
        public Reception_Login()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void loginButton_Click(object sender, EventArgs e)
        {

           

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-C7TK6UK;Initial Catalog=AyuboDrive_TaxiDB;Integrated Security=True" ); // making connection   
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Reception_Login WHERE Mail_ID='" + UN.Text + "' AND PASSWORD='" + pw.Text + "'", con);
            /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
            DataTable dt = new DataTable(); //this is creating a virtual table  
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */
                this.Hide();
                new Reception_Dashboard().Show();
            }
            else
                MessageBox.Show("Invalid username or password");  
  


            
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Login_dashboard ld1 = new Login_dashboard();
            ld1.Show();
            this.Hide();
        }

        
    }
}
