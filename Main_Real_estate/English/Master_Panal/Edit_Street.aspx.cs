using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Street : System.Web.UI.Page
    {
        MySqlConnection SqlCon = new MySqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string OwnerID = Request.QueryString["Id"];
                DataTable dt = new DataTable();
                SqlCon.Open();
                MySqlCommand MYSqlCmd = new MySqlCommand("SELECT Street_Id , Street_English_name , Street_arabic_name , Street_number FROM Street WHERE Street_Id = @ID", SqlCon);
                MySqlDataAdapter MYsqlDa = new MySqlDataAdapter(MYSqlCmd);

                MYSqlCmd.Parameters.AddWithValue("@ID", OwnerID);
                MYsqlDa.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txt_En_Street_Name.Text = dt.Rows[0]["Street_English_name"].ToString();
                    txt_Ar_Street_Name.Text = dt.Rows[0]["Street_arabic_name"].ToString();
                    txt_Street_Number.Text = dt.Rows[0]["Street_number"].ToString();

                    lbl_titel_Name_Edit_Street.Text= dt.Rows[0]["Street_English_name"].ToString();
                }
                SqlCon.Close();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string OwnerID = Request.QueryString["Id"];
            string X = txt_En_Street_Name.Text;
            string y = txt_Ar_Street_Name.Text;
            string z = txt_Street_Number.Text;


            //string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("/English/Master_Panal/Owner_QID/") + fileName);


            string quari = "UPDATE Street SET Street_English_name=@Street_English_name , Street_arabic_name=@Street_arabic_name , Street_number=@Street_number WHERE Street_Id=@ID ";
            SqlCon.Open();
            MySqlCommand MYSqlCmd2 = new MySqlCommand(quari, SqlCon);



            //MYSqlCmd2.Parameters.AddWithValue("@Owner_QID", fileName);
            //MYSqlCmd2.Parameters.AddWithValue("@path", "/English/Master_Panal/Owner_QID/" + fileName);

            MYSqlCmd2.Parameters.AddWithValue("@ID", OwnerID);
            MYSqlCmd2.Parameters.AddWithValue("@Street_English_name", X);
            MYSqlCmd2.Parameters.AddWithValue("@Street_arabic_name", y);
            MYSqlCmd2.Parameters.AddWithValue("@Street_number", z);



            MYSqlCmd2.ExecuteNonQuery();
            SqlCon.Close();
            lbl_Success_Edit_Street.Text = "Edit successfully";
            Response.Redirect("Street_List.aspx");

            //Response.Redirect("Edit_Owner.aspx");
        }

        protected void btn_Back_To_Street_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Street_List.aspx");
        }
    }
}