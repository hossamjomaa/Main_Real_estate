using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Sub_Type_Evaluation_List : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            string getSub_Type_EvaluationQuari = "SELECT Sub.* ,  " +
                    "(Main.Ar_Name) Main_Ar_Name , (Main.EN_Name) Main_EN_Name , (Main.Main_Weight) Main_Weight  " +
                    "FROM  sub_type_evaluation Sub  " +
                    "left join  main_type_evaluation Main on (Sub.Main_Type_Evaluation_Id = Main.Main_Type_Evaluation_Id) Order By Main.Main_Type_Evaluation_Id";


            try { Helper.GetDataReader(getSub_Type_EvaluationQuari, _sqlCon, The_Table); }
            catch { Response.Write(@"<script language='javascript'>alert('لا يمكن عرض هذه الصفحة')</script>"); };
        }
        protected void Delete(object sender, EventArgs e)
        {
            try
            {
                string id = (sender as LinkButton).CommandArgument;
                _sqlCon.Open();
                string quary1 = "DELETE FROM sub_type_evaluation WHERE Sub_Type_Evaluation_Id=@ID ";
                MySqlCommand mySqlCmd = new MySqlCommand(quary1, _sqlCon);
                mySqlCmd.Parameters.AddWithValue("@ID", id);
                mySqlCmd.ExecuteNonQuery();
                _sqlCon.Close();
                Response.Redirect(Request.RawUrl);
            }
            catch
            {
                Response.Write(@"<script language='javascript'>alert('لا يمكن الحذف')</script>");
            };
        }
        protected void Edit(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Edit_Sub_Type_Evaluation.aspx?Id=" + id);
        }
        protected void GoToAdd(object sender, EventArgs e)
        {
            Response.Redirect("Sub_Main_Type_Evaluation.aspx");
        }







































        protected void Delete_Sub_Type_Evaluation(object sender, EventArgs e)
        {
            string Sub_Type_EvaluationeRowId = (sender as LinkButton).CommandArgument;
            _sqlCon.Open();
            string deleteSub_Type_EvaluationeQuary = "DELETE FROM sub_type_evaluation WHERE Sub_Type_Evaluation_Id=@ID ";
            MySqlCommand mySqlCmd = new MySqlCommand(deleteSub_Type_EvaluationeQuary, _sqlCon);
            mySqlCmd.Parameters.AddWithValue("@ID", Sub_Type_EvaluationeRowId);
            mySqlCmd.ExecuteNonQuery();
            _sqlCon.Close();
            Response.Redirect(Request.RawUrl);
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Sub_Main_Type_Evaluation.aspx");
        }
    }
}