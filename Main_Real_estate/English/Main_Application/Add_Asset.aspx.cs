using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Add_Asset : System.Web.UI.Page
    {
        // Database Connection String
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //    //Fill aseet_warranty DropDownList
                using (MySqlCommand getAseetWarrantyDropDownListCmd =
                       new MySqlCommand("SELECT * FROM aseet_warranty"))
                {
                    getAseetWarrantyDropDownListCmd.CommandType = CommandType.Text;
                    getAseetWarrantyDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    Asset_Warranty_DropDownList.DataSource = getAseetWarrantyDropDownListCmd.ExecuteReader();
                    Asset_Warranty_DropDownList.DataTextField = "Aseet_Arabic_warranty";
                    Asset_Warranty_DropDownList.DataValueField = "Aseet_warranty_Id";
                    Asset_Warranty_DropDownList.DataBind();
                    Asset_Warranty_DropDownList.Items.Insert(0, "إختر ضمان الأصل ....");
                    _sqlCon.Close();
                }

                //    //Fill aseet_Unit DropDownList
                using (MySqlCommand getAseetUnitDropDownListCmd = new MySqlCommand("SELECT * FROM units"))
                {
                    getAseetUnitDropDownListCmd.CommandType = CommandType.Text;
                    getAseetUnitDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    Asset_Unit_DropDownList.DataSource = getAseetUnitDropDownListCmd.ExecuteReader();
                    Asset_Unit_DropDownList.DataTextField = "Unit_Number";
                    Asset_Unit_DropDownList.DataValueField = "Unit_ID";
                    Asset_Unit_DropDownList.DataBind();
                    Asset_Unit_DropDownList.Items.Insert(0, "اختر اسم الوحدة ....");
                    _sqlCon.Close();
                }

                //    //Fill aseet_Building DropDownList
                using (MySqlCommand getAseetBuildingDropDownListCmd = new MySqlCommand("SELECT * FROM building"))
                {
                    getAseetBuildingDropDownListCmd.CommandType = CommandType.Text;
                    getAseetBuildingDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    Assets_Building_DropDownList.DataSource = getAseetBuildingDropDownListCmd.ExecuteReader();
                    Assets_Building_DropDownList.DataTextField = "Building_Arabic_Name";
                    Assets_Building_DropDownList.DataValueField = "Building_Id";
                    Assets_Building_DropDownList.DataBind();
                    Assets_Building_DropDownList.Items.Insert(0, "أختر اسم البناء ....");
                    _sqlCon.Close();
                }

                //    //Fill aseet_Vendor DropDownList
                using (MySqlCommand getAseetVendorDropDownListCmd = new MySqlCommand("SELECT * FROM vendor_type"))
                {
                    getAseetVendorDropDownListCmd.CommandType = CommandType.Text;
                    getAseetVendorDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    Asset_Vendor_DropDownList.DataSource = getAseetVendorDropDownListCmd.ExecuteReader();
                    Asset_Vendor_DropDownList.DataTextField = "Vendor_Arabic_Type";
                    Asset_Vendor_DropDownList.DataValueField = "Vendor_Type_Id";
                    Asset_Vendor_DropDownList.DataBind();
                    Asset_Vendor_DropDownList.Items.Insert(0, "إختر بائع الاصل ....");
                    _sqlCon.Close();
                }

                //    //Fill aseet_inventory DropDownList
                using (MySqlCommand getAseetInventoryDropDownListCmd = new MySqlCommand("SELECT * FROM inventory"))
                {
                    getAseetInventoryDropDownListCmd.CommandType = CommandType.Text;
                    getAseetInventoryDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    Asset_Inventory_DropDownList.DataSource = getAseetInventoryDropDownListCmd.ExecuteReader();
                    Asset_Inventory_DropDownList.DataTextField = "Inventory_Arabic_name";
                    Asset_Inventory_DropDownList.DataValueField = "inventory_Id";
                    Asset_Inventory_DropDownList.DataBind();
                    Asset_Inventory_DropDownList.Items.Insert(0, "إختر مخزون الأصل ....");
                    _sqlCon.Close();
                }

                //    //Fill aseet_Location DropDownList
                using (MySqlCommand getAseetLocationDropDownListCmd =
                       new MySqlCommand("SELECT * FROM asset_location"))
                {
                    getAseetLocationDropDownListCmd.CommandType = CommandType.Text;
                    getAseetLocationDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    Asset_Location_DropDownList.DataSource = getAseetLocationDropDownListCmd.ExecuteReader();
                    Asset_Location_DropDownList.DataTextField = "Asset_Arabic_Location";
                    Asset_Location_DropDownList.DataValueField = "Asset_Location_Id";
                    Asset_Location_DropDownList.DataBind();
                    Asset_Location_DropDownList.Items.Insert(0, "إختر مكان الأصل ....");
                    _sqlCon.Close();
                }

                //Fill aseet_Type DropDownList
                using (MySqlCommand getAseetTypeDropDownListCmd = new MySqlCommand("SELECT * FROM asset_Type"))
                {
                    getAseetTypeDropDownListCmd.CommandType = CommandType.Text;
                    getAseetTypeDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    Asset_Type_DropDownList.DataSource = getAseetTypeDropDownListCmd.ExecuteReader();
                    Asset_Type_DropDownList.DataTextField = "Asset_Arabic_Type";
                    Asset_Type_DropDownList.DataValueField = "Asset_Type_Id";
                    Asset_Type_DropDownList.DataBind();
                    Asset_Type_DropDownList.Items.Insert(0, "أختر نوع الأصل ....");
                    _sqlCon.Close();
                }

                //Fill aseet_Condition DropDownList
                using (MySqlCommand getAseetConditionDropDownListCmd =
                       new MySqlCommand("SELECT * FROM asset_Condition"))
                {
                    getAseetConditionDropDownListCmd.CommandType = CommandType.Text;
                    getAseetConditionDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    Asset_Condition_DropDownList.DataSource = getAseetConditionDropDownListCmd.ExecuteReader();
                    Asset_Condition_DropDownList.DataTextField = "Asset_Arabic_Condition";
                    Asset_Condition_DropDownList.DataValueField = "Asset_Condition_Id";
                    Asset_Condition_DropDownList.DataBind();
                    Asset_Condition_DropDownList.Items.Insert(0, "أختر حالة الاصل ....");
                    _sqlCon.Close();
                }
            }
        }

        protected void Asset_Purchase_Date_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txt_Asset_Purchase_Date.Text = Asset_Purchase_Date_Calendar.SelectedDate.ToShortDateString();
            System.Web.UI.Control div = Page.FindControl("divCalendar");
        }

        protected void btn_Add_Asset_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //Fill The Asset Table With Data From View
                string addAssetQuery = "Insert Into assets (" +
                                       "Assets_English_Name , " +
                                       "Assets_Arabic_Name  , " +
                                       "Assets_Value        , " +
                                       "Purchase_Date       , " +
                                       "Description         , " +
                                       "Quantitiy           , " +
                                       "asset_type_Asset_Type_Id , " +
                                       "inventory_Inventory_Id   , " +
                                       "asset_condition_Asset_Condition_Id , " +
                                       "asset_location_Asset_Location_Id , " +
                                       "building_Building_Id , " +
                                       "units_Unit_ID , " +
                                       "vendor_type_Vendor_Type_Id , " +
                                       "aseet_warranty_Aseet_warranty_Id) " +
                                       "VALUES( " +
                                       "@Assets_English_Name , " +
                                       "@Assets_Arabic_Name  , " +
                                       "@Assets_Value        , " +
                                       "@Purchase_Date       , " +
                                       "@Description         , " +
                                       "@Quantitiy           , " +
                                       "@asset_type_Asset_Type_Id , " +
                                       "@inventory_Inventory_Id   , " +
                                       "@asset_condition_Asset_Condition_Id , " +
                                       "@asset_location_Asset_Location_Id , " +
                                       "@building_Building_Id , " +
                                       "@units_Unit_ID , " +
                                       "@vendor_type_Vendor_Type_Id , " +
                                       "@aseet_warranty_Aseet_warranty_Id ) ";
                _sqlCon.Open();
                using (MySqlCommand addAssetCmd = new MySqlCommand(addAssetQuery, _sqlCon))
                {
                    //Fill The Database with All DropDownLists Items
                    addAssetCmd.Parameters.AddWithValue("@asset_type_Asset_Type_Id",
                        Asset_Type_DropDownList.SelectedValue);
                    addAssetCmd.Parameters.AddWithValue("@inventory_Inventory_Id",
                        Asset_Inventory_DropDownList.SelectedValue);
                    addAssetCmd.Parameters.AddWithValue("@asset_condition_Asset_Condition_Id",
                        Asset_Condition_DropDownList.SelectedValue);
                    addAssetCmd.Parameters.AddWithValue("@asset_location_Asset_Location_Id",
                        Asset_Location_DropDownList.SelectedValue);
                    addAssetCmd.Parameters.AddWithValue("@building_Building_Id",
                        Assets_Building_DropDownList.SelectedValue);
                    addAssetCmd.Parameters.AddWithValue("@units_Unit_ID", Asset_Unit_DropDownList.SelectedValue);
                    addAssetCmd.Parameters.AddWithValue("@vendor_type_Vendor_Type_Id",
                        Asset_Vendor_DropDownList.SelectedValue);
                    addAssetCmd.Parameters.AddWithValue("@aseet_warranty_Aseet_warranty_Id",
                        Asset_Warranty_DropDownList.SelectedValue);
                    //Fill The Database with All Textbox Items
                    addAssetCmd.Parameters.AddWithValue("@Assets_English_Name", txt_En_Asset_Name.Text);
                    addAssetCmd.Parameters.AddWithValue("@Assets_Arabic_Name", txt_Ar_Asset_Name.Text);
                    addAssetCmd.Parameters.AddWithValue("@Assets_Value", txt_Asset_Value.Text);
                    addAssetCmd.Parameters.AddWithValue("@Description", txt_Asset_Description.Text);
                    addAssetCmd.Parameters.AddWithValue("@Quantitiy", txt_Asset_Quantity.Text);
                    addAssetCmd.Parameters.AddWithValue("@Purchase_Date", txt_Asset_Purchase_Date.Text);

                    addAssetCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }

                lbl_Success_Add_New_Asset.Text = "Added successfully";
            }
        }

        protected void btn_Back_To_Asset_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Asset_List.aspx");
        }
    }
}