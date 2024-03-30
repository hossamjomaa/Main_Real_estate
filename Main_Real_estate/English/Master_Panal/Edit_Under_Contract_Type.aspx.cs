using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Under_Under_Contract_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string underContractTypeId = Request.QueryString["Id"];
                DataTable getUnderContractTypeDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getUnderContractTypeCmd = new MySqlCommand(
                    "SELECT Under_Contract_Id , Under_Contractt_English_Type , Under_Contract_Arabic_Type  FROM under_contract WHERE Under_Contract_Id = @ID",
                    _sqlCon);
                MySqlDataAdapter getUnderContractTypeDa = new MySqlDataAdapter(getUnderContractTypeCmd);

                getUnderContractTypeCmd.Parameters.AddWithValue("@ID", underContractTypeId);
                getUnderContractTypeDa.Fill(getUnderContractTypeDt);
                if (getUnderContractTypeDt.Rows.Count > 0)
                {
                    txt_En_Under_Contract_Type_Name.Text =
                        getUnderContractTypeDt.Rows[0]["Under_Contractt_English_Type"].ToString();
                    txt_Ar_Under_Contract_Type_Name.Text =
                        getUnderContractTypeDt.Rows[0]["Under_Contract_Arabic_Type"].ToString();
                    lbl_Name_Of_Under_Contract_Type.Text =
                        getUnderContractTypeDt.Rows[0]["Under_Contract_Arabic_Type"].ToString();
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Edit_Under_Contract_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string underContractTypeId = Request.QueryString["Id"];
                string updateUnderContractTypeQuary =
                    "UPDATE under_contract SET Under_Contractt_English_Type=@Under_Contractt_English_Type , Under_Contract_Arabic_Type=@Under_Contract_Arabic_Type  WHERE Under_Contract_Id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateUnderContractTypeCmd =
                    new MySqlCommand(updateUnderContractTypeQuary, _sqlCon);
                updateUnderContractTypeCmd.Parameters.AddWithValue("@ID", underContractTypeId);
                updateUnderContractTypeCmd.Parameters.AddWithValue("@Under_Contractt_English_Type",
                    txt_En_Under_Contract_Type_Name.Text);
                updateUnderContractTypeCmd.Parameters.AddWithValue("@Under_Contract_Arabic_Type",
                    txt_Ar_Under_Contract_Type_Name.Text);
                updateUnderContractTypeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_New_Under_Contract_Type.Text = "Edit successfully";
                Response.Redirect("Under_Contract_Type_List.aspx");
            }
        }

        protected void btn_Back_To_Under_Contract_Type_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Under_Contract_Type_List.aspx");
        }
    }
}