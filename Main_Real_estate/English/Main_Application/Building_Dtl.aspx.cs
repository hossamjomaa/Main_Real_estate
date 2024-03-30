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
    public partial class Building_Dtl : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "properties", 0, "R");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            Building_Details();
            Unit_list();
        }
        protected void Building_Details()
        {
            T_B_D.Text = "تفاصيل البناء";
            string buildingId = Request.QueryString["Id"];
            using (MySqlCommand bulidingDetailsCmd = new MySqlCommand("Building_Details", _sqlCon))
            {
                bulidingDetailsCmd.CommandType = CommandType.StoredProcedure;
                bulidingDetailsCmd.Parameters.AddWithValue("@Id", buildingId);
                MySqlDataAdapter bulidingDetailsSda = new MySqlDataAdapter(bulidingDetailsCmd);

                DataTable bulidingDetailsDt = new DataTable();
                bulidingDetailsSda.Fill(bulidingDetailsDt);
                bulidingDetailsCmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                bulidingDetailsSda.Fill(dt);
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                _sqlCon.Close();
            }
        }
        protected void Unit_list()
        {
            string buildingId = Request.QueryString["Id"];
            _sqlCon.Open();
            using (MySqlCommand unitDetailsCmd = new MySqlCommand("Unit_List_In_Building_Details", _sqlCon))
            {
                unitDetailsCmd.CommandType = CommandType.StoredProcedure;
                unitDetailsCmd.Parameters.AddWithValue("@Id", buildingId);
                MySqlDataAdapter unitDetailsSda = new MySqlDataAdapter(unitDetailsCmd);

                DataTable unitDetailsDt = new DataTable();
                unitDetailsSda.Fill(unitDetailsDt);
                unitDetailsCmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                unitDetailsSda.Fill(dt);
                eeeee.DataSource = dt;
                eeeee.DataBind();
            }
            _sqlCon.Close();
        }

        protected void Details_Unit(object sender, EventArgs e)
        {
            T_U_D.Text = "تفاصيل الوحدة :";
            btn_Close.Visible = true;
            string ID = (sender as LinkButton).CommandArgument;
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
        protected void btn_Close_Click(object sender, EventArgs e)
        {

            T_U_D.Text = string.Empty;

            Unit_Details.DataSource = null;
            Unit_Details.DataSourceID = null;
            Unit_Details.DataBind();


            btn_Close.Visible = false;
        }
    }
}