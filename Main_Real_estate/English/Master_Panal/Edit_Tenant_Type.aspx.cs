using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Tenant_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string tenantTypeId = Request.QueryString["Id"];
                DataTable getTenantTypeDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getTenantTypeCmd =
                    new MySqlCommand(
                        "SELECT Tenant_Type_id , Tenant_English_Type , Tenant_Arabic_Type  FROM Tenant_Type WHERE Tenant_Type_id = @ID",
                        _sqlCon);
                MySqlDataAdapter getTenantTypeDa = new MySqlDataAdapter(getTenantTypeCmd);

                getTenantTypeCmd.Parameters.AddWithValue("@ID", tenantTypeId);
                getTenantTypeDa.Fill(getTenantTypeDt);
                if (getTenantTypeDt.Rows.Count > 0)
                {
                    txt_En_Tenant_Type_Name.Text = getTenantTypeDt.Rows[0]["Tenant_English_Type"].ToString();
                    txt_Ar_Tenant_Type_Name.Text = getTenantTypeDt.Rows[0]["Tenant_Arabic_Type"].ToString();
                    lbl_Name_Of_Tenant_Type.Text = getTenantTypeDt.Rows[0]["Tenant_Arabic_Type"].ToString();
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Back_To_Tenant_Type_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tenant_Type_List.aspx");
        }

        protected void btn_Edit_Tenant_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string tenantTypeId = Request.QueryString["Id"];
                string updateTenantTypeQuary =
                    "UPDATE Tenant_Type SET Tenant_English_Type=@Tenant_English_Type , Tenant_Arabic_Type=@Tenant_Arabic_Type  WHERE Tenant_Type_id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateTenantTypeCmd = new MySqlCommand(updateTenantTypeQuary, _sqlCon);
                updateTenantTypeCmd.Parameters.AddWithValue("@ID", tenantTypeId);
                updateTenantTypeCmd.Parameters.AddWithValue("@Tenant_English_Type", txt_En_Tenant_Type_Name.Text);
                updateTenantTypeCmd.Parameters.AddWithValue("@Tenant_Arabic_Type", txt_Ar_Tenant_Type_Name.Text);
                updateTenantTypeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_New_Tenant_Type.Text = "Edit successfully";
                Response.Redirect("Tenant_Type_List.aspx");
            }
        }
    }
}