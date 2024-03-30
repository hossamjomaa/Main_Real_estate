using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Unit_Details : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Add_Unit_Detail_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addUnitDetailsQuary =
                    "Insert Into Unit_Detail (Unit_English_Detail,Unit_Arabic_Detail) VALUES(@Unit_English_Detail,@Unit_Arabic_Detail)";
                _sqlCon.Open();
                MySqlCommand addUnitDetailsCmd = new MySqlCommand(addUnitDetailsQuary, _sqlCon);
                addUnitDetailsCmd.Parameters.AddWithValue("@Unit_English_Detail", txt_En_Unit_Detail_Name.Text);
                addUnitDetailsCmd.Parameters.AddWithValue("@Unit_Arabic_Detail", txt_Ar_Unit_Detail_Name.Text);
                addUnitDetailsCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Unit_Detail.Text = "Added successfully";

                _sqlCon.Close();
                Response.Redirect("Unit_Details_List.aspx");
            }
        }

        protected void btn_Back_To_Unit_Detail_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Unit_Details_List.aspx");
        }
    }
}