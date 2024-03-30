using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Asset_Details_Tabel : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            _sqlCon.Open();
            string assetId = Request.QueryString["Id"];
            using (MySqlCommand assetDetailsCmd = new MySqlCommand("Asset_Details", _sqlCon))
            {
                assetDetailsCmd.CommandType = CommandType.StoredProcedure;
                assetDetailsCmd.Parameters.AddWithValue("@Id", assetId);
                using (MySqlDataAdapter assetDetailsSda = new MySqlDataAdapter(assetDetailsCmd))
                {
                    DataTable assetDetailsDt = new DataTable();
                    assetDetailsSda.Fill(assetDetailsDt);
                    lbl_Dtl_Name_EN.Text = assetDetailsDt.Rows[0]["Assets_English_Name"].ToString();
                    lbl_Details_Asset_Name.Text = assetDetailsDt.Rows[0]["Assets_Arabic_Name"].ToString();
                    lbl_Dtl_Name_Ar.Text = assetDetailsDt.Rows[0]["Assets_Arabic_Name"].ToString();
                    lbl_Dtl_Asset_Value.Text = assetDetailsDt.Rows[0]["Assets_Value"].ToString();
                    lbl_Dtl_Purchase_Date.Text = assetDetailsDt.Rows[0]["Purchase_Date"].ToString();
                    lbl_Dtl_Asset_Description.Text = assetDetailsDt.Rows[0]["Description"].ToString();
                    lbl_Dtl_Asset_Quantity.Text = assetDetailsDt.Rows[0]["Quantitiy"].ToString();
                    lbl_Dtl_Asset_Type.Text = assetDetailsDt.Rows[0]["Asset_Arabic_Type"].ToString();
                    lbl_Dtl_Asset_Condition.Text = assetDetailsDt.Rows[0]["Asset_Arabic_Condition"].ToString();
                    lbl_Dtl_Asset_Location.Text = assetDetailsDt.Rows[0]["Asset_Arabic_Location"].ToString();
                    lbl_Dtl_Asset_Vendor.Text = assetDetailsDt.Rows[0]["Vendor_Arabic_Type"].ToString();
                    lbl_Dtl_Asset_Inventory.Text = assetDetailsDt.Rows[0]["Inventory_Arabic_name"].ToString();
                    lbl_Dtl_Asset_Warranty.Text = assetDetailsDt.Rows[0]["Aseet_Arabic_warranty"].ToString();
                    lbl_Dtl_Asset_Building.Text = assetDetailsDt.Rows[0]["Building_Arabic_Name"].ToString();
                    lbl_Dtl_Asset_Unit.Text = assetDetailsDt.Rows[0]["Unit_Number"].ToString();
                }
            }

            _sqlCon.Close();
        }

        protected void btn_Back_To_Asset_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Asset_List.aspx");
        }
    }
}