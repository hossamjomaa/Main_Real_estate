using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.IO;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Contractor : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Add_contractor_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addcontractorQuary =
                    "Insert Into contractor (" +
                    "Contractor_Ar_Name," +
                    "Contractor_En_Name," +
                    "Contractor_Company_Name," +
                    "Contractor_Company_Address," +
                    "Contractor_Phon) " +
                    "VALUES(" +
                    "@Contractor_Ar_Name," +
                    "@Contractor_En_Name," +
                    "@Contractor_Company_Name," +
                    "@Contractor_Company_Address," +
                    "@Contractor_Phon) ";
                _sqlCon.Open();
                using (MySqlCommand addcontractorCmd = new MySqlCommand(addcontractorQuary, _sqlCon))
                {
                    addcontractorCmd.Parameters.AddWithValue("@Contractor_Ar_Name", txt_Ar_contractor_Name.Text);
                    addcontractorCmd.Parameters.AddWithValue("@Contractor_En_Name", txt_En_contractor_Name.Text);
                    addcontractorCmd.Parameters.AddWithValue("@Contractor_Company_Name", txt_Company_Name.Text);
                    addcontractorCmd.Parameters.AddWithValue("@Contractor_Company_Address", txt_Company_Address.Text);
                    addcontractorCmd.Parameters.AddWithValue("@Contractor_Phon", txt_contractor_tell.Text);


                    addcontractorCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                    lbl_Success_Add_New_contractor.Text = "تمت الإضافة بنجاح";
                    Response.Redirect("contractor_List.aspx");
                }
            }
        }

        protected void btn_Back_To_contractor_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("contractor_List.aspx");
        }
    }
}