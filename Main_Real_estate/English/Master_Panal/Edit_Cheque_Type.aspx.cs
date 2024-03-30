using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Cheque_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string chequeTypeId = Request.QueryString["Id"];
                DataTable getChequeTypeDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getChequeTypeCmd =
                    new MySqlCommand(
                        "SELECT cheque_Type_id , cheque_English_Type , cheque_Arabic_Type  FROM cheque_Type WHERE cheque_Type_id = @ID",
                        _sqlCon);
                MySqlDataAdapter getChequeTypeDa = new MySqlDataAdapter(getChequeTypeCmd);

                getChequeTypeCmd.Parameters.AddWithValue("@ID", chequeTypeId);
                getChequeTypeDa.Fill(getChequeTypeDt);
                if (getChequeTypeDt.Rows.Count > 0)
                {
                    txt_En_cheque_Type_Name.Text = getChequeTypeDt.Rows[0]["cheque_English_Type"].ToString();
                    txt_Ar_cheque_Type_Name.Text = getChequeTypeDt.Rows[0]["cheque_Arabic_Type"].ToString();
                    lbl_Name_Of_cheque_Type.Text = getChequeTypeDt.Rows[0]["cheque_Arabic_Type"].ToString();
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Back_To_cheque_Type_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("cheque_Type_List.aspx");
        }

        protected void btn_Edit_cheque_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string chequeTypeId = Request.QueryString["Id"];
                string updateChequeTupeQuary =
                    "UPDATE cheque_Type SET cheque_English_Type=@cheque_English_Type , cheque_Arabic_Type=@cheque_Arabic_Type  WHERE cheque_Type_id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateChequeTypeCmd = new MySqlCommand(updateChequeTupeQuary, _sqlCon);
                updateChequeTypeCmd.Parameters.AddWithValue("@ID", chequeTypeId);
                updateChequeTypeCmd.Parameters.AddWithValue("@cheque_English_Type", txt_En_cheque_Type_Name.Text);
                updateChequeTypeCmd.Parameters.AddWithValue("@cheque_Arabic_Type", txt_Ar_cheque_Type_Name.Text);
                updateChequeTypeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_New_cheque_Type.Text = "Edit successfully";
                Response.Redirect("cheque_Type_List.aspx");
            }
        }
    }
}