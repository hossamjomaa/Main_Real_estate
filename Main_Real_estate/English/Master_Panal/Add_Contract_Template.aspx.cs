using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Contract_Template : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Add_Contract_Template_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addContractTemplateQuary =
                    "Insert Into Contract_Template (Contract_English_Template,Contract_Arabic_Template) VALUES(@Contract_English_Template,@Contract_Arabic_Template)";
                _sqlCon.Open();
                MySqlCommand addContractTemplateCmd = new MySqlCommand(addContractTemplateQuary, _sqlCon);
                addContractTemplateCmd.Parameters.AddWithValue("@Contract_English_Template",
                    txt_En_Contract_Template_Name.Text);
                addContractTemplateCmd.Parameters.AddWithValue("@Contract_Arabic_Template",
                    txt_Ar_Contract_Template_Name.Text);
                addContractTemplateCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Contract_Template.Text = "Added successfully";

                _sqlCon.Close();
                Response.Redirect("Contract_Template_List.aspx");
            }
        }

        protected void btn_Back_To_Contract_Template_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contract_Template_List.aspx");
        }
    }
}