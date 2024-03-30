using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Tenant_Datials : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Customer_Affairs", 0, "R");
                Utilities.Roles.Edit_permission(_sqlCon, Session["Role"].ToString(), "Customer_Affairs", Delete_Tenant);
                Utilities.Roles.Delete_permission(_sqlCon, Session["Role"].ToString(), "Customer_Affairs", Edit_Tenant);
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            _sqlCon.Open();
            string tenantId = Request.QueryString["Id"];
            using (MySqlCommand tenantDetailsCmd = new MySqlCommand("Tenant_Details", _sqlCon))
            {
                tenantDetailsCmd.CommandType = CommandType.StoredProcedure;
                tenantDetailsCmd.Parameters.AddWithValue("@Id", tenantId);
                using (MySqlDataAdapter tenantDetailsSda = new MySqlDataAdapter(tenantDetailsCmd))
                {
                    DataTable tenantDetailsDt = new DataTable();
                    tenantDetailsSda.Fill(tenantDetailsDt);
                    lbl_Details_Tenant_Name.Text =
                        "المستأجر " + tenantDetailsDt.Rows[0]["Tenants_Arabic_Name"].ToString();
                    lbl_Dtl_Tenant_En_Name.Text = tenantDetailsDt.Rows[0]["Tenants_English_Name"].ToString();
                    lbl_Dtl_Tenant_Ar_Name.Text = tenantDetailsDt.Rows[0]["Tenants_Arabic_Name"].ToString();
                    lbl_Dtl_Tenant_tell.Text = tenantDetailsDt.Rows[0]["Tenants_Tell"].ToString();
                    lbl_Dtl_Tenant_Moblie.Text = tenantDetailsDt.Rows[0]["Tenants_Mobile"].ToString();
                    lbl_Dtl_Tenant_Fax.Text = tenantDetailsDt.Rows[0]["Tenants_Fax"].ToString();
                    lbl_Dtl_Tenant_Email.Text = tenantDetailsDt.Rows[0]["Tenants_Email"].ToString();
                    lbl_Dtl_Tenant_Address.Text = tenantDetailsDt.Rows[0]["Tenants_Address"].ToString();

                    lbl_Dtl_ID_NO.Text = tenantDetailsDt.Rows[0]["ID_NO"].ToString();
                    lbl_Dtl_ID_Expiry.Text = tenantDetailsDt.Rows[0]["ID_Expiry"].ToString();

                    lbl_Dtl_Tenant_type.Text = tenantDetailsDt.Rows[0]["Tenant_Arabic_Type"].ToString();

                    if (tenantDetailsDt.Rows[0]["tenant_type_Tenant_Type_Id"].ToString() == "1")
                    {
                        lbl_Title_Tenant_Nationality_Or_business_records.Text = "جنسية المستأجر :";
                        lbl_Dtl_Tenant_Nationality_Or_business_records.Text =
                            tenantDetailsDt.Rows[0]["Arabic_nationality"].ToString();

                        lbl_Title_Nationality_Address_Or_P_O_Box.Text = "العنوان في البلد الأصل :";
                        lbl_Dtl_Tenant_Nationality_Address_Or_P_O_Box.Text =
                            tenantDetailsDt.Rows[0]["Tenants_Nationality_Address"].ToString();
                    }
                    else if (tenantDetailsDt.Rows[0]["tenant_type_Tenant_Type_Id"].ToString() == "2")
                    {
                        lbl_Title_Tenant_Nationality_Or_business_records.Text = "السجل التجاري :";
                        lbl_Dtl_Tenant_Nationality_Or_business_records.Text =
                            tenantDetailsDt.Rows[0]["business_records"].ToString();

                        lbl_Title_Nationality_Address_Or_P_O_Box.Text = "صندوق بريد :";
                        lbl_Dtl_Tenant_Nationality_Address_Or_P_O_Box.Text =
                            tenantDetailsDt.Rows[0]["P_O_Box"].ToString();


                        lbl_Title_Comp_Rep.Text = "ممثل الشركة :";
                        lbl_Dtl_Comp_Rep.Text = tenantDetailsDt.Rows[0]["Com_rep_Ar_Name"].ToString();
                    }

                    lbl_Link_Tenants_QId.Text = tenantDetailsDt.Rows[0]["Tenants_QId"].ToString();
                    Link_Tenants_QId.HRef = tenantDetailsDt.Rows[0]["Tenants_QId_Path"].ToString();
                    Link_Tenants_QId.Target = "_blank";

                    if (lbl_Link_Tenants_QId.Text == "No File")
                    {
                        Link_Tenants_QId.Visible = false;
                    }

                    lbl_Link_PassPort.Text = tenantDetailsDt.Rows[0]["PassPort"].ToString();
                    Link_PassPort.HRef = tenantDetailsDt.Rows[0]["PassPort_Path"].ToString();
                    Link_PassPort.Target = "_blank";

                    if (lbl_Link_PassPort.Text == "No File")
                    {
                        Link_PassPort.Visible = false;
                    }
                }
            }
        }

        protected void btn_Back_To_Tenant_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tenant_List.aspx");
        }
        protected void Delete_Tenant_Click(object sender, EventArgs e)
        {
            try
            {
                string tenantId = Request.QueryString["Id"];
                _sqlCon.Open();
                string deleteTenantQuary = "DELETE FROM tenants WHERE Tenants_ID=@ID ";
                MySqlCommand deleteTenantCmd = new MySqlCommand(deleteTenantQuary, _sqlCon);
                deleteTenantCmd.Parameters.AddWithValue("@ID", tenantId);
                deleteTenantCmd.ExecuteNonQuery();
                _sqlCon.Close();
                Response.Redirect(Request.RawUrl);
            }
            catch
            {
                Response.Write(@"<script language='javascript'>alert('This Tenant Cannot Be Removed!!! ')</script>");
            }
        }

        protected void Edit_Tenant_Click(object sender, EventArgs e)
        {
            string tenantId = Request.QueryString["Id"];
            Response.Redirect("Edit_Tenant.aspx?Id=" + tenantId);
        }
    }
}