using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Edit_Contract : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Contracting", 0, "R");
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Contracting", 2, "E");
                Utilities.Roles.Delete_permission_With_Reason(_sqlCon, Session["Role"].ToString(), "Contracting", Delete, Reason_Div);
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!this.IsPostBack)
            {
                //   Fill Employee Name DropDownList
                DataTable get_Employee_DataTable = new DataTable();
                _sqlCon.Open();
                MySqlCommand get_Employee_Cmd = new MySqlCommand("SELECT * FROM users WHERE Users_Name = @Users_Name", _sqlCon);
                MySqlDataAdapter get_Employee_Da = new MySqlDataAdapter(get_Employee_Cmd);
                get_Employee_Cmd.Parameters.AddWithValue("@Users_Name", Session["Users_Name"].ToString());
                get_Employee_Da.Fill(get_Employee_DataTable);
                if (get_Employee_DataTable.Rows.Count > 0)
                {
                    txt_Dtl_Employee_Name.Text = get_Employee_DataTable.Rows[0]["Users_Ar_First_Name"].ToString() + " " + get_Employee_DataTable.Rows[0]["Users_Ar_Last_Name"].ToString();
                }
                _sqlCon.Close();

                //    //Fill Tenant Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM tenants", _sqlCon, Tenan_Name_DropDownList, "Tenants_Arabic_Name", "Tenants_ID");
                Tenan_Name_DropDownList.Items.Insert(0, "إختر اسم المستأجر ....");

                //    //Fill Ownership Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM owner_ship", _sqlCon, Ownership_Name_DropDownList, "Owner_Ship_AR_Name", "Owner_Ship_Id");
                Ownership_Name_DropDownList.Items.Insert(0, "إختر الملكية ....");

                //    //Fill Building Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM building", _sqlCon, Building_Name_DropDownList, "Building_Arabic_Name", "Building_Id");
                Building_Name_DropDownList.Items.Insert(0, "إختر البناء ....");

                //    //Fill Units Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM units", _sqlCon, Units_DropDownList, "Unit_Number", "Unit_ID");
                Units_DropDownList.Items.Insert(0, "إختر الوحدة ....");

                //    //Fill contract_type DropDownList
                Helper.LoadDropDownList("SELECT * FROM contract_type", _sqlCon, Contract_Type_DropDownList, "Contract_Arabic_Type", "Contract_Type_Id");
                Contract_Type_DropDownList.Items.Insert(0, "إختر الوحدة الزمنية ....");

                //    //Fill Contract templet DropDownList
                Helper.LoadDropDownList("SELECT * FROM contract_template", _sqlCon, Contract_Templet_DropDownList, "Contract_Arabic_template", "Contract_template_Id");
                Contract_Templet_DropDownList.Items.Insert(0, "إختر نموذج العقد ....");

                //    //Fill Paymaent FrequencY DropDownList
                //Helper.LoadDropDownList("SELECT * FROM payment_frequency", _sqlCon, Payment_Frquancy_DropDownList, "Payment_Arabic_Frequency", "Payment_Frequency_Id");
                //Payment_Frquancy_DropDownList.Items.Insert(0, "إختر تكرار الدفعات ....");

                //    //Fill Paymaent Type DropDownList
                Helper.LoadDropDownList("SELECT * FROM payment_type", _sqlCon, Payment_Type_DropDownList, "payment_Arabic_type", "payment_type_Id");
                Payment_Type_DropDownList.Items.Insert(0, "إختر نوع الدفعات ....");

                //    //Fill Cheque_type DropDownList
                Helper.LoadDropDownList("SELECT * FROM cheque_type", _sqlCon, Cheque_Type_DropDownList, "Cheque_arabic_Type", "Cheque_Type_id");
                Cheque_Type_DropDownList.Items.Insert(0, "إخترنوع الشيك ....");

                //    //Fill Bank_Cheque_Name_DropDownList DropDownList
                Helper.LoadDropDownList("SELECT * FROM bank", _sqlCon, Bank_Cheque_Name_DropDownList, "Bank_Arabic_Name", "Bank_Id");
                Bank_Cheque_Name_DropDownList.Items.Insert(0, "إختراسم البنك ....");

                //    //Fill Reason_For_Rent_DropDownList
                Reason_For_Rent_DropDownList.Items.Insert(0, "إختر الغرض من الإيجار ....");

                Helper.LoadDropDownList("SELECT * FROM transformation_bank", _sqlCon, transformation_Bank_DropDownList, "Bank_Name", "transformation_Bank_ID");
                transformation_Bank_DropDownList.Items.Insert(0, "إختر اسم البنك ....");

                _sqlCon.Close();

                //************************ get The Contract Information **************************************************

                string Contract_Id = Request.QueryString["Id"];
                DataTable get_Contract_Dt = new DataTable();
                _sqlCon.Open();
                MySqlCommand get_Contract_Cmd = new MySqlCommand("SELECT * FROM contract WHERE Contract_Id = @ID", _sqlCon);
                MySqlDataAdapter get_Contract_Da = new MySqlDataAdapter(get_Contract_Cmd);
                get_Contract_Cmd.Parameters.AddWithValue("@ID", Contract_Id);
                get_Contract_Da.Fill(get_Contract_Dt);
                if (get_Contract_Dt.Rows.Count > 0)
                {
                    if (get_Contract_Dt.Rows[0]["Com_rep"].ToString() == "1")
                    {
                        Com_Rep_Div.Visible = false;
                    }
                    else
                    {
                        Com_Rep_Div.Visible = true;
                    }

                    if (get_Contract_Dt.Rows[0]["contract_type_Contract_Type_Id"].ToString() == "1")
                    {
                        lbl_No_Of_Months_Or_Years.Text = "عدد السنوات";
                        txt_No_Of_Months_Or_Years.ReadOnly = true;
                        txt_No_Of_Months_Or_Years.Text = get_Contract_Dt.Rows[0]["Number_Of_Years"].ToString();
                    }
                    else if (get_Contract_Dt.Rows[0]["contract_type_Contract_Type_Id"].ToString() == "2" || get_Contract_Dt.Rows[0]["contract_type_Contract_Type_Id"].ToString() == "3")
                    {
                        lbl_No_Of_Months_Or_Years.Text = "عدد الأشهر";
                        txt_No_Of_Months_Or_Years.ReadOnly = true;
                        txt_No_Of_Months_Or_Years.Text = get_Contract_Dt.Rows[0]["Number_Of_Mounth"].ToString();
                    }
                    else
                    {
                        lbl_No_Of_Months_Or_Years.Text = "عدد الأشهر";
                        txt_No_Of_Months_Or_Years.Text = get_Contract_Dt.Rows[0]["Number_Of_Mounth"].ToString();
                    }

                    //***********************************************************************************************

                    Com_Rep_DropDownList.SelectedValue = get_Contract_Dt.Rows[0]["Com_rep"].ToString();
                    txt_FREE_PERIOD.Text = get_Contract_Dt.Rows[0]["Start_Free_Period"].ToString();
                    txt_Duration_Of_The_Free_Period.Text = get_Contract_Dt.Rows[0]["Duration_free_period"].ToString();
                    Reason_For_Rent_DropDownList.SelectedValue = get_Contract_Dt.Rows[0]["reason_for_rent_Reason_For_Rent_Id"].ToString();
                    txt_Payment_Amount.Text = get_Contract_Dt.Rows[0]["Payment_Amount"].ToString();
                    txt_Payment_Amount_L.Text = get_Contract_Dt.Rows[0]["Payment_Amount_L"].ToString();
                    txt_Sign_Date.Text = get_Contract_Dt.Rows[0]["Date_Of_Sgin"].ToString();
                    txt_Start_Date.Text = get_Contract_Dt.Rows[0]["Start_Date"].ToString();
                    txt_End_Date.Text = get_Contract_Dt.Rows[0]["End_Date"].ToString();
                    txt_Contract_Details.Text = get_Contract_Dt.Rows[0]["Contract_Details"].ToString();
                    Tenan_Name_DropDownList.SelectedValue = get_Contract_Dt.Rows[0]["tenants_Tenants_ID"].ToString();

                    Real_Contract_FileName.Text = get_Contract_Dt.Rows[0]["Real_Contract_FileName"].ToString();
                    Real_Contract_Path.Text = get_Contract_Dt.Rows[0]["Real_Contract_Path"].ToString();


                    if (get_Contract_Dt.Rows[0]["Real_Contract_FileName"].ToString() != "") { Real_Contract_Div.Visible = true; }
                    else { Real_Contract_Div.Visible = false; }

                    lbl_Link_Real_Contract.Text = get_Contract_Dt.Rows[0]["Real_Contract_FileName"].ToString();
                    Link_Real_Contract.HRef = get_Contract_Dt.Rows[0]["Real_Contract_Path"].ToString();
                    Link_Real_Contract.Target = "_blank";




                    Helper.LoadDropDownList("SELECT * FROM company_representative where tenants_Tenants_ID ='" + Tenan_Name_DropDownList.SelectedValue + "'", _sqlCon, Com_Rep_DropDownList, "Com_rep_En_Name", "Company_representative_Id");
                    Com_Rep_DropDownList.Items.Insert(0, "إختر اسم الممثل ....");
                    Com_Rep_DropDownList.SelectedValue = get_Contract_Dt.Rows[0]["Com_rep"].ToString();

                    Contarct_tenant_Name.Text = Tenan_Name_DropDownList.SelectedItem.Text;
                    maintenance_RadioButtonList.SelectedValue = get_Contract_Dt.Rows[0]["maintenance"].ToString();
                    Rental_allowed_Or_Not_allowed_RadioButtonList.SelectedValue = get_Contract_Dt.Rows[0]["Rental_allowed_Or_Not_allowed"].ToString();

                    if(get_Contract_Dt.Rows[0]["Paymen_Method"].ToString() == "شيك") 
                    {
                        Paymen_Method_RadioButtonList.SelectedValue = "1"; Cheque_Div.Visible = true; Cash_div.Visible = false; transformation_Div.Visible = false;
                        lbl_Tenant_Cheque.Text = "شيكات المستأجر :" + Tenan_Name_DropDownList.SelectedItem.Text;
                    }
                    else if (get_Contract_Dt.Rows[0]["Paymen_Method"].ToString() == "تحويل") 
                    { 
                        Paymen_Method_RadioButtonList.SelectedValue = "2"; Cheque_Div.Visible = false; Cash_div.Visible = false; transformation_Div.Visible = true;
                        lbl_Tenant_Cheque.Text = "حوالات المستأجر :" + Tenan_Name_DropDownList.SelectedItem.Text;
                    }
                    else if (get_Contract_Dt.Rows[0]["Paymen_Method"].ToString() == "نقداً") 
                    {
                        lbl_Tenant_Cheque.Text = "دفعات المستأجر :" + Tenan_Name_DropDownList.SelectedItem.Text;
                        Paymen_Method_RadioButtonList.SelectedValue = "3"; Cheque_Div.Visible = false; Cash_div.Visible = true; transformation_Div.Visible = false; 
                    }



                    



                    
                    Units_DropDownList.SelectedValue = get_Contract_Dt.Rows[0]["units_Unit_ID"].ToString();
                    Contract_Type_DropDownList.SelectedValue = get_Contract_Dt.Rows[0]["contract_type_Contract_Type_Id"].ToString();
                    Contract_Templet_DropDownList.SelectedValue = get_Contract_Dt.Rows[0]["contract_template_Contract_template_Id"].ToString();
                    //Payment_Frquancy_DropDownList.SelectedValue = get_Contract_Dt.Rows[0]["payment_frequency_Payment_Frequency_Id"].ToString();
                    Payment_Type_DropDownList.SelectedValue = get_Contract_Dt.Rows[0]["payment_type_payment_type_Id"].ToString();
                }
                _sqlCon.Close();

                using (MySqlCommand get_Contract_ownership_drowpdownlist_Cmd = new MySqlCommand("Edit_Contract_Ownership_Unit_dropdownlist", _sqlCon))
                {
                    _sqlCon.Open();
                    get_Contract_ownership_drowpdownlist_Cmd.CommandType = CommandType.StoredProcedure;
                    get_Contract_ownership_drowpdownlist_Cmd.Parameters.AddWithValue("@Id", Units_DropDownList.SelectedValue);
                    using (MySqlDataAdapter get_Contract_ownership_drowpdownlist_Da = new MySqlDataAdapter(get_Contract_ownership_drowpdownlist_Cmd))
                    {
                        DataTable get_Contract_ownership_drowpdownlist_Dt = new DataTable();
                        get_Contract_ownership_drowpdownlist_Da.Fill(get_Contract_ownership_drowpdownlist_Dt);

                        Ownership_Name_DropDownList.SelectedValue = get_Contract_ownership_drowpdownlist_Dt.Rows[0]["Owner_Ship_Id"].ToString();
                        Building_Name_DropDownList.SelectedValue = get_Contract_ownership_drowpdownlist_Dt.Rows[0]["Building_Id"].ToString();
                    }
                    _sqlCon.Close();
                }
                this.BindGrid_Contract_Cheque_List();
                BindGrid_transportation_List();
                BindGrid_Cash_List();
            }
        }

        //*****************************************************************************************************************
        //*****************************************************************************************************************
        private void BindGrid_Contract_Cheque_List()
        {
            _sqlCon.Open();
            string ContractId = Request.QueryString["Id"];
            using (MySqlCommand Contract_ChequesCmd = new MySqlCommand("Contract_List_In_Edit_page", _sqlCon))
            {
                Contract_ChequesCmd.CommandType = CommandType.StoredProcedure;
                Contract_ChequesCmd.Parameters.AddWithValue("@Id", ContractId);
                MySqlDataAdapter Contract_ChequesSda = new MySqlDataAdapter(Contract_ChequesCmd);

                DataTable Contract_ChequesDt = new DataTable();
                Contract_ChequesSda.Fill(Contract_ChequesDt);
                Contract_ChequesCmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                Contract_ChequesSda.Fill(dt);
                Contract_Cheque_List.DataSource = dt;
                Contract_Cheque_List.DataBind();
            }
            _sqlCon.Close();
        }

        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string ChequeType;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    ChequeType = ((Label)e.Row.FindControl("lbl_cheque_Type")).Text;
                    if (ChequeType == "شيك ضمان")
                    {
                        e.Row.ForeColor = System.Drawing.Color.Blue;
                        e.Row.BackColor = System.Drawing.Color.AliceBlue;
                    }
                }
                catch
                {
                    ChequeType = "";
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow && Contract_Cheque_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddl_Cheque_Type = (DropDownList)e.Row.FindControl("cheque_type_DropDownList");
                string Cheque_Type_query = "SELECT * FROM cheque_type";
                using (MySqlDataAdapter sda = new MySqlDataAdapter(Cheque_Type_query, _sqlCon))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        ddl_Cheque_Type.DataSource = dt;
                        ddl_Cheque_Type.DataTextField = "Cheque_arabic_Type";
                        ddl_Cheque_Type.DataValueField = "Cheque_Type_id";
                        ddl_Cheque_Type.DataBind();
                        string selected_Cheque_Type = DataBinder.Eval(e.Row.DataItem, "cheque_type_Cheque_Type_id").ToString();
                        ddl_Cheque_Type.Items.FindByValue(selected_Cheque_Type).Selected = true;
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow && Contract_Cheque_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddl_Bank_Name = (DropDownList)e.Row.FindControl("bank_DropDownList");
                string Bank_Name_query = "SELECT * FROM bank";
                using (MySqlDataAdapter sda = new MySqlDataAdapter(Bank_Name_query, _sqlCon))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        ddl_Bank_Name.DataSource = dt;
                        ddl_Bank_Name.DataTextField = "Bank_Arabic_Name";
                        ddl_Bank_Name.DataValueField = "Bank_Id";
                        ddl_Bank_Name.DataBind();
                        string selected_Cheque_Type = DataBinder.Eval(e.Row.DataItem, "bank_Bank_Id").ToString();
                        ddl_Bank_Name.Items.FindByValue(selected_Cheque_Type).Selected = true;
                    }
                }
            }
        }

        protected void EditCustomer(object sender, GridViewEditEventArgs e)
        { Contract_Cheque_List.EditIndex = e.NewEditIndex; this.BindGrid_Contract_Cheque_List(); }

        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        { Contract_Cheque_List.EditIndex = -1; this.BindGrid_Contract_Cheque_List(); }

        protected void UpdateCustomer(object sender, GridViewUpdateEventArgs e)
        {
            string cheque_type = (Contract_Cheque_List.Rows[e.RowIndex].FindControl("cheque_type_DropDownList") as DropDownList).SelectedItem.Value;
            string bank = (Contract_Cheque_List.Rows[e.RowIndex].FindControl("bank_DropDownList") as DropDownList).SelectedItem.Value;
            TextBox Cheques_No = (Contract_Cheque_List.Rows[e.RowIndex].FindControl("txt_Cheques_No") as TextBox);

            TextBox Cheques_Amount = (Contract_Cheque_List.Rows[e.RowIndex].FindControl("txt_Cheques_Amount") as TextBox);

            TextBox Cheque_Owner = (Contract_Cheque_List.Rows[e.RowIndex].FindControl("txt_Cheque_Owner") as TextBox);
            TextBox beneficiary_person = (Contract_Cheque_List.Rows[e.RowIndex].FindControl("txt_beneficiary_person") as TextBox);

            Calendar Calendar2 = (Contract_Cheque_List.Rows[e.RowIndex]).FindControl("Calendar2") as Calendar;
            string calendar2 = Calendar2.SelectedDate.ToString("dd/MM/yyyy");
            Label lbl_Cheques_Date = (Contract_Cheque_List.Rows[e.RowIndex].FindControl("lbl_Cheques_Date") as Label);



            string Cheques_Id = Contract_Cheque_List.DataKeys[e.RowIndex].Value.ToString();

            string query = "UPDATE cheques SET" +
                            " Cheques_No = @Cheques_No ," +
                            " Cheque_Owner = @Cheque_Owner ," +

                            " beneficiary_person = @beneficiary_person ," +

                            " Cheques_Date = @Cheques_Date ," +
                            " Cheques_Amount = @Cheques_Amount ," +
                            " cheque_type_Cheque_Type_id = @cheque_type_Cheque_Type_id ," +
                            " bank_Bank_Id = @bank_Bank_Id " +
                            "WHERE Cheques_Id = @Cheques_Id";
            using (MySqlCommand cmd = new MySqlCommand(query, _sqlCon))
            {
                cmd.Parameters.AddWithValue("@Cheques_Id", Cheques_Id);
                cmd.Parameters.AddWithValue("@Cheques_No", Cheques_No.Text);

                cmd.Parameters.AddWithValue("@Cheques_Amount", Cheques_Amount.Text);

                cmd.Parameters.AddWithValue("@Cheque_Owner", Cheque_Owner.Text);
                cmd.Parameters.AddWithValue("@beneficiary_person", beneficiary_person.Text);


                if (calendar2 != "01/01/0001")
                {
                    cmd.Parameters.AddWithValue("@Cheques_Date", calendar2);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Cheques_Date", lbl_Cheques_Date.Text);
                }
                cmd.Parameters.AddWithValue("@cheque_type_Cheque_Type_id", cheque_type);
                cmd.Parameters.AddWithValue("@bank_Bank_Id", bank);

                _sqlCon.Open();
                cmd.ExecuteNonQuery();
                _sqlCon.Close();
                //Response.Redirect(Request.RawUrl);
                Contract_Cheque_List.EditIndex = -1; this.BindGrid_Contract_Cheque_List();
            }
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            if (txt_Cheque_NO.Text != "" & txt_Cheque_Date.Text != ""
                && txt_Cheque_Value.Text != "" & Cheque_Type_DropDownList.SelectedItem.Text != "إخترنوع الشيك ...."
                && Bank_Cheque_Name_DropDownList.SelectedItem.Text != "إختراسم البنك ...." &&
                Tenan_Name_DropDownList.SelectedItem.Text != "إختر اسم المستأجر ....")
            {
                string contractId = Request.QueryString["Id"];
                string Add_Cheque_In_Edit_Contract = "Insert Into cheques (" +
                                                    "Cheques_No , " +
                                                    "Cheques_Date  , " +
                                                    "Cheques_Amount        , " +
                                                    "Cheque_Owner ," +

                                                    "beneficiary_person ," +

                                                    "Cheques_Status ," +
                                                    "cheque_type_Cheque_Type_id       , " +
                                                    "bank_Bank_Id         , " +
                                                    "tenants_Tenants_ID , " +
                                                    "contract_Contract_Id ) " +
                                                    "VALUES( " +
                                                    "@Cheques_No , " +
                                                    "@Cheques_Date  , " +
                                                    "@Cheques_Amount        , " +
                                                    "@Cheque_Owner ," +
                                                    "@beneficiary_person ," +
                                                    "@Cheques_Status ," +
                                                    "@cheque_type_Cheque_Type_id       , " +
                                                    "@bank_Bank_Id         , " +
                                                    "@tenants_Tenants_ID , " +
                                                    "@contract_Contract_Id ) ";
                _sqlCon.Open();
                using (MySqlCommand Add_Cheque_In_Edit_Contract_Cmd = new MySqlCommand(Add_Cheque_In_Edit_Contract, _sqlCon))
                {
                    Add_Cheque_In_Edit_Contract_Cmd.Parameters.AddWithValue("@Cheques_No", txt_Cheque_NO.Text);
                    Add_Cheque_In_Edit_Contract_Cmd.Parameters.AddWithValue("@Cheques_Date", txt_Cheque_Date.Text);
                    Add_Cheque_In_Edit_Contract_Cmd.Parameters.AddWithValue("@Cheques_Amount", txt_Cheque_Value.Text);
                    Add_Cheque_In_Edit_Contract_Cmd.Parameters.AddWithValue("@Cheque_Owner", txt_Cheque_Owner.Text);
                    Add_Cheque_In_Edit_Contract_Cmd.Parameters.AddWithValue("@beneficiary_person", txt_beneficiary_person.Text);
                    Add_Cheque_In_Edit_Contract_Cmd.Parameters.AddWithValue("@Cheques_Status", "غير محصل");
                    Add_Cheque_In_Edit_Contract_Cmd.Parameters.AddWithValue("@cheque_type_Cheque_Type_id", Cheque_Type_DropDownList.SelectedValue);
                    Add_Cheque_In_Edit_Contract_Cmd.Parameters.AddWithValue("@bank_Bank_Id", Bank_Cheque_Name_DropDownList.SelectedValue);
                    Add_Cheque_In_Edit_Contract_Cmd.Parameters.AddWithValue("@tenants_Tenants_ID", Tenan_Name_DropDownList.SelectedValue);
                    Add_Cheque_In_Edit_Contract_Cmd.Parameters.AddWithValue("@contract_Contract_Id", contractId);
                    Add_Cheque_In_Edit_Contract_Cmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                txt_Cheque_NO.Text = ""; txt_Cheque_Date.Text = ""; txt_Cheque_Value.Text = ""; txt_Cheque_Owner.Text = ""; txt_beneficiary_person.Text = "";

                Helper.LoadDropDownList("SELECT * FROM cheque_type", _sqlCon, Cheque_Type_DropDownList, "Cheque_arabic_Type", "Cheque_Type_id");
                Cheque_Type_DropDownList.Items.Insert(0, "إخترنوع الشيك ....");

                Helper.LoadDropDownList("SELECT * FROM bank", _sqlCon, Bank_Cheque_Name_DropDownList, "Bank_Arabic_Name", "Bank_Id");
                Bank_Cheque_Name_DropDownList.Items.Insert(0, "إختراسم البنك ....");

                Helper.LoadDropDownList("SELECT * FROM tenants", _sqlCon, Tenan_Name_DropDownList, "Tenants_Arabic_Name", "Tenants_ID");
                Tenan_Name_DropDownList.Items.Insert(0, "إختر اسم المستأجر ....");
                BindGrid_Contract_Cheque_List();
            }
            else
            {
                lbl_Worrnig_Cheque.Visible = true;
            }
            ClientScript.RegisterClientScriptBlock(this.GetType(), "", "window.onload=function(){window.scrollTo(0,document.body.scrollHeight)};", true);
        }

        protected void btn_Add_Contract_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string contractId = Request.QueryString["Id"];
                string updateContractQuary = "UPDATE contract SET " +
                                               "users_user_ID=@users_user_ID ," +
                                               "tenants_Tenants_ID=@tenants_Tenants_ID, " +
                                               "Com_rep=@Com_rep, " +
                                               "units_Unit_ID=@units_Unit_ID , " +
                                               "contract_type_Contract_Type_Id=@contract_type_Contract_Type_Id, " +
                                               "contract_template_Contract_template_Id=@contract_template_Contract_template_Id , " +
                                               "payment_type_payment_type_Id=@payment_type_payment_type_Id , " +
                                               "reason_for_rent_Reason_For_Rent_Id=@reason_for_rent_Reason_For_Rent_Id , " +
                                               "Number_Of_Mounth=@Number_Of_Mounth , " +
                                               "Number_Of_Years=@Number_Of_Years , " +
                                               "Payment_Amount=@Payment_Amount ," +
                                               "Payment_Amount_L=@Payment_Amount_L ," +
                                               "maintenance=@maintenance ," +
                                               "Rental_allowed_Or_Not_allowed=@Rental_allowed_Or_Not_allowed ," +
                                               "Paymen_Method=@Paymen_Method ," +

                                               "Real_Contract_FileName=@Real_Contract_FileName ," +
                                               "Real_Contract_Path=@Real_Contract_Path ," +



                                               "Date_Of_Sgin=@Date_Of_Sgin  ," +
                                               "Start_Date=@Start_Date ," +
                                               "End_Date=@End_Date ," +
                                               "Start_Free_Period=@Start_Free_Period ," +
                                               "Duration_free_period=@Duration_free_period ," +
                                               "maintenance=@maintenance ," +
                                               "Rental_allowed_Or_Not_allowed=@Rental_allowed_Or_Not_allowed ," +
                                               "Contract_Details=@Contract_Details " +
                                               "WHERE Contract_Id=@ID ";
                _sqlCon.Open();
                using (MySqlCommand UpdateContractCmd = new MySqlCommand(updateContractQuary, _sqlCon))
                {
                    UpdateContractCmd.Parameters.AddWithValue("@ID", contractId);
                    //Fill The Database with All DropDownLists Items
                    UpdateContractCmd.Parameters.AddWithValue("@contract_type_Contract_Type_Id", Contract_Type_DropDownList.SelectedValue);
                    UpdateContractCmd.Parameters.AddWithValue("@contract_template_Contract_template_Id", Contract_Templet_DropDownList.SelectedValue);
                    //UpdateContractCmd.Parameters.AddWithValue("@payment_frequency_Payment_Frequency_Id", Payment_Frquancy_DropDownList.SelectedValue);
                    UpdateContractCmd.Parameters.AddWithValue("@tenants_Tenants_ID", Tenan_Name_DropDownList.SelectedValue);
                    UpdateContractCmd.Parameters.AddWithValue("@Com_rep", Com_Rep_DropDownList.SelectedValue);
                    UpdateContractCmd.Parameters.AddWithValue("@payment_type_payment_type_Id", Payment_Type_DropDownList.SelectedValue);
                    UpdateContractCmd.Parameters.AddWithValue("@units_Unit_ID", Units_DropDownList.SelectedValue);
                    UpdateContractCmd.Parameters.AddWithValue("@users_user_ID", Session["user_ID"]);
                    //Fill The Database with All Textbox Items
                    UpdateContractCmd.Parameters.AddWithValue("@Contract_Details", txt_Contract_Details.Text);
                    UpdateContractCmd.Parameters.AddWithValue("@Payment_Amount", txt_Payment_Amount.Text);
                    UpdateContractCmd.Parameters.AddWithValue("@Payment_Amount_L", txt_Payment_Amount_L.Text);
                    UpdateContractCmd.Parameters.AddWithValue("@maintenance", maintenance_RadioButtonList.SelectedValue);
                    UpdateContractCmd.Parameters.AddWithValue("@Rental_allowed_Or_Not_allowed", Rental_allowed_Or_Not_allowed_RadioButtonList.SelectedValue);
                    UpdateContractCmd.Parameters.AddWithValue("@Paymen_Method", Paymen_Method_RadioButtonList.SelectedItem.Text.Trim());
                    UpdateContractCmd.Parameters.AddWithValue("@Date_Of_Sgin", txt_Sign_Date.Text);
                    UpdateContractCmd.Parameters.AddWithValue("@Start_Date", txt_Start_Date.Text);
                    UpdateContractCmd.Parameters.AddWithValue("@End_Date", txt_End_Date.Text);

                    UpdateContractCmd.Parameters.AddWithValue("@reason_for_rent_Reason_For_Rent_Id", Reason_For_Rent_DropDownList.SelectedValue);
                    UpdateContractCmd.Parameters.AddWithValue("@Start_Free_Period", txt_FREE_PERIOD.Text);
                    UpdateContractCmd.Parameters.AddWithValue("@Duration_free_period", txt_Duration_Of_The_Free_Period.Text);

                    if (Contract_Type_DropDownList.SelectedValue == "1")
                    {
                        UpdateContractCmd.Parameters.AddWithValue("@Number_Of_Years", txt_No_Of_Months_Or_Years.Text);
                        UpdateContractCmd.Parameters.AddWithValue("@Number_Of_Mounth", "");
                    }
                    else
                    {
                        UpdateContractCmd.Parameters.AddWithValue("@Number_Of_Years", "");
                        UpdateContractCmd.Parameters.AddWithValue("@Number_Of_Mounth", txt_No_Of_Months_Or_Years.Text);
                    }



                    if (Real_Contract_FileUpload.HasFile)
                    {
                        string fileName1 = Path.GetFileName(Real_Contract_FileUpload.PostedFile.FileName);
                        Real_Contract_FileUpload.PostedFile.SaveAs( Server.MapPath("/English/Main_Application/Real_Contract/") + fileName1);
                        UpdateContractCmd.Parameters.AddWithValue("@Real_Contract_FileName", fileName1);
                        UpdateContractCmd.Parameters.AddWithValue("@Real_Contract_Path", "/English/Main_Application/Real_Contract/" + fileName1);
                    }
                    else
                    {
                        UpdateContractCmd.Parameters.AddWithValue("@Real_Contract_FileName", Real_Contract_FileName.Text);
                        UpdateContractCmd.Parameters.AddWithValue("@Real_Contract_Path", Real_Contract_Path.Text);
                    }

                    UpdateContractCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }

                Edit_Arcive_Contract();


                lbl_Success_Add_New_Contract.Text = "تم التعديل بنجاح";
                Response.Redirect("Contract_List.aspx");
            }
        }

        protected void btn_Back_To_Contract_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contract_List.aspx");
        }

        //*****************************************************************************************************************
        //*****************************************************************************************************************

        //******************  Get The Building Of Selected Ownership ***************************************************
        protected void Ownership_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    //Fill Buildings Name DropDownList
            Helper.LoadDropDownList("SELECT * FROM building where owner_ship_Owner_Ship_Id = '" + Ownership_Name_DropDownList.SelectedValue + "'", _sqlCon, Building_Name_DropDownList, "Building_Arabic_Name", "Building_Id");
            Building_Name_DropDownList.Items.Insert(0, "إختر البناء ....");
        }

        //******************  Get The Units Of Selected Building ***************************************************
        protected void Building_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    //Fill units Name DropDownList
            Helper.LoadDropDownList("SELECT * FROM units where building_Building_Id = '" + Building_Name_DropDownList.SelectedValue + "'", _sqlCon, Units_DropDownList, "Unit_Number", "Unit_ID");
            Units_DropDownList.Items.Insert(0, "إختر الوحدة ....");
        }

        //*********************** FREE_PERIOD_CheckBox Event ************************
        protected void FREE_PERIOD_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FREE_PERIOD_CheckBox.Checked == true)
            {
                FREE_PERIOD_Div.Visible = true;
            }
            else if (FREE_PERIOD_CheckBox.Checked == false)
            {
                FREE_PERIOD_Div.Visible = false;
            }
        }

        //*********************** Additional_Items_CheckBox Event ************************
        protected void Additional_Items_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Additional_Items_CheckBox.Checked == true)
            {
                Contract_Details_Div.Visible = true;
            }
            else if (Additional_Items_CheckBox.Checked == false)
            {
                Contract_Details_Div.Visible = false;
            }
        }

        //******************  Sign_Date ***************************************************
        protected void Sign_Date_Calendar_SelectionChanged1(object sender, EventArgs e)
        {
            txt_Sign_Date.Text = Sign_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_Sign_Date.Text != "") { Sign_Date_divCalendar.Visible = false; ImageButton1.Visible = false; }
        }

        protected void Date_Chosee_Click(object sender, EventArgs e)
        {
            Sign_Date_divCalendar.Visible = true; ImageButton1.Visible = true;
        }

        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Sign_Date_divCalendar.Visible = false; ImageButton1.Visible = false;
        }

        //******************  Start_Date ***************************************************
        protected void Start_Date_Calendar_SelectionChanged2(object sender, EventArgs e)
        {
            txt_Start_Date.Text = Start_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_Start_Date.Text != "") { Start_Date_Div.Visible = false; ImageButton2.Visible = false; }

            if (txt_No_Of_Months_Or_Years.Text != "")
            {
                if (Contract_Type_DropDownList.SelectedValue == "1")
                {
                    DateTime add_Months = Convert.ToDateTime(txt_Start_Date.Text).AddMonths(Convert.ToInt32(txt_No_Of_Months_Or_Years.Text) * 12);
                    txt_End_Date.Text = add_Months.ToString("dd/MM/yyyy");
                }
                else
                {
                    DateTime add_Months = Convert.ToDateTime(txt_Start_Date.Text).AddMonths(Convert.ToInt32(txt_No_Of_Months_Or_Years.Text));
                    txt_End_Date.Text = add_Months.ToString("dd/MM/yyyy");
                }
            }
        }

        protected void Start_Date_Chosee_Click(object sender, EventArgs e)
        {
            Start_Date_Div.Visible = true; ImageButton2.Visible = true;
        }

        protected void ImageButton2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Start_Date_Div.Visible = false; ImageButton2.Visible = false;
        }

        //******************  End_Date ***************************************************
        protected void End_Date_Chosee_Click(object sender, EventArgs e)
        {
            End_Date_Div.Visible = true; ImageButton3.Visible = true;
        }

        protected void ImageButton3_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            End_Date_Div.Visible = false; ImageButton3.Visible = false;
        }

        protected void End_Date_Calendar_SelectionChanged1(object sender, EventArgs e)
        {
            txt_End_Date.Text = End_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_End_Date.Text != "") { End_Date_Div.Visible = false; ImageButton3.Visible = false; }
        }

        //************************ Cheque_ Date **********************************************************
        protected void btn_Cheque_Date_Chosee_Click(object sender, EventArgs e)
        {
            Cheque_Date_Div.Visible = true; Cheque_Date_ImageButton.Visible = true;
        }

        protected void Cheque_Date_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txt_Cheque_Date.Text = Cheque_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_Cheque_Date.Text != "") { Cheque_Date_Div.Visible = false; Cheque_Date_ImageButton.Visible = false; }
        }

        protected void Cheque_Date_ImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Cheque_Date_Div.Visible = false; Cheque_Date_ImageButton.Visible = false;
        }

        //************************ Contract_Type_DropDownList **********************************************************
        protected void Contract_Type_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            div_No_Of_Months.Visible = true;
            if (Contract_Type_DropDownList.SelectedValue == "1")
            {
                lbl_No_Of_Months_Or_Years.Text = "عدد السنوات";
                txt_No_Of_Months_Or_Years.ReadOnly = false;
                txt_No_Of_Months_Or_Years.Text = "1";

                if (txt_Start_Date.Text != "")
                {
                    if (txt_No_Of_Months_Or_Years.Text != "")
                    {
                        DateTime add_Months = Convert.ToDateTime(txt_Start_Date.Text).AddMonths(Convert.ToInt32(txt_No_Of_Months_Or_Years.Text) * 12);
                        txt_End_Date.Text = add_Months.ToString("dd/MM/yyyy");
                    }
                }
            }
            else if (Contract_Type_DropDownList.SelectedValue == "2")
            {
                lbl_No_Of_Months_Or_Years.Text = "عدد الأشهر";
                txt_No_Of_Months_Or_Years.Text = "6";
                txt_No_Of_Months_Or_Years.ReadOnly = true;

                if (txt_Start_Date.Text != "")
                {
                    if (txt_No_Of_Months_Or_Years.Text != "")
                    {
                        DateTime add_Months = Convert.ToDateTime(txt_Start_Date.Text).AddMonths(6);
                        txt_End_Date.Text = add_Months.ToString("dd/MM/yyyy");
                    }
                }
            }
            else if (Contract_Type_DropDownList.SelectedValue == "3")
            {
                lbl_No_Of_Months_Or_Years.Text = "عدد الأشهر";
                txt_No_Of_Months_Or_Years.Text = "3";
                txt_No_Of_Months_Or_Years.ReadOnly = true;

                if (txt_Start_Date.Text != "")
                {
                    if (txt_No_Of_Months_Or_Years.Text != "")
                    {
                        DateTime add_Months = Convert.ToDateTime(txt_Start_Date.Text).AddMonths(3);
                        txt_End_Date.Text = add_Months.ToString("dd/MM/yyyy");
                    }
                }
            }
            else
            {
                lbl_No_Of_Months_Or_Years.Text = "عدد الأشهر";
                txt_No_Of_Months_Or_Years.ReadOnly = false;
                txt_No_Of_Months_Or_Years.Text = "1";

                if (txt_Start_Date.Text != "")
                {
                    if (txt_No_Of_Months_Or_Years.Text != "")
                    {
                        DateTime add_Months = Convert.ToDateTime(txt_Start_Date.Text).AddMonths(Convert.ToInt32(txt_No_Of_Months_Or_Years.Text));
                        txt_End_Date.Text = add_Months.ToString("dd/MM/yyyy");
                    }
                }
            }
        }

        protected void txt_No_Of_Months_Or_Years_TextChanged(object sender, EventArgs e)
        {
            if (txt_Start_Date.Text != "")
            {
                if (txt_No_Of_Months_Or_Years.Text != "")
                {
                    if (Contract_Type_DropDownList.SelectedValue == "1")
                    {
                        if (txt_Duration_Of_The_Free_Period.Text != "")
                        {
                            DateTime add_Months = Convert.ToDateTime(txt_Start_Date.Text).AddMonths(Convert.ToInt32(txt_No_Of_Months_Or_Years.Text) * 12);
                            DateTime add_Months_With_Free_Period = add_Months.AddMonths(Convert.ToInt32(txt_Duration_Of_The_Free_Period.Text));
                            txt_End_Date.Text = add_Months_With_Free_Period.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            DateTime add_Months = Convert.ToDateTime(txt_Start_Date.Text).AddMonths(Convert.ToInt32(txt_No_Of_Months_Or_Years.Text) * 12);
                            txt_End_Date.Text = add_Months.ToString("dd/MM/yyyy");
                        }
                    }
                    else
                    {
                        DateTime add_Months = Convert.ToDateTime(txt_Start_Date.Text).AddMonths(Convert.ToInt32(txt_No_Of_Months_Or_Years.Text));
                        txt_End_Date.Text = add_Months.ToString("dd/MM/yyyy");
                    }
                }
            }
        }

        protected void Contract_Cheque_List_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(Contract_Cheque_List.DataKeys[e.RowIndex].Values["Cheques_Id"].ToString());
            _sqlCon.Open();
            MySqlCommand cmd = new MySqlCommand("delete from cheques where Cheques_Id =@Cheques_Id", _sqlCon);
            cmd.Parameters.AddWithValue("Cheques_Id", id);
            cmd.ExecuteNonQuery();
            _sqlCon.Close();
            BindGrid_Contract_Cheque_List();
        }

        protected void txt_Duration_Of_The_Free_Period_TextChanged(object sender, EventArgs e)
        {
            // txt_Start_Date.Text = Start_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_Start_Date.Text != "") { Start_Date_Div.Visible = false; ImageButton2.Visible = false; }

            if (txt_No_Of_Months_Or_Years.Text != "")
            {
                if (Contract_Type_DropDownList.SelectedValue == "1")
                {
                    if (txt_Duration_Of_The_Free_Period.Text != "")
                    {
                        DateTime add_Months = Convert.ToDateTime(txt_Start_Date.Text).AddMonths(Convert.ToInt32(txt_No_Of_Months_Or_Years.Text) * 12);
                        DateTime add_Months_With_Free_Period = add_Months.AddMonths(Convert.ToInt32(txt_Duration_Of_The_Free_Period.Text));
                        txt_End_Date.Text = add_Months_With_Free_Period.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        DateTime add_Months = Convert.ToDateTime(txt_Start_Date.Text).AddMonths(Convert.ToInt32(txt_No_Of_Months_Or_Years.Text) * 12);
                        txt_End_Date.Text = add_Months.ToString("dd/MM/yyyy");
                    }
                }
                else
                {
                    if (txt_Duration_Of_The_Free_Period.Text != "")
                    {
                        DateTime add_Months = Convert.ToDateTime(txt_Start_Date.Text).AddMonths(Convert.ToInt32(txt_No_Of_Months_Or_Years.Text));
                        DateTime add_Months_With_Free_Period = add_Months.AddMonths(Convert.ToInt32(txt_Duration_Of_The_Free_Period.Text));
                        txt_End_Date.Text = add_Months_With_Free_Period.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        DateTime add_Months = Convert.ToDateTime(txt_Start_Date.Text).AddMonths(Convert.ToInt32(txt_No_Of_Months_Or_Years.Text));
                        txt_End_Date.Text = add_Months.ToString("dd/MM/yyyy");
                    }
                }
            }
        }

        protected void Tenan_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Tenant_Id = Tenan_Name_DropDownList.SelectedValue;
            DataTable get_Tenant_Id_Dt = new DataTable();
            _sqlCon.Open();
            MySqlCommand get_Tenant_Id_Cmd = new MySqlCommand("SELECT * FROM tenants where Tenants_ID='" + Tenant_Id + "'", _sqlCon);
            MySqlDataAdapter get_Tenant_Id_Da = new MySqlDataAdapter(get_Tenant_Id_Cmd);
            get_Tenant_Id_Da.Fill(get_Tenant_Id_Dt);
            if (get_Tenant_Id_Dt.Rows.Count > 0)
            {
                if (get_Tenant_Id_Dt.Rows[0]["tenant_type_Tenant_Type_Id"].ToString() == "2")
                {
                    Com_Rep_Div.Visible = true;
                    //    //Fill Com_Rep_DropDownList
                    string Tenan_Name_ID = Tenan_Name_DropDownList.SelectedValue;
                    Helper.LoadDropDownList("SELECT * FROM company_representative where tenants_Tenants_ID ='" + Tenan_Name_ID + "'", _sqlCon, Com_Rep_DropDownList, "Com_rep_En_Name", "Company_representative_Id");
                    Com_Rep_DropDownList.Items.Insert(0, "إختر اسم الممثل ....");
                }
                else
                {
                    string Tenan_Name_ID = Tenan_Name_DropDownList.SelectedValue;
                    Com_Rep_Div.Visible = false;
                    Helper.LoadDropDownList("SELECT * FROM company_representative ", _sqlCon, Com_Rep_DropDownList, "Com_rep_En_Name", "Company_representative_Id");
                    Com_Rep_DropDownList.Items.Insert(0, "إختر اسم الممثل ....");
                    Com_Rep_DropDownList.SelectedValue = "1";
                }
            }
        }


        //******************   transformation_Date ***************************************************
        protected void transformation_Date_Button_Click(object sender, EventArgs e)
        {
            transformation_Date_Div.Visible = true;
            ImageButton5.Visible = true;
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            transformation_Date_Div.Visible = false;
            ImageButton5.Visible = false;
        }

        protected void transformation_Date_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txt_transformation_Date.Text = transformation_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_transformation_Date.Text != "")
            {
                transformation_Date_Div.Visible = false;
                ImageButton5.Visible = false;
            }
        }
        //******************   Cash_Date ***************************************************
        protected void Cash_Date_Button_Click(object sender, EventArgs e)
        {
            Cash_Date_Div.Visible = true;
            ImageButton6.Visible = true;
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            Cash_Date_Div.Visible = false;
            ImageButton6.Visible = false;
        }

        protected void Cash_Date_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txt_Cash_Date.Text = Cash_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_Cash_Date.Text != "")
            {
                Cash_Date_Div.Visible = false;
                ImageButton6.Visible = false;
            }
        }

        protected void btn_Add_Transformation_Click(object sender, ImageClickEventArgs e)
        {
            string contractId = Request.QueryString["Id"];
            string Add_Transformation_In_Edit_Contract = "Insert Into transformation_table (" +
                                                "transformation_Bank_ID , " +
                                                "transformation_No , " +
                                                "transformation_Date , " +
                                                "Amount , " +
                                                "Status , " +
                                                "tenant_Id , " +
                                                "Contract_Id ) " +
                                                "VALUES( " +
                                                "@transformation_Bank_ID , " +
                                                "@transformation_No , " +
                                                "@transformation_Date , " +
                                                "@Amount , " +
                                                "@Status , " +
                                                "@tenant_Id , " +
                                                "@Contract_Id ) ";
            _sqlCon.Open();
            using (MySqlCommand Add_Transformation_In_Edit_Contract_Cmd = new MySqlCommand(Add_Transformation_In_Edit_Contract, _sqlCon))
            {
                Add_Transformation_In_Edit_Contract_Cmd.Parameters.AddWithValue("@transformation_Bank_ID", transformation_Bank_DropDownList.SelectedValue);
                Add_Transformation_In_Edit_Contract_Cmd.Parameters.AddWithValue("@transformation_No", txt_transformation_No.Text);
                Add_Transformation_In_Edit_Contract_Cmd.Parameters.AddWithValue("@transformation_Date", txt_transformation_Date.Text);
                Add_Transformation_In_Edit_Contract_Cmd.Parameters.AddWithValue("@Amount", txt_transformation_Amount.Text);
                Add_Transformation_In_Edit_Contract_Cmd.Parameters.AddWithValue("@Status", "غير محصل");
                Add_Transformation_In_Edit_Contract_Cmd.Parameters.AddWithValue("@tenant_Id", Tenan_Name_DropDownList.SelectedValue);
                Add_Transformation_In_Edit_Contract_Cmd.Parameters.AddWithValue("@Contract_Id", contractId);
                Add_Transformation_In_Edit_Contract_Cmd.ExecuteNonQuery();
                _sqlCon.Close();
            }
            BindGrid_transportation_List();
        }

        protected void Add_Cash_Click(object sender, ImageClickEventArgs e)
        {
            string contractId = Request.QueryString["Id"];
            string Add_Cash_In_Edit_Contract = "Insert Into cash_amount (" +
                                                "Cash_Amount , " +
                                                "Cash_Date , " +
                                                "tenant_Id , " +
                                                "Satuts , " +
                                                "Contract_Id ) " +
                                                "VALUES( " +
                                                "@Cash_Amount , " +
                                                "@Cash_Date , " +
                                                "@tenant_Id , " +
                                                "@Satuts , " +
                                                "@Contract_Id ) ";
            _sqlCon.Open();
            using (MySqlCommand Add_Cash_In_Edit_Contract_Cmd = new MySqlCommand(Add_Cash_In_Edit_Contract, _sqlCon))
            {
                Add_Cash_In_Edit_Contract_Cmd.Parameters.AddWithValue("@Cash_Amount", txt_Cash_Amount.Text);
                Add_Cash_In_Edit_Contract_Cmd.Parameters.AddWithValue("@Cash_Date", txt_Cash_Date.Text);
                Add_Cash_In_Edit_Contract_Cmd.Parameters.AddWithValue("@tenant_Id", Tenan_Name_DropDownList.SelectedValue);
                Add_Cash_In_Edit_Contract_Cmd.Parameters.AddWithValue("@Satuts", "غير محصل");
                Add_Cash_In_Edit_Contract_Cmd.Parameters.AddWithValue("@Contract_Id", contractId);
                Add_Cash_In_Edit_Contract_Cmd.ExecuteNonQuery();
                _sqlCon.Close();
            }
            BindGrid_Cash_List();
        }

        private void BindGrid_Cash_List()
        {
            string contractId = Request.QueryString["Id"];
            string getCashsQuari = "select Csh.*, T.Tenants_Arabic_Name FROM  cash_amount Csh left join tenants T on (Csh.tenant_Id = T.Tenants_ID) where Contract_Id = '"+ contractId + "';";
            MySqlCommand getCashsCmd = new MySqlCommand(getCashsQuari, _sqlCon);
            MySqlDataAdapter getCashsDt = new MySqlDataAdapter(getCashsCmd);
            getCashsCmd.Connection = _sqlCon;
            _sqlCon.Open();
            getCashsDt.SelectCommand = getCashsCmd;
            DataTable getCashsDataTable = new DataTable();
            getCashsDt.Fill(getCashsDataTable);
            Cash_GridView.DataSource = getCashsDataTable;
            Cash_GridView.DataBind();
            _sqlCon.Close();
        }


        protected void Cash_GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(Cash_GridView.DataKeys[e.RowIndex].Values["Cash_Amount_ID"].ToString());
            _sqlCon.Open();
            MySqlCommand cmd = new MySqlCommand("delete from cash_amount where Cash_Amount_ID =@Cash_Amount_ID", _sqlCon);
            cmd.Parameters.AddWithValue("Cash_Amount_ID", id);
            cmd.ExecuteNonQuery();
            _sqlCon.Close();
            BindGrid_Cash_List();
        }

       




        private void BindGrid_transportation_List()
        {
            string contractId = Request.QueryString["Id"];
            string gettransportationsQuari = "select Tr_Tb.*,  B.Bank_Name ,T.Tenants_Arabic_Name " +
                                            "FROM  transformation_table Tr_Tb " +
                                            "left join  transformation_bank B on (Tr_Tb.transformation_Bank_ID = B.transformation_Bank_ID) " +
                                            "left join  tenants T on (Tr_Tb.tenant_Id = T.Tenants_ID) " +
                                            "where Contract_Id = '"+ contractId + "';";



            MySqlCommand gettransportationsCmd = new MySqlCommand(gettransportationsQuari, _sqlCon);
            MySqlDataAdapter gettransportationsDt = new MySqlDataAdapter(gettransportationsCmd);
            gettransportationsCmd.Connection = _sqlCon;
            _sqlCon.Open();
            gettransportationsDt.SelectCommand = gettransportationsCmd;
            DataTable gettransportationsDataTable = new DataTable();
            gettransportationsDt.Fill(gettransportationsDataTable);
            transformation_GridView.DataSource = gettransportationsDataTable;
            transformation_GridView.DataBind();
            _sqlCon.Close();
        }
        protected void transformation_GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(transformation_GridView.DataKeys[e.RowIndex].Values["transformation_Table_ID"].ToString());
            _sqlCon.Open();
            MySqlCommand cmd = new MySqlCommand("delete from transformation_table where transformation_Table_ID =@transformation_Table_ID", _sqlCon);
            cmd.Parameters.AddWithValue("transformation_Table_ID", id);
            cmd.ExecuteNonQuery();
            _sqlCon.Close();
            BindGrid_transportation_List();
        }

        protected void Paymen_Method_RadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Paymen_Method_RadioButtonList.SelectedValue == "1") { Cheque_Div.Visible = true;  transformation_Div.Visible = false; Cash_div.Visible = false; }
            else if (Paymen_Method_RadioButtonList.SelectedValue == "2") { Cheque_Div.Visible = false; transformation_Div.Visible = true; Cash_div.Visible = false;  }
            else if (Paymen_Method_RadioButtonList.SelectedValue == "3") { Cheque_Div.Visible = false; transformation_Div.Visible = false; Cash_div.Visible = true;  }
            ClientScript.RegisterClientScriptBlock(this.GetType(), "", "window.onload=function(){window.scrollTo(0,document.body.scrollHeight)};", true);
        }

        protected void Delete_Contract_Click(object sender, EventArgs e)
        {


            string ContractId = Request.QueryString["ID"];

            _sqlCon.Open();
            DataTable getTransformationDt = new DataTable();
            MySqlCommand getTransformationCmd = new MySqlCommand("SELECT Contract_Id FROM transformation_table WHERE Contract_Id = @ID And Status = 'غير محصل'", _sqlCon);
            MySqlDataAdapter getTransformationDa = new MySqlDataAdapter(getTransformationCmd);
            getTransformationCmd.Parameters.AddWithValue("@ID", ContractId);
            getTransformationDa.Fill(getTransformationDt);
            if (getTransformationDt.Rows.Count == 0)
            {
                DataTable getCashDt = new DataTable();
                MySqlCommand getCashCmd = new MySqlCommand("SELECT Contract_Id FROM cash_amount WHERE Contract_Id = @ID And Satuts = 'غير محصل'", _sqlCon);
                MySqlDataAdapter getCashDa = new MySqlDataAdapter(getCashCmd);
                getCashCmd.Parameters.AddWithValue("@ID", ContractId);
                getCashDa.Fill(getCashDt);
                if (getCashDt.Rows.Count == 0)
                {

                    try
                    {
                        string deleteContractQuary = "DELETE FROM contract WHERE Contract_Id=@ID ";
                        MySqlCommand mySqlCmd = new MySqlCommand(deleteContractQuary, _sqlCon);
                        mySqlCmd.Parameters.AddWithValue("@ID", ContractId);
                        mySqlCmd.ExecuteNonQuery();



                        string addArciveContractQuary = "Insert Into delete_archive " +
                                                                    "(User_Id," +
                                                                    "Delete_Date," +
                                                                    "OS_B_U," +
                                                                    "Item_Id," +
                                                                    "Reason_Delete) " +
                                                                    "VALUES" +
                                                                    "(@User_Id," +
                                                                    "@Delete_Date," +
                                                                    "@OS_B_U," +
                                                                    "@Item_Id," +
                                                                    "@Reason_Delete)";
                        MySqlCommand addArciveContractCmd = new MySqlCommand(addArciveContractQuary, _sqlCon);
                        addArciveContractCmd.Parameters.AddWithValue("@User_Id", Session["user_ID"].ToString());
                        addArciveContractCmd.Parameters.AddWithValue("@Delete_Date", DateTime.Now.ToString("dd/MM/yyyy"));
                        addArciveContractCmd.Parameters.AddWithValue("@OS_B_U", "C");
                        addArciveContractCmd.Parameters.AddWithValue("@Item_Id", ContractId);
                        addArciveContractCmd.Parameters.AddWithValue("@Reason_Delete", txt_Reason_Delete.Text);
                        addArciveContractCmd.ExecuteNonQuery();


                        Response.Redirect("Contract_List.aspx");
                    }
                    catch
                    {
                        Response.Write(@"<script language='javascript'>alert('لا يمكن حذف هذه البناء لأنه يحتوي على  وحدات أو عقود ')</script>");
                    };
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('لا يمكن حذف هذا العقد لأنه يحتوي على دفعات نقدية غير محصلة')</script>");
                }
            }

            else
            {
                Response.Write(@"<script language='javascript'>alert('لا يمكن حذف هذا العقد لأنه يحتوي على حوالات غير محصلة')</script>");
            }
            _sqlCon.Close();
        }

        protected void Edit_Arcive_Contract()
        {
            string contractId = Request.QueryString["Id"];
            string updateContractQuary = "UPDATE arcive_contract SET " +
                                           "users_user_ID=@users_user_ID ," +
                                           "tenants_Tenants_ID=@tenants_Tenants_ID, " +
                                           "Com_rep=@Com_rep, " +
                                           "units_Unit_ID=@units_Unit_ID , " +
                                           "contract_type_Contract_Type_Id=@contract_type_Contract_Type_Id, " +
                                           "contract_template_Contract_template_Id=@contract_template_Contract_template_Id , " +
                                           "payment_type_payment_type_Id=@payment_type_payment_type_Id , " +
                                           "reason_for_rent_Reason_For_Rent_Id=@reason_for_rent_Reason_For_Rent_Id , " +
                                           "Number_Of_Mounth=@Number_Of_Mounth , " +
                                           "Number_Of_Years=@Number_Of_Years , " +
                                           "Payment_Amount=@Payment_Amount ," +
                                           "Payment_Amount_L=@Payment_Amount_L ," +
                                           "maintenance=@maintenance ," +
                                           "Rental_allowed_Or_Not_allowed=@Rental_allowed_Or_Not_allowed ," +
                                           "Paymen_Method=@Paymen_Method ," +

                                           "Real_Contract_FileName=@Real_Contract_FileName ," +
                                           "Real_Contract_Path=@Real_Contract_Path ," +



                                           "Date_Of_Sgin=@Date_Of_Sgin  ," +
                                           "Start_Date=@Start_Date ," +
                                           "End_Date=@End_Date ," +
                                           "Start_Free_Period=@Start_Free_Period ," +
                                           "Duration_free_period=@Duration_free_period ," +
                                           "maintenance=@maintenance ," +
                                           "Rental_allowed_Or_Not_allowed=@Rental_allowed_Or_Not_allowed ," +
                                           "Contract_Details=@Contract_Details " +
                                           "WHERE Contract_Id=@ID ";
            _sqlCon.Open();
            using (MySqlCommand UpdateContractCmd = new MySqlCommand(updateContractQuary, _sqlCon))
            {
                UpdateContractCmd.Parameters.AddWithValue("@ID", contractId);
                //Fill The Database with All DropDownLists Items
                UpdateContractCmd.Parameters.AddWithValue("@contract_type_Contract_Type_Id", Contract_Type_DropDownList.SelectedValue);
                UpdateContractCmd.Parameters.AddWithValue("@contract_template_Contract_template_Id", Contract_Templet_DropDownList.SelectedValue);
                //UpdateContractCmd.Parameters.AddWithValue("@payment_frequency_Payment_Frequency_Id", Payment_Frquancy_DropDownList.SelectedValue);
                UpdateContractCmd.Parameters.AddWithValue("@tenants_Tenants_ID", Tenan_Name_DropDownList.SelectedValue);
                UpdateContractCmd.Parameters.AddWithValue("@Com_rep", Com_Rep_DropDownList.SelectedValue);
                UpdateContractCmd.Parameters.AddWithValue("@payment_type_payment_type_Id", Payment_Type_DropDownList.SelectedValue);
                UpdateContractCmd.Parameters.AddWithValue("@units_Unit_ID", Units_DropDownList.SelectedValue);
                UpdateContractCmd.Parameters.AddWithValue("@users_user_ID", Session["user_ID"]);
                //Fill The Database with All Textbox Items
                UpdateContractCmd.Parameters.AddWithValue("@Contract_Details", txt_Contract_Details.Text);
                UpdateContractCmd.Parameters.AddWithValue("@Payment_Amount", txt_Payment_Amount.Text);
                UpdateContractCmd.Parameters.AddWithValue("@Payment_Amount_L", txt_Payment_Amount_L.Text);
                UpdateContractCmd.Parameters.AddWithValue("@maintenance", maintenance_RadioButtonList.SelectedValue);
                UpdateContractCmd.Parameters.AddWithValue("@Rental_allowed_Or_Not_allowed", Rental_allowed_Or_Not_allowed_RadioButtonList.SelectedValue);
                UpdateContractCmd.Parameters.AddWithValue("@Paymen_Method", Paymen_Method_RadioButtonList.SelectedItem.Text.Trim());
                UpdateContractCmd.Parameters.AddWithValue("@Date_Of_Sgin", txt_Sign_Date.Text);
                UpdateContractCmd.Parameters.AddWithValue("@Start_Date", txt_Start_Date.Text);
                UpdateContractCmd.Parameters.AddWithValue("@End_Date", txt_End_Date.Text);

                UpdateContractCmd.Parameters.AddWithValue("@reason_for_rent_Reason_For_Rent_Id", Reason_For_Rent_DropDownList.SelectedValue);
                UpdateContractCmd.Parameters.AddWithValue("@Start_Free_Period", txt_FREE_PERIOD.Text);
                UpdateContractCmd.Parameters.AddWithValue("@Duration_free_period", txt_Duration_Of_The_Free_Period.Text);

                if (Contract_Type_DropDownList.SelectedValue == "1")
                {
                    UpdateContractCmd.Parameters.AddWithValue("@Number_Of_Years", txt_No_Of_Months_Or_Years.Text);
                    UpdateContractCmd.Parameters.AddWithValue("@Number_Of_Mounth", "");
                }
                else
                {
                    UpdateContractCmd.Parameters.AddWithValue("@Number_Of_Years", "");
                    UpdateContractCmd.Parameters.AddWithValue("@Number_Of_Mounth", txt_No_Of_Months_Or_Years.Text);
                }



                if (Real_Contract_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(Real_Contract_FileUpload.PostedFile.FileName);
                    Real_Contract_FileUpload.PostedFile.SaveAs(Server.MapPath("/English/Main_Application/Real_Contract/") + fileName1);
                    UpdateContractCmd.Parameters.AddWithValue("@Real_Contract_FileName", fileName1);
                    UpdateContractCmd.Parameters.AddWithValue("@Real_Contract_Path", "/English/Main_Application/Real_Contract/" + fileName1);
                }
                else
                {
                    UpdateContractCmd.Parameters.AddWithValue("@Real_Contract_FileName", Real_Contract_FileName.Text);
                    UpdateContractCmd.Parameters.AddWithValue("@Real_Contract_Path", Real_Contract_Path.Text);
                }

                UpdateContractCmd.ExecuteNonQuery();
                _sqlCon.Close();
            }
        }

        protected void Btn_Remove_Link_Real_Contract_Click(object sender, ImageClickEventArgs e)
        {
            string Contrac_Id = Request.QueryString["ID"];

            string Remove_Real_Contrac_Att_Query = "UPDATE contract SET " +
                                            " Real_Contract_FileName=@Real_Contract_FileName ," +
                                            " Real_Contract_Path=@Real_Contract_Path  " +
                                            "WHERE Contract_Id=@ID";
            _sqlCon.Open();
            MySqlCommand Remove_Real_Contrac_Att_Cmd = new MySqlCommand(Remove_Real_Contrac_Att_Query, _sqlCon);
            Remove_Real_Contrac_Att_Cmd.Parameters.AddWithValue("@ID", Contrac_Id);
            Remove_Real_Contrac_Att_Cmd.Parameters.AddWithValue("@Real_Contract_FileName", "");
            Remove_Real_Contrac_Att_Cmd.Parameters.AddWithValue("@Real_Contract_Path", "");
            Remove_Real_Contrac_Att_Cmd.ExecuteNonQuery();
            _sqlCon.Close();

            Response.Redirect("Edit_Contract.aspx?Id=" + Contrac_Id);
        }
    }
}