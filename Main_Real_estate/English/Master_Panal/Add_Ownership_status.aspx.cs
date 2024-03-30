using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Ownership_Status : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Back_To_Ownership_statu_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ownership_Status_List.aspx");
        }

        protected void btn_Add_Ownership_Status_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addOwnershipStatusQuary =
                    "Insert Into ownership_status (ownership_english_status,ownership_arabic_status) VALUES(@ownership_english_status,@ownership_arabic_status)";
                _sqlCon.Open();
                MySqlCommand addOwnershipStatusCmd = new MySqlCommand(addOwnershipStatusQuary, _sqlCon);
                addOwnershipStatusCmd.Parameters.AddWithValue("@ownership_english_status",
                    txt_En_Ownership_Status_Name.Text);
                addOwnershipStatusCmd.Parameters.AddWithValue("@ownership_arabic_status",
                    txt_Ar_Ownership_Status_Name.Text);
                addOwnershipStatusCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Ownership_Status.Text = "Added successfully";

                _sqlCon.Close();
                Response.Redirect("Ownership_Status_List.aspx");
            }
        }
    }
}