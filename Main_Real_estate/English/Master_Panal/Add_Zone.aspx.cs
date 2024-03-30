using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal.Owners_QID
{
    public partial class Add_Zone : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Back_To_Zone_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Zone_List.aspx");
        }

        protected void btn_Add_Zone_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addZoneQuary =
                    "Insert Into zone (zone_English_name,zone_arabic_name,zone_number) VALUES(@zone_English_name,@zone_arabic_name,@zone_number)";
                _sqlCon.Open();
                MySqlCommand addZoneCmd = new MySqlCommand(addZoneQuary, _sqlCon);
                addZoneCmd.Parameters.AddWithValue("@zone_English_name", txt_En_Zone_Name.Text);
                addZoneCmd.Parameters.AddWithValue("@zone_arabic_name", txt_Ar_Zone_Name.Text);
                addZoneCmd.Parameters.AddWithValue("@zone_number", Convert.ToInt32(txt_Zone_Number.Text));
                addZoneCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Zone.Text = "Added successfully";
            }
        }

    }
}