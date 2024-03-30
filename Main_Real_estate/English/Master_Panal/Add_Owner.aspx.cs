using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.IO;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Owner : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Add_Owner_Click1(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addOwnerQuary =
                    "Insert Into owner (Owner_QID,path,Owner_English_name,Owner_Arabic_name,Owner_Tell,Owner_Mobile,Owner_Email,Owner_Website,Owner_Notes , Salary) " +
                    "VALUES(@Owner_QID , @path , @Owner_English_name,@Owner_Arabic_name,@Owner_Tell,@Owner_Mobile,@Owner_Email,@Owner_Website,@Owner_Notes , @Salary)";
                _sqlCon.Open();
                using (MySqlCommand addOwnerCmd = new MySqlCommand(addOwnerQuary, _sqlCon))
                {
                    addOwnerCmd.Parameters.AddWithValue("@Owner_English_name", txt_En_Owner_Name.Text);
                    addOwnerCmd.Parameters.AddWithValue("@Owner_Arabic_name", txt_Ar_Owner_Name.Text);
                    addOwnerCmd.Parameters.AddWithValue("@Owner_Tell", txt_Owner_tell.Text);
                    addOwnerCmd.Parameters.AddWithValue("@Owner_Mobile", txt_Owner_Mobile.Text);
                    addOwnerCmd.Parameters.AddWithValue("@Owner_Email", txt_Owner_Email.Text);
                    addOwnerCmd.Parameters.AddWithValue("@Owner_Website", txt_Owner_Website.Text);
                    addOwnerCmd.Parameters.AddWithValue("@Owner_Notes", txt_Owner_Note.Text);
                    addOwnerCmd.Parameters.AddWithValue("@Salary", txt_Owner_Salary.Text);

                    if (FUL_Owner_QID.HasFile)
                    {
                        string fileName = Path.GetFileName(FUL_Owner_QID.PostedFile.FileName);
                        FUL_Owner_QID.PostedFile.SaveAs(Server.MapPath("/English/Master_Panal/Owners_QID/") + fileName);

                        addOwnerCmd.Parameters.AddWithValue("@Owner_QID", fileName);
                        addOwnerCmd.Parameters.AddWithValue("@path", "/English/Master_Panal/Owners_QID/" + fileName);
                    }
                    else
                    {
                        addOwnerCmd.Parameters.AddWithValue("@Owner_QID", "No File");
                        addOwnerCmd.Parameters.AddWithValue("@path", "No File");
                    }

                    addOwnerCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                    lbl_Success_Add_New_Owner.Text = "Added successfully";
                    Response.Redirect("Owner_List.aspx");
                }
            }
        }

        protected void btn_Back_To_Owner_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Owner_List.aspx");
        }
    }
}