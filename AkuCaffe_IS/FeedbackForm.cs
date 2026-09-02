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
    public partial class FeedbackForm : Form
    {
        private string userRole;

        SqlConnection con = DatabaseConnection.GetConnection();
        public FeedbackForm(string role)
        {
            InitializeComponent();
            userRole = role;
        }

        private void FeedbackForm_Load(object sender, EventArgs e)
        {
            if (userRole != "Student")
            {
                MessageBox.Show("Only students can submit feedback.");
                this.Close();
            }

        }
        int GetRating(GroupBox grp)
        {
            foreach (RadioButton rb in grp.Controls)
            {
                if (rb.Checked)
                {
                    return int.Parse(rb.Text);
                }
            }
            return 0;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStudentID.Text == "")
                {
                    MessageBox.Show("Enter Student ID");
                    return;
                }

                int food = GetRating(grpFoodQuality);
                int clean = GetRating(grpCleanliness);
                int speed = GetRating(grpServiceSpeed);
                int staff = GetRating(grpStaffBehavior);

                if (food == 0 || clean == 0 || speed == 0 || staff == 0)
                {
                    MessageBox.Show("Please rate all categories.");
                    return;
                }

                SqlCommand cmd = new SqlCommand("sp_SubmitFeedback", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentID", txtStudentID.Text.Trim());
                cmd.Parameters.AddWithValue("@FoodQuality", food);
                cmd.Parameters.AddWithValue("@Cleanliness", clean);
                cmd.Parameters.AddWithValue("@ServiceSpeed", speed);
                cmd.Parameters.AddWithValue("@StaffBehavior", staff);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Feedback submitted successfully!");
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                con.Close();
            }
        }
        // ================= CLEAR =================
        void ClearForm()
        {
            txtStudentID.Clear();

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is GroupBox)
                {
                    foreach (RadioButton rb in ctrl.Controls)
                    {
                        rb.Checked = false;
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnLogout_Click(object sender, EventArgs e)
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
