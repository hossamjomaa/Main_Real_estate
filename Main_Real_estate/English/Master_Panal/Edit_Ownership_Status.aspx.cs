using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Ownership_Status : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string ownershipStatusId = Request.QueryString["Id"];
                DataTable getOwnershipStatusDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getOwnershipStatusCmd =
                    new MySqlCommand(
                        "SELECT ownership_status_id , ownership_english_status , ownership_arabic_status  FROM ownership_status WHERE ownership_status_id = @ID",
                        _sqlCon);
                MySqlDataAdapter getOwnershipStatusDa = new MySqlDataAdapter(getOwnershipStatusCmd);

                getOwnershipStatusCmd.Parameters.AddWithValue("@ID", ownershipStatusId);
                getOwnershipStatusDa.Fill(getOwnershipStatusDt);
                if (getOwnershipStatusDt.Rows.Count > 0)
                {
                    txt_En_Ownership_Status_Name.Text =
                        getOwnershipStatusDt.Rows[0]["ownership_english_status"].ToString();
                    txt_Ar_Ownership_Status_Name.Text =
                        getOwnershipStatusDt.Rows[0]["ownership_arabic_status"].ToString();
                    lbl_Name_Of_Ownership_Status.Text =
                        getOwnershipStatusDt.Rows[0]["ownership_arabic_status"].ToString();
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Edit_Ownership_Status_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string ownershipStatusId = Request.QueryString["Id"];
                string updateOwnershipStatusQuary =
                    "UPDATE ownership_status SET ownership_english_status=@ownership_english_status , ownership_arabic_status=@ownership_arabic_status  WHERE ownership_status_id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateOwnershipStatusCmd = new MySqlCommand(updateOwnershipStatusQuary, _sqlCon);
                updateOwnershipStatusCmd.Parameters.AddWithValue("@ID", ownershipStatusId);
                updateOwnershipStatusCmd.Parameters.AddWithValue("@ownership_english_status",
                    txt_En_Ownership_Status_Name.Text);
                updateOwnershipStatusCmd.Parameters.AddWithValue("@ownership_arabic_status",
                    txt_Ar_Ownership_Status_Name.Text);
                updateOwnershipStatusCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_New_Ownership_Status.Text = "Edit successfully";
                Response.Redirect("Ownership_Status_List.aspx");
            }
        }

        protected void btn_Back_To_Ownership_Status_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ownership_Status_List.aspx");
        }
    }
}