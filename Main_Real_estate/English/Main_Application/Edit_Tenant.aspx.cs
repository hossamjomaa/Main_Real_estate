using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Edit_Tenant : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Customer_Affairs", 0, "R");
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Customer_Affairs", 2, "E");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!Page.IsPostBack)
            {
                //Fill Tenant Type DropDownList
                Helper.LoadDropDownList("SELECT * FROM tenant_type", _sqlCon, Tenant_Type_DropDownList, "Tenant_Arabic_Type", "Tenant_Type_Id");
                Tenant_Type_DropDownList.Items.Insert(0, "إختر نوع المستأجر ....");

                Helper.LoadDropDownList("SELECT * FROM nationality", _sqlCon, nationality_DropDownList, "Arabic_nationality", "nationality_ID");
                nationality_DropDownList.Items.Insert(0, "إختر جنسية المستأجر ....");

                string tenantId = Request.QueryString["Id"];
                string getTenantQuery = "SELECT * From tenants Where Tenants_ID=@Id";
                MySqlCommand getTenantCmd = new MySqlCommand(getTenantQuery, _sqlCon);
                getTenantCmd.Parameters.AddWithValue("@ID", tenantId);
                _sqlCon.Open();
                MySqlDataReader getTenantSdr = getTenantCmd.ExecuteReader();
                getTenantSdr.Read();
                Tenant_Type_DropDownList.SelectedValue = getTenantSdr["tenant_type_Tenant_Type_Id"].ToString();

                if (getTenantSdr["tenant_type_Tenant_Type_Id"].ToString() == "1")
                {
                    nationality.Visible = true;
                    Tenant_Nationality_Address.Visible = true;
                    ID_PassPort_IdExpaired_Div.Visible = true;

                    business_records_Div.Visible = false;
                    P_O_Box_Div.Visible = false;
                    business_records_File_Div.Visible = false;
                    Establishment_Registration_Number_Div.Visible = false;
                    Company_registration_Div.Visible = false;
                    Add_Tenant_Div.Visible=false;

                    nationality_DropDownList.SelectedValue = getTenantSdr["nationality_nationality_ID"].ToString();
                    txt__Tenant_Nationality_Address.Text = getTenantSdr["Tenants_Nationality_Address"].ToString();
                }
                else if (getTenantSdr["tenant_type_Tenant_Type_Id"].ToString() == "2")
                {
                    business_records_Div.Visible = true;
                    P_O_Box_Div.Visible = true;
                    business_records_File_Div.Visible = true;
                    Establishment_Registration_Number_Div.Visible = true;
                    Company_registration_Div.Visible = true;
                    Add_Tenant_Div.Visible = true;

                    nationality.Visible = false;
                    Tenant_Nationality_Address.Visible = false;
                    ID_PassPort_IdExpaired_Div.Visible = false;

                    txt_business_records.Text = getTenantSdr["business_records"].ToString();
                    txt_P_O_Box.Text = getTenantSdr["P_O_Box"].ToString();
                }
                else
                {
                    nationality.Visible = false;
                    Tenant_Nationality_Address.Visible = false;
                    business_records_Div.Visible = false;
                    P_O_Box_Div.Visible = false;
                    business_records_File_Div.Visible = false;
                    Establishment_Registration_Number_Div.Visible = false;
                    Company_registration_Div.Visible = false;
                    Add_Tenant_Div.Visible = false;
                    ID_PassPort_IdExpaired_Div.Visible = false;
                }
                txt_En_Tenant_Name.Text = getTenantSdr["Tenants_English_Name"].ToString();
                txt_Ar_Tenant_Name.Text = getTenantSdr["Tenants_Arabic_Name"].ToString();
                lbl_Name_Of_Tenant.Text = getTenantSdr["Tenants_Arabic_Name"].ToString();
                txt_Tenant_Tell.Text = getTenantSdr["Tenants_Tell"].ToString();
                txt_Tenant_Mobile.Text = getTenantSdr["Tenants_Mobile"].ToString();
                txt_Tenant_Fax.Text = getTenantSdr["Tenants_Fax"].ToString();
                txt_Tenant_Email.Text = getTenantSdr["Tenants_Email"].ToString();
                txt_Tenant_Address.Text = getTenantSdr["Tenants_Address"].ToString();
                txt_ID_NO.Text = getTenantSdr["ID_NO"].ToString();
                txt_End_Date.Text = getTenantSdr["ID_Expiry"].ToString();
                Tenants_QId.Text = getTenantSdr["Tenants_QId"].ToString();
                Tenants_QId_Path.Text = getTenantSdr["Tenants_QId_Path"].ToString();
                Passport.Text = getTenantSdr["PassPort"].ToString();
                Passport_path.Text = getTenantSdr["PassPort_Path"].ToString();
                lbl_B_R_FN.Text = getTenantSdr["business_records_FileName"].ToString();
                lbl_B_R_P.Text = getTenantSdr["business_records_Path"].ToString();
                lbl_C_R_FN.Text = getTenantSdr["Company_registration_FileName"].ToString();
                lbl_C_R_P.Text = getTenantSdr["Company_registration_Path"].ToString();
                txt_Establishment_Registration_Number.Text = getTenantSdr["Company_registration_No"].ToString();
                _sqlCon.Close();

                //-------------------------------------------------------------------------------------------------
                DataTable getTenant_AccountDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getTenant_AccountCmd = new MySqlCommand("SELECT * FROM tenant_accounts WHERE Tenant_ID = @ID", _sqlCon);
                MySqlDataAdapter getTenant_AccountDa = new MySqlDataAdapter(getTenant_AccountCmd);
                getTenant_AccountCmd.Parameters.AddWithValue("@ID", tenantId);
                getTenant_AccountDa.Fill(getTenant_AccountDt);
                if (getTenant_AccountDt.Rows.Count > 0)
                {
                    txt_Tenant_User_Name.Text = getTenant_AccountDt.Rows[0]["User_Name"].ToString();
                    txt_Tenant_PassPword.Text = getTenant_AccountDt.Rows[0]["Pass_Word"].ToString();
                }

                _sqlCon.Close();






            }
            ViewState["Pwd"] = txt_Tenant_PassPword.Text;
            txt_Tenant_PassPword.Attributes.Add("value", ViewState["Pwd"].ToString());
        }

        protected void btn_Edit_Tenant_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string tenantsId = Request.QueryString["Id"];
                string updateTenantsQuary = "UPDATE tenants SET " +
                                              "tenant_type_Tenant_Type_Id=@tenant_type_Tenant_Type_Id, " +
                                              "nationality_nationality_ID=@nationality_nationality_ID, " +

                                              "Tenants_English_Name=@Tenants_English_Name ," +
                                              "Tenants_Arabic_Name=@Tenants_Arabic_Name , " +
                                              "Tenants_Tell=@Tenants_Tell, " +
                                              "Tenants_Mobile=@Tenants_Mobile , " +
                                              "Tenants_Fax=@Tenants_Fax , " +
                                              "Tenants_Email=@Tenants_Email , " +
                                              "Tenants_Address=@Tenants_Address , " +
                                              "Tenants_Nationality_Address=@Tenants_Nationality_Address ," +
                                              "ID_NO=@ID_NO ," +
                                              "ID_Expiry=@ID_Expiry ," +

                                              "business_records=@business_records ," +
                                              "business_records_FileName=@business_records_FileName ," +
                                              "business_records_Path=@business_records_Path ," +

                                              "Company_registration_No=@Company_registration_No ," +
                                              "Company_registration_FileName=@Company_registration_FileName ," +
                                              "Company_registration_Path=@Company_registration_Path ," +

                                              "P_O_Box=@P_O_Box ," +

                                              "PassPort=@PassPort ," +
                                              "PassPort_Path=@PassPort_Path ," +

                                              "Tenants_QId=@Tenants_QId , " +
                                              "Tenants_QId_Path=@Tenants_QId_Path " +
                                              "WHERE Tenants_Id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateTenantsCmd = new MySqlCommand(updateTenantsQuary, _sqlCon);
                updateTenantsCmd.Parameters.AddWithValue("@ID", tenantsId);

                updateTenantsCmd.Parameters.AddWithValue("@Tenants_English_Name", txt_En_Tenant_Name.Text);
                updateTenantsCmd.Parameters.AddWithValue("@Tenants_Arabic_Name", txt_Ar_Tenant_Name.Text);
                updateTenantsCmd.Parameters.AddWithValue("@Tenants_Tell", txt_Tenant_Tell.Text);
                updateTenantsCmd.Parameters.AddWithValue("@Tenants_Mobile", txt_Tenant_Mobile.Text);
                updateTenantsCmd.Parameters.AddWithValue("@Tenants_Fax", txt_Tenant_Fax.Text);
                updateTenantsCmd.Parameters.AddWithValue("@Tenants_Email", txt_Tenant_Email.Text);
                updateTenantsCmd.Parameters.AddWithValue("@Tenants_Address", txt_Tenant_Address.Text);
                updateTenantsCmd.Parameters.AddWithValue("@ID_NO", txt_ID_NO.Text);
                updateTenantsCmd.Parameters.AddWithValue("@ID_Expiry", txt_End_Date.Text);

                updateTenantsCmd.Parameters.AddWithValue("@tenant_type_Tenant_Type_Id", Tenant_Type_DropDownList.SelectedValue);

                if (Tenant_Type_DropDownList.SelectedValue == "1")
                {
                    updateTenantsCmd.Parameters.AddWithValue("@nationality_nationality_ID", nationality_DropDownList.SelectedValue);
                    updateTenantsCmd.Parameters.AddWithValue("@Tenants_Nationality_Address", txt__Tenant_Nationality_Address.Text);
                    updateTenantsCmd.Parameters.AddWithValue("@Com_Rep", "");
                    updateTenantsCmd.Parameters.AddWithValue("@business_records", "");
                    updateTenantsCmd.Parameters.AddWithValue("@P_O_Box", "");
                    updateTenantsCmd.Parameters.AddWithValue("@Company_registration_No", "");
                    updateTenantsCmd.Parameters.AddWithValue("@business_records_FileName", "");
                    updateTenantsCmd.Parameters.AddWithValue("@business_records_Path", "");
                    updateTenantsCmd.Parameters.AddWithValue("@Company_registration_FileName", "");
                    updateTenantsCmd.Parameters.AddWithValue("@Company_registration_Path", "");
                }
                else if (Tenant_Type_DropDownList.SelectedValue == "2")
                {
                    updateTenantsCmd.Parameters.AddWithValue("@nationality_nationality_ID", "165");
                    updateTenantsCmd.Parameters.AddWithValue("@Tenants_Nationality_Address", "Null");
                    updateTenantsCmd.Parameters.AddWithValue("@business_records", txt_business_records.Text);
                    updateTenantsCmd.Parameters.AddWithValue("@P_O_Box", txt_P_O_Box.Text);
                    updateTenantsCmd.Parameters.AddWithValue("@Company_registration_No", txt_Establishment_Registration_Number.Text);
                    //Fill The Database with All UploadFiles Items
                    if (business_records_File_FileUpload.HasFile)
                    {
                        string fileName = Path.GetFileName(business_records_File_FileUpload.PostedFile.FileName);
                        business_records_File_FileUpload.PostedFile.SaveAs(Server.MapPath("/English/Main_Application/business_records/") + fileName);
                        updateTenantsCmd.Parameters.AddWithValue("@business_records_FileName", fileName);
                        updateTenantsCmd.Parameters.AddWithValue("@business_records_Path", "/English/Main_Application/business_records/" + fileName);
                    }
                    else
                    {
                        updateTenantsCmd.Parameters.AddWithValue("@business_records_FileName", lbl_B_R_FN.Text);
                        updateTenantsCmd.Parameters.AddWithValue("@business_records_Path", lbl_B_R_P.Text);
                    }
                    //************************************************************************************************************************
                    //Fill The Database with All UploadFiles Items
                    if (Company_registration_FileUpload.HasFile)
                    {
                        string fileName_PassPort = Path.GetFileName(Company_registration_FileUpload.PostedFile.FileName);
                        Company_registration_FileUpload.PostedFile.SaveAs(Server.MapPath("/English/Main_Application/Company_registration/") + fileName_PassPort);
                        updateTenantsCmd.Parameters.AddWithValue("@Company_registration_FileName", fileName_PassPort);
                        updateTenantsCmd.Parameters.AddWithValue("@Company_registration_Path", "/English/Main_Application/Company_registration/" + fileName_PassPort);
                    }
                    else
                    {
                        updateTenantsCmd.Parameters.AddWithValue("@Company_registration_FileName", lbl_C_R_FN.Text);
                        updateTenantsCmd.Parameters.AddWithValue("@Company_registration_Path", lbl_C_R_P.Text);
                    }
                }
                else
                {
                    updateTenantsCmd.Parameters.AddWithValue("@nationality_nationality_ID", "165");
                    updateTenantsCmd.Parameters.AddWithValue("@Tenants_Nationality_Address", "Null");
                    updateTenantsCmd.Parameters.AddWithValue("@Com_Rep", "");
                    updateTenantsCmd.Parameters.AddWithValue("@business_records", "");
                    updateTenantsCmd.Parameters.AddWithValue("@P_O_Box", "");
                    updateTenantsCmd.Parameters.AddWithValue("@Company_registration_No", "");
                    updateTenantsCmd.Parameters.AddWithValue("@business_records_FileName", "");
                    updateTenantsCmd.Parameters.AddWithValue("@business_records_Path", "");
                    updateTenantsCmd.Parameters.AddWithValue("@Company_registration_FileName", "");
                    updateTenantsCmd.Parameters.AddWithValue("@Company_registration_Path", "");
                }

                //*************************** File Upload *******************************************************************
                //Fill The Database with All UploadFiles Items
                if (FUL_Tenant_QID.HasFile)
                {
                    string fileName = Path.GetFileName(FUL_Tenant_QID.PostedFile.FileName);
                    FUL_Tenant_QID.PostedFile.SaveAs(Server.MapPath("/English/Main_Application/Tenant_QID/") + fileName);
                    updateTenantsCmd.Parameters.AddWithValue("@Tenants_QId", fileName);
                    updateTenantsCmd.Parameters.AddWithValue("@Tenants_QId_Path",
                        "/English/Main_Application/Tenant_QID/" + fileName);
                }
                else
                {
                    updateTenantsCmd.Parameters.AddWithValue("@Tenants_QId", Tenants_QId.Text);
                    updateTenantsCmd.Parameters.AddWithValue("@Tenants_QId_Path", Tenants_QId_Path.Text);
                }
                //**************************************************************************************************************
                //Fill The Database with All UploadFiles Items
                if (Passport_FileUpload.HasFile)
                {
                    string fileName = Path.GetFileName(Passport_FileUpload.PostedFile.FileName);
                    Passport_FileUpload.PostedFile.SaveAs(Server.MapPath("/English/Main_Application/Tenant_Passport/") + fileName);
                    updateTenantsCmd.Parameters.AddWithValue("@PassPort", fileName);
                    updateTenantsCmd.Parameters.AddWithValue("@PassPort_Path",
                        "/English/Main_Application/Tenant_Passport/" + fileName);
                }
                else
                {
                    updateTenantsCmd.Parameters.AddWithValue("@PassPort", Passport.Text);
                    updateTenantsCmd.Parameters.AddWithValue("@PassPort_Path", Passport_path.Text);
                }

                updateTenantsCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_Tenant.Text = "تم التعديل بنجاح";
                // ****************************** Creat tenant Acount **************************

                DataTable getTenant_AccountDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getTenant_AccountCmd = new MySqlCommand("SELECT Tenant_ID FROM tenant_accounts WHERE Tenant_ID = @ID", _sqlCon);
                MySqlDataAdapter getTenant_AccountDa = new MySqlDataAdapter(getTenant_AccountCmd);
                getTenant_AccountCmd.Parameters.AddWithValue("@ID", tenantsId);
                getTenant_AccountDa.Fill(getTenant_AccountDt);
                if (getTenant_AccountDt.Rows.Count > 0)
                {
                    string updateAdd_Tenant_AccountQuary =
                        "UPDATE tenant_accounts SET " +
                        "User_Name=@User_Name , Pass_Word=@Pass_Word " +
                        " WHERE Tenant_ID=@ID ";
                    MySqlCommand updateAdd_Tenant_AccountCmd = new MySqlCommand(updateAdd_Tenant_AccountQuary, _sqlCon);
                    updateAdd_Tenant_AccountCmd.Parameters.AddWithValue("@ID", tenantsId);
                    updateAdd_Tenant_AccountCmd.Parameters.AddWithValue("@User_Name", txt_Tenant_User_Name.Text);
                    updateAdd_Tenant_AccountCmd.Parameters.AddWithValue("@Pass_Word", txt_Tenant_PassPword.Text);
                    updateAdd_Tenant_AccountCmd.ExecuteNonQuery();
                }
                else
                {
                    string addAdd_Tenant_AccountQuary =
                   "Insert Into tenant_accounts (" +
                   "User_Name , " +
                   "Tenant_ID , " +
                   "Pass_Word) " +
                   "VALUES(" +
                   "@User_Name , " +
                   "@Tenant_ID , " +
                   "@Pass_Word)";
                    MySqlCommand addAdd_Tenant_AccountCmd = new MySqlCommand(addAdd_Tenant_AccountQuary, _sqlCon);
                    addAdd_Tenant_AccountCmd.Parameters.AddWithValue("@Tenant_ID", tenantsId);
                    addAdd_Tenant_AccountCmd.Parameters.AddWithValue("@User_Name", txt_Tenant_User_Name.Text);
                    addAdd_Tenant_AccountCmd.Parameters.AddWithValue("@Pass_Word", txt_Tenant_PassPword.Text);
                    addAdd_Tenant_AccountCmd.ExecuteNonQuery();
                }
                _sqlCon.Close();










            }
        }

        protected void btn_Back_To_Tenant_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tenant_List.aspx");
        }

        //******************  Tenant_Type_DropDownList ***************************************************
        protected void Tenant_Type_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tenant_Type_DropDownList.SelectedValue == "1")
            {
                nationality.Visible = true;
                Tenant_Nationality_Address.Visible = true;
                ID_PassPort_IdExpaired_Div.Visible = true;

                business_records_Div.Visible = false;
                P_O_Box_Div.Visible = false;
                business_records_File_Div.Visible = false;
                Establishment_Registration_Number_Div.Visible = false;
                Company_registration_Div.Visible = false;
                Add_Tenant_Div.Visible = false;
            }
            else if (Tenant_Type_DropDownList.SelectedValue == "2")
            {
                business_records_Div.Visible = true;
                P_O_Box_Div.Visible = true;
                business_records_File_Div.Visible = true;
                Establishment_Registration_Number_Div.Visible = true;
                Company_registration_Div.Visible = true;
                Add_Tenant_Div.Visible = true;

                nationality.Visible = false;
                Tenant_Nationality_Address.Visible = false;
                ID_PassPort_IdExpaired_Div.Visible = false;
            }
            else
            {
                nationality.Visible = false;
                Tenant_Nationality_Address.Visible = false;
                business_records_Div.Visible = false;
                P_O_Box_Div.Visible = false;
                business_records_File_Div.Visible = false;
                Establishment_Registration_Number_Div.Visible = false;
                Company_registration_Div.Visible = false;
                Add_Tenant_Div.Visible = false;
                ID_PassPort_IdExpaired_Div.Visible = false;
            }
        }

        //******************  End_Date ***************************************************
        protected void Date_Chosee_Click(object sender, EventArgs e)
        {
            End_Date_divCalendar.Visible = true;
            ImageButton1.Visible = true;
        }

        protected void End_Date_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txt_End_Date.Text = End_Date_Calendar.SelectedDate.ToShortDateString();

            if (txt_End_Date.Text != "")
            {
                End_Date_divCalendar.Visible = false;
                ImageButton1.Visible = false;
            }
        }

        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            End_Date_divCalendar.Visible = false;
            ImageButton1.Visible = false;
        }

        protected void Add_Tenantt_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("../Master_Panal/Add_company_rep.aspx");
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(CheckBox1.Checked== true)
            {
                txt_Tenant_PassPword.TextMode = TextBoxMode.SingleLine;
            }
            else
            {
                txt_Tenant_PassPword.TextMode = TextBoxMode.Password;
            }
        }
    }
}