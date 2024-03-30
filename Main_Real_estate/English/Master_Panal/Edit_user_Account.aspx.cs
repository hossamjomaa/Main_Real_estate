using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_user_Account : System.Web.UI.Page
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


                // Get User Info 
                string ID = Request.QueryString["Id"];
                DataTable Dt = new DataTable();
                _sqlCon.Open();
                MySqlCommand Cmd = new MySqlCommand("SELECT * FROM users WHERE user_ID = @ID", _sqlCon);
                MySqlDataAdapter Da = new MySqlDataAdapter(Cmd);
                Cmd.Parameters.AddWithValue("@ID", ID);
                Da.Fill(Dt);
                if (Dt.Rows.Count > 0)
                {
                    Employe_DropDownList.SelectedValue = Dt.Rows[0]["Emploee_Id"].ToString();
                    txt_Ar_First_Name.Text = Dt.Rows[0]["Users_Ar_First_Name"].ToString();
                    txt_Ar_Last_Name.Text = Dt.Rows[0]["Users_Ar_Last_Name"].ToString();
                    txt_User_Name.Text = Dt.Rows[0]["Users_Name"].ToString();


                    var key = "b14ca5898a4e4133bbce2ea2315a1916";
                    var decryptedString = Utilities.AesOperation.DecryptString(key, Dt.Rows[0]["Users_password"].ToString());



                    txt_Password.Text = decryptedString;
                    txt_Confirm_Password.Text = decryptedString;




                    Role_DropDownList.SelectedValue = Dt.Rows[0]["Role"].ToString();
                    Photo_FileName.Text = Dt.Rows[0]["Photo"].ToString();
                    Photo_FilePath.Text = Dt.Rows[0]["Photo_Path"].ToString();
                    lbl_user_Account_Name.Text = Dt.Rows[0]["Users_Name"].ToString();
                }

                _sqlCon.Close();
            }
            ViewState["Pwd"] = txt_Password.Text;
            txt_Password.Attributes.Add("value", ViewState["Pwd"].ToString());

            ViewState["ConfirmPwd"] = txt_Confirm_Password.Text;
            txt_Confirm_Password.Attributes.Add("value", ViewState["ConfirmPwd"].ToString());
        }

        protected void btn_Edit_user_Account_Click(object sender, EventArgs e)
        {
            var key = "b14ca5898a4e4133bbce2ea2315a1916";
            string Orginal = txt_Password.Text;
            string Moshfar = Utilities.AesOperation.EncryptString(key, txt_Password.Text);

            if (Page.IsValid)
            {
                string ID = Request.QueryString["Id"];
                string Edit_user_Account_Query = "UPDATE users SET " +
                                                 "Emploee_Id=@Emploee_Id , " +
                                                 "Users_Ar_First_Name=@Users_Ar_First_Name , " +
                                                 "Users_Ar_Last_Name=@Users_Ar_Last_Name , " +
                                                 "Users_Name=@Users_Name , " +
                                                 "Users_password=@Users_password , " +
                                                 "Role=@Role , " +
                                                 "Photo=@Photo , " +
                                                 "Photo_Path=@Photo_Path " +
                                                 "WHERE user_ID=@ID ";
                _sqlCon.Open();
                MySqlCommand Cmd = new MySqlCommand(Edit_user_Account_Query, _sqlCon);
                Cmd.Parameters.AddWithValue("@ID", ID);
                Cmd.Parameters.AddWithValue("@Emploee_Id", Employe_DropDownList.SelectedValue);
                Cmd.Parameters.AddWithValue("@Users_Ar_First_Name", txt_Ar_First_Name.Text);
                Cmd.Parameters.AddWithValue("@Users_Ar_Last_Name", txt_Ar_Last_Name.Text);
                Cmd.Parameters.AddWithValue("@Users_Name", txt_User_Name.Text);
                Cmd.Parameters.AddWithValue("@Users_password", Moshfar);
                Cmd.Parameters.AddWithValue("@Role", Role_DropDownList.SelectedValue);
                Cmd.Parameters.AddWithValue("@Photo", Photo_FileName.Text);
                Cmd.Parameters.AddWithValue("@Photo_Path", Photo_FilePath.Text);
                Cmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_user_Account.Text = "تم التعديل بنجاح";
                Response.Redirect("user_Account_List.aspx");
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

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                txt_Password.TextMode = TextBoxMode.SingleLine;
            }
            else
            {
                txt_Password.TextMode = TextBoxMode.Password;
            }
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox2.Checked == true)
            {
                txt_Confirm_Password.TextMode = TextBoxMode.SingleLine;
            }
            else
            {
                txt_Confirm_Password.TextMode = TextBoxMode.Password;
            }
        }
    }
}
