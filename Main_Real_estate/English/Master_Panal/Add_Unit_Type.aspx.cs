using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Unit_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Add_Unit_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addUnitTypeQuary =
                    "Insert Into Unit_Type (Unit_English_Type,Unit_Arabic_Type) VALUES(@Unit_English_Type,@Unit_Arabic_Type)";
                _sqlCon.Open();
                MySqlCommand addUnitTypeCmd = new MySqlCommand(addUnitTypeQuary, _sqlCon);
                addUnitTypeCmd.Parameters.AddWithValue("@Unit_English_Type", txt_En_Unit_Type_Name.Text);
                addUnitTypeCmd.Parameters.AddWithValue("@Unit_Arabic_Type", txt_Ar_Unit_Type_Name.Text);
                addUnitTypeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Unit_Type.Text = "Added successfully";

                _sqlCon.Close();
                Response.Redirect("Unit_Type_List.aspx");
            }
        }

        protected void btn_Back_To_Unit_Type_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Unit_Type_List.aspx");
        }
    }
}