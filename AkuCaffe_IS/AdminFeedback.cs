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
    public partial class AdminFeedback : Form
    {
        private string userRole;

        SqlConnection con = DatabaseConnection.GetConnection();
        public AdminFeedback(string role)
        {
            InitializeComponent();
            userRole = role;
        }

        private void AdminFeedback_Load(object sender, EventArgs e)
        {

            if (userRole != "Admin")
            {
                MessageBox.Show("Admin only access.");
                this.Close();
                return;
            }

            LoadFeedback();
            LoadSummary();
        }
        // ================= LOAD TABLE =================
        void LoadFeedback()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_GetAllFeedback", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvFeedback.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error: " + ex.Message);
            }
        }
        // ================= LOAD AVERAGE =================
        void LoadSummary()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_FeedbackSummary", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    lblAvgFood.Text = "Avg Food: " + dr["AvgFoodQuality"].ToString();
                    lblAvgClean.Text = "Avg Clean: " + dr["AvgCleanliness"].ToString();
                    lblAvgSpeed.Text = "Avg Speed: " + dr["AvgServiceSpeed"].ToString();
                    lblAvgStaff.Text = "Avg Staff: " + dr["AvgStaffBehavior"].ToString();
                    lblTotal.Text = "Total Feedback: " + dr["TotalFeedbacks"].ToString();
                }

                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Summary error: " + ex.Message);
                con.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadFeedback();
            LoadSummary();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard(userRole);
            dashboard.Show();
        }
    }
}
