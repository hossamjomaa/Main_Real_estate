using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Unit_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string unitTypeId = Request.QueryString["Id"];
                DataTable getUnitTypeDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getUnitTypeCmd =
                    new MySqlCommand(
                        "SELECT Unit_Type_id , Unit_English_Type , Unit_Arabic_Type  FROM Unit_Type WHERE Unit_Type_id = @ID",
                        _sqlCon);
                MySqlDataAdapter getUnitTypeDa = new MySqlDataAdapter(getUnitTypeCmd);

                getUnitTypeCmd.Parameters.AddWithValue("@ID", unitTypeId);
                getUnitTypeDa.Fill(getUnitTypeDt);
                if (getUnitTypeDt.Rows.Count > 0)
                {
                    txt_En_Unit_Type_Name.Text = getUnitTypeDt.Rows[0]["Unit_English_Type"].ToString();
                    txt_Ar_Unit_Type_Name.Text = getUnitTypeDt.Rows[0]["Unit_Arabic_Type"].ToString();
                    lbl_Name_Of_Unit_Type.Text = getUnitTypeDt.Rows[0]["Unit_Arabic_Type"].ToString();
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Back_To_Unit_Type_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Unit_Type_List.aspx");
        }

        protected void btn_Edit_Unit_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string unitTypeId = Request.QueryString["Id"];
                string quari =
                    "UPDATE Unit_Type SET Unit_English_Type=@Unit_English_Type , Unit_Arabic_Type=@Unit_Arabic_Type  WHERE Unit_Type_id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateUnitTypeCmd = new MySqlCommand(quari, _sqlCon);
                updateUnitTypeCmd.Parameters.AddWithValue("@ID", unitTypeId);
                updateUnitTypeCmd.Parameters.AddWithValue("@Unit_English_Type", txt_En_Unit_Type_Name.Text);
                updateUnitTypeCmd.Parameters.AddWithValue("@Unit_Arabic_Type", txt_Ar_Unit_Type_Name.Text);
                updateUnitTypeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_New_Unit_Type.Text = "Edit successfully";
                Response.Redirect("Unit_Type_List.aspx");
            }
        }
    }
}