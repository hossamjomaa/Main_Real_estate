using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Building_Condition : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Add_Building_Condition_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addBuildingConditionQuary =
                    "Insert Into Building_Condition (Building_English_Condition,Building_Arabic_Condition) VALUES(@Building_English_Condition,@Building_Arabic_Condition)";
                _sqlCon.Open();
                MySqlCommand addBuildingConditionCmd = new MySqlCommand(addBuildingConditionQuary, _sqlCon);
                addBuildingConditionCmd.Parameters.AddWithValue("@Building_English_Condition",
                    txt_En_Building_Condition_Name.Text);
                addBuildingConditionCmd.Parameters.AddWithValue("@Building_Arabic_Condition",
                    txt_Ar_Building_Condition_Name.Text);
                addBuildingConditionCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Building_Condition.Text = "Added successfully";

                _sqlCon.Close();

                Response.Redirect("Building_Condition_List.aspx");
            }
        }

        protected void btn_Back_To_Ownership_statu_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Building_Condition_List.aspx");
        }
    }
}