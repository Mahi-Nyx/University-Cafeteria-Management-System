using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkuCaffe_IS
{
    public partial class Dashboard : Form
    {
        private string userRole;
        public Dashboard(string role)
        {
            InitializeComponent();
            userRole = role;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, " + userRole;

            // 🔒 Hide EVERYTHING first
            btnManageFood.Visible = false;
            btnDailyReport.Visible = false;
            btnAdminFeedback.Visible = false;
            btnMealOrder.Visible = false;
            btnFeedback.Visible = false;
            btnStudentReport.Visible = false;
            btnManageStudents.Visible = false;

            // ✅ Role-based display
            if (userRole == "Admin")
            {
                // ADMIN → ONLY ADMIN FORMS
                btnManageFood.Visible = true;
                btnDailyReport.Visible = true;
                btnAdminFeedback.Visible = true;
                btnManageStudents.Visible = true;
                // (Add other admin-only buttons here if you have)
            }
            else if (userRole == "Staff")
            {
                // STAFF → ONLY MEAL ORDER
                btnMealOrder.Visible = true;
            }
            else if (userRole == "Student")
            {
                // STUDENT → ONLY FEEDBACK
                btnFeedback.Visible = true;
                btnStudentReport.Visible = true;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();

        }

        private void btnManageFood_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageMenu menu = new ManageMenu(userRole);
            menu.Show();
        }

        private void btnMealOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            MealOrder morder = new MealOrder(userRole);
            morder.Show();
;
        }

        private void btnDailyReport_Click(object sender, EventArgs e)
        {
            this.Hide();
            DailyReport report = new DailyReport(userRole);
            report.Show();
        }

        private void btnStudentReport_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentReport studReport = new StudentReport(userRole);
            studReport.Show();
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            this.Hide();
            FeedbackForm sfeedback = new FeedbackForm(userRole);
            sfeedback.Show();
        }

        private void btnAdminFeedback_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminFeedback afeedback = new AdminFeedback(userRole);
            afeedback.Show();
        }

        private void btnManageStudents_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageStudents studmanage = new ManageStudents(userRole);
            studmanage.Show();
            
        }
    }
}
