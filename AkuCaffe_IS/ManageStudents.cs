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
    public partial class ManageStudents : Form
    {
        private string userRole;
        SqlConnection con = DatabaseConnection.GetConnection();
        public ManageStudents(string role)
        {
            InitializeComponent();
            userRole = role;
        }

        private void ManageStudents_Load(object sender, EventArgs e)
        {
            if (userRole != "Admin")
            {
                MessageBox.Show("Admin only access.");
                this.Close();
                return;
            }

            LoadStudents();
            AddButtonColumns();

        }
        // ================= LOAD =================
        void LoadStudents()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_GetAllStudents", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStudents.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ================= ADD BUTTON COLUMNS =================
        void AddButtonColumns()
        {
            if (!dgvStudents.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                editBtn.Name = "Edit";
                editBtn.Text = "Edit";
                editBtn.UseColumnTextForButtonValue = true;
                dgvStudents.Columns.Add(editBtn);

                DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                deleteBtn.Name = "Delete";
                deleteBtn.Text = "Delete";
                deleteBtn.UseColumnTextForButtonValue = true;
                dgvStudents.Columns.Add(deleteBtn);
            }
        }
        // ================= ADD =================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InsertStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentID", txtStudentID.Text.Trim());
                cmd.Parameters.AddWithValue("@StudentName", txtStudentName.Text.Trim());

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Student added successfully.");
                LoadStudents();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }

        }
        // ================= GRID CLICK =================
        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string studentID = dgvStudents.Rows[e.RowIndex].Cells["StudentID"].Value.ToString();
            string studentName = dgvStudents.Rows[e.RowIndex].Cells["StudentName"].Value.ToString();

            // UPDATE
            if (dgvStudents.Columns[e.ColumnIndex].Name == "Update")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdateStudent", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@StudentName", studentName);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Student updated successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }

            // DELETE
            if (dgvStudents.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure to delete this student?",
                    "Confirm",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("sp_DeleteStudent", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StudentID", studentID);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        LoadStudents();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        con.Close();
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_SearchStudent", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue(
                    "@StudentID", txtSearch.Text.Trim());

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStudents.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }
        void ClearFields()
        {
            txtStudentID.Clear();
            txtStudentName.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            txtStudentID.Enabled = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

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
