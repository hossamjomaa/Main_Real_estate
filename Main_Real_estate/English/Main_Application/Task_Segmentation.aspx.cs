using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Task_Segmentation : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // **************************** Get The Task Info *********************************************************************************
                string get_Task_Quari = "SELECT " +
                     "TM.* , " +
                     "D.Department_Arabic_Name ," +
                     "E.Employee_Arabic_name " +
                     "FROM task_management TM " +
                     "left join department D on(TM.Department_Id = D.Department_Id) " +
                     "left join employee E on(TM.Employee_Id = E.Employee_Id) where Task_Management_ID = @ID ORDER BY Task_Priority;";

                string _Task_Id = Request.QueryString["Id"];
                DataTable get_Task_Dt = new DataTable();
                _sqlCon.Open();
                MySqlCommand get_Task_Cmd = new MySqlCommand(get_Task_Quari, _sqlCon);
                MySqlDataAdapter get_Task_Da = new MySqlDataAdapter(get_Task_Cmd);
                get_Task_Cmd.Parameters.AddWithValue("@ID", _Task_Id);
                get_Task_Da.Fill(get_Task_Dt);
                if (get_Task_Dt.Rows.Count > 0) { lbl_Task_Type.Text = get_Task_Dt.Rows[0]["Task_Type"].ToString(); }
                _sqlCon.Close();



                BindData();
            }
        }

        protected void btn_Add_Part_Task_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string add_Part_Task_Quary = "Insert Into task_part (Task_Id , Task_Part_Discription ,Status) VALUES (@Task_Id , @Task_Part_Discription , @Status)";
                _sqlCon.Open();
                MySqlCommand add_Part_Task_Cmd = new MySqlCommand(add_Part_Task_Quary, _sqlCon);
                add_Part_Task_Cmd.Parameters.AddWithValue("@Task_Id", Request.QueryString["Id"]);
                add_Part_Task_Cmd.Parameters.AddWithValue("@Task_Part_Discription", txt_Part_Task_Discreption.Text);
                add_Part_Task_Cmd.Parameters.AddWithValue("@Status", "معلقة");
                add_Part_Task_Cmd.ExecuteNonQuery();
                _sqlCon.Close();

                Response.Redirect(Request.RawUrl);

            }
        }

        protected void btn_Back_To_Task_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employee_Task_Management.aspx");
        }

        protected void Part_Task_GV_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && Part_Task_GV.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddl_Status = (DropDownList)e.Row.FindControl("Task_Status_DropDownList");

                if (DataBinder.Eval(e.Row.DataItem, "Status").ToString() == "معلقة")
                { string selected_Activ = "1"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }

                else if (DataBinder.Eval(e.Row.DataItem, "Status").ToString() == "قيد التنفيذ")
                { string selected_Activ = "2"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }

                else { string selected_Activ = "3"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }
            }
        }

        protected void Part_Task_GV_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            Part_Task_GV.EditIndex = e.NewEditIndex; this.BindData();
        }
        protected void Part_Task_GV_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            Part_Task_GV.EditIndex = -1; this.BindData();
        }

        protected void Part_Task_GV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string lbl_Task_Part_Id = (Part_Task_GV.Rows[e.RowIndex].FindControl("lbl_Task_Part_Id") as Label).Text;
            _sqlCon.Open();
            MySqlCommand cmd = new MySqlCommand("delete from task_part where Task_Part_Id =@Task_Part_Id", _sqlCon);
            cmd.Parameters.AddWithValue("Task_Part_Id", lbl_Task_Part_Id);
            cmd.ExecuteNonQuery();
            _sqlCon.Close();
            BindData();
        }
        protected void Part_Task_GV_RowUpdating1(object sender, GridViewUpdateEventArgs e)
        {
            string lbl_Task_Part_Id = (Part_Task_GV.Rows[e.RowIndex].FindControl("lbl_Task_Part_Id") as Label).Text;
            string Task_Part_Discription = (Part_Task_GV.Rows[e.RowIndex].FindControl("txt_Task_Part_Discription") as TextBox).Text;
            string Task_Status_DropDownList = (Part_Task_GV.Rows[e.RowIndex].FindControl("Task_Status_DropDownList") as DropDownList).SelectedValue;

            string update_Task_Status_Quary = "UPDATE task_part SET Task_Part_Discription=@Task_Part_Discription , Status=@Status WHERE Task_Part_Id = '" + lbl_Task_Part_Id + "' ";

            _sqlCon.Open();
            MySqlCommand update_Task_Status_Cmd = new MySqlCommand(update_Task_Status_Quary, _sqlCon);
            update_Task_Status_Cmd.Parameters.AddWithValue("@Task_Part_Discription", Task_Part_Discription);

            if (Task_Status_DropDownList == "1") { update_Task_Status_Cmd.Parameters.AddWithValue("@Status", "معلقة"); }
            else if (Task_Status_DropDownList == "2") { update_Task_Status_Cmd.Parameters.AddWithValue("@Status", "قيد التنفيذ"); }
            else { update_Task_Status_Cmd.Parameters.AddWithValue("@Status", "منتهية"); }


            update_Task_Status_Cmd.ExecuteNonQuery();
            _sqlCon.Close();
            Part_Task_GV.EditIndex = -1; this.BindData();
        }







        protected void BindData(string sortExpression = null)
        {
            try
            {
                string get_Task_Quari = "SELECT * From task_part Where Task_Id = '"+ Request.QueryString["Id"] + "'";

                MySqlCommand get_Task_Cmd = new MySqlCommand(get_Task_Quari, _sqlCon);
                MySqlDataAdapter get_Task_Dt = new MySqlDataAdapter(get_Task_Cmd);
                get_Task_Cmd.Connection = _sqlCon;
                _sqlCon.Open();
                get_Task_Dt.SelectCommand = get_Task_Cmd;
                DataTable get_Task_DataTable = new DataTable();
                get_Task_Dt.Fill(get_Task_DataTable);
                Part_Task_GV.DataSource = get_Task_DataTable;
                Part_Task_GV.DataBind();
                _sqlCon.Close();
            }
            catch
            {
                Response.Write(
                    @"<script language='javascript'>alert('OOPS!!! Something Is Wrong')</script>");
            }
        }
       

     
    }
}