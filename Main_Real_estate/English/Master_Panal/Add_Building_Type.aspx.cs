using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Building_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Add_Building_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addBuildingTypeQuary =
                    "Insert Into Building_Type (Building_English_Type,Building_Arabic_Type) VALUES(@Building_English_Type,@Building_Arabic_Type)";
                _sqlCon.Open();
                MySqlCommand addBuildingTypeCmd = new MySqlCommand(addBuildingTypeQuary, _sqlCon);
                addBuildingTypeCmd.Parameters.AddWithValue("@Building_English_Type", txt_En_Building_Type_Name.Text);
                addBuildingTypeCmd.Parameters.AddWithValue("@Building_Arabic_Type", txt_Ar_Building_Type_Name.Text);
                addBuildingTypeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Building_Type.Text = "Added successfully";

                _sqlCon.Close();
                Response.Redirect("Building_Type_List.aspx");
            }
        }

        protected void btn_Back_To_Ownership_statu_List_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Building_Type_List.aspx");
        }
    }
}