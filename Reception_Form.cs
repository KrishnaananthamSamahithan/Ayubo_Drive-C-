using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;


namespace Ayubo_Drive
{
    public partial class Reception_Form : Form
    {
        // Code for sql connection
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-C7TK6UK;Initial Catalog=AyuboDrive_TaxiDB;Integrated Security=True");
      
        public Reception_Form()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
            //code for close application
        {
            this.Close();
        }

        private void backButton_Click(object sender, EventArgs e)
            //coding for back button from Reception form to Admin dashboard
        {
            Admin_dashboard adm = new Admin_dashboard();
            adm.Show();
            this.Hide();

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Addreception();

            Addreception_Login();
           
        }

      

        private void Reception_Form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ayuboDrive_TaxiDBDataSet2.Reception' table. You can move, or remove it, as needed.
            this.receptionTableAdapter.Fill(this.ayuboDrive_TaxiDBDataSet2.Reception);

            disp_data();
            AutoID();
           
           
           

        }

        private void search_TextChanged(object sender, EventArgs e)
            //Calling search code
        {
            SearchReception();
        }



       


       
       

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void updateButton_Click(object sender, EventArgs e)
            // Calling update coding
        {
            UpdateReception();


            UpdateReception_Login();
        }


        private void deleteButton_Click(object sender, EventArgs e)
        {
            // calling delete code
           DeleteReception();

           DeleteReception_Login();
               
        }



        private void DeleteReception()
            // Code for delete data
        {
              try
            { 
               if (receptionId.Text != "" && fName.Text != "" && lName.Text != "" && nicNo.Text != "" && mailId.Text != "" && phoneNo.Text != "" && password.Text != "" && dob.Text != "" && address.Text != "" && age.Text != "" && gender.Text != "" && experience.Text != "" )
               {
                   if (MessageBox.Show("Are You confirm to delete?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                   {
                       con.Open();
                       SqlCommand cmd = con.CreateCommand();
                       cmd.CommandType = CommandType.Text;
                       cmd.CommandText = "delete from Reception where Reception_ID ='" + receptionId.Text + "'";
                       cmd.ExecuteNonQuery();
                       con.Close();
                       disp_data();
                       Clear();
                       AutoID();
                       MessageBox.Show("Reception Details Delete successfully");
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

        private void SearchReception()
        // Code for Search Reception
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Reception where Reception_ID like'" + search.Text + "' ", con);
           

            
            SqlDataReader sdr = cmd.ExecuteReader();
            

            while (sdr.Read())
            {
                receptionId.Text = sdr["Reception_ID"].ToString();
                fName.Text = sdr["First_Name"].ToString();
                lName.Text = sdr["Last_Name"].ToString();
                nicNo.Text = sdr["NIC_No"].ToString();
                mailId.Text = sdr["Mail_ID"].ToString();
                phoneNo.Text = sdr["Phone_No"].ToString();
                password.Text = sdr["Password"].ToString();
                dob.Text = sdr["DOB"].ToString();
                address.Text = sdr["Address"].ToString();
                age.Text = sdr["Age"].ToString();
                gender.Text = sdr["Gender"].ToString();
                experience.Text = sdr["Experience"].ToString();
            }
            con.Close();

        }


        private void disp_data()
            //Code for display data
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Reception";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void Addreception()
        // Code for Add Reception
        {
            try
            {
                if (receptionId.Text != "" && fName.Text != "" && lName.Text != "" && nicNo.Text != "" && mailId.Text != "" && phoneNo.Text != "" && password.Text != "" && dob.Text != "" && address.Text != "" && age.Text != "" && gender.Text != "" && experience.Text != "")
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Reception ( Reception_ID, First_Name, Last_Name, NIC_No, Mail_ID,  Phone_No, Password, DOB, Address, Age, Gender, Experience) VALUES('" + receptionId.Text + "' , '" + fName.Text + "', '" + lName.Text + "' , '" + nicNo.Text + "', '" + mailId.Text + "', '" + phoneNo.Text + "' , '" + password.Text + "' , '" + dob.Text + "', '" + address.Text + "', '" + age.Text + "' , '" + gender.Text + "' , '" + experience.Text + "' )";
                    cmd.ExecuteNonQuery();
                   
                    
                   
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "insert into Reception_Login ( Mail_ID, PASSWORD) VALUES('" + mailId.Text + "','" + password.Text + "' )";
                    cmd1.ExecuteNonQuery();
                    con.Close();

                    disp_data();
                    Clear();
                    AutoID();
                    
                    MessageBox.Show("Data Saved successfully");
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

        private void UpdateReception()
        // Coding for update Reception
        {
             try
            {
                if (receptionId.Text != "" && fName.Text != "" && lName.Text != "" && nicNo.Text != "" && mailId.Text != "" && phoneNo.Text != "" && password.Text != "" && dob.Text != "" && address.Text != "" && age.Text != "" && gender.Text != "" && experience.Text != "")
                {
            con.Open();
            SqlCommand cmd = new SqlCommand("update Reception set  First_Name = '" + fName.Text + "', Last_Name = '" + lName.Text + "',  NIC_No  = '" + nicNo.Text + "',  Mail_ID = '" + mailId.Text + "',  Password = '" + password.Text + "', DOB = '" + dob.Text + "', Address = '" + address.Text + "', Age = '" + age.Text + "', Gender = '" + gender.Text + "', Experience = '" + experience.Text + "' Where Reception_ID = '" + search.Text + "' ", con);
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


        private void AutoID()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select isnull (max(cast (Reception_ID as int) ), 0) + 1 from Reception", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            receptionId.Text = dt.Rows[0][0].ToString();
            this.ActiveControl = fName;

        }


        private void Clear()
        {
            receptionId.Clear();
            fName.Clear();
            lName.Clear();
            nicNo.Clear();
            mailId.Clear();
            phoneNo.Clear();
            password.Clear();
            address.Clear();
            age.Clear();
            gender.SelectedIndex = -1;
            experience.Clear();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Clear();
            AutoID();
        }
          

       

        private void fName_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void mailId_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void fName_Validating(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void Addreception_Login()
        // Code for Add Reception
        {
          
               

        }

        private void UpdateReception_Login()
        // Coding for update Reception
        {
            AutoCompleteStringCollection namescolln = new AutoCompleteStringCollection();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-C7TK6UK;Initial Catalog=AyuboDrive_TaxiDB;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("update Reception_Login set    Mail_ID = '" + mailId.Text + "', PASSWORD= '" + password.Text + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();

        }


        private void DeleteReception_Login()
        // Code for delete data
        {


            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Reception_Login where Mail_ID ='" + mailId.Text + "' ";
            cmd.ExecuteNonQuery();
            con.Close();

        }
            

      

        /*private bool IsValidate_Name(string n)
        {
            Regex check = new Regex(@"^([A-Z] [a-z-A-z]+)$");
            bool valid = false;
            valid = check.IsMatch(n);
            if(valid==true)
            {
                return valid;
            }
            else
            {
                MessageBox.Show("Name Format is Incorrect");
                return valid;
            }
        }*/
    }

}
