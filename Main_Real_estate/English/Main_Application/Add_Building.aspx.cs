using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics.Contracts;
using System.IO;
using System.Web.Services.Description;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Add_Building : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "properties", 0, "R");
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "properties", 1, "A");

            }
            catch { Response.Redirect("Log_In.aspx"); }
            

            if (!this.IsPostBack)
            {
                // Fill Year &Mounth  DropDownList
                int year = DateTime.Now.Year; int Mounth = DateTime.Now.Month;
                for (int i = year - 50; i <= year + 10; i++)
                {
                    ListItem li = new ListItem(i.ToString());
                    Construction_Completion_Date_DropDownList.Items.Add(li);
                }
                Construction_Completion_Date_DropDownList.Items.FindByText(year.ToString()).Selected = true;


                //    //Get Building_Condition DropDownList
                using (MySqlCommand getBuildingConditionDropDownListCmd =
                       new MySqlCommand("SELECT * FROM building_condition"))
                {
                    getBuildingConditionDropDownListCmd.CommandType = CommandType.Text;
                    getBuildingConditionDropDownListCmd.Connection = _sqlCon;
                    if (_sqlCon.State != ConnectionState.Open)
                    {
                        _sqlCon.Open(); // Wherever you are trying to open the connection,  do this.
                        //Do the same for close connection
                    }

                    Building_Condition_DropDownList.DataSource =
                        getBuildingConditionDropDownListCmd.ExecuteReader();
                    Building_Condition_DropDownList.DataTextField = "Building_Arabic_Condition";
                    Building_Condition_DropDownList.DataValueField = "Building_Condition_Id";
                    Building_Condition_DropDownList.DataBind();
                    Building_Condition_DropDownList.Items.Insert(0, "اختر حالة البناء ....");
                    if (_sqlCon.State != ConnectionState.Closed)
                    {
                        _sqlCon.Close();
                    }
                }

                //    //Get Building_Type  DropDownList
                using (MySqlCommand getBuildingTypeDropDownListCmd =
                       new MySqlCommand("SELECT * FROM building_type"))
                {
                    getBuildingTypeDropDownListCmd.CommandType = CommandType.Text;
                    getBuildingTypeDropDownListCmd.Connection = _sqlCon;
                    if (_sqlCon.State != ConnectionState.Open)
                    {
                        _sqlCon.Open(); // Wherever you are trying to open the connection,  do this.
                        //Do the same for close connection
                    }

                    Building_Type_DropDownList.DataSource = getBuildingTypeDropDownListCmd.ExecuteReader();
                    Building_Type_DropDownList.DataTextField = "Building_Arabic_Type";
                    Building_Type_DropDownList.DataValueField = "Building_Type_Id";
                    Building_Type_DropDownList.DataBind();
                    Building_Type_DropDownList.Items.Insert(0, "إختر نوع البناء ....");
                    if (_sqlCon.State != ConnectionState.Closed)
                    {
                        _sqlCon.Close();
                    }
                }

                //Get ownership_Name DropDownList
                using (MySqlCommand getOwnershipNameDropDownListCmd = new MySqlCommand("SELECT * FROM owner_ship where Active !='1'"))
                {
                    getOwnershipNameDropDownListCmd.CommandType = CommandType.Text;
                    getOwnershipNameDropDownListCmd.Connection = _sqlCon;
                    if (_sqlCon.State != ConnectionState.Open)
                    {
                        _sqlCon.Open(); // Wherever you are trying to open the connection,  do this.
                        //Do the same for close connection
                    }

                    ownership_Name_DropDownList.DataSource = getOwnershipNameDropDownListCmd.ExecuteReader();
                    ownership_Name_DropDownList.DataTextField = "Owner_Ship_AR_Name";
                    ownership_Name_DropDownList.DataValueField = "Owner_Ship_Id";
                    ownership_Name_DropDownList.DataBind();
                    ownership_Name_DropDownList.Items.Insert(0, "أختر إسم الملكية....");

                    if (_sqlCon.State != ConnectionState.Closed)
                    {
                        _sqlCon.Close();
                    }

                    if (Request.QueryString["Id"] != null)
                    {
                        ownership_Name_DropDownList.SelectedValue = Request.QueryString["Id"];


                        _sqlCon.Open();
                        using (MySqlCommand ownershipDetailsCmd = new MySqlCommand("Ownership_Details", _sqlCon))
                        {
                            ownershipDetailsCmd.CommandType = CommandType.StoredProcedure;
                            ownershipDetailsCmd.Parameters.AddWithValue("@Id", ownership_Name_DropDownList.SelectedValue);
                            using (MySqlDataAdapter ownershipDetailsSda = new MySqlDataAdapter(ownershipDetailsCmd))
                            {
                                DataTable ownershipDetailsDt = new DataTable();
                                ownershipDetailsSda.Fill(ownershipDetailsDt);


                                txt_Street_No.Text = ownershipDetailsDt.Rows[0]["Street_NO"].ToString();
                                txt_Zone_No.Text = ownershipDetailsDt.Rows[0]["zone_number"].ToString();
                            }
                        }
                        _sqlCon.Close();
                    }
                }
                //***********************************  Nuit DrowpList *********************************************************

                //Get unit_condition DropDownList
                using (MySqlCommand getUnitConditionCmd = new MySqlCommand("SELECT * FROM unit_condition"))
                {
                    getUnitConditionCmd.CommandType = CommandType.Text;
                    getUnitConditionCmd.Connection = _sqlCon;
                    if (_sqlCon.State != ConnectionState.Open)
                    {
                        _sqlCon.Open(); // Wherever you are trying to open the connection,  do this.
                        //Do the same for close connection
                    }

                    Unit_Condition_DropDownList.DataSource = getUnitConditionCmd.ExecuteReader();
                    Unit_Condition_DropDownList.DataTextField = "Unit_Arabic_Condition";
                    Unit_Condition_DropDownList.DataValueField = "Unit_Condition_Id";
                    Unit_Condition_DropDownList.DataBind();
                    Unit_Condition_DropDownList.Items.Insert(0, "إختر حالة الوحدة ....");
                    if (_sqlCon.State != ConnectionState.Closed)
                    {
                        _sqlCon.Close();
                    }
                }

                //Get unit_Type DropDownList
                using (MySqlCommand getUnitTypeCmd = new MySqlCommand("SELECT * FROM unit_type"))
                {
                    getUnitTypeCmd.CommandType = CommandType.Text;
                    getUnitTypeCmd.Connection = _sqlCon;
                    if (_sqlCon.State != ConnectionState.Open)
                    {
                        _sqlCon.Open(); // Wherever you are trying to open the connection,  do this.
                        //Do the same for close connection
                    }

                    Unit_Type_DropDownList.DataSource = getUnitTypeCmd.ExecuteReader();
                    Unit_Type_DropDownList.DataTextField = "Unit_Arabic_Type";
                    Unit_Type_DropDownList.DataValueField = "Unit_Type_Id";
                    Unit_Type_DropDownList.DataBind();
                    Unit_Type_DropDownList.Items.Insert(0, "إختر نوع الوحدة ....");
                    if (_sqlCon.State != ConnectionState.Closed)
                    {
                        _sqlCon.Close();
                    }
                }

                //Get unit_Detail DropDownList
                using (MySqlCommand getUnitDetailCmd = new MySqlCommand("SELECT * FROM unit_detail"))
                {
                    getUnitDetailCmd.CommandType = CommandType.Text;
                    getUnitDetailCmd.Connection = _sqlCon;
                    if (_sqlCon.State != ConnectionState.Open)
                    {
                        _sqlCon.Open(); // Wherever you are trying to open the connection,  do this.
                        //Do the same for close connection
                    }

                    Unit_Detail_DropDownList.DataSource = getUnitDetailCmd.ExecuteReader();
                    Unit_Detail_DropDownList.DataTextField = "Unit_Arabic_Detail";
                    Unit_Detail_DropDownList.DataValueField = "Unit_Detail_Id";
                    Unit_Detail_DropDownList.DataBind();
                    Unit_Detail_DropDownList.Items.Insert(0, "إختر تفاصيل الوحدة ....");
                    if (_sqlCon.State != ConnectionState.Closed)
                    {
                        _sqlCon.Close();
                    }
                }
            }
        }

        protected void btn_Back_To_Building_List_Click1(object sender, EventArgs e)
        {

            if (Request.QueryString["Id"] != null)
            {
                Response.Redirect("Test_4.aspx");
            }
            else
            {
                Response.Redirect("Building_List.aspx");
            }
        }

        protected void btn_Add_Building_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addBuildingQuery = "Insert Into building (" +
                                            "owner_ship_Owner_Ship_Id  ,   " +
                                            "building_condition_Building_Condition_Id  ,  " +
                                            "building_type_Building_Type_Id , " +
                                            "Building_English_Name," +
                                            "Building_Arabic_Name ," +
                                            "electricity_meter, " +
                                            "Water_meter , " +
                                            "Building_NO," +
                                            "Construction_Area , " +
                                            "Maintenance_status , " +
                                            "Building_Value , " +
                                            "Construction_Completion_Date , " +
                                            "Active , " +
                                            "Building_Photo , " +
                                            "Building_Photo_Path , " +
                                            "Statement , " +
                                            "Statement_Path , " +
                                            "Building_Permit , " +
                                            "Building_Permit_Path , " +
                                            "certificate_of_completion , " +
                                            "certificate_of_completion_Path , " +
                                            "Image , " +
                                            "Image_Path , " +
                                            "Map , " +
                                            "Map_path , " +
                                            "Plan , " +
                                            "Plano_Path , " +
                                            "Entrance_Photo , " +
                                            "Entrance_Photo_Path , IsRealEsataeInvesment )" +
                                            " VALUES (" +
                                            "@owner_ship_Owner_Ship_Id  ,   " +
                                            "@building_condition_Building_Condition_Id  ,  " +
                                            "@building_type_Building_Type_Id , " +
                                            "@Building_English_Name," +
                                            "@Building_Arabic_Name ," +
                                            "@electricity_meter, " +
                                            "@Water_meter , " +
                                            "@Building_NO," +
                                            "@Construction_Area , " +
                                            "@Maintenance_status , " +
                                            "@Building_Value , " +
                                            "@Construction_Completion_Date , " +
                                            "@Active , " +
                                            "@Building_Photo , " +
                                            "@Building_Photo_Path , " +
                                            "@Statement , " +
                                            "@Statement_Path , " +
                                            "@Building_Permit , " +
                                            "@Building_Permit_Path , " +
                                            "@certificate_of_completion , " +
                                            "@certificate_of_completion_Path , " +
                                            "@Image , " +
                                            "@Image_Path , " +
                                            "@Map , " +
                                            "@Map_path , " +
                                            "@Plan , " +
                                            "@Plano_Path , " +
                                            "@Entrance_Photo , " +
                                            "@Entrance_Photo_Path , @IsRealEsataeInvesment)";
                if (_sqlCon.State != ConnectionState.Open)
                {
                    _sqlCon.Open(); // Wherever you are trying to open the connection,  do this.
                    //Do the same for close connection
                }

                using (MySqlCommand addBuildingCmd = new MySqlCommand(addBuildingQuery, _sqlCon))
                {
                    addBuildingCmd.Parameters.AddWithValue("@Building_English_Name", txt_En_Bilding_Name.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Building_Arabic_Name", txt_Ar_Bilding_Name.Text);
                    addBuildingCmd.Parameters.AddWithValue("@electricity_meter", txt_electricity_meter.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Water_meter", txt_Water_meter.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Building_NO", txt_Building_NO.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Construction_Area", txt_Construction_Area.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Maintenance_status", txt_Maintenance_status.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Building_Value", txt_Building_Value.Text);
                    addBuildingCmd.Parameters.AddWithValue("@Construction_Completion_Date", Construction_Completion_Date_DropDownList.SelectedItem.Text);
                    addBuildingCmd.Parameters.AddWithValue("@owner_ship_Owner_Ship_Id",  ownership_Name_DropDownList.SelectedValue);
                    addBuildingCmd.Parameters.AddWithValue("@building_condition_Building_Condition_Id",Building_Condition_DropDownList.SelectedValue);
                    addBuildingCmd.Parameters.AddWithValue("@building_type_Building_Type_Id",Building_Type_DropDownList.SelectedValue);
                    addBuildingCmd.Parameters.AddWithValue("@Active", "1");
                    addBuildingCmd.Parameters.AddWithValue("@IsRealEsataeInvesment", "0");

                    //*************************************** Add The File Uploads ************************************************************************************************
                    if (Building_Photo_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(Building_Photo_FileUpload.PostedFile.FileName);
                        Building_Photo_FileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/Building_File/Building_Photo/") + fileName1);
                        addBuildingCmd.Parameters.AddWithValue("@Building_Photo", fileName1);
                        addBuildingCmd.Parameters.AddWithValue("@Building_Photo_Path", "/English/Main_Application/Building_File/Building_Photo/" + fileName1);
                    }
                    else
                    {
                        addBuildingCmd.Parameters.AddWithValue("@Building_Photo", "No File");
                        addBuildingCmd.Parameters.AddWithValue("@Building_Photo_Path", "No File");
                    }

                    //**********************************************************************************************************************************************************
                    if (Statement_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(Statement_FileUpload.PostedFile.FileName);
                        Statement_FileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/Building_File/Statement/") + fileName1);
                        addBuildingCmd.Parameters.AddWithValue("@Statement", fileName1);
                        addBuildingCmd.Parameters.AddWithValue("@Statement_Path",
                            "/English/Main_Application/Building_File/Statement/" + fileName1);
                    }
                    else
                    {
                        addBuildingCmd.Parameters.AddWithValue("@Statement", "No File");
                        addBuildingCmd.Parameters.AddWithValue("@Statement_Path", "No File");
                    }

                    //**********************************************************************************************************************************************************
                    if (Building_Permit_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(Building_Permit_FileUpload.PostedFile.FileName);
                        Building_Permit_FileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/Building_File/Building_Permit/") + fileName1);
                        addBuildingCmd.Parameters.AddWithValue("@Building_Permit", fileName1);
                        addBuildingCmd.Parameters.AddWithValue("@Building_Permit_Path",
                            "/English/Main_Application/Building_File/Building_Permit/" + fileName1);
                    }
                    else
                    {
                        addBuildingCmd.Parameters.AddWithValue("@Building_Permit", "No File");
                        addBuildingCmd.Parameters.AddWithValue("@Building_Permit_Path", "No File");
                    }

                    //**********************************************************************************************************************************************************
                    if (certificate_of_completion_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(certificate_of_completion_FileUpload.PostedFile.FileName);
                        certificate_of_completion_FileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/Building_File/certificate_completion/") +
                            fileName1);
                        addBuildingCmd.Parameters.AddWithValue("@certificate_of_completion", fileName1);
                        addBuildingCmd.Parameters.AddWithValue("@certificate_of_completion_Path",
                            "/English/Main_Application/Building_File/certificate_completion/" + fileName1);
                    }
                    else
                    {
                        addBuildingCmd.Parameters.AddWithValue("@certificate_of_completion", "No File");
                        addBuildingCmd.Parameters.AddWithValue("@certificate_of_completion_Path", "No File");
                    }

                    //**********************************************************************************************************************************************************
                    if (Image_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(Image_FileUpload.PostedFile.FileName);
                        Image_FileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/Building_File/Image/") + fileName1);
                        addBuildingCmd.Parameters.AddWithValue("@Image", fileName1);
                        addBuildingCmd.Parameters.AddWithValue("@Image_Path",
                            "/English/Main_Application/Building_File/Image/" + fileName1);
                    }
                    else
                    {
                        addBuildingCmd.Parameters.AddWithValue("@Image", "No File");
                        addBuildingCmd.Parameters.AddWithValue("@Image_Path", "No File");
                    }

                    //**********************************************************************************************************************************************************
                    if (Maps_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(Maps_FileUpload.PostedFile.FileName);
                        Maps_FileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/Building_File/Map/") + fileName1);
                        addBuildingCmd.Parameters.AddWithValue("@Map", fileName1);
                        addBuildingCmd.Parameters.AddWithValue("@Map_Path",
                            "/English/Main_Application/Building_File/Map/" + fileName1);
                    }
                    else
                    {
                        addBuildingCmd.Parameters.AddWithValue("@Map", "No File");
                        addBuildingCmd.Parameters.AddWithValue("@Map_Path", "No File");
                    }

                    //**********************************************************************************************************************************************************
                    if (Plan_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(Plan_FileUpload.PostedFile.FileName);
                        Plan_FileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/Building_File/Building_Plan/") + fileName1);
                        addBuildingCmd.Parameters.AddWithValue("@Plan", fileName1);
                        addBuildingCmd.Parameters.AddWithValue("@Plano_Path",
                            "/English/Main_Application/Building_File/Building_Plan/" + fileName1);
                    }
                    else
                    {
                        addBuildingCmd.Parameters.AddWithValue("@Plan", "No File");
                        addBuildingCmd.Parameters.AddWithValue("@Plano_Path", "No File");
                    }

                    //**********************************************************************************************************************************************************
                    if (Entrance_picture_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(Entrance_picture_FileUpload.PostedFile.FileName);
                        Entrance_picture_FileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/Building_File/Entrace_Photo/") + fileName1);
                        addBuildingCmd.Parameters.AddWithValue("@Entrance_Photo", fileName1);
                        addBuildingCmd.Parameters.AddWithValue("@Entrance_Photo_Path",
                            "/English/Main_Application/Building_File/Entrace_Photo/" + fileName1);
                    }
                    else
                    {
                        addBuildingCmd.Parameters.AddWithValue("@Entrance_Photo", "No File");
                        addBuildingCmd.Parameters.AddWithValue("@Entrance_Photo_Path", "No File");
                    }

                    addBuildingCmd.ExecuteNonQuery();
                    if (_sqlCon.State != ConnectionState.Closed)
                    {
                        _sqlCon.Close();
                    }



                    using (MySqlCommand Get_Building_ID = new MySqlCommand("SELECT MAX(Building_Id) AS LastInsertedID from building ", _sqlCon))
                    {
                        _sqlCon.Open();
                        Get_Building_ID.CommandType = CommandType.Text;
                        object Building_ID = Get_Building_ID.ExecuteScalar();
                        if (Building_ID != null)
                        {
                            Building_id.Text = Building_ID.ToString();
                        }

                        _sqlCon.Close();
                    }

                    string updateHalf_Building_IdQuary = "UPDATE building SET Half_Building_ID=@Half_Building_ID  WHERE Building_Id=@ID ";
                    _sqlCon.Open();
                    MySqlCommand updateHalf_Building_IdCmd = new MySqlCommand(updateHalf_Building_IdQuary, _sqlCon);
                    updateHalf_Building_IdCmd.Parameters.AddWithValue("@ID", Building_id.Text);
                    updateHalf_Building_IdCmd.Parameters.AddWithValue("@Half_Building_ID", Building_id.Text);
                    
                    updateHalf_Building_IdCmd.ExecuteNonQuery();
                    _sqlCon.Close();


                    lbl_Success_Add_Building.Text = "تمت الإضافة بنجاح";

                    //***********************************  Make fields Empty After Adding *******************************************************
                }

                Arcive_Building();

                string buildingId;
                DataTable getAddedBuildingDt = new DataTable();
                if (_sqlCon.State != ConnectionState.Open)
                {
                    _sqlCon.Open(); // Wherever you are trying to open the connection,  do this.
                    //Do the same for close connection
                }

                MySqlCommand getAddedBuildingCmd = new MySqlCommand(
                    "SELECT Building_Arabic_Name , Building_Id FROM building where Building_NO = '" +
                    txt_Building_NO.Text + "' And owner_ship_Owner_Ship_Id='" +
                    ownership_Name_DropDownList.SelectedValue + "'", _sqlCon);
                MySqlDataAdapter getAddedBuildingDa = new MySqlDataAdapter(getAddedBuildingCmd);
                getAddedBuildingDa.Fill(getAddedBuildingDt);
                buildingId = getAddedBuildingDt.Rows[0]["Building_Id"].ToString();
                Added_Building_Id.Text = buildingId;
                lbl_Add_New_Unit.Text = " إضافة وحدة لبناء : " +
                                        getAddedBuildingDt.Rows[0]["Building_Arabic_Name"].ToString();

                //Button3.Visible = true;
                //Button4.Visible = true;
                if (_sqlCon.State != ConnectionState.Closed)
                {
                    _sqlCon.Close();
                }


                Zone_Sterrt_BuildingNO();

                //Page.SetFocus(Button3.ClientID);
            }
        }

        protected void btn_Add_Unit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addUnitQuery = "Insert Into units (" +
                                        "unit_condition_Unit_Condition_Id  ,   " +
                                        "unit_detail_Unit_Detail_Id  ,  " +
                                        "unit_type_Unit_Type_Id , " +
                                        "building_Building_Id , " +
                                        "furniture_case_Furniture_case_Id , " +
                                        "Unit_Number," +
                                        "Floor_Number ," +
                                        "Unit_Space, " +
                                        "current_situation , " +
                                        "Oreedo_Number," +
                                        "Electricityt_Number , " +
                                        "Water_Number , " +
                                        "virtual_Value , " +
                                        "Image_One , " +
                                        "Image_One_Path , " +
                                        "Image_Two , " +
                                        "Image_Two_Path , " +
                                        "Image_Three , " +
                                        "Image_Three_Path , " +
                                        "Image_Four , " +
                                        "Image_Four_Path)" +
                                        " VALUES (" +
                                        "@unit_condition_Unit_Condition_Id  ,   " +
                                        "@unit_detail_Unit_Detail_Id  ,  " +
                                        "@unit_type_Unit_Type_Id , " +
                                        "@building_Building_Id , " +
                                        "@furniture_case_Furniture_case_Id , " +
                                        "@Unit_Number," +
                                        "@Floor_Number ," +
                                        "@Unit_Space, " +
                                        "@current_situation , " +
                                        "@Oreedo_Number," +
                                        "@Electricityt_Number , " +
                                        "@Water_Number , " +
                                        "@virtual_Value , " +
                                        "@Image_One , " +
                                        "@Image_One_Path , " +
                                        "@Image_Two , " +
                                        "@Image_Two_Path , " +
                                        "@Image_Three , " +
                                        "@Image_Three_Path , " +
                                        "@Image_Four , " +
                                        "@Image_Four_Path)";
                if (_sqlCon.State != ConnectionState.Open)
                {
                    _sqlCon.Open(); // Wherever you are trying to open the connection,  do this.
                    //Do the same for close connection
                }

                using (MySqlCommand addUnitCmd = new MySqlCommand(addUnitQuery, _sqlCon))
                {
                    addUnitCmd.Parameters.AddWithValue("@Unit_Number", txt_Unit_NO.Text);
                    addUnitCmd.Parameters.AddWithValue("@Floor_Number", txt_Floor_NO.Text);
                    addUnitCmd.Parameters.AddWithValue("@Unit_Space", txt_Unit_Space.Text);
                    addUnitCmd.Parameters.AddWithValue("@current_situation", txt_current_situation.Text);
                    addUnitCmd.Parameters.AddWithValue("@Oreedo_Number", txt_Oreedo_Number.Text);
                    addUnitCmd.Parameters.AddWithValue("@Electricityt_Number", txt_Electricityt_Number.Text);
                    addUnitCmd.Parameters.AddWithValue("@Water_Number", txt_Water_Number.Text);
                    addUnitCmd.Parameters.AddWithValue("@virtual_Value", txt_virtual_Value.Text);
                    if (
                     Unit_Type_DropDownList.SelectedValue == "1" || Unit_Type_DropDownList.SelectedValue == "4" ||
                     Unit_Type_DropDownList.SelectedValue == "5" || Unit_Type_DropDownList.SelectedValue == "6" ||
                     Unit_Type_DropDownList.SelectedValue == "8" || Unit_Type_DropDownList.SelectedValue == "10"
                     )
                    {
                        addUnitCmd.Parameters.AddWithValue("@furniture_case_Furniture_case_Id", Furniture_case_DropDownList.SelectedValue);
                    }
                    else
                    {
                        addUnitCmd.Parameters.AddWithValue("@furniture_case_Furniture_case_Id", "1");
                    }

                    addUnitCmd.Parameters.AddWithValue("@unit_condition_Unit_Condition_Id",
                        Unit_Condition_DropDownList.SelectedValue);
                    addUnitCmd.Parameters.AddWithValue("@unit_detail_Unit_Detail_Id",
                        Unit_Detail_DropDownList.SelectedValue);
                    addUnitCmd.Parameters.AddWithValue("@unit_type_Unit_Type_Id",
                        Unit_Type_DropDownList.SelectedValue);
                    addUnitCmd.Parameters.AddWithValue("@building_Building_Id", Added_Building_Id.Text);

                    //*************************************** Add The File Uploads ************************************************************************************************
                    if (Image_One_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(Image_One_FileUpload.PostedFile.FileName);
                        Image_One_FileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/units_Photo/") + fileName1);
                        addUnitCmd.Parameters.AddWithValue("@Image_One", fileName1);
                        addUnitCmd.Parameters.AddWithValue("@Image_One_Path",
                            "/English/Main_Application/units_Photo/" + fileName1);
                    }
                    else
                    {
                        addUnitCmd.Parameters.AddWithValue("@Image_One", "No File");
                        addUnitCmd.Parameters.AddWithValue("@Image_One_Path", "No File");
                    }

                    //**********************************************************************************************************************************************************
                    if (Image_Two_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(Image_Two_FileUpload.PostedFile.FileName);
                        Image_Two_FileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/units_Photo/") + fileName1);
                        addUnitCmd.Parameters.AddWithValue("@Image_Two", fileName1);
                        addUnitCmd.Parameters.AddWithValue("@Image_Two_Path",
                            "/English/Main_Application/units_Photo/" + fileName1);
                    }
                    else
                    {
                        addUnitCmd.Parameters.AddWithValue("@Image_Two", "No File");
                        addUnitCmd.Parameters.AddWithValue("@Image_Two_Path", "No File");
                    }

                    //**********************************************************************************************************************************************************
                    if (Image_Three_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(Image_Three_FileUpload.PostedFile.FileName);
                        Image_Three_FileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/units_Photo/") + fileName1);
                        addUnitCmd.Parameters.AddWithValue("@Image_Three", fileName1);
                        addUnitCmd.Parameters.AddWithValue("@Image_Three_Path",
                            "/English/Main_Application/units_Photo/" + fileName1);
                    }
                    else
                    {
                        addUnitCmd.Parameters.AddWithValue("@Image_Three", "No File");
                        addUnitCmd.Parameters.AddWithValue("@Image_Three_Path", "No File");
                    }

                    //**********************************************************************************************************************************************************
                    if (Image_Four_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(Image_Four_FileUpload.PostedFile.FileName);
                        Image_Four_FileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/units_Photo/") + fileName1);
                        addUnitCmd.Parameters.AddWithValue("@Image_Four", fileName1);
                        addUnitCmd.Parameters.AddWithValue("@Image_Four_Path",
                            "/English/Main_Application/units_Photo/" + fileName1);
                    }
                    else
                    {
                        addUnitCmd.Parameters.AddWithValue("@Image_Four", "No File");
                        addUnitCmd.Parameters.AddWithValue("@Image_Four_Path", "No File");
                    }

                    //**********************************************************************************************************************************************************
                    addUnitCmd.ExecuteNonQuery();
                    if (_sqlCon.State != ConnectionState.Closed)
                    {
                        _sqlCon.Close();
                    }

                    lbl_Success_Add_Unit.Text = "تمت إضافة الوحدة بنجاح";
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Unit_Panel.Visible = true;
            lbl_Success_Add_Building.Visible = false;
            txt_En_Bilding_Name.ReadOnly = true;
            txt_Ar_Bilding_Name.ReadOnly = true;
            txt_Building_NO.ReadOnly = true;
            txt_Construction_Area.ReadOnly = true;
            txt_Maintenance_status.ReadOnly = true;
            txt_electricity_meter.ReadOnly = true;
            txt_Water_meter.ReadOnly = true;
            Building_Condition_DropDownList.Enabled = false;
            Building_Type_DropDownList.Enabled = false;
            ownership_Name_DropDownList.Enabled = false;
            btn_Add_Building.Enabled = false;
            Page.SetFocus(Image_One_FileUpload.ClientID);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Add_Building.aspx");
        }

        protected void Unit_Type_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (
                Unit_Type_DropDownList.SelectedValue == "1" || Unit_Type_DropDownList.SelectedValue == "4" ||
                Unit_Type_DropDownList.SelectedValue == "5" || Unit_Type_DropDownList.SelectedValue == "6" ||
                Unit_Type_DropDownList.SelectedValue == "8" || Unit_Type_DropDownList.SelectedValue == "10"
            )
            {
                div_Furniture_case.Visible = true;
            }
            else
            {
                div_Furniture_case.Visible = false;
            }
        }

        protected void ownership_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _sqlCon.Open();
            using (MySqlCommand ownershipDetailsCmd = new MySqlCommand("Ownership_Details", _sqlCon))
            {
                ownershipDetailsCmd.CommandType = CommandType.StoredProcedure;
                ownershipDetailsCmd.Parameters.AddWithValue("@Id", ownership_Name_DropDownList.SelectedValue);
                using (MySqlDataAdapter ownershipDetailsSda = new MySqlDataAdapter(ownershipDetailsCmd))
                {
                    DataTable ownershipDetailsDt = new DataTable();
                    ownershipDetailsSda.Fill(ownershipDetailsDt);


                    txt_Street_No.Text = ownershipDetailsDt.Rows[0]["Street_NO"].ToString();
                    txt_Zone_No.Text = ownershipDetailsDt.Rows[0]["zone_number"].ToString();
                }
            }
            _sqlCon.Close();
        }

        protected void Building_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Zone_Sterrt_BuildingNO();
        }

        protected void Zone_Sterrt_BuildingNO()
        {
            _sqlCon.Open();
            using (MySqlCommand buildingDetailsCmd = new MySqlCommand("Building_Details", _sqlCon))
            {
                buildingDetailsCmd.CommandType = CommandType.StoredProcedure;
                buildingDetailsCmd.Parameters.AddWithValue("@Id", Added_Building_Id.Text);
                using (MySqlDataAdapter buildingDetailsSda = new MySqlDataAdapter(buildingDetailsCmd))
                {
                    DataTable bulidingDetailsDt = new DataTable();
                    buildingDetailsSda.Fill(bulidingDetailsDt);

                    txt_Building_NO.Text = bulidingDetailsDt.Rows[0]["Building_NO"].ToString();
                    txt_Street_No.Text = bulidingDetailsDt.Rows[0]["Street_NO"].ToString();
                    txt_Zone_No.Text = bulidingDetailsDt.Rows[0]["zone_number"].ToString();
                }
            }
            _sqlCon.Close();
        }



        //*****************************************************************************************************************************
        //*********************************************************** أرشفة البناء ***************************************************

        protected void Arcive_Building()
        {
            string addBuildingQuery = "Insert Into arcive_building (" +
                                            "owner_ship_Owner_Ship_Id  ,   " +
                                            "building_condition_Building_Condition_Id  ,  " +
                                            "building_type_Building_Type_Id , " +
                                            "Building_English_Name," +
                                            "Building_Arabic_Name ," +
                                            "electricity_meter, " +
                                            "Water_meter , " +
                                            "Building_NO," +
                                            "Construction_Area , " +
                                            "Maintenance_status , " +
                                            "Building_Value , " +
                                            "Construction_Completion_Date , " +
                                            "Active , " +
                                            "Building_Photo , " +
                                            "Building_Photo_Path , " +
                                            "Statement , " +
                                            "Statement_Path , " +
                                            "Building_Permit , " +
                                            "Building_Permit_Path , " +
                                            "certificate_of_completion , " +
                                            "certificate_of_completion_Path , " +
                                            "Image , " +
                                            "Image_Path , " +
                                            "Map , " +
                                            "Map_path , " +
                                            "Plan , " +
                                            "Plano_Path , " +
                                            "Entrance_Photo , " +
                                            "Entrance_Photo_Path , IsRealEsataeInvesment)" +
                                            " VALUES (" +
                                            "@owner_ship_Owner_Ship_Id  ,   " +
                                            "@building_condition_Building_Condition_Id  ,  " +
                                            "@building_type_Building_Type_Id , " +
                                            "@Building_English_Name," +
                                            "@Building_Arabic_Name ," +
                                            "@electricity_meter, " +
                                            "@Water_meter , " +
                                            "@Building_NO," +
                                            "@Construction_Area , " +
                                            "@Maintenance_status , " +
                                            "@Building_Value , " +
                                            "@Construction_Completion_Date , " +
                                            "@Active , " +
                                            "@Building_Photo , " +
                                            "@Building_Photo_Path , " +
                                            "@Statement , " +
                                            "@Statement_Path , " +
                                            "@Building_Permit , " +
                                            "@Building_Permit_Path , " +
                                            "@certificate_of_completion , " +
                                            "@certificate_of_completion_Path , " +
                                            "@Image , " +
                                            "@Image_Path , " +
                                            "@Map , " +
                                            "@Map_path , " +
                                            "@Plan , " +
                                            "@Plano_Path , " +
                                            "@Entrance_Photo , " +
                                            "@Entrance_Photo_Path , @IsRealEsataeInvesment)";
            if (_sqlCon.State != ConnectionState.Open)
            {
                _sqlCon.Open(); // Wherever you are trying to open the connection,  do this.
                                //Do the same for close connection
            }

            using (MySqlCommand addBuildingCmd = new MySqlCommand(addBuildingQuery, _sqlCon))
            {
                addBuildingCmd.Parameters.AddWithValue("@Building_English_Name", txt_En_Bilding_Name.Text);
                addBuildingCmd.Parameters.AddWithValue("@Building_Arabic_Name", txt_Ar_Bilding_Name.Text);
                addBuildingCmd.Parameters.AddWithValue("@electricity_meter", txt_electricity_meter.Text);
                addBuildingCmd.Parameters.AddWithValue("@Water_meter", txt_Water_meter.Text);
                addBuildingCmd.Parameters.AddWithValue("@Building_NO", txt_Building_NO.Text);
                addBuildingCmd.Parameters.AddWithValue("@Construction_Area", txt_Construction_Area.Text);
                addBuildingCmd.Parameters.AddWithValue("@Maintenance_status", txt_Maintenance_status.Text);
                addBuildingCmd.Parameters.AddWithValue("@Building_Value", txt_Building_Value.Text);
                addBuildingCmd.Parameters.AddWithValue("@Construction_Completion_Date", Construction_Completion_Date_DropDownList.SelectedItem.Text);
                addBuildingCmd.Parameters.AddWithValue("@owner_ship_Owner_Ship_Id", ownership_Name_DropDownList.SelectedValue);
                addBuildingCmd.Parameters.AddWithValue("@building_condition_Building_Condition_Id", Building_Condition_DropDownList.SelectedValue);
                addBuildingCmd.Parameters.AddWithValue("@building_type_Building_Type_Id", Building_Type_DropDownList.SelectedValue);
                addBuildingCmd.Parameters.AddWithValue("@Active", "1");
                addBuildingCmd.Parameters.AddWithValue("@IsRealEsataeInvesment", "0");

                //*************************************** Add The File Uploads ************************************************************************************************
                if (Building_Photo_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(Building_Photo_FileUpload.PostedFile.FileName);
                    Building_Photo_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/Building_File/Building_Photo/") + fileName1);
                    addBuildingCmd.Parameters.AddWithValue("@Building_Photo", fileName1);
                    addBuildingCmd.Parameters.AddWithValue("@Building_Photo_Path", "/English/Main_Application/Building_File/Building_Photo/" + fileName1);
                }
                else
                {
                    addBuildingCmd.Parameters.AddWithValue("@Building_Photo", "No File");
                    addBuildingCmd.Parameters.AddWithValue("@Building_Photo_Path", "No File");
                }

                //**********************************************************************************************************************************************************
                if (Statement_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(Statement_FileUpload.PostedFile.FileName);
                    Statement_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/Building_File/Statement/") + fileName1);
                    addBuildingCmd.Parameters.AddWithValue("@Statement", fileName1);
                    addBuildingCmd.Parameters.AddWithValue("@Statement_Path",
                        "/English/Main_Application/Building_File/Statement/" + fileName1);
                }
                else
                {
                    addBuildingCmd.Parameters.AddWithValue("@Statement", "No File");
                    addBuildingCmd.Parameters.AddWithValue("@Statement_Path", "No File");
                }

                //**********************************************************************************************************************************************************
                if (Building_Permit_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(Building_Permit_FileUpload.PostedFile.FileName);
                    Building_Permit_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/Building_File/Building_Permit/") + fileName1);
                    addBuildingCmd.Parameters.AddWithValue("@Building_Permit", fileName1);
                    addBuildingCmd.Parameters.AddWithValue("@Building_Permit_Path",
                        "/English/Main_Application/Building_File/Building_Permit/" + fileName1);
                }
                else
                {
                    addBuildingCmd.Parameters.AddWithValue("@Building_Permit", "No File");
                    addBuildingCmd.Parameters.AddWithValue("@Building_Permit_Path", "No File");
                }

                //**********************************************************************************************************************************************************
                if (certificate_of_completion_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(certificate_of_completion_FileUpload.PostedFile.FileName);
                    certificate_of_completion_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/Building_File/certificate_completion/") +
                        fileName1);
                    addBuildingCmd.Parameters.AddWithValue("@certificate_of_completion", fileName1);
                    addBuildingCmd.Parameters.AddWithValue("@certificate_of_completion_Path",
                        "/English/Main_Application/Building_File/certificate_completion/" + fileName1);
                }
                else
                {
                    addBuildingCmd.Parameters.AddWithValue("@certificate_of_completion", "No File");
                    addBuildingCmd.Parameters.AddWithValue("@certificate_of_completion_Path", "No File");
                }

                //**********************************************************************************************************************************************************
                if (Image_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(Image_FileUpload.PostedFile.FileName);
                    Image_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/Building_File/Image/") + fileName1);
                    addBuildingCmd.Parameters.AddWithValue("@Image", fileName1);
                    addBuildingCmd.Parameters.AddWithValue("@Image_Path",
                        "/English/Main_Application/Building_File/Image/" + fileName1);
                }
                else
                {
                    addBuildingCmd.Parameters.AddWithValue("@Image", "No File");
                    addBuildingCmd.Parameters.AddWithValue("@Image_Path", "No File");
                }

                //**********************************************************************************************************************************************************
                if (Maps_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(Maps_FileUpload.PostedFile.FileName);
                    Maps_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/Building_File/Map/") + fileName1);
                    addBuildingCmd.Parameters.AddWithValue("@Map", fileName1);
                    addBuildingCmd.Parameters.AddWithValue("@Map_Path",
                        "/English/Main_Application/Building_File/Map/" + fileName1);
                }
                else
                {
                    addBuildingCmd.Parameters.AddWithValue("@Map", "No File");
                    addBuildingCmd.Parameters.AddWithValue("@Map_Path", "No File");
                }

                //**********************************************************************************************************************************************************
                if (Plan_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(Plan_FileUpload.PostedFile.FileName);
                    Plan_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/Building_File/Building_Plan/") + fileName1);
                    addBuildingCmd.Parameters.AddWithValue("@Plan", fileName1);
                    addBuildingCmd.Parameters.AddWithValue("@Plano_Path",
                        "/English/Main_Application/Building_File/Building_Plan/" + fileName1);
                }
                else
                {
                    addBuildingCmd.Parameters.AddWithValue("@Plan", "No File");
                    addBuildingCmd.Parameters.AddWithValue("@Plano_Path", "No File");
                }

                //**********************************************************************************************************************************************************
                if (Entrance_picture_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(Entrance_picture_FileUpload.PostedFile.FileName);
                    Entrance_picture_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/Building_File/Entrace_Photo/") + fileName1);
                    addBuildingCmd.Parameters.AddWithValue("@Entrance_Photo", fileName1);
                    addBuildingCmd.Parameters.AddWithValue("@Entrance_Photo_Path",
                        "/English/Main_Application/Building_File/Entrace_Photo/" + fileName1);
                }
                else
                {
                    addBuildingCmd.Parameters.AddWithValue("@Entrance_Photo", "No File");
                    addBuildingCmd.Parameters.AddWithValue("@Entrance_Photo_Path", "No File");
                }

                addBuildingCmd.ExecuteNonQuery();
                if (_sqlCon.State != ConnectionState.Closed)
                {
                    _sqlCon.Close();
                }



                using (MySqlCommand Get_Building_ID = new MySqlCommand("SELECT MAX(Building_Id) AS LastInsertedID from building ", _sqlCon))
                {
                    _sqlCon.Open();
                    Get_Building_ID.CommandType = CommandType.Text;
                    object Building_ID = Get_Building_ID.ExecuteScalar();
                    if (Building_ID != null)
                    {
                        Building_id.Text = Building_ID.ToString();
                    }

                    _sqlCon.Close();
                }

                string updateHalf_Building_IdQuary = "UPDATE building SET Half_Building_ID=@Half_Building_ID  WHERE Building_Id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateHalf_Building_IdCmd = new MySqlCommand(updateHalf_Building_IdQuary, _sqlCon);
                updateHalf_Building_IdCmd.Parameters.AddWithValue("@ID", Building_id.Text);
                updateHalf_Building_IdCmd.Parameters.AddWithValue("@Half_Building_ID", Building_id.Text);

                updateHalf_Building_IdCmd.ExecuteNonQuery();
                _sqlCon.Close();
            }
        }
    }
}