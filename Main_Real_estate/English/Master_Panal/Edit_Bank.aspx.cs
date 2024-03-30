using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Bank : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string bankId = Request.QueryString["Id"];
                DataTable getBankDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getBankCmd =
                    new MySqlCommand(
                        "SELECT Bank_Id , Bank_English_name , Bank_arabic_name  FROM Bank WHERE Bank_Id = @ID", _sqlCon);
                MySqlDataAdapter getBankDa = new MySqlDataAdapter(getBankCmd);

                getBankCmd.Parameters.AddWithValue("@ID", bankId);
                getBankDa.Fill(getBankDt);
                if (getBankDt.Rows.Count > 0)
                {
                    txt_En_Bank_Name.Text = getBankDt.Rows[0]["Bank_English_name"].ToString();
                    txt_Ar_Bank_Name.Text = getBankDt.Rows[0]["Bank_arabic_name"].ToString();
                    lbl_titel_Name_Edit_Bank.Text = getBankDt.Rows[0]["Bank_arabic_name"].ToString();
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Back_To_Bank_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Bank_List.aspx");
        }

        protected void btn_Add_Bank_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string bankId = Request.QueryString["Id"];
                string updateBankQuary =
                    "UPDATE Bank SET Bank_English_name=@Bank_English_name , Bank_arabic_name=@Bank_arabic_name  WHERE Bank_Id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateBankCmd = new MySqlCommand(updateBankQuary, _sqlCon);
                updateBankCmd.Parameters.AddWithValue("@ID", bankId);
                updateBankCmd.Parameters.AddWithValue("@Bank_English_name", txt_En_Bank_Name.Text);
                updateBankCmd.Parameters.AddWithValue("@Bank_arabic_name", txt_Ar_Bank_Name.Text);
                updateBankCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_Bank.Text = "Edit successfully";
                Response.Redirect("Bank_List.aspx");
            }
        }
    }
}