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
    public partial class Hire_Form : Form
    {
        // Code for sql connection
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-C7TK6UK;Initial Catalog=AyuboDrive_TaxiDB;Integrated Security=True");
        public Hire_Form()
        {
            InitializeComponent();
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void hireId_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8 && chr != 46)
            {
                e.Handled = true;
                MessageBox.Show("Please input valid value");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Enabled = true;
            groupBox5.Enabled = false;
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Enabled = false;
            groupBox5.Enabled = true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Hire(Hire_ID, Customer_ID, First_Name, Identity_No, Phone_No, Driver_ID, D_First_Name, License_No, Pakage_Type_D, Hire_Date_D, Hire_End_Date_D, Start_Time_D, End_Time_D, Km_Range_D, Hire_Calculation_D, Driver_Payment_D, Total_Hire_D ) values('" + hireId.Text + "','" + customerId.Text + "','" + customerName.Text + "','" + identityNo.Text + "','" + phoneNo.Text + "','" + driverId.Text + "','" + driverName.Text + "','" + licenseNo.Text + "','" + dPakageType.Text + "','" + dHireDate.Text + "','" + dHireEndDate.Text + "','" + dStartTime.Text + "','" + dEndTime.Text + "','" + dKmRange.Text + "','" + dHireCalculation.Text + "','" + dDriverPayment.Text + "','" + dTotalHire.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("New Hire Added Successfully!", "Customer Addition", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            con.Close();
            hireId.Text = "";
            customerId.Text = "";
            customerName.Text = "";
            identityNo.Text = "";
            phoneNo.Text = "";
            driverId.Text = "";
            driverName.Text = "";
            licenseNo.Text = "";
            dPakageType.Text = "";
            dHireDate.Text = "";
            dHireEndDate.Text = "";
            dStartTime.Text = "";
            dEndTime.Text = "";
            dKmRange.Text = "";
            dHireCalculation.Text = "";
            dTotalHire.Text = "";
        }

        private void Hire_Form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ayuboDrive_TaxiDBDataSet10.Hire' table. You can move, or remove it, as needed.
            this.hireTableAdapter.Fill(this.ayuboDrive_TaxiDBDataSet10.Hire);

        }

        private void lAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Hire(Hire_ID, Customer_ID, First_Name, Identity_No, Phone_No, Driver_ID, D_First_Name, License_No, Pakage_Type_L, Hire_Date_L, Hire_End_Date_L, Km_Range_L, Total_Night_Stay, Total_Parking, Hire_Calculation_L, Driver_Payment_L, Total_Hire_L ) values('" + hireId.Text + "','" + customerId.Text + "','" + customerName.Text + "','" + identityNo.Text + "','" + phoneNo.Text + "','" + driverId.Text + "','" + driverName.Text + "','" + licenseNo.Text + "','" + lPakageType.Text + "','" + lHireDate.Text + "','" + lHireEndDate.Text + "','" + lKmRange.Text + "', '" + nightStay.Text + "', '" + totalParking.Text + "','" + lHireCalculation.Text + "','" + lDriverPayment.Text + "','" + lTotalHire.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("New Hire Added Successfully!", "Customer Addition", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            con.Close();
            hireId.Text = "";
            customerId.Text = "";
            customerName.Text = "";
            identityNo.Text = "";
            phoneNo.Text = "";
            driverId.Text = "";
            driverName.Text = "";
            licenseNo.Text = "";
            lPakageType.Text = "";
            lHireDate.Text = "";
            lHireEndDate.Text = "";
            lStartTime.Text = "";
            lEndTime.Text = "";
            lKmRange.Text = "";
            nightStay.Text = "";
            totalParking.Text = "";
            lHireCalculation.Text = "";
            lTotalHire.Text = "";
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(dKmRange.Text);
            int x2 = int.Parse(dHireCalculation.Text);
            int x3 = int.Parse(dDriverPayment.Text);
            int Rs = (x1 * 750) + x2 + x3;

            dTotalHire.Text += Rs.ToString() + ".000";
        }

        private void lCalculate_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(lKmRange.Text);
            int x2 = int.Parse(nightStay.Text);
            int x3 = int.Parse(totalParking.Text);
            int x4 = int.Parse(lHireCalculation.Text);
            int x5 = int.Parse(lDriverPayment.Text);
            int Rs = (x1 * 750) + x2 + x3 + x4 + x5 ;

            lTotalHire.Text += Rs.ToString() + ".000";  
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
                   


                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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
                    licenseNo.Text = dt.Rows[0].ItemArray[6].ToString();
                    dAge.Text = dt.Rows[0].ItemArray[10].ToString();

                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
