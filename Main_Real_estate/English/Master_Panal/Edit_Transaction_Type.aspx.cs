using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Transaction_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string transactionTypeId = Request.QueryString["Id"];
                DataTable getTransactionTypeDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getTransactionTypeCmd =
                    new MySqlCommand(
                        "SELECT Transaction_Type_id , Transaction_English_Type , Transaction_Arabic_Type  FROM Transaction_Type WHERE Transaction_Type_id = @ID",
                        _sqlCon);
                MySqlDataAdapter getTransactionTypeDa = new MySqlDataAdapter(getTransactionTypeCmd);

                getTransactionTypeCmd.Parameters.AddWithValue("@ID", transactionTypeId);
                getTransactionTypeDa.Fill(getTransactionTypeDt);
                if (getTransactionTypeDt.Rows.Count > 0)
                {
                    txt_En_Transaction_Type_Name.Text =
                        getTransactionTypeDt.Rows[0]["Transaction_English_Type"].ToString();
                    txt_Ar_Transaction_Type_Name.Text =
                        getTransactionTypeDt.Rows[0]["Transaction_Arabic_Type"].ToString();
                    lbl_Name_Of_Transaction_Type.Text =
                        getTransactionTypeDt.Rows[0]["Transaction_English_Type"].ToString();
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Edit_Transaction_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string transactionTypeId = Request.QueryString["Id"];
                string updateTransactionTypeQuary =
                    "UPDATE Transaction_Type SET Transaction_English_Type=@Transaction_English_Type , Transaction_Arabic_Type=@Transaction_Arabic_Type  WHERE Transaction_Type_id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateTransactionTypeCmd = new MySqlCommand(updateTransactionTypeQuary, _sqlCon);
                updateTransactionTypeCmd.Parameters.AddWithValue("@ID", transactionTypeId);
                updateTransactionTypeCmd.Parameters.AddWithValue("@Transaction_English_Type",
                    txt_En_Transaction_Type_Name.Text);
                updateTransactionTypeCmd.Parameters.AddWithValue("@Transaction_Arabic_Type",
                    txt_Ar_Transaction_Type_Name.Text);
                updateTransactionTypeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_New_Transaction_Type.Text = "Edit successfully";
                Response.Redirect("Transaction_Type_List.aspx");
            }
        }

        protected void btn_Back_To_Transaction_Type_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Transaction_Type_List.aspx");
        }
    }
}