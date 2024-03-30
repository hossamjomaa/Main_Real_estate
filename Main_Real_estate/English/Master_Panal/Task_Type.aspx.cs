using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Task_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindData();
            }
        }

        protected void btn_Add_Task_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string add_Task_Type_Quary = "Insert Into task_type (Task_Arabic_Type , Task_English_Type ) VALUES (@Task_Arabic_Type , @Task_English_Type )";
                _sqlCon.Open();
                MySqlCommand add_Task_Type_Cmd = new MySqlCommand(add_Task_Type_Quary, _sqlCon);
                add_Task_Type_Cmd.Parameters.AddWithValue("@Task_Arabic_Type", txt_Ar_Task_Type_Name.Text);
                add_Task_Type_Cmd.Parameters.AddWithValue("@Task_English_Type", txt_EN_Task_Type_Name.Text);
                add_Task_Type_Cmd.ExecuteNonQuery();
                _sqlCon.Close();

                Response.Redirect(Request.RawUrl);

            }
        }

        

        protected void Task_Type_GV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Task_Type_GV.EditIndex = e.NewEditIndex; this.BindData();
        }
        protected void Task_Type_GV_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Task_Type_GV.EditIndex = -1; this.BindData();
        }

        protected void Task_Type_GV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string lbl_Task_Type_Id = (Task_Type_GV.Rows[e.RowIndex].FindControl("lbl_Task_Type_Id") as Label).Text;
            _sqlCon.Open();
            MySqlCommand cmd = new MySqlCommand("delete from task_type where Task_Type_Id =@Task_Type_Id", _sqlCon);
            cmd.Parameters.AddWithValue("Task_Type_Id", lbl_Task_Type_Id);
            cmd.ExecuteNonQuery();
            _sqlCon.Close();
            BindData();
        }

        protected void Task_Type_GV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string lbl_Task_Type_Id = (Task_Type_GV.Rows[e.RowIndex].FindControl("lbl_Task_Type_Id") as Label).Text;
            string txt_Task_Arabic_Type = (Task_Type_GV.Rows[e.RowIndex].FindControl("txt_Task_Arabic_Type") as TextBox).Text;
            string txt_Task_English_Type = (Task_Type_GV.Rows[e.RowIndex].FindControl("txt_Task_English_Type") as TextBox).Text;


            string update_Task_Status_Quary = "UPDATE task_type SET Task_Arabic_Type=@Task_Arabic_Type , Task_English_Type=@Task_English_Type WHERE Task_Type_Id = '" + lbl_Task_Type_Id + "' ";

            _sqlCon.Open();
            MySqlCommand update_Task_Status_Cmd = new MySqlCommand(update_Task_Status_Quary, _sqlCon);
            update_Task_Status_Cmd.Parameters.AddWithValue("@Task_Arabic_Type", txt_Task_Arabic_Type);
            update_Task_Status_Cmd.Parameters.AddWithValue("@Task_English_Type", txt_Task_English_Type);




            update_Task_Status_Cmd.ExecuteNonQuery();
            _sqlCon.Close();
            Task_Type_GV.EditIndex = -1; this.BindData();
        }




        protected void BindData(string sortExpression = null)
        {
            try
            {
                string get_Task_Quari = "SELECT * From task_type";

                MySqlCommand get_Task_Cmd = new MySqlCommand(get_Task_Quari, _sqlCon);
                MySqlDataAdapter get_Task_Dt = new MySqlDataAdapter(get_Task_Cmd);
                get_Task_Cmd.Connection = _sqlCon;
                _sqlCon.Open();
                get_Task_Dt.SelectCommand = get_Task_Cmd;
                DataTable get_Task_DataTable = new DataTable();
                get_Task_Dt.Fill(get_Task_DataTable);
                Task_Type_GV.DataSource = get_Task_DataTable;
                Task_Type_GV.DataBind();
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