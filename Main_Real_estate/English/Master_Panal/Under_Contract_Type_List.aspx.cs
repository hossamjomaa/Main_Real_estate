using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Under_Under_Contract_Type_List : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            string quari1 =
                "SELECT Under_Contract_Id , Under_Contractt_English_Type , Under_Contract_Arabic_Type FROM under_contract";
            MySqlCommand mySqlCmd = new MySqlCommand(quari1, _sqlCon);
            MySqlDataAdapter dt = new MySqlDataAdapter(mySqlCmd);
            mySqlCmd.Connection = _sqlCon;
            _sqlCon.Open();
            dt.SelectCommand = mySqlCmd;
            DataTable dataTable = new DataTable();
            dt.Fill(dataTable);
            Under_Contract_Type_GridView1.DataSource = dataTable;
            Under_Contract_Type_GridView1.DataBind();
            _sqlCon.Close();
        }

        protected void Delete_Under_Contract_Type(object sender, EventArgs e)
        {
            try
            {
                string id = (sender as LinkButton).CommandArgument;
                _sqlCon.Open();
                string quary1 = "DELETE FROM under_contract WHERE Under_Contract_Id=@ID ";
                MySqlCommand mySqlCmd = new MySqlCommand(quary1, _sqlCon);
                mySqlCmd.Parameters.AddWithValue("@ID", id);
                mySqlCmd.ExecuteNonQuery();
                _sqlCon.Close();
                Response.Redirect(Request.RawUrl);
            }
            catch
            {
                Response.Write(
                    @"<script language='javascript'>alert('This Under Contract Type Cannot Be Deleted Because It Is Related To An Contract')</script>");
            }

            ;
        }

        protected void GoToAddBuildinType(object sender, EventArgs e)
        {
            Response.Redirect("Add_Under_Contract_Type.aspx");
        }
    }
}