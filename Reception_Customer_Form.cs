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
    public partial class Reception_Customer_Form : Form
    {
        // Code for sql connection
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-C7TK6UK;Initial Catalog=AyuboDrive_TaxiDB;Integrated Security=True");


        string identity;

        public Reception_Customer_Form()
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
            AddCustomer();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Clear();

            AutoID();
        }


        private void nicNo_CheckedChanged(object sender, EventArgs e)
        {
            identity = "NIC No";
        }

        private void passportNo_CheckedChanged(object sender, EventArgs e)
        {
            identity = "Passport No";
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer();
        }



        private void AddCustomer()
        // Code for Add Reception
        {
            try
            {
                if (customerId.Text != "" && fName.Text != "" && lName.Text != "" && nationality.Text != "" && identyfyBy.Text != "" && mailId.Text != "" && phoneNo.Text != "" && dob.Text != "" && address.Text != "" && age.Text != "" && gender.Text != "")
                {

                    con.Open();
                    string query = "insert into Customer (Customer_ID, First_Name, Last_Name, Nationality,Identityby, Identity_No, Mail_ID,  Phone_No, DOB, Address, Age, Gender) VALUES('" + customerId.Text + "' , '" + fName.Text + "', '" + lName.Text + "' , '" + nationality.Text + "', '" + identyfyBy.Text + "', '" + identityNo.Text + "', '" + mailId.Text + "', '" + phoneNo.Text + "' , '" + dob.Text + "', '" + address.Text + "', '" + age.Text + "' , '" + gender.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Details Add Successfully");
                    con.Close();
                    disp_data();
                    Clear();
                    AutoID();



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
        //Code for display data
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Customer";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();

        }


        private void Clear()
        //Code for Clear Button
        {
            customerId.Clear();
            fName.Clear();
            lName.Clear();
            nationality.SelectedIndex = -1;
            identyfyBy.SelectedIndex = -1;
            identityNo.Clear();
            mailId.Clear();
            phoneNo.Clear();
            address.Clear();
            age.Clear();
            gender.SelectedIndex = -1;


        }


        private void SearchCustomer()
        // Code for Search Reception
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Customer where Customer_ID like'" + search.Text + "' ", con);



            SqlDataReader sdr = cmd.ExecuteReader();


            while (sdr.Read())
            {
                customerId.Text = sdr["Customer_ID"].ToString();
                fName.Text = sdr["First_Name"].ToString();
                lName.Text = sdr["Last_Name"].ToString();
                nationality.Text = sdr["Nationality"].ToString();
                identyfyBy.Text = sdr.ToString();
                identityNo.Text = sdr["Identity_No"].ToString();
                mailId.Text = sdr["Mail_ID"].ToString();
                phoneNo.Text = sdr["Phone_No"].ToString();
                dob.Text = sdr["DOB"].ToString();
                address.Text = sdr["Address"].ToString();
                age.Text = sdr["Age"].ToString();
                gender.Text = sdr["Gender"].ToString();

            }
            con.Close();

        }

        private void AutoID()
        //Code for AutoID 
        {
            SqlDataAdapter sda = new SqlDataAdapter("select isnull (max(cast (Customer_ID as int) ), 0) + 1 from Customer", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            customerId.Text = dt.Rows[0][0].ToString();
            this.ActiveControl = fName;
        }

        private void Reception_Customer_Form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ayuboDrive_TaxiDBDataSet6.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.ayuboDrive_TaxiDBDataSet6.Customer);

            AutoID();
                
        }

        private void search_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
