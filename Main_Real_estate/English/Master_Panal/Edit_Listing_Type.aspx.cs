using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Listing_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string listingTypeId = Request.QueryString["Id"];
                DataTable getListingTypeDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getListingTypeCmd =
                    new MySqlCommand(
                        "SELECT listing_Type_id , listing_English_Type , listing_Arabic_Type  FROM listing_Type WHERE listing_Type_id = @ID",
                        _sqlCon);
                MySqlDataAdapter getListingTypeDa = new MySqlDataAdapter(getListingTypeCmd);

                getListingTypeCmd.Parameters.AddWithValue("@ID", listingTypeId);
                getListingTypeDa.Fill(getListingTypeDt);
                if (getListingTypeDt.Rows.Count > 0)
                {
                    txt_En_listing_Type_Name.Text = getListingTypeDt.Rows[0]["listing_English_Type"].ToString();
                    txt_Ar_listing_Type_Name.Text = getListingTypeDt.Rows[0]["listing_Arabic_Type"].ToString();
                    lbl_Name_Of_listing_Type.Text = getListingTypeDt.Rows[0]["listing_Arabic_Type"].ToString();
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Back_To_listing_Type_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("listing_Type_List.aspx");
        }

        protected void btn_Edit_listing_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string listingTypeId = Request.QueryString["Id"];
                string updateListingTupeQuary =
                    "UPDATE listing_type SET listing_English_Type=@listing_English_Type , listing_Arabic_Type=@listing_Arabic_Type  WHERE listing_Type_id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateListingTypeCmd = new MySqlCommand(updateListingTupeQuary, _sqlCon);
                updateListingTypeCmd.Parameters.AddWithValue("@ID", listingTypeId);
                updateListingTypeCmd.Parameters.AddWithValue("@listing_English_Type", txt_En_listing_Type_Name.Text);
                updateListingTypeCmd.Parameters.AddWithValue("@listing_Arabic_Type", txt_Ar_listing_Type_Name.Text);
                updateListingTypeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_New_listing_Type.Text = "Edit successfully";
                Response.Redirect("listing_Type_List.aspx");
            }
        }
    }
}