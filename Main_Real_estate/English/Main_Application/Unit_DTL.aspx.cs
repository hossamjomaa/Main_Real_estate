using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Main_Real_estate.English.Master_Panal;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Unit_DTL : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "properties", 0, "R");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            Unit_Detail();
        }

        protected void Unit_Detail()
        {
            T_U_D.Text = "تفاصيل الوحدة :";
            string ID = Request.QueryString["Id"];
            using (MySqlCommand Cmd = new MySqlCommand("Unit_Details", _sqlCon))
            {
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@Id", ID);
                MySqlDataAdapter DataAdapter = new MySqlDataAdapter(Cmd);
                DataTable DT = new DataTable();
                DataAdapter.Fill(DT);
                Unit_Details.DataSource = DT;
                Unit_Details.DataBind();
                _sqlCon.Close();
            }
        }
    }
}