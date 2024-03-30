using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Employee_Level : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Add_Employee_Level_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addEmployeeLevelQuary =
                    "Insert Into Employee_Level (Employee_English_Level,Employee_Arabic_Level) VALUES(@Employee_English_Level,@Employee_Arabic_Level)";
                _sqlCon.Open();
                MySqlCommand addEmployeeLevelCmd = new MySqlCommand(addEmployeeLevelQuary, _sqlCon);
                addEmployeeLevelCmd.Parameters.AddWithValue("@Employee_English_Level",
                    txt_En_Employee_Level_Name.Text);
                addEmployeeLevelCmd.Parameters.AddWithValue("@Employee_Arabic_Level",
                    txt_Ar_Employee_Level_Name.Text);
                addEmployeeLevelCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Employee_Level.Text = "Added successfully";

                _sqlCon.Close();
                Response.Redirect("Employee_Level_List.aspx");
            }
        }

        protected void btn_Back_To_Employee_Level_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employee_Level_List.aspx");
        }
    }
}