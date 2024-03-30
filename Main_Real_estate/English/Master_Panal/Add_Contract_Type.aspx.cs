using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Contract_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void btn_Add_Contract_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addContractTypeQuary =
                    "Insert Into Contract_Type (Contract_English_Type,Contract_Arabic_Type) VALUES(@Contract_English_Type,@Contract_Arabic_Type)";
                _sqlCon.Open();
                MySqlCommand addContractTypeCmd = new MySqlCommand(addContractTypeQuary, _sqlCon);
                addContractTypeCmd.Parameters.AddWithValue("@Contract_English_Type", txt_En_Contract_Type_Name.Text);
                addContractTypeCmd.Parameters.AddWithValue("@Contract_Arabic_Type", txt_Ar_Contract_Type_Name.Text);
                addContractTypeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Contract_Type.Text = "Added successfully";

                _sqlCon.Close();
                Response.Redirect("Contract_Type_List.aspx");
            }
        }

        protected void btn_Back_To_Contract_Type_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contract_Type_List.aspx");
        }
    }
}