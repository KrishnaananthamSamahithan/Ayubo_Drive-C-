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
    public partial class Customer_Form : Form
    {
        // Code for sql connection
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-C7TK6UK;Initial Catalog=AyuboDrive_TaxiDB;Integrated Security=True");

        string identity;
        public Customer_Form()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Admin_dashboard adm = new Admin_dashboard();
            adm.Show();
            this.Hide();
        }

        private void Customer_Form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ayuboDrive_TaxiDBDataSet3.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.ayuboDrive_TaxiDBDataSet3.Customer);

            AutoID();

        }

        private void addButton_Click(object sender, EventArgs e)
            // Calling Add reception code
        {
            AddCustomer();
        }

        private void updateButton_Click(object sender, EventArgs e)
        // Calling Update reception code
        {
            UpdateCustomer();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        // Calling Delete reception code
        {
            DeleteCustomer();
        }

        private void clearButton_Click(object sender, EventArgs e)
        // Calling Clear reception code
        {
            Clear();

            AutoID();
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

        private void nicNo_CheckedChanged(object sender, EventArgs e)
        {
            identity = "NIC No";
        }

        private void passportNo_CheckedChanged(object sender, EventArgs e)
        {
            identity = "Passport No";
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

        private void UpdateCustomer()
        // Coding for update Reception
        {
            try
            {
                if (customerId.Text != "" && fName.Text != "" && lName.Text != "" && nationality.Text != "" && identyfyBy.Text != "" && mailId.Text != "" && phoneNo.Text != "" && dob.Text != "" && address.Text != "" && age.Text != "" && gender.Text != "")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Customer set  First_Name = '" + fName.Text + "', Last_Name = '" + lName.Text + "',  Nationality  = '" + nationality.Text + "', Identity_No = '"+ identityNo.Text +"' , Mail_ID = '" + mailId.Text + "', DOB = '" + dob.Text + "', Address = '" + address.Text + "', Age = '" + age.Text + "', Gender = '" + gender.Text + "' Where Customer_ID = '" + search.Text + "' ", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Updated successfully");
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
                identyfyBy.Text= sdr.ToString();
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

        private void search_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer();
        }



        private void DeleteCustomer()
        // Code for delete data
        {
            try
            {
                if (customerId.Text != "" && fName.Text != "" && lName.Text != "" && nationality.Text != "" && identyfyBy.Text != "" && mailId.Text != "" && phoneNo.Text != "" && dob.Text != "" && address.Text != "" && age.Text != "" && gender.Text != "")
                {
                    if (MessageBox.Show("Are You confirm to delete?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "delete from Customer where Customer_ID ='" + customerId.Text + "'";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        disp_data();
                        Clear();
                        AutoID();
                        MessageBox.Show("Customer Details Deleted successfully");
                    }
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


        private void AutoID()
            //Code for AutoID 
        {
            SqlDataAdapter sda = new SqlDataAdapter("select isnull (max(cast (Customer_ID as int) ), 0) + 1 from Customer", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            customerId.Text = dt.Rows[0][0].ToString();
            this.ActiveControl = fName;

        }

        private void customerId_TextChanged(object sender, EventArgs e)
            // Calling AutoID code
        {
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void phoneNo_TextChanged(object sender, EventArgs e)
        {
            if (phoneNo.Text.Length == 10)
            {
            }
            else
            {
                MessageBox.Show("You can Enter only 10 digits for mobilenumber");
            }
        }
    }
}
