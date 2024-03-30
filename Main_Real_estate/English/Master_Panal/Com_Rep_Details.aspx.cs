using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Com_Rep_Details : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            _sqlCon.Open();
            string Com_RepId = Request.QueryString["Id"];
            using (MySqlCommand Com_RepDetailsCmd = new MySqlCommand("Com_Rep_Details", _sqlCon))
            {
                Com_RepDetailsCmd.CommandType = CommandType.StoredProcedure;
                Com_RepDetailsCmd.Parameters.AddWithValue("@Id", Com_RepId);
                using (MySqlDataAdapter Com_RepDetailsSda = new MySqlDataAdapter(Com_RepDetailsCmd))
                {
                    DataTable Com_RepDetailsDt = new DataTable();
                    Com_RepDetailsSda.Fill(Com_RepDetailsDt);
                    lbl_Details_Com_Rep_Name.Text =
                        "الممثل " + Com_RepDetailsDt.Rows[0]["Com_rep_En_Name"].ToString();
                    lbl_Dtl_Company_Name.Text = Com_RepDetailsDt.Rows[0]["Tenants_Arabic_Name"].ToString();
                    lbl_Dtl_Com_Rep_Ar_Name.Text = Com_RepDetailsDt.Rows[0]["Com_rep_En_Name"].ToString();
                    lbl_Dtl_Com_Rep_Ar_Mobile.Text = Com_RepDetailsDt.Rows[0]["Com_rep_Mobile"].ToString();
                    lbl_Dtl_Com_Rep_Qid_No.Text = Com_RepDetailsDt.Rows[0]["Com_rep_QID_NO"].ToString();
                    lbl_Dtl_Com_Rep_Nationality.Text = Com_RepDetailsDt.Rows[0]["Arabic_nationality"].ToString();
                    lbl_Dtl_Com_Rep_Email.Text = Com_RepDetailsDt.Rows[0]["Com_rep_Email"].ToString();

                    lbl_Link_Com_Reps_QId.Text = Com_RepDetailsDt.Rows[0]["Com_rep_QID"].ToString();
                    Link_Com_Reps_QId.HRef = Com_RepDetailsDt.Rows[0]["Com_rep_QID_Path"].ToString();
                    Link_Com_Reps_QId.Target = "_blank";


                    if (lbl_Link_Com_Reps_QId.Text == "No File")
                    {
                        Link_Com_Reps_QId.Visible = false;
                    }


                    lbl_Link_Com_Reps_QId.Text = Com_RepDetailsDt.Rows[0]["Com_rep_QID"].ToString();
                    Link_Com_Reps_QId.HRef = Com_RepDetailsDt.Rows[0]["Com_rep_QID_Path"].ToString();
                    Link_Com_Reps_QId.Target = "_blank";


                    if (lbl_Link_Com_Reps_QId.Text == "No File")
                    {
                        Link_Com_Reps_QId.Visible = false;
                    }
                }
            }
        }

        protected void btn_Back_To_Com_Rep_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Company_rep_List.aspx");
        }
    }
}