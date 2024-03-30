using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Asset_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Back_To_Asset_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Asset_Type_List.aspx");
        }

        protected void btn_Add_Asset_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addAssetTypeQuary =
                    "Insert Into asset_type (Asset_English_Type,Asset_Arabic_Type) VALUES(@Asset_English_Type,@Asset_Arabic_Type)";
                _sqlCon.Open();
                MySqlCommand addAssetTypeCmd = new MySqlCommand(addAssetTypeQuary, _sqlCon);
                addAssetTypeCmd.Parameters.AddWithValue("@Asset_English_Type", txt_En_Asset_Type_Name.Text);
                addAssetTypeCmd.Parameters.AddWithValue("@Asset_Arabic_Type", txt_Ar_Asset_Type_Name.Text);
                addAssetTypeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Asset_Type.Text = "Added successfully";

                _sqlCon.Close();
                Response.Redirect("Asset_Type_List.aspx");
            }
        }
    }
}