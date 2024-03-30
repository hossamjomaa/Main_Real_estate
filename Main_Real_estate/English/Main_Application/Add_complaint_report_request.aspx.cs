using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Add_complaint_report_request : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Asset_Management", 0, "R");
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Asset_Management", 1, "A");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!this.IsPostBack)
            {
                //   Fill Employee Name DropDownList
                DataTable get_Employee_DataTable = new DataTable();
                _sqlCon.Open();
                MySqlCommand get_Employee_Cmd =
                    new MySqlCommand("SELECT * FROM users WHERE Users_Name = @Users_Name", _sqlCon);
                MySqlDataAdapter get_Employee_Da = new MySqlDataAdapter(get_Employee_Cmd);
                if (Session["Users_Name"].ToString() != null)
                {
                    get_Employee_Cmd.Parameters.AddWithValue("@Users_Name", Session["Users_Name"].ToString());
                    get_Employee_Da.Fill(get_Employee_DataTable);
                    if (get_Employee_DataTable.Rows.Count > 0)
                    {
                        txt_Dtl_Employee_Name.Text = "مقدم الطلب السيد : " + get_Employee_DataTable.Rows[0]["Users_Ar_First_Name"].ToString()
                    + " " + get_Employee_DataTable.Rows[0]["Users_Ar_Last_Name"].ToString();
                    }
                }
                else { Response.Redirect("Log_In.aspx"); }
                _sqlCon.Close();

                //---------------------------------------------------------------------------------------------------------------------------------

                //Fill Employee / Tenant DropDownList
                Helper.LoadDropDownList("SELECT * FROM tenants", _sqlCon, Employee_Tenant_DropDownList, "Tenants_Arabic_Name", "Tenants_ID");
                Employee_Tenant_DropDownList.Items.Insert(0, "إختر اسم المستأجر ....");

                //Fill Technical_DropDownList
                Helper.LoadDropDownList("SELECT * FROM employee", _sqlCon, Technical_DropDownList, "Employee_Arabic_name", "Employee_Id");
                Technical_DropDownList.Items.Insert(0, "إختر الفني المسؤول ....");

                //Fill Technical_DropDownList
                Helper.LoadDropDownList("SELECT * FROM employee", _sqlCon, Observer_DropDownList, "Employee_Arabic_name", "Employee_Id");
                Observer_DropDownList.Items.Insert(0, "إختر المراقب  ....");

                Building_Or_unit_DropDownList.Items.Insert(0, "إختر بناء أو وحدة ....");
                Request_Classification_DropDownList.Items.Insert(0, "إختر صنف الطلب ....");
                Request_Type_DropDownList.Items.Insert(0, "إختر النوع ....");
                Order_priority_DropDownList.Items.Insert(0, "إختر مدى العاجلية ....");
                Danger_Magnitude_DropDownList.Items.Insert(0, "إختر درجة الخطورة ....");
                Maintenance_Status_DropDownList.Items.Insert(0, "إختر حالة طلب الصيانة ....");
                Maintenance_Guarantor_DropDownList.Items.Insert(0, "إختر  ....");
                Executing_Agency_DropDownList.Items.Insert(0, "إختر الجهة المنفذة ....");

                //Fill Maintenance_Type_DropDownList
                Helper.LoadDropDownList("SELECT * FROM maintenance_categoty Where Main_Categoty = 0", _sqlCon, Maintenance_Type_DropDownList, "Categoty_AR", "Categoty_Id");
                Maintenance_Type_DropDownList.Items.Insert(0, "إختر نوع الصيانة ....");

                //Fill Maintenance_Type_DropDownList
                Helper.LoadDropDownList("SELECT * FROM maintenance_categoty Where Main_Categoty != 0", _sqlCon, Maintenance_SubType_DropDownList, "Categoty_AR", "Categoty_Id");
                Maintenance_SubType_DropDownList.Items.Insert(0, "إختر النوع الفرعي للصيانة ....");

                //Fill Asset_DropDownList
                Helper.LoadDropDownList("SELECT * FROM assets", _sqlCon, Asset_DropDownList, "Assets_Arabic_Name", "Assets_Id");
                Asset_DropDownList.Items.Insert(0, "إختر الاصل ....");

                //Fill Complainte_Source_DropDownList
                Helper.LoadDropDownList("SELECT * FROM requst_source", _sqlCon, Complainte_Source_DropDownList, "Ar_Requst_Source", "Requst_Source_id");
                Complainte_Source_DropDownList.SelectedValue = "1";
                txt_Report_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");



                //--------------------------------------- Fill Maintenance GridView with Added Maintenance --------------------------------------------------------------
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[15]
                {
                    new DataColumn("Maintenance_Type"),
                    new DataColumn("Maintenance_SubType"), new DataColumn("maintenance_subtypes_Maintenance_Subtypes_Id"),
                    new DataColumn("Asset"), new DataColumn("assets_Assets_Id"),
                    new DataColumn("Executing_Agency"), new DataColumn("Cost_Direction"),
                    new DataColumn("technical") ,new DataColumn("Technical_ID"),
                    new DataColumn("watcher"), new DataColumn("Watcher_ID"),
                    new DataColumn("Start_Date"),new DataColumn("End_Date"),new DataColumn("Cost"),
                    new DataColumn("Act")
                });
                ViewState["Customers"] = dt;
                this.BindGrid();

            }
        }
        protected void Add_Maintenane_Click(object sender, ImageClickEventArgs e)
        {
            DataTable dt1 = (DataTable)ViewState["Customers"];
            dt1.Rows.Add
            (
                Maintenance_Type_DropDownList.SelectedItem.Text.Trim(),
                Maintenance_SubType_DropDownList.SelectedItem.Text.Trim(), Maintenance_SubType_DropDownList.SelectedValue,
                Asset_DropDownList.SelectedItem.Text.Trim(), Asset_DropDownList.SelectedValue,
                Executing_Agency_DropDownList.SelectedItem.Text.Trim(), Maintenance_Guarantor_DropDownList.SelectedItem.Text.Trim(),
                Technical_DropDownList.SelectedItem.Text.Trim(), Technical_DropDownList.SelectedValue,
                Observer_DropDownList.SelectedItem.Text.Trim(), Observer_DropDownList.SelectedValue,
                txt_Start_Date.Text.Trim(), txt_End_Date.Text.Trim(), txt_Cost.Text.Trim(),
                Maintenance_Status_DropDownList.SelectedItem.Text.Trim()
            );
            ViewState["Customers"] = dt1;
            this.BindGrid();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "", "window.onload=function(){window.scrollTo(0,document.body.scrollHeight)};", true);
        }
        protected void BindGrid()
        {
            Maintenance_GridView.DataSource = (DataTable)ViewState["Customers"];
            Maintenance_GridView.DataBind();
        }
        protected void Complainte_Source_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Complainte_Source_DropDownList.SelectedValue == "1")
            {
                Employee_Tenant_Div.Visible = true; Other_Div.Visible=false;
                lbl_Employee_Tenant.Text = "اسم المستاجر";

                //Fill Employee / Tenant DropDownList
                Helper.LoadDropDownList("SELECT * FROM tenants", _sqlCon, Employee_Tenant_DropDownList, "Tenants_Arabic_Name", "Tenants_ID");
                Employee_Tenant_DropDownList.Items.Insert(0, "إختر اسم المستأجر ....");

            }
            else if (Complainte_Source_DropDownList.SelectedValue == "2")
            {
                Employee_Tenant_Div.Visible = true; Other_Div.Visible = false;
                lbl_Employee_Tenant.Text = "اسم الموظف";

                //Fill Employee / Tenant DropDownList
                Helper.LoadDropDownList("SELECT * FROM employee", _sqlCon, Employee_Tenant_DropDownList, "Employee_Arabic_name", "Employee_Id");
                Employee_Tenant_DropDownList.Items.Insert(0, "إختر اسم الموظف ....");
            }
            else
            {
                Employee_Tenant_Div.Visible = false; Other_Div.Visible = true;
                Building_Or_unit_DropDownList.Enabled = true;
            }
        }

        protected void Building_Or_unit_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Complainte_Source_DropDownList.SelectedValue == "1" && Building_Or_unit_DropDownList.SelectedValue == "1")
            {
                _sqlCon.Open();
                string spName = "maintenance_request_site";
                DataTable dt = new DataTable();
                MySqlCommand sqlCmd = new MySqlCommand(spName, _sqlCon);
                MySqlDataAdapter sqlDa = new MySqlDataAdapter(sqlCmd);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ID", Employee_Tenant_DropDownList.SelectedValue);

                sqlDa.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Building_Name_DropDownList.DataSource = dt;
                    Building_Name_DropDownList.DataTextField = "Building_Arabic_Name";
                    Building_Name_DropDownList.DataValueField = "Building_Id";
                    Building_Name_DropDownList.DataBind();
                    Building_Name_DropDownList.Items.Insert(0, "إختر اسم البناء ....");
                }
                Unit_Div.Visible = false;
            }
            else if (Complainte_Source_DropDownList.SelectedValue == "1" && Building_Or_unit_DropDownList.SelectedValue == "2")
            {
                _sqlCon.Open();
                string spName = "maintenance_request_site";
                DataTable dt = new DataTable();
                MySqlCommand sqlCmd = new MySqlCommand(spName, _sqlCon);
                MySqlDataAdapter sqlDa = new MySqlDataAdapter(sqlCmd);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ID", Employee_Tenant_DropDownList.SelectedValue);

                sqlDa.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Building_Name_DropDownList.DataSource = dt;
                    Building_Name_DropDownList.DataTextField = "Building_Arabic_Name";
                    Building_Name_DropDownList.DataValueField = "Building_Id";
                    Building_Name_DropDownList.DataBind();
                    Building_Name_DropDownList.Items.Insert(0, "إختر اسم البناء ....");
                }
                Unit_Div.Visible = true;
            }
            else if (Complainte_Source_DropDownList.SelectedValue == "2" && Building_Or_unit_DropDownList.SelectedValue == "1")
            {
                //Fill Building DropDownList
                Helper.LoadDropDownList("SELECT * FROM building where Active ='1'", _sqlCon, Building_Name_DropDownList, "Building_Arabic_Name", "Building_Id");
                Building_Name_DropDownList.Items.Insert(0, "إختر اسم البناء ....");
                Unit_Div.Visible = false;
            }
            else
            {
                //Fill Building DropDownList
                Helper.LoadDropDownList("SELECT * FROM building where Active ='1'", _sqlCon, Building_Name_DropDownList, "Building_Arabic_Name", "Building_Id");
                Building_Name_DropDownList.Items.Insert(0, "إختر اسم البناء ....");
                Unit_Div.Visible = true;
            }
        }
        protected void Building_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Fill units Name DropDownList
            Helper.LoadDropDownList("SELECT * FROM units where Half !='1' and building_Building_Id = '" + Building_Name_DropDownList.SelectedValue + "'", _sqlCon, Units_DropDownList, "Unit_Number", "Unit_ID");
            Units_DropDownList.Items.Insert(0, "إختر الوحدة ....");
        }
        //******************  Report_Date ***************************************************
        protected void Report_Date_Calendar_SelectionChanged1(object sender, EventArgs e)
        {
            txt_Report_Date.Text = Report_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_Report_Date.Text != "")
            { Report_Date_divCalendar.Visible = false; ImageButton1.Visible = false; }
        }
        protected void Date_Chosee_Click(object sender, EventArgs e)
        { Report_Date_divCalendar.Visible = true; ImageButton1.Visible = true; }
        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        { Report_Date_divCalendar.Visible = false; ImageButton1.Visible = false; }
        //******************  Maintenance_Panel ***************************************************
        protected void Request_Type_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Request_Type_DropDownList.SelectedValue == "1") { Maintenance_Panel.Visible = true; } else { Maintenance_Panel.Visible = false; }
        }

        protected void Maintenance_Type_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Maintenance_Type_ID = Maintenance_Type_DropDownList.SelectedValue;
            //Fill Maintenance_Type_DropDownList
            Helper.LoadDropDownList("SELECT * FROM maintenance_categoty where Main_Categoty='" + Maintenance_Type_ID + "'",
                _sqlCon, Maintenance_SubType_DropDownList, "Categoty_AR", "Categoty_Id");
            Maintenance_SubType_DropDownList.Items.Insert(0, "إختر النوع الفرعي للصيانة ....");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "", "window.onload=function(){window.scrollTo(0,document.body.scrollHeight)};", true);
        }
        //******************  Start_Date ***************************************************
        protected void Start_Date_Calendar_SelectionChanged2(object sender, EventArgs e)
        {
            txt_Start_Date.Text = Start_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_Start_Date.Text != "")
            {
                Start_Date_Div.Visible = false;
                ImageButton2.Visible = false;
            }
        }

        protected void Start_Date_Chosee_Click(object sender, EventArgs e)
        {
            Start_Date_Div.Visible = true;
            ImageButton2.Visible = true;
        }

        protected void ImageButton2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Start_Date_Div.Visible = false;
            ImageButton2.Visible = false;
        }

        //******************  End_Date ***************************************************
        protected void End_Date_Chosee_Click(object sender, EventArgs e)
        {
            End_Date_Div.Visible = true;
            ImageButton3.Visible = true;
        }

        protected void ImageButton3_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            End_Date_Div.Visible = false;
            ImageButton3.Visible = false;
        }

        protected void End_Date_Calendar_SelectionChanged1(object sender, EventArgs e)
        {
            txt_End_Date.Text = End_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_End_Date.Text != "")
            {
                End_Date_Div.Visible = false;
                ImageButton3.Visible = false;
            }
        }

        protected void btn_Add_Request_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //Fill The Request Table With Data From View
                string addRequestQuery = "Insert Into complaint_report_request (" +
                                       "building_Building_Id , " +
                                       "Unit_Id , " +
                                       "source , " +
                                       "Tenant_ID  , " +
                                       "Employee_ID        , " +
                                       "Order_Classification       , " +
                                       "Report_Type         , " +
                                       "Report_Direction           , " +
                                       "urgent           , " +
                                       "Danger           , " +
                                       "priority_Danger   , " +
                                       "Date , " +
                                       "Report_Text , " +
                                       "Report_Description , " +
                                       "precaution , " +

                                       "Image_Befor_FileName , " +
                                       "Image_Befor_Path , " +
                                       "Image_After_FileName , " +
                                       "Image_After_Path , " +


                                       "Activ) " +
                                       "VALUES( " +
                                       "@building_Building_Id , " +
                                       "@Unit_Id , " +
                                       "@source , " +
                                       "@Tenant_ID  , " +
                                       "@Employee_ID        , " +
                                       "@Order_Classification       , " +
                                       "@Report_Type         , " +
                                       "@Report_Direction           , " +
                                       "@urgent           , " +
                                       "@Danger           , " +
                                       "@priority_Danger   , " +
                                        "@Date , " +
                                       "@Report_Text , " +
                                       "@Report_Description , " +
                                       "@precaution , " +


                                        "@Image_Befor_FileName , " +
                                       "@Image_Befor_Path , " +
                                       "@Image_After_FileName , " +
                                       "@Image_After_Path , " +


                                       "@Activ ) ";
                _sqlCon.Open();
                using (MySqlCommand addRequestCmd = new MySqlCommand(addRequestQuery, _sqlCon))
                {
                    string Priority = Order_priority_DropDownList.SelectedValue;
                    string Danger = Danger_Magnitude_DropDownList.SelectedValue;

                    //Fill The Database with All DropDownLists Items
                    if (Complainte_Source_DropDownList.SelectedValue == "1")
                    {
                        addRequestCmd.Parameters.AddWithValue("@source", Complainte_Source_DropDownList.SelectedItem.Text.Trim());
                    }
                    else if (Complainte_Source_DropDownList.SelectedValue == "2")
                    {
                        addRequestCmd.Parameters.AddWithValue("@source", Complainte_Source_DropDownList.SelectedItem.Text.Trim());
                    }
                    else
                    {
                        addRequestCmd.Parameters.AddWithValue("@source", txt_Souorce_Name.Text);
                    }
                    
                    if (Building_Or_unit_DropDownList.SelectedValue == "1")
                    {
                        addRequestCmd.Parameters.AddWithValue("@building_Building_Id", Building_Name_DropDownList.SelectedValue);
                        addRequestCmd.Parameters.AddWithValue("@Unit_Id", "");
                    }
                    else
                    {
                        addRequestCmd.Parameters.AddWithValue("@building_Building_Id", Building_Name_DropDownList.SelectedValue);
                        addRequestCmd.Parameters.AddWithValue("@Unit_Id", Units_DropDownList.SelectedValue);
                    }

                    addRequestCmd.Parameters.AddWithValue("@Order_Classification", Request_Classification_DropDownList.SelectedItem.Text.Trim());
                    addRequestCmd.Parameters.AddWithValue("@Report_Type", Request_Type_DropDownList.SelectedItem.Text.Trim());
                    addRequestCmd.Parameters.AddWithValue("@Report_Direction", Order_Direction_DropDownList.SelectedItem.Text.Trim());
                    addRequestCmd.Parameters.AddWithValue("@urgent", Order_priority_DropDownList.SelectedItem.Text.Trim());
                    addRequestCmd.Parameters.AddWithValue("@Danger", Danger_Magnitude_DropDownList.SelectedItem.Text.Trim());

                    if (Priority == "1" && Danger == "1")
                    { addRequestCmd.Parameters.AddWithValue("@priority_Danger", "1"); }
                    else if (Priority == "1" && Danger == "2")
                    { addRequestCmd.Parameters.AddWithValue("@priority_Danger", "1"); }
                    else if (Priority == "1" && Danger == "3")
                    { addRequestCmd.Parameters.AddWithValue("@priority_Danger", "2"); }


                    else if (Priority == "2" && Danger == "1")
                    { addRequestCmd.Parameters.AddWithValue("@priority_Danger", "1"); }
                    else if (Priority == "2" && Danger == "2")
                    { addRequestCmd.Parameters.AddWithValue("@priority_Danger", "2"); }
                    else if (Priority == "2" && Danger == "3")
                    { addRequestCmd.Parameters.AddWithValue("@priority_Danger", "3"); }


                    else if (Priority == "3" && Danger == "1")
                    { addRequestCmd.Parameters.AddWithValue("@priority_Danger", "2"); }
                    else if (Priority == "3" && Danger == "2")
                    { addRequestCmd.Parameters.AddWithValue("@priority_Danger", "3"); }
                    else if (Priority == "3" && Danger == "3")
                    { addRequestCmd.Parameters.AddWithValue("@priority_Danger", "3"); }


                    addRequestCmd.Parameters.AddWithValue("@Date", txt_Report_Date.Text);
                    addRequestCmd.Parameters.AddWithValue("@Report_Text", txt_Rreport_Text.Text);
                    addRequestCmd.Parameters.AddWithValue("@Report_Description", txt_Inspection_Report_Description.Text);
                    addRequestCmd.Parameters.AddWithValue("@precaution", txt_precaution.Text);
                    addRequestCmd.Parameters.AddWithValue("@Activ", Achievement_Verification_RadioButtonList.SelectedItem.Text.Trim());

                    if (Complainte_Source_DropDownList.SelectedValue == "1")
                    {
                        addRequestCmd.Parameters.AddWithValue("@Tenant_ID", Employee_Tenant_DropDownList.SelectedValue);
                        addRequestCmd.Parameters.AddWithValue("@Employee_ID", "");
                    }
                    else if (Complainte_Source_DropDownList.SelectedValue == "2")
                    {
                        addRequestCmd.Parameters.AddWithValue("@Tenant_ID", "");
                        addRequestCmd.Parameters.AddWithValue("@Employee_ID", Employee_Tenant_DropDownList.SelectedValue);
                    }
                    else
                    {
                        addRequestCmd.Parameters.AddWithValue("@Tenant_ID", "");
                        addRequestCmd.Parameters.AddWithValue("@Employee_ID", "");
                    }





                    if (Image_Befor_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(Image_Befor_FileUpload.PostedFile.FileName);
                        Image_Befor_FileUpload.PostedFile.SaveAs( Server.MapPath("/English/Main_Application/Maintenance_Image/") + fileName1);
                        addRequestCmd.Parameters.AddWithValue("@Image_Befor_FileName", fileName1);
                        addRequestCmd.Parameters.AddWithValue("@Image_Befor_Path", "/English/Main_Application/Maintenance_Image/" + fileName1);
                    }
                    else
                    {
                        addRequestCmd.Parameters.AddWithValue("@Image_Befor_FileName", "No File");
                        addRequestCmd.Parameters.AddWithValue("@Image_Befor_Path", "No File");
                    }



                    if (Image_After_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(Image_After_FileUpload.PostedFile.FileName);
                        Image_After_FileUpload.PostedFile.SaveAs(  Server.MapPath("/English/Main_Application/Maintenance_Image/") + fileName1);
                        addRequestCmd.Parameters.AddWithValue("@Image_After_FileName", fileName1);
                        addRequestCmd.Parameters.AddWithValue("@Image_After_Path", "/English/Main_Application/Maintenance_Image/" + fileName1);
                    }
                    else
                    {
                        addRequestCmd.Parameters.AddWithValue("@Image_After_FileName", "No File");
                        addRequestCmd.Parameters.AddWithValue("@Image_After_Path", "No File");
                    }


                    addRequestCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                //    Get The Added Request Id
                using (MySqlCommand Get_Request_ID = new MySqlCommand("SELECT MAX(Complaint_Report_Request_Id) AS LastInsertedID from complaint_report_request", _sqlCon))
                {
                    _sqlCon.Open();
                    Get_Request_ID.CommandType = CommandType.Text;
                    object Request_ID = Get_Request_ID.ExecuteScalar();
                    if (Request_ID != null)
                    {
                        Request_id.Text = Request_ID.ToString();
                    }

                    _sqlCon.Close();
                }
                //    insert The Cheques Information in Cheques Tabel in DB
                if (Request_Type_DropDownList.SelectedValue == "1")
                {
                    MySqlCommand com;
                    foreach (GridViewRow g1 in Maintenance_GridView.Rows)
                    {
                        _sqlCon.Open();
                        com = new
                            MySqlCommand("INSERT INTO maintenance_request (" +
                                        "Cost_Direction," +
                                        "Executing_Agency," +
                                        "Technical," +
                                        "Watcher," +
                                        "Activ," +
                                        "Cost," +
                                         "End_Date," +
                                         "Start_Date," +
                                         "assets_Assets_Id  , " +
                                         "maintenance_categoty_Categoty_Id  , " +
                                         "complaint_report_request_Complaint_Report_Request_Id)  " +
                                         "VALUES(" +
                                         "'" + g1.Cells[6].Text + "' ," +
                                         "'" + g1.Cells[7].Text + "' ," +
                                         "'" + Convert.ToInt32(g1.Cells[9].Text) + "' , " +
                                         "'" + Convert.ToInt32(g1.Cells[11].Text) + "' , " +
                                         "'" + g1.Cells[15].Text + "' ," +
                                         "'" + g1.Cells[14].Text + "' ," +
                                         "'" + g1.Cells[13].Text + "' ," +
                                         "'" + g1.Cells[12].Text + "' ," +
                                         "'" + Convert.ToInt32(g1.Cells[5].Text) + "' , " +
                                         "'" + Convert.ToInt32(g1.Cells[3].Text) + "' ," +
                                         "'" + Convert.ToInt32(Request_id.Text) + "')", _sqlCon);
                        com.ExecuteNonQuery();
                        _sqlCon.Close();
                    }
                }
                lbl_Success_Add_New_Maintenance.Text = "تمت الإضافة بنجاح";
            }

        }

        protected void btn_Back_To_Request_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("complaint_report_request_List.aspx");
        }

        protected void Maintenance_SubType_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Building_Or_unit_DropDownList.SelectedValue == "1")
            {
                string Building_ID = Building_Name_DropDownList.SelectedValue;
                string MST = Maintenance_SubType_DropDownList.SelectedValue;
                //Fill Asset_DropDownList
                Helper.LoadDropDownList("SELECT * FROM assets Where Building_ID = '" + Building_ID + "' And maintenance_categoty_Categoty_Id = '" + MST + "'", _sqlCon, Asset_DropDownList, "Assets_Arabic_Name", "Assets_Id");
                Asset_DropDownList.Items.Insert(0, "إختر الاصل ....");
            }
            else if (Building_Or_unit_DropDownList.SelectedValue == "2")
            {


                string Unitg_ID = Units_DropDownList.SelectedValue;
                string MST = Maintenance_SubType_DropDownList.SelectedValue;

                Label3.Text = Unitg_ID;
                Label4.Text = MST;

                //Fill Asset_DropDownList
                Helper.LoadDropDownList("SELECT * FROM assets Where Unit_Id = '" + Unitg_ID + "' And maintenance_categoty_Categoty_Id = '" + MST + "'", _sqlCon, Asset_DropDownList, "Assets_Arabic_Name", "Assets_Id");
                Asset_DropDownList.Items.Insert(0, "إختر الاصل ....");
            }
            ClientScript.RegisterClientScriptBlock(this.GetType(), "", "window.onload=function(){window.scrollTo(0,document.body.scrollHeight)};", true);
        }

        protected void Maintenance_GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = ViewState["Customers"] as DataTable;
            dt.Rows[index].Delete();
            ViewState["Customers"] = dt;
            BindGrid();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "", "window.onload=function(){window.scrollTo(0,document.body.scrollHeight)};", true);
        }

        protected void Employee_Tenant_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Building_Or_unit_DropDownList.Enabled = true;
        }

        protected void Asset_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "", "window.onload=function(){window.scrollTo(0,document.body.scrollHeight)};", true);
            _sqlCon.Open();
            string maintenance_request_Id = Asset_DropDownList.SelectedValue;
            using (MySqlCommand maintenance_requestDetailsCmd = new MySqlCommand("Asset_Detail", _sqlCon))
            {
                maintenance_requestDetailsCmd.CommandType = CommandType.StoredProcedure;
                maintenance_requestDetailsCmd.Parameters.AddWithValue("@Id", maintenance_request_Id);
                using (MySqlDataAdapter maintenance_requestDetailsSda = new MySqlDataAdapter(maintenance_requestDetailsCmd))
                {
                    DataTable maintenance_requestDetailsDt = new DataTable();
                    maintenance_requestDetailsSda.Fill(maintenance_requestDetailsDt);
                    if (maintenance_requestDetailsDt.Rows[0]["Contractor_Waranty_Period"].ToString() == "" && maintenance_requestDetailsDt.Rows[0]["Waranty_Period"].ToString() == "")
                    {
                        Maintenance_Guarantor_DropDownList.Items.Insert(0, "إختر  ....");
                    }
                    else if (maintenance_requestDetailsDt.Rows[0]["Contractor_Waranty_Period"].ToString() != "" && maintenance_requestDetailsDt.Rows[0]["Waranty_Period"].ToString() == "")
                    {
                        DateTime Today = DateTime.Now;
                        DateTime Purchase_Date = Convert.ToDateTime(maintenance_requestDetailsDt.Rows[0]["Purchase_Date"].ToString());
                        int Contractor_Waranty_Period = Convert.ToInt32(maintenance_requestDetailsDt.Rows[0]["Contractor_Waranty_Period"].ToString());
                        int difference_between_dates = (int)(Today - Purchase_Date).TotalDays;
                        int Remaining_Day = Contractor_Waranty_Period - difference_between_dates;
                        if (Remaining_Day > 0)
                        {
                            Maintenance_Guarantor_DropDownList.SelectedValue = "1";
                            Maintenance_Guarantor_DropDownList.Enabled = false;
                        }
                        else
                        {
                            Maintenance_Guarantor_DropDownList.Items.Insert(0, "إختر  ....");
                        }
                    }
                    else if (maintenance_requestDetailsDt.Rows[0]["Contractor_Waranty_Period"].ToString() == "" && maintenance_requestDetailsDt.Rows[0]["Waranty_Period"].ToString() != "")
                    {
                        DateTime Today = DateTime.Now;
                        DateTime Waranty_Start_Date = Convert.ToDateTime(maintenance_requestDetailsDt.Rows[0]["Waranty_Start_Date"].ToString());
                        int Waranty_Period = Convert.ToInt32(maintenance_requestDetailsDt.Rows[0]["Waranty_Period"].ToString());
                        int difference_between_dates = (int)(Today - Waranty_Start_Date).TotalDays;
                        int Remaining_Day = Waranty_Period - difference_between_dates;
                        if (Remaining_Day > 0)
                        {
                            Maintenance_Guarantor_DropDownList.SelectedValue = "2";
                            Maintenance_Guarantor_DropDownList.Enabled = false;
                        }
                        else
                        {
                            Maintenance_Guarantor_DropDownList.Items.Insert(0, "إختر  ....");
                        }
                    }
                    else
                    {
                        DateTime Today = DateTime.Now;
                        DateTime Purchase_Date = Convert.ToDateTime(maintenance_requestDetailsDt.Rows[0]["Purchase_Date"].ToString());
                        int Contractor_Waranty_Period = Convert.ToInt32(maintenance_requestDetailsDt.Rows[0]["Contractor_Waranty_Period"].ToString());
                        int difference_between_dates = (int)(Today - Purchase_Date).TotalDays;
                        int Remaining_Day = Contractor_Waranty_Period - difference_between_dates;
                        if (Remaining_Day > 0)
                        {
                            Maintenance_Guarantor_DropDownList.SelectedValue = "1";
                            Maintenance_Guarantor_DropDownList.Enabled = false;
                        }
                        else
                        {
                            DateTime Waranty_Start_Date = Convert.ToDateTime(maintenance_requestDetailsDt.Rows[0]["Waranty_Start_Date"].ToString());
                            int Waranty_Period = Convert.ToInt32(maintenance_requestDetailsDt.Rows[0]["Waranty_Period"].ToString());
                            int difference_between_Dates = (int)(Today - Waranty_Start_Date).TotalDays;
                            int Remaining_Days = Waranty_Period - difference_between_Dates;
                            if (Remaining_Days > 0)
                            {
                                Maintenance_Guarantor_DropDownList.SelectedValue = "2";
                                Maintenance_Guarantor_DropDownList.Enabled = false;
                            }
                            else
                            {
                                Maintenance_Guarantor_DropDownList.Items.Insert(0, "إختر  ....");
                            }
                        }
                    }
                }
            }
            _sqlCon.Close();
        }
    }
}