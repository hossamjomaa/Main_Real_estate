using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Unit_Condition : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string unitConditionId = Request.QueryString["Id"];
                DataTable getUnitConditionDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getUnitConditionCmd =
                    new MySqlCommand(
                        "SELECT Unit_Condition_id , Unit_English_Condition , Unit_Arabic_Condition  FROM Unit_Condition WHERE Unit_Condition_id = @ID",
                        _sqlCon);
                MySqlDataAdapter getUnitConditionDa = new MySqlDataAdapter(getUnitConditionCmd);

                getUnitConditionCmd.Parameters.AddWithValue("@ID", unitConditionId);
                getUnitConditionDa.Fill(getUnitConditionDt);
                if (getUnitConditionDt.Rows.Count > 0)
                {
                    txt_En_Unit_Condition_Name.Text =
                        getUnitConditionDt.Rows[0]["Unit_English_Condition"].ToString();
                    txt_Ar_Unit_Condition_Name.Text = getUnitConditionDt.Rows[0]["Unit_Arabic_Condition"].ToString();
                    lbl_Name_Of_Unit_Condition.Text = getUnitConditionDt.Rows[0]["Unit_Arabic_Condition"].ToString();
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Back_To_Unit_Condition_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Unit_Condition_List.aspx");
        }

        protected void btn_Edit_Unit_Condition_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string unitConditionId = Request.QueryString["Id"];
                string updateUnitConditionQuary =
                    "UPDATE Unit_Condition SET Unit_English_Condition=@Unit_English_Condition , Unit_Arabic_Condition=@Unit_Arabic_Condition  WHERE Unit_Condition_id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateUnitConditionCmd = new MySqlCommand(updateUnitConditionQuary, _sqlCon);
                updateUnitConditionCmd.Parameters.AddWithValue("@ID", unitConditionId);
                updateUnitConditionCmd.Parameters.AddWithValue("@Unit_English_Condition",
                    txt_En_Unit_Condition_Name.Text);
                updateUnitConditionCmd.Parameters.AddWithValue("@Unit_Arabic_Condition",
                    txt_Ar_Unit_Condition_Name.Text);
                updateUnitConditionCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_New_Unit_Condition.Text = "Edit successfully";
                Response.Redirect("Unit_Condition_List.aspx");
            }
        }
    }
}