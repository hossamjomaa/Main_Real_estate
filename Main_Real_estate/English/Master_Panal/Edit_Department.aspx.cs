using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Department : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string departmentId = Request.QueryString["Id"];
                DataTable getDepartmentDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getDepartmentCmd =
                    new MySqlCommand(
                        "SELECT Department_Id , Department_English_name , Department_arabic_name  FROM Department WHERE Department_Id = @ID",
                        _sqlCon);
                MySqlDataAdapter getDepartmentDa = new MySqlDataAdapter(getDepartmentCmd);

                getDepartmentCmd.Parameters.AddWithValue("@ID", departmentId);
                getDepartmentDa.Fill(getDepartmentDt);
                if (getDepartmentDt.Rows.Count > 0)
                {
                    txt_En_Department_Name.Text = getDepartmentDt.Rows[0]["Department_English_name"].ToString();
                    txt_Ar_Department_Name.Text = getDepartmentDt.Rows[0]["Department_arabic_name"].ToString();
                    lbl_titel_Name_Edit_Department.Text =
                        getDepartmentDt.Rows[0]["Department_English_name"].ToString();
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Back_To_Department_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Department_List.aspx");
        }

        protected void btn_Add_Department_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string departmentId = Request.QueryString["Id"];
                string updateDepartmentQuary =
                    "UPDATE Department SET Department_English_name=@Department_English_name , Department_arabic_name=@Department_arabic_name  WHERE Department_Id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateDepartmentCmd = new MySqlCommand(updateDepartmentQuary, _sqlCon);
                updateDepartmentCmd.Parameters.AddWithValue("@ID", departmentId);
                updateDepartmentCmd.Parameters.AddWithValue("@Department_English_name", txt_En_Department_Name.Text);
                updateDepartmentCmd.Parameters.AddWithValue("@Department_arabic_name", txt_Ar_Department_Name.Text);
                updateDepartmentCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_Department.Text = "Edit successfully";
                Response.Redirect("Department_List.aspx");
            }
        }
    }
}