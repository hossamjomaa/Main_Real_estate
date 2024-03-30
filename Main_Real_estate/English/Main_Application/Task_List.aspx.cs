using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Task_List : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
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
                    "left join employee E on(TM.Employee_Id = E.Employee_Id) ORDER BY Task_Priority;";

                MySqlCommand get_Task_Cmd = new MySqlCommand(get_Task_Quari, _sqlCon);
                MySqlDataAdapter get_Task_Dt = new MySqlDataAdapter(get_Task_Cmd);
                get_Task_Cmd.Connection = _sqlCon;
                _sqlCon.Open();
                get_Task_Dt.SelectCommand = get_Task_Cmd;
                DataTable get_Task_DataTable = new DataTable();
                get_Task_Dt.Fill(get_Task_DataTable);
                Task_List_R.DataSource = get_Task_DataTable;
                Task_List_R.DataBind();
                _sqlCon.Close();
            }
            catch
            {
                Response.Write(
                    @"<script language='javascript'>alert('OOPS!!! SomeThing Wrong')</script>");
            }
        }
       

        protected void Edit_Task(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Edit_Task.aspx?Id=" + id);
        }

        protected void Task_List_R_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem ri in Task_List_R.Items)
            {
                _sqlCon.Close();
                LinkButton Edit = ri.FindControl("Edit") as LinkButton;
                Utilities.Roles.Edit_permission(_sqlCon, Session["Role"].ToString(), "Task_Management", Edit);



                Button But_Priority = (ri.FindControl("But_Priority") as Button);
                Label lbl_Task_Priority_Word = (ri.FindControl("lbl_Task_Priority_Word") as Label);
                Label lbl_Task_Priority = (ri.FindControl("lbl_Task_Priority") as Label);

                HtmlTableRow tr = ri.FindControl("row") as HtmlTableRow;
                Label lbl_Task_Status = (ri.FindControl("lbl_Task_Status") as Label);


                if (lbl_Task_Priority.Text == "1")
                {
                    //But_Priority.BackColor = Color.Red; 
                    //lbl_Task_Priority_Word.ForeColor = Color.Red; 
                    But_Priority.Attributes.Add("style", "background-color: #da4453");
                    lbl_Task_Priority_Word.Attributes.Add("style", "color: #da4453");
                }
                else if (lbl_Task_Priority.Text == "2")
                {
                    //But_Priority.BackColor = Color.Orange; 
                    //lbl_Task_Priority_Word.ForeColor = Color.Orange; 
                    But_Priority.Attributes.Add("style", "background-color: #e8563f");
                    lbl_Task_Priority_Word.Attributes.Add("style", "color: #e8563f");
                }
                else if (lbl_Task_Priority.Text == "3")
                {
                    //But_Priority.BackColor = Color.Yellow; 
                    //lbl_Task_Priority_Word.ForeColor = Color.Yellow; 
                    But_Priority.Attributes.Add("style", "background-color: #fcbb42");
                    lbl_Task_Priority_Word.Attributes.Add("style", "color: #fcbb42");
                }
                else if (lbl_Task_Priority.Text == "4")
                {
                    //But_Priority.BackColor = Color.Green; 
                    //lbl_Task_Priority_Word.ForeColor = Color.Green; 
                    But_Priority.Attributes.Add("style", "background-color: #37bc9b");
                    lbl_Task_Priority_Word.Attributes.Add("style", "color: #37bc9b");
                }

                else if (lbl_Task_Priority.Text == "5")
                {
                    //But_Priority.BackColor = Color.LightGreen; 
                    //lbl_Task_Priority_Word.ForeColor = Color.LightGreen; 
                    But_Priority.Attributes.Add("style", "background-color: #62ddbd");
                    lbl_Task_Priority_Word.Attributes.Add("style", "color: #62ddbd");

                }
                else if (lbl_Task_Priority.Text == "6")
                {
                    //But_Priority.BackColor = Color.Blue; 
                    //lbl_Task_Priority_Word.ForeColor = Color.Blue; 
                    But_Priority.Attributes.Add("style", "background-color: #3bafda");
                    lbl_Task_Priority_Word.Attributes.Add("style", "color: #3bafda");
                }


                if(lbl_Task_Status.Text == "قيد التنفيذ") { tr.Attributes.Add("style", "background-color:#00bfff;color:#000000;"); }
                else if(lbl_Task_Status.Text == "منفذة") { tr.Attributes.Add("style", "background-color:#20b2aa;color:#000000;"); }

            }
        }
    }
}