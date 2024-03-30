using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Edit_complaint_report_request : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Asset_Management", 0, "R");
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Asset_Management", 2, "E");
                Utilities.Roles.Delete_permission_With_Reason(_sqlCon, Session["Role"].ToString(), "Asset_Management", Delete_Request, Delete_Div);
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!this.IsPostBack)
            {
                BindGrid_Contract_Cheque_List();



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
                        txt_Dtl_Employee_Name.Text = "تم التعديل من قبل السيد : " + get_Employee_DataTable.Rows[0]["Users_Ar_First_Name"].ToString()
                    + " " + get_Employee_DataTable.Rows[0]["Users_Ar_Last_Name"].ToString();
                    }
                }
                else { Response.Redirect("Log_In.aspx"); }
                _sqlCon.Close();

                //---------------------------------------------------------------------------------------------------------------------------------

                //Fill Building_Name_DropDownList
                Helper.LoadDropDownList("SELECT * FROM building", _sqlCon, Building_Name_DropDownList, "Building_Arabic_Name", "Building_Id");
                Building_Name_DropDownList.Items.Insert(0, "إختر اسم البناء ....");

                //Fill Employee / Tenant DropDownList
                Helper.LoadDropDownList("SELECT * FROM units", _sqlCon, Units_DropDownList, "Unit_Number", "Unit_ID");
                Units_DropDownList.Items.Insert(0, "إختر الوحدة ....");

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

                //*************** Get The Data Of Requst From Database *****************************************************************************************************************
                string RequstId = Request.QueryString["Id"];
                DataTable getRequstDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getRequstCmd = new MySqlCommand("SELECT * FROM complaint_report_request WHERE Complaint_Report_Request_Id = @ID", _sqlCon);
                MySqlDataAdapter getRequstDa = new MySqlDataAdapter(getRequstCmd);
                getRequstCmd.Parameters.AddWithValue("@ID", RequstId);
                getRequstDa.Fill(getRequstDt);
                if (getRequstDt.Rows.Count > 0)
                {
                    if (getRequstDt.Rows[0]["Report_Type"].ToString() == "صيانة") { Maintenance_Panel.Visible = true; } else { Maintenance_Panel.Visible = false; }
                    if (getRequstDt.Rows[0]["Unit_Id"].ToString() != "")
                    {
                        Unit_Div.Visible = true;
                        Building_Or_unit_DropDownList.SelectedValue = "2";
                    }
                    else
                    {
                        Unit_Div.Visible = false;
                        Building_Or_unit_DropDownList.SelectedValue = "1";
                    }

                    if (getRequstDt.Rows[0]["source"].ToString() == "عميل") 
                    {
                        Complainte_Source_DropDownList.SelectedValue = "1";
                        Employee_Tenant_Div.Visible=true; Other_Div.Visible=false;   
                    } 
                    else if (getRequstDt.Rows[0]["source"].ToString() == "رقابة")
                    {
                        Complainte_Source_DropDownList.SelectedValue = "2";
                        Employee_Tenant_Div.Visible = true; Other_Div.Visible = false;
                    }
                    else
                    {
                        txt_Souorce_Name.Text = getRequstDt.Rows[0]["source"].ToString();
                        Employee_Tenant_Div.Visible = false; Other_Div.Visible = true;
                    }


                    if (getRequstDt.Rows[0]["Order_Classification"].ToString() == "بلاغ") { Request_Classification_DropDownList.SelectedValue = "1"; } else { Request_Classification_DropDownList.SelectedValue = "2"; }

                    if (getRequstDt.Rows[0]["Report_Type"].ToString() == "صيانة") { Request_Type_DropDownList.SelectedValue = "1"; }
                    else if (getRequstDt.Rows[0]["Report_Type"].ToString() == "نظافة") { Request_Type_DropDownList.SelectedValue = "2"; }
                    else { Request_Type_DropDownList.SelectedValue = "3"; }

                    if (getRequstDt.Rows[0]["Report_Direction"].ToString() == "الرقابة") { Order_Direction_DropDownList.SelectedValue = "1"; } else { Order_Direction_DropDownList.SelectedValue = "2"; }


                    if (getRequstDt.Rows[0]["urgent"].ToString() == "إزعاج عابر") { Order_priority_DropDownList.SelectedValue = "3"; }
                    else if (getRequstDt.Rows[0]["urgent"].ToString() == "إزعاج مؤقت") { Order_priority_DropDownList.SelectedValue = "2"; }
                    else { Order_priority_DropDownList.SelectedValue = "1"; }


                    if (getRequstDt.Rows[0]["Danger"].ToString() == "خطورة قليلة الإحتمالية") { Danger_Magnitude_DropDownList.SelectedValue = "3"; }
                    else if (getRequstDt.Rows[0]["Danger"].ToString() == "خطورة على الممتلكات") { Danger_Magnitude_DropDownList.SelectedValue = "2"; }
                    else { Danger_Magnitude_DropDownList.SelectedValue = "1"; }

                    if (getRequstDt.Rows[0]["Activ"].ToString() == "معلق") { Achievement_Verification_RadioButtonList.SelectedValue = "1"; }
                    else if (getRequstDt.Rows[0]["Activ"].ToString() == "تم أنجازه") { Achievement_Verification_RadioButtonList.SelectedValue = "2"; }
                    else { Achievement_Verification_RadioButtonList.SelectedValue = "3"; }

                    Employee_Tenant_DropDownList.SelectedValue = getRequstDt.Rows[0]["Tenant_ID"].ToString();
                    Employee_Tenant_DropDownList.SelectedValue = getRequstDt.Rows[0]["Employee_ID"].ToString();
                    Building_Name_DropDownList.SelectedValue = getRequstDt.Rows[0]["building_Building_Id"].ToString();
                    Units_DropDownList.SelectedValue = getRequstDt.Rows[0]["Unit_Id"].ToString();

                    txt_Report_Date.Text = getRequstDt.Rows[0]["Date"].ToString();
                    txt_Rreport_Text.Text = getRequstDt.Rows[0]["Report_Text"].ToString();
                    txt_Inspection_Report_Description.Text = getRequstDt.Rows[0]["Report_Description"].ToString();
                    txt_precaution.Text = getRequstDt.Rows[0]["precaution"].ToString();



                    Image_Befor.Text = getRequstDt.Rows[0]["Image_Befor_FileName"].ToString();
                    Image_Befor_Pathe.Text = getRequstDt.Rows[0]["Image_Befor_Path"].ToString();

                    Image_After.Text = getRequstDt.Rows[0]["Image_After_FileName"].ToString();
                    Image_After_Pathe.Text = getRequstDt.Rows[0]["Image_After_Path"].ToString();




                    if (getRequstDt.Rows[0]["Image_Befor_FileName"].ToString() != "") { Image_Befor_Div.Visible = true; }
                    else { Image_Befor_Div.Visible = false; }

                    if (getRequstDt.Rows[0]["Image_After_FileName"].ToString() != "") { Image_After_Div.Visible = true; }
                    else { Image_After_Div.Visible = false; }





                    lbl_Link_Image_Befor.Text = getRequstDt.Rows[0]["Image_Befor_FileName"].ToString();
                    Link_Image_Befor.HRef = getRequstDt.Rows[0]["Image_Befor_Path"].ToString();
                    Link_Image_Befor.Target = "_blank";


                    lbl_Link_Image_After.Text = getRequstDt.Rows[0]["Image_After_FileName"].ToString();
                    Link_Image_After.HRef = getRequstDt.Rows[0]["Image_After_Path"].ToString();
                    Link_Image_After.Target = "_blank";

                    


                }
            }
        }
        protected void Complainte_Source_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Complainte_Source_DropDownList.SelectedValue == "1")
            {
                Employee_Tenant_Div.Visible = true; Other_Div.Visible = false;
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
                Helper.LoadDropDownList("SELECT * FROM building", _sqlCon, Building_Name_DropDownList, "Building_Arabic_Name", "Building_Id");
                Building_Name_DropDownList.Items.Insert(0, "إختر اسم البناء ....");
                Unit_Div.Visible = false;
            }
            else
            {
                //Fill Building DropDownList
                Helper.LoadDropDownList("SELECT * FROM building", _sqlCon, Building_Name_DropDownList, "Building_Arabic_Name", "Building_Id");
                Building_Name_DropDownList.Items.Insert(0, "إختر اسم البناء ....");
                Unit_Div.Visible = true;
            }
        }
        protected void Building_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Complainte_Source_DropDownList.SelectedValue == "1" && Building_Or_unit_DropDownList.SelectedValue == "2")
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
                    Units_DropDownList.DataSource = dt;
                    Units_DropDownList.DataTextField = "Unit_Number";
                    Units_DropDownList.DataValueField = "units_Unit_ID";
                    Units_DropDownList.DataBind();
                    Units_DropDownList.Items.Insert(0, "إختر الوحدة ....");
                }
            }
            else if (Complainte_Source_DropDownList.SelectedValue == "2" && Building_Or_unit_DropDownList.SelectedValue == "2")
            {
                //Fill units Name DropDownList
                Helper.LoadDropDownList(
                    "SELECT * FROM units where building_Building_Id = '" + Building_Name_DropDownList.SelectedValue + "'",
                    _sqlCon, Units_DropDownList, "Unit_Number", "Unit_ID");
                Units_DropDownList.Items.Insert(0, "إختر الوحدة ....");
            }
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



                //Fill Asset_DropDownList
                Helper.LoadDropDownList("SELECT * FROM assets Where Unit_Id = '" + Unitg_ID + "' And maintenance_categoty_Categoty_Id = '" + MST + "'", _sqlCon, Asset_DropDownList, "Assets_Arabic_Name", "Assets_Id");
                Asset_DropDownList.Items.Insert(0, "إختر الاصل ....");
            }
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
        private void BindGrid_Contract_Cheque_List()
        {
            _sqlCon.Open();
            string ContractId = Request.QueryString["Id"];
            using (MySqlCommand Contract_ChequesCmd = new MySqlCommand("maintenance_request_List", _sqlCon))
            {
                Contract_ChequesCmd.CommandType = CommandType.StoredProcedure;
                Contract_ChequesCmd.Parameters.AddWithValue("@Id", ContractId);
                MySqlDataAdapter Contract_ChequesSda = new MySqlDataAdapter(Contract_ChequesCmd);

                DataTable Contract_ChequesDt = new DataTable();
                Contract_ChequesSda.Fill(Contract_ChequesDt);
                Contract_ChequesCmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                Contract_ChequesSda.Fill(dt);
                Maintenance_List.DataSource = dt;
                Maintenance_List.DataBind();
            }
            _sqlCon.Close();
        }


        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && Maintenance_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddl_Activ = (DropDownList)e.Row.FindControl("Activ_DropDownList");

                if (DataBinder.Eval(e.Row.DataItem, "Activ").ToString() == "معلق")
                { string selected_Activ = "1"; ddl_Activ.Items.FindByValue(selected_Activ).Selected = true; }
                else if (DataBinder.Eval(e.Row.DataItem, "Activ").ToString() == "قيد التنفيذ")
                { string selected_Activ = "2"; ddl_Activ.Items.FindByValue(selected_Activ).Selected = true; }
                else { string selected_Activ = "3"; ddl_Activ.Items.FindByValue(selected_Activ).Selected = true; }
            }

            if (e.Row.RowType == DataControlRowType.DataRow && Maintenance_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddl_Categoty_AR = (DropDownList)e.Row.FindControl("Categoty_AR_DropDownList");
                string Categoty_Ar_query = "SELECT * FROM maintenance_categoty where Main_Categoty != 0";
                using (MySqlDataAdapter sda = new MySqlDataAdapter(Categoty_Ar_query, _sqlCon))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        ddl_Categoty_AR.DataSource = dt;
                        ddl_Categoty_AR.DataTextField = "Categoty_AR";
                        ddl_Categoty_AR.DataValueField = "Categoty_Id";
                        ddl_Categoty_AR.DataBind();
                        string selected_Categoty_AR = DataBinder.Eval(e.Row.DataItem, "maintenance_categoty_Categoty_Id").ToString();
                        ddl_Categoty_AR.Items.FindByValue(selected_Categoty_AR).Selected = true;
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow && Maintenance_List.EditIndex == e.Row.RowIndex)
            {
                string Main_Place; string Building_ID; string Unit_Id;
                Main_Place = Building_Or_unit_DropDownList.SelectedValue;
                if (Main_Place == "2")
                {
                    Building_ID = Building_Name_DropDownList.SelectedValue;
                    DropDownList ddl_Assets_Arabic_Name = (DropDownList)e.Row.FindControl("Assets_Arabic_Name_DropDownList");
                    string Assets_Arabic_Name_query = "SELECT * FROM assets where Building_ID = '" + Building_ID + "'";
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(Assets_Arabic_Name_query, _sqlCon))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            ddl_Assets_Arabic_Name.DataSource = dt;
                            ddl_Assets_Arabic_Name.DataTextField = "Assets_Arabic_Name";
                            ddl_Assets_Arabic_Name.DataValueField = "Assets_Id";
                            ddl_Assets_Arabic_Name.DataBind();
                            string selected_Assets_Arabic_Name = DataBinder.Eval(e.Row.DataItem, "assets_Assets_Id").ToString();
                            ddl_Assets_Arabic_Name.Items.FindByValue(selected_Assets_Arabic_Name).Selected = true;
                        }
                    }
                }
                else if (Main_Place == "3")
                {
                    Unit_Id = Units_DropDownList.SelectedValue;
                    DropDownList ddl_Assets_Arabic_Name = (DropDownList)e.Row.FindControl("Assets_Arabic_Name_DropDownList");
                    string Assets_Arabic_Name_query = "SELECT * FROM assets where Unit_Id = '" + Unit_Id + "'";
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(Assets_Arabic_Name_query, _sqlCon))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            ddl_Assets_Arabic_Name.DataSource = dt;
                            ddl_Assets_Arabic_Name.DataTextField = "Assets_Arabic_Name";
                            ddl_Assets_Arabic_Name.DataValueField = "Assets_Id";
                            ddl_Assets_Arabic_Name.DataBind();
                            string selected_Assets_Arabic_Name = DataBinder.Eval(e.Row.DataItem, "assets_Assets_Id").ToString();
                            ddl_Assets_Arabic_Name.Items.FindByValue(selected_Assets_Arabic_Name).Selected = true;
                        }
                    }
                }


            }

            if (e.Row.RowType == DataControlRowType.DataRow && Maintenance_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddl_Cost_Direction = (DropDownList)e.Row.FindControl("Cost_Direction_DropDownList");

                if (DataBinder.Eval(e.Row.DataItem, "Cost_Direction").ToString() == "المقاول")
                { string selected_Activ = "1"; ddl_Cost_Direction.Items.FindByValue(selected_Activ).Selected = true; }
                else if (DataBinder.Eval(e.Row.DataItem, "Cost_Direction").ToString() == "الموّرد")
                { string selected_Activ = "2"; ddl_Cost_Direction.Items.FindByValue(selected_Activ).Selected = true; }
                else if (DataBinder.Eval(e.Row.DataItem, "Cost_Direction").ToString() == "المالك")
                { string selected_Activ = "3"; ddl_Cost_Direction.Items.FindByValue(selected_Activ).Selected = true; }
                else { string selected_Activ = "4"; ddl_Cost_Direction.Items.FindByValue(selected_Activ).Selected = true; }
            }

            if (e.Row.RowType == DataControlRowType.DataRow && Maintenance_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddl_Executing_Agency = (DropDownList)e.Row.FindControl("Executing_Agency_DropDownList");

                if (DataBinder.Eval(e.Row.DataItem, "Executing_Agency").ToString() == "فريق الصيانة")
                { string selected_Activ = "1"; ddl_Executing_Agency.Items.FindByValue(selected_Activ).Selected = true; }
                else if (DataBinder.Eval(e.Row.DataItem, "Executing_Agency").ToString() == "المقاول")
                { string selected_Activ = "2"; ddl_Executing_Agency.Items.FindByValue(selected_Activ).Selected = true; }
                else { string selected_Activ = "3"; ddl_Executing_Agency.Items.FindByValue(selected_Activ).Selected = true; }
            }

            if (e.Row.RowType == DataControlRowType.DataRow && Maintenance_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddl_T_echnical = (DropDownList)e.Row.FindControl("T_echnical_DropDownList");
                string T_echnical_query = "SELECT * FROM employee ";
                using (MySqlDataAdapter sda = new MySqlDataAdapter(T_echnical_query, _sqlCon))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        ddl_T_echnical.DataSource = dt;
                        ddl_T_echnical.DataTextField = "Employee_Arabic_name";
                        ddl_T_echnical.DataValueField = "Employee_Id";
                        ddl_T_echnical.DataBind();
                        string selected_T_echnical = DataBinder.Eval(e.Row.DataItem, "Technical").ToString();
                        ddl_T_echnical.Items.FindByValue(selected_T_echnical).Selected = true;
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow && Maintenance_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddl_W_atcher_DropDownList = (DropDownList)e.Row.FindControl("W_atcher_DropDownList");
                string W_atcherl_query = "SELECT * FROM employee ";
                using (MySqlDataAdapter sda = new MySqlDataAdapter(W_atcherl_query, _sqlCon))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        ddl_W_atcher_DropDownList.DataSource = dt;
                        ddl_W_atcher_DropDownList.DataTextField = "Employee_Arabic_name";
                        ddl_W_atcher_DropDownList.DataValueField = "Employee_Id";
                        ddl_W_atcher_DropDownList.DataBind();
                        string selected_W_atcherl = DataBinder.Eval(e.Row.DataItem, "Watcher").ToString();
                        ddl_W_atcher_DropDownList.Items.FindByValue(selected_W_atcherl).Selected = true;
                    }
                }
            }

        }

        protected void EditCustomer(object sender, GridViewEditEventArgs e)
        { Maintenance_List.EditIndex = e.NewEditIndex; this.BindGrid_Contract_Cheque_List(); }
        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        { Maintenance_List.EditIndex = -1; this.BindGrid_Contract_Cheque_List(); }

        protected void UpdateCustomer(object sender, GridViewUpdateEventArgs e)
        {
            string Activ_DropDownList = (Maintenance_List.Rows[e.RowIndex].FindControl("Activ_DropDownList") as DropDownList).SelectedItem.Text.Trim();
            string Categoty_AR_DropDownList = (Maintenance_List.Rows[e.RowIndex].FindControl("Categoty_AR_DropDownList") as DropDownList).SelectedItem.Value;
            string Assets_Arabic_Name_DropDownList = (Maintenance_List.Rows[e.RowIndex].FindControl("Assets_Arabic_Name_DropDownList") as DropDownList).SelectedItem.Value;
            string Cost_Direction_DropDownList = (Maintenance_List.Rows[e.RowIndex].FindControl("Cost_Direction_DropDownList") as DropDownList).SelectedItem.Text.Trim();
            string Executing_Agency_DropDownList = (Maintenance_List.Rows[e.RowIndex].FindControl("Executing_Agency_DropDownList") as DropDownList).SelectedItem.Text.Trim();
            string T_echnical_DropDownList = (Maintenance_List.Rows[e.RowIndex].FindControl("T_echnical_DropDownList") as DropDownList).SelectedItem.Value;
            string W_atcher_DropDownList = (Maintenance_List.Rows[e.RowIndex].FindControl("W_atcher_DropDownList") as DropDownList).SelectedItem.Value;
            TextBox txt_Cost = (Maintenance_List.Rows[e.RowIndex].FindControl("txt_Cost") as TextBox);

            Calendar Start_Date_Calendar = (Maintenance_List.Rows[e.RowIndex]).FindControl("Start_Date_Calendar") as Calendar;
            string calendar1 = Start_Date_Calendar.SelectedDate.ToString("dd/MM/yyyy");
            Label lbl_Start_Date = (Maintenance_List.Rows[e.RowIndex].FindControl("lbl_Start_Date") as Label);

            Calendar End_Date_Calendar = (Maintenance_List.Rows[e.RowIndex]).FindControl("End_Date_Calendar") as Calendar;
            string calendar2 = Start_Date_Calendar.SelectedDate.ToString("dd/MM/yyyy");
            Label lbl_End_Date = (Maintenance_List.Rows[e.RowIndex].FindControl("lbl_End_Date") as Label);


            string Maintenance_Id = Maintenance_List.DataKeys[e.RowIndex].Value.ToString();

            string query = "UPDATE maintenance_request SET" +
                            " maintenance_categoty_Categoty_Id = @maintenance_categoty_Categoty_Id ," +
                            " assets_Assets_Id = @assets_Assets_Id ," +
                            " Start_Date = @Start_Date ," +
                            " End_Date = @End_Date ," +
                            " Cost = @Cost ," +
                            " Activ = @Activ ," +
                            " Cost_Direction = @Cost_Direction ," +
                            " Executing_Agency = @Executing_Agency ," +
                            " Technical = @Technical ," +
                            " Watcher = @Watcher " +
                            "WHERE Maintenance_Request_ID = @Maintenance_Request_ID";
            using (MySqlCommand cmd = new MySqlCommand(query, _sqlCon))
            {
                cmd.Parameters.AddWithValue("@Maintenance_Request_ID", Maintenance_Id);


                cmd.Parameters.AddWithValue("@maintenance_categoty_Categoty_Id", Categoty_AR_DropDownList);
                cmd.Parameters.AddWithValue("@assets_Assets_Id", Assets_Arabic_Name_DropDownList);
                cmd.Parameters.AddWithValue("@Cost", txt_Cost.Text);
                cmd.Parameters.AddWithValue("@Activ", Activ_DropDownList);
                cmd.Parameters.AddWithValue("@Cost_Direction", Cost_Direction_DropDownList);
                cmd.Parameters.AddWithValue("@Executing_Agency", Executing_Agency_DropDownList);
                cmd.Parameters.AddWithValue("@Technical", T_echnical_DropDownList);
                cmd.Parameters.AddWithValue("@Watcher", W_atcher_DropDownList);

                if (calendar1 != "01/01/0001") { cmd.Parameters.AddWithValue("@Start_Date", calendar1); }
                else { cmd.Parameters.AddWithValue("@Start_Date", lbl_Start_Date.Text); }

                if (calendar2 != "01/01/0001") { cmd.Parameters.AddWithValue("@End_Date", calendar2); }
                else { cmd.Parameters.AddWithValue("@End_Date", lbl_End_Date.Text); }


                _sqlCon.Open();
                cmd.ExecuteNonQuery();
                _sqlCon.Close();
                //Response.Redirect(Request.RawUrl);
                Maintenance_List.EditIndex = -1; this.BindGrid_Contract_Cheque_List();
            }
        }

        protected void Maintenance_List_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(Maintenance_List.DataKeys[e.RowIndex].Values["Maintenance_Request_ID"].ToString());
            _sqlCon.Open();
            MySqlCommand cmd = new MySqlCommand("delete from maintenance_request where Maintenance_Request_ID =@Maintenance_Request_ID", _sqlCon);
            cmd.Parameters.AddWithValue("Cheques_Id", id);
            cmd.ExecuteNonQuery();
            _sqlCon.Close();
            BindGrid_Contract_Cheque_List();
        }

        protected void btn_Add_Request_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (Page.IsValid)
                {
                    string RequestId = Request.QueryString["Id"];
                    //Fill The Request Table With Data From View
                    string UpdateRequestQuery = "UPDATE complaint_report_request SET " +
                                                   "source = @source ," +
                                                   "Tenant_ID = @Tenant_ID, " +
                                                   "Employee_ID = @Employee_ID, " +
                                                   "Order_Classification = @Order_Classification , " +
                                                   "Report_Type = @Report_Type, " +
                                                   "Report_Direction = @Report_Direction , " +
                                                   "priority_Danger = @priority_Danger , " +
                                                   "Date = @Date , " +
                                                   "Report_Text = @Report_Text , " +
                                                   "Report_Description = @Report_Description , " +
                                                   "Activ = @Activ , " +
                                                   "urgent = @urgent ," +
                                                   "Danger = @Danger ," +
                                                   "building_Building_Id = @building_Building_Id ," +
                                                   "Unit_Id = @Unit_Id ," +


                                                   "Image_Befor_FileName = @Image_Befor_FileName , " +
                                                   "Image_Befor_Path = @Image_Befor_Path , " +
                                                   "Image_After_FileName = @Image_After_FileName , " +
                                                   "Image_After_Path = @Image_After_Path " +



                                                   "WHERE Complaint_Report_Request_Id = @ID ";
                    _sqlCon.Open();
                    using (MySqlCommand UpdateRequestCmd = new MySqlCommand(UpdateRequestQuery, _sqlCon))
                    {
                        UpdateRequestCmd.Parameters.AddWithValue("@ID", RequestId);
                        string Priority = Order_priority_DropDownList.SelectedValue;
                        string Danger = Danger_Magnitude_DropDownList.SelectedValue;

                        //Fill The Database with All DropDownLists Items



                        //Fill The Database with All DropDownLists Items
                        if (Complainte_Source_DropDownList.SelectedValue == "1")
                        {
                            UpdateRequestCmd.Parameters.AddWithValue("@source", Complainte_Source_DropDownList.SelectedItem.Text.Trim());
                        }
                        else if (Complainte_Source_DropDownList.SelectedValue == "2")
                        {
                            UpdateRequestCmd.Parameters.AddWithValue("@source", Complainte_Source_DropDownList.SelectedItem.Text.Trim());
                        }
                        else
                        {
                            UpdateRequestCmd.Parameters.AddWithValue("@source", txt_Souorce_Name.Text);
                        }




                        if (Building_Or_unit_DropDownList.SelectedValue == "1")
                        {
                            UpdateRequestCmd.Parameters.AddWithValue("@building_Building_Id", Building_Name_DropDownList.SelectedValue);
                            UpdateRequestCmd.Parameters.AddWithValue("@Unit_Id", "");
                        }
                        else
                        {
                            UpdateRequestCmd.Parameters.AddWithValue("@building_Building_Id", Building_Name_DropDownList.SelectedValue);
                            UpdateRequestCmd.Parameters.AddWithValue("@Unit_Id", Units_DropDownList.SelectedValue);
                        }

                        UpdateRequestCmd.Parameters.AddWithValue("@Order_Classification", Request_Classification_DropDownList.SelectedItem.Text.Trim());
                        UpdateRequestCmd.Parameters.AddWithValue("@Report_Type", Request_Type_DropDownList.SelectedItem.Text.Trim());
                        UpdateRequestCmd.Parameters.AddWithValue("@Report_Direction", Order_Direction_DropDownList.SelectedItem.Text.Trim());
                        UpdateRequestCmd.Parameters.AddWithValue("@urgent", Order_priority_DropDownList.SelectedItem.Text.Trim());
                        UpdateRequestCmd.Parameters.AddWithValue("@Danger", Danger_Magnitude_DropDownList.SelectedItem.Text.Trim());
                        if (Priority == "1" && Danger == "1")
                        { UpdateRequestCmd.Parameters.AddWithValue("@priority_Danger", "1"); }
                        else if (Priority == "1" && Danger == "2")
                        { UpdateRequestCmd.Parameters.AddWithValue("@priority_Danger", "1"); }
                        else if (Priority == "1" && Danger == "3")
                        { UpdateRequestCmd.Parameters.AddWithValue("@priority_Danger", "2"); }


                        else if (Priority == "2" && Danger == "1")
                        { UpdateRequestCmd.Parameters.AddWithValue("@priority_Danger", "1"); }
                        else if (Priority == "2" && Danger == "2")
                        { UpdateRequestCmd.Parameters.AddWithValue("@priority_Danger", "2"); }
                        else if (Priority == "2" && Danger == "3")
                        { UpdateRequestCmd.Parameters.AddWithValue("@priority_Danger", "3"); }


                        else if (Priority == "3" && Danger == "1")
                        { UpdateRequestCmd.Parameters.AddWithValue("@priority_Danger", "2"); }
                        else if (Priority == "3" && Danger == "2")
                        { UpdateRequestCmd.Parameters.AddWithValue("@priority_Danger", "3"); }
                        else if (Priority == "3" && Danger == "3")
                        { UpdateRequestCmd.Parameters.AddWithValue("@priority_Danger", "3"); }


                        UpdateRequestCmd.Parameters.AddWithValue("@Date", txt_Report_Date.Text);
                        UpdateRequestCmd.Parameters.AddWithValue("@Report_Text", txt_Rreport_Text.Text);
                        UpdateRequestCmd.Parameters.AddWithValue("@Report_Description", txt_Inspection_Report_Description.Text);
                        UpdateRequestCmd.Parameters.AddWithValue("@precaution", txt_precaution.Text);
                        UpdateRequestCmd.Parameters.AddWithValue("@Activ", Achievement_Verification_RadioButtonList.SelectedItem.Text.Trim());

                        if (Complainte_Source_DropDownList.SelectedValue == "1")
                        {
                            UpdateRequestCmd.Parameters.AddWithValue("@Tenant_ID", Employee_Tenant_DropDownList.SelectedValue);
                            UpdateRequestCmd.Parameters.AddWithValue("@Employee_ID", "");
                        }
                        else if (Complainte_Source_DropDownList.SelectedValue == "2")
                        {
                            UpdateRequestCmd.Parameters.AddWithValue("@Tenant_ID", "");
                            UpdateRequestCmd.Parameters.AddWithValue("@Employee_ID", Employee_Tenant_DropDownList.SelectedValue);
                        }
                        else
                        {
                            UpdateRequestCmd.Parameters.AddWithValue("@Tenant_ID", "");
                            UpdateRequestCmd.Parameters.AddWithValue("@Employee_ID", "");
                        }




                        if (Image_Befor_FileUpload.HasFile)
                        {
                            string fileName1 = Path.GetFileName(Image_Befor_FileUpload.PostedFile.FileName);
                            Image_Befor_FileUpload.PostedFile.SaveAs( Server.MapPath("/English/Main_Application/Maintenance_Image/") + fileName1);
                            UpdateRequestCmd.Parameters.AddWithValue("@Image_Befor_FileName", fileName1);
                            UpdateRequestCmd.Parameters.AddWithValue("@Image_Befor_Path", "/English/Main_Application/Maintenance_Image/" + fileName1);
                        }
                        else
                        {
                            UpdateRequestCmd.Parameters.AddWithValue("@Image_Befor_FileName", Image_Befor.Text);
                            UpdateRequestCmd.Parameters.AddWithValue("@Image_Befor_Path", Image_Befor_Pathe.Text);
                        }

                        //**********************************************************************************************************************************************************
                        if (Image_After_FileUpload.HasFile)
                        {
                            string fileName1 = Path.GetFileName(Image_After_FileUpload.PostedFile.FileName);
                            Image_After_FileUpload.PostedFile.SaveAs( Server.MapPath("/English/Main_Application/Maintenance_Image/") + fileName1);
                            UpdateRequestCmd.Parameters.AddWithValue("@Image_After_FileName", fileName1);
                            UpdateRequestCmd.Parameters.AddWithValue("@Image_After_Path", "/English/Main_Application/Maintenance_Image/" + fileName1);
                        }
                        else
                        {
                            UpdateRequestCmd.Parameters.AddWithValue("@Image_After_FileName", Image_After.Text);
                            UpdateRequestCmd.Parameters.AddWithValue("@Image_After_Path", Image_After_Pathe.Text);
                        }


                        UpdateRequestCmd.ExecuteNonQuery();
                        _sqlCon.Close();
                    }
                    lbl_Success_Add_New_complaint_repor_Request.Text = "تم التعديل بنجاح";
                }
            }
        }

        protected void btn_Edit_Request_Click(object sender, EventArgs e)
        {
            Response.Redirect("complaint_report_request_List.aspx");
        }

        protected void Add_Maintenane_Click(object sender, ImageClickEventArgs e)
        {
            string complaint_reportId = Request.QueryString["Id"];
            string Add_maintenance_In_Edit_omplaint_repor =
                                                "Insert Into maintenance_request (" +
                                                "complaint_report_request_Complaint_Report_Request_Id , " +
                                                "maintenance_categoty_Categoty_Id  , " +
                                                "assets_Assets_Id        , " +
                                                "Start_Date ," +
                                                "End_Date       , " +
                                                "Cost         , " +
                                                "Activ , " +
                                                "Cost_Direction , " +
                                                "Executing_Agency , " +
                                                "Technical , " +
                                                "Watcher ) " +
                                                "VALUES( " +
                                                "@complaint_report_request_Complaint_Report_Request_Id , " +
                                                "@maintenance_categoty_Categoty_Id  , " +
                                                "@assets_Assets_Id        , " +
                                                "@Start_Date ," +
                                                "@End_Date       , " +
                                                "@Cost         , " +
                                                "@Activ , " +
                                                "@Cost_Direction , " +
                                                "@Executing_Agency , " +
                                                "@Technical , " +
                                                "@Watcher ) ";
            _sqlCon.Open();
            using (MySqlCommand Add_Maintenance_In_Edit_complaint_repor_Cmd = new MySqlCommand(Add_maintenance_In_Edit_omplaint_repor, _sqlCon))
            {
                Add_Maintenance_In_Edit_complaint_repor_Cmd.Parameters.AddWithValue("@complaint_report_request_Complaint_Report_Request_Id", complaint_reportId);
                Add_Maintenance_In_Edit_complaint_repor_Cmd.Parameters.AddWithValue("@maintenance_categoty_Categoty_Id", Maintenance_SubType_DropDownList.SelectedValue);
                Add_Maintenance_In_Edit_complaint_repor_Cmd.Parameters.AddWithValue("@assets_Assets_Id", Asset_DropDownList.SelectedValue);
                Add_Maintenance_In_Edit_complaint_repor_Cmd.Parameters.AddWithValue("@Start_Date", txt_Start_Date.Text);
                Add_Maintenance_In_Edit_complaint_repor_Cmd.Parameters.AddWithValue("@End_Date", txt_End_Date.Text);
                Add_Maintenance_In_Edit_complaint_repor_Cmd.Parameters.AddWithValue("@Cost", txt_Cost.Text);
                Add_Maintenance_In_Edit_complaint_repor_Cmd.Parameters.AddWithValue("@Activ", Maintenance_Status_DropDownList.SelectedItem.Text.Trim());
                Add_Maintenance_In_Edit_complaint_repor_Cmd.Parameters.AddWithValue("@Cost_Direction", Maintenance_Guarantor_DropDownList.SelectedItem.Text.Trim());
                Add_Maintenance_In_Edit_complaint_repor_Cmd.Parameters.AddWithValue("@Executing_Agency", Executing_Agency_DropDownList.SelectedItem.Text.Trim());
                Add_Maintenance_In_Edit_complaint_repor_Cmd.Parameters.AddWithValue("@Technical", Technical_DropDownList.SelectedValue);
                Add_Maintenance_In_Edit_complaint_repor_Cmd.Parameters.AddWithValue("@Watcher", Observer_DropDownList.SelectedValue);

                Add_Maintenance_In_Edit_complaint_repor_Cmd.ExecuteNonQuery();
                _sqlCon.Close();
            }
            BindGrid_Contract_Cheque_List();

            ClientScript.RegisterClientScriptBlock(this.GetType(), "", "window.onload=function(){window.scrollTo(0,document.body.scrollHeight)};", true);
        }

        protected void Delete_Request_Click(object sender, EventArgs e)
        {
            Delete_Div.Visible= true;
            try
            {
                string id = Request.QueryString["Id"];
                _sqlCon.Open();
                string quary1 = "DELETE FROM complaint_report_request WHERE Complaint_Report_Request_Id=@ID ";
                MySqlCommand mySqlCmd = new MySqlCommand(quary1, _sqlCon);
                mySqlCmd.Parameters.AddWithValue("@ID", id);
                mySqlCmd.ExecuteNonQuery();
                _sqlCon.Close();

                Response.Redirect("complaint_report_request_List.aspx");
            }
            catch
            {
                Response.Write( @"<script language='javascript'>alert('لايمكن حذف هذا الطلب لأنو يحتوي على طلبات صيانة')</script>");
            }
        }

        protected void Btn_Remove_Link_Image_Befor_Click(object sender, ImageClickEventArgs e)
        {
            string Uint_Id = Request.QueryString["ID"];

            string Remove_Unit_Att_Query = "UPDATE complaint_report_request SET " +
                                            " Image_Befor_FileName=@Image_Befor_FileName ," +
                                            " Image_Befor_Path=@Image_Befor_Path  " +
                                            "WHERE Complaint_Report_Request_Id=@ID";
            _sqlCon.Open();
            MySqlCommand Remove_Unit_Att_Cmd = new MySqlCommand(Remove_Unit_Att_Query, _sqlCon);
            Remove_Unit_Att_Cmd.Parameters.AddWithValue("@ID", Uint_Id);
            Remove_Unit_Att_Cmd.Parameters.AddWithValue("@Image_Befor_FileName", "");
            Remove_Unit_Att_Cmd.Parameters.AddWithValue("@Image_Befor_Path", "");
            Remove_Unit_Att_Cmd.ExecuteNonQuery();
            _sqlCon.Close();

            Response.Redirect("Edit_complaint_report_request.aspx?Id=" + Uint_Id);
        }

        protected void Btn_Remove_Link_Image_After_Click(object sender, ImageClickEventArgs e)
        {
            string Uint_Id = Request.QueryString["ID"];

            string Remove_Unit_Att_Query = "UPDATE complaint_report_request SET " +
                                            " Image_After_FileName=@Image_After_FileName ," +
                                            " Image_After_Path=@Image_After_Path  " +
                                            "WHERE Complaint_Report_Request_Id=@ID";
            _sqlCon.Open();
            MySqlCommand Remove_Unit_Att_Cmd = new MySqlCommand(Remove_Unit_Att_Query, _sqlCon);
            Remove_Unit_Att_Cmd.Parameters.AddWithValue("@ID", Uint_Id);
            Remove_Unit_Att_Cmd.Parameters.AddWithValue("@Image_After_FileName", "");
            Remove_Unit_Att_Cmd.Parameters.AddWithValue("@Image_After_Path", "");
            Remove_Unit_Att_Cmd.ExecuteNonQuery();
            _sqlCon.Close();

            Response.Redirect("Edit_complaint_report_request.aspx?Id=" + Uint_Id);
        }
    }
}