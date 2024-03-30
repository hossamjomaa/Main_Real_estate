using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Company_Rep : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Helper.LoadDropDownList("SELECT * FROM nationality", _sqlCon, Nationality_DropDownList, "Arabic_nationality", "nationality_ID");
                Nationality_DropDownList.Items.Insert(0, "إختر جنسية الممثل ....");

                Helper.LoadDropDownList("SELECT * FROM tenants where tenant_type_Tenant_Type_Id = 2", _sqlCon, Company_Name_DropDownList, "Tenants_Arabic_Name", "Tenants_ID");
                Company_Name_DropDownList.Items.Insert(0, "إختر الشركة ....");
                //**********************************************************************************************************************
                string Com_RepId = Request.QueryString["Id"];
                DataTable getCom_RepDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getCom_RepCmd =
                    new MySqlCommand(
                        "SELECT * FROM company_representative WHERE Company_representative_Id = @ID",
                        _sqlCon);
                MySqlDataAdapter getCom_RepDa = new MySqlDataAdapter(getCom_RepCmd);

                getCom_RepCmd.Parameters.AddWithValue("@ID", Com_RepId);
                getCom_RepDa.Fill(getCom_RepDt);
                if (getCom_RepDt.Rows.Count > 0)
                {
                    Rep_Name.Text = getCom_RepDt.Rows[0]["Com_rep_En_Name"].ToString();
                    txt_Ar_Com_rep_Name.Text = getCom_RepDt.Rows[0]["Com_rep_Ar_Name"].ToString();
                    txt_En_Com_rep_Name.Text = getCom_RepDt.Rows[0]["Com_rep_En_Name"].ToString();
                    txt_Com_Rep_Mobile.Text = getCom_RepDt.Rows[0]["Com_rep_Mobile"].ToString();
                    txt_Com_Rep_Email.Text = getCom_RepDt.Rows[0]["Com_rep_Email"].ToString();
                    txt_Com_Rep_Qid_No.Text = getCom_RepDt.Rows[0]["Com_rep_QID_NO"].ToString();
                    Qid_Path.Text = getCom_RepDt.Rows[0]["Com_rep_QID_Path"].ToString();
                    Qid_File_Name.Text = getCom_RepDt.Rows[0]["Com_rep_QID"].ToString();
                    Nationality_DropDownList.SelectedValue = getCom_RepDt.Rows[0]["nationality_nationality_ID"].ToString();
                    Company_Name_DropDownList.SelectedValue = getCom_RepDt.Rows[0]["tenants_Tenants_ID"].ToString();
                }

                _sqlCon.Close();
            }
        }

        protected void btn_ُEdit_Com_rep_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string Com_RepId = Request.QueryString["Id"];

                string updateCom_RepQuary =
                    "UPDATE company_representative SET " +
                    "Com_rep_Ar_Name=@Com_rep_Ar_Name , " +
                    "Com_rep_En_Name=@Com_rep_En_Name , " +
                    "Com_rep_Mobile=@Com_rep_Mobile ," +
                    "Com_rep_Email=@Com_rep_Email , " +
                    "Com_rep_QID_NO=@Com_rep_QID_NO , " +
                    "Com_rep_QID=@Com_rep_QID , " +
                    "Com_rep_QID_Path=@Com_rep_QID_Path , " +
                    "tenants_Tenants_ID=@tenants_Tenants_ID , " +
                    "nationality_nationality_ID =@nationality_nationality_ID " +

                    "WHERE Company_representative_Id=@ID "; 
                _sqlCon.Open();
                MySqlCommand updateCom_RepCmd = new MySqlCommand(updateCom_RepQuary, _sqlCon);
                updateCom_RepCmd.Parameters.AddWithValue("@ID", Com_RepId);
                updateCom_RepCmd.Parameters.AddWithValue("@Com_rep_Ar_Name", lbl_Ar_Com_rep_Name.Text);
                updateCom_RepCmd.Parameters.AddWithValue("@Com_rep_En_Name", txt_En_Com_rep_Name.Text);
                updateCom_RepCmd.Parameters.AddWithValue("@Com_rep_Mobile", txt_Com_Rep_Mobile.Text);
                updateCom_RepCmd.Parameters.AddWithValue("@Com_rep_Email", txt_Com_Rep_Email.Text);
                updateCom_RepCmd.Parameters.AddWithValue("@Com_rep_QID_NO", txt_Com_Rep_Qid_No.Text);
                updateCom_RepCmd.Parameters.AddWithValue("@nationality_nationality_ID", Nationality_DropDownList.SelectedValue);
                updateCom_RepCmd.Parameters.AddWithValue("@tenants_Tenants_ID", Company_Name_DropDownList.SelectedValue);

                if (Com_Rep_Qid_File_FileUpload.HasFile)
                {
                    string fileName = Path.GetFileName(Com_Rep_Qid_File_FileUpload.PostedFile.FileName);
                    Com_Rep_Qid_File_FileUpload.PostedFile.SaveAs(Server.MapPath("/English/Master_Panal/Com_reps_QID/") + fileName);
                    updateCom_RepCmd.Parameters.AddWithValue("@Com_rep_QID", fileName);
                    updateCom_RepCmd.Parameters.AddWithValue("@Com_rep_QID_Path", "/English/Master_Panal/Com_reps_QID/" + fileName);
                }
                else
                {
                    string fileName = Path.GetFileName(Com_Rep_Qid_File_FileUpload.PostedFile.FileName);
                    updateCom_RepCmd.Parameters.AddWithValue("@Com_rep_QID", Qid_File_Name.Text);
                    updateCom_RepCmd.Parameters.AddWithValue("@Com_rep_QID_Path", Qid_Path.Text);
                }

                updateCom_RepCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_Com_rep.Text = "تم التعديل بنجاح";
                Response.Redirect("Company_rep_List.aspx");
            }
        }

        protected void btn_Back_To_Com_rep_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Company_rep_List.aspx");
        }
    }
}