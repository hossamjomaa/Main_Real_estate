using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Payment_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string paymentTypeId = Request.QueryString["Id"];
                DataTable getPaymentTypeDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getPaymentTypeCmd =
                    new MySqlCommand(
                        "SELECT Payment_Type_id , Payment_English_Type , Payment_Arabic_Type  FROM Payment_Type WHERE Payment_Type_id = @ID",
                        _sqlCon);
                MySqlDataAdapter getPaymentTypeDa = new MySqlDataAdapter(getPaymentTypeCmd);

                getPaymentTypeCmd.Parameters.AddWithValue("@ID", paymentTypeId);
                getPaymentTypeDa.Fill(getPaymentTypeDt);
                if (getPaymentTypeDt.Rows.Count > 0)
                {
                    txt_En_Payment_Type_Name.Text = getPaymentTypeDt.Rows[0]["Payment_English_Type"].ToString();
                    txt_Ar_Payment_Type_Name.Text = getPaymentTypeDt.Rows[0]["Payment_Arabic_Type"].ToString();
                    lbl_Name_Of_Payment_Type.Text = getPaymentTypeDt.Rows[0]["Payment_Arabic_Type"].ToString();
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Edit_Payment_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string paymentTypeId = Request.QueryString["Id"];
                string updatePaymentTypeQuary =
                    "UPDATE Payment_Type SET Payment_English_Type=@Payment_English_Type , Payment_Arabic_Type=@Payment_Arabic_Type  WHERE Payment_Type_id=@ID ";
                _sqlCon.Open();
                MySqlCommand updatePaymentTypeCmd = new MySqlCommand(updatePaymentTypeQuary, _sqlCon);
                updatePaymentTypeCmd.Parameters.AddWithValue("@ID", paymentTypeId);
                updatePaymentTypeCmd.Parameters.AddWithValue("@Payment_English_Type", txt_En_Payment_Type_Name.Text);
                updatePaymentTypeCmd.Parameters.AddWithValue("@Payment_Arabic_Type", txt_Ar_Payment_Type_Name.Text);
                updatePaymentTypeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_New_Payment_Type.Text = "Edit successfully";
                Response.Redirect("Payment_Type_List.aspx");
            }
        }

        protected void btn_Back_To_Payment_Type_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Payment_Type_List.aspx");
        }
    }
}