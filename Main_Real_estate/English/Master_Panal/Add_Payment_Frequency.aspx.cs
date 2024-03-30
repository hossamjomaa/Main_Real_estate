using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Payment_Frequency : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Add_Payment_Frequency_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addPaymentFrequencyQuary =
                    "Insert Into Payment_Frequency (Payment_English_Frequency,Payment_Arabic_Frequency) VALUES(@Payment_English_Frequency,@Payment_Arabic_Frequency)";
                _sqlCon.Open();
                MySqlCommand addPaymentFrequencyCmd = new MySqlCommand(addPaymentFrequencyQuary, _sqlCon);
                addPaymentFrequencyCmd.Parameters.AddWithValue("@Payment_English_Frequency",
                    txt_En_Payment_Frequency_Name.Text);
                addPaymentFrequencyCmd.Parameters.AddWithValue("@Payment_Arabic_Frequency",
                    txt_Ar_Payment_Frequency_Name.Text);
                addPaymentFrequencyCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Payment_Frequency.Text = "Added successfully";

                _sqlCon.Close();
                Response.Redirect("Payment_Frequency_List.aspx");
            }
        }

        protected void btn_Back_To_Payment_Frequency_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Payment_Frequency_List.aspx");
        }
    }
}