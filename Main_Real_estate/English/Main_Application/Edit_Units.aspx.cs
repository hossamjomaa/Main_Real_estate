using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Units_List : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "properties", 0, "R");
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "properties", 2, "E");
                Utilities.Roles.Delete_permission_With_Reason(_sqlCon, Session["Role"].ToString(), "properties", Delete_Unit, Delete_Reason);
                Utilities.Roles.Delete_permission(_sqlCon, Session["Role"].ToString(), "properties", Remove_Link_Image_One);
                Utilities.Roles.Delete_permission(_sqlCon, Session["Role"].ToString(), "properties", Remove_Link_Image_Two);
                Utilities.Roles.Delete_permission(_sqlCon, Session["Role"].ToString(), "properties", Remove_Link_Image_Three);
                Utilities.Roles.Delete_permission(_sqlCon, Session["Role"].ToString(), "properties", Remove_Link_Image_Four);
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!this.IsPostBack)
            {
                


                Helper.LoadDropDownList("SELECT * FROM unit_condition", _sqlCon, Unit_Condition_DropDownList,
                    "Unit_Arabic_Condition", "Unit_Condition_Id");
                Unit_Condition_DropDownList.Items.Insert(0, "إختر حالة الوحدة ....");
                Unit_Condition_DropDownList.SelectedValue = "2";

                //Get unit_Type DropDownList
                Helper.LoadDropDownList("SELECT * FROM unit_type", _sqlCon, Unit_Type_DropDownList, "Unit_Arabic_Type",
                    "Unit_Type_Id");
                Unit_Type_DropDownList.Items.Insert(0, "إختر نوع الوحدة ....");

                //Get unit_Detail DropDownList
                Helper.LoadDropDownList("SELECT * FROM unit_detail", _sqlCon, Unit_Detail_DropDownList,
                    "Unit_Arabic_Detail", "Unit_Detail_Id");
                Unit_Detail_DropDownList.Items.Insert(0, "إختر تفاصيل الوحدة ....");

                //Get Building_Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM building Where Active ='1'", _sqlCon, Building_Name_DropDownList,
                    "Building_Arabic_Name", "Building_Id");
                Building_Name_DropDownList.Items.Insert(0, "إختر إسم البناء ....");

                //    //Fill Furniture_case_DropDownList
                Helper.LoadDropDownList("SELECT * FROM furniture_case where Furniture_case_Id !=1", _sqlCon,
                    Furniture_case_DropDownList, "Furniture_Ar_case", "Furniture_case_Id");
                Furniture_case_DropDownList.Items.Insert(0, "إختر الفرش ....");

                string unitId = Request.QueryString["Id"];
                DataTable getUnitDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getUnitCmd = new MySqlCommand("SELECT * FROM units WHERE Unit_ID = @ID", _sqlCon);
                MySqlDataAdapter getUnitDa = new MySqlDataAdapter(getUnitCmd);
                getUnitCmd.Parameters.AddWithValue("@ID", unitId);
                getUnitDa.Fill(getUnitDt);
                if (getUnitDt.Rows.Count > 0)
                {
                    txt_Unit_NO.Text = getUnitDt.Rows[0]["Unit_Number"].ToString();
                    txt_Floor_NO.Text = getUnitDt.Rows[0]["Floor_Number"].ToString();
                    txt_Unit_Space.Text = getUnitDt.Rows[0]["Unit_Space"].ToString();
                    txt_current_situation.Text = getUnitDt.Rows[0]["current_situation"].ToString();
                    txt_Oreedo_Number.Text = getUnitDt.Rows[0]["Oreedo_Number"].ToString();
                    txt_Electricityt_Number.Text = getUnitDt.Rows[0]["Electricityt_Number"].ToString();
                    txt_Water_Number.Text = getUnitDt.Rows[0]["Water_Number"].ToString();
                    txt_virtual_Value.Text = getUnitDt.Rows[0]["virtual_Value"].ToString();
                    Furniture_case_DropDownList.SelectedValue = getUnitDt.Rows[0]["furniture_case_Furniture_case_Id"].ToString();
                    lbl_Name_Of_Unit.Text = getUnitDt.Rows[0]["Unit_Number"].ToString();

                    Image_One.Text = getUnitDt.Rows[0]["Image_One"].ToString();
                    Image_One_Pathe.Text = getUnitDt.Rows[0]["Image_One_Path"].ToString();

                    Image_Two.Text = getUnitDt.Rows[0]["Image_Two"].ToString();
                    Image_Two_Pathe.Text = getUnitDt.Rows[0]["Image_Two_Path"].ToString();

                    Image_Three.Text = getUnitDt.Rows[0]["Image_Three"].ToString();
                    Image_Three_Pathe.Text = getUnitDt.Rows[0]["Image_Three_Path"].ToString();

                    Image_Four.Text = getUnitDt.Rows[0]["Image_Four"].ToString();
                    Image_Four_Pathe.Text = getUnitDt.Rows[0]["Image_Four_Path"].ToString();

                    Unit_Condition_DropDownList.SelectedValue =
                        getUnitDt.Rows[0]["unit_condition_Unit_Condition_Id"].ToString();
                    Unit_Detail_DropDownList.SelectedValue =
                        getUnitDt.Rows[0]["unit_detail_Unit_Detail_Id"].ToString();
                    Unit_Type_DropDownList.SelectedValue = getUnitDt.Rows[0]["unit_type_Unit_Type_Id"].ToString();
                    Building_Name_DropDownList.SelectedValue = getUnitDt.Rows[0]["building_Building_Id"].ToString();

                    if (
                        getUnitDt.Rows[0]["unit_type_Unit_Type_Id"].ToString() == "1" ||
                        getUnitDt.Rows[0]["unit_type_Unit_Type_Id"].ToString() == "4" ||
                        getUnitDt.Rows[0]["unit_type_Unit_Type_Id"].ToString() == "5" ||
                        getUnitDt.Rows[0]["unit_type_Unit_Type_Id"].ToString() == "6" ||
                        getUnitDt.Rows[0]["unit_type_Unit_Type_Id"].ToString() == "8" ||
                        getUnitDt.Rows[0]["unit_type_Unit_Type_Id"].ToString() == "10"
                    )
                    {
                        div_Furniture_case.Visible = true;
                    }
                    else
                    {
                        div_Furniture_case.Visible = false;
                    }
                }



                if (getUnitDt.Rows[0]["Image_One"].ToString() != "No File") { Image_One_Div.Visible = true; }
                else { Image_One_Div.Visible = false; }

                if (getUnitDt.Rows[0]["Image_Two"].ToString() != "No File") { Image_Two_Div.Visible = true; }
                else { Image_Two_Div.Visible = false; }

                if (getUnitDt.Rows[0]["Image_Three"].ToString() != "No File") { Image_Three_Div.Visible = true; }
                else { Image_Three_Div.Visible = false; }

                if (getUnitDt.Rows[0]["Image_Four"].ToString() != "No File") { Image_Four_Div.Visible = true; }
                else { Image_Four_Div.Visible = false; }



                lbl_Link_Image_One.Text = getUnitDt.Rows[0]["Image_One"].ToString();
                Link_Image_One.HRef = getUnitDt.Rows[0]["Image_One_Path"].ToString();
                Link_Image_One.Target = "_blank";


                lbl_Link_Image_Two.Text = getUnitDt.Rows[0]["Image_Two"].ToString();
                Link_Image_Two.HRef = getUnitDt.Rows[0]["Image_Two_Path"].ToString();
                Link_Image_Two.Target = "_blank";

                lbl_Link_Image_Three.Text = getUnitDt.Rows[0]["Image_Three"].ToString();
                Link_Image_Three.HRef = getUnitDt.Rows[0]["Image_Three_Path"].ToString();
                Link_Image_Three.Target = "_blank";


                lbl_Link_Image_Four.Text = getUnitDt.Rows[0]["Image_Four"].ToString();
                Link_Image_Four.HRef = getUnitDt.Rows[0]["Image_Four_path"].ToString();
                Link_Image_Four.Target = "_blank";



                _sqlCon.Close();

                //Zone_Sterrt_BuildingNO();


                if (Session["U_Back"].ToString() == "1")
                {
                    btn_Back_To_Unit.Text = "العودة لقائمة الوحدات";
                }
                else if (Session["U_Back"].ToString() == "2")
                {
                    btn_Back_To_Unit.Text = "العودة لعمليات الملكيات";
                }
                else if (Session["U_Back"].ToString() == "3")
                {
                    btn_Back_To_Unit.Text = "العودة لكشف النواقص";
                }
                else
                {
                    btn_Back_To_Unit.Text = "العودة لقائمة الوحدات";
                }

            }
        }

        protected void btn_Back_To_Unit_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Units_List.aspx");
        }

        protected void btn_Add_Unit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string unitId = Request.QueryString["ID"];
                string updateUnitQuery = "UPDATE units SET " +
                                         "Unit_Number=@Unit_Number , " +
                                         "Floor_Number=@Floor_Number , " +
                                         "Unit_Space=@Unit_Space ," +
                                         "current_situation=@current_situation , " +
                                         "Oreedo_Number=@Oreedo_Number , " +
                                         "Electricityt_Number=@Electricityt_Number , " +
                                         "Water_Number=@Water_Number , " +
                                         "virtual_Value=@virtual_Value , " +
                                         "furniture_case_Furniture_case_Id =@furniture_case_Furniture_case_Id ," +
                                         "unit_condition_Unit_Condition_Id=@unit_condition_Unit_Condition_Id , " +
                                         "unit_detail_Unit_Detail_Id=@unit_detail_Unit_Detail_Id , " +
                                         "unit_type_Unit_Type_Id=@unit_type_Unit_Type_Id, " +
                                         "building_Building_Id=@building_Building_Id ,  " +
                                         "Image_One=@Image_One , " +
                                         "Image_One_Path=@Image_One_Path ,  " +
                                         "Image_Two=@Image_Two , " +
                                         "Image_Two_Path=@Image_Two_Path , " +
                                         "Image_Three=@Image_Three , " +
                                         "Image_Three_Path=@Image_Three_Path , " +
                                         "Image_Four=@Image_Four , " +
                                         "Image_Four_Path=@Image_Four_Path  " +
                                         "WHERE Unit_ID=@ID ";
                _sqlCon.Open();
                using (MySqlCommand updateUnitCmd = new MySqlCommand(updateUnitQuery, _sqlCon))
                {
                    updateUnitCmd.Parameters.AddWithValue("@ID", unitId);
                    //Fill The Database with All DropDownLists Items
                    updateUnitCmd.Parameters.AddWithValue("@Unit_Number", txt_Unit_NO.Text);
                    updateUnitCmd.Parameters.AddWithValue("@Floor_Number", txt_Floor_NO.Text);
                    updateUnitCmd.Parameters.AddWithValue("@Unit_Space", txt_Unit_Space.Text);
                    updateUnitCmd.Parameters.AddWithValue("@current_situation", txt_current_situation.Text);
                    updateUnitCmd.Parameters.AddWithValue("@Oreedo_Number", txt_Oreedo_Number.Text);
                    updateUnitCmd.Parameters.AddWithValue("@Electricityt_Number", txt_Electricityt_Number.Text);
                    updateUnitCmd.Parameters.AddWithValue("@Water_Number", txt_Water_Number.Text);
                    updateUnitCmd.Parameters.AddWithValue("@virtual_Value", txt_virtual_Value.Text);

                    if (
                        Unit_Type_DropDownList.SelectedValue == "1" || Unit_Type_DropDownList.SelectedValue == "4" ||
                        Unit_Type_DropDownList.SelectedValue == "5" || Unit_Type_DropDownList.SelectedValue == "6" ||
                        Unit_Type_DropDownList.SelectedValue == "8" || Unit_Type_DropDownList.SelectedValue == "10"
                    )
                    {
                        updateUnitCmd.Parameters.AddWithValue("@furniture_case_Furniture_case_Id",
                            Furniture_case_DropDownList.SelectedValue);
                    }
                    else
                    {
                        updateUnitCmd.Parameters.AddWithValue("@furniture_case_Furniture_case_Id", "1");
                    }

                    updateUnitCmd.Parameters.AddWithValue("@unit_condition_Unit_Condition_Id",
                        Unit_Condition_DropDownList.SelectedValue);
                    updateUnitCmd.Parameters.AddWithValue("@unit_detail_Unit_Detail_Id",
                        Unit_Detail_DropDownList.SelectedValue);
                    updateUnitCmd.Parameters.AddWithValue("@unit_type_Unit_Type_Id",
                        Unit_Type_DropDownList.SelectedValue);
                    updateUnitCmd.Parameters.AddWithValue("@building_Building_Id",
                        Building_Name_DropDownList.SelectedValue);

                    //*************************************** Add The File Uploads ************************************************************************************************
                    if (Image_One_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(Image_One_FileUpload.PostedFile.FileName);
                        Image_One_FileUpload.PostedFile.SaveAs(Server.MapPath("/English/Main_Application/units_Photo/") + fileName1);
                        updateUnitCmd.Parameters.AddWithValue("@Image_One", fileName1);
                        updateUnitCmd.Parameters.AddWithValue("@Image_One_Path",
                            "/English/Main_Application/units_Photo/" + fileName1);
                    }
                    else
                    {
                        updateUnitCmd.Parameters.AddWithValue("@Image_One", Image_One.Text);
                        updateUnitCmd.Parameters.AddWithValue("@Image_One_Path", Image_One_Pathe.Text);
                    }

                    //**********************************************************************************************************************************************************
                    if (Image_Two_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(Image_Two_FileUpload.PostedFile.FileName);
                        Image_Two_FileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/units_Photo/") + fileName1);
                        updateUnitCmd.Parameters.AddWithValue("@Image_Two", fileName1);
                        updateUnitCmd.Parameters.AddWithValue("@Image_Two_Path",
                            "/English/Main_Application/units_Photo/" + fileName1);
                    }
                    else
                    {
                        updateUnitCmd.Parameters.AddWithValue("@Image_Two", Image_Two.Text);
                        updateUnitCmd.Parameters.AddWithValue("@Image_Two_Path", Image_Two_Pathe.Text);
                    }

                    //**********************************************************************************************************************************************************
                    if (Image_Three_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(Image_Three_FileUpload.PostedFile.FileName);
                        Image_Three_FileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/units_Photo/") + fileName1);
                        updateUnitCmd.Parameters.AddWithValue("@Image_Three", fileName1);
                        updateUnitCmd.Parameters.AddWithValue("@Image_Three_Path",
                            "/English/Main_Application/units_Photo/" + fileName1);
                    }
                    else
                    {
                        updateUnitCmd.Parameters.AddWithValue("@Image_Three", Image_Three.Text);
                        updateUnitCmd.Parameters.AddWithValue("@Image_Three_Path", Image_Three_Pathe.Text);
                    }

                    //**********************************************************************************************************************************************************
                    if (Image_Four_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(Image_Four_FileUpload.PostedFile.FileName);
                        Image_Four_FileUpload.PostedFile.SaveAs(
                            Server.MapPath("/English/Main_Application/units_Photo/") + fileName1);
                        updateUnitCmd.Parameters.AddWithValue("@Image_Four", fileName1);
                        updateUnitCmd.Parameters.AddWithValue("@Image_Four_Path",
                            "/English/Main_Application/units_Photo/" + fileName1);
                    }
                    else
                    {
                        updateUnitCmd.Parameters.AddWithValue("@Image_Four", Image_Four.Text);
                        updateUnitCmd.Parameters.AddWithValue("@Image_Four_Path", Image_Four_Pathe.Text);
                    }

                    //**********************************************************************************************************************************************************
                    updateUnitCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }


                Edit_Arcive_Unit();

                lbl_Success_Edit_New_Unit.Text = "تم التعديل بنجاح";
            }
        }

        protected void btn_Back_To_Unit_Click(object sender, EventArgs e)
        
        {
            if (Session["U_Back"].ToString() == "1")
            {
                Response.Redirect("Units_List.aspx");
            }
            else if (Session["U_Back"].ToString() == "2")
            {
                Response.Redirect("Test_4.aspx?Id=2");
            }
            else if (Session["U_Back"].ToString() == "3")
            {
                Response.Redirect("Missing_Fields.aspx");
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
            else
            {
                div_Furniture_case.Visible = false;
            }
        }

        protected void Btn_Remove_Link_Image_One_Click(object sender, EventArgs e)
        {
            string Uint_Id = Request.QueryString["ID"];

            string Remove_Unit_Att_Query = "UPDATE units SET " +
                                            " Image_One=@Image_One ," +
                                            " Image_One_Path=@Image_One_Path  " +
                                            "WHERE Unit_ID=@ID";
            _sqlCon.Open();
            MySqlCommand Remove_Unit_Att_Cmd = new MySqlCommand(Remove_Unit_Att_Query, _sqlCon);
            Remove_Unit_Att_Cmd.Parameters.AddWithValue("@ID", Uint_Id);
            Remove_Unit_Att_Cmd.Parameters.AddWithValue("@Image_One", "No File");
            Remove_Unit_Att_Cmd.Parameters.AddWithValue("@Image_One_Path", "No File");
            Remove_Unit_Att_Cmd.ExecuteNonQuery();
            _sqlCon.Close();

            Response.Redirect("Edit_Units.aspx?Id=" + Uint_Id);
        }

        protected void Btn_Remove_Link_Image_Two_Click(object sender, EventArgs e)
        {
            string Uint_Id = Request.QueryString["ID"];

            string Remove_Unit_Att_Query = "UPDATE units SET " +
                                            " Image_Two=@Image_Two ," +
                                            " Image_Two_Path=@Image_Two_Path  " +
                                            "WHERE Unit_ID=@ID";
            _sqlCon.Open();
            MySqlCommand Remove_Unit_Att_Cmd = new MySqlCommand(Remove_Unit_Att_Query, _sqlCon);
            Remove_Unit_Att_Cmd.Parameters.AddWithValue("@ID", Uint_Id);
            Remove_Unit_Att_Cmd.Parameters.AddWithValue("@Image_Two", "No File");
            Remove_Unit_Att_Cmd.Parameters.AddWithValue("@Image_Two_Path", "No File");
            Remove_Unit_Att_Cmd.ExecuteNonQuery();
            _sqlCon.Close();

            Response.Redirect("Edit_Units.aspx?Id=" + Uint_Id);
        }

        protected void Btn_Remove_Link_Image_Three_Click(object sender, EventArgs e)
        {
            string Uint_Id = Request.QueryString["ID"];

            string Remove_Unit_Att_Query = "UPDATE units SET " +
                                            " Image_Three=@Image_Three ," +
                                            " Image_Three_Path=@Image_Three_Path  " +
                                            "WHERE Unit_ID=@ID";
            _sqlCon.Open();
            MySqlCommand Remove_Unit_Att_Cmd = new MySqlCommand(Remove_Unit_Att_Query, _sqlCon);
            Remove_Unit_Att_Cmd.Parameters.AddWithValue("@ID", Uint_Id);
            Remove_Unit_Att_Cmd.Parameters.AddWithValue("@Image_Three", "No File");
            Remove_Unit_Att_Cmd.Parameters.AddWithValue("@Image_Three_Path", "No File");
            Remove_Unit_Att_Cmd.ExecuteNonQuery();
            _sqlCon.Close();

            Response.Redirect("Edit_Units.aspx?Id=" + Uint_Id);
        }

        protected void Btn_Remove_Link_Image_Four_Click(object sender, EventArgs e)
        {
            string Uint_Id = Request.QueryString["ID"];

            string Remove_Unit_Att_Query = "UPDATE units SET " +
                                            " Image_Four=@Image_Four ," +
                                            " Image_Four_Path=@Image_Four_Path  " +
                                            "WHERE Unit_ID=@ID";
            _sqlCon.Open();
            MySqlCommand Remove_Unit_Att_Cmd = new MySqlCommand(Remove_Unit_Att_Query, _sqlCon);
            Remove_Unit_Att_Cmd.Parameters.AddWithValue("@ID", Uint_Id);
            Remove_Unit_Att_Cmd.Parameters.AddWithValue("@Image_Four", "No File");
            Remove_Unit_Att_Cmd.Parameters.AddWithValue("@Image_Four_Path", "No File");
            Remove_Unit_Att_Cmd.ExecuteNonQuery();
            _sqlCon.Close();

            Response.Redirect("Edit_Units.aspx?Id=" + Uint_Id);
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

        protected void Delete_Unit_Click(object sender, EventArgs e)
        {
            string UnitId = Request.QueryString["ID"];

            try
            {
                _sqlCon.Open();
                string deleteUnitQuary = "DELETE FROM units WHERE Unit_ID=@ID ";
                MySqlCommand mySqlCmd = new MySqlCommand(deleteUnitQuary, _sqlCon);
                mySqlCmd.Parameters.AddWithValue("@ID", UnitId);
                mySqlCmd.ExecuteNonQuery();



                string addArciveUnitQuary = "Insert Into delete_archive " +
                                                            "(User_Id," +
                                                            "Delete_Date," +
                                                            "OS_B_U," +
                                                            "Item_Id," +
                                                            "Reason_Delete) " +
                                                            "VALUES" +
                                                            "(@User_Id," +
                                                            "@Delete_Date," +
                                                            "@OS_B_U," +
                                                            "@Item_Id," +
                                                            "@Reason_Delete)";
                MySqlCommand addArciveUnitCmd = new MySqlCommand(addArciveUnitQuary, _sqlCon);
                addArciveUnitCmd.Parameters.AddWithValue("@User_Id", Session["user_ID"].ToString());
                addArciveUnitCmd.Parameters.AddWithValue("@Delete_Date", DateTime.Now.ToString("dd/MM/yyyy"));
                addArciveUnitCmd.Parameters.AddWithValue("@OS_B_U", "U");
                addArciveUnitCmd.Parameters.AddWithValue("@Item_Id", UnitId);
                addArciveUnitCmd.Parameters.AddWithValue("@Reason_Delete", txt_Reason_Delete.Text);
                addArciveUnitCmd.ExecuteNonQuery();


                Response.Redirect("Units_List.aspx");
            }
            catch
            {
                Response.Write(@"<script language='javascript'>alert('لا يمكن حذف هذه الوحدة لأنها تحتوي على عقود ')</script>");
            };
            _sqlCon.Close();
        }



        protected void Edit_Arcive_Unit()
        {
            string unitId = Request.QueryString["ID"];
            string updateUnitQuery = "UPDATE arcive_units SET " +
                                     "Unit_Number=@Unit_Number , " +
                                     "Floor_Number=@Floor_Number , " +
                                     "Unit_Space=@Unit_Space ," +
                                     "current_situation=@current_situation , " +
                                     "Oreedo_Number=@Oreedo_Number , " +
                                     "Electricityt_Number=@Electricityt_Number , " +
                                     "Water_Number=@Water_Number , " +
                                     "virtual_Value=@virtual_Value , " +
                                     "furniture_case_Furniture_case_Id =@furniture_case_Furniture_case_Id ," +
                                     "unit_condition_Unit_Condition_Id=@unit_condition_Unit_Condition_Id , " +
                                     "unit_detail_Unit_Detail_Id=@unit_detail_Unit_Detail_Id , " +
                                     "unit_type_Unit_Type_Id=@unit_type_Unit_Type_Id, " +
                                     "building_Building_Id=@building_Building_Id ,  " +
                                     "Image_One=@Image_One , " +
                                     "Image_One_Path=@Image_One_Path ,  " +
                                     "Image_Two=@Image_Two , " +
                                     "Image_Two_Path=@Image_Two_Path , " +
                                     "Image_Three=@Image_Three , " +
                                     "Image_Three_Path=@Image_Three_Path , " +
                                     "Image_Four=@Image_Four , " +
                                     "Image_Four_Path=@Image_Four_Path  " +
                                     "WHERE Unit_ID=@ID ";
            _sqlCon.Open();
            using (MySqlCommand updateUnitCmd = new MySqlCommand(updateUnitQuery, _sqlCon))
            {
                updateUnitCmd.Parameters.AddWithValue("@ID", unitId);
                //Fill The Database with All DropDownLists Items
                updateUnitCmd.Parameters.AddWithValue("@Unit_Number", txt_Unit_NO.Text);
                updateUnitCmd.Parameters.AddWithValue("@Floor_Number", txt_Floor_NO.Text);
                updateUnitCmd.Parameters.AddWithValue("@Unit_Space", txt_Unit_Space.Text);
                updateUnitCmd.Parameters.AddWithValue("@current_situation", txt_current_situation.Text);
                updateUnitCmd.Parameters.AddWithValue("@Oreedo_Number", txt_Oreedo_Number.Text);
                updateUnitCmd.Parameters.AddWithValue("@Electricityt_Number", txt_Electricityt_Number.Text);
                updateUnitCmd.Parameters.AddWithValue("@Water_Number", txt_Water_Number.Text);
                updateUnitCmd.Parameters.AddWithValue("@virtual_Value", txt_virtual_Value.Text);

                if (
                    Unit_Type_DropDownList.SelectedValue == "1" || Unit_Type_DropDownList.SelectedValue == "4" ||
                    Unit_Type_DropDownList.SelectedValue == "5" || Unit_Type_DropDownList.SelectedValue == "6" ||
                    Unit_Type_DropDownList.SelectedValue == "8" || Unit_Type_DropDownList.SelectedValue == "10"
                )
                {
                    updateUnitCmd.Parameters.AddWithValue("@furniture_case_Furniture_case_Id",
                        Furniture_case_DropDownList.SelectedValue);
                }
                else
                {
                    updateUnitCmd.Parameters.AddWithValue("@furniture_case_Furniture_case_Id", "1");
                }

                updateUnitCmd.Parameters.AddWithValue("@unit_condition_Unit_Condition_Id",
                    Unit_Condition_DropDownList.SelectedValue);
                updateUnitCmd.Parameters.AddWithValue("@unit_detail_Unit_Detail_Id",
                    Unit_Detail_DropDownList.SelectedValue);
                updateUnitCmd.Parameters.AddWithValue("@unit_type_Unit_Type_Id",
                    Unit_Type_DropDownList.SelectedValue);
                updateUnitCmd.Parameters.AddWithValue("@building_Building_Id",
                    Building_Name_DropDownList.SelectedValue);

                //*************************************** Add The File Uploads ************************************************************************************************
                if (Image_One_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(Image_One_FileUpload.PostedFile.FileName);
                    Image_One_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/units_Photo/") + fileName1);
                    updateUnitCmd.Parameters.AddWithValue("@Image_One", fileName1);
                    updateUnitCmd.Parameters.AddWithValue("@Image_One_Path",
                        "/English/Main_Application/units_Photo/" + fileName1);
                }
                else
                {
                    updateUnitCmd.Parameters.AddWithValue("@Image_One", Image_One.Text);
                    updateUnitCmd.Parameters.AddWithValue("@Image_One_Path", Image_One_Pathe.Text);
                }

                //**********************************************************************************************************************************************************
                if (Image_Two_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(Image_Two_FileUpload.PostedFile.FileName);
                    Image_Two_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/units_Photo/") + fileName1);
                    updateUnitCmd.Parameters.AddWithValue("@Image_Two", fileName1);
                    updateUnitCmd.Parameters.AddWithValue("@Image_Two_Path",
                        "/English/Main_Application/units_Photo/" + fileName1);
                }
                else
                {
                    updateUnitCmd.Parameters.AddWithValue("@Image_Two", Image_Two.Text);
                    updateUnitCmd.Parameters.AddWithValue("@Image_Two_Path", Image_Two_Pathe.Text);
                }

                //**********************************************************************************************************************************************************
                if (Image_Three_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(Image_Three_FileUpload.PostedFile.FileName);
                    Image_Three_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/units_Photo/") + fileName1);
                    updateUnitCmd.Parameters.AddWithValue("@Image_Three", fileName1);
                    updateUnitCmd.Parameters.AddWithValue("@Image_Three_Path",
                        "/English/Main_Application/units_Photo/" + fileName1);
                }
                else
                {
                    updateUnitCmd.Parameters.AddWithValue("@Image_Three", Image_Three.Text);
                    updateUnitCmd.Parameters.AddWithValue("@Image_Three_Path", Image_Three_Pathe.Text);
                }

                //**********************************************************************************************************************************************************
                if (Image_Four_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(Image_Four_FileUpload.PostedFile.FileName);
                    Image_Four_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/units_Photo/") + fileName1);
                    updateUnitCmd.Parameters.AddWithValue("@Image_Four", fileName1);
                    updateUnitCmd.Parameters.AddWithValue("@Image_Four_Path",
                        "/English/Main_Application/units_Photo/" + fileName1);
                }
                else
                {
                    updateUnitCmd.Parameters.AddWithValue("@Image_Four", Image_Four.Text);
                    updateUnitCmd.Parameters.AddWithValue("@Image_Four_Path", Image_Four_Pathe.Text);
                }

                //**********************************************************************************************************************************************************
                updateUnitCmd.ExecuteNonQuery();
                _sqlCon.Close();
            }

           
        }
    }
}