using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Maintenance_SubType : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Helper.LoadDropDownList("SELECT * FROM maintenance_categoty where Main_Categoty = 0",
                    _sqlCon, Maintenance_Types_DropDownList, "Categoty_AR", "Categoty_Id");
                Maintenance_Types_DropDownList.Items.Insert(0, "إختر نوع الصيانة ....");
                //*************************************************************************************************************************************
                string MaintenanceSubtypesId = Request.QueryString["Id"];
                DataTable getMaintenanceSubtypesDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getMaintenanceSubtypesCmd =
                    new MySqlCommand(
                        "SELECT * FROM maintenance_categoty" +
                        " WHERE Categoty_Id = @ID",
                        _sqlCon);
                MySqlDataAdapter getMaintenanceSubtypesDa = new MySqlDataAdapter(getMaintenanceSubtypesCmd);

                getMaintenanceSubtypesCmd.Parameters.AddWithValue("@ID", MaintenanceSubtypesId);
                getMaintenanceSubtypesDa.Fill(getMaintenanceSubtypesDt);
                if (getMaintenanceSubtypesDt.Rows.Count > 0)
                {
                    Maintenance_Types_DropDownList.SelectedValue = getMaintenanceSubtypesDt.Rows[0]["Main_Categoty"].ToString();
                    txt_En_Maintenance_Subtypes_Name.Text = getMaintenanceSubtypesDt.Rows[0]["Categoty_En"].ToString();
                    txt_Ar_Maintenance_Subtypes_Name.Text = getMaintenanceSubtypesDt.Rows[0]["Categoty_AR"].ToString();
                    lbl_Name_Of_Maintenance_Subtypes.Text = getMaintenanceSubtypesDt.Rows[0]["Categoty_AR"].ToString();
                }
                _sqlCon.Close();
            }
        }
        protected void btn_Edit_Maintenance_Subtypes_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string MaintenanceSubtypesId = Request.QueryString["Id"];
                string updateAssetTupeQuary =
                    "UPDATE maintenance_categoty SET Main_Categoty=@Main_Categoty , Categoty_En=@Categoty_En , Categoty_AR=@Categoty_AR , Active=@Active  " +
                    "WHERE Categoty_Id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateMaintenanceSubtypesCmd = new MySqlCommand(updateAssetTupeQuary, _sqlCon);
                updateMaintenanceSubtypesCmd.Parameters.AddWithValue("@ID", MaintenanceSubtypesId);
                updateMaintenanceSubtypesCmd.Parameters.AddWithValue("@Categoty_En", txt_En_Maintenance_Subtypes_Name.Text);
                updateMaintenanceSubtypesCmd.Parameters.AddWithValue("@Categoty_AR", txt_Ar_Maintenance_Subtypes_Name.Text);
                updateMaintenanceSubtypesCmd.Parameters.AddWithValue("@Main_Categoty", Maintenance_Types_DropDownList.SelectedValue);
                updateMaintenanceSubtypesCmd.Parameters.AddWithValue("@Active", 1);
                updateMaintenanceSubtypesCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_New_Maintenance_Subtypes.Text = "تمت التعديل بنجاح";
                Response.Redirect("Maintenance_SubType_List.aspx");
            }
        }
        protected void btn_Back_To_Maintenance_Subtypes_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Maintenance_SubType_List.aspx");
        }
    }
}