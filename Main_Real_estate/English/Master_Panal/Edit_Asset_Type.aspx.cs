using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Asset_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string assetTypeId = Request.QueryString["Id"];
                DataTable getAssetTypeDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getAssetTypeCmd =
                    new MySqlCommand(
                        "SELECT Asset_Type_id , Asset_English_Type , Asset_Arabic_Type  FROM asset_type WHERE Asset_Type_id = @ID",
                        _sqlCon);
                MySqlDataAdapter getAssetTypeDa = new MySqlDataAdapter(getAssetTypeCmd);

                getAssetTypeCmd.Parameters.AddWithValue("@ID", assetTypeId);
                getAssetTypeDa.Fill(getAssetTypeDt);
                if (getAssetTypeDt.Rows.Count > 0)
                {
                    txt_En_Asset_Type_Name.Text = getAssetTypeDt.Rows[0]["Asset_English_Type"].ToString();
                    txt_Ar_Asset_Type_Name.Text = getAssetTypeDt.Rows[0]["Asset_Arabic_Type"].ToString();
                    lbl_Name_Of_Asset_Type.Text = getAssetTypeDt.Rows[0]["Asset_Arabic_Type"].ToString();
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Back_To_Asset_Type_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Asset_Type_List.aspx");
        }

        protected void btn_Edit_Asset_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string assetTypeId = Request.QueryString["Id"];
                string updateAssetTupeQuary =
                    "UPDATE asset_type SET Asset_English_Type=@Asset_English_Type , Asset_Arabic_Type=@Asset_Arabic_Type  WHERE Asset_Type_id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateAssetTypeCmd = new MySqlCommand(updateAssetTupeQuary, _sqlCon);
                updateAssetTypeCmd.Parameters.AddWithValue("@ID", assetTypeId);
                updateAssetTypeCmd.Parameters.AddWithValue("@Asset_English_Type", txt_En_Asset_Type_Name.Text);
                updateAssetTypeCmd.Parameters.AddWithValue("@Asset_Arabic_Type", txt_Ar_Asset_Type_Name.Text);
                updateAssetTypeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_New_Asset_Type.Text = "Edit successfully";
                Response.Redirect("Asset_Type_List.aspx");
            }
        }
    }
}