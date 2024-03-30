using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Contract_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string contractTypeId = Request.QueryString["Id"];
                DataTable getContractTypeDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getContractTypeCmd =
                    new MySqlCommand(
                        "SELECT Contract_Type_id , Contract_English_Type , Contract_Arabic_Type  FROM Contract_Type WHERE Contract_Type_id = @ID",
                        _sqlCon);
                MySqlDataAdapter getContractTypeDa = new MySqlDataAdapter(getContractTypeCmd);

                getContractTypeCmd.Parameters.AddWithValue("@ID", contractTypeId);
                getContractTypeDa.Fill(getContractTypeDt);
                if (getContractTypeDt.Rows.Count > 0)
                {
                    txt_En_Contract_Type_Name.Text = getContractTypeDt.Rows[0]["Contract_English_Type"].ToString();
                    txt_Ar_Contract_Type_Name.Text = getContractTypeDt.Rows[0]["Contract_Arabic_Type"].ToString();
                    lbl_Name_Of_Contract_Type.Text = getContractTypeDt.Rows[0]["Contract_English_Type"].ToString();
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Back_To_Contract_Type_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contract_Type_List.aspx");
        }

        protected void btn_Edit_Contract_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string contractTypeId = Request.QueryString["Id"];
                string updateContractTypeQuary =
                    "UPDATE Contract_Type SET Contract_English_Type=@Contract_English_Type , Contract_Arabic_Type=@Contract_Arabic_Type  WHERE Contract_Type_id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateContractTypeCmd = new MySqlCommand(updateContractTypeQuary, _sqlCon);
                updateContractTypeCmd.Parameters.AddWithValue("@ID", contractTypeId);
                updateContractTypeCmd.Parameters.AddWithValue("@Contract_English_Type",
                    txt_En_Contract_Type_Name.Text);
                updateContractTypeCmd.Parameters.AddWithValue("@Contract_Arabic_Type",
                    txt_Ar_Contract_Type_Name.Text);
                updateContractTypeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_New_Contract_Type.Text = "Edit successfully";
                Response.Redirect("Contract_Type_List.aspx");
            }
        }
    }
}