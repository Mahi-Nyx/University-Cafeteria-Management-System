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
    public partial class StudentReport : Form
    {
        private string userRole;
        SqlConnection con = DatabaseConnection.GetConnection();
        public StudentReport(string role)
        {
            InitializeComponent();
            userRole = role;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStudentID.Text == "")
                {
                    MessageBox.Show("Please enter your Student ID");
                    return;
                }

                // DETAIL
                SqlDataAdapter daDetail =
                    new SqlDataAdapter("sp_StudentOwnDailyReport", con);
                daDetail.SelectCommand.CommandType = CommandType.StoredProcedure;
                daDetail.SelectCommand.Parameters.AddWithValue(
                    "@StudentID", txtStudentID.Text.Trim());

                DataTable dtDetail = new DataTable();
                daDetail.Fill(dtDetail);
                dgvStudentReport.DataSource = dtDetail;

                if (dtDetail.Rows.Count == 0)
                {
                    MessageBox.Show("No record found for today");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStudentID.Clear();
            dgvStudentReport.DataSource = null;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard(userRole);
            dashboard.Show();
        }
    }
}
