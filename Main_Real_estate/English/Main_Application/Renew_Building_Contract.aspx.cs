using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Renew_Building_Contract : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();    

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Contracting", 0, "R");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            //try
            //{
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

                //    //Fill contract_type DropDownList
                Helper.LoadDropDownList("SELECT * FROM contract_type", _sqlCon, Contract_Type_DropDownList, "Contract_Arabic_Type", "Contract_Type_Id");
                Contract_Type_DropDownList.Items.Insert(0, "إخترنوع العقد ....");

                //    //Fill Contract templet DropDownList
                Helper.LoadDropDownList("SELECT * FROM contract_template", _sqlCon, Contract_Templet_DropDownList, "Contract_Arabic_template", "Contract_template_Id");
                Contract_Templet_DropDownList.Items.Insert(0, "إختر نموذج العقد ....");


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

                //    //Fill Tenant Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM transformation_bank", _sqlCon, transformation_Bank_DropDownList, "Bank_Name", "transformation_Bank_ID");
                transformation_Bank_DropDownList.Items.Insert(0, "إختر اسم البنك ....");

                _sqlCon.Close();

                //************************ get The Contract Information **************************************************

                string Contract_Id = Request.QueryString["Id"];
                DataTable get_Contract_Dt = new DataTable();
                _sqlCon.Open();
                MySqlCommand get_Contract_Cmd = new MySqlCommand("SELECT * FROM building_contract WHERE Contract_Id = @ID", _sqlCon);
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
                    Helper.LoadDropDownList("SELECT * FROM company_representative where tenants_Tenants_ID ='" + Tenan_Name_DropDownList.SelectedValue + "'", _sqlCon, Com_Rep_DropDownList, "Com_rep_En_Name", "Company_representative_Id");
                    Com_Rep_DropDownList.Items.Insert(0, "إختر اسم الممثل ....");
                    Com_Rep_DropDownList.SelectedValue = get_Contract_Dt.Rows[0]["Com_rep"].ToString();

                    if (get_Contract_Dt.Rows[0]["Paymen_Method"].ToString() == "شيك") { Paymen_Method_RadioButtonList.SelectedValue = "1"; }
                    else if (get_Contract_Dt.Rows[0]["Paymen_Method"].ToString() == "تحويل") { Paymen_Method_RadioButtonList.SelectedValue = "2"; }
                    else if (get_Contract_Dt.Rows[0]["Paymen_Method"].ToString() == "نقداً") { Paymen_Method_RadioButtonList.SelectedValue = "3"; }


                    if (get_Contract_Dt.Rows[0]["Paymen_Method"].ToString() == "شيك")
                    {
                        Paymen_Method_RadioButtonList.SelectedValue = "1"; Cheque_Div.Visible = true; Cash_div.Visible = false; transformation_Div.Visible = false;
                    }
                    else if (get_Contract_Dt.Rows[0]["Paymen_Method"].ToString() == "تحويل")
                    {
                        Paymen_Method_RadioButtonList.SelectedValue = "2"; Cheque_Div.Visible = false; Cash_div.Visible = false; transformation_Div.Visible = true;
                    }
                    else if (get_Contract_Dt.Rows[0]["Paymen_Method"].ToString() == "نقداً")
                    {
                        Paymen_Method_RadioButtonList.SelectedValue = "3"; Cheque_Div.Visible = false; Cash_div.Visible = true; transformation_Div.Visible = false;
                    }

                    Building_Name_DropDownList.SelectedValue = get_Contract_Dt.Rows[0]["building_Building_Id"].ToString();
                    Contract_Type_DropDownList.SelectedValue = get_Contract_Dt.Rows[0]["contract_type_Contract_Type_Id"].ToString();

                    Contract_Templet_DropDownList.SelectedValue = get_Contract_Dt.Rows[0]["contract_template_Contract_template_Id"].ToString();
                 //   Payment_Frquancy_DropDownList.SelectedValue = get_Contract_Dt.Rows[0]["payment_frequency_Payment_Frequency_Id"].ToString();
                    Payment_Type_DropDownList.SelectedValue = get_Contract_Dt.Rows[0]["payment_type_payment_type_Id"].ToString();
                    lbl_Tenant_Name.Text = Tenan_Name_DropDownList.SelectedItem.Text;

                    // ---------------------- get The user Name ----------------------------------------------------------------------------------
                    string User_Id = get_Contract_Dt.Rows[0]["users_user_ID"].ToString();
                    DataTable get_User_Dt = new DataTable();
                    // _sqlCon.Open();
                    MySqlCommand get_User_Cmd = new MySqlCommand("SELECT * FROM users WHERE user_ID = @ID", _sqlCon);
                    MySqlDataAdapter get_User_Da = new MySqlDataAdapter(get_User_Cmd);
                    get_User_Cmd.Parameters.AddWithValue("@ID", User_Id);
                    get_User_Da.Fill(get_User_Dt);
                    if (get_User_Dt.Rows.Count > 0)
                    {
                        txt_Dtl_Employee_Name.Text = get_User_Dt.Rows[0]["Users_Ar_First_Name"].ToString() + " " + get_User_Dt.Rows[0]["Users_Ar_Last_Name"].ToString();
                    }
                    //----------------------------------------------------------------------------------------------------------------------------------------------
                }
                _sqlCon.Close();

                using (MySqlCommand get_Contract_ownership_drowpdownlist_Cmd = new MySqlCommand("Edit_B_Contract_Ownership_Unit_dropdownlist", _sqlCon))
                {
                    _sqlCon.Open();
                    get_Contract_ownership_drowpdownlist_Cmd.CommandType = CommandType.StoredProcedure;
                    get_Contract_ownership_drowpdownlist_Cmd.Parameters.AddWithValue("@Id", Building_Name_DropDownList.SelectedValue);
                    using (MySqlDataAdapter get_Contract_ownership_drowpdownlist_Da = new MySqlDataAdapter(get_Contract_ownership_drowpdownlist_Cmd))
                    {
                        DataTable get_Contract_ownership_drowpdownlist_Dt = new DataTable();
                        get_Contract_ownership_drowpdownlist_Da.Fill(get_Contract_ownership_drowpdownlist_Dt);

                        Ownership_Name_DropDownList.SelectedValue = get_Contract_ownership_drowpdownlist_Dt.Rows[0]["Owner_Ship_Id"].ToString();
                    }
                    _sqlCon.Close();
                }
                //--------------------------------------- Fill Cheque GridView with Added Cheques --------------------------------------------------------------
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[11]
                {
                    new DataColumn("Cheques_No"), new DataColumn("Cheques_Date"), new DataColumn("Cheques_Amount"),
                    new DataColumn("Cheque_Type"), new DataColumn("cheque_type_Cheque_Type_id"),
                    new DataColumn("Cheque_Bank_Name"),
                    new DataColumn("bank_Bank_Id"), new DataColumn("Tenant_Name"), new DataColumn("tenants_Tenants_ID"), new DataColumn("Cheque_Owner"),
                    new DataColumn("beneficiary_person")
                });
                ViewState["Customers"] = dt;
                this.BindGrid();
                //**************************************************************************************************************************************************

                //--------------------------------------- Fill transformation GridView with Added transformation --------------------------------------------------------------
                DataTable Tr_Dt = new DataTable();
                Tr_Dt.Columns.AddRange(new DataColumn[7]
                {
                    new DataColumn("transformation_No"),
                    new DataColumn("Bank_Name"),new DataColumn("transformation_Bank_ID"),
                    new DataColumn("transformation_Date"),
                    new DataColumn("Amount"),
                    new DataColumn("tenant_Name"), new DataColumn("tenant_Id")
                });
                ViewState["transformation_Customers"] = Tr_Dt;
                this.BindGrid();
                //**************************************************************************************************************************************************

                //--------------------------------------- Fill Cash GridView with Added Cash --------------------------------------------------------------

                DataTable Ch_Dt = new DataTable();
                Ch_Dt.Columns.AddRange(new DataColumn[4]
                {
                    new DataColumn("Cash_Amount"),
                    new DataColumn("Cash_Date"),
                    new DataColumn("tenant_Name"), new DataColumn("tenant_Id")
                });
                ViewState["Cash_Customers"] = Ch_Dt;
                this.BindGrid();
                //-----------------------------------------------------------------------------------------------------
                if (Cheque_GridView.Rows.Count == 0)
                {
                    lbl_Cheque.Text = " لا توجد شيكات مُدخلة";
                }

                if (Contract_Templet_DropDownList.SelectedValue == "3")
                {
                    refreshdata();
                    Building_Name_DropDownList.Enabled = false;
                    Half_Contract_Worrning.Text = "لا يمكن تعديل البناء بحالة العقود نص المجملة ";

                }
            }
            //}
            //catch
            //{
            //    Response.Redirect("Contract_List.aspx");
            //    Response.Write(@"<script language='javascript'>alert('لايوجد عقد لتعديله')</script>");
            //}
        }

        protected void BindGrid()
        {
            Cheque_GridView.DataSource = (DataTable)ViewState["Customers"];
            Cheque_GridView.DataBind();
        }


        protected void transformation_BindGrid()
        {
            transformation_GridView.DataSource = (DataTable)ViewState["transformation_Customers"];
            transformation_GridView.DataBind();
        }


        protected void Cash_BindGrid()
        {
            Cash_GridView.DataSource = (DataTable)ViewState["Cash_Customers"];
            Cash_GridView.DataBind();
        }

        //*****************************************************************************************************************
        //************************************   Buttons Events    **************************************************
        //*****************************************************************************************************************
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = ViewState["Customers"] as DataTable;
            dt.Rows[index].Delete();
            ViewState["Customers"] = dt;
            BindGrid();

            if (Cheque_GridView.Rows.Count == 0)
            {
                lbl_Cheque.Text = " لا توجد شيكات مُدخلة";
            }
            else
            {
                lbl_Cheque.Text = "عدد الشيكات المُدخلة :" + Cheque_GridView.Rows.Count.ToString();
            }
        }

        protected void transformation_GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable Tr_Dt = ViewState["transformation_Customers"] as DataTable;
            Tr_Dt.Rows[index].Delete();
            ViewState["transformation_Customers"] = Tr_Dt;
            transformation_BindGrid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable Tr_Dt = ViewState["Cash_Customers"] as DataTable;
            Tr_Dt.Rows[index].Delete();
            ViewState["Cash_Customers"] = Tr_Dt;
            Cash_BindGrid();
        }

        //************************************** Add Cheques in the View  ***************************************************************************************
        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            if (serial_CheckBox.Checked == true)
            {
                if (txt_Cheque_NO.Text != "" & txt_Cheque_Date.Text != ""
                && txt_Cheque_Value.Text != "" & Cheque_Type_DropDownList.SelectedItem.Text != "إخترنوع الشيك ...."
                && Bank_Cheque_Name_DropDownList.SelectedItem.Text != "إختراسم البنك ...." &&
                Tenan_Name_DropDownList.SelectedItem.Text != "إختر اسم المستأجر ...." && Cheque_Owner.Text != "")
                {
                    for (int i = 0; i < Convert.ToInt32(txt_No_serial_Chques.Text); i++)
                    {
                        int Cheque_NO = Convert.ToInt32(txt_Cheque_NO.Text.Trim()) + i;
                        DateTime Cheque_Date = Convert.ToDateTime(txt_Cheque_Date.Text.Trim()).AddMonths(i);
                        string String_Cheque_Date = Cheque_Date.ToString("dd/MM/yyyy");
                        DataTable dt1 = (DataTable)ViewState["Customers"];
                        dt1.Rows.Add
                        (

                            Convert.ToString(Cheque_NO),
                            String_Cheque_Date,
                            txt_Cheque_Value.Text.Trim(),
                            Cheque_Type_DropDownList.SelectedItem.Text.Trim(),
                            Cheque_Type_DropDownList.SelectedValue,
                            Bank_Cheque_Name_DropDownList.SelectedItem.Text.Trim(),
                            Bank_Cheque_Name_DropDownList.SelectedValue,
                            Tenan_Name_DropDownList.SelectedItem.Text.Trim(),
                            Tenan_Name_DropDownList.SelectedValue,
                            Cheque_Owner.Text.Trim(),
                            txt_beneficiary_person.Text.Trim()
                        ); ;
                        ViewState["Customers"] = dt1;
                        this.BindGrid();
                        lbl_Cheque.Text = "عدد الشيكات المُدخلة :" + Cheque_GridView.Rows.Count.ToString();
                        lbl_Worrnig_Cheque.Visible = false;
                    }
                }
                else
                {
                    lbl_Worrnig_Cheque.Visible = true;
                }
            }
            else
            {
                if (txt_Cheque_NO.Text != "" & txt_Cheque_Date.Text != ""
               && txt_Cheque_Value.Text != "" & Cheque_Type_DropDownList.SelectedItem.Text != "إخترنوع الشيك ...."
               && Bank_Cheque_Name_DropDownList.SelectedItem.Text != "إختراسم البنك ...." &&
               Tenan_Name_DropDownList.SelectedItem.Text != "إختر اسم المستأجر ...." && Cheque_Owner.Text != "")
                {
                    DataTable dt1 = (DataTable)ViewState["Customers"];
                    dt1.Rows.Add
                    (
                        txt_Cheque_NO.Text.Trim(),
                        txt_Cheque_Date.Text.Trim(),
                        txt_Cheque_Value.Text.Trim(),
                        Cheque_Type_DropDownList.SelectedItem.Text.Trim(),
                        Cheque_Type_DropDownList.SelectedValue,
                        Bank_Cheque_Name_DropDownList.SelectedItem.Text.Trim(),
                        Bank_Cheque_Name_DropDownList.SelectedValue,
                        Tenan_Name_DropDownList.SelectedItem.Text.Trim(),
                        Tenan_Name_DropDownList.SelectedValue,
                        Cheque_Owner.Text.Trim(),
                        txt_beneficiary_person.Text.Trim()
                    );
                    ViewState["Customers"] = dt1;
                    this.BindGrid();
                    lbl_Cheque.Text = "عدد الشيكات المُدخلة :" + Cheque_GridView.Rows.Count.ToString();
                    lbl_Worrnig_Cheque.Visible = false;
                }
                else
                {
                    lbl_Worrnig_Cheque.Visible = true;
                }
            }


            ClientScript.RegisterClientScriptBlock(this.GetType(), "",
                "window.onload=function(){window.scrollTo(0,document.body.scrollHeight)};", true);
        }
        //***********************************************************************************************************************************
        protected void btn_Add_Transformation_Click(object sender, ImageClickEventArgs e)
        {

            DataTable dt1 = (DataTable)ViewState["transformation_Customers"];
            dt1.Rows.Add
            (
                txt_transformation_No.Text.Trim(),

                transformation_Bank_DropDownList.SelectedItem.Text.Trim(),
                transformation_Bank_DropDownList.SelectedValue,

                txt_transformation_Date.Text.Trim(),

                txt_transformation_Amount.Text.Trim(),

                Tenan_Name_DropDownList.SelectedItem.Text.Trim(),
                Tenan_Name_DropDownList.SelectedValue


            );
            ViewState["transformation_Customers"] = dt1;
            this.transformation_BindGrid();


            ClientScript.RegisterClientScriptBlock(this.GetType(), "", "window.onload=function(){window.scrollTo(0,document.body.scrollHeight)};", true);

        }
        //************************************************************************************************************************************************************************

        protected void Add_Cash_Click(object sender, ImageClickEventArgs e)
        {
            DataTable dt1 = (DataTable)ViewState["Cash_Customers"];
            dt1.Rows.Add
            (
                txt_Cash_Amount.Text.Trim(),
                txt_Cash_Date.Text.Trim(),
                Tenan_Name_DropDownList.SelectedItem.Text.Trim(),
                Tenan_Name_DropDownList.SelectedValue


            );
            ViewState["Cash_Customers"] = dt1;
            this.Cash_BindGrid();


            ClientScript.RegisterClientScriptBlock(this.GetType(), "", "window.onload=function(){window.scrollTo(0,document.body.scrollHeight)};", true);
        }

        //*********************************  conclusion of the contract ***********************************************************************************************************
        protected void btn_Add_Contract_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                //  Update New_ReNewed_Expaired to 2 in Contract Table
                string contractId = Request.QueryString["Id"];
                string New_ReNewed_ExpairedQuery = "UPDATE building_contract SET New_ReNewed_Expaired=@New_ReNewed_Expaired  WHERE Contract_Id=@ID ";
                _sqlCon.Open();
                using (MySqlCommand UpdateContractCmd = new MySqlCommand(New_ReNewed_ExpairedQuery, _sqlCon))
                {
                    UpdateContractCmd.Parameters.AddWithValue("@ID", contractId);
                    //Fill The Database with All DropDownLists Items
                    UpdateContractCmd.Parameters.AddWithValue("@New_ReNewed_Expaired", "2");
                    UpdateContractCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }


                //  insert The Contract Information in Contract Tabel in DB
                string RenewContractQuery = "Insert Into building_contract (" +
                                          "Contract_Details , " +
                                          "Payment_Amount  , " +
                                          "Payment_Amount_L  , " +
                                          "Date_Of_Sgin        , " +
                                          "Start_Date       , " +
                                          "End_Date         , " +
                                          "users_user_ID , " +
                                          "building_Building_Id , " +
                                          "New_ReNewed_Expaired , " +
                                          "Start_Free_Period , " +
                                          "Duration_free_period , " +
                                          "maintenance , " +
                                          "Rental_allowed_Or_Not_allowed , " +
                                          "reason_for_rent_Reason_For_Rent_Id   , " +
                                          "contract_type_Contract_Type_Id   , " +
                                          "contract_template_Contract_template_Id , " +
                                          "Number_Of_Mounth , " +
                                          "Number_Of_Years , " +
                                          "tenants_Tenants_ID , " +
                                          "Com_rep ," +
                                          "Paymen_Method ," +
                                          "payment_type_payment_type_Id) " +
                                          "VALUES( " +
                                          "@Contract_Details , " +
                                          "@Payment_Amount  , " +
                                          "@Payment_Amount_L  , " +
                                          "@Date_Of_Sgin        , " +
                                          "@Start_Date       , " +
                                          "@End_Date         , " +
                                          "@users_user_ID , " +
                                          "@building_Building_Id , " +
                                          "@New_ReNewed_Expaired , " +
                                          "@Start_Free_Period , " +
                                          "@Duration_free_period , " +
                                          "@maintenance , " +
                                          "@Rental_allowed_Or_Not_allowed , " +
                                          "@reason_for_rent_Reason_For_Rent_Id   , " +
                                          "@contract_type_Contract_Type_Id   , " +
                                          "@contract_template_Contract_template_Id , " +
                                          "@Number_Of_Mounth , " +
                                          "@Number_Of_Years , " +
                                          "@tenants_Tenants_ID , " +
                                          "@Com_rep ," +
                                          "@Paymen_Method ," +
                                          "@payment_type_payment_type_Id ) ";
                _sqlCon.Open();
                using (MySqlCommand RenewContractCmd = new MySqlCommand(RenewContractQuery, _sqlCon))
                {
                    //Fill The Database with All DropDownLists Items
                    RenewContractCmd.Parameters.AddWithValue("@contract_type_Contract_Type_Id",
                        Contract_Type_DropDownList.SelectedValue);
                    RenewContractCmd.Parameters.AddWithValue("@contract_template_Contract_template_Id",
                        Contract_Templet_DropDownList.SelectedValue);
                    //RenewContractCmd.Parameters.AddWithValue("@payment_frequency_Payment_Frequency_Id",
                    //    Payment_Frquancy_DropDownList.SelectedValue);
                    RenewContractCmd.Parameters.AddWithValue("@tenants_Tenants_ID", Tenan_Name_DropDownList.SelectedValue);
                    RenewContractCmd.Parameters.AddWithValue("@payment_type_payment_type_Id", Payment_Type_DropDownList.SelectedValue);
                    RenewContractCmd.Parameters.AddWithValue("@building_Building_Id", Building_Name_DropDownList.SelectedValue);
                    RenewContractCmd.Parameters.AddWithValue("@users_user_ID", Session["user_ID"]);
                    RenewContractCmd.Parameters.AddWithValue("@New_ReNewed_Expaired", "1");
                    RenewContractCmd.Parameters.AddWithValue("@reason_for_rent_Reason_For_Rent_Id", Reason_For_Rent_DropDownList.SelectedValue);
                    RenewContractCmd.Parameters.AddWithValue("@Start_Free_Period", txt_FREE_PERIOD.Text);
                    RenewContractCmd.Parameters.AddWithValue("@Duration_free_period", txt_Duration_Of_The_Free_Period.Text);
                    RenewContractCmd.Parameters.AddWithValue("@Com_rep", Com_Rep_DropDownList.SelectedValue);
                    RenewContractCmd.Parameters.AddWithValue("@maintenance", maintenance_RadioButtonList.SelectedValue);
                    RenewContractCmd.Parameters.AddWithValue("@Rental_allowed_Or_Not_allowed", Rental_allowed_Or_Not_allowed_RadioButtonList.SelectedValue);
                    RenewContractCmd.Parameters.AddWithValue("@Paymen_Method", Paymen_Method_RadioButtonList.SelectedItem.Text.Trim());
                    //Fill The Database with All Textbox Items
                    RenewContractCmd.Parameters.AddWithValue("@Contract_Details", txt_Contract_Details.Text);
                    RenewContractCmd.Parameters.AddWithValue("@Payment_Amount", txt_Payment_Amount.Text);
                    RenewContractCmd.Parameters.AddWithValue("@Payment_Amount_L", txt_Payment_Amount_L.Text);
                    RenewContractCmd.Parameters.AddWithValue("@Date_Of_Sgin", txt_Sign_Date.Text);
                    RenewContractCmd.Parameters.AddWithValue("@Start_Date", txt_Start_Date.Text);
                    RenewContractCmd.Parameters.AddWithValue("@End_Date", txt_End_Date.Text);
                    if (Contract_Type_DropDownList.SelectedValue == "1")
                    {
                        RenewContractCmd.Parameters.AddWithValue("@Number_Of_Years", txt_No_Of_Months_Or_Years.Text);
                        RenewContractCmd.Parameters.AddWithValue("@Number_Of_Mounth", "");
                    }
                    else
                    {
                        RenewContractCmd.Parameters.AddWithValue("@Number_Of_Years", "");
                        RenewContractCmd.Parameters.AddWithValue("@Number_Of_Mounth", txt_No_Of_Months_Or_Years.Text);
                    }

                    RenewContractCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }

                Renew_Arcive_Building_Contract();

                //    Get The Added Contract Id
                using (MySqlCommand Get_Contract_ID = new MySqlCommand("SELECT MAX(Contract_Id) AS LastInsertedID from building_contract", _sqlCon))
                {
                    _sqlCon.Open();
                    Get_Contract_ID.CommandType = CommandType.Text;
                    object Contract_ID = Get_Contract_ID.ExecuteScalar();
                    if (Contract_ID != null)
                    {
                        Contract_id.Text = Contract_ID.ToString();
                    }

                    _sqlCon.Close();
                }






                if (Paymen_Method_RadioButtonList.SelectedValue == "1")
                {
                    //    insert The Cheques Information in Cheques Tabel in DB
                    string Defult_Chque_Status = "غير محصل";
                    MySqlCommand com;
                    foreach (GridViewRow g1 in Cheque_GridView.Rows)
                    {
                        _sqlCon.Open();
                        com = new
                        MySqlCommand("INSERT INTO building_cheques (" +
                                     "Cheques_No," +
                                     "Cheques_Date  , " +
                                     "Cheques_Amount," +
                                     "Cheque_Owner," +
                                     "beneficiary_person," +
                                     "Cheques_Status," +
                                     "cheque_type_Cheque_Type_id," +
                                     "bank_Bank_Id  , " +
                                     "tenants_Tenants_ID  , " +
                                     "building_contract_Contract_Id)  " +
                                     "VALUES(" +
                                     "'" + g1.Cells[1].Text + "' ," +
                                     "'" + g1.Cells[2].Text + "' ," +
                                     "'" + g1.Cells[3].Text + "' ," +
                                     "'" + g1.Cells[11].Text + "' ," +
                                     "'" + g1.Cells[12].Text + "' ," +
                                     "'" + Defult_Chque_Status + "' ," +
                                     " '" + Convert.ToInt32(g1.Cells[6].Text) + "', " +
                                     "'" + Convert.ToInt32(g1.Cells[8].Text) + "' , " +
                                     "'" + Convert.ToInt32(g1.Cells[10].Text) + "' ," +
                                     "'" + Convert.ToInt32(Contract_id.Text) + "')", _sqlCon);

                        com.ExecuteNonQuery();
                        _sqlCon.Close();
                    }
                }
                else if (Paymen_Method_RadioButtonList.SelectedValue == "2")
                {
                    string Defult_transformation_Status = "غير محصل";
                    MySqlCommand com;
                    foreach (GridViewRow g1 in transformation_GridView.Rows)
                    {
                        _sqlCon.Open();
                        com = new
                            MySqlCommand("INSERT INTO building_transformation_table (" +
                                         "transformation_No," +
                                         "transformation_Bank_ID," +
                                         "transformation_Date," +
                                         "Amount," +
                                         "Status," +
                                         "tenant_Id  , " +
                                         "Contract_Id)  " +
                                         "VALUES(" +
                                         "'" + g1.Cells[0].Text + "' ," +
                                         "'" + g1.Cells[2].Text + "' ," +
                                         "'" + g1.Cells[3].Text + "' ," +
                                         "'" + g1.Cells[4].Text + "' ," +
                                         "'" + Defult_transformation_Status + "' ," +
                                         "'" + g1.Cells[6].Text + "' ," +
                                         "'" + Contract_id.Text + "')", _sqlCon);
                        com.ExecuteNonQuery();
                        _sqlCon.Close();
                    }
                }
                else
                {
                    string Defult_Cash_Status = "غير محصل";
                    MySqlCommand com;
                    foreach (GridViewRow g1 in Cash_GridView.Rows)
                    {
                        _sqlCon.Open();
                        com = new
                            MySqlCommand("INSERT INTO building_cash_amount (" +
                                         "Cash_Amount," +
                                         "Cash_Date," +
                                         "Satuts," +
                                         "tenant_Id," +
                                         "Contract_Id)  " +
                                         "VALUES(" +
                                         "'" + g1.Cells[0].Text + "' ," +
                                         "'" + g1.Cells[1].Text + "' ," +
                                          "'" + Defult_Cash_Status + "' ," +
                                         "'" + g1.Cells[3].Text + "' ," +
                                         "'" + Contract_id.Text + "')", _sqlCon);
                        com.ExecuteNonQuery();
                        _sqlCon.Close();
                    }
                }

                    

                lbl_Success_Add_New_Contract.Text = "تمت التجديد بنجاح";
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

        protected void Cheque_GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string ChequeType;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    ChequeType = ((Label)e.Row.FindControl("lbl_cheque_type")).Text;
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
        }

        //******************  Tenant_Id_End_Date ***************************************************

        protected void txt_Duration_Of_The_Free_Period_TextChanged(object sender, EventArgs e)
        {
            txt_Start_Date.Text = Start_Date_Calendar.SelectedDate.ToShortDateString();
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

        public void refreshdata()
        {
            string getUnitQuari = "SELECT * FROM units where building_Building_Id = '" + Building_Name_DropDownList.SelectedValue + "'";
            MySqlCommand getUnitCmd = new MySqlCommand(getUnitQuari, _sqlCon);
            MySqlDataAdapter getUnitDt = new MySqlDataAdapter(getUnitCmd);
            getUnitCmd.Connection = _sqlCon;
            _sqlCon.Open();
            getUnitDt.SelectCommand = getUnitCmd;
            DataTable getUnitDataTable = new DataTable();
            getUnitDt.Fill(getUnitDataTable);
            Unit_GridView.DataSource = getUnitDataTable;
            Unit_GridView.DataBind();
            _sqlCon.Close();
        }

        protected void Unit_GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string Half; CheckBox CB;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    Half = ((Label)e.Row.FindControl("Half")).Text;
                    CB = ((CheckBox)e.Row.FindControl("CheckBox1"));
                    if (Half == "1")
                    {
                        e.Row.ForeColor = System.Drawing.Color.Blue;
                        e.Row.BackColor = System.Drawing.Color.AliceBlue;
                        CB.Checked = true;
                    }
                }
                catch
                {
                    Half = "";
                }
            }
        }

        protected void Renew_Arcive_Building_Contract()
        {
            //  Update New_ReNewed_Expaired to 2 in Contract Table
            string contractId = Request.QueryString["Id"];
            string New_ReNewed_ExpairedQuery = "UPDATE arcive_building_contract SET New_ReNewed_Expaired=@New_ReNewed_Expaired  WHERE Contract_Id=@ID ";
            _sqlCon.Open();
            using (MySqlCommand UpdateContractCmd = new MySqlCommand(New_ReNewed_ExpairedQuery, _sqlCon))
            {
                UpdateContractCmd.Parameters.AddWithValue("@ID", contractId);
                //Fill The Database with All DropDownLists Items
                UpdateContractCmd.Parameters.AddWithValue("@New_ReNewed_Expaired", "2");
                UpdateContractCmd.ExecuteNonQuery();
                _sqlCon.Close();
            }


            //  insert The Contract Information in Contract Tabel in DB
            string RenewContractQuery = "Insert Into arcive_building_contract (" +
                                      "Contract_Details , " +
                                      "Payment_Amount  , " +
                                      "Payment_Amount_L  , " +
                                      "Date_Of_Sgin        , " +
                                      "Start_Date       , " +
                                      "End_Date         , " +
                                      "users_user_ID , " +
                                      "building_Building_Id , " +
                                      "New_ReNewed_Expaired , " +
                                      "Start_Free_Period , " +
                                      "Duration_free_period , " +
                                      "maintenance , " +
                                      "Rental_allowed_Or_Not_allowed , " +
                                      "reason_for_rent_Reason_For_Rent_Id   , " +
                                      "contract_type_Contract_Type_Id   , " +
                                      "contract_template_Contract_template_Id , " +
                                      "Number_Of_Mounth , " +
                                      "Number_Of_Years , " +
                                      "tenants_Tenants_ID , " +
                                      "Com_rep ," +
                                      "Paymen_Method ," +
                                      "payment_type_payment_type_Id) " +
                                      "VALUES( " +
                                      "@Contract_Details , " +
                                      "@Payment_Amount  , " +
                                      "@Payment_Amount_L  , " +
                                      "@Date_Of_Sgin        , " +
                                      "@Start_Date       , " +
                                      "@End_Date         , " +
                                      "@users_user_ID , " +
                                      "@building_Building_Id , " +
                                      "@New_ReNewed_Expaired , " +
                                      "@Start_Free_Period , " +
                                      "@Duration_free_period , " +
                                      "@maintenance , " +
                                      "@Rental_allowed_Or_Not_allowed , " +
                                      "@reason_for_rent_Reason_For_Rent_Id   , " +
                                      "@contract_type_Contract_Type_Id   , " +
                                      "@contract_template_Contract_template_Id , " +
                                      "@Number_Of_Mounth , " +
                                      "@Number_Of_Years , " +
                                      "@tenants_Tenants_ID , " +
                                      "@Com_rep ," +
                                      "@Paymen_Method ," +
                                      "@payment_type_payment_type_Id ) ";
            _sqlCon.Open();
            using (MySqlCommand RenewContractCmd = new MySqlCommand(RenewContractQuery, _sqlCon))
            {
                //Fill The Database with All DropDownLists Items
                RenewContractCmd.Parameters.AddWithValue("@contract_type_Contract_Type_Id",
                    Contract_Type_DropDownList.SelectedValue);
                RenewContractCmd.Parameters.AddWithValue("@contract_template_Contract_template_Id",
                    Contract_Templet_DropDownList.SelectedValue);
                //RenewContractCmd.Parameters.AddWithValue("@payment_frequency_Payment_Frequency_Id",
                //    Payment_Frquancy_DropDownList.SelectedValue);
                RenewContractCmd.Parameters.AddWithValue("@tenants_Tenants_ID", Tenan_Name_DropDownList.SelectedValue);
                RenewContractCmd.Parameters.AddWithValue("@payment_type_payment_type_Id", Payment_Type_DropDownList.SelectedValue);
                RenewContractCmd.Parameters.AddWithValue("@building_Building_Id", Building_Name_DropDownList.SelectedValue);
                RenewContractCmd.Parameters.AddWithValue("@users_user_ID", Session["user_ID"]);
                RenewContractCmd.Parameters.AddWithValue("@New_ReNewed_Expaired", "1");
                RenewContractCmd.Parameters.AddWithValue("@reason_for_rent_Reason_For_Rent_Id", Reason_For_Rent_DropDownList.SelectedValue);
                RenewContractCmd.Parameters.AddWithValue("@Start_Free_Period", txt_FREE_PERIOD.Text);
                RenewContractCmd.Parameters.AddWithValue("@Duration_free_period", txt_Duration_Of_The_Free_Period.Text);
                RenewContractCmd.Parameters.AddWithValue("@Com_rep", Com_Rep_DropDownList.SelectedValue);
                RenewContractCmd.Parameters.AddWithValue("@maintenance", maintenance_RadioButtonList.SelectedValue);
                RenewContractCmd.Parameters.AddWithValue("@Rental_allowed_Or_Not_allowed", Rental_allowed_Or_Not_allowed_RadioButtonList.SelectedValue);
                RenewContractCmd.Parameters.AddWithValue("@Paymen_Method", Paymen_Method_RadioButtonList.SelectedItem.Text.Trim());
                //Fill The Database with All Textbox Items
                RenewContractCmd.Parameters.AddWithValue("@Contract_Details", txt_Contract_Details.Text);
                RenewContractCmd.Parameters.AddWithValue("@Payment_Amount", txt_Payment_Amount.Text);
                RenewContractCmd.Parameters.AddWithValue("@Payment_Amount_L", txt_Payment_Amount_L.Text);
                RenewContractCmd.Parameters.AddWithValue("@Date_Of_Sgin", txt_Sign_Date.Text);
                RenewContractCmd.Parameters.AddWithValue("@Start_Date", txt_Start_Date.Text);
                RenewContractCmd.Parameters.AddWithValue("@End_Date", txt_End_Date.Text);
                if (Contract_Type_DropDownList.SelectedValue == "1")
                {
                    RenewContractCmd.Parameters.AddWithValue("@Number_Of_Years", txt_No_Of_Months_Or_Years.Text);
                    RenewContractCmd.Parameters.AddWithValue("@Number_Of_Mounth", "");
                }
                else
                {
                    RenewContractCmd.Parameters.AddWithValue("@Number_Of_Years", "");
                    RenewContractCmd.Parameters.AddWithValue("@Number_Of_Mounth", txt_No_Of_Months_Or_Years.Text);
                }

                RenewContractCmd.ExecuteNonQuery();
                _sqlCon.Close();
            }
        }



        protected void Paymen_Method_RadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Paymen_Method_RadioButtonList.SelectedValue == "1") { Cheque_Div.Visible = true; lbl_Cheque.Visible = true; transformation_Div.Visible = false; Cash_div.Visible = false; }
            else if (Paymen_Method_RadioButtonList.SelectedValue == "2") { Cheque_Div.Visible = false; transformation_Div.Visible = true; Cash_div.Visible = false; lbl_Cheque.Text = "التحويلات"; }
            else if (Paymen_Method_RadioButtonList.SelectedValue == "3") { Cheque_Div.Visible = false; transformation_Div.Visible = false; Cash_div.Visible = true; lbl_Cheque.Text = "الدفعات النقدية"; }
            ClientScript.RegisterClientScriptBlock(this.GetType(), "", "window.onload=function(){window.scrollTo(0,document.body.scrollHeight)};", true);
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



    }
}