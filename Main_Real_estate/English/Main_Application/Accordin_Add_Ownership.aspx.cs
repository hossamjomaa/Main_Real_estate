using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Accordin_Add_Ownership : System.Web.UI.Page
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
            
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "", "window.onload=function(){window.scrollTo(0,document.body.scrollHeight)};", true);

            if (!this.IsPostBack)
            {
                //*****************  Ownership DropDownList ********************
                // Fill Year &Mounth  DropDownList
                int year = DateTime.Now.Year; int Mounth = DateTime.Now.Month;
                for (int i = year - 50; i <= year + 10; i++)
                {
                    ListItem li = new ListItem(i.ToString());
                    Construction_Completion_Date_DropDownList.Items.Add(li);
                }
                Construction_Completion_Date_DropDownList.Items.FindByText(year.ToString()).Selected = true;

                //    //Get Owner DropDownList

                Helper.LoadDropDownList("SELECT * FROM owner", _sqlCon, Owner_DropDownList, "Owner_Arabic_name",
                    "Owner_Id");
                Owner_DropDownList.Items.Insert(0, "أختر إسم المالك ....");

                //    //Get Zone Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM zone", _sqlCon, Zone_Name_DropDownList, "zone_Arabic_name",
                    "zone_Id");
                Zone_Name_DropDownList.Items.Insert(0, "أختر إسم المنطقة ....");

                //***************************** Buliding DrowpList **********************************************

                //    //Get Building_Condition DropDownList

                Helper.LoadDropDownList("SELECT * FROM building_condition", _sqlCon, Building_Condition_DropDownList,
                    "Building_Arabic_Condition",
                    "Building_Condition_Id");
                Building_Condition_DropDownList.Items.Insert(0, "أختر حالة البناء ....");

                //    //Get Building_Type  DropDownList
                Helper.LoadDropDownList("SELECT * FROM building_type", _sqlCon, Building_Type_DropDownList,
                    "Building_Arabic_Type",
                    "Building_Type_Id");
                Building_Type_DropDownList.Items.Insert(0, "أختر نوع البناء ....");

                //***********************************  Nuit DrowpList *********************************************************

                //Get unit_condition DropDownList

                Helper.LoadDropDownList("SELECT * FROM unit_condition", _sqlCon, Unit_Condition_DropDownList,
                    "Unit_Arabic_Condition",
                    "Unit_Condition_Id");
                Unit_Condition_DropDownList.Items.Insert(0, "أختر حالة الوحدة ....");
                Unit_Condition_DropDownList.SelectedValue = "2";

                //Get unit_Type DropDownList
                Helper.LoadDropDownList("SELECT * FROM unit_type", _sqlCon, Unit_Type_DropDownList, "Unit_Arabic_Type",
                    "Unit_Type_Id");
                Unit_Type_DropDownList.Items.Insert(0, "أختر نوع الوحدة ....");

                //Get unit_Detail DropDownList
                Helper.LoadDropDownList("SELECT * FROM unit_detail", _sqlCon, Unit_Detail_DropDownList,
                    "Unit_Arabic_Detail",
                    "Unit_Detail_Id");
                Unit_Detail_DropDownList.Items.Insert(0, "أختر تفاصيل الوحدة ....");

                _sqlCon.Close();



            }
        }

        protected void txt_PIN_Number_TextChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(txt_PIN_Number.Text);

            try
            {
                char[] pinNumber = txt_PIN_Number.Text.ToCharArray();
                if (pinNumber.Length == 7)
                {
                    string zoneNo = (pinNumber[0]).ToString();
                    _sqlCon.EnhancedOpen();
                    MySqlDataAdapter Check_Zone_NO_DA =
                        new MySqlDataAdapter("Select * from zone where zone_number='" + zoneNo + "'", _sqlCon);
                    DataTable Check_Zone_NO_dt = new DataTable();
                    Check_Zone_NO_DA.Fill(Check_Zone_NO_dt);
                    if (Check_Zone_NO_dt.Rows.Count > 0)
                    {
                        Helper.LoadDropDownList("SELECT * FROM zone where zone_number = '" + zoneNo + "'", _sqlCon,
                            Zone_Name_DropDownList, "zone_Arabic_name", "zone_Id");
                        Pin_No_Worrnig.Visible = false;
                    }
                    else
                    {
                        Helper.LoadDropDownList("SELECT * FROM zone", _sqlCon, Zone_Name_DropDownList,
                            "zone_Arabic_name", "zone_Id");
                        Zone_Name_DropDownList.Items.Insert(0, "أختر إسم المنطقة ....");
                        Pin_No_Worrnig.Visible = true;
                        Pin_No_Worrnig.Text = "لم يتم إدراج منطقة لهذا الرقم المساحي ... أختر يدوياً إذا أردت";
                    }

                    _sqlCon.EnhancedClose();
                }
                else if (pinNumber.Length == 8)
                {
                    string zoneNo = (pinNumber[0]).ToString() + (pinNumber[1]).ToString();
                    _sqlCon.EnhancedOpen();
                    MySqlDataAdapter Check_Zone_NO_DA =
                        new MySqlDataAdapter("Select * from zone where zone_number='" + zoneNo + "'", _sqlCon);
                    DataTable Check_Zone_NO_dt = new DataTable();
                    Check_Zone_NO_DA.Fill(Check_Zone_NO_dt);
                    if (Check_Zone_NO_dt.Rows.Count > 0)
                    {
                        Helper.LoadDropDownList("SELECT * FROM zone where zone_number = '" + zoneNo + "'", _sqlCon,
                            Zone_Name_DropDownList, "zone_Arabic_name", "zone_Id");
                        Pin_No_Worrnig.Visible = false;
                    }
                    else
                    {
                        Helper.LoadDropDownList("SELECT * FROM zone", _sqlCon, Zone_Name_DropDownList,
                            "zone_Arabic_name", "zone_Id");
                        Zone_Name_DropDownList.Items.Insert(0, "أختر إسم المنطقة ....");

                        Pin_No_Worrnig.Visible = true;
                        Pin_No_Worrnig.Text = "لم يتم إدراج منطقة لهذا الرقم المساحي ... أختر يدوياً إذا أردت";
                    }

                    _sqlCon.EnhancedClose();
                }
                else
                {
                    Helper.LoadDropDownList("SELECT * FROM zone", _sqlCon, Zone_Name_DropDownList, "zone_Arabic_name",
                        "zone_Id");
                    Zone_Name_DropDownList.Items.Insert(0, "أختر إسم المنطقة ....");

                    Pin_No_Worrnig.Visible = true;
                    Pin_No_Worrnig.Text = "تأكد من صحة الرقم المساحي";
                }
            }
            catch
            {
                Response.Write(@"<script language='javascript'>alert('الرجاء التأكد من صحة الرقم المساحي')</script>");
            }
        }

        protected void Zone_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pin_No_Worrnig.Visible = false;
        }

        protected void Btn_Add_Ownership_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addOwnershipQuery = "Insert Into owner_ship  (" +
                                           "owner_Owner_Id  ,   " +
                                           "zone_zone_Id  ,  " +
                                           "Owner_Ship_EN_Name," +
                                           "Owner_Ship_AR_Name ," +
                                           "ownership_NO, " +
                                           "Parcel_Area , " +
                                           "Bond_NO," +
                                           "Bond_Date," +
                                           "Street_NO , " +
                                           "Street_Name , " +
                                           "Land_Value , " +
                                           "Appreciation_octagon , " +
                                           "PIN_Number," +
                                           "owner_ship_Code , " +
                                           "Active , " +
                                           "Mab_Url , " +
                                           "owner_ship_Certificate_Image , " +
                                           "owner_ship_Certificate_Image_Path , " +
                                           "Property_Scheme_Image , " +
                                           "Property_Scheme_Image_Path , IsRealEsataeInvesment)" +
                                           " VALUES (" +
                                           "@owner_Owner_Id  ,   " +
                                           "@zone_zone_Id  ,  " +
                                           "@Owner_Ship_EN_Name," +
                                           "@Owner_Ship_AR_Name ," +
                                           "@ownership_NO, " +
                                           "@Parcel_Area , " +
                                           "@Bond_NO," +
                                           "@Bond_Date," +
                                           "@Street_NO , " +
                                           "@Street_Name , " +
                                           "@Land_Value , " +
                                           "@Appreciation_octagon , " +
                                           "@PIN_Number," +
                                           "@owner_ship_Code , " +
                                           "@Active , " +
                                           "@Mab_Url , " +
                                           "@owner_ship_Certificate_Image , " +
                                           "@owner_ship_Certificate_Image_Path , " +
                                           "@Property_Scheme_Image , " +
                                           "@Property_Scheme_Image_Path , @IsRealEsataeInvesment)";

                _sqlCon.EnhancedOpen();
                //if (_sqlCon.State != ConnectionState.Open)
                //{
                //    _sqlCon.Open();
                //}

                using (MySqlCommand addOwnershipCmd = new MySqlCommand(addOwnershipQuery, _sqlCon))
                {
                    addOwnershipCmd.Parameters.AddWithValue("@owner_Owner_Id", Owner_DropDownList.SelectedValue);
                    addOwnershipCmd.Parameters.AddWithValue("@zone_zone_Id", Zone_Name_DropDownList.SelectedValue);
                    // Add_Ownership_CMD.Parameters.AddWithValue("@ownership_status_ownership_status_id", Ownership_Status_DropDownList.SelectedValue);

                    addOwnershipCmd.Parameters.AddWithValue("@Owner_Ship_EN_Name", txt_En_Ownership_Name.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@Owner_Ship_AR_Name", txt_Ar_Ownership_Name.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@ownership_NO", txt_Ownership_Number.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@Parcel_Area", txt_Parcel_Area.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@Bond_NO", txt_Bond_No.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@Bond_Date", txt_bond_Date.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@Street_NO", txt_Street_No.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@Street_Name", txt_Street_Name.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@Land_Value", txt_Lande_Value.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@IsRealEsataeInvesment", "0");

                    if (txt_Map_Url.Text == "")
                    {
                        addOwnershipCmd.Parameters.AddWithValue("@Mab_Url", "No File");
                    }
                    else
                    {
                        addOwnershipCmd.Parameters.AddWithValue("@Mab_Url", txt_Map_Url.Text);
                    }
                    addOwnershipCmd.Parameters.AddWithValue("@Active", "0");


                    //************************** Appreciation_octagon ****************************************************************

                    if (CheckBox_Appreciation.Checked)
                    {
                        addOwnershipCmd.Parameters.AddWithValue("@Appreciation_octagon", "تقديري");
                    }
                    else if (CheckBox_octagon.Checked)
                    {
                        addOwnershipCmd.Parameters.AddWithValue("@Appreciation_octagon", "مثمن");
                    }
                    else
                    {
                        addOwnershipCmd.Parameters.AddWithValue("@Appreciation_octagon", " ");
                    }

                    //addOwnershipCmd.Parameters.AddWithValue("@Land_Value", txt_Lande_Value.Text);
                    // Add_Ownership_CMD.Parameters.AddWithValue("@PIN_Number", txt_PIN_Number.Text);

                    char[] spaceNumberWords = txt_PIN_Number.Text.ToCharArray();
                    if (spaceNumberWords.Length == 8)
                    {
                        addOwnershipCmd.Parameters.AddWithValue("@PIN_Number", txt_PIN_Number.Text);
                        
                        addOwnershipCmd.Parameters.AddWithValue("@owner_ship_Code",
                            spaceNumberWords[0].ToString() + spaceNumberWords[1].ToString() + "/" +
                            txt_Ownership_Number.Text);
                    }
                    else
                    {
                        int numberDifference = 8 - spaceNumberWords.Length;
                        string countOfZeros = new string('0', numberDifference);
                        addOwnershipCmd.Parameters.AddWithValue("@PIN_Number", countOfZeros + txt_PIN_Number.Text);
                        addOwnershipCmd.Parameters.AddWithValue("@owner_ship_Code",
                            spaceNumberWords[0].ToString() + "/" + txt_Ownership_Number.Text);
                    }
                    //***************************************************************************************************

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
                    if (Property_Scheme_FileUpload.HasFile)
                    {
                        string fileName3 = Path.GetFileName(Property_Scheme_FileUpload.PostedFile.FileName);
                        Property_Scheme_FileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/Ownership_Images/Property_Scheme/") + fileName3);
                        addOwnershipCmd.Parameters.AddWithValue("@Property_Scheme_Image", fileName3);
                        addOwnershipCmd.Parameters.AddWithValue("@Property_Scheme_Image_Path",
                            "/English/Main_Application/Ownership_Images/Property_Scheme/" + fileName3);
                    }
                    else
                    {
                        addOwnershipCmd.Parameters.AddWithValue("@Property_Scheme_Image", "No File");
                        addOwnershipCmd.Parameters.AddWithValue("@Property_Scheme_Image_Path", "No File");
                    }

                    addOwnershipCmd.ExecuteNonQuery();

                    _sqlCon.EnhancedClose();




                    
                }


                Arcive_Ownership();



                lbl_Success_Add_New_Ownership.Visible = true;
                //Button1.Visible = true;
                //Button2.Visible = true;
                // ******************  Fetch Added Ownership ID ************************************************
                string pinNo;
                string ownershiId;
                char[] pinNoArray = txt_PIN_Number.Text.ToCharArray();
                if (pinNoArray.Length == 8)
                {
                    pinNo = txt_PIN_Number.Text;
                }
                else
                {
                    int numberDifference = 8 - pinNoArray.Length;
                    string countOfZeros = new string('0', numberDifference);
                    pinNo = countOfZeros + txt_PIN_Number.Text;
                }

                DataTable getOwnershipDt = new DataTable();

                _sqlCon.EnhancedOpen();

                MySqlCommand command =
                    new MySqlCommand(
                        "SELECT Owner_Ship_AR_Name , Owner_Ship_Id FROM owner_ship where PIN_Number='" + pinNo + "'",
                        _sqlCon);
                MySqlDataAdapter getOwnershipDa = new MySqlDataAdapter(command);
                getOwnershipDa.Fill(getOwnershipDt);
                ownershiId = getOwnershipDt.Rows[0]["Owner_Ship_Id"].ToString();
                Added_Ownership_Id.Text = ownershiId;
                lbl_Add_New_Building.Text =
                    " إضافة بناء للملكية : " + getOwnershipDt.Rows[0]["Owner_Ship_AR_Name"].ToString();
                Page.SetFocus(Button1.ClientID);
                _sqlCon.Close();

                Zone_Street();
            }
        }

        //***************************************************      Add Building    *************************************************************************************************
        protected void Btn_Add_Building_Click(object sender, EventArgs e)
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
                                          "Entrance_Photo_Path)" +
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
                                          "@Entrance_Photo_Path)";

                _sqlCon.EnhancedOpen();

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
                    addBuildingCmd.Parameters.AddWithValue("@owner_ship_Owner_Ship_Id", Added_Ownership_Id.Text);
                    addBuildingCmd.Parameters.AddWithValue("@building_condition_Building_Condition_Id", Building_Condition_DropDownList.SelectedValue);
                    addBuildingCmd.Parameters.AddWithValue("@building_type_Building_Type_Id",Building_Type_DropDownList.SelectedValue);

                    //*************************************** Add The File Uploads ************************************************************************************************
                    if (Building_Photo_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(Building_Photo_FileUpload.PostedFile.FileName);
                        Building_Photo_FileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/Building_File/Building_Photo/") + fileName1);
                        addBuildingCmd.Parameters.AddWithValue("@Building_Photo", fileName1);
                        addBuildingCmd.Parameters.AddWithValue("@Building_Photo_Path",
                            "/English/Main_Application/Building_File/Building_Photo/" + fileName1);
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

                    _sqlCon.EnhancedClose();

                    lbl_Success_Add_Building.Text = "تمت إضافة البناء بنجاح";
                }

                string buildingId;
                DataTable getAddedBuildingDt = new DataTable();

                _sqlCon.EnhancedOpen();

                MySqlCommand getAddedBuildingCmd =
                    new MySqlCommand(
                        "SELECT Building_Arabic_Name , Building_Id FROM building where Building_NO = '" +
                        txt_Building_NO.Text + "' And owner_ship_Owner_Ship_Id='" + Added_Ownership_Id.Text + "'",
                        _sqlCon);
                MySqlDataAdapter getAddedBuildingDa = new MySqlDataAdapter(getAddedBuildingCmd);
                getAddedBuildingDa.Fill(getAddedBuildingDt);
                buildingId = getAddedBuildingDt.Rows[0]["Building_Id"].ToString();
                Added_Building_Id.Text = buildingId;
                lbl_Add_New_Unit.Text = " إضافة وحدة لبناء : " +
                                        getAddedBuildingDt.Rows[0]["Building_Arabic_Name"].ToString();

                Button3.Visible = true;
                Button4.Visible = true;

                _sqlCon.EnhancedClose();

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

                _sqlCon.EnhancedOpen();

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
                    addUnitCmd.Parameters.AddWithValue("@unit_type_Unit_Type_Id", Unit_Type_DropDownList.SelectedValue);
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
                    //if (_sqlCon.State != ConnectionState.Closed)
                    //{
                    //    _sqlCon.Close();
                    //}
                    _sqlCon.EnhancedClose();

                    lbl_Success_Add_Unit.Text = "تمت إضافة الوحدة بنجاح";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Page.SetFocus(Building_Photo_FileUpload.ClientID);
            Buidling_Panel.Visible = true;
            lbl_Success_Add_New_Ownership.Visible = false;
            txt_En_Ownership_Name.ReadOnly = true;
            txt_Ar_Ownership_Name.ReadOnly = true;
            txt_Ownership_Number.ReadOnly = true;
            txt_Bond_No.ReadOnly = true;
            txt_Lande_Value.ReadOnly = true;
            txt_Parcel_Area.ReadOnly = true;
            txt_PIN_Number.ReadOnly = true;
            txt_Street_No.ReadOnly = true;
            Owner_DropDownList.Enabled = false;
            Zone_Name_DropDownList.Enabled = false;
            btn_Add_Ownership.Enabled = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Accordin_Add_Ownership.aspx");
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
            btn_Add_Building.Enabled = false;
            Page.SetFocus(Image_One_FileUpload.ClientID);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Unit_Panel.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;
            lbl_Success_Add_Building.Visible = false;
            txt_En_Bilding_Name.ReadOnly = false;
            txt_Ar_Bilding_Name.ReadOnly = false;
            txt_Building_NO.ReadOnly = false;
            txt_Construction_Area.ReadOnly = false;
            txt_Maintenance_status.ReadOnly = false;
            txt_electricity_meter.ReadOnly = false;
            txt_Water_meter.ReadOnly = false;
            Building_Condition_DropDownList.Enabled = true;
            Building_Type_DropDownList.Enabled = true;
            btn_Add_Building.Enabled = true;

            txt_En_Bilding_Name.Text = "";
            txt_Ar_Bilding_Name.Text = "";
            txt_Building_NO.Text = "";
            txt_Construction_Area.Text = "";
            txt_Maintenance_status.Text = "";
            txt_electricity_meter.Text = "";
            txt_Water_meter.Text = "";

            //    //Get Building_Condition DropDownList

            Helper.LoadDropDownList("SELECT * FROM building_condition", _sqlCon, Building_Condition_DropDownList,
                "Building_Arabic_Condition",
                "Building_Condition_Id");

            //    //Get Building_Type  DropDownList

            Helper.LoadDropDownList("SELECT * FROM building_type", _sqlCon, Building_Type_DropDownList,
                "Building_Arabic_Type",
                "Building_Type_Id");
        }

        protected void btn_Back_To_OwnerShip_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ownership_List.aspx");
        }

        protected void btn_Back_To_Building_Click(object sender, EventArgs e)
        {
            Response.Redirect("Building_List.aspx");
        }

        protected void btn_Back_To_Unit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Units_List.aspx");
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_Appreciation.Checked)
            {
                CheckBox_octagon.Checked = false;
            }
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_octagon.Checked)
            {
                CheckBox_Appreciation.Checked = false;
            }
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
            Zone_Street();
        }


        protected void Zone_Street()
        {
            _sqlCon.Open();
            using (MySqlCommand ownershipDetailsCmd = new MySqlCommand("Ownership_Details", _sqlCon))
            {
                ownershipDetailsCmd.CommandType = CommandType.StoredProcedure;
                ownershipDetailsCmd.Parameters.AddWithValue("@Id", Added_Ownership_Id.Text);
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














       //******************************************************************************************************************************************************
       //************************************************************* أرشفة الملكيات ****************************************************************************

        protected void Arcive_Ownership()
        {
            string addOwnershipQuery = "Insert Into arcive_ownership  (" +
                                           "owner_Owner_Id  ,   " +
                                           "zone_zone_Id  ,  " +
                                           "Owner_Ship_EN_Name," +
                                           "Owner_Ship_AR_Name ," +
                                           "ownership_NO, " +
                                           "Parcel_Area , " +
                                           "Bond_NO," +
                                           "Bond_Date," +
                                           "Street_NO , " +
                                           "Street_Name , " +
                                           "Land_Value , " +
                                           "Appreciation_octagon , " +
                                           "PIN_Number," +
                                           "owner_ship_Code , " +
                                           "Active , " +
                                           "Mab_Url , " +
                                           "owner_ship_Certificate_Image , " +
                                           "owner_ship_Certificate_Image_Path , " +
                                           "Property_Scheme_Image , " +
                                           "Property_Scheme_Image_Path , IsRealEsataeInvesment )" +
                                           " VALUES (" +
                                           "@owner_Owner_Id  ,   " +
                                           "@zone_zone_Id  ,  " +
                                           "@Owner_Ship_EN_Name," +
                                           "@Owner_Ship_AR_Name ," +
                                           "@ownership_NO, " +
                                           "@Parcel_Area , " +
                                           "@Bond_NO," +
                                           "@Bond_Date," +
                                           "@Street_NO , " +
                                           "@Street_Name , " +
                                           "@Land_Value , " +
                                           "@Appreciation_octagon , " +
                                           "@PIN_Number," +
                                           "@owner_ship_Code , " +
                                           "@Active , " +
                                           "@Mab_Url , " +
                                           "@owner_ship_Certificate_Image , " +
                                           "@owner_ship_Certificate_Image_Path , " +
                                           "@Property_Scheme_Image , " +
                                           "@Property_Scheme_Image_Path , @IsRealEsataeInvesment)";

            _sqlCon.EnhancedOpen();
            //if (_sqlCon.State != ConnectionState.Open)
            //{
            //    _sqlCon.Open();
            //}

            using (MySqlCommand addOwnershipCmd = new MySqlCommand(addOwnershipQuery, _sqlCon))
            {
                addOwnershipCmd.Parameters.AddWithValue("@owner_Owner_Id", Owner_DropDownList.SelectedValue);
                addOwnershipCmd.Parameters.AddWithValue("@zone_zone_Id", Zone_Name_DropDownList.SelectedValue);
                // Add_Ownership_CMD.Parameters.AddWithValue("@ownership_status_ownership_status_id", Ownership_Status_DropDownList.SelectedValue);

                addOwnershipCmd.Parameters.AddWithValue("@Owner_Ship_EN_Name", txt_En_Ownership_Name.Text);
                addOwnershipCmd.Parameters.AddWithValue("@Owner_Ship_AR_Name", txt_Ar_Ownership_Name.Text);
                addOwnershipCmd.Parameters.AddWithValue("@ownership_NO", txt_Ownership_Number.Text);
                addOwnershipCmd.Parameters.AddWithValue("@Parcel_Area", txt_Parcel_Area.Text);
                addOwnershipCmd.Parameters.AddWithValue("@Bond_NO", txt_Bond_No.Text);
                addOwnershipCmd.Parameters.AddWithValue("@Bond_Date", txt_bond_Date.Text);
                addOwnershipCmd.Parameters.AddWithValue("@Street_NO", txt_Street_No.Text);
                addOwnershipCmd.Parameters.AddWithValue("@Street_Name", txt_Street_Name.Text);
                addOwnershipCmd.Parameters.AddWithValue("@Land_Value", txt_Lande_Value.Text);
                addOwnershipCmd.Parameters.AddWithValue("@IsRealEsataeInvesment", "0");

                if (txt_Map_Url.Text == "")
                {
                    addOwnershipCmd.Parameters.AddWithValue("@Mab_Url", "No File");
                }
                else
                {
                    addOwnershipCmd.Parameters.AddWithValue("@Mab_Url", txt_Map_Url.Text);
                }
                addOwnershipCmd.Parameters.AddWithValue("@Active", "0");


                //************************** Appreciation_octagon ****************************************************************

                if (CheckBox_Appreciation.Checked)
                {
                    addOwnershipCmd.Parameters.AddWithValue("@Appreciation_octagon", "تقديري");
                }
                else if (CheckBox_octagon.Checked)
                {
                    addOwnershipCmd.Parameters.AddWithValue("@Appreciation_octagon", "مثمن");
                }
                else
                {
                    addOwnershipCmd.Parameters.AddWithValue("@Appreciation_octagon", " ");
                }

                //addOwnershipCmd.Parameters.AddWithValue("@Land_Value", txt_Lande_Value.Text);
                // Add_Ownership_CMD.Parameters.AddWithValue("@PIN_Number", txt_PIN_Number.Text);

                char[] spaceNumberWords = txt_PIN_Number.Text.ToCharArray();
                if (spaceNumberWords.Length == 8)
                {
                    addOwnershipCmd.Parameters.AddWithValue("@PIN_Number", txt_PIN_Number.Text);

                    addOwnershipCmd.Parameters.AddWithValue("@owner_ship_Code",
                        spaceNumberWords[0].ToString() + spaceNumberWords[1].ToString() + "/" +
                        txt_Ownership_Number.Text);
                }
                else
                {
                    int numberDifference = 8 - spaceNumberWords.Length;
                    string countOfZeros = new string('0', numberDifference);
                    addOwnershipCmd.Parameters.AddWithValue("@PIN_Number", countOfZeros + txt_PIN_Number.Text);
                    addOwnershipCmd.Parameters.AddWithValue("@owner_ship_Code",
                        spaceNumberWords[0].ToString() + "/" + txt_Ownership_Number.Text);
                }
                //***************************************************************************************************

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
                if (Property_Scheme_FileUpload.HasFile)
                {
                    string fileName3 = Path.GetFileName(Property_Scheme_FileUpload.PostedFile.FileName);
                    Property_Scheme_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/Ownership_Images/Property_Scheme/") + fileName3);
                    addOwnershipCmd.Parameters.AddWithValue("@Property_Scheme_Image", fileName3);
                    addOwnershipCmd.Parameters.AddWithValue("@Property_Scheme_Image_Path",
                        "/English/Main_Application/Ownership_Images/Property_Scheme/" + fileName3);
                }
                else
                {
                    addOwnershipCmd.Parameters.AddWithValue("@Property_Scheme_Image", "No File");
                    addOwnershipCmd.Parameters.AddWithValue("@Property_Scheme_Image_Path", "No File");
                }

                addOwnershipCmd.ExecuteNonQuery();

                _sqlCon.EnhancedClose();
            }
        }


        //protected void Arcive_Building()
        //{
        //    string addBuildingQuery = "Insert Into building (" +
        //                                 "owner_ship_Owner_Ship_Id  ,   " +
        //                                 "building_condition_Building_Condition_Id  ,  " +
        //                                 "building_type_Building_Type_Id , " +
        //                                 "Building_English_Name," +
        //                                 "Building_Arabic_Name ," +
        //                                 "electricity_meter, " +
        //                                 "Water_meter , " +
        //                                 "Building_NO," +
        //                                 "Construction_Area , " +
        //                                 "Maintenance_status , " +
        //                                 "Building_Value , " +
        //                                 "Construction_Completion_Date , " +
        //                                 "Building_Photo , " +
        //                                 "Building_Photo_Path , " +
        //                                 "Statement , " +
        //                                 "Statement_Path , " +
        //                                 "Building_Permit , " +
        //                                 "Building_Permit_Path , " +
        //                                 "certificate_of_completion , " +
        //                                 "certificate_of_completion_Path , " +
        //                                 "Image , " +
        //                                 "Image_Path , " +
        //                                 "Map , " +
        //                                 "Map_path , " +
        //                                 "Plan , " +
        //                                 "Plano_Path , " +
        //                                 "Entrance_Photo , " +
        //                                 "Entrance_Photo_Path)" +
        //                                 " VALUES (" +
        //                                 "@owner_ship_Owner_Ship_Id  ,   " +
        //                                 "@building_condition_Building_Condition_Id  ,  " +
        //                                 "@building_type_Building_Type_Id , " +
        //                                 "@Building_English_Name," +
        //                                 "@Building_Arabic_Name ," +
        //                                 "@electricity_meter, " +
        //                                 "@Water_meter , " +
        //                                 "@Building_NO," +
        //                                 "@Construction_Area , " +
        //                                 "@Maintenance_status , " +
        //                                 "@Building_Value , " +
        //                                 "@Construction_Completion_Date , " +
        //                                 "@Building_Photo , " +
        //                                 "@Building_Photo_Path , " +
        //                                 "@Statement , " +
        //                                 "@Statement_Path , " +
        //                                 "@Building_Permit , " +
        //                                 "@Building_Permit_Path , " +
        //                                 "@certificate_of_completion , " +
        //                                 "@certificate_of_completion_Path , " +
        //                                 "@Image , " +
        //                                 "@Image_Path , " +
        //                                 "@Map , " +
        //                                 "@Map_path , " +
        //                                 "@Plan , " +
        //                                 "@Plano_Path , " +
        //                                 "@Entrance_Photo , " +
        //                                 "@Entrance_Photo_Path)";

        //    _sqlCon.EnhancedOpen();

        //    using (MySqlCommand addBuildingCmd = new MySqlCommand(addBuildingQuery, _sqlCon))
        //    {
        //        addBuildingCmd.Parameters.AddWithValue("@Building_English_Name", txt_En_Bilding_Name.Text);
        //        addBuildingCmd.Parameters.AddWithValue("@Building_Arabic_Name", txt_Ar_Bilding_Name.Text);
        //        addBuildingCmd.Parameters.AddWithValue("@electricity_meter", txt_electricity_meter.Text);
        //        addBuildingCmd.Parameters.AddWithValue("@Water_meter", txt_Water_meter.Text);
        //        addBuildingCmd.Parameters.AddWithValue("@Building_NO", txt_Building_NO.Text);
        //        addBuildingCmd.Parameters.AddWithValue("@Construction_Area", txt_Construction_Area.Text);
        //        addBuildingCmd.Parameters.AddWithValue("@Maintenance_status", txt_Maintenance_status.Text);
        //        addBuildingCmd.Parameters.AddWithValue("@Building_Value", txt_Building_Value.Text);
        //        addBuildingCmd.Parameters.AddWithValue("@Construction_Completion_Date", Construction_Completion_Date_DropDownList.SelectedItem.Text);
        //        addBuildingCmd.Parameters.AddWithValue("@owner_ship_Owner_Ship_Id", Added_Ownership_Id.Text);
        //        addBuildingCmd.Parameters.AddWithValue("@building_condition_Building_Condition_Id", Building_Condition_DropDownList.SelectedValue);
        //        addBuildingCmd.Parameters.AddWithValue("@building_type_Building_Type_Id", Building_Type_DropDownList.SelectedValue);

        //        //*************************************** Add The File Uploads ************************************************************************************************
        //        if (Building_Photo_FileUpload.HasFile)
        //        {
        //            string fileName1 = Path.GetFileName(Building_Photo_FileUpload.PostedFile.FileName);
        //            Building_Photo_FileUpload.PostedFile.SaveAs(
        //                Server.MapPath("/English/Main_Application/Building_File/Building_Photo/") + fileName1);
        //            addBuildingCmd.Parameters.AddWithValue("@Building_Photo", fileName1);
        //            addBuildingCmd.Parameters.AddWithValue("@Building_Photo_Path",
        //                "/English/Main_Application/Building_File/Building_Photo/" + fileName1);
        //        }
        //        else
        //        {
        //            addBuildingCmd.Parameters.AddWithValue("@Building_Photo", "No File");
        //            addBuildingCmd.Parameters.AddWithValue("@Building_Photo_Path", "No File");
        //        }

        //        //**********************************************************************************************************************************************************
        //        if (Statement_FileUpload.HasFile)
        //        {
        //            string fileName1 = Path.GetFileName(Statement_FileUpload.PostedFile.FileName);
        //            Statement_FileUpload.PostedFile.SaveAs(
        //                Server.MapPath("/English/Main_Application/Building_File/Statement/") + fileName1);
        //            addBuildingCmd.Parameters.AddWithValue("@Statement", fileName1);
        //            addBuildingCmd.Parameters.AddWithValue("@Statement_Path",
        //                "/English/Main_Application/Building_File/Statement/" + fileName1);
        //        }
        //        else
        //        {
        //            addBuildingCmd.Parameters.AddWithValue("@Statement", "No File");
        //            addBuildingCmd.Parameters.AddWithValue("@Statement_Path", "No File");
        //        }

        //        //**********************************************************************************************************************************************************
        //        if (Building_Permit_FileUpload.HasFile)
        //        {
        //            string fileName1 = Path.GetFileName(Building_Permit_FileUpload.PostedFile.FileName);
        //            Building_Permit_FileUpload.PostedFile.SaveAs(
        //                Server.MapPath("/English/Main_Application/Building_File/Building_Permit/") + fileName1);
        //            addBuildingCmd.Parameters.AddWithValue("@Building_Permit", fileName1);
        //            addBuildingCmd.Parameters.AddWithValue("@Building_Permit_Path",
        //                "/English/Main_Application/Building_File/Building_Permit/" + fileName1);
        //        }
        //        else
        //        {
        //            addBuildingCmd.Parameters.AddWithValue("@Building_Permit", "No File");
        //            addBuildingCmd.Parameters.AddWithValue("@Building_Permit_Path", "No File");
        //        }

        //        //**********************************************************************************************************************************************************
        //        if (certificate_of_completion_FileUpload.HasFile)
        //        {
        //            string fileName1 = Path.GetFileName(certificate_of_completion_FileUpload.PostedFile.FileName);
        //            certificate_of_completion_FileUpload.PostedFile.SaveAs(
        //                Server.MapPath("/English/Main_Application/Building_File/certificate_completion/") +
        //                fileName1);
        //            addBuildingCmd.Parameters.AddWithValue("@certificate_of_completion", fileName1);
        //            addBuildingCmd.Parameters.AddWithValue("@certificate_of_completion_Path",
        //                "/English/Main_Application/Building_File/certificate_completion/" + fileName1);
        //        }
        //        else
        //        {
        //            addBuildingCmd.Parameters.AddWithValue("@certificate_of_completion", "No File");
        //            addBuildingCmd.Parameters.AddWithValue("@certificate_of_completion_Path", "No File");
        //        }

        //        //**********************************************************************************************************************************************************
        //        if (Image_FileUpload.HasFile)
        //        {
        //            string fileName1 = Path.GetFileName(Image_FileUpload.PostedFile.FileName);
        //            Image_FileUpload.PostedFile.SaveAs(
        //                Server.MapPath("/English/Main_Application/Building_File/Image/") + fileName1);
        //            addBuildingCmd.Parameters.AddWithValue("@Image", fileName1);
        //            addBuildingCmd.Parameters.AddWithValue("@Image_Path",
        //                "/English/Main_Application/Building_File/Image/" + fileName1);
        //        }
        //        else
        //        {
        //            addBuildingCmd.Parameters.AddWithValue("@Image", "No File");
        //            addBuildingCmd.Parameters.AddWithValue("@Image_Path", "No File");
        //        }

        //        //**********************************************************************************************************************************************************
        //        if (Maps_FileUpload.HasFile)
        //        {
        //            string fileName1 = Path.GetFileName(Maps_FileUpload.PostedFile.FileName);
        //            Maps_FileUpload.PostedFile.SaveAs(
        //                Server.MapPath("/English/Main_Application/Building_File/Map/") + fileName1);
        //            addBuildingCmd.Parameters.AddWithValue("@Map", fileName1);
        //            addBuildingCmd.Parameters.AddWithValue("@Map_Path",
        //                "/English/Main_Application/Building_File/Map/" + fileName1);
        //        }
        //        else
        //        {
        //            addBuildingCmd.Parameters.AddWithValue("@Map", "No File");
        //            addBuildingCmd.Parameters.AddWithValue("@Map_Path", "No File");
        //        }

        //        //**********************************************************************************************************************************************************
        //        if (Plan_FileUpload.HasFile)
        //        {
        //            string fileName1 = Path.GetFileName(Plan_FileUpload.PostedFile.FileName);
        //            Plan_FileUpload.PostedFile.SaveAs(
        //                Server.MapPath("/English/Main_Application/Building_File/Building_Plan/") + fileName1);
        //            addBuildingCmd.Parameters.AddWithValue("@Plan", fileName1);
        //            addBuildingCmd.Parameters.AddWithValue("@Plano_Path",
        //                "/English/Main_Application/Building_File/Building_Plan/" + fileName1);
        //        }
        //        else
        //        {
        //            addBuildingCmd.Parameters.AddWithValue("@Plan", "No File");
        //            addBuildingCmd.Parameters.AddWithValue("@Plano_Path", "No File");
        //        }

        //        //**********************************************************************************************************************************************************
        //        if (Entrance_picture_FileUpload.HasFile)
        //        {
        //            string fileName1 = Path.GetFileName(Entrance_picture_FileUpload.PostedFile.FileName);

        //            Entrance_picture_FileUpload.PostedFile.SaveAs(
        //                Server.MapPath("/English/Main_Application/Building_File/Entrace_Photo/") + fileName1);
        //            addBuildingCmd.Parameters.AddWithValue("@Entrance_Photo", fileName1);
        //            addBuildingCmd.Parameters.AddWithValue("@Entrance_Photo_Path",
        //                "/English/Main_Application/Building_File/Entrace_Photo/" + fileName1);
        //        }
        //        else
        //        {
        //            addBuildingCmd.Parameters.AddWithValue("@Entrance_Photo", "No File");
        //            addBuildingCmd.Parameters.AddWithValue("@Entrance_Photo_Path", "No File");
        //        }

        //        addBuildingCmd.ExecuteNonQuery();

        //        _sqlCon.EnhancedClose();

                
        //    }
        //}
    }
}