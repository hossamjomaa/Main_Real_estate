using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Payment_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Add_Payment_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addPaymentTypeQuary =
                    "Insert Into Payment_Type (Payment_English_Type,Payment_Arabic_Type) VALUES(@Payment_English_Type,@Payment_Arabic_Type)";
                _sqlCon.Open();
                MySqlCommand addPaymentTypeCmd = new MySqlCommand(addPaymentTypeQuary, _sqlCon);
                addPaymentTypeCmd.Parameters.AddWithValue("@Payment_English_Type", txt_En_Payment_Type_Name.Text);
                addPaymentTypeCmd.Parameters.AddWithValue("@Payment_Arabic_Type", txt_Ar_Payment_Type_Name.Text);
                addPaymentTypeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Payment_Type.Text = "Added successfully";

                _sqlCon.Close();
                Response.Redirect("Payment_Type_List.aspx");
            }
        }

        protected void btn_Back_To_Payment_Type_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Payment_Type_List.aspx");
        }
    }
}