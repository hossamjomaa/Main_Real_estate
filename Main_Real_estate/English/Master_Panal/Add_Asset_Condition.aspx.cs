using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Asset_Condition : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Add_Asset_Condition_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addAssetConditionQuary =
                    "Insert Into asset_condition (Asset_English_Condition,Asset_Arabic_Condition) VALUES(@Asset_English_Condition,@Asset_Arabic_Condition)";
                _sqlCon.Open();
                MySqlCommand addAssetConditionCmd = new MySqlCommand(addAssetConditionQuary, _sqlCon);
                addAssetConditionCmd.Parameters.AddWithValue("@Asset_English_Condition",
                    txt_En_Asset_Condition_Name.Text);
                addAssetConditionCmd.Parameters.AddWithValue("@Asset_Arabic_Condition",
                    txt_Ar_Asset_Condition_Name.Text);
                addAssetConditionCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Asset_Condition.Text = "Added successfully";

                _sqlCon.Close();
                Response.Redirect("Asset_Condition_List.aspx");
            }
        }

        protected void btn_Back_To_Asset_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Asset_Condition_List.aspx");
        }
    }
}