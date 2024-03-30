using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Requst_Source : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Add_Requst_Source_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addRequstSourceQuary =
                    "Insert Into requst_source (Ar_Requst_Source,En_Requst_Source) VALUES(@Ar_Requst_Source,@En_Requst_Source)";
                _sqlCon.Open();
                MySqlCommand addRequstSourceCmd = new MySqlCommand(addRequstSourceQuary, _sqlCon);
                addRequstSourceCmd.Parameters.AddWithValue("@Ar_Requst_Source", txt_Ar_Requst_Source_Name.Text);
                addRequstSourceCmd.Parameters.AddWithValue("@En_Requst_Source", txt_En_Requst_Source_Name.Text);
                addRequstSourceCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Requst_Source_Type.Text = "تمت الإضافة بنجاح";

                _sqlCon.Close();
                Response.Redirect("Requst_Source_List.aspx");
            }
        }

        protected void btn_Back_To_Requst_Source_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Requst_Source_List.aspx");
        }
    }
}