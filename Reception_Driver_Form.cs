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
    public partial class Reception_Driver_Form : Form
    {
        // Code for sql connection
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-C7TK6UK;Initial Catalog=AyuboDrive_TaxiDB;Integrated Security=True");

        public Reception_Driver_Form()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Reception_Dashboard rnd = new Reception_Dashboard();
            rnd.Show();
            this.Hide();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddDriver();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Clear();

            AutoID();
        }

        private void Reception_Driver_Form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ayuboDrive_TaxiDBDataSet7.Driver' table. You can move, or remove it, as needed.
            this.driverTableAdapter.Fill(this.ayuboDrive_TaxiDBDataSet7.Driver);

            //Calling Auto ID generate code
            AutoID();

            // Caling Auto Refresh Code
            disp_data();

        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            SearchDriver();
        }

        private void AddDriver()
        // Code for Add Driver
        {
            try
            {
                if (driverId.Text != "" && fName.Text != "" && lName.Text != "" && nicNo.Text != "" && mailId.Text != "" && phoneNo.Text != "" && licenseNo.Text != "" && licenseExpire.Text != "" && dob.Text != "" && address.Text != "" && age.Text != "" && gender.Text != "" && experience.Text != "")
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Driver ( Driver_ID, First_Name, Last_Name, NIC_No, Mail_ID,  Phone_No, License_No, License_Expire, DOB, Address, Age, Gender, Experience) VALUES('" + driverId.Text + "' , '" + fName.Text + "', '" + lName.Text + "' , '" + nicNo.Text + "', '" + mailId.Text + "', '" + phoneNo.Text + "' , '" + licenseNo.Text + "' , '" + licenseExpire.Text + "', '" + dob.Text + "', '" + address.Text + "', '" + age.Text + "' , '" + gender.Text + "' , '" + experience.Text + "' )";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    disp_data();
                    Clear();
                    AutoID();

                    MessageBox.Show("Driver Details Saved successfully");
                }
                else
                {
                    MessageBox.Show("Please fill out the empty field");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void disp_data()
        //Code for Auto Refresh
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Driver";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void Clear()
        {
            driverId.Clear();
            fName.Clear();
            lName.Clear();
            nicNo.Clear();
            mailId.Clear();
            phoneNo.Clear();
            licenseNo.Clear();
            address.Clear();
            age.Clear();
            gender.SelectedIndex = -1;
            experience.Clear();
        }

        private void AutoID()
        // Code for Auto ID generate
        {
            SqlDataAdapter sda = new SqlDataAdapter("select isnull (max(cast (Driver_ID as int) ), 0) + 1 from Driver", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            driverId.Text = dt.Rows[0][0].ToString();
            this.ActiveControl = fName;

        }


        private void SearchDriver()
        // Code for Search Reception
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Driver where Driver_ID like'" + search.Text + "' ", con);



            SqlDataReader sdr = cmd.ExecuteReader();


            while (sdr.Read())
            {
                driverId.Text = sdr["Driver_ID"].ToString();
                fName.Text = sdr["First_Name"].ToString();
                lName.Text = sdr["Last_Name"].ToString();
                nicNo.Text = sdr["NIC_No"].ToString();
                mailId.Text = sdr["Mail_ID"].ToString();
                phoneNo.Text = sdr["Phone_No"].ToString();
                licenseNo.Text = sdr["License_No"].ToString();
                licenseExpire.Text = sdr["License_Expire"].ToString();
                dob.Text = sdr["DOB"].ToString();
                address.Text = sdr["Address"].ToString();
                age.Text = sdr["Age"].ToString();
                gender.Text = sdr["Gender"].ToString();
                experience.Text = sdr["Experience"].ToString();
            }
            con.Close();

        }



    }
}
