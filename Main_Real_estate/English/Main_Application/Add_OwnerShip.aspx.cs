using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Add_OwnerShip : System.Web.UI.Page
    {
        // Database Connection String
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

/*
        private string _ownwerShipId;
*/

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "properties", 0, "R");
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "properties", 1, "A");
                //txt_Ownership_Space_Number.ReadOnly = true;

                //    //Get Owner DropDownList
                using (MySqlCommand getOwnerDropDownListCmd = new MySqlCommand("SELECT * FROM owner"))
                {
                    getOwnerDropDownListCmd.CommandType = CommandType.Text;
                    getOwnerDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    Owner_DropDownList.DataSource = getOwnerDropDownListCmd.ExecuteReader();
                    Owner_DropDownList.DataTextField = "Owner_Arabic_name";
                    Owner_DropDownList.DataValueField = "Owner_Id";
                    Owner_DropDownList.DataBind();
                    Owner_DropDownList.Items.Insert(0, "اختر إسم المالك ....");
                    _sqlCon.Close();
                }

                //    //Get Ownership Status  DropDownList
                using (MySqlCommand getOwnershipStatusDropDownListCmd =
                       new MySqlCommand("SELECT * FROM ownership_status"))
                {
                    getOwnershipStatusDropDownListCmd.CommandType = CommandType.Text;
                    getOwnershipStatusDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    Ownership_Status_DropDownList.DataSource = getOwnershipStatusDropDownListCmd.ExecuteReader();
                    Ownership_Status_DropDownList.DataTextField = "ownership_Arabic_status";
                    Ownership_Status_DropDownList.DataValueField = "ownership_status_id";
                    Ownership_Status_DropDownList.DataBind();
                    Ownership_Status_DropDownList.Items.Insert(0, "إختر حالة الملكية ....");
                    _sqlCon.Close();
                }

                //    //Get Zone Name DropDownList
                using (MySqlCommand getZoneDropDownListCmd = new MySqlCommand("SELECT * FROM Zone"))
                {
                    getZoneDropDownListCmd.CommandType = CommandType.Text;
                    getZoneDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    Zone_Name_DropDownList.DataSource = getZoneDropDownListCmd.ExecuteReader();
                    Zone_Name_DropDownList.DataTextField = "zone_Arabic_name";
                    Zone_Name_DropDownList.DataValueField = "zone_Id";
                    Zone_Name_DropDownList.DataBind();
                    Zone_Name_DropDownList.Items.Insert(0, "أختر إسم المنطقة ....");
                    _sqlCon.Close();
                }

                //    //Get Building Type DropDownList
                using (MySqlCommand getBuildingTypeDropDownListCmd =
                       new MySqlCommand("SELECT * FROM building_type"))
                {
                    getBuildingTypeDropDownListCmd.CommandType = CommandType.Text;
                    getBuildingTypeDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    Buildings_Type_DropDownList.DataSource = getBuildingTypeDropDownListCmd.ExecuteReader();
                    Buildings_Type_DropDownList.DataTextField = "Building_Arabic_Type";
                    Buildings_Type_DropDownList.DataValueField = "Building_Type_Id";
                    Buildings_Type_DropDownList.DataBind();
                    Buildings_Type_DropDownList.Items.Insert(0, "أختر نوع الأبنية ....");
                    _sqlCon.Close();
                }
                //***************************** Buliding DrowpList **********************************************

                //    //Get Building_Condition DropDownList
                using (MySqlCommand getBuildingConditionDropDownListCmd =
                       new MySqlCommand("SELECT * FROM building_condition"))
                {
                    getBuildingConditionDropDownListCmd.CommandType = CommandType.Text;
                    getBuildingConditionDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    B_Building_Condition_DropDownList.DataSource =
                        getBuildingConditionDropDownListCmd.ExecuteReader();
                    B_Building_Condition_DropDownList.DataTextField = "Building_Arabic_Condition";
                    B_Building_Condition_DropDownList.DataValueField = "Building_Condition_Id";
                    B_Building_Condition_DropDownList.DataBind();
                    B_Building_Condition_DropDownList.Items.Insert(0, "اختر حالة البناء ....");
                    _sqlCon.Close();
                }

                //    //Get Building_Type  DropDownList
                using (MySqlCommand getBuildingTypeDropDownListCmd =
                       new MySqlCommand("SELECT * FROM building_type"))
                {
                    getBuildingTypeDropDownListCmd.CommandType = CommandType.Text;
                    getBuildingTypeDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    B_Building_Type_DropDownList.DataSource = getBuildingTypeDropDownListCmd.ExecuteReader();
                    B_Building_Type_DropDownList.DataTextField = "Building_Arabic_Type";
                    B_Building_Type_DropDownList.DataValueField = "Building_Type_Id";
                    B_Building_Type_DropDownList.DataBind();
                    B_Building_Type_DropDownList.Items.Insert(0, "إختر نوع البناء ....");
                    _sqlCon.Close();
                }

                //    //Get Units_Type DropDownList
                using (MySqlCommand getUnitsTypeDropDownListCmd = new MySqlCommand("SELECT * FROM unit_type"))
                {
                    getUnitsTypeDropDownListCmd.CommandType = CommandType.Text;
                    getUnitsTypeDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    B_Units_Type_DropDownList.DataSource = getUnitsTypeDropDownListCmd.ExecuteReader();
                    B_Units_Type_DropDownList.DataTextField = "Unit_Arabic_Type";
                    B_Units_Type_DropDownList.DataValueField = "Unit_Type_Id";
                    B_Units_Type_DropDownList.DataBind();
                    B_Units_Type_DropDownList.Items.Insert(0, "أختر نوعية الوحدات ....");
                    _sqlCon.Close();
                }

                //    //Get ownership_Name DropDownList
                //using (MySqlCommand Get_ownership_Name_DropDownList_CMD = new MySqlCommand("SELECT * FROM owner_ship"))
                //{
                //    Get_ownership_Name_DropDownList_CMD.CommandType = CommandType.Text;
                //    Get_ownership_Name_DropDownList_CMD.Connection = SqlCon;
                //    SqlCon.Open();
                //    B_ownership_Name_DropDownList.DataSource = Get_ownership_Name_DropDownList_CMD.ExecuteReader();
                //    B_ownership_Name_DropDownList.DataTextField = "Owner_Ship_AR_Name";
                //    B_ownership_Name_DropDownList.DataValueField = "Owner_Ship_Id";
                //    B_ownership_Name_DropDownList.DataBind();
                //    B_ownership_Name_DropDownList.Items.Insert(0, "أختر إسم الملكية....");
                //    SqlCon.Close();
                //}
            }
        }

        // Add OWnership Bottun
        protected void btn_Add_Ownership_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //Get The Owner_Ship Table With Data From View
                string addOwnershipQuery = "Insert Into owner_ship (owner_Owner_Id  ,   " +
                                           "zone_zone_Id  ,  " +
                                           "ownership_status_ownership_status_id , " +
                                           "building_type_Building_Type_Id," +
                                           "Owner_Ship_EN_Name," +
                                           "Owner_Ship_AR_Name ," +
                                           "owner_ship_Code, " +
                                           "owner_ship_Number , " +
                                           "Street," +
                                           "owner_ship_Certificate , " +
                                           "Land_Initial_Value , " +
                                           "Building_Number," +
                                           "Space_Number , " +
                                           "Area_Space , " +
                                           "Bond_Update," +
                                           "Annual_Difference," +
                                           "ROI," +
                                           "Remaining_amount," +
                                           "Building_Value," +
                                           "Annual_Revenue," +
                                           "Mortgage_Status , " +
                                           "Remaining_time , " +
                                           "Total_Value," +
                                           "Difference_of_the_collections," +
                                           "Mortgage_Value, " +
                                           "Release_date ," +
                                           "owner_ship_Certificate_Image , " +
                                           "owner_ship_Certificate_Image_Path ," +
                                           "Complition_Certificate_Image," +
                                           "Complition_Certificate_Image_Path , " +
                                           "Building_License_Image , " +
                                           "Building_License_Image_path , " +
                                           "Plan_Image , " +
                                           "Plan_Image_Path , " +
                                           "Statment_Image , " +
                                           "Statment_Image_path , " +
                                           "Othe_Image , " +
                                           "Othe_Image_Path)" +
                                           " VALUES (@owner_Owner_Id ,   " +
                                           "@zone_zone_Id ,  " +
                                           "@ownership_status_ownership_status_id ," +
                                           "@building_type_Building_Type_Id," +
                                           "@Owner_Ship_EN_Name , " +
                                           "@Owner_Ship_AR_Name , " +
                                           "@owner_ship_Code," +
                                           "@owner_ship_Number , " +
                                           "@Street," +
                                           "@owner_ship_Certificate ," +
                                           "@Land_Initial_Value ," +
                                           "@Building_Number," +
                                           "@Space_Number , " +
                                           "@Area_Space ," +
                                           "@Bond_Update," +
                                           "@Annual_Difference," +
                                           "@ROI," +
                                           "@Remaining_amount," +
                                           "@Building_Value," +
                                           "@Annual_Revenue," +
                                           "@Mortgage_Status , " +
                                           "@Remaining_time , " +
                                           "@Total_Value," +
                                           "@Difference_of_the_collections," +
                                           "@Mortgage_Value, " +
                                           "@Release_date," +
                                           "@owner_ship_Certificate_Image ," +
                                           "@owner_ship_Certificate_Image_Path ," +
                                           "@Complition_Certificate_Image," +
                                           "@Complition_Certificate_Image_Path," +
                                           "@Building_License_Image," +
                                           "@Building_License_Image_Path," +
                                           "@Plan_Image," +
                                           "@Plan_Image_path," +
                                           "@Statment_Image," +
                                           "@Statment_Image_Path," +
                                           "@Othe_Image," +
                                           "@Othe_Image_path  )";
                _sqlCon.Open();
                using (MySqlCommand addOwnershipCmd = new MySqlCommand(addOwnershipQuery, _sqlCon))
                {
                    addOwnershipCmd.Parameters.AddWithValue("@owner_Owner_Id", Owner_DropDownList.SelectedValue);
                    addOwnershipCmd.Parameters.AddWithValue("@zone_zone_Id", Zone_Name_DropDownList.SelectedValue);
                    addOwnershipCmd.Parameters.AddWithValue("@ownership_status_ownership_status_id",
                        Ownership_Status_DropDownList.SelectedValue);
                    addOwnershipCmd.Parameters.AddWithValue("@building_type_Building_Type_Id",
                        Buildings_Type_DropDownList.SelectedValue);
                    addOwnershipCmd.Parameters.AddWithValue("@Owner_Ship_EN_Name", txt_En_Ownership_Name.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@Owner_Ship_AR_Name", txt_Ar_Ownership_Name.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@Street", txt_Street_Number.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@owner_ship_Number", txt_Ownership_Number.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@owner_ship_Certificate",
                        txt_Ownership_Certificate.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@Land_Initial_Value",
                        txt_Ownership_Lande_Initial_Value.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@Building_Number", txt_Building_Number.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@Area_Space", txt_Ownership_Area_Space.Text);
                    char[] spaceNumberWords = txt_Ownership_Space_Number.Text.ToCharArray();
                    if (spaceNumberWords.Length == 8)
                    {
                        addOwnershipCmd.Parameters.AddWithValue("@Space_Number", txt_Ownership_Space_Number.Text);
                    }
                    else
                    {
                        int numberDifference = 8 - spaceNumberWords.Length;
                        string countOfZeros = new String('0', numberDifference);
                        addOwnershipCmd.Parameters.AddWithValue("@Space_Number",
                            countOfZeros + txt_Ownership_Space_Number.Text);
                    }

                    addOwnershipCmd.Parameters.AddWithValue("@Bond_Update", txt_Bond_Update.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@Annual_Difference", txt_Annual_Difference.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@ROI", txt_ROI.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@Remaining_amount", txt_Remaining_amount.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@Building_Value", txt_Building_Value.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@Annual_Revenue", txt_Annual_Revenue.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@Mortgage_Status", txt_Mortgage_Status.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@Remaining_time", txt_Remaining_time.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@Total_Value", txt_Total_Value.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@Difference_of_the_collections",
                        txt_Difference_of_the_collections.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@Mortgage_Value", txt_Mortgage_Value.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@Release_date", txt_Release_Date.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@owner_ship_Code",
                        txt_Ownership_Number.Text + "/" + (spaceNumberWords[0]).ToString() +
                        (spaceNumberWords[1]).ToString());
                    if (Ownership_Certificate_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(Ownership_Certificate_FileUpload.PostedFile.FileName);
                        Ownership_Certificate_FileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/Ownership_Images/Ownership_Certificate/") +
                            fileName1);
                        addOwnershipCmd.Parameters.AddWithValue("@owner_ship_Certificate_Image", fileName1);
                        addOwnershipCmd.Parameters.AddWithValue("@owner_ship_Certificate_Image_Path",
                            "/English/Main_Application/Ownership_Images/Ownership_Certificate/" + fileName1);
                    }
                    else
                    {
                        addOwnershipCmd.Parameters.AddWithValue("@owner_ship_Certificate_Image", "No File");
                        addOwnershipCmd.Parameters.AddWithValue("@owner_ship_Certificate_Image_Path", "No File");
                    }

                    // *************************************************************************************************************
                    if (Complition_Certificate_FileUpload.HasFile)
                    {
                        string fileName3 = Path.GetFileName(Complition_Certificate_FileUpload.PostedFile.FileName);
                        Complition_Certificate_FileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/Ownership_Images/Complition_Certificate/") +
                            fileName3);
                        addOwnershipCmd.Parameters.AddWithValue("@Complition_Certificate_Image", fileName3);
                        addOwnershipCmd.Parameters.AddWithValue("@Complition_Certificate_Image_Path",
                            "/English/Main_Application/Ownership_Images/Complition_Certificate/" + fileName3);
                    }
                    else
                    {
                        addOwnershipCmd.Parameters.AddWithValue("@Complition_Certificate_Image", "No File");
                        addOwnershipCmd.Parameters.AddWithValue("@Complition_Certificate_Image_Path", "No File");
                    }

                    //****************************************************************************************************************
                    if (Building_LicenseFileUpload.HasFile)
                    {
                        string fileName5 = Path.GetFileName(Building_LicenseFileUpload.PostedFile.FileName);
                        Building_LicenseFileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/Ownership_Images/Building_License/") + fileName5);
                        addOwnershipCmd.Parameters.AddWithValue("@Building_License_Image", fileName5);
                        addOwnershipCmd.Parameters.AddWithValue("@Building_License_Image_Path",
                            "/English/Main_Application/Ownership_Images/Building_License/" + fileName5);
                    }
                    else
                    {
                        addOwnershipCmd.Parameters.AddWithValue("@Building_License_Image", "No File");
                        addOwnershipCmd.Parameters.AddWithValue("@Building_License_Image_Path", "No File");
                    }

                    //****************************************************************************************************************
                    if (Plan_FileUpload.HasFile)
                    {
                        string fileName7 = Path.GetFileName(Plan_FileUpload.PostedFile.FileName);
                        Plan_FileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/Ownership_Images/Plan/") + fileName7);
                        addOwnershipCmd.Parameters.AddWithValue("@Plan_Image", fileName7);
                        addOwnershipCmd.Parameters.AddWithValue("@Plan_Image_Path",
                            "/English/Main_Application/Ownership_Images/Plan/" + fileName7);
                    }
                    else
                    {
                        addOwnershipCmd.Parameters.AddWithValue("@Plan_Image", "No File");
                        addOwnershipCmd.Parameters.AddWithValue("@Plan_Image_Path", "No File");
                    }
                    //****************************************************************************************************************

                    if (Statment_FileUpload.HasFile)
                    {
                        string fileName9 = Path.GetFileName(Statment_FileUpload.PostedFile.FileName);
                        Statment_FileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/Ownership_Images/Statment/") + fileName9);
                        addOwnershipCmd.Parameters.AddWithValue("@Statment_Image", fileName9);
                        addOwnershipCmd.Parameters.AddWithValue("@Statment_Image_Path",
                            "/English/Main_Application/Ownership_Images/Statment/" + fileName9);
                    }
                    else
                    {
                        addOwnershipCmd.Parameters.AddWithValue("@Statment_Image", "No File");
                        addOwnershipCmd.Parameters.AddWithValue("@Statment_Image_Path", "No File");
                    }

                    if (Other_FileUpload.HasFile)
                    {
                        string fileName11 = Path.GetFileName(Other_FileUpload.PostedFile.FileName);
                        Other_FileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/Ownership_Images/Other/") + fileName11);
                        addOwnershipCmd.Parameters.AddWithValue("@Othe_Image", fileName11);
                        addOwnershipCmd.Parameters.AddWithValue("@Othe_Image_Path",
                            "/English/Main_Application/Ownership_Images/Other/" + fileName11);
                    }
                    else
                    {
                        addOwnershipCmd.Parameters.AddWithValue("@Othe_Image", "No File");
                        addOwnershipCmd.Parameters.AddWithValue("@Othe_Image_Path", "No File");
                    }

                    addOwnershipCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }

                lbl_Success_Add_New_Ownership.Text = "تمت إضافة الملكية بنجاح";
                Add_Building_TO_This_Ownership.Visible = true;
            }
        }

        protected void btn_Back_To_OwnerShip_List_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Ownership_List.aspx");
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                CheckBox2.Checked = false;
                txt_Ownership_Space_Number.ReadOnly = false;
                txt_Ownership_Space_Number.MaxLength = 7;
            }
            else
            {
                txt_Ownership_Space_Number.ReadOnly = true;
            }
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox2.Checked)
            {
                CheckBox1.Checked = false;
                txt_Ownership_Space_Number.ReadOnly = false;
                txt_Ownership_Space_Number.MaxLength = 8;
            }
            else
            {
                txt_Ownership_Space_Number.ReadOnly = true;
            }
        }

        protected void Add_Building_TO_This_Ownership_Click(object sender, EventArgs e)
        {
            string sapceNumber;
            string ownershiId;
            Panel1.Visible = true;
            lbl_Name_Of_Added_Ownership.Text = txt_Ar_Building_Name.Text;

            char[] spaceNumberWords = txt_Ownership_Space_Number.Text.ToCharArray();
            if (spaceNumberWords.Length == 8)
            {
                sapceNumber = txt_Ownership_Space_Number.Text;
            }
            else
            {
                int numberDifference = 8 - spaceNumberWords.Length;
                string countOfZeros = new String('0', numberDifference);
                sapceNumber = countOfZeros + txt_Ownership_Space_Number.Text;
            }

            DataTable getOwnershipDt = new DataTable();
            _sqlCon.Open();
            MySqlCommand command =
                new MySqlCommand(
                    "SELECT Owner_Ship_AR_Name , Owner_Ship_Id FROM owner_ship where Space_Number='" + sapceNumber +
                    "'", _sqlCon);
            MySqlDataAdapter getOwnershipDa = new MySqlDataAdapter(command);
            getOwnershipDa.Fill(getOwnershipDt);
            ownershiId = getOwnershipDt.Rows[0]["Owner_Ship_Id"].ToString();
            lbl_Name_Of_Added_Ownership.Text = getOwnershipDt.Rows[0]["Owner_Ship_AR_Name"].ToString();

            ownership_ID.Text = ownershiId;
            txt_B_ownership_Name.Text = getOwnershipDt.Rows[0]["Owner_Ship_AR_Name"].ToString();
            _sqlCon.Close();
        }

        protected void txt_Ownership_Space_Number_TextChanged(object sender, EventArgs e)
        {
            char[] words = txt_Ownership_Space_Number.Text.ToCharArray();
            Zone_Name_DropDownList.AutoPostBack = true;
            Zone_Name_DropDownList.SelectedValue = (words[0]).ToString() + (words[1]).ToString();
        }

        protected void Release_Date_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txt_Release_Date.Text = Release_Date_Calendar.SelectedDate.ToShortDateString();
            System.Web.UI.Control div = Page.FindControl("divCalendar");
        }

        protected void btn_Add_Building_Click1(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addBuildingQuery = "Insert Into building (" +
                                          "owner_ship_Owner_Ship_Id  ,   " +
                                          "building_condition_Building_Condition_Id  ,  " +
                                          "building_type_Building_Type_Id , " +
                                          "unit_type_Unit_Type_Id," +
                                          "Building_English_Name," +
                                          "Building_Arabic_Name ," +
                                          "Construction_Area, " +
                                          "Completion_date , " +
                                          "Current_Building_age," +
                                          "Building_Value , " +
                                          "Depreciation_Value , " +
                                          "presumed_Income," +
                                          "Maintenance_status , " +
                                          "Renovation , " +
                                          "residual_cost," +
                                          "Estimated_residual_value," +
                                          "Depreciation_Year," +
                                          "Balance_Value," +
                                          "Actual_income," +
                                          "Number_of_Conflict_Cases," +
                                          "Contractual_Rent , " +
                                          "electricity_meter , " +
                                          "Water_meter," +
                                          "Building_Number," +
                                          "Occupied_Units, " +
                                          "Vacant_units ," +
                                          "Number_of_units_under_construction," +
                                          "Map , " +
                                          "Map_path ," +
                                          "Entrance_Photo," +
                                          "Entrance_Photo_Path , " +
                                          "Building_Photo , " +
                                          "Building_Photo_Path , " +
                                          "Facilities_Photo , " +
                                          "Facilities_Photo_Path)" +
                                          " VALUES (" +
                                          "@owner_ship_Owner_Ship_Id  ,   " +
                                          "@building_condition_Building_Condition_Id  ,  " +
                                          "@building_type_Building_Type_Id , " +
                                          "@unit_type_Unit_Type_Id," +
                                          "@Building_English_Name," +
                                          "@Building_Arabic_Name ," +
                                          "@Construction_Area, " +
                                          "@Completion_date , " +
                                          "@Current_Building_age," +
                                          "@Building_Value , " +
                                          "@Depreciation_Value , " +
                                          "@presumed_Income," +
                                          "@Maintenance_status , " +
                                          "@Renovation , " +
                                          "@residual_cost," +
                                          "@Estimated_residual_value," +
                                          "@Depreciation_Year," +
                                          "@Balance_Value," +
                                          "@Actual_income," +
                                          "@Number_of_Conflict_Cases," +
                                          "@Contractual_Rent , " +
                                          "@electricity_meter , " +
                                          "@Water_meter," +
                                          "@Building_Number," +
                                          "@Occupied_Units, " +
                                          "@Vacant_units ," +
                                          "@Number_of_units_under_construction," +
                                          "@Map , " +
                                          "@Map_path ," +
                                          "@Entrance_Photo," +
                                          "@Entrance_Photo_Path , " +
                                          "@Building_Photo , " +
                                          "@Building_Photo_Path , " +
                                          "@Facilities_Photo , " +
                                          "@Facilities_Photo_Path)";
                _sqlCon.Open();
                using (MySqlCommand addBuildingCmd = new MySqlCommand(addBuildingQuery, _sqlCon))
                {
                    addBuildingCmd.Parameters.AddWithValue("@Building_English_Name", txt_En_Building_Name.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Building_Arabic_Name", txt_Ar_Building_Name.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Construction_Area", txt_Building_Area.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Completion_date", txt_Completion_Date.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Current_Building_age", txt_Current_Building_age.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Depreciation_Value", txt_Depreciation_Value.Text);
                    addBuildingCmd.Parameters.AddWithValue("@presumed_Income", txt_presumed_Income.Text);

                    addBuildingCmd.Parameters.AddWithValue("@Maintenance_status", txt_Maintenance_status.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Renovation", txt_Renovation.Text);
                    addBuildingCmd.Parameters.AddWithValue("@residual_cost", txt_residual_cost.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Estimated_residual_value",
                        txt_Estimated_residual_value.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Depreciation_Year", txt_Depreciation_Year.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Number_of_Conflict_Cases",
                        txt_Number_of_Conflict_Cases.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Actual_income", txt_Actual_income.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Contractual_Rent", txt_Contractual_Rent.Text);
                    addBuildingCmd.Parameters.AddWithValue("@electricity_meter", txt_Electricity_Meter.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Water_meter", txt_Water_Meter.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Building_Number", txt_Building_Number.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Occupied_Units", txt_Occupied_Units.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Vacant_units", txt_Vacant_units.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Building_Value", txt_Building_Value.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Balance_Value", txt_Balance_Value.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Number_of_units_under_construction",
                        txt_Number_of_units_under_construction.Text);

                    addBuildingCmd.Parameters.AddWithValue("@owner_ship_Owner_Ship_Id", ownership_ID.Text);
                    addBuildingCmd.Parameters.AddWithValue("@building_condition_Building_Condition_Id",
                        B_Building_Condition_DropDownList.SelectedValue);
                    addBuildingCmd.Parameters.AddWithValue("@building_type_Building_Type_Id",
                        B_Building_Type_DropDownList.SelectedValue);
                    addBuildingCmd.Parameters.AddWithValue("@unit_type_Unit_Type_Id",
                        B_Units_Type_DropDownList.SelectedValue);

                    string fileName = Path.GetFileName(Building_Photo_FileUpload.PostedFile.FileName);
                    Building_Photo_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/Building_Pdf/Building_Photo/") + fileName);
                    addBuildingCmd.Parameters.AddWithValue("@Building_Photo", fileName);
                    addBuildingCmd.Parameters.AddWithValue("@Building_Photo_Path",
                        "/English/Main_Application/Building_Pdf/Building_Photo/" + fileName);

                    string fileName2 = Path.GetFileName(Building_Entrace_Photo_FileUpload.PostedFile.FileName);
                    Building_Entrace_Photo_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/Building_Pdf/Entrace_Photo/") + fileName2);
                    addBuildingCmd.Parameters.AddWithValue("@Entrance_Photo", fileName2);
                    addBuildingCmd.Parameters.AddWithValue("@Entrance_Photo_Path",
                        "/English/Main_Application/Building_Pdf/Entrace_Photo/" + fileName2);

                    string fileName3 = Path.GetFileName(Building_Facilities_Photo_FileUpload.PostedFile.FileName);
                    Building_Facilities_Photo_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/Building_Pdf/Facilities_Photo/") + fileName3);
                    addBuildingCmd.Parameters.AddWithValue("@Facilities_Photo", fileName3);
                    addBuildingCmd.Parameters.AddWithValue("@Facilities_Photo_Path",
                        "/English/Main_Application/Building_Pdf/Facilities_Photo/" + fileName3);

                    string fileName4 = Path.GetFileName(Building_Map_FileUpload.PostedFile.FileName);
                    Building_Map_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/Building_Pdf/Map/") + fileName4);
                    addBuildingCmd.Parameters.AddWithValue("@Map", fileName4);
                    addBuildingCmd.Parameters.AddWithValue("@Map_Path",
                        "/English/Main_Application/Building_Pdf/Map/" + fileName4);

                    addBuildingCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
            }
        }

        protected void Completion_Date_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txt_Completion_Date.Text = Completion_Date_Calendar.SelectedDate.ToShortDateString();
            System.Web.UI.Control div = Page.FindControl("Completion_Date_divCalendar");
        }
    }
}