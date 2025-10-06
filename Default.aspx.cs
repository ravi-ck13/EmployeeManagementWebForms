using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace EmployeeApp
{
    public partial class Default : Page
    {
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadEmployees();
        }

        void LoadEmployees()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("GetEmployees", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvEmployees.DataSource = dt;
                gvEmployees.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string dept = txtDepartment.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(dept) || string.IsNullOrEmpty(email))
            {
                lblMsg.Text = "Please fill all fields.";
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("AddEmployee", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Department", dept);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            lblMsg.Text = "Employee added successfully!";
            LoadEmployees();
            txtName.Text = txtDepartment.Text = txtEmail.Text = "";
        }

        protected void gvEmployees_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvEmployees.EditIndex = e.NewEditIndex;
            LoadEmployees();
        }

        protected void gvEmployees_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvEmployees.EditIndex = -1;
            LoadEmployees();
        }

        protected void gvEmployees_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvEmployees.DataKeys[e.RowIndex].Value);
            string name = ((System.Web.UI.WebControls.TextBox)gvEmployees.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string dept = ((System.Web.UI.WebControls.TextBox)gvEmployees.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string email = ((System.Web.UI.WebControls.TextBox)gvEmployees.Rows[e.RowIndex].Cells[3].Controls[0]).Text;

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("UpdateEmployee", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Department", dept);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            gvEmployees.EditIndex = -1;
            LoadEmployees();
        }

        protected void gvEmployees_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvEmployees.DataKeys[e.RowIndex].Value);

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("DeleteEmployee", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            LoadEmployees();
        }
    }
}
