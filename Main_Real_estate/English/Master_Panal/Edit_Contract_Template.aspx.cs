using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Contract_Template : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string contractTemplateId = Request.QueryString["Id"];
                DataTable getContractTemplateDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getContractTemplateCmd = new MySqlCommand(
                    "SELECT Contract_Template_id , Contract_English_Template , Contract_Arabic_Template  FROM Contract_Template WHERE Contract_Template_id = @ID",
                    _sqlCon);
                MySqlDataAdapter getContractTemplateDa = new MySqlDataAdapter(getContractTemplateCmd);

                getContractTemplateCmd.Parameters.AddWithValue("@ID", contractTemplateId);
                getContractTemplateDa.Fill(getContractTemplateDt);
                if (getContractTemplateDt.Rows.Count > 0)
                {
                    txt_En_Contract_Template_Name.Text =
                        getContractTemplateDt.Rows[0]["Contract_English_Template"].ToString();
                    txt_Ar_Contract_Template_Name.Text =
                        getContractTemplateDt.Rows[0]["Contract_Arabic_Template"].ToString();
                    lbl_Name_Of_Contract_Template.Text =
                        getContractTemplateDt.Rows[0]["Contract_Arabic_Template"].ToString();
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Back_To_Contract_Template_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contract_Template_List.aspx");
        }

        protected void btn_Edit_Contract_Template_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string contractTemplateId = Request.QueryString["Id"];
                string updateContractTemplateQuary =
                    "UPDATE Contract_Template SET Contract_English_Template=@Contract_English_Template , Contract_Arabic_Template=@Contract_Arabic_Template  WHERE Contract_Template_id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateContractTemplateCmd = new MySqlCommand(updateContractTemplateQuary, _sqlCon);
                updateContractTemplateCmd.Parameters.AddWithValue("@ID", contractTemplateId);
                updateContractTemplateCmd.Parameters.AddWithValue("@Contract_English_Template",
                    txt_En_Contract_Template_Name.Text);
                updateContractTemplateCmd.Parameters.AddWithValue("@Contract_Arabic_Template",
                    txt_Ar_Contract_Template_Name.Text);
                updateContractTemplateCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_New_Contract_Template.Text = "Edit successfully";
                Response.Redirect("Contract_Template_List.aspx");
            }
        }
    }
}