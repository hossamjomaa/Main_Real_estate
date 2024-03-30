using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Add_Task : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Task_Management", 0, "R");
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Task_Management", 1, "A");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!this.IsPostBack)
                {

                    txt_Start_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");

                    //    //Fill department DropDownList
                    Helper.LoadDropDownList("SELECT * FROM department", _sqlCon, Department_DropDownList, "Department_Arabic_Name", "Department_Id");
                    Department_DropDownList.Items.Insert(0, "إختر القسم المطلوب ....");

                    //    //Fill Employee Name DropDownList
                    Helper.LoadDropDownList("SELECT * FROM employee",  _sqlCon, Employee_Name_DropDownList, "Employee_Arabic_name", "Employee_Id");
                    Employee_Name_DropDownList.Items.Insert(0, "إختر اسم الموظف ....");
                }
           
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
        protected void btn_Back_To_Task_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Task_List.aspx");
        }

        protected void Department_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    //Fill Employee Name DropDownList
            Helper.LoadDropDownList("SELECT * FROM employee where department_Department_Id = '" + Department_DropDownList.SelectedValue + "'",
            _sqlCon, Employee_Name_DropDownList, "Employee_Arabic_name", "Employee_Id");
            Employee_Name_DropDownList.Items.Insert(0, "إختر اسم الموظف ....");
        }
        protected void btn_Add_Task_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addTaskQuary =
                    "Insert Into task_management " +
                    "(Task_Type ," +
                    "Department_Id," +
                    "Employee_Id," +
                    "Task_Descrioption," +
                    "Start_date," +
                    "End_Date," +
                    "Task_Status," +
                    "Task_Priority," +
                    "Task_Priority_Word," +
                    "Notification_Activ) " +
                    "VALUES" +
                    "(@Task_Type ," +
                    "@Department_Id," +
                    "@Employee_Id," +
                    "@Task_Descrioption," +
                    "@Start_date," +
                    "@End_Date," +
                    "@Task_Status," +
                    "@Task_Priority," +
                    "@Task_Priority_Word," +
                    "@Notification_Activ)";
                _sqlCon.Open();
                MySqlCommand addTaskCmd = new MySqlCommand(addTaskQuary, _sqlCon);
                addTaskCmd.Parameters.AddWithValue("@Task_Type", txt_Task_Type.Text);
                addTaskCmd.Parameters.AddWithValue("@Task_Descrioption", txt_Task_Discreption.Text);
                addTaskCmd.Parameters.AddWithValue("@Start_date", txt_Start_Date.Text);
                addTaskCmd.Parameters.AddWithValue("@End_Date", txt_End_Date.Text);
                addTaskCmd.Parameters.AddWithValue("@Task_Status", "معلقة");
                addTaskCmd.Parameters.AddWithValue("@Task_Priority", priority_DropDownList.SelectedValue);
                addTaskCmd.Parameters.AddWithValue("@Task_Priority_Word", priority_DropDownList.SelectedItem.Text.Trim());
                addTaskCmd.Parameters.AddWithValue("@Notification_Activ", "1");

                if (Department_DropDownList.SelectedItem.Text == "إختر القسم المطلوب ....") { addTaskCmd.Parameters.AddWithValue("@Department_Id", "");}
                else { addTaskCmd.Parameters.AddWithValue("@Department_Id", Department_DropDownList.SelectedValue); }

                if(Employee_Name_DropDownList.SelectedItem.Text== "إختر اسم الموظف ...." ){ addTaskCmd.Parameters.AddWithValue("@Employee_Id", ""); }
                else { addTaskCmd.Parameters.AddWithValue("@Employee_Id", Employee_Name_DropDownList.SelectedValue); }

                addTaskCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_Task.Text = "تمت الإضافة بنجاح";
                Response.Redirect("Task_list.aspx");


            }
        }
    }
}