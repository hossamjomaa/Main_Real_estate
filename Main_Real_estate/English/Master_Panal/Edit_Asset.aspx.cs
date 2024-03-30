using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Asset : System.Web.UI.Page
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

                //Fill Asset_SubType_DropDownList
                Helper.LoadDropDownList("SELECT * FROM maintenance_categoty where Main_Categoty !=0", _sqlCon, Asset_SubType_DropDownList, "Categoty_AR", "Categoty_Id");
                Asset_SubType_DropDownList.Items.Insert(0, "أختر النوع الفرعي للأصل ....");

                //Fill Asset_Condition_DropDownList
                Helper.LoadDropDownList("SELECT * FROM asset_condition", _sqlCon, Asset_Condition_DropDownList, "Asset_Arabic_Condition", "Asset_Condition_Id");
                Asset_Condition_DropDownList.Items.Insert(0, "أختر حالة الاصل ....");


                //Fill Asset_Vendor_DropDownList
                Helper.LoadDropDownList("SELECT * FROM vendor_typ ", _sqlCon, Asset_Vendor_DropDownList, "Vendor_Arabic_Type", "Vendor_Type_Id");
                Asset_Vendor_DropDownList.Items.Insert(0, "إختر الموّرد  ....");

                //Fill Ownership_Name_DropDownList
                Helper.LoadDropDownList("SELECT * FROM owner_ship", _sqlCon, Ownership_Name_DropDownList, "Owner_Ship_AR_Name", "Owner_Ship_Id");
                Ownership_Name_DropDownList.Items.Insert(0, "إختر اسم الملكية ....");

                //Fill Building_Name_DropDownList
                Helper.LoadDropDownList("SELECT * FROM building", _sqlCon, Building_Name_DropDownList, "Building_Arabic_Name", "Building_Id");
                Building_Name_DropDownList.Items.Insert(0, "إختر اسم البناء ....");

                //Fill Units_DropDownList
                Helper.LoadDropDownList("SELECT * FROM units", _sqlCon, Units_DropDownList, "Unit_Number", "Unit_ID");
                Units_DropDownList.Items.Insert(0, "إختر الوحدة ....");

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


                // Get The All Asset Data From DataBase
                string assetId = Request.QueryString["Id"];
                DataTable getAssetDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getAssetCmd = new MySqlCommand("SELECT * FROM assets WHERE Assets_Id = @ID", _sqlCon);
                MySqlDataAdapter getAssetDa = new MySqlDataAdapter(getAssetCmd);
                getAssetCmd.Parameters.AddWithValue("@ID", assetId);
                getAssetDa.Fill(getAssetDt);
                if (getAssetDt.Rows.Count > 0)
                {
                    if (getAssetDt.Rows[0]["Main_Place"].ToString() == "ملكية")
                    {
                        Ownership_Building_Unit_Div.Visible = true; Inventory_Div.Visible = false; Units_DropDownList.Enabled = false; Building_Name_DropDownList.Enabled = false;
                        Ownership_Building_Unit_DropDownList.SelectedValue = "1";
                        Ownership_Name_DropDownList.SelectedValue = getAssetDt.Rows[0]["OwnerShip_Id"].ToString();
                        Asset_Location_DropDownList.SelectedValue = getAssetDt.Rows[0]["asset_location_Asset_Location_Id"].ToString();
                    }
                    else if (getAssetDt.Rows[0]["Main_Place"].ToString() == "بناء")
                    {
                        Ownership_Building_Unit_Div.Visible = true; Inventory_Div.Visible = false; Units_DropDownList.Enabled = false; Building_Name_DropDownList.Enabled = true;
                        Ownership_Building_Unit_DropDownList.SelectedValue = "2";
                        Ownership_Name_DropDownList.SelectedValue = getAssetDt.Rows[0]["OwnerShip_Id"].ToString();
                        Building_Name_DropDownList.SelectedValue = getAssetDt.Rows[0]["Building_ID"].ToString();
                        Asset_Location_DropDownList.SelectedValue = getAssetDt.Rows[0]["asset_location_Asset_Location_Id"].ToString();
                    }
                    else if (getAssetDt.Rows[0]["Main_Place"].ToString() == "وحدة")
                    {
                        Ownership_Building_Unit_Div.Visible = true; Inventory_Div.Visible = false; Units_DropDownList.Enabled = true; Building_Name_DropDownList.Enabled = true;
                        Ownership_Building_Unit_DropDownList.SelectedValue = "3";
                        Ownership_Name_DropDownList.SelectedValue = getAssetDt.Rows[0]["OwnerShip_Id"].ToString();
                        Building_Name_DropDownList.SelectedValue = getAssetDt.Rows[0]["Building_ID"].ToString();
                        Units_DropDownList.SelectedValue = getAssetDt.Rows[0]["Unit_Id"].ToString();
                        Asset_Location_DropDownList.SelectedValue = getAssetDt.Rows[0]["asset_location_Asset_Location_Id"].ToString();
                    }
                    else
                    {
                        Ownership_Building_Unit_Div.Visible = false; Inventory_Div.Visible = true;
                        Ownership_Building_Unit_DropDownList.SelectedValue = "4";
                        Inventory_DropDownList.SelectedValue = getAssetDt.Rows[0]["Inventory_Id"].ToString();
                    }

                    Asset_Condition_DropDownList.SelectedValue = getAssetDt.Rows[0]["asset_condition_Asset_Condition_Id"].ToString();
                    Asset_SubType_DropDownList.SelectedValue = getAssetDt.Rows[0]["maintenance_categoty_Categoty_Id"].ToString();
                    txt_En_Asset_Name.Text = getAssetDt.Rows[0]["Assets_English_Name"].ToString();
                    txt_Ar_Asset_Name.Text = getAssetDt.Rows[0]["Assets_Arabic_Name"].ToString();
                    txt_Serial_Number.Text = getAssetDt.Rows[0]["Serial_Number"].ToString();
                    txt_purchase_Date.Text = getAssetDt.Rows[0]["Purchase_Date"].ToString();
                    txt_Asset_Value.Text = getAssetDt.Rows[0]["Assets_Value"].ToString();
                    txt_Asset_Description.Text = getAssetDt.Rows[0]["Description"].ToString();
                    txt_Warranty_Period.Text = getAssetDt.Rows[0]["Waranty_Period"].ToString();
                    txt_Start_Date.Text = getAssetDt.Rows[0]["Waranty_Start_Date"].ToString();
                    txt_End_Date.Text = getAssetDt.Rows[0]["Waranty_End_Date"].ToString();
                    Waranty_Image_FileName.Text = getAssetDt.Rows[0]["Waranty_Certificate"].ToString();
                    Waranty_Image_Path.Text = getAssetDt.Rows[0]["Waranty_Certificate_Path"].ToString();


                    DataTable getCatigoryDt = new DataTable();
                    MySqlCommand getCatigoryCmd = new MySqlCommand("SELECT Main_Categoty FROM maintenance_categoty WHERE Categoty_Id = @ID", _sqlCon);
                    MySqlDataAdapter getCatigoryDa = new MySqlDataAdapter(getCatigoryCmd);
                    getCatigoryCmd.Parameters.AddWithValue("@ID", Asset_SubType_DropDownList.SelectedValue);
                    getCatigoryDa.Fill(getCatigoryDt);
                    if (getCatigoryDt.Rows.Count > 0)
                    {
                        Asset_Type_DropDownList.SelectedValue = getCatigoryDt.Rows[0]["Main_Categoty"].ToString();
                    }



                    if (getAssetDt.Rows[0]["How_To_Get"].ToString() == "ضمن مشروع")
                    {
                        How_To_Get_DropDownList.SelectedValue = "1";
                        Contractor_Div.Visible = true; Contractor_DropDownList.SelectedValue = getAssetDt.Rows[0]["Contractor"].ToString();
                        Asset_Vendor_DropDownList.SelectedValue = getAssetDt.Rows[0]["vendor_type_Vendor_Type_Id"].ToString();
                        Contractor_Warranty_Period_Div.Visible = true; txt_Contractor_Warranty_Period.Text = getAssetDt.Rows[0]["Contractor_Waranty_Period"].ToString();
                        Buyer_Div.Visible = false;
                    }
                    else
                    {
                        How_To_Get_DropDownList.SelectedValue = "2";
                        Contractor_Div.Visible = false;
                        Asset_Vendor_DropDownList.SelectedValue = getAssetDt.Rows[0]["vendor_type_Vendor_Type_Id"].ToString();
                        Contractor_Warranty_Period_Div.Visible = false;
                        Buyer_Div.Visible = true; Buyer_DropDownList.SelectedValue = getAssetDt.Rows[0]["Buyer"].ToString();
                    }


                    if (getAssetDt.Rows[0]["Waranty_Period"].ToString() != "")
                    {
                        Warenty_CheckBox.Checked = true;
                        Waranty_Div.Visible = true;
                    }
                    else
                    {
                        Warenty_CheckBox.Checked = false;
                        Waranty_Div.Visible = false;

                    }
                }

                _sqlCon.Close();
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

        protected void btn_Edit_Asset_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string assetId = Request.QueryString["ID"];
                string updateAssetQuery = "UPDATE assets SET " +
                                          "asset_location_Asset_Location_Id=@asset_location_Asset_Location_Id ," +
                                          "vendor_type_Vendor_Type_Id=@vendor_type_Vendor_Type_Id ," +
                                          "asset_condition_Asset_Condition_Id=@asset_condition_Asset_Condition_Id ," +
                                          "maintenance_categoty_Categoty_Id=@maintenance_categoty_Categoty_Id ," +
                                          "Assets_English_Name=@Assets_English_Name ," +
                                          "Assets_Arabic_Name=@Assets_Arabic_Name ," +
                                          "Assets_Value=@Assets_Value ," +
                                          "Purchase_Date=@Purchase_Date ," +
                                          "Description=@Description ," +
                                          "Serial_Number=@Serial_Number ," +
                                          "Main_Place=@Main_Place ," +
                                          "How_To_Get=@How_To_Get ," +
                                          "Contractor=@Contractor ," +
                                          "Buyer=@Buyer  ," +
                                          "Contractor_Waranty_Period=@Contractor_Waranty_Period ," +
                                          "Waranty_Period=@Waranty_Period ," +
                                          "Waranty_Start_Date=@Waranty_Start_Date ," +
                                          "Waranty_End_Date=@Waranty_End_Date ," +
                                          "Waranty_Certificate=@Waranty_Certificate ," +
                                          "Waranty_Certificate_Path=@Waranty_Certificate_Path ," +
                                          "Inventory_Id=@Inventory_Id ," +
                                          "OwnerShip_Id=@OwnerShip_Id ," +
                                          "Building_ID=@Building_ID ," +
                                          "Unit_Id=@Unit_Id " +
                                          "WHERE Assets_Id=@ID ";
                _sqlCon.Open();
                using (MySqlCommand updateAssetCmd = new MySqlCommand(updateAssetQuery, _sqlCon))
                {
                    updateAssetCmd.Parameters.AddWithValue("@ID", assetId);

                    // Main Place Cases 
                    updateAssetCmd.Parameters.AddWithValue("@Main_Place", Ownership_Building_Unit_DropDownList.SelectedItem.Text.Trim());
                    if (Ownership_Building_Unit_DropDownList.SelectedValue == "1")
                    {
                        updateAssetCmd.Parameters.AddWithValue("@OwnerShip_Id", Ownership_Name_DropDownList.SelectedValue);
                        updateAssetCmd.Parameters.AddWithValue("@Building_ID", "");
                        updateAssetCmd.Parameters.AddWithValue("@Unit_Id", "");
                        updateAssetCmd.Parameters.AddWithValue("@asset_location_Asset_Location_Id", Asset_Location_DropDownList.SelectedValue);
                        updateAssetCmd.Parameters.AddWithValue("@Inventory_Id", "1");
                    }
                    else if (Ownership_Building_Unit_DropDownList.SelectedValue == "2")
                    {
                        updateAssetCmd.Parameters.AddWithValue("@OwnerShip_Id", Ownership_Name_DropDownList.SelectedValue);
                        updateAssetCmd.Parameters.AddWithValue("@Building_ID", Building_Name_DropDownList.SelectedValue);
                        updateAssetCmd.Parameters.AddWithValue("@Unit_Id", "");
                        updateAssetCmd.Parameters.AddWithValue("@asset_location_Asset_Location_Id", Asset_Location_DropDownList.SelectedValue);
                        updateAssetCmd.Parameters.AddWithValue("@Inventory_Id", "1");
                    }
                    else if (Ownership_Building_Unit_DropDownList.SelectedValue == "3")
                    {
                        updateAssetCmd.Parameters.AddWithValue("@OwnerShip_Id", Ownership_Name_DropDownList.SelectedValue);
                        updateAssetCmd.Parameters.AddWithValue("@Building_ID", Building_Name_DropDownList.SelectedValue);
                        updateAssetCmd.Parameters.AddWithValue("@Unit_Id", Units_DropDownList.SelectedValue);
                        updateAssetCmd.Parameters.AddWithValue("@asset_location_Asset_Location_Id", Asset_Location_DropDownList.SelectedValue);
                        updateAssetCmd.Parameters.AddWithValue("@Inventory_Id", "1");
                    }
                    else
                    {
                        updateAssetCmd.Parameters.AddWithValue("@OwnerShip_Id", "");
                        updateAssetCmd.Parameters.AddWithValue("@Building_ID", "");
                        updateAssetCmd.Parameters.AddWithValue("@Unit_Id", "");
                        updateAssetCmd.Parameters.AddWithValue("@asset_location_Asset_Location_Id", "1");
                        updateAssetCmd.Parameters.AddWithValue("@Inventory_Id", Inventory_DropDownList.SelectedValue);
                    }

                    // How To Get Cases
                    updateAssetCmd.Parameters.AddWithValue("@How_To_Get", How_To_Get_DropDownList.SelectedItem.Text.Trim());
                    if (How_To_Get_DropDownList.SelectedValue == "1")
                    {
                        updateAssetCmd.Parameters.AddWithValue("@Contractor", Contractor_DropDownList.Text);
                        updateAssetCmd.Parameters.AddWithValue("@Contractor_Waranty_Period", txt_Contractor_Warranty_Period.Text);
                        updateAssetCmd.Parameters.AddWithValue("@vendor_type_Vendor_Type_Id", Asset_Vendor_DropDownList.SelectedValue);
                        updateAssetCmd.Parameters.AddWithValue("@Buyer", "");
                    }
                    else
                    {
                        updateAssetCmd.Parameters.AddWithValue("@Contractor", "");
                        updateAssetCmd.Parameters.AddWithValue("@Contractor_Waranty_Period", "");
                        updateAssetCmd.Parameters.AddWithValue("@vendor_type_Vendor_Type_Id", Asset_Vendor_DropDownList.SelectedValue);
                        updateAssetCmd.Parameters.AddWithValue("@Buyer", Buyer_DropDownList.SelectedValue);
                    }


                    updateAssetCmd.Parameters.AddWithValue("@asset_condition_Asset_Condition_Id", Asset_Condition_DropDownList.Text);
                    updateAssetCmd.Parameters.AddWithValue("@maintenance_categoty_Categoty_Id", Asset_SubType_DropDownList.Text);
                    updateAssetCmd.Parameters.AddWithValue("@Assets_English_Name", txt_En_Asset_Name.Text);
                    updateAssetCmd.Parameters.AddWithValue("@Assets_Arabic_Name", txt_Ar_Asset_Name.Text);
                    updateAssetCmd.Parameters.AddWithValue("@Assets_Value", txt_Asset_Value.Text);
                    updateAssetCmd.Parameters.AddWithValue("@Purchase_Date", txt_purchase_Date.Text);
                    updateAssetCmd.Parameters.AddWithValue("@Description", txt_Asset_Description.Text);
                    updateAssetCmd.Parameters.AddWithValue("@Serial_Number", txt_Serial_Number.Text);




                    updateAssetCmd.Parameters.AddWithValue("@Waranty_Period", txt_Warranty_Period.Text);
                    updateAssetCmd.Parameters.AddWithValue("@Waranty_Start_Date", txt_Start_Date.Text);
                    updateAssetCmd.Parameters.AddWithValue("@Waranty_End_Date", txt_End_Date.Text);

                    if (Waranty_Image_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(Waranty_Image_FileUpload.PostedFile.FileName);
                        Waranty_Image_FileUpload.PostedFile.SaveAs(Server.MapPath("/English/Master_Panal/Waranty_Images/") + fileName1);
                        updateAssetCmd.Parameters.AddWithValue("@Waranty_Certificate", fileName1);
                        updateAssetCmd.Parameters.AddWithValue("@Waranty_Certificate_Path", "/English/Master_Panal/Waranty_Images/" + fileName1);
                    }
                    else
                    {
                        updateAssetCmd.Parameters.AddWithValue("@Waranty_Certificate", Waranty_Image_FileName.Text);
                        updateAssetCmd.Parameters.AddWithValue("@Waranty_Certificate_Path", Waranty_Image_Path.Text);
                    }
                    updateAssetCmd.ExecuteNonQuery();
                    if (Ownership_Building_Unit_DropDownList.SelectedValue != "4" && Asset_SubType_DropDownList.SelectedValue != "13" || Asset_SubType_DropDownList.SelectedValue != "15" || Asset_SubType_DropDownList.SelectedValue != "36")
                    {
                        int year = DateTime.Now.Year;
                        //MySqlConnection SqlCon = Helper.GetConnection();
                        MySqlConnection sqlCon = Helper.GetConnection();
                        MySqlDataAdapter Sda = new MySqlDataAdapter("Select Asset_ID from periodic_maintenence where Asset_ID='" + assetId + "'", sqlCon);
                        DataTable dt = new DataTable();
                        Sda.Fill(dt);
                        if (dt.Rows.Count == 0)
                        {
                            string sql = "";
                            sql += "INSERT INTO periodic_maintenence (Asset_ID , Year ) Values ('" + assetId + "','" + year + "')";
                            MySqlCommand cmd = new MySqlCommand(sql, _sqlCon);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                    }
                    _sqlCon.Close();
                }

                lbl_Success_Edit_Asset.Text = "تم التعديل بنجاح";
            }
        }

        protected void btn_Back_To_Asset_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Asset_List.aspx");
        }
    }
}