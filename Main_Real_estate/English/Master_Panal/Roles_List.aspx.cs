using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Roles_List : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try { Helper.GetDataReader("SELECT * FROM roles", _sqlCon, The_Table); }
            catch { Response.Write(@"<script language='javascript'>alert('لا يمكن عرض هذه الصفحة')</script>"); };
        }
        protected void Delete(object sender, EventArgs e)
        {
            string RoleId = (sender as LinkButton).CommandArgument;
            DataTable Dt = new DataTable();
            _sqlCon.Open();
            MySqlCommand Cmd = new MySqlCommand("SELECT Role FROM users WHERE Role = @ID", _sqlCon);
            MySqlDataAdapter Da = new MySqlDataAdapter(Cmd);
            Cmd.Parameters.AddWithValue("@ID", RoleId);
            Da.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                Response.Write(@"<script language='javascript'>alert('لا يمكن حذف هذه الصلاحية لأنها مستخدمة بالفعل ')</script>");
            }
            else
            {
                try
                {
                    string id = (sender as LinkButton).CommandArgument;
                    string quary1 = "DELETE FROM roles WHERE Role_ID=@ID ";
                    MySqlCommand mySqlCmd = new MySqlCommand(quary1, _sqlCon);
                    mySqlCmd.Parameters.AddWithValue("@ID", id);
                    mySqlCmd.ExecuteNonQuery();
                    Response.Redirect(Request.RawUrl);
                }
                catch
                {
                    Response.Write(@"<script language='javascript'>alert('لا يمكن الحذف')</script>");
                };
            }

            _sqlCon.Close();





        }
        protected void Edit(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Edit_Role.aspx?Id=" + id);
        }
        protected void GoToAdd(object sender, EventArgs e)
        {
            Response.Redirect("Add_Role.aspx");
        }
    }
}