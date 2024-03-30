using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Street : System.Web.UI.Page
    {
        MySqlConnection SqlCon = new MySqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            string X = txt_En_Street_Name.Text;
            string y = txt_Ar_Street_Name.Text;
            int z = Convert.ToInt32(txt_Street_Number.Text);

            string quari = "Insert Into Street (Street_English_name,Street_arabic_name,Street_number) VALUES(@Street_English_name,@Street_arabic_name,@Street_number)";
            SqlCon.Open();
            MySqlCommand MYSqlCmd = new MySqlCommand(quari, SqlCon);
            MYSqlCmd.Parameters.AddWithValue("@Street_English_name", X);
            MYSqlCmd.Parameters.AddWithValue("@Street_arabic_name", y);
            MYSqlCmd.Parameters.AddWithValue("@Street_number", z);
            MYSqlCmd.ExecuteNonQuery();
            SqlCon.Close();
            lbl_Success_Add_New_Street.Text = "Added successfully";

            Response.Redirect("Street_List.aspx");
        }

        protected void btn_Back_To_Street_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Street_List.aspx");
        }
    }
}