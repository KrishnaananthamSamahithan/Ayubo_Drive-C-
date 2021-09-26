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
    public partial class Reception_Vehicle_Form : Form
    {
        // Code for sql connection
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-C7TK6UK;Initial Catalog=AyuboDrive_TaxiDB;Integrated Security=True");
        public Reception_Vehicle_Form()
        {
            InitializeComponent();
        }

        private void Reception_Vehicle_Form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ayuboDrive_TaxiDBDataSet8.Vehicle' table. You can move, or remove it, as needed.
            this.vehicleTableAdapter.Fill(this.ayuboDrive_TaxiDBDataSet8.Vehicle);


            disp_data();
            AutoID();

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
            AddVehicle();

            AutoID();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Clear();

            AutoID();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            SearchVehicle();
        }


        private void AddVehicle()
        // Code for Add Vehicle
        {
            try
            {
                if (vehicleId.Text != "" && vehicleBrand.Text != "" && vehicleName.Text != "" && vehicleColour.Text != "" && vehicleNo.Text != "" && vehicleType.Text != "" && insurenceNo.Text != "" && insurenceExpire.Text != "" && taxNo.Text != "" && taxExpire.Text != "" && fuelType.Text != "" && seatCount.Text != "" && ratePerDay.Text != "" && ratePerWeek.Text != "" && ratePerMonth.Text != "")
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Vehicle ( Vehicle_ID, Vehicle_Brand, Vehicle_Name, Vehicle_Colour, Vehicle_No, Vehicle_Type, Insurence_No, Insurence_Expire, Tax_No, Tax_Expire, Fuel_Type, Seat_Count, Rate_Per_Day, Rate_Per_Week, Rate_Per_Month) VALUES('" + vehicleId.Text + "' , '" + vehicleBrand.Text + "', '" + vehicleName.Text + "', '" + vehicleColour.Text + "', '" + vehicleNo.Text + "', '" + vehicleType.Text + "',  '" + insurenceNo.Text + "', '" + insurenceExpire.Text + "' , '" + taxNo.Text + "' , '" + taxExpire.Text + "', '" + fuelType.Text + "', '" + seatCount.Text + "' , '" + ratePerDay.Text + "' , '" + ratePerWeek.Text + "','" + ratePerMonth.Text + "' )";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    disp_data();
                    AutoID();
                    Clear();

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

        private void disp_data()
        //Code for display data
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Vehicle";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void AutoID()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select isnull (max(cast (Vehicle_ID as int) ), 0) + 1 from Vehicle", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            vehicleId.Text = dt.Rows[0][0].ToString();
            this.ActiveControl = vehicleBrand;
        }

        private void Clear()
        // Code for Clear Button
        {
            vehicleId.Clear();
            vehicleBrand.Clear();
            vehicleName.Clear();
            vehicleColour.Clear();
            vehicleNo.Clear();
            vehicleType.SelectedIndex = -1;
            insurenceNo.Clear();
            insurenceExpire.Select();
            taxNo.Clear();
            taxExpire.Select();
            fuelType.SelectedIndex = -1;
            seatCount.SelectedIndex = -1;
            ratePerDay.Clear();
            ratePerWeek.Clear();
            ratePerMonth.Clear();
        }


        private void SearchVehicle()
        // Code for Search Reception
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Vehicle where Vehicle_ID like'" + search.Text + "' ", con);



            SqlDataReader sdr = cmd.ExecuteReader();


            while (sdr.Read())
            {
                vehicleId.Text = sdr["Vehicle_ID"].ToString();
                vehicleBrand.Text = sdr["Vehicle_Brand"].ToString();
                vehicleName.Text = sdr["Vehicle_Name"].ToString();
                vehicleColour.Text = sdr["Vehicle_Colour"].ToString();
                vehicleNo.Text = sdr["Vehicle_No"].ToString();
                vehicleType.Text = sdr["Vehicle_Type"].ToString();
                insurenceNo.Text = sdr["Insurence_No"].ToString();
                insurenceExpire.Text = sdr["Insurence_Expire"].ToString();
                taxNo.Text = sdr["Tax_No"].ToString();
                taxExpire.Text = sdr["Tax_Expire"].ToString();
                fuelType.Text = sdr["Fuel_Type"].ToString();
                seatCount.Text = sdr["Seat_Count"].ToString();
                ratePerDay.Text = sdr["Rate_Per_Day"].ToString();
                ratePerWeek.Text = sdr["Rate_Per_Week"].ToString();
                ratePerMonth.Text = sdr["Rate_Per_Month"].ToString();
            }
            con.Close();

        }

    }
}
