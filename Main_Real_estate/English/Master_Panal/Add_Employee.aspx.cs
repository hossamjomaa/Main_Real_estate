using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Employee : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
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
            }
        }

        protected void btn_Add_Employee_Click1(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addEmployeeQuary = "Insert Into employee (" +
                                            "Employee_Photo," +
                                            "Employee_Photo_Path," +
                                            "Employee_English_name," +
                                            "Employee_Arabic_name," +
                                            "Employee_Mobile," +
                                            "Employee_Tell," +
                                            "Employee_Designation," +
                                            "department_Department_Id," +
                                            "employee_level_Employee_Level_Id) " +
                                            "VALUES(" +
                                            "@Employee_Photo ," +
                                            "@Employee_Photo_Path , " +
                                            "@Employee_English_name," +
                                            "@Employee_Arabic_name," +
                                            "@Employee_Mobile," +
                                            "@Employee_Tell," +
                                            "@Employee_Designation," +
                                            "@department_Department_Id," +
                                            "@employee_level_Employee_Level_Id)";
                _sqlCon.Open();
                MySqlCommand addEmployeeCmd = new MySqlCommand(addEmployeeQuary, _sqlCon);

                addEmployeeCmd.Parameters.AddWithValue("@department_Department_Id", Employee_Department_DropDownList.SelectedValue);
                addEmployeeCmd.Parameters.AddWithValue("@employee_level_Employee_Level_Id", Employee_Level_DropDownList.SelectedValue);
                addEmployeeCmd.Parameters.AddWithValue("@Employee_English_name", txt_En_Employee_Name.Text);
                addEmployeeCmd.Parameters.AddWithValue("@Employee_Arabic_name", txt_Ar_Employee_Name.Text);
                addEmployeeCmd.Parameters.AddWithValue("@Employee_Mobile", txt_Employee_Mobile.Text);
                addEmployeeCmd.Parameters.AddWithValue("@Employee_Tell", txt_Employee_Mobile.Text);
                addEmployeeCmd.Parameters.AddWithValue("@Employee_Designation", txt_Employee_Designation.Text);


                if (FUL_Employee_Photo.HasFile)
                {
                    string fileName1 = Path.GetFileName(FUL_Employee_Photo.PostedFile.FileName);
                    FUL_Employee_Photo.PostedFile.SaveAs(Server.MapPath("/English/Master_Panal/Employee_Photo/") + fileName1);
                    addEmployeeCmd.Parameters.AddWithValue("@Employee_Photo", fileName1);
                    addEmployeeCmd.Parameters.AddWithValue("@Employee_Photo_Path", "/English/Master_Panal/Employee_Photo/" + fileName1);
                }
                else
                {
                    addEmployeeCmd.Parameters.AddWithValue("@Employee_Photo", "User.png");
                    addEmployeeCmd.Parameters.AddWithValue("@Employee_Photo_Path", "/English/Main_Application/Main_Image/User.png");
                }




                addEmployeeCmd.ExecuteNonQuery();



                _sqlCon.Close();
                lbl_Success_Add_New_Employee.Text = "تمت الإضافة بنجاح";

                Response.Redirect("Employee_List.aspx");
            }
        }

        protected void btn_Back_To_Employee_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employee_List.aspx");
        }
    }
}