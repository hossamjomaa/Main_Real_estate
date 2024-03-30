using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Under_Under_Contract_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Add_Under_Contract_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addUnderContractTypeQuary =
                    "Insert Into under_contract (Under_Contractt_English_Type,Under_Contract_Arabic_Type) VALUES(@Under_Contractt_English_Type,@Under_Contract_Arabic_Type)";
                _sqlCon.Open();
                MySqlCommand addUnderContractTypeCmd = new MySqlCommand(addUnderContractTypeQuary, _sqlCon);
                addUnderContractTypeCmd.Parameters.AddWithValue("@Under_Contractt_English_Type",
                    txt_En_Under_Contract_Type_Name.Text);
                addUnderContractTypeCmd.Parameters.AddWithValue("@Under_Contract_Arabic_Type",
                    txt_Ar_Under_Contract_Type_Name.Text);
                addUnderContractTypeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Under_Contract_Type.Text = "Added successfully";

                _sqlCon.Close();
                Response.Redirect("Under_Contract_Type_List.aspx");
            }
        }

        protected void btn_Back_To_Under_Contract_Type_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Under_Contract_Type_List.aspx");
        }
    }
}