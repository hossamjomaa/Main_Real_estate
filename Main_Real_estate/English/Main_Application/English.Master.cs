using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English
{
    public partial class English : System.Web.UI.MasterPage
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Users_Name"] != null)
            {
                Utilities.Roles.Master_Page_permission(_sqlCon, Session["Role"].ToString(),
                Ownership_Div, Contract_Div, Tenant_Div, complaintreport_Div, Income_Expensess_Div,
                Financial_Statements_Div, Markting, Task_Managements_Div, lists_Div, Sitting_Div);
                Label1.Text = Session["Users_Name"].ToString();
                if (Session["Photo_Path"].ToString() != "") { user_Photo.Src = Session["Photo_Path"].ToString(); }
                else { user_Photo.Src = "Main_Image/user.jpg"; }

                BindData();
                Tenanat_Notification_BindData();
            }
            else { Response.Redirect("~/English/Main_Application/Log_In.aspx"); }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/English/Main_Application/Log_In.aspx");
        }
        //************************************** إشعارات العملاء **************************************************
        protected void Tenanat_Notification_BindData(string sortExpression = null)
        {
            // *********************************** جلب الإشعارات ضمن مربع الإشعارات ***************************************************************
            string get_Notification_Quari =
            "SELECT TN.* , T.Tenants_Arabic_Name , " +
            "(SELECT IF(TN.From_Who = '', TN.From_Who, CONCAT('تمت مشاهدته من قبل', TN.From_Who)))From_Whoo " +
            " FROM tenant_notification TN  " +
            "left join tenants T on (TN.Tenant_ID = T.Tenants_ID) ";

            MySqlCommand get_Notification_Cmd = new MySqlCommand(get_Notification_Quari, _sqlCon);
            MySqlDataAdapter get_Notification_Dt = new MySqlDataAdapter(get_Notification_Cmd);
            get_Notification_Cmd.Connection = _sqlCon;
            _sqlCon.Open();
            get_Notification_Dt.SelectCommand = get_Notification_Cmd;
            DataTable get_Notification_DataTable = new DataTable();
            get_Notification_Dt.Fill(get_Notification_DataTable);

            T_Notification_Repeater.DataSource = get_Notification_DataTable;
            T_Notification_Repeater.DataBind();

            _sqlCon.Close();

            // *********************************** جلب عدد الغشعارات ضمن مربع الإشعارات ***************************************************************

            string get_Notification_Count_Quari = "select * from tenant_notification where Seen = '0' ";

            MySqlCommand get_Notification_Count_Cmd = new MySqlCommand(get_Notification_Count_Quari, _sqlCon);
            MySqlDataAdapter get_Notification_Count_Dt = new MySqlDataAdapter(get_Notification_Count_Cmd);
            get_Notification_Count_Cmd.Connection = _sqlCon;
            _sqlCon.Open();
            get_Notification_Count_Dt.SelectCommand = get_Notification_Count_Cmd;
            DataTable get_Notification_Count_DataTable = new DataTable();
            get_Notification_Count_Dt.Fill(get_Notification_Count_DataTable);
            if (get_Notification_Count_DataTable.Rows.Count > 0)
            {
                T_Notification_Span.Visible = true;
                T_Notification_NO.Text = Convert.ToString(get_Notification_Count_DataTable.Rows.Count);
            }
            else
            {
                T_Notification_Span.Visible = false;
                T_Notification_NO.Text = "";
            }
            _sqlCon.Close();
        }
        protected void T_Notification_Link_Click(object sender, EventArgs e)
        {
            string updateNotification_ActivQuary = "UPDATE tenant_notification SET " +
                                                    "Seen=@Seen , From_Who=@From_Who ";
            _sqlCon.Open();
            MySqlCommand updateNotification_ActivCmd = new MySqlCommand(updateNotification_ActivQuary, _sqlCon);
            updateNotification_ActivCmd.Parameters.AddWithValue("@Seen", "1");
            updateNotification_ActivCmd.Parameters.AddWithValue("@From_Who", Session["Users_Name"].ToString());
            updateNotification_ActivCmd.ExecuteNonQuery();
            _sqlCon.Close();


            Response.Redirect("complaint_report_request_List.aspx");
        }








        protected void BindData(string sortExpression = null)
        {
            //try
            //{

            // *********************************** جلب المهام ضمن مربع الإشعارات ***************************************************************
            string get_Task_Quari = "SELECT " +
                "TM.* , " +
                "D.Department_Arabic_Name ," +
                "E.Employee_Arabic_name " +
                "FROM task_management TM " +
                "left join department D on(TM.Department_Id = D.Department_Id) " +
                "left join employee E on(TM.Employee_Id = E.Employee_Id) where TM.Employee_Id = '" + Session["Employee_Id"].ToString() + "' ;";

            MySqlCommand get_Task_Cmd = new MySqlCommand(get_Task_Quari, _sqlCon);
            MySqlDataAdapter get_Task_Dt = new MySqlDataAdapter(get_Task_Cmd);
            get_Task_Cmd.Connection = _sqlCon;
            _sqlCon.Open();
            get_Task_Dt.SelectCommand = get_Task_Cmd;
            DataTable get_Task_DataTable = new DataTable();
            get_Task_Dt.Fill(get_Task_DataTable);

            Notification_Repeater.DataSource = get_Task_DataTable;
            Notification_Repeater.DataBind();

            _sqlCon.Close();

            // *********************************** جلب عدد المهام ضمن مربع الإشعارات ***************************************************************
            string get_Task_Count_Quari = "select * from task_management where Employee_Id = '" + Session["Employee_Id"].ToString() + "'and Notification_Activ =1";

            MySqlCommand get_Task_Count_Cmd = new MySqlCommand(get_Task_Count_Quari, _sqlCon);
            MySqlDataAdapter get_Task_Count_Dt = new MySqlDataAdapter(get_Task_Count_Cmd);
            get_Task_Count_Cmd.Connection = _sqlCon;
            _sqlCon.Open();
            get_Task_Count_Dt.SelectCommand = get_Task_Count_Cmd;
            DataTable get_Task_Count_DataTable = new DataTable();
            get_Task_Count_Dt.Fill(get_Task_Count_DataTable);
            if (get_Task_Count_DataTable.Rows.Count > 0)
            {

                Notification_Span.Visible = true;
                lbl_Notification_Numberl.Text = Convert.ToString(get_Task_Count_DataTable.Rows.Count);

            }
            else
            {
                Notification_Span.Visible = false;
                lbl_Notification_Numberl.Text = "";
            }
            _sqlCon.Close();
            //}
            //catch
            //{
            //    Response.Write(
            //        @"<script language='javascript'>alert('OOPS!!! Some Thing Wrong')</script>");
            //}
        }


        protected void LinkButton2_Click(object sender, EventArgs e)
        {


            string updateNotification_ActivQuary = "UPDATE task_management SET " +
                                                    "Notification_Activ=@Notification_Activ " +
                                                    " WHERE Employee_Id = '" + Session["Employee_Id"].ToString() + "' ";
            _sqlCon.Open();
            MySqlCommand updateNotification_ActivCmd = new MySqlCommand(updateNotification_ActivQuary, _sqlCon);
            updateNotification_ActivCmd.Parameters.AddWithValue("@Notification_Activ", "0");
            updateNotification_ActivCmd.ExecuteNonQuery();
            _sqlCon.Close();


            Response.Redirect("E_Task_List.aspx");
        }



        //************************************************************************************************************




    }
}