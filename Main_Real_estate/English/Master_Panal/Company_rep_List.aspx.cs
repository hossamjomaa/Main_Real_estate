using System;
using Main_Real_estate.Utilities;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Company_rep_List : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData(string sortExpression = null)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("Company_Rep_List", _sqlCon))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        eeeee.DataSource = dt;
                        eeeee.DataBind();
                    }
                }
            }
            catch { Response.Write(@"<script language='javascript'>alert('لايمكن عرض قائمة ممثلي الشركات')</script>"); }
        }




        protected void Delete_Unit(object sender, EventArgs e)
        {
            try
            {
                string id = (sender as LinkButton).CommandArgument;
                _sqlCon.Open();
                string quary1 = "DELETE FROM company_representative WHERE Company_representative_Id=@ID ";
                MySqlCommand mySqlCmd = new MySqlCommand(quary1, _sqlCon);
                mySqlCmd.Parameters.AddWithValue("@ID", id);
                mySqlCmd.ExecuteNonQuery();
                _sqlCon.Close();

                Response.Redirect(Request.RawUrl);
            }
            catch
            {
                Response.Write(@"<script language='javascript'>alert('لا يمكن حذف هذا الممثل ')</script>");
            }
        }
        protected void Edit_Unit(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Edit_Company_Rep.aspx?Id=" + id);
        }
        protected void Details_Unit(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Com_Rep_Details.aspx?Id=" + id);
        }
    }
}