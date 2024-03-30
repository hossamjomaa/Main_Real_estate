using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_user_Account : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //Get Employe DropDownList
                Helper.LoadDropDownList("SELECT * FROM employee", _sqlCon, Employe_DropDownList, "Employee_Arabic_name", "Employee_Id");
                Employe_DropDownList.Items.Insert(0, "إختر الموظف ....");

                //Get Employe DropDownList
                Helper.LoadDropDownList("SELECT * FROM roles", _sqlCon, Role_DropDownList, "Role_name", "Role_ID");
                Role_DropDownList.Items.Insert(0, "إختر الصلاحية ....");
            }
        }

        protected void btn_Add_user_Account_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var key = "b14ca5898a4e4133bbce2ea2315a1916";
                string Orginal = txt_Password.Text;
                string Moshfar = Utilities.AesOperation.EncryptString(key, txt_Password.Text);



                string Add_user_Account_Query = "Insert Into users ( Emploee_Id , Users_Name ,  Users_Ar_First_Name , Users_Ar_Last_Name , Users_password , Role , Photo , Photo_Path ) " +
                                            "VALUES  ( @Emploee_Id , @Users_Name ,  @Users_Ar_First_Name , @Users_Ar_Last_Name , @Users_password , Role , @Photo , @Photo_Path ) ";
                _sqlCon.Open();
                using (MySqlCommand user_Account_Cmd = new MySqlCommand(Add_user_Account_Query, _sqlCon))
                {
                    user_Account_Cmd.Parameters.AddWithValue("@Emploee_Id", Employe_DropDownList.SelectedValue);
                    user_Account_Cmd.Parameters.AddWithValue("@Users_Name", txt_User_Name.Text);
                    user_Account_Cmd.Parameters.AddWithValue("@Users_Ar_First_Name", txt_Ar_First_Name.Text);
                    user_Account_Cmd.Parameters.AddWithValue("@Users_Ar_Last_Name", txt_Ar_Last_Name.Text);
                    user_Account_Cmd.Parameters.AddWithValue("@Users_password", Moshfar);
                    user_Account_Cmd.Parameters.AddWithValue("@Role", Role_DropDownList.SelectedValue);
                    user_Account_Cmd.Parameters.AddWithValue("@Photo", Photo_FileName.Text);
                    user_Account_Cmd.Parameters.AddWithValue("@Photo_Path", Photo_FilePath.Text);


                    user_Account_Cmd.ExecuteNonQuery();
                }
                _sqlCon.Close();
                lbl_Success_Add_user_Account.Text = "تمت إضافة الوحدة بنجاح";


            }
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("user_Account_List.aspx");
        }

        protected void Employe_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable Dt = new DataTable();
            _sqlCon.Open();
            MySqlCommand Cmd = new MySqlCommand("SELECT Employee_Photo , Employee_Photo_Path FROM employee WHERE Employee_Id = @ID", _sqlCon);
            MySqlDataAdapter Da = new MySqlDataAdapter(Cmd);
            Cmd.Parameters.AddWithValue("@ID", Employe_DropDownList.SelectedValue);
            Da.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                Photo_FileName.Text = Dt.Rows[0]["Employee_Photo"].ToString();
                Photo_FilePath.Text = Dt.Rows[0]["Employee_Photo_Path"].ToString();
            }

            _sqlCon.Close();
        }
    }
}