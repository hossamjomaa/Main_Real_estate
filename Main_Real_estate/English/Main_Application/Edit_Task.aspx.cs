using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Edit_Task : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Task_Management", 0, "R");
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Task_Management", 2, "E");
                Utilities.Roles.Delete_permission_With_Reason(_sqlCon, Session["Role"].ToString(), "Task_Management", Delete_Task, Delete_Reason);
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!this.IsPostBack)
                {
                    //    //Fill department DropDownList
                    Helper.LoadDropDownList("SELECT * FROM department", _sqlCon, Department_DropDownList, "Department_Arabic_Name", "Department_Id");
                    Department_DropDownList.Items.Insert(0, "إختر القسم المطلوب ....");

                    //    //Fill Employee Name DropDownList
                    Helper.LoadDropDownList("SELECT * FROM employee ", _sqlCon, Employee_Name_DropDownList, "Employee_Arabic_name", "Employee_Id");
                    Employee_Name_DropDownList.Items.Insert(0, "إختر اسم الموظف ....");

                    // **************************** Get The Task Info *********************************************************************************

                    string _Task_Id = Request.QueryString["Id"];
                    DataTable get_Task_Dt = new DataTable();
                    _sqlCon.Open();
                    MySqlCommand get_Task_Cmd = new MySqlCommand("SELECT * FROM task_management WHERE Task_Management_ID = @ID", _sqlCon);
                    MySqlDataAdapter get_Task_Da = new MySqlDataAdapter(get_Task_Cmd);
                    get_Task_Cmd.Parameters.AddWithValue("@ID", _Task_Id);
                    get_Task_Da.Fill(get_Task_Dt);
                    if (get_Task_Dt.Rows.Count > 0)
                    {
                        txt_Task_Type.Text = get_Task_Dt.Rows[0]["Task_Type"].ToString();
                        Department_DropDownList.SelectedValue = get_Task_Dt.Rows[0]["Department_Id"].ToString();
                        Employee_Name_DropDownList.SelectedValue = get_Task_Dt.Rows[0]["Employee_Id"].ToString();
                        txt_Task_Discreption.Text = get_Task_Dt.Rows[0]["Task_Descrioption"].ToString();
                        txt_Start_Date.Text = get_Task_Dt.Rows[0]["Start_date"].ToString();
                        txt_End_Date.Text = get_Task_Dt.Rows[0]["End_Date"].ToString();
                        priority_DropDownList.SelectedValue = get_Task_Dt.Rows[0]["Task_Priority"].ToString();
                    }

                    _sqlCon.Close();
                }
            
            
        }

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
        protected void Department_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    //Fill Employee Name DropDownList
            Helper.LoadDropDownList("SELECT * FROM employee where department_Department_Id = '" + Department_DropDownList.SelectedValue + "'",
            _sqlCon, Employee_Name_DropDownList, "Employee_Arabic_name", "Employee_Id");
            Employee_Name_DropDownList.Items.Insert(0, "إختر اسم الموظف ....");
        }
        protected void btn_Back_To_Task_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Task_List.aspx");
        }

        protected void btn_Edit_Task_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string _Task_Id = Request.QueryString["Id"];
                string update_Task_Quary = "UPDATE task_management SET " +
                                           "Task_Type =@Task_Type , " +
                                           "Department_Id=@Department_Id , " +
                                           "Employee_Id=@Employee_Id , " +
                                           "Task_Descrioption=@Task_Descrioption , " +
                                           "Task_Priority=@Task_Priority , " +
                                           "Task_Priority_Word=@Task_Priority_Word , " +
                                           "Start_date=@Start_date , " +
                                           "End_Date=@End_Date " +
                                           "WHERE Task_Management_ID=@ID ";
                _sqlCon.Open();
                MySqlCommand update_Task_Cmd = new MySqlCommand(update_Task_Quary, _sqlCon);
                update_Task_Cmd.Parameters.AddWithValue("@ID", _Task_Id);
                update_Task_Cmd.Parameters.AddWithValue("@Task_Type", txt_Task_Type.Text);
                update_Task_Cmd.Parameters.AddWithValue("@Task_Descrioption", txt_Task_Discreption.Text);
                update_Task_Cmd.Parameters.AddWithValue("@Start_date", txt_Start_Date.Text);
                update_Task_Cmd.Parameters.AddWithValue("@End_Date", txt_End_Date.Text);
                update_Task_Cmd.Parameters.AddWithValue("@Task_Priority", priority_DropDownList.SelectedValue);
                update_Task_Cmd.Parameters.AddWithValue("@Task_Priority_Word", priority_DropDownList.SelectedItem.Text.Trim());



                if (Department_DropDownList.SelectedItem.Text == "إختر القسم المطلوب ....") { update_Task_Cmd.Parameters.AddWithValue("@Department_Id", "0"); }
                else { update_Task_Cmd.Parameters.AddWithValue("@Department_Id", Department_DropDownList.SelectedValue); }

                if (Employee_Name_DropDownList.SelectedItem.Text == "إختر اسم الموظف ....") { update_Task_Cmd.Parameters.AddWithValue("@Employee_Id", "0"); }
                else { update_Task_Cmd.Parameters.AddWithValue("@Employee_Id", Employee_Name_DropDownList.SelectedValue); }

                update_Task_Cmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_Task.Text = "تم التعديل بنجاح";
            }
        }

        protected void Delete_Task_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["Id"];

            try
            {
                _sqlCon.Open();



                MySqlCommand cmd = new MySqlCommand("delete from task_part where Task_Id =@Task_Id", _sqlCon);
                cmd.Parameters.AddWithValue("Task_Id", id);
                cmd.ExecuteNonQuery();


                string quary1 = "DELETE FROM task_management WHERE Task_Management_ID=@ID ";
                MySqlCommand mySqlCmd = new MySqlCommand(quary1, _sqlCon);
                mySqlCmd.Parameters.AddWithValue("@ID", id);
                mySqlCmd.ExecuteNonQuery();





                _sqlCon.Close();
                Response.Redirect("Task_List.aspx");
            }
            catch
            {
                Response.Write(
                    @"<script language='javascript'>alert('لا يمكن حذف هذه المهمة')</script>");
            }
        }
    }
}