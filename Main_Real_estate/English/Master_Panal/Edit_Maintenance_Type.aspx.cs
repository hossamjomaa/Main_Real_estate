using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;


namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Maintenance_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string MaintenanceTypeId = Request.QueryString["Id"];
                DataTable getMaintenanceTypeDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getMaintenanceTypeCmd =
                    new MySqlCommand(
                        "SELECT * FROM maintenance_categoty WHERE Categoty_Id = @ID",
                        _sqlCon);
                MySqlDataAdapter getMaintenanceTypeDa = new MySqlDataAdapter(getMaintenanceTypeCmd);

                getMaintenanceTypeCmd.Parameters.AddWithValue("@ID", MaintenanceTypeId);
                getMaintenanceTypeDa.Fill(getMaintenanceTypeDt);
                if (getMaintenanceTypeDt.Rows.Count > 0)
                {
                    txt_En_Maintenance_Type_Name.Text =
                        getMaintenanceTypeDt.Rows[0]["Categoty_En"].ToString();
                    txt_Ar_Maintenance_Type_Name.Text =
                        getMaintenanceTypeDt.Rows[0]["Categoty_AR"].ToString();
                    lbl_Name_Of_Maintenance_Type.Text =
                        getMaintenanceTypeDt.Rows[0]["Categoty_AR"].ToString();
                }

                _sqlCon.Close();
            }

        }
        protected void btn_Edit_Maintenance_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string MaintenanceTypeId = Request.QueryString["Id"];
                string updateAssetTupeQuary =
                "UPDATE maintenance_categoty SET Categoty_AR=@Categoty_AR , Categoty_En=@Categoty_En  WHERE Categoty_Id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateMaintenanceTypeCmd = new MySqlCommand(updateAssetTupeQuary, _sqlCon);
                updateMaintenanceTypeCmd.Parameters.AddWithValue("@ID", MaintenanceTypeId);
                updateMaintenanceTypeCmd.Parameters.AddWithValue("@Categoty_En",
                    txt_En_Maintenance_Type_Name.Text);
                updateMaintenanceTypeCmd.Parameters.AddWithValue("@Categoty_AR",
                    txt_Ar_Maintenance_Type_Name.Text);
                updateMaintenanceTypeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_New_Maintenance_Type.Text = "تم التعديل بنجاح";
                Response.Redirect("Maintenance_Type_List.aspx");
            }
        }

        protected void btn_Back_To_Maintenance_Type_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Maintenance_Type_List.aspx");
        }
    }
}