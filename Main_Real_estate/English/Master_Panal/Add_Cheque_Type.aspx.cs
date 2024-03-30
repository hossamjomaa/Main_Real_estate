using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Cheque_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Add_cheque_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addChequeTypeQuary =
                    "Insert Into cheque_Type (cheque_English_Type,cheque_Arabic_Type) VALUES(@cheque_English_Type,@cheque_Arabic_Type)";
                _sqlCon.Open();
                MySqlCommand addChequeTypeCmd = new MySqlCommand(addChequeTypeQuary, _sqlCon);
                addChequeTypeCmd.Parameters.AddWithValue("@cheque_English_Type", txt_En_cheque_Type_Name.Text);
                addChequeTypeCmd.Parameters.AddWithValue("@cheque_Arabic_Type", txt_Ar_cheque_Type_Name.Text);
                addChequeTypeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_cheque_Type.Text = "Added successfully";

                _sqlCon.Close();
                Response.Redirect("cheque_Type_List.aspx");
            }
        }

        protected void btn_Back_To_cheque_Type_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("cheque_Type_List.aspx");
        }
    }
}