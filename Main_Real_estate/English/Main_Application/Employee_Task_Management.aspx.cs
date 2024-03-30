using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Employee_Task_Management : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
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
                    { lbl_Employee.Text = get_Employee_DataTable.Rows[0]["Users_Ar_First_Name"].ToString() + " " + get_Employee_DataTable.Rows[0]["Users_Ar_Last_Name"] .ToString(); }
                }
                else  { Response.Redirect("Log_In.aspx");  }
                _sqlCon.Close();

                BindData(); 
            }
        }

        protected void Employee_Task_Management_GV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && Employee_Task_Management_GV.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddl_Status = (DropDownList)e.Row.FindControl("Task_Status_DropDownList");

                if (DataBinder.Eval(e.Row.DataItem, "Task_Status").ToString() == "معلقة")
                { string selected_Activ = "1"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }

                else if (DataBinder.Eval(e.Row.DataItem, "Task_Status").ToString() == "قيد التنفيذ")
                { string selected_Activ = "2"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }

                else { string selected_Activ = "3"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }
            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string lbl_Task_Status = ((Label)e.Row.FindControl("lbl_TaskStatus")).Text;
                if (lbl_Task_Status == "قيد التنفيذ")
                {
                    e.Row.BackColor = System.Drawing.Color.DeepSkyBlue;
                }
                else if (lbl_Task_Status == "منفذة")
                {
                    e.Row.BackColor = System.Drawing.Color.LightSeaGreen;
                }
                
            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string lbl_Task_Priority = ((Label)e.Row.FindControl("lbl_Task_Priority")).Text;
                string lbl_Task_Priority_Word = ((Label)e.Row.FindControl("lbl_Task_Priority_Word")).Text;
                Button But_Priority = (Button)e.Row.FindControl("But_Priority");





                if (lbl_Task_Priority == "1") { But_Priority.BackColor = Color.Red; ((Label)e.Row.FindControl("lbl_Task_Priority_Word")).ForeColor = Color.Red; }
                else if (lbl_Task_Priority == "2") { But_Priority.BackColor = Color.Orange; ((Label)e.Row.FindControl("lbl_Task_Priority_Word")).ForeColor = Color.Orange; }
                else if (lbl_Task_Priority == "3") { But_Priority.BackColor = Color.Yellow; ((Label)e.Row.FindControl("lbl_Task_Priority_Word")).ForeColor = Color.Yellow; }
                else if (lbl_Task_Priority == "4") { But_Priority.BackColor = Color.Green; ((Label)e.Row.FindControl("lbl_Task_Priority_Word")).ForeColor = Color.Green; }
                else if (lbl_Task_Priority == "5") { But_Priority.BackColor = Color.LightGreen; ((Label)e.Row.FindControl("lbl_Task_Priority_Word")).ForeColor = Color.LightGreen; }
                else if (lbl_Task_Priority == "6") { But_Priority.BackColor = Color.Blue; ((Label)e.Row.FindControl("lbl_Task_Priority_Word")).ForeColor = Color.Blue; }

            }
        }

        protected void Employee_Task_Management_GV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Employee_Task_Management_GV.EditIndex = e.NewEditIndex; this.BindData();
        }

        

        protected void Employee_Task_Management_GV_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Employee_Task_Management_GV.EditIndex = -1; this.BindData();
        }


        protected void Employee_Task_Management_GV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string Task_Management_ID = (Employee_Task_Management_GV.Rows[e.RowIndex].FindControl("lbl_Task_Id") as Label).Text;
            string End_Date = (Employee_Task_Management_GV.Rows[e.RowIndex].FindControl("lbl_End_Date") as Label).Text;
            string Actual_End_Date = (Employee_Task_Management_GV.Rows[e.RowIndex].FindControl("lbl_Actual_End_Date") as Label).Text;
            string Date_Now = DateTime.Now.ToString("dd/MM/yyyy");
            //DateTime Date_Now = DateTime.Now("dd/mm/yyyy");
            //int result = DateTime.Compare(end_date, Date_Now);


            string Task_Status_DropDownList = (Employee_Task_Management_GV.Rows[e.RowIndex].FindControl("Task_Status_DropDownList") as DropDownList).SelectedValue;




                string update_Task_Status_Quary = "UPDATE task_management SET" +
                                                  " Task_Status=@Task_Status , " +
                                                  " Actual_End_Date=@Actual_End_Date  " +
                                                  "WHERE Task_Management_ID = '" + Task_Management_ID + "'";
                _sqlCon.Open();
                MySqlCommand update_Task_Status_Cmd = new MySqlCommand(update_Task_Status_Quary, _sqlCon);
                if (Task_Status_DropDownList == "1")
                {
                    update_Task_Status_Cmd.Parameters.AddWithValue("@Task_Status", "معلقة");
                    update_Task_Status_Cmd.Parameters.AddWithValue("@Actual_End_Date", "");
                }
                else if(Task_Status_DropDownList == "2")
                {
                    update_Task_Status_Cmd.Parameters.AddWithValue("@Task_Status", "قيد التنفيذ");
                    update_Task_Status_Cmd.Parameters.AddWithValue("@Actual_End_Date", "");
                }
                else
                {
                    update_Task_Status_Cmd.Parameters.AddWithValue("@Task_Status", "منفذة");
                    update_Task_Status_Cmd.Parameters.AddWithValue("@Actual_End_Date", Date_Now);
                }
                update_Task_Status_Cmd.ExecuteNonQuery();
                _sqlCon.Close();
                Employee_Task_Management_GV.EditIndex = -1; this.BindData();

        }








































        protected void BindData(string sortExpression = null)
        {
            try
            {
                string get_Task_Quari = "SELECT " +
                    "TM.* , " +
                    "D.Department_Arabic_Name ," +
                    "E.Employee_Arabic_name " +
                    "FROM task_management TM " +
                    "left join department D on(TM.Department_Id = D.Department_Id) " +
                    "left join employee E on(TM.Employee_Id = E.Employee_Id) Where TM.Employee_Id = '" + Session["Employee_Id"].ToString() + "' ORDER BY Task_Priority;";

                MySqlCommand get_Task_Cmd = new MySqlCommand(get_Task_Quari, _sqlCon);
                MySqlDataAdapter get_Task_Dt = new MySqlDataAdapter(get_Task_Cmd);
                get_Task_Cmd.Connection = _sqlCon;
                _sqlCon.Open();
                get_Task_Dt.SelectCommand = get_Task_Cmd;
                DataTable get_Task_DataTable = new DataTable();
                get_Task_Dt.Fill(get_Task_DataTable);
                Employee_Task_Management_GV.DataSource = get_Task_DataTable;
                Employee_Task_Management_GV.DataBind();
                _sqlCon.Close();
            }
            catch
            {
                Response.Write(
                    @"<script language='javascript'>alert('OOPS!!! The Building List Cannt Display')</script>");
            }
        }
    }
}