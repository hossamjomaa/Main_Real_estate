using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Master_Log_In : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ValidateUser(object sender, AuthenticateEventArgs e)
        {
            if (e.Authenticated)
            {
                Response.Redirect("~/English/Master_Panal/Master_Home.aspx.aspx");
            }

            if (ValidateUser(Login1.UserName, Login1.Password))
            {
                Response.Redirect("~/English/Master_Panal/Master_Home.aspx");
            }
            else
            {
                e.Authenticated = false;
            }
        }

        private bool ValidateUser(string userName, string password)
        {
            bool status;
            MySqlConnection con = Helper.GetConnection();
            MySqlDataAdapter sda = new MySqlDataAdapter(
                "Select Users_Name , Users_password from users where Users_Name='" + userName +
                "' and Users_password='" + password + "'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                Session["Users_Name"] = dt.Rows[0][0].ToString();
                status = true;
            }
            else
            {
                status = false;
            }

            return status;

            ////bool status;
            ////string mycon = "SERVER = LOCALHOST; DATABASE = real_estate_db ; UID = root ; PASSWORD =123456 ;";
            ////MySqlConnection scon = new MySqlConnection(mycon);
            ////string myquri = "Select Users_Name , Users_password From users";
            ////MySqlCommand CMD = new MySqlCommand();
            ////CMD.CommandText = myquri;
            ////CMD.Connection = scon;
            ////MySqlDataAdapter da = new MySqlDataAdapter();
            ////da.SelectCommand = CMD;
            ////DataSet ds = new DataSet();
            ////da.Fill(ds);
            //string uname;
            //string pass;

            //uname = ds.Tables[0].Rows[0]["Users_Name"].ToString();
            //pass = ds.Tables[0].Rows[0]["Users_password"].ToString();
            //scon.Close();
            //if (uname == userName && pass == password)
            //{
            //    Session["Users_Name"] = uname;
            //    status = true;
            //    //Session.RemoveAll();
            //}
            //else
            //{
            //    status = false;
            //}
            //return status;
        }
    }
}