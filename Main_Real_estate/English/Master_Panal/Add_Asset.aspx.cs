using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Asset : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //Fill Contractor_DropDownList
                Helper.LoadDropDownList("SELECT * FROM contractor ", _sqlCon, Contractor_DropDownList, "Contractor_Ar_Name", "Contractor_ID");
                Contractor_DropDownList.Items.Insert(0, "إختر المقاول....");

                //Fill Buyer_DropDownList
                Helper.LoadDropDownList("SELECT * FROM employee ", _sqlCon, Buyer_DropDownList, "Employee_Arabic_name", "Employee_Id");
                Buyer_DropDownList.Items.Insert(0, "إختر مسؤول الشراء  ....");

                //Fill Inventory_DropDownList
                Helper.LoadDropDownList("SELECT * FROM inventory ", _sqlCon, Inventory_DropDownList, "Inventory_arabic_name", "Inventory_Id");
                Inventory_DropDownList.Items.Insert(0, "إختر اسم المخزن  ....");

                //Fill Asset_Type_DropDownList
                Helper.LoadDropDownList("SELECT * FROM maintenance_categoty where Main_Categoty=0", _sqlCon, Asset_Type_DropDownList, "Categoty_AR", "Categoty_Id");
                Asset_Type_DropDownList.Items.Insert(0, "أختر النوع الأساسي للأصل ....");

                //Fill Asset_Condition_DropDownList
                Helper.LoadDropDownList("SELECT * FROM asset_condition", _sqlCon, Asset_Condition_DropDownList, "Asset_Arabic_Condition", "Asset_Condition_Id");
                Asset_Condition_DropDownList.Items.Insert(0, "أختر حالة الاصل ....");


                //Fill Asset_Vendor_DropDownList
                Helper.LoadDropDownList("SELECT * FROM vendor_typ ", _sqlCon, Asset_Vendor_DropDownList, "Vendor_Arabic_Type", "Vendor_Type_Id");
                Asset_Vendor_DropDownList.Items.Insert(0, "إختر الموّرد  ....");

                //Fill Ownership_Name_DropDownList
                Helper.LoadDropDownList("SELECT * FROM owner_ship", _sqlCon, Ownership_Name_DropDownList, "Owner_Ship_AR_Name", "Owner_Ship_Id");
                Ownership_Name_DropDownList.Items.Insert(0, "إختر اسم الملكية ....");

                //Fill Asset_Location_DropDownList
                Helper.LoadDropDownList("SELECT * FROM asset_location where Asset_Location_Id != 1", _sqlCon, Asset_Location_DropDownList, "Asset_Arabic_Location", "Asset_Location_Id");
                Asset_Location_DropDownList.Items.Insert(0, "إختر مكان الأصل ....");

                // get Value=0 for the Asset_SubType_DropDownList
                Asset_SubType_DropDownList.Items.Insert(0, "أختر النوع الفرعي للأصل ....");

                // get Value=0 for the Building_Name_DropDownList
                Building_Name_DropDownList.Items.Insert(0, "إختر اسم البناء ....");

                // get Value=0 for the Units_DropDownList
                Units_DropDownList.Items.Insert(0, "إختر الوحدة ....");

                // get Value=0 for the How_To_Get_DropDownList
                How_To_Get_DropDownList.Items.Insert(0, "أختر طريقة التملك ....");

                // get Value=0 for the Ownership_Building_Unit_DropDownList
                Ownership_Building_Unit_DropDownList.Items.Insert(0, "إختر ملكية / بناء / وحدة  ....");
            }
        }
        //******************  purchase_Date ***************************************************
        protected void purchase_Date_Calendar_SelectionChanged1(object sender, EventArgs e)
        {
            txt_purchase_Date.Text = purchase_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_purchase_Date.Text != "") { purchase_Date_divCalendar.Visible = false; ImageButton1.Visible = false; }
        }
        protected void Date_Chosee_Click(object sender, EventArgs e)
        { purchase_Date_divCalendar.Visible = true; ImageButton1.Visible = true; }
        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        { purchase_Date_divCalendar.Visible = false; ImageButton1.Visible = false; }
        //******************  Start_Date ***************************************************
        protected void Start_Date_Calendar_SelectionChanged2(object sender, EventArgs e)
        {
            txt_Start_Date.Text = Start_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_Start_Date.Text != "")
            { Start_Date_Div.Visible = false; ImageButton2.Visible = false; }
        }

        protected void Start_Date_Chosee_Click(object sender, EventArgs e)
        { Start_Date_Div.Visible = true; ImageButton2.Visible = true; }

        protected void ImageButton2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        { Start_Date_Div.Visible = false; ImageButton2.Visible = false; }

        //******************  End_Date ***************************************************
        protected void End_Date_Chosee_Click(object sender, EventArgs e)
        { End_Date_Div.Visible = true; ImageButton3.Visible = true; }
        protected void ImageButton3_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        { End_Date_Div.Visible = false; ImageButton3.Visible = false; }
        protected void End_Date_Calendar_SelectionChanged1(object sender, EventArgs e)
        {
            txt_End_Date.Text = End_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_End_Date.Text != "")
            { End_Date_Div.Visible = false; ImageButton3.Visible = false; }
        }

        protected void Asset_Type_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Asset_Type_ID = Asset_Type_DropDownList.SelectedValue;
            Asset_SubType_DropDownList.Enabled = true;
            //Fill Asset_SubType_DropDownList
            Helper.LoadDropDownList("SELECT * FROM maintenance_categoty where  Main_Categoty = '" + Asset_Type_ID + "'", _sqlCon, Asset_SubType_DropDownList, "Categoty_AR", "Categoty_Id");
            Asset_SubType_DropDownList.Items.Insert(0, "أختر النوع الفرعي للأصل ....");
        }

        protected void Ownership_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            string Ownership_Name_ID = Ownership_Name_DropDownList.SelectedValue;
            //Fill Building_Name_DropDownList
            Helper.LoadDropDownList("SELECT * FROM building where owner_ship_Owner_Ship_Id = '" + Ownership_Name_ID + "'", _sqlCon, Building_Name_DropDownList, "Building_Arabic_Name", "Building_Id");
            Building_Name_DropDownList.Items.Insert(0, "إختر اسم البناء ....");
        }

        protected void Building_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            string Building_Name_ID = Building_Name_DropDownList.SelectedValue;

            //Fill Building_Name_DropDownList
            Helper.LoadDropDownList("SELECT * FROM units where building_Building_Id = '" + Building_Name_ID + "'", _sqlCon, Units_DropDownList, "Unit_Number", "Unit_ID");
            Units_DropDownList.Items.Insert(0, "إختر الوحدة ....");
        }

        protected void How_To_Get_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (How_To_Get_DropDownList.SelectedValue == "1")
            {
                Contractor_Warranty_Period_Div.Visible = true;
                Contractor_Div.Visible = true;
                Buyer_Div.Visible = false;
            }
            else
            {
                Contractor_Warranty_Period_Div.Visible = false;
                Contractor_Div.Visible = false;
                Buyer_Div.Visible = true;
            }
        }

        protected void Warenty_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Warenty_CheckBox.Checked == true) { Waranty_Div.Visible = true; }
            else { Waranty_Div.Visible = false; }
        }

        protected void Ownership_Building_Unit_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Ownership_Building_Unit_DropDownList.SelectedValue == "1")
            {
                Ownership_Building_Unit_Div.Visible = true;
                Inventory_Div.Visible = false;
                Building_Name_DropDownList.Enabled = false;
                Units_DropDownList.Enabled = false;
            }
            else if (Ownership_Building_Unit_DropDownList.SelectedValue == "2")
            {
                Ownership_Building_Unit_Div.Visible = true;
                Inventory_Div.Visible = false;
                Building_Name_DropDownList.Enabled = true;
                Units_DropDownList.Enabled = false;
            }
            else if (Ownership_Building_Unit_DropDownList.SelectedValue == "3")
            {
                Ownership_Building_Unit_Div.Visible = true;
                Inventory_Div.Visible = false;
                Building_Name_DropDownList.Enabled = true;
                Units_DropDownList.Enabled = true;
            }
            else
            {
                Ownership_Building_Unit_Div.Visible = false;
                Inventory_Div.Visible = true;
            }
        }

        protected void btn_Add_Asset_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string AddAssetQuary = "Insert Into assets" +
                                       "(asset_location_Asset_Location_Id , " +
                                       "vendor_type_Vendor_Type_Id ," +
                                       "asset_condition_Asset_Condition_Id ," +
                                       "maintenance_categoty_Categoty_Id ," +
                                       "Assets_English_Name ," +
                                       "Assets_Arabic_Name ," +
                                       "Assets_Value ," +
                                       "Purchase_Date ," +
                                       "Description ," +
                                       "Serial_Number ," +
                                       "Main_Place ," +
                                       "How_To_Get ," +
                                       "Contractor ," +
                                       "Buyer ," +
                                       "Contractor_Waranty_Period ," +
                                       "Waranty_Period ," +
                                       "Waranty_Start_Date ," +
                                       "Waranty_End_Date ," +
                                       "Waranty_Certificate ," +
                                       "Waranty_Certificate_Path ," +
                                       "Inventory_Id ," +
                                       "OwnerShip_Id ," +
                                       "Building_ID , " +
                                       "Unit_Id)" +

                                       " VALUES" +

                                       "(@asset_location_Asset_Location_Id," +
                                       "@vendor_type_Vendor_Type_Id ," +
                                       "@asset_condition_Asset_Condition_Id ," +
                                       "@maintenance_categoty_Categoty_Id ," +
                                       "@Assets_English_Name ," +
                                       "@Assets_Arabic_Name ," +
                                       "@Assets_Value ," +
                                       "@Purchase_Date ," +
                                       "@Description ," +
                                       "@Serial_Number ," +
                                       "@Main_Place ," +
                                       "@How_To_Get ," +
                                       "@Contractor ," +
                                       "@Buyer ," +
                                       "@Contractor_Waranty_Period ," +
                                       "@Waranty_Period ," +
                                       "@Waranty_Start_Date ," +
                                       "@Waranty_End_Date ," +
                                       "@Waranty_Certificate ," +
                                       "@Waranty_Certificate_Path ," +
                                       "@Inventory_Id ," +
                                       "@OwnerShip_Id ," +
                                       "@Building_ID , " +
                                       "@Unit_Id)";
                _sqlCon.Open();
                using (MySqlCommand addAssetCmd = new MySqlCommand(AddAssetQuary, _sqlCon))
                {
                    // Main Place Cases 
                    addAssetCmd.Parameters.AddWithValue("@Main_Place", Ownership_Building_Unit_DropDownList.SelectedItem.Text.Trim());
                    if (Ownership_Building_Unit_DropDownList.SelectedValue == "1")
                    {
                        addAssetCmd.Parameters.AddWithValue("@OwnerShip_Id", Ownership_Name_DropDownList.SelectedValue);
                        addAssetCmd.Parameters.AddWithValue("@Building_ID", "");
                        addAssetCmd.Parameters.AddWithValue("@Unit_Id", "");
                        addAssetCmd.Parameters.AddWithValue("@asset_location_Asset_Location_Id", Asset_Location_DropDownList.SelectedValue);
                        addAssetCmd.Parameters.AddWithValue("@Inventory_Id", "1");
                    }
                    else if (Ownership_Building_Unit_DropDownList.SelectedValue == "2")
                    {
                        addAssetCmd.Parameters.AddWithValue("@OwnerShip_Id", Ownership_Name_DropDownList.SelectedValue);
                        addAssetCmd.Parameters.AddWithValue("@Building_ID", Building_Name_DropDownList.SelectedValue);
                        addAssetCmd.Parameters.AddWithValue("@Unit_Id", "");
                        addAssetCmd.Parameters.AddWithValue("@asset_location_Asset_Location_Id", Asset_Location_DropDownList.SelectedValue);
                        addAssetCmd.Parameters.AddWithValue("@Inventory_Id", "1");
                    }
                    else if (Ownership_Building_Unit_DropDownList.SelectedValue == "3")
                    {
                        addAssetCmd.Parameters.AddWithValue("@OwnerShip_Id", Ownership_Name_DropDownList.SelectedValue);
                        addAssetCmd.Parameters.AddWithValue("@Building_ID", Building_Name_DropDownList.SelectedValue);
                        addAssetCmd.Parameters.AddWithValue("@Unit_Id", Units_DropDownList.SelectedValue);
                        addAssetCmd.Parameters.AddWithValue("@asset_location_Asset_Location_Id", Asset_Location_DropDownList.SelectedValue);
                        addAssetCmd.Parameters.AddWithValue("@Inventory_Id", "1");
                    }
                    else
                    {
                        addAssetCmd.Parameters.AddWithValue("@OwnerShip_Id", "");
                        addAssetCmd.Parameters.AddWithValue("@Building_ID", "");
                        addAssetCmd.Parameters.AddWithValue("@Unit_Id", "");
                        addAssetCmd.Parameters.AddWithValue("@asset_location_Asset_Location_Id", "1");
                        addAssetCmd.Parameters.AddWithValue("@Inventory_Id", Inventory_DropDownList.SelectedValue);
                    }
                    // How To Get Cases
                    addAssetCmd.Parameters.AddWithValue("@How_To_Get", How_To_Get_DropDownList.SelectedItem.Text.Trim());
                    if (How_To_Get_DropDownList.SelectedValue == "1")
                    {
                        addAssetCmd.Parameters.AddWithValue("@Contractor", Contractor_DropDownList.SelectedValue);
                        addAssetCmd.Parameters.AddWithValue("@Contractor_Waranty_Period", txt_Contractor_Warranty_Period.Text);
                        addAssetCmd.Parameters.AddWithValue("@vendor_type_Vendor_Type_Id", Asset_Vendor_DropDownList.SelectedValue);
                        addAssetCmd.Parameters.AddWithValue("@Buyer", "");
                    }
                    else
                    {
                        addAssetCmd.Parameters.AddWithValue("@Contractor", "");
                        addAssetCmd.Parameters.AddWithValue("@Contractor_Waranty_Period", "");
                        addAssetCmd.Parameters.AddWithValue("@vendor_type_Vendor_Type_Id", Asset_Vendor_DropDownList.SelectedValue);
                        addAssetCmd.Parameters.AddWithValue("@Buyer", Buyer_DropDownList.SelectedValue);
                    }


                    addAssetCmd.Parameters.AddWithValue("@asset_condition_Asset_Condition_Id", Asset_Condition_DropDownList.Text);
                    addAssetCmd.Parameters.AddWithValue("@maintenance_categoty_Categoty_Id", Asset_SubType_DropDownList.Text);
                    addAssetCmd.Parameters.AddWithValue("@Assets_English_Name", txt_En_Asset_Name.Text);
                    addAssetCmd.Parameters.AddWithValue("@Assets_Arabic_Name", txt_Ar_Asset_Name.Text);
                    addAssetCmd.Parameters.AddWithValue("@Assets_Value", txt_Asset_Value.Text);
                    addAssetCmd.Parameters.AddWithValue("@Purchase_Date", txt_purchase_Date.Text);
                    addAssetCmd.Parameters.AddWithValue("@Description", txt_Asset_Description.Text);
                    addAssetCmd.Parameters.AddWithValue("@Serial_Number", txt_Serial_Number.Text);




                    addAssetCmd.Parameters.AddWithValue("@Waranty_Period", txt_Warranty_Period.Text);
                    addAssetCmd.Parameters.AddWithValue("@Waranty_Start_Date", txt_Start_Date.Text);
                    addAssetCmd.Parameters.AddWithValue("@Waranty_End_Date", txt_End_Date.Text);

                    if (Waranty_Image_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(Waranty_Image_FileUpload.PostedFile.FileName);
                        Waranty_Image_FileUpload.PostedFile.SaveAs(Server.MapPath("/English/Master_Panal/Waranty_Images/") + fileName1);
                        addAssetCmd.Parameters.AddWithValue("@Waranty_Certificate", fileName1);
                        addAssetCmd.Parameters.AddWithValue("@Waranty_Certificate_Path", "/English/Master_Panal/Waranty_Images/" + fileName1);
                    }
                    else
                    {
                        addAssetCmd.Parameters.AddWithValue("@Waranty_Certificate", "No File");
                        addAssetCmd.Parameters.AddWithValue("@Waranty_Certificate_Path", "No File");
                    }

                    addAssetCmd.ExecuteNonQuery();
                    if (_sqlCon.State != ConnectionState.Closed)
                    {
                        _sqlCon.Close();
                    }
                    lbl_Success_Add_New_Asset.Text = "تمت الإضافة بنجاح";
                }


                //    Get The Last Asset Id
                using (MySqlCommand Last_Asset_ID_Cmd = new MySqlCommand("SELECT MAX(Assets_Id) AS LastInsertedID from assets", _sqlCon))
                {
                    _sqlCon.Open(); Last_Asset_ID_Cmd.CommandType = CommandType.Text;
                    object Asset_ID = Last_Asset_ID_Cmd.ExecuteScalar();
                    if (Asset_ID != null) { Last_Asset_ID.Text = Asset_ID.ToString(); }
                    _sqlCon.Close();
                }
                if (Ownership_Building_Unit_DropDownList.SelectedValue != "4" && Asset_SubType_DropDownList.SelectedValue == "13" || Asset_SubType_DropDownList.SelectedValue == "15" || Asset_SubType_DropDownList.SelectedValue == "36")
                {
                    string AddAssetInPeriodicMaintenaneQuary = "Insert Into periodic_maintenence (Asset_ID , Year) VALUES (@Asset_ID , @Year)";
                    _sqlCon.Open();
                    using (MySqlCommand addAssetInPeriodicMaintenaneCmd = new MySqlCommand(AddAssetInPeriodicMaintenaneQuary, _sqlCon))
                    {
                        addAssetInPeriodicMaintenaneCmd.Parameters.AddWithValue("@Asset_ID", Last_Asset_ID.Text);
                        addAssetInPeriodicMaintenaneCmd.Parameters.AddWithValue("@Year", Convert.ToString(DateTime.Now.Year));
                        addAssetInPeriodicMaintenaneCmd.ExecuteNonQuery();
                        if (_sqlCon.State != ConnectionState.Closed) { _sqlCon.Close(); }
                    }
                }
            }
        }

        protected void btn_Back_To_Asset_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Asset_List.aspx");
        }


    }

}