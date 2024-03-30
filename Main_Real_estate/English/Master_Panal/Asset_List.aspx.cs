using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;


namespace Main_Real_estate.English.Master_Panal
{
    public partial class Assset_List : System.Web.UI.Page
    {
        //MySqlConnection SqlCon = Helper.GetConnection();
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Asset_List_BindData();
            }
        }
        protected void Asset_List_BindData(string sortExpression = null)
        {
            using (MySqlCommand cmd = new MySqlCommand("Asset_List", _sqlCon))
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    Assset_List_1.DataSource = dt;
                    Assset_List_1.DataBind();
                }
            }
        }

        protected void Asset_Details(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Asset_Details.aspx?Id=" + id);
        }
        protected void Edit_Asset(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Edit_Asset.aspx?Id=" + id);
        }
        protected void Delete_Asset(object sender, EventArgs e)
        {
            try
            {
                string id = (sender as LinkButton).CommandArgument;
                _sqlCon.Open();
                string quary1 = "DELETE FROM assets WHERE Assets_Id=@ID ";
                MySqlCommand mySqlCmd = new MySqlCommand(quary1, _sqlCon);
                mySqlCmd.Parameters.AddWithValue("@ID", id);
                mySqlCmd.ExecuteNonQuery();




                string PM_quary = "DELETE FROM periodic_maintenence WHERE Asset_ID=@ID ";
                MySqlCommand PM_mySqlCmd = new MySqlCommand(PM_quary, _sqlCon);
                PM_mySqlCmd.Parameters.AddWithValue("@ID", id);
                PM_mySqlCmd.ExecuteNonQuery();
                _sqlCon.Close();
                Response.Redirect(Request.RawUrl);
            }
            catch
            {
                Response.Write(
                    @"<script language='javascript'>alert('عذراً لا يمكن حذف هذا الأصل')</script>");
            }

        }
    }
}