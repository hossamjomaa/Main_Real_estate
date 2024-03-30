using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Transaction_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Add_Transaction_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addTransactionTypeQuary =
                    "Insert Into Transaction_Type (Transaction_English_Type,Transaction_Arabic_Type) VALUES(@Transaction_English_Type,@Transaction_Arabic_Type)";
                _sqlCon.Open();
                MySqlCommand addTransactionTypeCmd = new MySqlCommand(addTransactionTypeQuary, _sqlCon);
                addTransactionTypeCmd.Parameters.AddWithValue("@Transaction_English_Type",
                    txt_En_Transaction_Type_Name.Text);
                addTransactionTypeCmd.Parameters.AddWithValue("@Transaction_Arabic_Type",
                    txt_Ar_Transaction_Type_Name.Text);
                addTransactionTypeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Transaction_Type.Text = "Added successfully";

                _sqlCon.Close();
                Response.Redirect("Transaction_Type_List.aspx");
            }
        }

        protected void btn_Back_To_Transaction_Type_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Transaction_Type_List.aspx");
        }
    }
}