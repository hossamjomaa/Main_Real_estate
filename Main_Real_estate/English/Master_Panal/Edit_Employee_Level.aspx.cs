using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Employee_Level : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string employeeLevelId = Request.QueryString["Id"];
                DataTable getEmployeeLevelDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getEmployeeLevelCmd =
                    new MySqlCommand(
                        "SELECT Employee_Level_id , Employee_English_Level , Employee_Arabic_Level  FROM Employee_Level WHERE Employee_Level_id = @ID",
                        _sqlCon);
                MySqlDataAdapter getEmployeeLevelDa = new MySqlDataAdapter(getEmployeeLevelCmd);

                getEmployeeLevelCmd.Parameters.AddWithValue("@ID", employeeLevelId);
                getEmployeeLevelDa.Fill(getEmployeeLevelDt);
                if (getEmployeeLevelDt.Rows.Count > 0)
                {
                    txt_En_Employee_Level_Name.Text =
                        getEmployeeLevelDt.Rows[0]["Employee_English_Level"].ToString();
                    txt_Ar_Employee_Level_Name.Text = getEmployeeLevelDt.Rows[0]["Employee_Arabic_Level"].ToString();
                    lbl_Name_Of_Employee_Level.Text = getEmployeeLevelDt.Rows[0]["Employee_Arabic_Level"].ToString();
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Back_To_Employee_Level_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employee_Level_List.aspx");
        }

        protected void btn_Edit_Employee_Level_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string employeeLevelId = Request.QueryString["Id"];
                string updateEmployeeTupeQuary =
                    "UPDATE Employee_Level SET Employee_English_Level=@Employee_English_Level , Employee_Arabic_Level=@Employee_Arabic_Level  WHERE Employee_Level_id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateEmployeeLevelCmd = new MySqlCommand(updateEmployeeTupeQuary, _sqlCon);
                updateEmployeeLevelCmd.Parameters.AddWithValue("@ID", employeeLevelId);
                updateEmployeeLevelCmd.Parameters.AddWithValue("@Employee_English_Level",
                    txt_En_Employee_Level_Name.Text);
                updateEmployeeLevelCmd.Parameters.AddWithValue("@Employee_Arabic_Level",
                    txt_Ar_Employee_Level_Name.Text);
                updateEmployeeLevelCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_New_Employee_Level.Text = "Edit successfully";
                Response.Redirect("Employee_Level_List.aspx");
            }
        }
    }
}