using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Vendor_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Back_To_Vendor_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Vendor_Type_List.aspx");
        }

        protected void btn_Add_Vendor_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addVendorTypeQuary =
                    "Insert Into Vendor_Type (Vendor_English_Type,Vendor_Arabic_Type) VALUES(@Vendor_English_Type,@Vendor_Arabic_Type)";
                _sqlCon.Open();
                MySqlCommand addVendorTypeCmd = new MySqlCommand(addVendorTypeQuary, _sqlCon);
                addVendorTypeCmd.Parameters.AddWithValue("@Vendor_English_Type", txt_En_Vendor_Type_Name.Text);
                addVendorTypeCmd.Parameters.AddWithValue("@Vendor_Arabic_Type", txt_Ar_Vendor_Type_Name.Text);
                addVendorTypeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Vendor_Type.Text = "Added successfully";

                _sqlCon.Close();
                Response.Redirect("Vendor_Type_List.aspx");
            }
        }
    }
}