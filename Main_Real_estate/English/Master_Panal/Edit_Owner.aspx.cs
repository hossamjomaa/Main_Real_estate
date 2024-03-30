using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Owner : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string ownerId = Request.QueryString["Id"];
                DataTable getOwnerDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getOwnerCmd =
                    new MySqlCommand(
                        "SELECT * FROM owner WHERE Owner_Id = @ID",
                        _sqlCon);
                MySqlDataAdapter getOwnerDa = new MySqlDataAdapter(getOwnerCmd);

                getOwnerCmd.Parameters.AddWithValue("@ID", ownerId);
                getOwnerDa.Fill(getOwnerDt);
                if (getOwnerDt.Rows.Count > 0)
                {
                    txt_En_Owner_Name.Text = getOwnerDt.Rows[0]["Owner_English_name"].ToString();
                    txt_Ar_Owner_Name.Text = getOwnerDt.Rows[0]["Owner_Arabic_name"].ToString();
                    txt_Owner_tell.Text = getOwnerDt.Rows[0]["Owner_Tell"].ToString();
                    txt_Owner_Mobile.Text = getOwnerDt.Rows[0]["Owner_Mobile"].ToString();
                    txt_Owner_Email.Text = getOwnerDt.Rows[0]["Owner_Email"].ToString();
                    txt_Owner_Website.Text = getOwnerDt.Rows[0]["Owner_Website"].ToString();
                    txt_Owner_Note.Text = getOwnerDt.Rows[0]["Owner_Notes"].ToString();

                    txt_Owner_Salary.Text = getOwnerDt.Rows[0]["Salary"].ToString();

                    lbl_titel_Name_Edit_Owner.Text = getOwnerDt.Rows[0]["Owner_Arabic_name"].ToString();
                    QID_NAME.Text = getOwnerDt.Rows[0]["Owner_QID"].ToString();
                    lbl_path.Text = getOwnerDt.Rows[0]["path"].ToString();
                    Image1.ImageUrl = lbl_path.Text;
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Update_Owner_Click1(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string ownerId = Request.QueryString["Id"];

                string updateOwnerQuary =
                    "UPDATE owner SET " +
                    "Owner_QID=@Owner_QID , " +
                    "path=@path , " +
                    "Owner_English_name=@Owner_English_name, " +
                    "Owner_Arabic_name=@Owner_Arabic_name ," +
                    " Owner_Tell=@Owner_Tell , " +
                    "Owner_Mobile=@Owner_Mobile , " +
                    "Owner_Email=@Owner_Email , " +
                    "Owner_Website=@Owner_Website ," +
                    " Owner_Notes=@Owner_Notes , " +
                     " Salary=@Salary " +
                    " WHERE Owner_Id=@ID ";

                _sqlCon.Open();
                MySqlCommand updateOwnerCmd = new MySqlCommand(updateOwnerQuary, _sqlCon);
                updateOwnerCmd.Parameters.AddWithValue("@ID", ownerId);
                updateOwnerCmd.Parameters.AddWithValue("@Owner_English_name", txt_En_Owner_Name.Text);
                updateOwnerCmd.Parameters.AddWithValue("@Owner_Arabic_name", txt_Ar_Owner_Name.Text);
                updateOwnerCmd.Parameters.AddWithValue("@Owner_Tell", txt_Owner_tell.Text);
                updateOwnerCmd.Parameters.AddWithValue("@Owner_Mobile", txt_Owner_Mobile.Text);
                updateOwnerCmd.Parameters.AddWithValue("@Owner_Email", txt_Owner_Email.Text);
                updateOwnerCmd.Parameters.AddWithValue("@Owner_Website", txt_Owner_Website.Text);
                updateOwnerCmd.Parameters.AddWithValue("@Owner_Notes", txt_Owner_Note.Text);
                updateOwnerCmd.Parameters.AddWithValue("@Salary", txt_Owner_Salary.Text);

                if (FileUpload1.HasFile)
                {
                    string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("/English/Master_Panal/Owners_QID/") + fileName);
                    updateOwnerCmd.Parameters.AddWithValue("@Owner_QID", fileName);
                    updateOwnerCmd.Parameters.AddWithValue("@path", "/English/Master_Panal/Owners_QID/" + fileName);
                }
                else
                {
                    string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    updateOwnerCmd.Parameters.AddWithValue("@Owner_QID", QID_NAME.Text);
                    updateOwnerCmd.Parameters.AddWithValue("@path", lbl_path.Text);
                }

                updateOwnerCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_Owner.Text = "Edit successfully";
                Response.Redirect("Owner_List.aspx");
            }
        }

        protected void btn_Back_To_Owner_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Owner_List.aspx");
        }
    }
}