using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Contractor : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string ContractorId = Request.QueryString["Id"];
                DataTable getContractorDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getContractorCmd = new MySqlCommand("SELECT * FROM contractor WHERE Contractor_ID = @ID",
                        _sqlCon);
                MySqlDataAdapter getContractorDa = new MySqlDataAdapter(getContractorCmd);

                getContractorCmd.Parameters.AddWithValue("@ID", ContractorId);
                getContractorDa.Fill(getContractorDt);
                if (getContractorDt.Rows.Count > 0)
                {
                    txt_Ar_contractor_Name.Text = getContractorDt.Rows[0]["Contractor_Ar_Name"].ToString();
                    txt_En_contractor_Name.Text = getContractorDt.Rows[0]["Contractor_En_Name"].ToString();
                    txt_Company_Name.Text = getContractorDt.Rows[0]["Contractor_Company_Name"].ToString();
                    txt_Company_Editress.Text = getContractorDt.Rows[0]["Contractor_Company_Address"].ToString();
                    txt_contractor_tell.Text = getContractorDt.Rows[0]["Contractor_Phon"].ToString();
                }

                _sqlCon.Close();
            }
        }
        protected void btn_Edit_contractor_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string ContractorId = Request.QueryString["Id"];

                string updateContractorQuary =
                    "UPDATE contractor SET " +
                    "Contractor_Ar_Name=@Contractor_Ar_Name , " +
                    "Contractor_En_Name=@Contractor_En_Name , " +
                    "Contractor_Company_Name=@Contractor_Company_Name, " +
                    "Contractor_Company_Address=@Contractor_Company_Address , " +
                    "Contractor_Phon=@Contractor_Phon " +
                    " WHERE Contractor_ID=@ID ";
                _sqlCon.Open();
                MySqlCommand updateContractorCmd = new MySqlCommand(updateContractorQuary, _sqlCon);
                updateContractorCmd.Parameters.AddWithValue("@ID", ContractorId);
                updateContractorCmd.Parameters.AddWithValue("@Contractor_En_Name", txt_En_contractor_Name.Text);
                updateContractorCmd.Parameters.AddWithValue("@Contractor_Ar_Name", txt_Ar_contractor_Name.Text);
                updateContractorCmd.Parameters.AddWithValue("@Contractor_Company_Name", txt_Company_Name.Text);
                updateContractorCmd.Parameters.AddWithValue("@Contractor_Company_Address", txt_Company_Editress.Text);
                updateContractorCmd.Parameters.AddWithValue("@Contractor_Phon", txt_contractor_tell.Text);
                updateContractorCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_contractor.Text = "تم التعديل بنجاح";
                Response.Redirect("Contractor_List.aspx");
            }
        }

        protected void btn_Back_To_contractor_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contractor_List.aspx");
        }
    }
}