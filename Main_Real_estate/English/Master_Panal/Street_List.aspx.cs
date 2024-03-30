using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Street_List : System.Web.UI.Page
    {
        MySqlConnection SqlCon = new MySqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string quari1 = "SELECT Street_Id , Street_English_name , Street_arabic_name , Street_number FROM Street";
                MySqlCommand MYSqlCmd = new MySqlCommand(quari1, SqlCon);
                MySqlDataAdapter dt = new MySqlDataAdapter(MYSqlCmd);
                MYSqlCmd.Connection = SqlCon;
                SqlCon.Open();
                dt.SelectCommand = MYSqlCmd;
                DataTable dataTable = new DataTable();
                dt.Fill(dataTable);
                Street_GridView1.DataSource = dataTable;
                Street_GridView1.DataBind();
                SqlCon.Close();
            }
            catch (Exception ex) { }
        }
        protected void linkDelete(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            SqlCon.Open();
            string quary1 = "DELETE FROM Street WHERE Street_Id=@ID ";
            MySqlCommand MYSqlCmd = new MySqlCommand(quary1, SqlCon);
            MYSqlCmd.Parameters.AddWithValue("@ID", id);
            MYSqlCmd.ExecuteNonQuery();
            SqlCon.Close();
            Response.Redirect(Request.RawUrl);
        }

        protected void GoToAddBuildinType(object sender, EventArgs e)
        {
            Response.Redirect("Add_Street.aspx");
        }
    }
}