using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Log_In : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ValidateUser(object sender, AuthenticateEventArgs e)
        {
            if (e.Authenticated)
            {
                Response.Redirect("~/English/Main_Application/DashBoard.aspx");
            }

            if (ValidateUser(Login1.UserName, Login1.Password))
            {
                Response.Redirect("~/English/Main_Application/DashBoard.aspx");
            }
            else
            {
                e.Authenticated = false;
            }
        }

        private bool ValidateUser(string userName, string password)
        {
            var key = "b14ca5898a4e4133bbce2ea2315a1916";
            string Orginal = password;
            string Moshfar = Utilities.AesOperation.EncryptString(key, password);


            bool status;
            //MySqlConnection SqlCon = Helper.GetConnection();
            MySqlConnection sqlCon = Helper.GetConnection();
            MySqlDataAdapter logInSda = new MySqlDataAdapter(
                "Select * from users where Users_Name='" + userName +
                "' and Users_password='" + Moshfar + "'", sqlCon);

            DataTable dt = new DataTable();
            logInSda.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                Session["user_ID"] = dt.Rows[0]["user_ID"].ToString();
                Session["Users_Name"] = dt.Rows[0]["Users_Name"].ToString();
                Session["Photo_Path"] = dt.Rows[0]["Photo_Path"].ToString();
                Session["user_ID"] = dt.Rows[0]["user_ID"].ToString();
                Session["Employee_Id"] = dt.Rows[0]["Emploee_Id"].ToString();

                Session["Role"] = dt.Rows[0]["Role"].ToString();

                Session["OW_Back"] = "1";
                Session["B_Back"] = "1";
                Session["U_Back"] = "1";


                status = true;
            }
            else
            {
                status = false;
            }

            return status;
        }
    }
}