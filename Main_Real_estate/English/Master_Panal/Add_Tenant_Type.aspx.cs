using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal.Owners_QID
{
    public partial class Tenant_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Add_Tenant_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addTenantTypeQuary =
                    "Insert Into Tenant_Type (Tenant_English_Type,Tenant_Arabic_Type) VALUES(@Tenant_English_Type,@Tenant_Arabic_Type)";
                _sqlCon.Open();
                MySqlCommand addTenantTypeCmd = new MySqlCommand(addTenantTypeQuary, _sqlCon);
                addTenantTypeCmd.Parameters.AddWithValue("@Tenant_English_Type", txt_En_Tenant_Type_Name.Text);
                addTenantTypeCmd.Parameters.AddWithValue("@Tenant_Arabic_Type", txt_Ar_Tenant_Type_Name.Text);
                addTenantTypeCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Tenant_Type.Text = "Added successfully";

                _sqlCon.Close();
                Response.Redirect("Tenant_Type_List.aspx");
            }
        }

        protected void btn_Back_To_Tenant_Type_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tenant_Type_List.aspx");
        }
    }
}