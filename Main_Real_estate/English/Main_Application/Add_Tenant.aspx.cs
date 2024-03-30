using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Add_Tenant : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Customer_Affairs", 0, "R");
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Customer_Affairs", 1, "A");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!this.IsPostBack)
            {
                string Id = Request.QueryString["Id"];
                if(Id == "1")
                {
                    btn_Back_To_Tenant_List.Text = "العودة لإضاغة عقد";
                }


                //    //Fill Tenant Type DropDownList
                Helper.LoadDropDownList("SELECT * FROM tenant_type", _sqlCon, Tenant_Type_DropDownList, "Tenant_Arabic_Type", "Tenant_Type_Id");
                Tenant_Type_DropDownList.Items.Insert(0, "إختر نوع المستأجر ....");

                //Fill nationality_DropDownList DropDownList
                Helper.LoadDropDownList("SELECT * FROM nationality", _sqlCon, nationality_DropDownList, "Arabic_nationality", "nationality_ID");
                nationality_DropDownList.Items.Insert(0, "إختر جنسية المستأجر ....");
            }
        }

        protected void btn_Add_Tenant_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addTenantQuery = "Insert Into tenants" +
                                          "(tenant_type_Tenant_Type_Id , " +
                                          "nationality_nationality_ID," +
                                          "Tenants_English_Name," +
                                          "Tenants_Arabic_Name , " +
                                          "Tenants_Tell , " +
                                          "Tenants_Mobile , " +
                                          "Tenants_Fax , " +
                                          "Tenants_Email ," +
                                          "Tenants_Address , " +
                                          "Tenants_Nationality_Address," +
                                          "ID_NO," +
                                          "ID_Expiry," +
                                          "business_records," +
                                          "P_O_Box," +
                                          "PassPort," +
                                          "PassPort_Path," +
                                          "Tenants_QId , " +

                                          "business_records_FileName ," +
                                          "business_records_Path ," +
                                          "Company_registration_No ," +
                                          "Company_registration_FileName ," +
                                          "Company_registration_Path ," +

                                          "Tenants_QId_Path)  " +

                                          " VALUES (" +

                                          "@tenant_type_Tenant_Type_Id , " +
                                          "@nationality_nationality_ID," +
                                          "@Tenants_English_Name , " +
                                          "@Tenants_Arabic_Name, " +
                                          "@Tenants_Tell , " +
                                          "@Tenants_Mobile , " +
                                          "@Tenants_Fax , " +
                                          "@Tenants_Email ," +
                                          "@Tenants_Address ," +
                                          "@Tenants_Nationality_Address ," +
                                          "@ID_NO," +
                                          "@ID_Expiry," +
                                          "@business_records," +
                                          "@P_O_Box," +
                                          "@PassPort," +
                                          "@PassPort_Path," +
                                          "@Tenants_QId ," +

                                          "@business_records_FileName ," +
                                          "@business_records_Path ," +
                                          "@Company_registration_No ," +
                                          "@Company_registration_FileName ," +
                                          "@Company_registration_Path ," +

                                          "@Tenants_QId_Path)";
                _sqlCon.Open();
                MySqlCommand addTenantCmd = new MySqlCommand(addTenantQuery, _sqlCon);
                addTenantCmd.Parameters.AddWithValue("@tenant_type_Tenant_Type_Id", Tenant_Type_DropDownList.SelectedValue);
                addTenantCmd.Parameters.AddWithValue("@Tenants_English_Name", txt_En_Tenant_Name.Text);
                addTenantCmd.Parameters.AddWithValue("@Tenants_Arabic_Name", txt_Ar_Tenant_Name.Text);

                addTenantCmd.Parameters.AddWithValue("@Company_registration_No", txt_Establishment_Registration_Number.Text);

                if (Tenant_Type_DropDownList.SelectedValue == "1")
                {
                    addTenantCmd.Parameters.AddWithValue("@nationality_nationality_ID", nationality_DropDownList.SelectedValue);
                    addTenantCmd.Parameters.AddWithValue("@Tenants_Nationality_Address", txt__Tenant_Nationality_Address.Text);
                }
                else
                {
                    addTenantCmd.Parameters.AddWithValue("@nationality_nationality_ID", "165");
                    addTenantCmd.Parameters.AddWithValue("@Tenants_Nationality_Address", "Null");
                }

                if (Tenant_Type_DropDownList.SelectedValue == "2")
                {
                    addTenantCmd.Parameters.AddWithValue("@business_records", txt_business_records.Text);
                    addTenantCmd.Parameters.AddWithValue("@P_O_Box", txt_P_O_Box.Text);
                }
                else
                {
                    addTenantCmd.Parameters.AddWithValue("@business_records", "");
                    addTenantCmd.Parameters.AddWithValue("@P_O_Box", "");
                }

                addTenantCmd.Parameters.AddWithValue("@Tenants_Tell", txt_Tenant_Tell.Text);
                addTenantCmd.Parameters.AddWithValue("@Tenants_Fax", txt_Tenant_Fax.Text);
                addTenantCmd.Parameters.AddWithValue("@Tenants_Mobile", txt_Tenant_Mobile.Text);
                addTenantCmd.Parameters.AddWithValue("@Tenants_Email", txt_Tenant_Email.Text);
                addTenantCmd.Parameters.AddWithValue("@Tenants_Address", txt_Tenant_Address.Text);

                addTenantCmd.Parameters.AddWithValue("@ID_NO", txt_ID_NO.Text);
                addTenantCmd.Parameters.AddWithValue("@ID_Expiry", txt_End_Date.Text);

                //Fill The Database with All UploadFiles Items
                if (FUL_Tenant_QID.HasFile)
                {
                    string fileName = Path.GetFileName(FUL_Tenant_QID.PostedFile.FileName);
                    FUL_Tenant_QID.PostedFile.SaveAs(Server.MapPath("/English/Main_Application/Tenant_QID/") + fileName);
                    addTenantCmd.Parameters.AddWithValue("@Tenants_QId", fileName);
                    addTenantCmd.Parameters.AddWithValue("@Tenants_QId_Path", "/English/Main_Application/Tenant_QID/" + fileName);
                }
                else
                {
                    addTenantCmd.Parameters.AddWithValue("@Tenants_QId", "No File");
                    addTenantCmd.Parameters.AddWithValue("@Tenants_QId_Path", "No File");
                }
                //************************************************************************************************************************
                //Fill The Database with All UploadFiles Items
                if (Passport_FileUpload.HasFile)
                {
                    string fileName_PassPort = Path.GetFileName(Passport_FileUpload.PostedFile.FileName);
                    Passport_FileUpload.PostedFile.SaveAs(Server.MapPath("/English/Main_Application/Tenant_Passport/") + fileName_PassPort);
                    addTenantCmd.Parameters.AddWithValue("@PassPort", fileName_PassPort);
                    addTenantCmd.Parameters.AddWithValue("@PassPort_Path", "/English/Main_Application/Tenant_Passport/" + fileName_PassPort);
                }
                else
                {
                    addTenantCmd.Parameters.AddWithValue("@PassPort", "No File");
                    addTenantCmd.Parameters.AddWithValue("@PassPort_Path", "No File");
                }

                //************************************************************************************************************************

                //Fill The Database with All UploadFiles Items
                if (business_records_File_FileUpload.HasFile)
                {
                    string fileName = Path.GetFileName(business_records_File_FileUpload.PostedFile.FileName);
                    business_records_File_FileUpload.PostedFile.SaveAs(Server.MapPath("/English/Main_Application/business_records/") + fileName);
                    addTenantCmd.Parameters.AddWithValue("@business_records_FileName", fileName);
                    addTenantCmd.Parameters.AddWithValue("@business_records_Path", "/English/Main_Application/business_records/" + fileName);
                }
                else
                {
                    addTenantCmd.Parameters.AddWithValue("@business_records_FileName", "No File");
                    addTenantCmd.Parameters.AddWithValue("@business_records_Path", "No File");
                }
                //************************************************************************************************************************
                //Fill The Database with All UploadFiles Items
                if (Company_registration_FileUpload.HasFile)
                {
                    string fileName_PassPort = Path.GetFileName(Company_registration_FileUpload.PostedFile.FileName);
                    Company_registration_FileUpload.PostedFile.SaveAs(Server.MapPath("/English/Main_Application/Company_registration/") + fileName_PassPort);
                    addTenantCmd.Parameters.AddWithValue("@Company_registration_FileName", fileName_PassPort);
                    addTenantCmd.Parameters.AddWithValue("@Company_registration_Path", "/English/Main_Application/Company_registration/" + fileName_PassPort);
                }
                else
                {
                    addTenantCmd.Parameters.AddWithValue("@Company_registration_FileName", "No File");
                    addTenantCmd.Parameters.AddWithValue("@Company_registration_Path", "No File");
                }

                addTenantCmd.ExecuteNonQuery();
                _sqlCon.Close();

                // Empty The TextBox And DropDownList

                txt_En_Tenant_Name.Text = "";
                txt_Ar_Tenant_Name.Text = "";
                // txt_Ar_Tenant_Nationality.Text = "";
                txt_Tenant_Tell.Text = "";
                txt_Tenant_Fax.Text = "";
                txt_Tenant_Mobile.Text = "";
                txt_Tenant_Email.Text = "";
                txt_Tenant_Address.Text = "";
                txt__Tenant_Nationality_Address.Text = "";
                using (MySqlCommand getTenantsTypeCmd = new MySqlCommand("SELECT * FROM tenant_type"))
                {
                    getTenantsTypeCmd.CommandType = CommandType.Text;
                    getTenantsTypeCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    Tenant_Type_DropDownList.DataSource = getTenantsTypeCmd.ExecuteReader();
                    Tenant_Type_DropDownList.DataTextField = "Tenant_English_Type";
                    Tenant_Type_DropDownList.DataValueField = "Tenant_Type_Id";
                    Tenant_Type_DropDownList.DataBind();
                    Tenant_Type_DropDownList.Items.Insert(0, "Select Tenant Type ....");
                    _sqlCon.Close();
                }

                lbl_Success_Add_New_Tenant.Text = "تمت الإضافة بنجاح";
            }
        }

        protected void btn_Back_To_Tenant_List_Click1(object sender, EventArgs e)
        {
            string Id = Request.QueryString["Id"];
            if (Id == "1")
            {
                Response.Redirect("Add-Contract.aspx");
            }
            else
            {
                Response.Redirect("Tenant_List.aspx");
            }


            
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
                Add_Tenant_Div.Visible=false;
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
        protected void End_Date_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txt_End_Date.Text = End_Date_Calendar.SelectedDate.ToShortDateString();

            if (txt_End_Date.Text != "")
            {
                End_Date_divCalendar.Visible = false;
                ImageButton1.Visible = false;
            }
        }

        protected void Date_Chosee_Click(object sender, EventArgs e)
        {
            End_Date_divCalendar.Visible = true;
            ImageButton1.Visible = true;
        }

        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            End_Date_divCalendar.Visible = false;
            ImageButton1.Visible = false;
        }

        protected void Add_Tenant_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("../Master_Panal/Add_company_rep.aspx");
        }
    }
}