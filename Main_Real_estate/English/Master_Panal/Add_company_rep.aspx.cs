using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_company_rep : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Helper.LoadDropDownList("SELECT * FROM nationality", _sqlCon, Nationality_DropDownList, "Arabic_nationality", "nationality_ID");
                Nationality_DropDownList.Items.Insert(0, "إختر جنسية الممثل ....");

                Helper.LoadDropDownList("SELECT * FROM tenants where tenant_type_Tenant_Type_Id = 2", _sqlCon, Company_Name_DropDownList, "Tenants_Arabic_Name", "Tenants_ID");
                Company_Name_DropDownList.Items.Insert(0, "إختر الشركة ....");
            }
        }

        protected void btn_Add_Com_rep_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string Add_Com_rep_Quary =
                    "Insert Into company_representative " +
                    "(Com_rep_Ar_Name , " +
                    "Com_rep_En_Name , " +
                    "Com_rep_Mobile , " +
                    "Com_rep_Email , " +
                    "Com_rep_QID_NO," +
                    "Com_rep_QID, " +
                    "Com_rep_QID_Path , " +
                    "tenants_Tenants_ID , " +
                    "nationality_nationality_ID) " +
                    "VALUES" +
                    "(@Com_rep_Ar_Name , " +
                    "@Com_rep_En_Name , " +
                    "@Com_rep_Mobile , " +
                    "@Com_rep_Email , " +
                    "@Com_rep_QID_NO," +
                    "@Com_rep_QID, " +
                    "@Com_rep_QID_Path , " +
                    "@tenants_Tenants_ID , " +
                    "@nationality_nationality_ID) ";
                _sqlCon.Open();
                using (MySqlCommand Add_Com_Rep_Cmd = new MySqlCommand(Add_Com_rep_Quary, _sqlCon))
                {
                    Add_Com_Rep_Cmd.Parameters.AddWithValue("@Com_rep_Ar_Name", txt_En_Com_rep_Name.Text);
                    Add_Com_Rep_Cmd.Parameters.AddWithValue("@Com_rep_En_Name", txt_Ar_Com_rep_Name.Text);
                    Add_Com_Rep_Cmd.Parameters.AddWithValue("@Com_rep_Mobile", txt_Com_Rep_Mobile.Text);
                    Add_Com_Rep_Cmd.Parameters.AddWithValue("@Com_rep_Email", txt_Com_Rep_Email.Text);
                    Add_Com_Rep_Cmd.Parameters.AddWithValue("@Com_rep_QID_NO", txt_Com_Rep_Qid_No.Text);
                    Add_Com_Rep_Cmd.Parameters.AddWithValue("@nationality_nationality_ID", Nationality_DropDownList.SelectedValue);
                    Add_Com_Rep_Cmd.Parameters.AddWithValue("@tenants_Tenants_ID", Company_Name_DropDownList.SelectedValue);

                    if (Com_Rep_Qid_File_FileUpload.HasFile)
                    {
                        string fileName = Path.GetFileName(Com_Rep_Qid_File_FileUpload.PostedFile.FileName);
                        Com_Rep_Qid_File_FileUpload.PostedFile.SaveAs(Server.MapPath("/English/Master_Panal/Com_reps_QID/") + fileName);

                        Add_Com_Rep_Cmd.Parameters.AddWithValue("@Com_rep_QID", fileName);
                        Add_Com_Rep_Cmd.Parameters.AddWithValue("@Com_rep_QID_Path", "/English/Master_Panal/Com_reps_QID/" + fileName);
                    }
                    else
                    {
                        Add_Com_Rep_Cmd.Parameters.AddWithValue("@Com_rep_QID", "No File");
                        Add_Com_Rep_Cmd.Parameters.AddWithValue("@Com_rep_QID_Path", "No File");
                    }

                    Add_Com_Rep_Cmd.ExecuteNonQuery();
                    _sqlCon.Close();
                    lbl_Success_Add_New_Com_rep.Text = "تمت الغضافة بنجاح";
                    Response.Redirect("Company_rep_List.aspx");
                }
            }
        }

        protected void btn_Back_To_Com_rep_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Company_rep_List.aspx");
        }
    }
}