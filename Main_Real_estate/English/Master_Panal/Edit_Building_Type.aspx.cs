using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Building_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string buildingTypeId = Request.QueryString["Id"];
                DataTable getBuildingTypeDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getBuildingTypeCmd = new MySqlCommand(  "SELECT Building_Type_id , Building_English_Type , Building_Arabic_Type  FROM Building_Type WHERE Building_Type_id = @ID",  _sqlCon);
                MySqlDataAdapter getBuildingTypeDa = new MySqlDataAdapter(getBuildingTypeCmd);

                getBuildingTypeCmd.Parameters.AddWithValue("@ID", buildingTypeId);
                getBuildingTypeDa.Fill(getBuildingTypeDt);
                if (getBuildingTypeDt.Rows.Count > 0)
                {
                    txt_En_Building_Type_Name.Text = getBuildingTypeDt.Rows[0]["Building_English_Type"].ToString();
                    txt_Ar_Building_Type_Name.Text = getBuildingTypeDt.Rows[0]["Building_Arabic_Type"].ToString();
                    lbl_Name_Of_Building_Type.Text = getBuildingTypeDt.Rows[0]["Building_Arabic_Type"].ToString();
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Back_To_Building_Type_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Building_Type_List.aspx");
        }

        protected void btn_Edit_Building_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string buildingTypeId = Request.QueryString["Id"];
                string updateBuildingTypeQuary =
                    "UPDATE Building_Type SET Building_English_Type=@Building_English_Type , Building_Arabic_Type=@Building_Arabic_Type  WHERE Building_Type_id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateBuildingTypeCmd = new MySqlCommand(updateBuildingTypeQuary, _sqlCon);
                updateBuildingTypeCmd.Parameters.AddWithValue("@ID", buildingTypeId);
                updateBuildingTypeCmd.Parameters.AddWithValue("@Building_English_Type",
                    txt_En_Building_Type_Name.Text);
                updateBuildingTypeCmd.Parameters.AddWithValue("@Building_Arabic_Type",
                    txt_Ar_Building_Type_Name.Text);
                updateBuildingTypeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_New_Building_Type.Text = "Edit successfully";
                Response.Redirect("Building_Type_List.aspx");
            }
        }
    }
}