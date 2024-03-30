using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Security.Policy;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Main_Type_Evaluation : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                _sqlCon.Open();
                string getMain_Type_Evaluation_Wghit_Qury = "select (Select Sum(Main_Weight) from main_type_evaluation)  Sum_Main_Weight";
                DataTable getMain_Type_Evaluation_WghitDt = new DataTable();
                MySqlCommand getMain_Type_Evaluation_WghitCmd = new MySqlCommand(getMain_Type_Evaluation_Wghit_Qury, _sqlCon);
                MySqlDataAdapter getMain_Type_Evaluation_WghitDa = new MySqlDataAdapter(getMain_Type_Evaluation_WghitCmd);
                getMain_Type_Evaluation_WghitDa.Fill(getMain_Type_Evaluation_WghitDt);
                if (getMain_Type_Evaluation_WghitDt.Rows.Count > 0)
                {
                    string Wghit = (100 - (Convert.ToDouble(getMain_Type_Evaluation_WghitDt.Rows[0]["Sum_Main_Weight"].ToString()))).ToString();
                    txt_Main_Type_Evaluation_Number.Attributes.Add("max", Wghit);
                }
                _sqlCon.Close();
            }
                
        }

        protected void btn_Add_Main_Type_Evaluation_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addMain_Type_EvaluationQuary =
                    "Insert Into main_type_evaluation (" +
                    "Ar_Name , " +
                    "EN_Name , " +
                    "Main_Weight) " +
                    "VALUES( " +
                    "@Ar_Name , " +
                    "@EN_Name , " +
                    "@Main_Weight)";
                _sqlCon.Open();
                MySqlCommand addMain_Type_EvaluationCmd = new MySqlCommand(addMain_Type_EvaluationQuary, _sqlCon);
                addMain_Type_EvaluationCmd.Parameters.AddWithValue("@EN_Name", txt_En_Main_Type_Evaluation_Name.Text);
                addMain_Type_EvaluationCmd.Parameters.AddWithValue("@Ar_Name", txt_Ar_Main_Type_Evaluation_Name.Text);
                addMain_Type_EvaluationCmd.Parameters.AddWithValue("@Main_Weight", txt_Main_Type_Evaluation_Number.Text);
                addMain_Type_EvaluationCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Main_Type_Evaluation.Text = "تمت الإضافة بنجاح";
            }
        }

        protected void btn_Back_To_Main_Type_Evaluation_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main_Type_Evaluation_List.aspx");
        }
    }
}