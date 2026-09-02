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

namespace AkuCaffe_IS
{
    public partial class MealOrder : Form
    {
        private string userRole;
        SqlConnection con = DatabaseConnection.GetConnection();
        public MealOrder(string role)
        {
            InitializeComponent();
            userRole = role;
        }

        private void MealOrder_Load(object sender, EventArgs e)
        {
            cmbMealTime.Items.Add("Breakfast");
            cmbMealTime.Items.Add("Lunch");
            cmbMealTime.Items.Add("Dinner");

            LoadMenu();
            LoadTodayOrders();

        }
        void LoadMenu()
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT MenuID, FoodName FROM Menu WHERE Status='Available'", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbMenu.DataSource = dt;
            cmbMenu.DisplayMember = "FoodName";
            cmbMenu.ValueMember = "MenuID";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStudentID.Text == "")
                {
                    MessageBox.Show("Please enter Student ID");
                    return;
                }

                SqlCommand cmd = new SqlCommand("sp_FindStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentID", txtStudentID.Text.Trim());

                con.Open();
                object result = cmd.ExecuteScalar();
                con.Close();

                if (result != null)
                {
                    txtStudentName.Text = result.ToString();
                }
                else
                {
                    MessageBox.Show("Student not found");
                    txtStudentName.Clear();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
                con.Close();
            }
        }

        private void btnServe_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStudentID.Text == "" || cmbMealTime.Text == "" || cmbMenu.SelectedIndex == -1)
                {
                    MessageBox.Show("Please fill all fields");
                    return;
                }

                SqlCommand cmd = new SqlCommand("sp_TakeMeal", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentID", txtStudentID.Text.Trim());
                cmd.Parameters.AddWithValue("@MealTime", cmbMealTime.Text);
                cmd.Parameters.AddWithValue("@MenuID", cmbMenu.SelectedValue);
                cmd.Parameters.AddWithValue("@ServedBy", "Staff");

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Meal served successfully");
                LoadTodayOrders();
            }
            catch (SqlException ex)
            {
                con.Close();

                // Duplicate meal error (from RAISERROR)
                if (ex.Message.Contains("already took"))
                {
                    MessageBox.Show("This student already took this meal today.");
                }
                else
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Unexpected error: " + ex.Message);
            }
        }
        // ================= TODAY ORDERS =================
        void LoadTodayOrders()
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_GetTodayOrders", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvOrders.DataSource = dt;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard(userRole);
            dashboard.Show();
        }
    }
}
