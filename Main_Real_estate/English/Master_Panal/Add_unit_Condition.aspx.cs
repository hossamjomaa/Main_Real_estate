using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Unit_Condition : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Add_Unit_Condition_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addUnitConditionQuar =
                    "Insert Into Unit_Condition (Unit_English_Condition,Unit_Arabic_Condition) VALUES(@Unit_English_Condition,@Unit_Arabic_Condition)";
                _sqlCon.Open();
                MySqlCommand addUnitConditionCmd = new MySqlCommand(addUnitConditionQuar, _sqlCon);
                addUnitConditionCmd.Parameters.AddWithValue("@Unit_English_Condition",
                    txt_En_Unit_Condition_Name.Text);
                addUnitConditionCmd.Parameters.AddWithValue("@Unit_Arabic_Condition",
                    txt_Ar_Unit_Condition_Name.Text);
                addUnitConditionCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Unit_Condition.Text = "Added successfully";

                _sqlCon.Close();
                Response.Redirect("Unit_Condition_List.aspx");
            }
        }

        protected void btn_Back_To_Unit_Condition_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Unit_Condition_List.aspx");
        }
    }
}