using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Requst_Source : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string RequstSourceId = Request.QueryString["Id"];
                DataTable getRequstSourceDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getRequstSourceCmd = new MySqlCommand("SELECT * FROM requst_source WHERE Requst_Source_id = @ID", _sqlCon);
                MySqlDataAdapter getRequstSourceDa = new MySqlDataAdapter(getRequstSourceCmd);

                getRequstSourceCmd.Parameters.AddWithValue("@ID", RequstSourceId);
                getRequstSourceDa.Fill(getRequstSourceDt);
                if (getRequstSourceDt.Rows.Count > 0)
                {
                    txt_Ar_Requst_Source_Name.Text = getRequstSourceDt.Rows[0]["Ar_Requst_Source"].ToString();
                    txt_En_Requst_Source_Name.Text = getRequstSourceDt.Rows[0]["En_Requst_Source"].ToString();
                    lbl_Name_Of_Requst_Source.Text = getRequstSourceDt.Rows[0]["Ar_Requst_Source"].ToString();
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Edit_Requst_Source_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string RequstSourceId = Request.QueryString["Id"];
                string quari = "UPDATE requst_source SET Ar_Requst_Source=@Ar_Requst_Source , En_Requst_Source=@En_Requst_Source  WHERE Requst_Source_id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateRequstSourceCmd = new MySqlCommand(quari, _sqlCon);
                updateRequstSourceCmd.Parameters.AddWithValue("@ID", RequstSourceId);
                updateRequstSourceCmd.Parameters.AddWithValue("@Ar_Requst_Source", txt_Ar_Requst_Source_Name.Text);
                updateRequstSourceCmd.Parameters.AddWithValue("@En_Requst_Source", txt_En_Requst_Source_Name.Text);
                updateRequstSourceCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_New_Unit_Type.Text = "تم التعديل بنجاح";
                Response.Redirect("Requst_Source_List.aspx");
            }
        }

        protected void btn_Back_To_Requst_Source_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Requst_Source_List.aspx");
        }
    }
}