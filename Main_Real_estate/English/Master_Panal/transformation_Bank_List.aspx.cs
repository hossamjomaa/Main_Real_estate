using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;
using Ubiety.Dns.Core;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class transformation_Bank_List : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            Get_Bank_BindData();
        }

        protected void Get_Bank_BindData()
        {
            try
            {
                string getBankQuari = "SELECT * FROM transformation_bank";
                MySqlCommand getBankCmd = new MySqlCommand(getBankQuari, _sqlCon);
                MySqlDataAdapter getBankDt = new MySqlDataAdapter(getBankCmd);
                getBankCmd.Connection = _sqlCon;
                _sqlCon.Open();
                getBankDt.SelectCommand = getBankCmd;
                DataTable getBankDataTable = new DataTable();
                getBankDt.Fill(getBankDataTable);
                Bank_GridView1.DataSource = getBankDataTable;
                Bank_GridView1.DataBind();
                _sqlCon.Close();
            }
            catch (Exception ex)
            {
            }
        }

        protected void btn_Bank_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string bankRowId = (sender as LinkButton).CommandArgument;
                _sqlCon.Open();
                string deleteBankQuary = "DELETE FROM transformation_bank WHERE transformation_Bank_ID=@ID ";
                MySqlCommand mySqlCmd = new MySqlCommand(deleteBankQuary, _sqlCon);
                mySqlCmd.Parameters.AddWithValue("@ID", bankRowId);
                mySqlCmd.ExecuteNonQuery();
                _sqlCon.Close();
                Response.Redirect(Request.RawUrl);
             }
            catch
            {
                Response.Write(@"<script language='javascript'>alert('هذا البنك مرتبط بحولات مالية')</script>");
            };
        }

        protected void GoToAddBank()
        {
            Response.Redirect("Edit_transformation_Bank.aspx");
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Add_transformation_Bank.aspx");
        }
    }
}