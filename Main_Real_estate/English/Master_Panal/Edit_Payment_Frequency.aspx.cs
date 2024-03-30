using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Payment_Frequency : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string paymentFrequencyId = Request.QueryString["Id"];
                DataTable getPaymentFrequencyDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getPaymentFrequencyCmd = new MySqlCommand(
                    "SELECT Payment_Frequency_id , Payment_English_Frequency , Payment_Arabic_Frequency  FROM Payment_Frequency WHERE Payment_Frequency_id = @ID",
                    _sqlCon);
                MySqlDataAdapter getPaymentFrequencyDa = new MySqlDataAdapter(getPaymentFrequencyCmd);

                getPaymentFrequencyCmd.Parameters.AddWithValue("@ID", paymentFrequencyId);
                getPaymentFrequencyDa.Fill(getPaymentFrequencyDt);
                if (getPaymentFrequencyDt.Rows.Count > 0)
                {
                    txt_En_Payment_Frequency_Name.Text =
                        getPaymentFrequencyDt.Rows[0]["Payment_English_Frequency"].ToString();
                    txt_Ar_Payment_Frequency_Name.Text =
                        getPaymentFrequencyDt.Rows[0]["Payment_Arabic_Frequency"].ToString();
                    lbl_Name_Of_Payment_Frequency.Text =
                        getPaymentFrequencyDt.Rows[0]["Payment_Arabic_Frequency"].ToString();
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Edit_Payment_Frequency_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string paymentFrequencyId = Request.QueryString["Id"];
                string updatePaymentFrequencyQuary =
                    "UPDATE Payment_Frequency SET Payment_English_Frequency=@Payment_English_Frequency , Payment_Arabic_Frequency=@Payment_Arabic_Frequency  WHERE Payment_Frequency_id=@ID ";
                _sqlCon.Open();
                MySqlCommand updatePaymentFrequencyCmd = new MySqlCommand(updatePaymentFrequencyQuary, _sqlCon);
                updatePaymentFrequencyCmd.Parameters.AddWithValue("@ID", paymentFrequencyId);
                updatePaymentFrequencyCmd.Parameters.AddWithValue("@Payment_English_Frequency",
                    txt_En_Payment_Frequency_Name.Text);
                updatePaymentFrequencyCmd.Parameters.AddWithValue("@Payment_Arabic_Frequency",
                    txt_Ar_Payment_Frequency_Name.Text);
                updatePaymentFrequencyCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_New_Payment_Frequency.Text = "Edit successfully";
                Response.Redirect("Payment_Frequency_List.aspx");
            }
        }

        protected void btn_Back_To_Payment_Frequency_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Payment_Frequency_List.aspx");
        }
    }
}