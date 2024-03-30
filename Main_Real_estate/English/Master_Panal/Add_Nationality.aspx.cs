using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Nationality : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Add_nationality_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addNationalityQuary =
                    "Insert Into nationality (English_nationality,Arabic_nationality) VALUES(@English_nationality,@Arabic_nationality)";
                _sqlCon.Open();
                MySqlCommand addNationalityCmd = new MySqlCommand(addNationalityQuary, _sqlCon);
                addNationalityCmd.Parameters.AddWithValue("@English_nationality", txt_En_nationality_Name.Text);
                addNationalityCmd.Parameters.AddWithValue("@Arabic_nationality", txt_Ar_nationality_Name.Text);
                addNationalityCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_nationality.Text = "تمت الإضافة بنجاح";

                _sqlCon.Close();
                Response.Redirect("nationality_List.aspx");
            }
        }

        protected void btn_Back_To_nationality_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("nationality_List.aspx");
        }
    }
}