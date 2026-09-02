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
    public partial class ManageMenu : Form
    {
        private string userRole;

        SqlConnection con = DatabaseConnection.GetConnection();
        public ManageMenu(string role)
        {
            InitializeComponent();
            userRole = role;
        }

        private void ManageMenu_Load(object sender, EventArgs e)
        {
            
            cmbMealTime.Items.Add("Breakfast");
            cmbMealTime.Items.Add("Lunch");
            cmbMealTime.Items.Add("Dinner");

            cmbStatus.Items.Add("Available");
            cmbStatus.Items.Add("Not Available");

            LoadMenu();
            AddButtons();
        }
        void LoadMenu()
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_GetMenu", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvMenu.DataSource = dt;
        }

        void AddButtons()
        {
            if (!dgvMenu.Columns.Contains("Update"))
            {
                DataGridViewButtonColumn btnUpdate = new DataGridViewButtonColumn();
                btnUpdate.Name = "Update";
                btnUpdate.Text = "Update";
                btnUpdate.UseColumnTextForButtonValue = true;
                dgvMenu.Columns.Add(btnUpdate);
            }

            if (!dgvMenu.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                btnDelete.Name = "Delete";
                btnDelete.Text = "Delete";
                btnDelete.UseColumnTextForButtonValue = true;
                dgvMenu.Columns.Add(btnDelete);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_AddMenu", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MealTime", cmbMealTime.Text);
            cmd.Parameters.AddWithValue("@FoodName", txtFoodName.Text);
            cmd.Parameters.AddWithValue("@BreadCount", numBread.Value);
            cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Menu added successfully");
            LoadMenu();
        }

        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int menuID = Convert.ToInt32(dgvMenu.Rows[e.RowIndex].Cells["MenuID"].Value);

            // UPDATE
            if (dgvMenu.Columns[e.ColumnIndex].Name == "Update")
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateMenu", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MenuID", menuID);
                cmd.Parameters.AddWithValue("@MealTime",
                    dgvMenu.Rows[e.RowIndex].Cells["MealTime"].Value.ToString());
                cmd.Parameters.AddWithValue("@FoodName",
                    dgvMenu.Rows[e.RowIndex].Cells["FoodName"].Value.ToString());
                cmd.Parameters.AddWithValue("@BreadCount",
                    dgvMenu.Rows[e.RowIndex].Cells["BreadCount"].Value);
                cmd.Parameters.AddWithValue("@Status",
                    dgvMenu.Rows[e.RowIndex].Cells["Status"].Value.ToString());

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Menu updated");
                LoadMenu();
            }

            // DELETE
            if (dgvMenu.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Delete this item?", "Confirm",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("sp_DeleteMenu", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MenuID", menuID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Menu deleted");
                    LoadMenu();
                }

            }
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
