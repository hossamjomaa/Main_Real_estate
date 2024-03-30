using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Department : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Add_Department_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addDepartmentQuary =
                    "Insert Into Department (Department_English_name,Department_arabic_name) VALUES(@Department_English_name,@Department_arabic_name)";
                _sqlCon.Open();
                MySqlCommand addDepartmentCmd = new MySqlCommand(addDepartmentQuary, _sqlCon);
                addDepartmentCmd.Parameters.AddWithValue("@Department_English_name", txt_En_Department_Name.Text);
                addDepartmentCmd.Parameters.AddWithValue("@Department_arabic_name", txt_Ar_Department_Name.Text);
                addDepartmentCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Department.Text = "Added successfully";
                Response.Redirect("Department_List.aspx");
            }
        }

        protected void btn_Back_To_Department_List_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Department_List.aspx");
        }
    }
}