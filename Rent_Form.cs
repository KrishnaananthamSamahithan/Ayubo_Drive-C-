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
    public partial class Rent_Form : Form
    {
        // Code for sql connection
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-C7TK6UK;Initial Catalog=AyuboDrive_TaxiDB;Integrated Security=True");
        public Rent_Form()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
               Admin_dashboard amd = new Admin_dashboard();
            amd.Show();
            this.Hide();
        }

        private void Rent_Form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ayuboDrive_TaxiDBDataSet11.Rent' table. You can move, or remove it, as needed.
            this.rentTableAdapter.Fill(this.ayuboDrive_TaxiDBDataSet11.Rent);
          

            AutoID();

        }

        private void customerId_TextChanged(object sender, EventArgs e)
        {
            if (customerId.TextLength <= 9)
            {
                try
                {
                    AutoCompleteStringCollection namescolln = new AutoCompleteStringCollection();
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-C7TK6UK;Initial Catalog=AyuboDrive_TaxiDB;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Customer WHERE Customer_ID= '" + customerId.Text + "' ", con);
                    sda.Fill(dt);
                    customerName.Text = dt.Rows[0].ItemArray[1].ToString();
                    identityNo.Text = dt.Rows[0].ItemArray[5].ToString();
                    phoneNo.Text = dt.Rows[0].ItemArray[7].ToString();
                    age.Text = dt.Rows[0].ItemArray[10].ToString();
                    gender.Text = dt.Rows[0].ItemArray[11].ToString();
                    

                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void vehicleId_TextChanged(object sender, EventArgs e)
        {
            if (vehicleId.TextLength <= 1)
            {
                try
                {
                    AutoCompleteStringCollection namescolln = new AutoCompleteStringCollection();
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-C7TK6UK;Initial Catalog=AyuboDrive_TaxiDB;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Vehicle WHERE Vehicle_ID= '" + vehicleId.Text + "' ", con);
                    sda.Fill(dt);
                    vehicleBrand.Text = dt.Rows[0].ItemArray[1].ToString();
                    vehicleNo.Text = dt.Rows[0].ItemArray[4].ToString();
                    vehicleType.Text = dt.Rows[0].ItemArray[5].ToString();
                    ratePerDay.Text = dt.Rows[0].ItemArray[12].ToString();
                    ratePerWeek.Text = dt.Rows[0].ItemArray[13].ToString();
                    ratePerMonth.Text = dt.Rows[0].ItemArray[14].ToString();
                    perDay.Text = dt.Rows[0].ItemArray[12].ToString();
                    perWeek.Text = dt.Rows[0].ItemArray[13].ToString();
                    perMonth.Text = dt.Rows[0].ItemArray[14].ToString();

                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Rent where Rent_ID like'" + search.Text + "' ", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                rentId.Text = sdr["Rent_ID"].ToString();
                customerId.Text = sdr["Customer_ID"].ToString();
                vehicleId.Text = sdr["Vehicle_ID"].ToString();
                driverId.Text = sdr["Driver_ID"].ToString();
                dRentStartDate.Text = sdr["Rent_Start_Date_W"].ToString();
                dRentEndDate.Text = sdr["Rent_End_Date_W"].ToString();
                dNoOfDays.Text = sdr["No_of_Days_W"].ToString();
                rentStartDate.Text = sdr["Rent_Start_Date_WO"].ToString();
                rentEndDate.Text = sdr["Rent_End_Date_WO"].ToString();
                cNoOfDays.Text = sdr["No_of_Days_WO"].ToString();
                noOfDays.Text = sdr["No_of_Days"].ToString();
                noOfWeek.Text = sdr["No_of_Weeks"].ToString();
                noOfMonth.Text = sdr["No_of_Months"].ToString();
                perDay.Text = sdr["Per_Day"].ToString();
                perWeek.Text = sdr["Per_Week"].ToString();
                perMonth.Text = sdr["Per_Month"].ToString();
                totalPayment.Text = sdr["Total_Payment"].ToString();

            }
            else
            {
                MessageBox.Show(" There is No Data found for This ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true && radioButton2.Checked == false)
            {
                groupBox2.Enabled = true;
                groupBox5.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false && radioButton2.Checked == true)
            {
                groupBox5.Enabled = true;
                groupBox2.Enabled = false;
            }
        }

        private void calculate_Click(object sender, EventArgs e)
        {
              if (radioButton1.Checked == true && radioButton2.Checked == false)
            {
                int x1 = int.Parse(noOfDays.Text);
                int x2 = int.Parse(noOfWeek.Text);
                int x3 = int.Parse(noOfMonth.Text);
                int x4 = int.Parse(perDay.Text);
                int x5 = int.Parse(perWeek.Text);
                int x6 = int.Parse(perMonth.Text);
                int x7 = int.Parse(driverPayment.Text);
                int Rs = (x1 * x4) + (x2 * x5) + (x3 * x6) + x7;

                totalPayment.Text += Rs.ToString() + ".000";
            }
              else if (radioButton1.Checked == false && radioButton2.Checked == true)
              {
                  int r1= int.Parse(noOfDays.Text);
                  int r2 = int.Parse(noOfWeek.Text);
                  int r3 = int.Parse(noOfMonth.Text);
                  int r4 = int.Parse(perDay.Text);
                  int r5 = int.Parse(perWeek.Text);
                  int r6 = int.Parse(perMonth.Text);
                  int print = (r1 * r4) + (r2 * r5) + (r3 * r6);

                  totalPayment.Text += print.ToString() + ".000";
              }
             
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (customerId.Text == "")
            {
                MessageBox.Show("Please Enter the Customer ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (vehicleId.Text == "")
            {
                MessageBox.Show("Please Enter the Vehicle_ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (driverId.Text == "")
            {
                MessageBox.Show("Please Enter the Driver ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (dRentStartDate.Text == "")
            {
                MessageBox.Show("Please Enter the Rent Start Date(W)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (dRentEndDate.Text == "")
            {
                MessageBox.Show("Please Enter the Rent End Date(W)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (dNoOfDays.Text == "")
            {
                MessageBox.Show("Please Enter the No.of.Days(W) !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (noOfDays.Text == "")
            {
                MessageBox.Show("Please Enter the No.of.Days!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (noOfWeek.Text == "")
            {
                MessageBox.Show("Please Enter the No.of.Weeks !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (noOfMonth.Text == "")
            {
                MessageBox.Show("Please Enter the No.of.Months !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (perDay.Text == "")
            {
                MessageBox.Show("Please Enter the Per Day !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (perWeek.Text == "")
            {
                MessageBox.Show("Please Enter the Per Week !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (perMonth.Text == "")
            {
                MessageBox.Show("Please Enter the Per Month!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if(rentId.Text != "" && customerId.Text != "" && customerName.Text != "" && identityNo.Text != "" && phoneNo.Text != "" && gender.Text != "" && driverId.Text != "" && driverName.Text != "" &&  licenseNo.Text != "" && vehicleId.Text != "" && vehicleNo.Text != "" && vehicleType.Text != "" && dRentStartDate.Text != "" && dRentEndDate.Text != "" && dNoOfDays.Text != "" && driverPayment.Text != "" && rentStartDate.Text != "" && rentEndDate.Text != "" && noOfDays.Text != "" &&  noOfWeek.Text != "" && noOfMonth.Text != "" && perDay.Text != "" &&  perWeek.Text != "" && perMonth.Text != "" &&  totalPayment.Text != "" )
                {
                SqlCommand cmd = new SqlCommand("insert into Rent(Rent_ID, Customer_ID, First_Name, Identity_No, Phone_No, Driver_ID, D_First_Name, License_No, Vehicle_ID, Vehicle_No, Vehicle_Type ) values('" + rentId.Text + "', '" + customerId.Text + "', '" + customerName.Text + "', '" + identityNo.Text + "','" + phoneNo.Text + "', '" + driverId.Text + "', '" + driverName.Text + "', '" + licenseNo.Text + "', '" + vehicleId.Text + "', '" + vehicleNo.Text + "','" + vehicleType.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("New Rental Added Successfully!", "Rental Addition", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                con.Close();
                }
               
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {

        }

        private void addWo_Click(object sender, EventArgs e)
        {
             if (customerId.Text == "")
            {
                MessageBox.Show("Please Enter the Customer ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
             else if (vehicleId.Text == "")
             {
                 MessageBox.Show("Please Enter the Vehicle_ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             else if (noOfDays.Text == "")
             {
                 MessageBox.Show("Please Enter the No.of.Days!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             else if (noOfWeek.Text == "")
             {
                 MessageBox.Show("Please Enter the No.of.Weeks !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             else if (noOfMonth.Text == "")
             {
                 MessageBox.Show("Please Enter the No.of.Months !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             else if (perDay.Text == "")
             {
                 MessageBox.Show("Please Enter the Per Day !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             else if (perWeek.Text == "")
             {
                 MessageBox.Show("Please Enter the Per Week !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             else if (perMonth.Text == "")
             {
                 MessageBox.Show("Please Enter the Per Month!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             else
             {
                
                 
                     SqlCommand cmd = new SqlCommand("insert into Rent(Rent_ID, Customer_ID, First_Name, Identity_No, Phone_No, Vehicle_ID, Vehicle_No, Vehicle_Type, No_Of_Days, No_Of_Week, No_Of_Month, Per_Day, Per_Week, Per_Month, Total_Payment ) values('" + rentId.Text + "', '" + customerId.Text + "', '" + customerName.Text + "', '" + identityNo.Text + "','" + phoneNo.Text + "', '" + vehicleId.Text + "', '" + vehicleNo.Text + "','" + vehicleType.Text + "',  '" + noOfDays.Text + "', '" + noOfWeek.Text + "', '" + noOfMonth.Text + "','" + perDay.Text + "', '" + perWeek.Text + "', '" + perMonth.Text + "', '" + totalPayment.Text + "')", con);
                     con.Open();
                     cmd.ExecuteNonQuery();
                     MessageBox.Show("New Rental Added Successfully!", "Rental Addition", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                     con.Close();
                 }
             
        }

        private void clearWo_Click(object sender, EventArgs e)
        {

        }

        private void AutoID()
        //Code for AutoID 
        {
            SqlDataAdapter sda = new SqlDataAdapter("select isnull (max(cast (Rent_ID as int) ), 0) + 1 from Rent", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            rentId.Text = dt.Rows[0][0].ToString();
            

        }

        private void driverId_TextChanged(object sender, EventArgs e)
        {
            if (driverId.TextLength <= 3)
            {
                try
                {
                    AutoCompleteStringCollection namescolln = new AutoCompleteStringCollection();
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-C7TK6UK;Initial Catalog=AyuboDrive_TaxiDB;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Driver WHERE Driver_ID= '" + driverId.Text + "' ", con);
                    sda.Fill(dt);
                    driverName.Text = dt.Rows[0].ItemArray[1].ToString();
                    dAge.Text = dt.Rows[0].ItemArray[10].ToString();
                    licenseNo.Text = dt.Rows[0].ItemArray[6].ToString();
                   

                
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dRentEndDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime date1 = dRentStartDate.Value;
            DateTime date2 = dRentEndDate.Value;
            TimeSpan day = date2 - date1;
            dNoOfDays.Text = day.TotalDays.ToString();
 
        }

        private void rentId_TextChanged(object sender, EventArgs e)
        {
            
        }
    

        private void rentId_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8 && chr != 46)
            {
                e.Handled = true;
                MessageBox.Show("Please input valid value");
            }
        }

        private void filter_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Without Driver")
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-C7TK6UK;Initial Catalog=AyuboDrive_TaxiDB;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Rent_ID, Customer_ID, First_Name, Identity_No, Phone_No, Vehicle_ID, Vehicle_No, Vehicle_Type, Rent_Start_Date_W_O, Rent_End_Date_W_O, No_Of_Days, No_Of_Week, No_Of_Month, Per_Day, Per_Week, Per_Month, Total_Payment  FROM Rent where Phone_No like '" + filter.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            else if (comboBox2.Text == "With Driver")
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-C7TK6UK;Initial Catalog=AyuboDrive_TaxiDB;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Rent_ID,Customer_ID,First_Name_C,Last_Name_C,Address,NIC_No,Gender,Age,Vechile_ID,Vechile_Type,Driver_ID,First_Name_D,Last_Name_D,Driver_License,Rent_Start_Date_W,Rent_End_Date_W,No_of_Days_W,Driver_Payment,No_of_Days,No_of_Weeks,No_of_Months,Per_Day,Per_Week,Per_Month,Total_Payment FROM Rent where Driver_ID like '" + filter.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
            } 
        }

        private void rentEndDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime date1 = rentStartDate.Value;
            DateTime date2 = rentEndDate.Value;
            TimeSpan day = date2 - date1;
            cNoOfDays.Text = day.TotalDays.ToString();
 
        }

         /*if(rentId.Text != "" && customerId.Text != "" && customerName.Text != "" && identityNo.Text != "" && phoneNo.Text != "" && gender.Text != "" && driverId.Text != "" && driverName.Text != "" &&  licenseNo.Text != "" && vehicleId.Text != "" && vehicleNo.Text != "" && vehicleType.Text != "" && dRentStartDate.Text != "" && dRentEndDate.Text != "" && dNoOfDays.Text != "" && driverPayment.Text != "" && rentStartDate.Text != "" && rentEndDate.Text != "" && noOfDays.Text != "" &&  noOfWeek.Text != "" && noOfMonth.Text != "" && perDay.Text != "" &&  perWeek.Text != "" && perMonth.Text != "" &&  totalPayment.Text != "" )
                {
                SqlCommand cmd = new SqlCommand("insert into Rent(Rent_ID, Customer_ID, First_Name, Identity_No, Phone_No, Gender, Driver_ID, D_First_Name, License_No, Vehicle_ID, Vehicle_No, Vehicle_Type, Rent_Start_Date_W, Rent_End_Date_W, No_Of_Days_W, Driver_Payment, Rent_Start_Date_W_O, Rent_End_Date_W_O, No_Of_Days, No_Of_Week, No_Of_Month, Per_Day, Per_Week, Per_Month, Total_Payment ) values('" + rentId.Text + "', '" + customerId.Text + "', '" + customerName.Text + "', '" + identityNo.Text + "','" + phoneNo.Text + "', '" + gender + "', '" + driverId.Text + "', '" + driverName.Text + "', '" + licenseNo.Text + "', '" + vehicleId.Text + "', '" + vehicleNo.Text + "','" + vehicleType.Text + "','" + dRentStartDate.Text + "', '" + dRentEndDate.Text + "','" + dNoOfDays.Text + "', '" + driverPayment.Text + "', '" + rentStartDate.Text + "', '" + rentEndDate.Text + "', '" + noOfDays.Text + "', '" + noOfWeek.Text + "', '" + noOfMonth.Text + "', '" + perDay.Text + "', '" + perWeek.Text + "', '" + perMonth.Text + "', '" + totalPayment.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("New Rental Added Successfully!", "Rental Addition", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                con.Close();
                }*/

    }
}


