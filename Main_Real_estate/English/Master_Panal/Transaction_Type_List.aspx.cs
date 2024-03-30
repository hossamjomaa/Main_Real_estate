using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Transaction_Type_List : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            Transaction_Type_BindData();
        }

        protected void Transaction_Type_BindData()
        {
            string getTransactionTypeQuary =
                "SELECT Transaction_Type_id , Transaction_English_Type , Transaction_Arabic_Type FROM transaction_type";
            MySqlCommand getTransactionTypeCmd = new MySqlCommand(getTransactionTypeQuary, _sqlCon);
            MySqlDataAdapter getTransactionTypeDt = new MySqlDataAdapter(getTransactionTypeCmd);
            getTransactionTypeCmd.Connection = _sqlCon;
            _sqlCon.Open();
            getTransactionTypeDt.SelectCommand = getTransactionTypeCmd;
            DataTable getTransactionTypeDataTable = new DataTable();
            getTransactionTypeDt.Fill(getTransactionTypeDataTable);
            Transaction_Type_GridView1.DataSource = getTransactionTypeDataTable;
            Transaction_Type_GridView1.DataBind();
            _sqlCon.Close();
        }

        protected void Transaction_Type_GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Transaction_Type_GridView1.PageIndex = e.NewPageIndex;
            Transaction_Type_BindData();
        }

        protected void Delete_Transaction_Type(object sender, EventArgs e)
        {
            try
            {
                string transactionTypeId = (sender as LinkButton).CommandArgument;
                _sqlCon.Open();
                string deleteTransactionTypeQuary = "DELETE FROM transaction_type WHERE Transaction_Type_id=@ID ";
                MySqlCommand deleteTransactionTypeLCmd = new MySqlCommand(deleteTransactionTypeQuary, _sqlCon);
                deleteTransactionTypeLCmd.Parameters.AddWithValue("@ID", transactionTypeId);
                deleteTransactionTypeLCmd.ExecuteNonQuery();
                _sqlCon.Close();
                Response.Redirect(Request.RawUrl);
            }
            catch
            {
                Response.Write(
                    @"<script language='javascript'>alert('This Transaction_Type Cannot Be Deleted Because It Is Related To An Transaction And Renal')</script>");
            }

            ;
        }

        protected void Go_To_Add_Transaction_Type_Type(object sender, EventArgs e)
        {
            Response.Redirect("Add_Transaction_Type.aspx");
        }
    }
}