using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Listing_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Add_listing_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addListingTypeQuary =
                    "Insert Into listing_Type (listing_English_Type,listing_Arabic_Type) VALUES(@listing_English_Type,@listing_Arabic_Type)";
                _sqlCon.Open();
                MySqlCommand addListingTypeCmd = new MySqlCommand(addListingTypeQuary, _sqlCon);
                addListingTypeCmd.Parameters.AddWithValue("@listing_English_Type", txt_En_listing_Type_Name.Text);
                addListingTypeCmd.Parameters.AddWithValue("@listing_Arabic_Type", txt_Ar_listing_Type_Name.Text);
                addListingTypeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_listing_Type.Text = "Added successfully";

                _sqlCon.Close();
                Response.Redirect("listing_Type_List.aspx");
            }
        }

        protected void btn_Back_To_listing_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("listing_Type_List.aspx");
        }
    }
}