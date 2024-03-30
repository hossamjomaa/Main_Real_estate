using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Add_Contract : System.Web.UI.Page
    {
        // Database Connection String
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //    //Fill Tenant Name DropDownList
                using (MySqlCommand getTenantNameDropDownListCmd = new MySqlCommand("SELECT * FROM tenants"))
                {
                    getTenantNameDropDownListCmd.CommandType = CommandType.Text;
                    getTenantNameDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    Tenan_Name_DropDownList.DataSource = getTenantNameDropDownListCmd.ExecuteReader();
                    Tenan_Name_DropDownList.DataTextField = "Tenants_Arabic_Name";
                    Tenan_Name_DropDownList.DataValueField = "Tenants_ID";
                    Tenan_Name_DropDownList.DataBind();
                    Tenan_Name_DropDownList.Items.Insert(0, "إختر اسم المستأجر ....");
                    _sqlCon.Close();
                }
                //   Fill Employee Name DropDownList

                DataTable get_Employee_DataTable = new DataTable();
                _sqlCon.Open();
                MySqlCommand get_Employee_Cmd = new MySqlCommand("SELECT * FROM users WHERE Users_Name = @Users_Name", _sqlCon);
                MySqlDataAdapter get_Employee_Da = new MySqlDataAdapter(get_Employee_Cmd);
                get_Employee_Cmd.Parameters.AddWithValue("@Users_Name", Session["Users_Name"].ToString());
                get_Employee_Da.Fill(get_Employee_DataTable);
                if (get_Employee_DataTable.Rows.Count > 0)
                {
                    txt_Employee_Name.Text = get_Employee_DataTable.Rows[0]["Users_Ar_First_Name"].ToString() + " " + get_Employee_DataTable.Rows[0]["Users_Ar_Last_Name"].ToString();
                }
                _sqlCon.Close();

                //    //Fill Contract templet DropDownList
                using (MySqlCommand getContractTempletDropDownListCmd =
                       new MySqlCommand("SELECT * FROM contract_template"))
                {
                    getContractTempletDropDownListCmd.CommandType = CommandType.Text;
                    getContractTempletDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    Contract_Templet_DropDownList.DataSource = getContractTempletDropDownListCmd.ExecuteReader();
                    Contract_Templet_DropDownList.DataTextField = "Contract_Arabic_template";
                    Contract_Templet_DropDownList.DataValueField = "Contract_template_Id";
                    Contract_Templet_DropDownList.DataBind();
                    Contract_Templet_DropDownList.Items.Insert(0, "إختر نموذج العقد ....");
                    _sqlCon.Close();
                }

                //    //Fill Paymaent FrequencY DropDownList
                using (MySqlCommand getPaymaentFrequencYDropDownListCmd =
                       new MySqlCommand("SELECT * FROM payment_frequency"))
                {
                    getPaymaentFrequencYDropDownListCmd.CommandType = CommandType.Text;
                    getPaymaentFrequencYDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    Payment_Frquancy_DropDownList.DataSource = getPaymaentFrequencYDropDownListCmd.ExecuteReader();
                    Payment_Frquancy_DropDownList.DataTextField = "Payment_Arabic_Frequency";
                    Payment_Frquancy_DropDownList.DataValueField = "Payment_Frequency_Id";
                    Payment_Frquancy_DropDownList.DataBind();
                    Payment_Frquancy_DropDownList.Items.Insert(0, "إختر تكرار الدفعات ....");
                    _sqlCon.Close();
                }

                //    //Fill Payment Type DropDownList
                using (MySqlCommand getPaymaentTypeDropDownListCmd = new MySqlCommand("SELECT * FROM payment_type"))
                {
                    getPaymaentTypeDropDownListCmd.CommandType = CommandType.Text;
                    getPaymaentTypeDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    Payment_Type_DropDownList.DataSource = getPaymaentTypeDropDownListCmd.ExecuteReader();
                    Payment_Type_DropDownList.DataTextField = "payment_Arabic_type";
                    Payment_Type_DropDownList.DataValueField = "payment_type_Id";
                    Payment_Type_DropDownList.DataBind();
                    Payment_Type_DropDownList.Items.Insert(0, "إخترنوع الدفع ....");
                    _sqlCon.Close();
                }

                //    //Fill aseet_Location DropDownList
                using (MySqlCommand getContractTypeDropDownListCmd =
                       new MySqlCommand("SELECT * FROM contract_type"))
                {
                    getContractTypeDropDownListCmd.CommandType = CommandType.Text;
                    getContractTypeDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    Contract_Type_DropDownList.DataSource = getContractTypeDropDownListCmd.ExecuteReader();
                    Contract_Type_DropDownList.DataTextField = "Contract_Arabic_Type";
                    Contract_Type_DropDownList.DataValueField = "Contract_Type_Id";
                    Contract_Type_DropDownList.DataBind();
                    Contract_Type_DropDownList.Items.Insert(0, "إخترنوع العقد ....");
                    _sqlCon.Close();
                }
            }
        }

        protected void btn_Add_Contract_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addContractQuery = "Insert Into contract (" +
                                            "Contract_Details , " +
                                            "Payment_Amount  , " +
                                            "Date_Of_Sgin        , " +
                                            "Start_Date       , " +
                                            "End_Date         , " +
                                            "users_user_ID , " +
                                            "contract_type_Contract_Type_Id   , " +
                                            "contract_template_Contract_template_Id , " +
                                            "payment_frequency_Payment_Frequency_Id , " +
                                            "tenants_Tenants_ID , " +
                                            "payment_type_payment_type_Id) " +
                                            "VALUES( " +
                                            "@Contract_Details , " +
                                            "@Payment_Amount  , " +
                                            "@Date_Of_Sgin        , " +
                                            "@Start_Date       , " +
                                            "@End_Date         , " +
                                            "@users_user_ID , " +
                                            "@contract_type_Contract_Type_Id   , " +
                                            "@contract_template_Contract_template_Id , " +
                                            "@payment_frequency_Payment_Frequency_Id , " +
                                            "@tenants_Tenants_ID , " +
                                            "@payment_type_payment_type_Id ) ";
                _sqlCon.Open();
                using (MySqlCommand addContractCmd = new MySqlCommand(addContractQuery, _sqlCon))
                {
                    //Fill The Database with All DropDownLists Items
                    //addContractCmd.Parameters.AddWithValue("@employee_Employee_Id",
                    //    Employee_Name_DropDownList.SelectedValue);
                    addContractCmd.Parameters.AddWithValue("@contract_type_Contract_Type_Id",
                        Contract_Type_DropDownList.SelectedValue);
                    addContractCmd.Parameters.AddWithValue("@contract_template_Contract_template_Id",
                        Contract_Templet_DropDownList.SelectedValue);
                    addContractCmd.Parameters.AddWithValue("@payment_frequency_Payment_Frequency_Id",
                        Payment_Frquancy_DropDownList.SelectedValue);
                    addContractCmd.Parameters.AddWithValue("@tenants_Tenants_ID",
                        Tenan_Name_DropDownList.SelectedValue);
                    addContractCmd.Parameters.AddWithValue("@payment_type_payment_type_Id",
                        Payment_Type_DropDownList.SelectedValue);

                    addContractCmd.Parameters.AddWithValue("@users_user_ID", Session["user_ID"]);

                    //Fill The Database with All Textbox Items
                    addContractCmd.Parameters.AddWithValue("@Contract_Details", txt_Contract_Details.Text);
                    addContractCmd.Parameters.AddWithValue("@Payment_Amount", txt_Payment_Amount.Text);
                    addContractCmd.Parameters.AddWithValue("@Date_Of_Sgin", txt_Sign_Date.Text);
                    addContractCmd.Parameters.AddWithValue("@Start_Date", txt_Start_Date.Text);
                    addContractCmd.Parameters.AddWithValue("@End_Date", txt_End_Date.Text);

                    addContractCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }

                lbl_Success_Add_New_Contract.Text = "تمت الإضافة بنجاح";
            }
        }

        protected void btn_Back_To_Contract_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contract_List.aspx");
        }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ////+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /////+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /////+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /////+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        /////+++++++++++++++++++++++++++++++++++++++++ Desgin OF Contracting ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        /////+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /////+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /////+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /////+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

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

        //************************ Cheque1_ Date **********************************************************
        protected void btn_Cheque1_Date_Chosee_Click(object sender, EventArgs e)
        {
            Cheque1_Date_Div.Visible = true; Cheque1_Date_ImageButton.Visible = true;
        }

        protected void Cheque1_Date_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txt_Cheque1_Date.Text = Cheque1_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_Cheque1_Date.Text != "") { Cheque1_Date_Div.Visible = false; Cheque1_Date_ImageButton.Visible = false; }
        }

        protected void Cheque1_Date_ImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Cheque1_Date_Div.Visible = false; Cheque1_Date_ImageButton.Visible = false;
        }

        //************************ Cheque2_ Date **********************************************************
        protected void btn_Cheque2_Date_Chosee_Click(object sender, EventArgs e)
        {
            Cheque2_Date_Div.Visible = true; Cheque2_Date_ImageButton.Visible = true;
        }

        protected void Cheque2_Date_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txt_Cheque2_Date.Text = Cheque2_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_Cheque2_Date.Text != "") { Cheque2_Date_Div.Visible = false; Cheque2_Date_ImageButton.Visible = false; }
        }

        protected void Cheque2_Date_ImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Cheque2_Date_Div.Visible = false; Cheque2_Date_ImageButton.Visible = false;
        }

        //************************ Cheque3_ Date **********************************************************
        protected void btn_Cheque3_Date_Chosee_Click(object sender, EventArgs e)
        {
            Cheque3_Date_Div.Visible = true; Cheque3_Date_ImageButton.Visible = true;
        }

        protected void Cheque3_Date_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txt_Cheque3_Date.Text = Cheque3_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_Cheque3_Date.Text != "") { Cheque3_Date_Div.Visible = false; Cheque3_Date_ImageButton.Visible = false; }
        }

        protected void Cheque3_Date_ImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Cheque3_Date_Div.Visible = false; Cheque3_Date_ImageButton.Visible = false;
        }

        //************************ Cheque4_ Date **********************************************************
        protected void btn_Cheque4_Date_Chosee_Click(object sender, EventArgs e)
        {
            Cheque4_Date_Div.Visible = true; Cheque4_Date_ImageButton.Visible = true;
        }

        protected void Cheque4_Date_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txt_Cheque4_Date.Text = Cheque4_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_Cheque4_Date.Text != "") { Cheque4_Date_Div.Visible = false; Cheque4_Date_ImageButton.Visible = false; }
        }

        protected void Cheque4_Date_ImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Cheque4_Date_Div.Visible = false; Cheque4_Date_ImageButton.Visible = false;
        }

        //************************ Cheque5_ Date **********************************************************
        protected void btn_Cheque5_Date_Chosee_Click(object sender, EventArgs e)
        {
            Cheque5_Date_Div.Visible = true; Cheque5_Date_ImageButton.Visible = true;
        }

        protected void Cheque5_Date_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txt_Cheque5_Date.Text = Cheque5_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_Cheque5_Date.Text != "") { Cheque5_Date_Div.Visible = false; Cheque5_Date_ImageButton.Visible = false; }
        }

        protected void Cheque5_Date_ImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Cheque5_Date_Div.Visible = false; Cheque5_Date_ImageButton.Visible = false;
        }

        //************************ Cheque6_ Date **********************************************************
        protected void btn_Cheque6_Date_Chosee_Click(object sender, EventArgs e)
        {
            Cheque6_Date_Div.Visible = true; Cheque6_Date_ImageButton.Visible = true;
        }

        protected void Cheque6_Date_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txt_Cheque6_Date.Text = Cheque6_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_Cheque6_Date.Text != "") { Cheque6_Date_Div.Visible = false; Cheque6_Date_ImageButton.Visible = false; }
        }

        protected void Cheque6_Date_ImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Cheque6_Date_Div.Visible = false; Cheque6_Date_ImageButton.Visible = false;
        }

        //************************ Cheque7_ Date **********************************************************
        protected void btn_Cheque7_Date_Chosee_Click(object sender, EventArgs e)
        {
            Cheque7_Date_Div.Visible = true; Cheque7_Date_ImageButton.Visible = true;
        }

        protected void Cheque7_Date_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txt_Cheque7_Date.Text = Cheque7_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_Cheque7_Date.Text != "") { Cheque7_Date_Div.Visible = false; Cheque7_Date_ImageButton.Visible = false; }
        }

        protected void Cheque7_Date_ImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Cheque7_Date_Div.Visible = false; Cheque7_Date_ImageButton.Visible = false;
        }

        //************************ Cheque8_ Date **********************************************************
        protected void btn_Cheque8_Date_Chosee_Click(object sender, EventArgs e)
        {
            Cheque8_Date_Div.Visible = true; Cheque8_Date_ImageButton.Visible = true;
        }

        protected void Cheque8_Date_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txt_Cheque8_Date.Text = Cheque8_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_Cheque8_Date.Text != "") { Cheque8_Date_Div.Visible = false; Cheque8_Date_ImageButton.Visible = false; }
        }

        protected void Cheque8_Date_ImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Cheque8_Date_Div.Visible = false; Cheque8_Date_ImageButton.Visible = false;
        }

        //************************ Cheque9_ Date **********************************************************
        protected void btn_Cheque9_Date_Chosee_Click(object sender, EventArgs e)
        {
            Cheque9_Date_Div.Visible = true; Cheque9_Date_ImageButton.Visible = true;
        }

        protected void Cheque9_Date_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txt_Cheque9_Date.Text = Cheque9_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_Cheque9_Date.Text != "") { Cheque9_Date_Div.Visible = false; Cheque9_Date_ImageButton.Visible = false; }
        }

        protected void Cheque9_Date_ImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Cheque9_Date_Div.Visible = false; Cheque9_Date_ImageButton.Visible = false;
        }

        //************************ Cheque10_ Date **********************************************************
        protected void btn_Cheque10_Date_Chosee_Click(object sender, EventArgs e)
        {
            Cheque10_Date_Div.Visible = true; Cheque10_Date_ImageButton.Visible = true;
        }

        protected void Cheque10_Date_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txt_Cheque10_Date.Text = Cheque10_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_Cheque10_Date.Text != "") { Cheque10_Date_Div.Visible = false; Cheque10_Date_ImageButton.Visible = false; }
        }

        protected void Cheque10_Date_ImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Cheque10_Date_Div.Visible = false; Cheque10_Date_ImageButton.Visible = false;
        }

        //************************ Cheque11_ Date **********************************************************
        protected void btn_Cheque11_Date_Chosee_Click(object sender, EventArgs e)
        {
            Cheque11_Date_Div.Visible = true; Cheque11_Date_ImageButton.Visible = true;
        }

        protected void Cheque11_Date_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txt_Cheque11_Date.Text = Cheque11_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_Cheque11_Date.Text != "") { Cheque11_Date_Div.Visible = false; Cheque11_Date_ImageButton.Visible = false; }
        }

        protected void Cheque11_Date_ImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Cheque11_Date_Div.Visible = false; Cheque11_Date_ImageButton.Visible = false;
        }

        //************************ Cheque12_ Date **********************************************************
        protected void btn_Cheque12_Date_Chosee_Click(object sender, EventArgs e)
        {
            Cheque12_Date_Div.Visible = true; Cheque12_Date_ImageButton.Visible = true;
        }

        protected void Cheque12_Date_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txt_Cheque12_Date.Text = Cheque12_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_Cheque12_Date.Text != "") { Cheque12_Date_Div.Visible = false; Cheque12_Date_ImageButton.Visible = false; }
        }

        protected void Cheque12_Date_ImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Cheque12_Date_Div.Visible = false; Cheque12_Date_ImageButton.Visible = false;
        }

        //************************ Cheque13_ Date **********************************************************
        protected void btn_Cheque13_Date_Chosee_Click(object sender, EventArgs e)
        {
            Cheque13_Date_Div.Visible = true; Cheque13_Date_ImageButton.Visible = true;
        }

        protected void Cheque13_Date_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txt_Cheque13_Date.Text = Cheque13_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_Cheque13_Date.Text != "") { Cheque13_Date_Div.Visible = false; Cheque13_Date_ImageButton.Visible = false; }
        }

        protected void Cheque13_Date_ImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Cheque13_Date_Div.Visible = false; Cheque13_Date_ImageButton.Visible = false;
        }

        //**********************************************  Contract Type  ****************************************************
        protected void Contract_Type_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Contract_Type_DropDownList.SelectedValue == "1")
            {
                lbl_No_Of_Months.Text = "عدد السنوات";
                div_No_Of_Months.Visible = true;
                No_Of_Months_DropDownList.Items.Add("1"); No_Of_Months_DropDownList.Items.Add("2"); No_Of_Months_DropDownList.Items.Add("3");
                No_Of_Months_DropDownList.Items.Add("4"); No_Of_Months_DropDownList.Items.Add("5");

                //div_No_Of_Months.Visible = true; lbl_Add_Cheques.Visible = true; Close_Cheque_Table_ImageButton.Visible = true;
                //Cheque_Tbl.Visible = true;
                //Cheque_3.Visible = false; Cheque_4.Visible = false; Cheque_5.Visible = false; Cheque_6.Visible = false;
                //Cheque_7.Visible = false; Cheque_8.Visible = false; Cheque_9.Visible = false; Cheque_10.Visible = false;
                //Cheque_11.Visible = false; Cheque_12.Visible = false; Cheque_13.Visible = false;
            }
            else if (Contract_Type_DropDownList.SelectedValue == "2")
            {
                Close_Cheque_Table_ImageButton.Visible = true;
                div_No_Of_Months.Visible = false; lbl_Add_Cheques.Visible = true;
                Cheque_Tbl.Visible = true;
                Cheque_1.Visible = true; Cheque_2.Visible = true; Cheque_3.Visible = true; Cheque_4.Visible = true; Cheque_5.Visible = true; Cheque_6.Visible = true; Cheque_7.Visible = true;
                Cheque_8.Visible = true; Cheque_9.Visible = true; Cheque_10.Visible = true; Cheque_11.Visible = true; Cheque_12.Visible = true; Cheque_13.Visible = true;
            }
            else if (Contract_Type_DropDownList.SelectedValue == "3")
            {
            }
            else if (Contract_Type_DropDownList.SelectedValue == "4")
            {
            }
        }

        protected void No_Of_Months_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (No_Of_Months_DropDownList.SelectedValue == "1")
            {
                Cheque_Tbl.Visible = true; Close_Cheque_Table_ImageButton.Visible = true;
                Cheque_3.Visible = false; Cheque_4.Visible = false; Cheque_5.Visible = false; Cheque_6.Visible = false;
                Cheque_7.Visible = false; Cheque_8.Visible = false; Cheque_9.Visible = false; Cheque_10.Visible = false;
                Cheque_11.Visible = false; Cheque_12.Visible = false; Cheque_13.Visible = false;
            }
            else if (No_Of_Months_DropDownList.SelectedValue == "2")
            {
                Cheque_Tbl.Visible = true; Close_Cheque_Table_ImageButton.Visible = true;
                Cheque_1.Visible = true; Cheque_2.Visible = true; Cheque_3.Visible = true;

                Cheque_4.Visible = false; Cheque_5.Visible = false; Cheque_6.Visible = false;
                Cheque_7.Visible = false; Cheque_8.Visible = false; Cheque_9.Visible = false; Cheque_10.Visible = false;
                Cheque_11.Visible = false; Cheque_12.Visible = false; Cheque_13.Visible = false;
            }
            else if (No_Of_Months_DropDownList.SelectedValue == "3")
            {
                Cheque_Tbl.Visible = true; Close_Cheque_Table_ImageButton.Visible = true;
                Cheque_1.Visible = true; Cheque_2.Visible = true; Cheque_3.Visible = true; Cheque_4.Visible = true;

                Cheque_6.Visible = false;
                Cheque_7.Visible = false; Cheque_8.Visible = false; Cheque_9.Visible = false; Cheque_10.Visible = false;
                Cheque_11.Visible = false; Cheque_12.Visible = false; Cheque_13.Visible = false;
            }
            else if (No_Of_Months_DropDownList.SelectedValue == "4")
            {
                Cheque_Tbl.Visible = true; Close_Cheque_Table_ImageButton.Visible = true;
                Cheque_1.Visible = true; Cheque_2.Visible = true; Cheque_3.Visible = true; Cheque_4.Visible = true; Cheque_5.Visible = true;

                Cheque_6.Visible = false;
                Cheque_7.Visible = false; Cheque_8.Visible = false; Cheque_9.Visible = false; Cheque_10.Visible = false;
                Cheque_11.Visible = false; Cheque_12.Visible = false; Cheque_13.Visible = false;
            }
            else if (No_Of_Months_DropDownList.SelectedValue == "5")
            {
                Cheque_Tbl.Visible = true; Close_Cheque_Table_ImageButton.Visible = true;
                Cheque_1.Visible = true; Cheque_2.Visible = true; Cheque_3.Visible = true; Cheque_4.Visible = true; Cheque_5.Visible = true; Cheque_6.Visible = true;

                Cheque_7.Visible = false; Cheque_8.Visible = false; Cheque_9.Visible = false; Cheque_10.Visible = false;
                Cheque_11.Visible = false; Cheque_12.Visible = false; Cheque_13.Visible = false;
            }
            else if (No_Of_Months_DropDownList.SelectedValue == "6")
            {
                Cheque_Tbl.Visible = true; Close_Cheque_Table_ImageButton.Visible = true;
                Cheque_1.Visible = true; Cheque_2.Visible = true; Cheque_3.Visible = true; Cheque_4.Visible = true; Cheque_5.Visible = true; Cheque_6.Visible = true; Cheque_7.Visible = true;

                Cheque_8.Visible = false; Cheque_9.Visible = false; Cheque_10.Visible = false;
                Cheque_11.Visible = false; Cheque_12.Visible = false; Cheque_13.Visible = false;
            }
            else if (No_Of_Months_DropDownList.SelectedValue == "7")
            {
                Cheque_Tbl.Visible = true; Close_Cheque_Table_ImageButton.Visible = true;
                Cheque_1.Visible = true; Cheque_2.Visible = true; Cheque_3.Visible = true; Cheque_4.Visible = true; Cheque_5.Visible = true; Cheque_6.Visible = true; Cheque_7.Visible = true;
                Cheque_8.Visible = true;

                Cheque_9.Visible = false; Cheque_10.Visible = false;
                Cheque_11.Visible = false; Cheque_12.Visible = false; Cheque_13.Visible = false;
            }
            else if (No_Of_Months_DropDownList.SelectedValue == "8")
            {
                Cheque_Tbl.Visible = true; Close_Cheque_Table_ImageButton.Visible = true;
                Cheque_1.Visible = true; Cheque_2.Visible = true; Cheque_3.Visible = true; Cheque_4.Visible = true; Cheque_5.Visible = true; Cheque_6.Visible = true; Cheque_7.Visible = true;
                Cheque_8.Visible = true; Cheque_9.Visible = true;

                Cheque_10.Visible = false;
                Cheque_11.Visible = false; Cheque_12.Visible = false; Cheque_13.Visible = false;
            }
            else if (No_Of_Months_DropDownList.SelectedValue == "9")
            {
                Cheque_Tbl.Visible = true; Close_Cheque_Table_ImageButton.Visible = true;
                Cheque_1.Visible = true; Cheque_2.Visible = true; Cheque_3.Visible = true; Cheque_4.Visible = true; Cheque_5.Visible = true; Cheque_6.Visible = true; Cheque_7.Visible = true;
                Cheque_8.Visible = true; Cheque_9.Visible = true; Cheque_10.Visible = true;

                Cheque_11.Visible = false; Cheque_12.Visible = false; Cheque_13.Visible = false;
            }
            else if (No_Of_Months_DropDownList.SelectedValue == "10")
            {
                Cheque_Tbl.Visible = true; Close_Cheque_Table_ImageButton.Visible = true;
                Cheque_1.Visible = true; Cheque_2.Visible = true; Cheque_3.Visible = true; Cheque_4.Visible = true; Cheque_5.Visible = true; Cheque_6.Visible = true; Cheque_7.Visible = true;
                Cheque_8.Visible = true; Cheque_9.Visible = true; Cheque_10.Visible = true; Cheque_11.Visible = true;

                Cheque_12.Visible = false; Cheque_13.Visible = false;
            }
            else if (No_Of_Months_DropDownList.SelectedValue == "11")
            {
                Cheque_Tbl.Visible = true; Close_Cheque_Table_ImageButton.Visible = true;
                Cheque_1.Visible = true; Cheque_2.Visible = true; Cheque_3.Visible = true; Cheque_4.Visible = true; Cheque_5.Visible = true; Cheque_6.Visible = true; Cheque_7.Visible = true;
                Cheque_8.Visible = true; Cheque_9.Visible = true; Cheque_10.Visible = true; Cheque_11.Visible = true; Cheque_12.Visible = true;

                Cheque_13.Visible = false;
            }
        }

        protected void Close_Cheque_Table_ImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Close_Cheque_Table_ImageButton.Visible = false;
            Cheque_Tbl.Visible = false;
            lbl_Add_Cheques.Visible = false;
        }
    }
}