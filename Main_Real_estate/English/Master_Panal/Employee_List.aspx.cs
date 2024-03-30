using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Employee_List : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            Employee_BindData();
        }

        protected void Employee_BindData()
        {
            _sqlCon.Open();
            MySqlCommand employeeListCmd = new MySqlCommand("Employee_GridView", _sqlCon);
            employeeListCmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter employeeListDa = new MySqlDataAdapter(employeeListCmd);
            DataTable employeeListDt = new DataTable();
            employeeListDa.Fill(employeeListDt);
            The_Table.DataSource = employeeListDt;
            The_Table.DataBind();
            _sqlCon.Close();
        }

        protected void Delete(object sender, EventArgs e)
        {
            try
            {
                string id = (sender as LinkButton).CommandArgument;
                _sqlCon.Open();
                string quary1 = "DELETE FROM employee WHERE Employee_Id=@ID ";
                MySqlCommand mySqlCmd = new MySqlCommand(quary1, _sqlCon);
                mySqlCmd.Parameters.AddWithValue("@ID", id);
                mySqlCmd.ExecuteNonQuery();
                _sqlCon.Close();
                Response.Redirect(Request.RawUrl);
            }
            catch
            {
                Response.Write(@"<script language='javascript'>alert('لا يمكن الحذف')</script>");
            };
        }
        protected void Edit(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Edit_Employee.aspx?Id=" + id);
        }
        protected void GoToAdd(object sender, EventArgs e)
        {
            Response.Redirect("Add_Employee.aspx");
        }
    }
}