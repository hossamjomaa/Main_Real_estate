using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Zone : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string zoneId = Request.QueryString["Id"];
                DataTable getZoneDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getZoneCmd =  new MySqlCommand(  "SELECT zone_Id , zone_English_name , zone_arabic_name , zone_number FROM zone WHERE zone_Id = @ID",  _sqlCon);
                MySqlDataAdapter getZoneDa = new MySqlDataAdapter(getZoneCmd);
                getZoneCmd.Parameters.AddWithValue("@ID", zoneId);
                getZoneDa.Fill(getZoneDt);
                if (getZoneDt.Rows.Count > 0)
                {
                    txt_En_Zone_Name.Text = getZoneDt.Rows[0]["zone_English_name"].ToString();
                    txt_Ar_Zone_Name.Text = getZoneDt.Rows[0]["zone_arabic_name"].ToString();
                    txt_Zone_Number.Text = getZoneDt.Rows[0]["zone_number"].ToString();

                    lbl_titel_Name_Edit_Zone.Text = getZoneDt.Rows[0]["zone_arabic_name"].ToString();
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Back_To_Zone_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Zone_List.aspx");
        }

        protected void btn_Add_Zone_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string zoneId = Request.QueryString["Id"];
                string updateZoneQuary =
                    "UPDATE zone SET zone_English_name=@zone_English_name , zone_arabic_name=@zone_arabic_name , zone_number=@zone_number WHERE zone_Id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateZoneCmd = new MySqlCommand(updateZoneQuary, _sqlCon);
                updateZoneCmd.Parameters.AddWithValue("@ID", zoneId);
                updateZoneCmd.Parameters.AddWithValue("@zone_English_name", txt_En_Zone_Name.Text);
                updateZoneCmd.Parameters.AddWithValue("@zone_arabic_name", txt_Ar_Zone_Name.Text);
                updateZoneCmd.Parameters.AddWithValue("@zone_number", txt_Zone_Number.Text);
                updateZoneCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_Zone.Text = "Edit successfully";
                Response.Redirect("Zone_List.aspx");
            }
        }
    }
}