using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Employee : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Fill Employee Departement DropDownList
                using (MySqlCommand getEmployeeDepartementDropDownListCmd =
                       new MySqlCommand("SELECT * FROM department"))
                {
                    getEmployeeDepartementDropDownListCmd.CommandType = CommandType.Text;
                    getEmployeeDepartementDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    Employee_Department_DropDownList.DataSource =
                        getEmployeeDepartementDropDownListCmd.ExecuteReader();
                    Employee_Department_DropDownList.DataTextField = "Department_Arabic_Name";
                    Employee_Department_DropDownList.DataValueField = "Department_Id";
                    Employee_Department_DropDownList.DataBind();
                    Employee_Department_DropDownList.Items.Insert(0, "إختر القسم ....");
                    _sqlCon.Close();
                }

                //    //Fill Employee Level  DropDownList
                using (MySqlCommand getEmployeeLevelDropDownListCmd =
                       new MySqlCommand("SELECT * FROM employee_level"))
                {
                    getEmployeeLevelDropDownListCmd.CommandType = CommandType.Text;
                    getEmployeeLevelDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    Employee_Level_DropDownList.DataSource = getEmployeeLevelDropDownListCmd.ExecuteReader();
                    Employee_Level_DropDownList.DataTextField = "Employee_Arabic_Level";
                    Employee_Level_DropDownList.DataValueField = "Employee_Level_Id";
                    Employee_Level_DropDownList.DataBind();
                    Employee_Level_DropDownList.Items.Insert(0, "إختر الدرجة ....");
                    _sqlCon.Close();
                }

                string employeeId = Request.QueryString["Id"];
                DataTable getEmployeeDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getEmployeeCmd =
                    new MySqlCommand("SELECT * FROM employee WHERE Employee_Id = @ID", _sqlCon);
                MySqlDataAdapter getEmployeeDa = new MySqlDataAdapter(getEmployeeCmd);
                getEmployeeCmd.Parameters.AddWithValue("@ID", employeeId);
                getEmployeeDa.Fill(getEmployeeDt);
                if (getEmployeeDt.Rows.Count > 0)
                {
                    txt_En_Employee_Name.Text = getEmployeeDt.Rows[0]["Employee_English_name"].ToString();
                    txt_Ar_Employee_Name.Text = getEmployeeDt.Rows[0]["Employee_Arabic_name"].ToString();
                    txt_Employee_Mobile.Text = getEmployeeDt.Rows[0]["Employee_Mobile"].ToString();
                    txt_Employee_tell.Text = getEmployeeDt.Rows[0]["Employee_Tell"].ToString();
                    txt_Employee_Designation.Text = getEmployeeDt.Rows[0]["Employee_Designation"].ToString();

                    Employee_Department_DropDownList.SelectedValue =
                        getEmployeeDt.Rows[0]["department_Department_Id"].ToString();
                    Employee_Level_DropDownList.SelectedValue =
                        getEmployeeDt.Rows[0]["employee_level_Employee_Level_Id"].ToString();

                    lbl_titel_Name_Edit_Employee.Text = getEmployeeDt.Rows[0]["Employee_Arabic_name"].ToString();
                    Photo_Name.Text = getEmployeeDt.Rows[0]["Employee_Photo"].ToString();
                    lbl_path.Text = getEmployeeDt.Rows[0]["Employee_Photo_path"].ToString();
                    Employee_Photo.ImageUrl = lbl_path.Text;
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Edit_Employee_Click1(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string employeeId = Request.QueryString["Id"];

                string updateEmployeeQuary = "UPDATE employee SET " +
                                               "Employee_Photo=@Employee_Photo , " +
                                               "Employee_Photo_path=@Employee_Photo_Path , " +
                                               "Employee_English_name=@Employee_English_name, " +
                                               "Employee_Arabic_name=@Employee_Arabic_name , " +
                                               "Employee_Mobile=@Employee_Mobile , " +
                                               "Employee_Tell=@Employee_Tell , " +
                                               "Employee_Designation=@Employee_Designation , " +
                                               "department_Department_Id=@department_Department_Id , " +
                                               "employee_level_Employee_Level_Id=@employee_level_Employee_Level_Id " +
                                               "WHERE Employee_Id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateEmployeeCmd = new MySqlCommand(updateEmployeeQuary, _sqlCon);
                updateEmployeeCmd.Parameters.AddWithValue("@ID", employeeId);
                updateEmployeeCmd.Parameters.AddWithValue("@Employee_English_name", txt_En_Employee_Name.Text);
                updateEmployeeCmd.Parameters.AddWithValue("@Employee_Arabic_name", txt_Ar_Employee_Name.Text);
                updateEmployeeCmd.Parameters.AddWithValue("@Employee_Mobile", txt_Employee_Mobile.Text);
                updateEmployeeCmd.Parameters.AddWithValue("@Employee_Tell", txt_Employee_tell.Text);
                updateEmployeeCmd.Parameters.AddWithValue("@Employee_Designation", txt_Employee_Designation.Text);
                updateEmployeeCmd.Parameters.AddWithValue("@department_Department_Id",
                    Employee_Department_DropDownList.SelectedValue);
                updateEmployeeCmd.Parameters.AddWithValue("@employee_level_Employee_Level_Id",
                    Employee_Level_DropDownList.SelectedValue);

                if (FUL_Employee_Photo.HasFile)
                {
                    string fileName = Path.GetFileName(FUL_Employee_Photo.PostedFile.FileName);
                    FUL_Employee_Photo.PostedFile.SaveAs(Server.MapPath("/English/Master_Panal/Employee_Photo/") +
                                                         fileName);
                    updateEmployeeCmd.Parameters.AddWithValue("@Employee_Photo", fileName);
                    updateEmployeeCmd.Parameters.AddWithValue("@Employee_Photo_Path",
                        "/English/Master_Panal/Employee_Photo/" + fileName);
                }
                else
                {
                    string fileName = Path.GetFileName(FUL_Employee_Photo.PostedFile.FileName);
                    updateEmployeeCmd.Parameters.AddWithValue("@Employee_Photo", Photo_Name.Text);
                    updateEmployeeCmd.Parameters.AddWithValue("@Employee_Photo_Path", lbl_path.Text);
                }

                updateEmployeeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_Employee.Text = "تم التعديل بنجاح";
                Response.Redirect("Employee_List.aspx");
            }
        }

        protected void btn_Back_To_Employee_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employee_List.aspx");
        }
    }
}