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
    public partial class DailyReport : Form
    {
        private string userRole;
        SqlConnection con = DatabaseConnection.GetConnection();
        public DailyReport(string role)
        {
            InitializeComponent();
            userRole = role;
        }

        private void DailyReport_Load(object sender, EventArgs e)
        {
            LoadDaily();

        }
        void LoadDaily()
        {
            LoadReport("sp_DailyMealReport", "sp_DailyStudentSummary");
        }
        void LoadReport(string detailSP, string summarySP)
        {
            try
            {
                SqlDataAdapter da1 = new SqlDataAdapter(detailSP, con);
                da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dgvDailyReport.DataSource = dt1;

                SqlDataAdapter da2 = new SqlDataAdapter(summarySP, con);
                da2.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                dgvSummary.DataSource = dt2;

                foreach (DataGridViewRow row in dgvSummary.Rows)
                {
                    if (row.Cells["TotalCost"].Value != null &&
                        Convert.ToInt32(row.Cells["TotalCost"].Value) > 100)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error: " + ex.Message);
            }
        }
        private void LoadDailyReport()
        {
            LoadReport("sp_DailyMealReport", "sp_DailyStudentSummary");
        }
        private void btnDailyReport_Click(object sender, EventArgs e)
        {
            LoadDailyReport();

        }

        private void btnWeeklyReport_Click(object sender, EventArgs e)
        {
            LoadReport("sp_WeeklyMealReport", "sp_WeeklyStudentSummary");
        }

        private void btnMonthlyReport_Click(object sender, EventArgs e)
        {
            LoadReport("sp_MonthlyMealReport", "sp_MonthlyStudentSummary");
        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearchStudentID.Text == "")
                {
                    MessageBox.Show("Enter Student ID to search");
                    return;
                }

                // Filter DETAIL
                (dgvDailyReport.DataSource as DataTable).DefaultView.RowFilter =
                    $"StudentID = '{txtSearchStudentID.Text.Trim()}'";

                // Filter SUMMARY
                (dgvSummary.DataSource as DataTable).DefaultView.RowFilter =
                    $"StudentID = '{txtSearchStudentID.Text.Trim()}'";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtSearchStudentID.Clear();

                (dgvDailyReport.DataSource as DataTable).DefaultView.RowFilter = "";
                (dgvSummary.DataSource as DataTable).DefaultView.RowFilter = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Clear error: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchStudentID.Clear();
            LoadDailyReport();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard(userRole);
            dashboard.Show();
        }
    }
}
