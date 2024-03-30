using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Add_Unit : System.Web.UI.Page
    {
        // Database Connection String
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
                Helper.LoadDropDownList("SELECT * FROM unit_condition", _sqlCon, Unit_Condition_DropDownList, "Unit_Arabic_Condition", "Unit_Condition_Id");
                Unit_Condition_DropDownList.Items.Insert(0, "إختر حالة الوحدة ....");
                Unit_Condition_DropDownList.SelectedValue = "2";

                //Get unit_Type DropDownList
                Helper.LoadDropDownList("SELECT * FROM unit_type", _sqlCon, Unit_Type_DropDownList, "Unit_Arabic_Type", "Unit_Type_Id");
                Unit_Type_DropDownList.Items.Insert(0, "إختر نوع الوحدة ....");

                //Get unit_Detail DropDownList
                Helper.LoadDropDownList("SELECT * FROM unit_detail", _sqlCon, Unit_Detail_DropDownList, "Unit_Arabic_Detail", "Unit_Detail_Id");
                Unit_Detail_DropDownList.Items.Insert(0, "إختر تفاصيل الوحدة ....");

                //Get Building_Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM building Where Active ='1' ", _sqlCon, Building_Name_DropDownList, "Building_Arabic_Name", "Building_Id");
                Building_Name_DropDownList.Items.Insert(0, "إختر إسم البناء ....");

                if(Request.QueryString["Id"] != null)
                {
                    Building_Name_DropDownList.SelectedValue = Request.QueryString["Id"];
                    Zone_Sterrt_BuildingNO();
                }

                //    //Fill Furniture_case_DropDownList
                Helper.LoadDropDownList("SELECT * FROM furniture_case where Furniture_case_Id !=1", _sqlCon, Furniture_case_DropDownList, "Furniture_Ar_case", "Furniture_case_Id");
                Furniture_case_DropDownList.Items.Insert(0, "إختر الفرش ....");
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
                                        "Half , " +
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
                                        "@Half , " +
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
                    addUnitCmd.Parameters.AddWithValue("@Half", "0");
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
                    addUnitCmd.Parameters.AddWithValue("@building_Building_Id",
                        Building_Name_DropDownList.SelectedValue);

                    //*************************************** Add The File Uploads ************************************************************************************************
                    if (Image_One_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(Image_One_FileUpload.PostedFile.FileName);
                        Image_One_FileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/units_Photo/") + fileName1);
                        addUnitCmd.Parameters.AddWithValue("@Image_One", fileName1);
                        addUnitCmd.Parameters.AddWithValue("@Image_One_Path", "/English/Main_Application/units_Photo/" + fileName1);
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

                    ;
                    lbl_Success_Add_Unit.Text = "تمت إضافة الوحدة بنجاح";
                }

                Unit_Arcive();
            }
        }

        protected void btn_Back_To_Unit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                Response.Redirect("Test_4.aspx");
            }
            else
            {
                Response.Redirect("Units_List.aspx");
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
            else { div_Furniture_case.Visible = false; }
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
                buildingDetailsCmd.Parameters.AddWithValue("@Id", Building_Name_DropDownList.SelectedValue);
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




        protected void Unit_Arcive()
        {
            string addUnitQuery = "Insert Into arcive_units (" +
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
                                        "Half , " +
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
                                        "@Half , " +
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
                addUnitCmd.Parameters.AddWithValue("@Half", "0");
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
                addUnitCmd.Parameters.AddWithValue("@building_Building_Id",
                    Building_Name_DropDownList.SelectedValue);

                //*************************************** Add The File Uploads ************************************************************************************************
                if (Image_One_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(Image_One_FileUpload.PostedFile.FileName);
                    Image_One_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/units_Photo/") + fileName1);
                    addUnitCmd.Parameters.AddWithValue("@Image_One", fileName1);
                    addUnitCmd.Parameters.AddWithValue("@Image_One_Path", "/English/Main_Application/units_Photo/" + fileName1);
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

                ;
            }
        }
    }
}