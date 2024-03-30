using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class complaint_report_request_Details : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Asset_Management", 0, "R");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            

            _sqlCon.Open();
            string complaint_report_requestId = Request.QueryString["Id"];
            using (MySqlCommand complaint_report_requestDetailsCmd = new MySqlCommand("complaint_report_request_Details", _sqlCon))
            {
                complaint_report_requestDetailsCmd.CommandType = CommandType.StoredProcedure;
                complaint_report_requestDetailsCmd.Parameters.AddWithValue("@Id", complaint_report_requestId);
                using (MySqlDataAdapter complaint_report_requestDetailsSda = new MySqlDataAdapter(complaint_report_requestDetailsCmd))
                {
                    DataTable complaint_report_requestDetailsDt = new DataTable();
                    complaint_report_requestDetailsSda.Fill(complaint_report_requestDetailsDt);
                    lbl_source.Text = complaint_report_requestDetailsDt.Rows[0]["source"].ToString();
                    lbl_Building_Name.Text = complaint_report_requestDetailsDt.Rows[0]["Building_Arabic_Name"].ToString();
                    if (complaint_report_requestDetailsDt.Rows[0]["Unit_Number"].ToString() != "")
                    {
                        lbl_Unit_Number.Text = "/ " + complaint_report_requestDetailsDt.Rows[0]["Unit_Number"].ToString();
                    }
                    lbl_Date.Text = complaint_report_requestDetailsDt.Rows[0]["Date"].ToString();
                    lbl_Order_Classification.Text = complaint_report_requestDetailsDt.Rows[0]["Order_Classification"].ToString();
                    lbl_Report_Type.Text = complaint_report_requestDetailsDt.Rows[0]["Report_Type"].ToString();
                    lbl_Report_Direction.Text = complaint_report_requestDetailsDt.Rows[0]["Report_Direction"].ToString();
                    lbl_Report_Text.Text = complaint_report_requestDetailsDt.Rows[0]["Report_Text"].ToString();
                    lbl_Report_Description.Text = complaint_report_requestDetailsDt.Rows[0]["Report_Description"].ToString();
                    lbl_precaution.Text = complaint_report_requestDetailsDt.Rows[0]["precaution"].ToString();
                    lbl_Activ.Text = complaint_report_requestDetailsDt.Rows[0]["Activ"].ToString();
                    lbl_Priority.Text = complaint_report_requestDetailsDt.Rows[0]["urgent"].ToString();
                    lbl_Danger.Text = complaint_report_requestDetailsDt.Rows[0]["Danger"].ToString();
                    if (complaint_report_requestDetailsDt.Rows[0]["priority_Danger"].ToString() == "1")
                    { lbl_Priority_Resut.Text = "من الدرجة الأولى"; lbl_Priority_Resut.ForeColor = System.Drawing.Color.Red; lbl_Priority_Resut.BackColor = System.Drawing.Color.Black; }
                    else if (complaint_report_requestDetailsDt.Rows[0]["priority_Danger"].ToString() == "2")
                    { lbl_Priority_Resut.Text = "من الدرجة الثانية"; lbl_Priority_Resut.ForeColor = System.Drawing.Color.Yellow; lbl_Priority_Resut.BackColor = System.Drawing.Color.Black; }
                    else { lbl_Priority_Resut.Text = "من الدرجة الثالثة"; lbl_Priority_Resut.ForeColor = System.Drawing.Color.Green; lbl_Priority_Resut.BackColor = System.Drawing.Color.Black; }
                    if (complaint_report_requestDetailsDt.Rows[0]["Report_Type"].ToString() == "صيانة") { Maintenance_div.Visible = true; } else { Maintenance_div.Visible = false; }




                    if (complaint_report_requestDetailsDt.Rows[0]["Image_Befor_Path"].ToString() == "No File")
                    {
                        Image_Befor.Visible = false;
                    }
                    else
                    {
                        Image_Befor.ImageUrl = complaint_report_requestDetailsDt.Rows[0]["Image_Befor_Path"].ToString();
                    }

                    //***********************************************************************************
                    if (complaint_report_requestDetailsDt.Rows[0]["Image_After_Path"].ToString() == "No File")
                    {
                        Image_After.Visible = false;
                    }
                    else
                    {
                        Image_After.ImageUrl = complaint_report_requestDetailsDt.Rows[0]["Image_After_Path"].ToString();
                    }
                }
                _sqlCon.Close();
            }
            BindData();








        }
        protected void BindData(string sortExpression = null)
        {
            string complaint_reportId = Request.QueryString["Id"];
            try
            {
                _sqlCon.Open();
                using (MySqlCommand Maintenance_RequestDetailsCmd = new MySqlCommand("maintenance_request_List", _sqlCon))
                {
                    Maintenance_RequestDetailsCmd.CommandType = CommandType.StoredProcedure;
                    Maintenance_RequestDetailsCmd.Parameters.AddWithValue("@Id", complaint_reportId);
                    MySqlDataAdapter Maintenance_RequestDetailsSda = new MySqlDataAdapter(Maintenance_RequestDetailsCmd);

                    DataTable Maintenance_RequestDetailsDt = new DataTable();
                    Maintenance_RequestDetailsSda.Fill(Maintenance_RequestDetailsDt);
                    Maintenance_RequestDetailsCmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    Maintenance_RequestDetailsSda.Fill(dt);
                    Maintenance_Request_Liist.DataSource = dt;
                    Maintenance_Request_Liist.DataBind();
                    _sqlCon.Close();
                }
            }
            catch { Response.Write(@"<script language='javascript'>alert('OOPS!!! The Maintenance List Cannt Display')</script>"); }
        }

        protected void Delete_Maintenance_Request(object sender, EventArgs e)
        {
            try
            {
                string id = (sender as LinkButton).CommandArgument;
                _sqlCon.Open();
                string quary1 = "DELETE FROM maintenance_request WHERE Maintenance_Request_ID=@ID ";
                MySqlCommand mySqlCmd = new MySqlCommand(quary1, _sqlCon);
                mySqlCmd.Parameters.AddWithValue("@ID", id);
                mySqlCmd.ExecuteNonQuery();
                _sqlCon.Close();

                Response.Redirect(Request.RawUrl);
            }
            catch
            {
                Response.Write(
                    @"<script language='javascript'>alert('عذراً ... لايمكن حذف هذا الطلب')</script>");
            }
        }
        protected void Details_Maintenance_Request(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "", "window.onload=function(){window.scrollTo(0,document.body.scrollHeight)};", true);
            maintenance_request_Details_Div.Visible = true;
            _sqlCon.Open();
            string maintenance_request_Id = (sender as LinkButton).CommandArgument;
            using (MySqlCommand maintenance_requestDetailsCmd = new MySqlCommand("maintenance_request_Details", _sqlCon))
            {
                maintenance_requestDetailsCmd.CommandType = CommandType.StoredProcedure;
                maintenance_requestDetailsCmd.Parameters.AddWithValue("@Id", maintenance_request_Id);
                using (MySqlDataAdapter maintenance_requestDetailsSda = new MySqlDataAdapter(maintenance_requestDetailsCmd))
                {
                    DataTable maintenance_requestDetailsDt = new DataTable();
                    maintenance_requestDetailsSda.Fill(maintenance_requestDetailsDt);


                    lbl_Cost_Direction.Text = maintenance_requestDetailsDt.Rows[0]["Cost_Direction"].ToString();
                    lbl_Executing_Agency.Text = maintenance_requestDetailsDt.Rows[0]["Executing_Agency"].ToString();

                    lbl_Technical.Text = maintenance_requestDetailsDt.Rows[0]["T_echnical"].ToString();
                    lbl_Watcher.Text = maintenance_requestDetailsDt.Rows[0]["W_atcher"].ToString();

                    lbl_Asset.Text = maintenance_requestDetailsDt.Rows[0]["Assets_Arabic_Name"].ToString();

                    if (maintenance_requestDetailsDt.Rows[0]["Contractor_Waranty_Period"].ToString() == "" && maintenance_requestDetailsDt.Rows[0]["Waranty_Period"].ToString() == "")
                    {
                        lbl_Waranty.Text = "غير ساري";
                        lbl_Waranty_Direction.Text = "غير محددة";
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
                            lbl_Waranty.Text = "ساري";
                            lbl_Waranty_Direction.Text = "المقاول";
                        }
                        else
                        {
                            lbl_Waranty.Text = "غير ساري";
                            lbl_Waranty_Direction.Text = "غير محدد";
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
                            lbl_Waranty.Text = "ساري";
                            lbl_Waranty_Direction.Text = "المورد";
                        }
                        else
                        {
                            lbl_Waranty.Text = "غير ساري ";
                            lbl_Waranty_Direction.Text = "غير محدد";
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
                            lbl_Waranty.Text = "ساري";
                            lbl_Waranty_Direction.Text = "المقاول";
                        }
                        else
                        {
                            DateTime Waranty_Start_Date = Convert.ToDateTime(maintenance_requestDetailsDt.Rows[0]["Waranty_Start_Date"].ToString());
                            int Waranty_Period = Convert.ToInt32(maintenance_requestDetailsDt.Rows[0]["Waranty_Period"].ToString());
                            int difference_between_Dates = (int)(Today - Waranty_Start_Date).TotalDays;
                            int Remaining_Days = Waranty_Period - difference_between_Dates;


                            if (Remaining_Days > 0)
                            {
                                lbl_Waranty.Text = "ساري";
                                lbl_Waranty_Direction.Text = "المورد";
                            }
                            else
                            {
                                lbl_Waranty.Text = "غير ساري ";
                                lbl_Waranty_Direction.Text = "غير محدد";
                            }
                        }
                    }
                }
            }
            _sqlCon.Close();
        }

        protected void btn_Close_Maintenance_Details_Click(object sender, EventArgs e)
        {
            maintenance_request_Details_Div.Visible = false;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "", "window.onload=function(){window.scrollTo(0,document.body.scrollHeight)};", true);
        }

        protected void btn_Back_To_complaint_report_request_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("complaint_report_request_List.aspx");
        }

        protected void Image_Befor_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(Image_Befor.ImageUrl);
        }

        protected void Image_After_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(Image_After.ImageUrl);
        }
    }
}
