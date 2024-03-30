using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Vendor_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string vendorTypeId = Request.QueryString["Id"];
                DataTable getVendorTypeDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getVendorTypeCmd =
                    new MySqlCommand(
                        "SELECT Vendor_Type_id , Vendor_English_Type , Vendor_Arabic_Type  FROM vendor_typ WHERE Vendor_Type_id = @ID",
                        _sqlCon);
                MySqlDataAdapter getVendorTypeDa = new MySqlDataAdapter(getVendorTypeCmd);

                getVendorTypeCmd.Parameters.AddWithValue("@ID", vendorTypeId);
                getVendorTypeDa.Fill(getVendorTypeDt);
                if (getVendorTypeDt.Rows.Count > 0)
                {
                    txt_En_Vendor_Type_Name.Text = getVendorTypeDt.Rows[0]["Vendor_English_Type"].ToString();
                    txt_Ar_Vendor_Type_Name.Text = getVendorTypeDt.Rows[0]["Vendor_Arabic_Type"].ToString();
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Back_To_Vendor_Type_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Vendor_Type_List.aspx");
        }

        protected void btn_Edit_Vendor_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string vendorTypeId = Request.QueryString["Id"];
                string updateVendorTupeQuary =
                    "UPDATE vendor_typ SET Vendor_English_Type=@Vendor_English_Type , Vendor_Arabic_Type=@Vendor_Arabic_Type  WHERE Vendor_Type_Id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateVendorTypeCmd = new MySqlCommand(updateVendorTupeQuary, _sqlCon);
                updateVendorTypeCmd.Parameters.AddWithValue("@ID", vendorTypeId);
                updateVendorTypeCmd.Parameters.AddWithValue("@Vendor_English_Type", txt_En_Vendor_Type_Name.Text);
                updateVendorTypeCmd.Parameters.AddWithValue("@Vendor_Arabic_Type", txt_Ar_Vendor_Type_Name.Text);
                updateVendorTypeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_New_Vendor_Type.Text = "Edit successfully";
                Response.Redirect("Vendor_Type_List.aspx");
            }
        }
    }
}