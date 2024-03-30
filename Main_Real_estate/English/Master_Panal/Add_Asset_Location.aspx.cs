using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Asset_Location : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Add_Asset_location_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addAssetLocationQuary =
                    "Insert Into asset_location (Asset_English_location,Asset_Arabic_location) VALUES(@Asset_English_location,@Asset_Arabic_location)";
                _sqlCon.Open();
                MySqlCommand addAssetLocationCmd = new MySqlCommand(addAssetLocationQuary, _sqlCon);
                addAssetLocationCmd.Parameters.AddWithValue("@Asset_English_location",
                    txt_En_Asset_location_Name.Text);
                addAssetLocationCmd.Parameters.AddWithValue("@Asset_Arabic_location",
                    txt_Ar_Asset_location_Name.Text);
                addAssetLocationCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Asset_location.Text = "Added successfully";

                _sqlCon.Close();
                Response.Redirect("Asset_location_List.aspx");
            }
        }

        protected void btn_Back_To_Asset_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Asset_location_List.aspx");
        }
    }
}