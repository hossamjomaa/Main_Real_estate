using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Bank : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Back_To_Bank_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Bank_List.aspx");
        }

        protected void btn_Add_Bank_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addBankQuary =  "Insert Into Bank (Bank_English_name,Bank_arabic_name) VALUES(@Bank_English_name,@Bank_arabic_name)";
                _sqlCon.Open();
                MySqlCommand addBankCmd = new MySqlCommand(addBankQuary, _sqlCon);
                addBankCmd.Parameters.AddWithValue("@Bank_English_name", txt_En_Bank_Name.Text);
                addBankCmd.Parameters.AddWithValue("@Bank_arabic_name", txt_Ar_Bank_Name.Text);
                addBankCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Bank.Text = "Added successfully";
                Response.Redirect("Bank_List.aspx");
            }
        }
    }
}