using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Edit_Building : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "properties", 0, "R");
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "properties", 2, "E");
                Utilities.Roles.Delete_permission_With_Reason(_sqlCon, Session["Role"].ToString(), "properties", Delete_Building, Delete_Reason);
                Utilities.Roles.Delete_permission(_sqlCon, Session["Role"].ToString(), "properties", Remove_Link_Building_Photo);
                Utilities.Roles.Delete_permission(_sqlCon, Session["Role"].ToString(), "properties", Remove_Link_Plan);
                Utilities.Roles.Delete_permission(_sqlCon, Session["Role"].ToString(), "properties", Remove_Link_Statement);
                Utilities.Roles.Delete_permission(_sqlCon, Session["Role"].ToString(), "properties", Remove_Link_Maps);
                Utilities.Roles.Delete_permission(_sqlCon, Session["Role"].ToString(), "properties", Remove_Link_Permit);
                Utilities.Roles.Delete_permission(_sqlCon, Session["Role"].ToString(), "properties", Remove_Link_certificate_of_completion);
                Utilities.Roles.Delete_permission(_sqlCon, Session["Role"].ToString(), "properties", Remove_Link_Entrance_picture);
                Utilities.Roles.Delete_permission(_sqlCon, Session["Role"].ToString(), "properties", Remove_Link_Image);
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
                    _sqlCon.Open();
                    Building_Condition_DropDownList.DataSource =
                        getBuildingConditionDropDownListCmd.ExecuteReader();
                    Building_Condition_DropDownList.DataTextField = "Building_Arabic_Condition";
                    Building_Condition_DropDownList.DataValueField = "Building_Condition_Id";
                    Building_Condition_DropDownList.DataBind();
                    Building_Condition_DropDownList.Items.Insert(0, "اختر حالة البناء ....");
                    _sqlCon.Close();
                }

                //    //Get Building_Type  DropDownList
                using (MySqlCommand getBuildingTypeDropDownListCmd =
                       new MySqlCommand("SELECT * FROM building_type"))
                {
                    getBuildingTypeDropDownListCmd.CommandType = CommandType.Text;
                    getBuildingTypeDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    Building_Type_DropDownList.DataSource = getBuildingTypeDropDownListCmd.ExecuteReader();
                    Building_Type_DropDownList.DataTextField = "Building_Arabic_Type";
                    Building_Type_DropDownList.DataValueField = "Building_Type_Id";
                    Building_Type_DropDownList.DataBind();
                    Building_Type_DropDownList.Items.Insert(0, "إختر نوع البناء ....");
                    _sqlCon.Close();
                }

                //Get ownership_Name DropDownList
                using (MySqlCommand getOwnershipNameDropDownListCmd = new MySqlCommand("SELECT * FROM owner_ship"))
                {
                    getOwnershipNameDropDownListCmd.CommandType = CommandType.Text;
                    getOwnershipNameDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    ownership_Name_DropDownList.DataSource = getOwnershipNameDropDownListCmd.ExecuteReader();
                    ownership_Name_DropDownList.DataTextField = "Owner_Ship_AR_Name";
                    ownership_Name_DropDownList.DataValueField = "Owner_Ship_Id";
                    ownership_Name_DropDownList.DataBind();
                    ownership_Name_DropDownList.Items.Insert(0, "أختر إسم الملكية....");
                    _sqlCon.Close();
                }

                string buildingId = Request.QueryString["Id"];
                DataTable getBuildingDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getBuildingCmd =
                    new MySqlCommand("SELECT * FROM building WHERE Building_Id = @ID", _sqlCon);
                MySqlDataAdapter getBuildingDa = new MySqlDataAdapter(getBuildingCmd);
                getBuildingCmd.Parameters.AddWithValue("@ID", buildingId);
                getBuildingDa.Fill(getBuildingDt);
                if (getBuildingDt.Rows.Count > 0)
                {
                    txt_En_Bilding_Name.Text = getBuildingDt.Rows[0]["Building_English_Name"].ToString();
                    lbl_Name_Of_Building.Text = getBuildingDt.Rows[0]["Building_Arabic_Name"].ToString();
                    txt_Ar_Bilding_Name.Text = getBuildingDt.Rows[0]["Building_Arabic_Name"].ToString();
                    txt_electricity_meter.Text = getBuildingDt.Rows[0]["electricity_meter"].ToString();
                    txt_Water_meter.Text = getBuildingDt.Rows[0]["Water_meter"].ToString();
                    txt_Building_NO.Text = getBuildingDt.Rows[0]["Building_NO"].ToString();
                    txt_Construction_Area.Text = getBuildingDt.Rows[0]["Construction_Area"].ToString();
                    txt_Maintenance_status.Text = getBuildingDt.Rows[0]["Maintenance_status"].ToString();
                    txt_Building_Value.Text = getBuildingDt.Rows[0]["Building_Value"].ToString();
                    Construction_Completion_Date_DropDownList.SelectedItem.Text= getBuildingDt.Rows[0]["Construction_Completion_Date"].ToString();

                    Building_Condition_DropDownList.SelectedValue = getBuildingDt.Rows[0]["building_condition_Building_Condition_Id"].ToString();
                    Building_Type_DropDownList.SelectedValue =getBuildingDt.Rows[0]["building_type_Building_Type_Id"].ToString();
                    ownership_Name_DropDownList.SelectedValue =getBuildingDt.Rows[0]["owner_ship_Owner_Ship_Id"].ToString();

                    Building_Photo.Text = getBuildingDt.Rows[0]["Building_Photo"].ToString();
                    Building_Photo_Path.Text = getBuildingDt.Rows[0]["Building_Photo_Path"].ToString();
                    Plan.Text = getBuildingDt.Rows[0]["Plan"].ToString();
                    Plan_Path.Text = getBuildingDt.Rows[0]["Plano_Path"].ToString();
                    Statement.Text = getBuildingDt.Rows[0]["Statement"].ToString();
                    Statement_Path.Text = getBuildingDt.Rows[0]["Statement_Path"].ToString();
                    Maps.Text = getBuildingDt.Rows[0]["Map"].ToString();
                    Maps_Path.Text = getBuildingDt.Rows[0]["Map_path"].ToString();
                    Building_Permit.Text = getBuildingDt.Rows[0]["Building_Permit"].ToString();
                    Building_Permit_Path.Text = getBuildingDt.Rows[0]["Building_Permit_Path"].ToString();
                    certificate_of_completion.Text = getBuildingDt.Rows[0]["certificate_of_completion"].ToString();
                    certificate_of_completion_Path.Text =  getBuildingDt.Rows[0]["certificate_of_completion_Path"].ToString();
                    Entrance_picture.Text = getBuildingDt.Rows[0]["Entrance_Photo"].ToString();
                    Entrance_picture_Path.Text = getBuildingDt.Rows[0]["Entrance_Photo_Path"].ToString();
                    Image.Text = getBuildingDt.Rows[0]["Image"].ToString();
                    Image_Path.Text = getBuildingDt.Rows[0]["Image_Path"].ToString();







                    if (getBuildingDt.Rows[0]["Building_Photo"].ToString() != "No File") { Building_Photo_Div.Visible = true; }
                    else { Building_Photo_Div.Visible = false; }

                    if (getBuildingDt.Rows[0]["Plan"].ToString() != "No File") { Plan_Div.Visible = true; }
                    else { Plan_Div.Visible = false; }

                    if (getBuildingDt.Rows[0]["Statement"].ToString() != "No File") { Statement_Div.Visible = true; }
                    else { Statement_Div.Visible = false; }

                    if (getBuildingDt.Rows[0]["Map"].ToString() != "No File") { Maps_Div.Visible = true; }
                    else { Maps_Div.Visible = false; }

                    if (getBuildingDt.Rows[0]["Building_Permit"].ToString() != "No File") { Permit_Div.Visible = true; }
                    else { Permit_Div.Visible = false; }

                    if (getBuildingDt.Rows[0]["certificate_of_completion"].ToString() != "No File") { certificate_of_completion_Div.Visible = true; }
                    else { certificate_of_completion_Div.Visible = false; }

                    if (getBuildingDt.Rows[0]["Entrance_Photo"].ToString() != "No File") { Entrance_picture_Div.Visible = true; }
                    else { Entrance_picture_Div.Visible = false; }

                    if (getBuildingDt.Rows[0]["Image"].ToString() != "No File") { Image_Div.Visible = true; }
                    else { Image_Div.Visible = false; }


                    lbl_Link_Building_Photo.Text = getBuildingDt.Rows[0]["Building_Photo"].ToString();
                    Link_Building_Photo.HRef = getBuildingDt.Rows[0]["Building_Photo_Path"].ToString();
                    Link_Building_Photo.Target = "_blank";


                    lbl_Link_Plan.Text = getBuildingDt.Rows[0]["Plan"].ToString();
                    Link_Plan.HRef = getBuildingDt.Rows[0]["Plano_Path"].ToString();
                    Link_Plan.Target = "_blank";

                    lbl_Link_Statement.Text = getBuildingDt.Rows[0]["Statement"].ToString();
                    Link_Statement.HRef = getBuildingDt.Rows[0]["Statement_Path"].ToString();
                    Link_Statement.Target = "_blank";


                    lbl_Link_Maps.Text = getBuildingDt.Rows[0]["Map"].ToString();
                    Link_Maps.HRef = getBuildingDt.Rows[0]["Map_path"].ToString();
                    Link_Maps.Target = "_blank";


                    lbl_Link_Permit.Text = getBuildingDt.Rows[0]["Building_Permit"].ToString();
                    Link_Permit.HRef = getBuildingDt.Rows[0]["Building_Permit_Path"].ToString();
                    Link_Permit.Target = "_blank";

                    lbl_Link_certificate_of_completion.Text = getBuildingDt.Rows[0]["certificate_of_completion"].ToString();
                    Link_certificate_of_completion.HRef = getBuildingDt.Rows[0]["certificate_of_completion_Path"].ToString();
                    Link_certificate_of_completion.Target = "_blank";

                    lbl_Link_Entrance_picture.Text = getBuildingDt.Rows[0]["Entrance_Photo"].ToString();
                    Link_Entrance_picture.HRef = getBuildingDt.Rows[0]["Entrance_Photo_Path"].ToString();
                    Link_Entrance_picture.Target = "_blank";


                    lbl_Link_Image.Text = getBuildingDt.Rows[0]["Image"].ToString();
                    Link_Imagee.HRef = getBuildingDt.Rows[0]["Image_Path"].ToString();
                    Link_Imagee.Target = "_blank";
                }
                _sqlCon.Close();

                Zone_Street();


                if (Session["B_Back"].ToString() == "1")
                {
                    btn_Back_To_Building.Text = "العودة لقائمة الأبنية";
                }
                else if (Session["B_Back"].ToString() == "2")
                {
                    btn_Back_To_Building.Text = "العودة لعمليات الملكيات";
                }
                else if (Session["B_Back"].ToString() == "3")
                {
                    btn_Back_To_Building.Text = "العودة لكشف النواقص";
                }
                else
                {
                    btn_Back_To_Building.Text = "العودة لقائمة الأبنية";
                }
            }
        }

        protected void btn_Add_Building_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string buildingId = Request.QueryString["ID"];
                string updateBuildingQuery = "UPDATE building SET " +
                                             "owner_ship_Owner_Ship_Id =@owner_ship_Owner_Ship_Id , " +
                                             "building_condition_Building_Condition_Id=@building_condition_Building_Condition_Id, " +
                                             "building_type_Building_Type_Id=@building_type_Building_Type_Id, " +
                                             "Building_English_Name = @Building_English_Name ," +
                                             "Building_Arabic_Name=@Building_Arabic_Name," +
                                             "electricity_meter = @electricity_meter ," +
                                             "Water_meter =@Water_meter ," +
                                             "Building_NO=@Building_NO , " +
                                             "Construction_Area=@Construction_Area ," +
                                             "Maintenance_status=@Maintenance_status ," +
                                             "Building_Value=@Building_Value ," +
                                             "Construction_Completion_Date=@Construction_Completion_Date ," +
                                             "Building_Photo=@Building_Photo ," +
                                             "Building_Photo_Path=@Building_Photo_Path ," +
                                             "Entrance_Photo=@Entrance_Photo ," +
                                             "Entrance_Photo_Path=@Entrance_Photo_Path ," +
                                             "Statement=@Statement ," +
                                             "Statement_Path=@Statement_Path ," +
                                             "Building_Permit=@Building_Permit ," +
                                             "Building_Permit_Path=@Building_Permit_Path ," +
                                             "certificate_of_completion=@certificate_of_completion ," +
                                             "certificate_of_completion_Path=@certificate_of_completion_Path ," +
                                             "Image=@Image ," +
                                             "Image_Path=@Image_Path ," +
                                             "Map=@Map ," +
                                             "Map_path=@Map_path ," +
                                             "Plan=@Plan ," +
                                             "Plano_Path=@Plano_Path " +
                                             "Where Building_Id=@ID";
                _sqlCon.Open();
                MySqlCommand updateBuildingCmd = new MySqlCommand(updateBuildingQuery, _sqlCon);
                updateBuildingCmd.Parameters.AddWithValue("@ID", buildingId);
                updateBuildingCmd.Parameters.AddWithValue("@Building_English_Name", txt_En_Bilding_Name.Text);
                updateBuildingCmd.Parameters.AddWithValue("@Building_Arabic_Name", txt_Ar_Bilding_Name.Text);
                updateBuildingCmd.Parameters.AddWithValue("@electricity_meter", txt_electricity_meter.Text);
                updateBuildingCmd.Parameters.AddWithValue("@Water_meter", txt_Water_meter.Text);
                updateBuildingCmd.Parameters.AddWithValue("@Building_NO", txt_Building_NO.Text);
                updateBuildingCmd.Parameters.AddWithValue("@Construction_Area", txt_Construction_Area.Text);
                updateBuildingCmd.Parameters.AddWithValue("@Maintenance_status", txt_Maintenance_status.Text);
                updateBuildingCmd.Parameters.AddWithValue("@Building_Value", txt_Building_Value.Text);
                updateBuildingCmd.Parameters.AddWithValue("@Construction_Completion_Date", Construction_Completion_Date_DropDownList.SelectedItem.Text);

                updateBuildingCmd.Parameters.AddWithValue("@owner_ship_Owner_Ship_Id", ownership_Name_DropDownList.SelectedValue);
                updateBuildingCmd.Parameters.AddWithValue("@building_condition_Building_Condition_Id",Building_Condition_DropDownList.SelectedValue);
                updateBuildingCmd.Parameters.AddWithValue("@building_type_Building_Type_Id",Building_Type_DropDownList.SelectedValue);

                if (Building_Photo_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(Building_Photo_FileUpload.PostedFile.FileName);
                    Building_Photo_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/Building_File/Building_Photo/") + fileName1);
                    updateBuildingCmd.Parameters.AddWithValue("@Building_Photo", fileName1);
                    updateBuildingCmd.Parameters.AddWithValue("@Building_Photo_Path",
                        "/English/Main_Application/Building_File/Building_Photo/" + fileName1);
                }
                else
                {
                    updateBuildingCmd.Parameters.AddWithValue("@Building_Photo", Building_Photo.Text);
                    updateBuildingCmd.Parameters.AddWithValue("@Building_Photo_Path", Building_Photo_Path.Text);
                }

                //**********************************************************************************************************************************************************
                if (Statement_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(Statement_FileUpload.PostedFile.FileName);
                    Statement_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/Building_File/Statement/") + fileName1);
                    updateBuildingCmd.Parameters.AddWithValue("@Statement", fileName1);
                    updateBuildingCmd.Parameters.AddWithValue("@Statement_Path",
                        "/English/Main_Application/Building_File/Statement/" + fileName1);
                }
                else
                {
                    updateBuildingCmd.Parameters.AddWithValue("@Statement", Statement.Text);
                    updateBuildingCmd.Parameters.AddWithValue("@Statement_Path", Statement_Path.Text);
                }

                //**********************************************************************************************************************************************************
                if (Building_Permit_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(Building_Permit_FileUpload.PostedFile.FileName);
                    Building_Permit_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/Building_File/Building_Permit/") + fileName1);
                    updateBuildingCmd.Parameters.AddWithValue("@Building_Permit", fileName1);
                    updateBuildingCmd.Parameters.AddWithValue("@Building_Permit_Path",
                        "/English/Main_Application/Building_File/Building_Permit/" + fileName1);
                }
                else
                {
                    updateBuildingCmd.Parameters.AddWithValue("@Building_Permit", Building_Permit.Text);
                    updateBuildingCmd.Parameters.AddWithValue("@Building_Permit_Path", Building_Permit_Path.Text);
                }

                //**********************************************************************************************************************************************************
                if (certificate_of_completion_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(certificate_of_completion_FileUpload.PostedFile.FileName);
                    certificate_of_completion_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/Building_File/certificate_completion/") + fileName1);
                    updateBuildingCmd.Parameters.AddWithValue("@certificate_of_completion", fileName1);
                    updateBuildingCmd.Parameters.AddWithValue("@certificate_of_completion_Path",
                        "/English/Main_Application/Building_File/certificate_completion/" + fileName1);
                }
                else
                {
                    updateBuildingCmd.Parameters.AddWithValue("@certificate_of_completion",
                        certificate_of_completion.Text);
                    updateBuildingCmd.Parameters.AddWithValue("@certificate_of_completion_Path",
                        certificate_of_completion_Path.Text);
                }

                //**********************************************************************************************************************************************************
                if (Image_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(Image_FileUpload.PostedFile.FileName);
                    Image_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/Building_File/Image/") + fileName1);
                    updateBuildingCmd.Parameters.AddWithValue("@Image", fileName1);
                    updateBuildingCmd.Parameters.AddWithValue("@Image_Path",
                        "/English/Main_Application/Building_File/Image/" + fileName1);
                }
                else
                {
                    updateBuildingCmd.Parameters.AddWithValue("@Image", Image.Text);
                    updateBuildingCmd.Parameters.AddWithValue("@Image_Path", Image_Path.Text);
                }

                //**********************************************************************************************************************************************************
                if (Maps_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(Maps_FileUpload.PostedFile.FileName);
                    Maps_FileUpload.PostedFile.SaveAs(Server.MapPath("/English/Main_Application/Building_File/Map/") +
                                                      fileName1);
                    updateBuildingCmd.Parameters.AddWithValue("@Map", fileName1);
                    updateBuildingCmd.Parameters.AddWithValue("@Map_Path",
                        "/English/Main_Application/Building_File/Map/" + fileName1);
                }
                else
                {
                    updateBuildingCmd.Parameters.AddWithValue("@Map", Maps.Text);
                    updateBuildingCmd.Parameters.AddWithValue("@Map_Path", Maps_Path.Text);
                }

                //**********************************************************************************************************************************************************
                if (Plan_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(Plan_FileUpload.PostedFile.FileName);
                    Plan_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/Building_File/Building_Plan/") + fileName1);
                    updateBuildingCmd.Parameters.AddWithValue("@Plan", fileName1);
                    updateBuildingCmd.Parameters.AddWithValue("@Plano_Path",
                        "/English/Main_Application/Building_File/Building_Plan/" + fileName1);
                }
                else
                {
                    updateBuildingCmd.Parameters.AddWithValue("@Plan", Plan.Text);
                    updateBuildingCmd.Parameters.AddWithValue("@Plano_Path", Plan_Path.Text);
                }

                //**********************************************************************************************************************************************************
                if (Entrance_picture_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(Entrance_picture_FileUpload.PostedFile.FileName);
                    Entrance_picture_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/Building_File/Entrace_Photo/") + fileName1);
                    updateBuildingCmd.Parameters.AddWithValue("@Entrance_Photo", fileName1);
                    updateBuildingCmd.Parameters.AddWithValue("@Entrance_Photo_Path",
                        "/English/Main_Application/Building_File/Entrace_Photo/" + fileName1);
                }
                else
                {
                    updateBuildingCmd.Parameters.AddWithValue("@Entrance_Photo", Entrance_picture.Text);
                    updateBuildingCmd.Parameters.AddWithValue("@Entrance_Photo_Path", Entrance_picture_Path.Text);
                }

                updateBuildingCmd.ExecuteNonQuery();
                _sqlCon.Close();


                Edit_Arcived_Building();



                lbl_Success_Add_Building.Text = "تم التعديل بنجاح";
            }
        }

        protected void btn_Back_To_Building_Click(object sender, EventArgs e)
        {
            if (Session["B_Back"].ToString() == "1")
            {
                Response.Redirect("Building_List.aspx");
            }
            else if (Session["B_Back"].ToString() == "2")
            {
                Response.Redirect("Test_4.aspx?Id=2");
            }
            else if (Session["B_Back"].ToString() == "3")
            {
                Response.Redirect("Missing_Fields.aspx");
            }
            else
            {
                Response.Redirect("Building_List.aspx");
            }
            
        }

        protected void Btn_Remove_Link_Image_Click(object sender, EventArgs e)
        {
            string Building_Id = Request.QueryString["ID"];

            string Remove_Building_Att_Query = "UPDATE building SET " +
                                                " Image=@Image ," +
                                                " Image_Path=@Image_Path  " +
                                                "WHERE Building_Id=@ID";
            _sqlCon.Open();
            MySqlCommand Remove_Building_Att_Cmd = new MySqlCommand(Remove_Building_Att_Query, _sqlCon);
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@ID", Building_Id);
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@Image", "No File");
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@Image_Path", "No File");
            Remove_Building_Att_Cmd.ExecuteNonQuery();
            _sqlCon.Close();

            Response.Redirect("Edit_Building.aspx?Id=" + Building_Id);
        }

        protected void Btn_Remove_Link_Entrance_picture_Click(object sender, EventArgs e)
        {
            string Building_Id = Request.QueryString["ID"];

            string Remove_Building_Att_Query = "UPDATE building SET " +
                                                " Entrance_Photo=@Entrance_Photo ," +
                                                " Entrance_Photo_Path=@Entrance_Photo_Path  " +
                                                "WHERE Building_Id=@ID";
            _sqlCon.Open();
            MySqlCommand Remove_Building_Att_Cmd = new MySqlCommand(Remove_Building_Att_Query, _sqlCon);
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@ID", Building_Id);
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@Entrance_Photo", "No File");
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@Entrance_Photo_Path", "No File");
            Remove_Building_Att_Cmd.ExecuteNonQuery();
            _sqlCon.Close();

            Response.Redirect("Edit_Building.aspx?Id=" + Building_Id);
        }

        protected void Btn_Remove_Link_certificate_of_completion_Click(object sender, EventArgs e)
        {
            string Building_Id = Request.QueryString["ID"];

            string Remove_Building_Att_Query = "UPDATE building SET " +
                                                " certificate_of_completion=@certificate_of_completion ," +
                                                " certificate_of_completion_Path=@certificate_of_completion_Path  " +
                                                "WHERE Building_Id=@ID";
            _sqlCon.Open();
            MySqlCommand Remove_Building_Att_Cmd = new MySqlCommand(Remove_Building_Att_Query, _sqlCon);
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@ID", Building_Id);
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@certificate_of_completion", "No File");
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@certificate_of_completion_Path", "No File");
            Remove_Building_Att_Cmd.ExecuteNonQuery();
            _sqlCon.Close();

            Response.Redirect("Edit_Building.aspx?Id=" + Building_Id);
        }

        protected void Btn_Remove_Link_Permit_Click(object sender, EventArgs e)
        {
            string Building_Id = Request.QueryString["ID"];

            string Remove_Building_Att_Query = "UPDATE building SET " +
                                                " Building_Permit=@Building_Permit ," +
                                                " Building_Permit_Path=@Building_Permit_Path  " +
                                                "WHERE Building_Id=@ID";
            _sqlCon.Open();
            MySqlCommand Remove_Building_Att_Cmd = new MySqlCommand(Remove_Building_Att_Query, _sqlCon);
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@ID", Building_Id);
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@Building_Permit", "No File");
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@Building_Permit_Path", "No File");
            Remove_Building_Att_Cmd.ExecuteNonQuery();
            _sqlCon.Close();

            Response.Redirect("Edit_Building.aspx?Id=" + Building_Id);
        }

        protected void Btn_Remove_Link_Maps_Click(object sender, EventArgs e)
        {
            string Building_Id = Request.QueryString["ID"];

            string Remove_Building_Att_Query = "UPDATE building SET " +
                                                " Map=@Map ," +
                                                " Map_path=@Map_path  " +
                                                "WHERE Building_Id=@ID";
            _sqlCon.Open();
            MySqlCommand Remove_Building_Att_Cmd = new MySqlCommand(Remove_Building_Att_Query, _sqlCon);
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@ID", Building_Id);
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@Map", "No File");
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@Map_path", "No File");
            Remove_Building_Att_Cmd.ExecuteNonQuery();
            _sqlCon.Close();

            Response.Redirect("Edit_Building.aspx?Id=" + Building_Id);
        }

        protected void Btn_Remove_Link_Statement_Click(object sender, EventArgs e)
        {
            string Building_Id = Request.QueryString["ID"];

            string Remove_Building_Att_Query = "UPDATE building SET " +
                                                " Statement=@Statement ," +
                                                " Statement_Path=@Statement_Path  " +
                                                "WHERE Building_Id=@ID";
            _sqlCon.Open();
            MySqlCommand Remove_Building_Att_Cmd = new MySqlCommand(Remove_Building_Att_Query, _sqlCon);
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@ID", Building_Id);
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@Statement", "No File");
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@Statement_Path", "No File");
            Remove_Building_Att_Cmd.ExecuteNonQuery();
            _sqlCon.Close();

            Response.Redirect("Edit_Building.aspx?Id=" + Building_Id);
        }

        protected void Btn_Remove_Link_Plan_Click(object sender, EventArgs e)
        {
            string Building_Id = Request.QueryString["ID"];

            string Remove_Building_Att_Query = "UPDATE building SET " +
                                                " Plan=@Plan ," +
                                                " Plano_Path=@Plano_Path  " +
                                                "WHERE Building_Id=@ID";
            _sqlCon.Open();
            MySqlCommand Remove_Building_Att_Cmd = new MySqlCommand(Remove_Building_Att_Query, _sqlCon);
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@ID", Building_Id);
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@Plan", "No File");
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@Plano_Path", "No File");
            Remove_Building_Att_Cmd.ExecuteNonQuery();
            _sqlCon.Close();

            Response.Redirect("Edit_Building.aspx?Id=" + Building_Id);
        }

        protected void Btn_Remove_Link_Building_Photo_Click(object sender, EventArgs e)
        {
            string Building_Id = Request.QueryString["ID"];

            string Remove_Building_Att_Query = "UPDATE building SET " +
                                                " Building_Photo=@Building_Photo ," +
                                                " Building_Photo_Path=@Building_Photo_Path  " +
                                                "WHERE Building_Id=@ID";
            _sqlCon.Open();
            MySqlCommand Remove_Building_Att_Cmd = new MySqlCommand(Remove_Building_Att_Query, _sqlCon);
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@ID", Building_Id);
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@Building_Photo", "No File");
            Remove_Building_Att_Cmd.Parameters.AddWithValue("@Building_Photo_Path", "No File");
            Remove_Building_Att_Cmd.ExecuteNonQuery();
            _sqlCon.Close();

            Response.Redirect("Edit_Building.aspx?Id=" + Building_Id);
        }

        protected void btn_Back_To_B_Lists_Click(object sender, EventArgs e)
        {
            Response.Redirect("lists.aspx");
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

        protected void Delete_Building_Click(object sender, EventArgs e)
        {
            string BuildingId = Request.QueryString["ID"];

            try
            {
                _sqlCon.Open();
                string deleteBuildingQuary = "DELETE FROM building WHERE Building_Id=@ID ";
                MySqlCommand mySqlCmd = new MySqlCommand(deleteBuildingQuary, _sqlCon);
                mySqlCmd.Parameters.AddWithValue("@ID", BuildingId);
                mySqlCmd.ExecuteNonQuery();



                string addArciveBuildingQuary = "Insert Into delete_archive " +
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
                MySqlCommand addArciveBuildingCmd = new MySqlCommand(addArciveBuildingQuary, _sqlCon);
                addArciveBuildingCmd.Parameters.AddWithValue("@User_Id", Session["user_ID"].ToString());
                addArciveBuildingCmd.Parameters.AddWithValue("@Delete_Date", DateTime.Now.ToString("dd/MM/yyyy"));
                addArciveBuildingCmd.Parameters.AddWithValue("@OS_B_U", "B");
                addArciveBuildingCmd.Parameters.AddWithValue("@Item_Id", BuildingId);
                addArciveBuildingCmd.Parameters.AddWithValue("@Reason_Delete", txt_Reason_Delete.Text);
                addArciveBuildingCmd.ExecuteNonQuery();


                Response.Redirect("Building_List.aspx");
            }
            catch
            {
                Response.Write(@"<script language='javascript'>alert('لا يمكن حذف هذه البناء لأنه يحتوي على  وحدات أو عقود ')</script>");
            };
            _sqlCon.Close();
        }




        protected void Edit_Arcived_Building()
        {
            string buildingId = Request.QueryString["ID"];
            string updateBuildingQuery = "UPDATE arcive_building SET " +
                                         "owner_ship_Owner_Ship_Id =@owner_ship_Owner_Ship_Id , " +
                                         "building_condition_Building_Condition_Id=@building_condition_Building_Condition_Id, " +
                                         "building_type_Building_Type_Id=@building_type_Building_Type_Id, " +
                                         "Building_English_Name = @Building_English_Name ," +
                                         "Building_Arabic_Name=@Building_Arabic_Name," +
                                         "electricity_meter = @electricity_meter ," +
                                         "Water_meter =@Water_meter ," +
                                         "Building_NO=@Building_NO , " +
                                         "Construction_Area=@Construction_Area ," +
                                         "Maintenance_status=@Maintenance_status ," +
                                         "Building_Value=@Building_Value ," +
                                         "Construction_Completion_Date=@Construction_Completion_Date ," +
                                         "Building_Photo=@Building_Photo ," +
                                         "Building_Photo_Path=@Building_Photo_Path ," +
                                         "Entrance_Photo=@Entrance_Photo ," +
                                         "Entrance_Photo_Path=@Entrance_Photo_Path ," +
                                         "Statement=@Statement ," +
                                         "Statement_Path=@Statement_Path ," +
                                         "Building_Permit=@Building_Permit ," +
                                         "Building_Permit_Path=@Building_Permit_Path ," +
                                         "certificate_of_completion=@certificate_of_completion ," +
                                         "certificate_of_completion_Path=@certificate_of_completion_Path ," +
                                         "Image=@Image ," +
                                         "Image_Path=@Image_Path ," +
                                         "Map=@Map ," +
                                         "Map_path=@Map_path ," +
                                         "Plan=@Plan ," +
                                         "Plano_Path=@Plano_Path " +
                                         "Where Building_Id=@ID";
            _sqlCon.Open();
            MySqlCommand updateBuildingCmd = new MySqlCommand(updateBuildingQuery, _sqlCon);
            updateBuildingCmd.Parameters.AddWithValue("@ID", buildingId);
            updateBuildingCmd.Parameters.AddWithValue("@Building_English_Name", txt_En_Bilding_Name.Text);
            updateBuildingCmd.Parameters.AddWithValue("@Building_Arabic_Name", txt_Ar_Bilding_Name.Text);
            updateBuildingCmd.Parameters.AddWithValue("@electricity_meter", txt_electricity_meter.Text);
            updateBuildingCmd.Parameters.AddWithValue("@Water_meter", txt_Water_meter.Text);
            updateBuildingCmd.Parameters.AddWithValue("@Building_NO", txt_Building_NO.Text);
            updateBuildingCmd.Parameters.AddWithValue("@Construction_Area", txt_Construction_Area.Text);
            updateBuildingCmd.Parameters.AddWithValue("@Maintenance_status", txt_Maintenance_status.Text);
            updateBuildingCmd.Parameters.AddWithValue("@Building_Value", txt_Building_Value.Text);
            updateBuildingCmd.Parameters.AddWithValue("@Construction_Completion_Date", Construction_Completion_Date_DropDownList.SelectedItem.Text);

            updateBuildingCmd.Parameters.AddWithValue("@owner_ship_Owner_Ship_Id", ownership_Name_DropDownList.SelectedValue);
            updateBuildingCmd.Parameters.AddWithValue("@building_condition_Building_Condition_Id", Building_Condition_DropDownList.SelectedValue);
            updateBuildingCmd.Parameters.AddWithValue("@building_type_Building_Type_Id", Building_Type_DropDownList.SelectedValue);

            if (Building_Photo_FileUpload.HasFile)
            {
                string fileName1 = Path.GetFileName(Building_Photo_FileUpload.PostedFile.FileName);
                Building_Photo_FileUpload.PostedFile.SaveAs(
                    Server.MapPath("/English/Main_Application/Building_File/Building_Photo/") + fileName1);
                updateBuildingCmd.Parameters.AddWithValue("@Building_Photo", fileName1);
                updateBuildingCmd.Parameters.AddWithValue("@Building_Photo_Path",
                    "/English/Main_Application/Building_File/Building_Photo/" + fileName1);
            }
            else
            {
                updateBuildingCmd.Parameters.AddWithValue("@Building_Photo", Building_Photo.Text);
                updateBuildingCmd.Parameters.AddWithValue("@Building_Photo_Path", Building_Photo_Path.Text);
            }

            //**********************************************************************************************************************************************************
            if (Statement_FileUpload.HasFile)
            {
                string fileName1 = Path.GetFileName(Statement_FileUpload.PostedFile.FileName);
                Statement_FileUpload.PostedFile.SaveAs(
                    Server.MapPath("/English/Main_Application/Building_File/Statement/") + fileName1);
                updateBuildingCmd.Parameters.AddWithValue("@Statement", fileName1);
                updateBuildingCmd.Parameters.AddWithValue("@Statement_Path",
                    "/English/Main_Application/Building_File/Statement/" + fileName1);
            }
            else
            {
                updateBuildingCmd.Parameters.AddWithValue("@Statement", Statement.Text);
                updateBuildingCmd.Parameters.AddWithValue("@Statement_Path", Statement_Path.Text);
            }

            //**********************************************************************************************************************************************************
            if (Building_Permit_FileUpload.HasFile)
            {
                string fileName1 = Path.GetFileName(Building_Permit_FileUpload.PostedFile.FileName);
                Building_Permit_FileUpload.PostedFile.SaveAs(
                    Server.MapPath("/English/Main_Application/Building_File/Building_Permit/") + fileName1);
                updateBuildingCmd.Parameters.AddWithValue("@Building_Permit", fileName1);
                updateBuildingCmd.Parameters.AddWithValue("@Building_Permit_Path",
                    "/English/Main_Application/Building_File/Building_Permit/" + fileName1);
            }
            else
            {
                updateBuildingCmd.Parameters.AddWithValue("@Building_Permit", Building_Permit.Text);
                updateBuildingCmd.Parameters.AddWithValue("@Building_Permit_Path", Building_Permit_Path.Text);
            }

            //**********************************************************************************************************************************************************
            if (certificate_of_completion_FileUpload.HasFile)
            {
                string fileName1 = Path.GetFileName(certificate_of_completion_FileUpload.PostedFile.FileName);
                certificate_of_completion_FileUpload.PostedFile.SaveAs(
                    Server.MapPath("/English/Main_Application/Building_File/certificate_completion/") + fileName1);
                updateBuildingCmd.Parameters.AddWithValue("@certificate_of_completion", fileName1);
                updateBuildingCmd.Parameters.AddWithValue("@certificate_of_completion_Path",
                    "/English/Main_Application/Building_File/certificate_completion/" + fileName1);
            }
            else
            {
                updateBuildingCmd.Parameters.AddWithValue("@certificate_of_completion",
                    certificate_of_completion.Text);
                updateBuildingCmd.Parameters.AddWithValue("@certificate_of_completion_Path",
                    certificate_of_completion_Path.Text);
            }

            //**********************************************************************************************************************************************************
            if (Image_FileUpload.HasFile)
            {
                string fileName1 = Path.GetFileName(Image_FileUpload.PostedFile.FileName);
                Image_FileUpload.PostedFile.SaveAs(
                    Server.MapPath("/English/Main_Application/Building_File/Image/") + fileName1);
                updateBuildingCmd.Parameters.AddWithValue("@Image", fileName1);
                updateBuildingCmd.Parameters.AddWithValue("@Image_Path",
                    "/English/Main_Application/Building_File/Image/" + fileName1);
            }
            else
            {
                updateBuildingCmd.Parameters.AddWithValue("@Image", Image.Text);
                updateBuildingCmd.Parameters.AddWithValue("@Image_Path", Image_Path.Text);
            }

            //**********************************************************************************************************************************************************
            if (Maps_FileUpload.HasFile)
            {
                string fileName1 = Path.GetFileName(Maps_FileUpload.PostedFile.FileName);
                Maps_FileUpload.PostedFile.SaveAs(Server.MapPath("/English/Main_Application/Building_File/Map/") +
                                                  fileName1);
                updateBuildingCmd.Parameters.AddWithValue("@Map", fileName1);
                updateBuildingCmd.Parameters.AddWithValue("@Map_Path",
                    "/English/Main_Application/Building_File/Map/" + fileName1);
            }
            else
            {
                updateBuildingCmd.Parameters.AddWithValue("@Map", Maps.Text);
                updateBuildingCmd.Parameters.AddWithValue("@Map_Path", Maps_Path.Text);
            }

            //**********************************************************************************************************************************************************
            if (Plan_FileUpload.HasFile)
            {
                string fileName1 = Path.GetFileName(Plan_FileUpload.PostedFile.FileName);
                Plan_FileUpload.PostedFile.SaveAs(
                    Server.MapPath("/English/Main_Application/Building_File/Building_Plan/") + fileName1);
                updateBuildingCmd.Parameters.AddWithValue("@Plan", fileName1);
                updateBuildingCmd.Parameters.AddWithValue("@Plano_Path",
                    "/English/Main_Application/Building_File/Building_Plan/" + fileName1);
            }
            else
            {
                updateBuildingCmd.Parameters.AddWithValue("@Plan", Plan.Text);
                updateBuildingCmd.Parameters.AddWithValue("@Plano_Path", Plan_Path.Text);
            }

            //**********************************************************************************************************************************************************
            if (Entrance_picture_FileUpload.HasFile)
            {
                string fileName1 = Path.GetFileName(Entrance_picture_FileUpload.PostedFile.FileName);
                Entrance_picture_FileUpload.PostedFile.SaveAs(
                    Server.MapPath("/English/Main_Application/Building_File/Entrace_Photo/") + fileName1);
                updateBuildingCmd.Parameters.AddWithValue("@Entrance_Photo", fileName1);
                updateBuildingCmd.Parameters.AddWithValue("@Entrance_Photo_Path",
                    "/English/Main_Application/Building_File/Entrace_Photo/" + fileName1);
            }
            else
            {
                updateBuildingCmd.Parameters.AddWithValue("@Entrance_Photo", Entrance_picture.Text);
                updateBuildingCmd.Parameters.AddWithValue("@Entrance_Photo_Path", Entrance_picture_Path.Text);
            }

            updateBuildingCmd.ExecuteNonQuery();
            _sqlCon.Close();
        }
    }
}