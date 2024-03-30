using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Asset_Condition : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string assetConditionId = Request.QueryString["Id"];
                DataTable getAssetConditionDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getAssetConditionCmd =
                    new MySqlCommand(
                        "SELECT Asset_Condition_id , Asset_English_Condition , Asset_Arabic_Condition  FROM asset_condition WHERE Asset_Condition_id = @ID",
                        _sqlCon);
                MySqlDataAdapter getAssetConditionDa = new MySqlDataAdapter(getAssetConditionCmd);

                getAssetConditionCmd.Parameters.AddWithValue("@ID", assetConditionId);
                getAssetConditionDa.Fill(getAssetConditionDt);
                if (getAssetConditionDt.Rows.Count > 0)
                {
                    txt_En_Asset_Condition_Name.Text =
                        getAssetConditionDt.Rows[0]["Asset_English_Condition"].ToString();
                    txt_Ar_Asset_Condition_Name.Text =
                        getAssetConditionDt.Rows[0]["Asset_Arabic_Condition"].ToString();
                    lbl_Name_Of_Asset_Condition.Text =
                        getAssetConditionDt.Rows[0]["Asset_Arabic_Condition"].ToString();
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Back_To_Asset_Condition_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Asset_Condition_List.aspx");
        }

        protected void btn_Edit_Asset_Condition_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string assetConditionId = Request.QueryString["Id"];
                string updateAssetTupeQuary =
                    "UPDATE asset_condition SET Asset_English_Condition=@Asset_English_Condition , Asset_Arabic_Condition=@Asset_Arabic_Condition  WHERE Asset_Condition_id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateAssetConditionCmd = new MySqlCommand(updateAssetTupeQuary, _sqlCon);
                updateAssetConditionCmd.Parameters.AddWithValue("@ID", assetConditionId);
                updateAssetConditionCmd.Parameters.AddWithValue("@Asset_English_Condition",
                    txt_En_Asset_Condition_Name.Text);
                updateAssetConditionCmd.Parameters.AddWithValue("@Asset_Arabic_Condition",
                    txt_Ar_Asset_Condition_Name.Text);
                updateAssetConditionCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_New_Asset_Condition.Text = "Edit successfully";
                Response.Redirect("Asset_Condition_List.aspx");
            }
        }
    }
}