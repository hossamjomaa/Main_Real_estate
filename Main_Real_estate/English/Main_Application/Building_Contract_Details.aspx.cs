using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Building_Contract_Details : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) { Label1.Text = Request.UrlReferrer.ToString(); }
            //*********************************************************************************************************

            // Get Contract Details

            _sqlCon.Open();
            string ContractId = Request.QueryString["Id"];
            using (MySqlCommand ContractDetailsCmd = new MySqlCommand("Building_Contract_Detalis", _sqlCon))
            {
                ContractDetailsCmd.CommandType = CommandType.StoredProcedure;
                ContractDetailsCmd.Parameters.AddWithValue("@Id", ContractId);
                using (MySqlDataAdapter ContractDetailsSda = new MySqlDataAdapter(ContractDetailsCmd))
                {
                    DataTable ContractDetailsDt = new DataTable();
                    ContractDetailsSda.Fill(ContractDetailsDt);
                    lbl_Sgin_Date.Text = ContractDetailsDt.Rows[0]["Date_Of_Sgin"].ToString();
                    lbl_tenant_Name.Text = ContractDetailsDt.Rows[0]["Tenants_Arabic_Name"].ToString();

                    if (ContractDetailsDt.Rows[0]["Arabic_nationality"].ToString() == "لا يوجد")
                    {
                        lbl_Tenant_Nationality.Text = ".....";
                    }
                    else
                    {
                        lbl_Tenant_Nationality.Text = ContractDetailsDt.Rows[0]["Arabic_nationality"].ToString();
                    }
                    //*************************************************************************************************************************

                    lbl_Tenant_Mobile.Text = ContractDetailsDt.Rows[0]["Tenants_Mobile"].ToString();

                    lbl_Building_Number.Text = ContractDetailsDt.Rows[0]["Building_Arabic_Name"].ToString();

                    lbl_Street_Number.Text = ContractDetailsDt.Rows[0]["Street_NO"].ToString();
                    lbl_street_Name.Text = ContractDetailsDt.Rows[0]["Street_Name"].ToString();
                    lbl_Unit_Type.Text= ContractDetailsDt.Rows[0]["Building_Arabic_Type"].ToString();
                    lbl_Zone_Number.Text = ContractDetailsDt.Rows[0]["zone_number"].ToString();
                    lbl_Strat_Date.Text = ContractDetailsDt.Rows[0]["Start_Date"].ToString();
                    lbl_End_Date.Text = ContractDetailsDt.Rows[0]["End_Date"].ToString();
                    lbl_Tenant_Mobile.Text = ContractDetailsDt.Rows[0]["Tenants_Mobile"].ToString();
                    lbl_Payment_Amount.Text = ContractDetailsDt.Rows[0]["Payment_Amount"].ToString();
                    lbl_Payment_Amount_L.Text = ContractDetailsDt.Rows[0]["Payment_Amount_L"].ToString();
                    Contract_Type.Text = ContractDetailsDt.Rows[0]["Contract_Arabic_Type"].ToString();
                    //**************************************  Rental_allowed_Or_Not_allowed *****************************************
                    if (ContractDetailsDt.Rows[0]["Rental_allowed_Or_Not_allowed"].ToString() == "1")
                    {
                        lbl_Rental_allowed_Or_Not_allowed.Text = "يجوز";
                    }
                    else
                    {
                        lbl_Rental_allowed_Or_Not_allowed.Text = "لا يجوز";
                    }
                    //**************************************  Paymen_Method *****************************************
                    if (ContractDetailsDt.Rows[0]["Paymen_Method"].ToString() == "شيكات")
                    {
                        lbl_Paymen_Method.Text = "بموجب شيكات بنكية";
                    }
                    else if (ContractDetailsDt.Rows[0]["Paymen_Method"].ToString() == "تحويل")
                    {
                        lbl_Paymen_Method.Text = "بموجب تحويل بنكي";
                    }
                    else if (ContractDetailsDt.Rows[0]["Paymen_Method"].ToString() == "نقداً")
                    {
                        lbl_Paymen_Method.Text = "نقداً";
                    }
                    else
                    {
                        lbl_Paymen_Method.Text = "بموجب شيكات بنكية";
                    }

                    //**************************************  maintenance *****************************************
                    if (ContractDetailsDt.Rows[0]["maintenance"].ToString() == "1")
                    {
                        lbl_maintenance.Text = "على المؤجر";
                    }
                    else
                    {
                        lbl_maintenance.Text = "على المستاجر";
                    }

                    //**************************************  Contract_Details *****************************************
                    if (ContractDetailsDt.Rows[0]["Contract_Details"].ToString() != "")
                    {
                        lbl_No_23.Text = "<br /> البند الثالث و العشرين  <br />";
                        lbl_Contract_Details.Text = ContractDetailsDt.Rows[0]["Contract_Details"].ToString() + "<br />";
                    }
                    else
                    {
                        lbl_No_23.Text = "";
                        lbl_Contract_Details.Text = "";
                    }

                    //**************************************  Free_Period *****************************************
                    if (ContractDetailsDt.Rows[0]["Duration_free_period"].ToString() != "")
                    {
                        Free_Period.Visible = true;

                        Start_Free_Period.Text = ContractDetailsDt.Rows[0]["Start_Free_Period"].ToString();
                        Duration_free_period.Text = ContractDetailsDt.Rows[0]["Duration_free_period"].ToString();
                    }
                    else
                    {
                        Free_Period.Visible = false;
                        Start_Free_Period.Text = "";
                        Duration_free_period.Text = "";
                    }

                    //*************************************  Reason_For_Rent*****************************************
                    if (ContractDetailsDt.Rows[0]["reason_for_rent_Reason_For_Rent_Id"].ToString() == "1")
                    {
                        lbl_Reason_For_Rent.Text = "سكن عائلي";
                        lbl_Reason_For_Rent_Discribtion.Text = "عدم إسكان العزاب الذكور فيها إلا بإذن خطي من المؤجر";
                    }
                    else if (ContractDetailsDt.Rows[0]["reason_for_rent_Reason_For_Rent_Id"].ToString() == "2")
                    {
                        lbl_Reason_For_Rent.Text = "عمل تجاري";
                        lbl_Reason_For_Rent_Discribtion.Text = "";
                    }
                    else if (ContractDetailsDt.Rows[0]["reason_for_rent_Reason_For_Rent_Id"].ToString() == "3")
                    {
                        lbl_Reason_For_Rent.Text = "سكن عزاب";
                        lbl_Reason_For_Rent_Discribtion.Text =
                            "وبالعدد الموافق لسعة العين المؤجرة أي بحد أقصى شخص لكل أربع متر لغرفة النوم فقط";
                    }
                    //**************************************  Furniture_case *****************************************

                    //lbl_Contract_Details.Text = ContractDetailsDt.Rows[0]["Contract_Details"].ToString();

                    if (ContractDetailsDt.Rows[0]["contract_type_Contract_Type_Id"].ToString() == "1" &&
                        ContractDetailsDt.Rows[0]["Duration_free_period"].ToString() == "")
                    {
                        if (ContractDetailsDt.Rows[0]["Number_Of_Years"].ToString() == "1" ||
                            ContractDetailsDt.Rows[0]["Number_Of_Years"].ToString() == "2")
                        {
                            lbl_Month_Year_Number.Text =
                                ContractDetailsDt.Rows[0]["Number_Of_Years"].ToString() + " " + "سنة";
                        }
                        else
                        {
                            lbl_Month_Year_Number.Text =
                                ContractDetailsDt.Rows[0]["Number_Of_Years"].ToString() + " " + "سنوات";
                        }
                    }
                    else if (ContractDetailsDt.Rows[0]["contract_type_Contract_Type_Id"].ToString() == "1" &&
                             ContractDetailsDt.Rows[0]["Duration_free_period"].ToString() != "")
                    {
                        if (ContractDetailsDt.Rows[0]["Number_Of_Years"].ToString() == "1" ||
                            ContractDetailsDt.Rows[0]["Number_Of_Years"].ToString() == "2")
                        {
                            lbl_Month_Year_Number.Text = ContractDetailsDt.Rows[0]["Number_Of_Years"].ToString() + " " +
                                                         "سنة و ";
                        }
                        else
                        {
                            lbl_Month_Year_Number.Text = ContractDetailsDt.Rows[0]["Number_Of_Years"].ToString() + " " +
                                                         "سنوات و";
                        }

                        if (ContractDetailsDt.Rows[0]["Duration_free_period"].ToString() == "1" ||
                            ContractDetailsDt.Rows[0]["Duration_free_period"].ToString() == "2")
                        {
                            lbl_Duration_free_period.Text =
                                ContractDetailsDt.Rows[0]["Duration_free_period"].ToString() + " " + "شهر";
                        }
                        else
                        {
                            lbl_Duration_free_period.Text =
                                ContractDetailsDt.Rows[0]["Duration_free_period"].ToString() + " " + "أشهر";
                        }
                    }
                    else if (ContractDetailsDt.Rows[0]["contract_type_Contract_Type_Id"].ToString() != "1" &&
                             ContractDetailsDt.Rows[0]["Duration_free_period"].ToString() != "")
                    {
                        string Sum_Contarct_Duration =
                            (Convert.ToInt32(ContractDetailsDt.Rows[0]["Number_Of_Mounth"].ToString()) +
                             Convert.ToInt32(ContractDetailsDt.Rows[0]["Duration_free_period"].ToString())).ToString();
                        if (Sum_Contarct_Duration == "1" || Sum_Contarct_Duration == "2")
                        {
                            lbl_Month_Year_Number.Text = Sum_Contarct_Duration + "شهر";
                            lbl_Duration_free_period.Text = "";
                        }
                        else
                        {
                            lbl_Month_Year_Number.Text = Sum_Contarct_Duration + "أشهر";
                            lbl_Duration_free_period.Text = "";
                        }
                    }
                    else
                    {
                        if (ContractDetailsDt.Rows[0]["Number_Of_Mounth"].ToString() == "1" ||
                            ContractDetailsDt.Rows[0]["Number_Of_Mounth"].ToString() == "2")
                        {
                            lbl_Month_Year_Number.Text =
                                ContractDetailsDt.Rows[0]["Number_Of_Mounth"].ToString() + " " + "شهر";
                        }
                        else
                        {
                            lbl_Month_Year_Number.Text =
                                ContractDetailsDt.Rows[0]["Number_Of_Mounth"].ToString() + " " + "أشهر";
                        }
                    }

                    if (ContractDetailsDt.Rows[0]["tenant_type_Tenant_Type_Id"].ToString() == "2")
                    {
                        lbl_MR_Or_Mrs_Or_Com.Text = "السادة شركة :";
                        lbl_Tenant_Qid.Text = ContractDetailsDt.Rows[0]["ID_NO"].ToString();
                        lbl_Po_Cr.Text = "سجل تجاري رقم :&nbsp;" +
                                         ContractDetailsDt.Rows[0]["business_records"].ToString() +
                                         " &nbsp;&nbsp;,&nbsp;" +
                                         " ص.ب رقم &nbsp;" + ContractDetailsDt.Rows[0]["P_O_Box"].ToString();

                        using (MySqlCommand Com_Rep_Details_Cmd = new MySqlCommand("Com_Rep_Detail", _sqlCon))
                        {
                            Com_Rep_Details_Cmd.CommandType = CommandType.StoredProcedure;
                            Com_Rep_Details_Cmd.Parameters.AddWithValue("@Id",
                                ContractDetailsDt.Rows[0]["Com_rep"].ToString());
                            using (MySqlDataAdapter Com_Rep_DetailsSda = new MySqlDataAdapter(Com_Rep_Details_Cmd))
                            {
                                DataTable Com_Rep_DetailsDt = new DataTable();
                                Com_Rep_DetailsSda.Fill(Com_Rep_DetailsDt);
                                lbl_Com_Rep_Name.Text = "ويمثلها السيد(ة)	" +
                                                        Com_Rep_DetailsDt.Rows[0]["Com_rep_En_Name"].ToString();
                                lbl_Tenant_Qid.Text = Com_Rep_DetailsDt.Rows[0]["Com_rep_QID_NO"].ToString();
                                lbl_Com_Rep_Mobile.Text = "رقم الهاتف  :" + Com_Rep_DetailsDt.Rows[0]["Com_rep_Mobile"].ToString();
                                lbl_Tenant_Nationality.Text =
                                    Com_Rep_DetailsDt.Rows[0]["Arabic_nationality"].ToString();
                            }
                        }
                    }
                    else
                    {
                        lbl_MR_Or_Mrs_Or_Com.Text = "السيد (ة):";
                        lbl_Tenant_Qid.Text = ContractDetailsDt.Rows[0]["ID_NO"].ToString();
                    }




                    //******************************************************************************
                    //******************************************************************************
                    //******************************************************************************
                    int buildingCount = Convert.ToInt32(ContractDetailsDt.Rows[0]["buildingCount"].ToString());
                    string BuildingID = ContractDetailsDt.Rows[0]["building_Building_Id"].ToString();
                    string getZoneQuari = "SELECT * FROM units where building_Building_Id ='" + BuildingID + "'";
                    MySqlCommand getZoneCmd = new MySqlCommand(getZoneQuari, _sqlCon);
                    MySqlDataAdapter getZoneDt = new MySqlDataAdapter(getZoneCmd);
                    getZoneCmd.Connection = _sqlCon;
                    getZoneDt.SelectCommand = getZoneCmd;
                    DataTable getZoneDataTable = new DataTable();
                    getZoneDt.Fill(getZoneDataTable);
                    Units_GridView.DataSource = getZoneDataTable;
                    Units_GridView.DataBind();
                }

            }
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            if (Label1.Text == "https://almanara.wisdom.qa/")
            {
                string ContractId = Request.QueryString["Id"];



                DataTable getTenant_IDDt = new DataTable();
                MySqlCommand getTenant_IDCmd = new MySqlCommand("SELECT tenants_Tenants_ID FROM contract WHERE Contract_Id = @ID", _sqlCon);
                MySqlDataAdapter getTenant_IDDa = new MySqlDataAdapter(getTenant_IDCmd);
                getTenant_IDCmd.Parameters.AddWithValue("@ID", ContractId);
                getTenant_IDDa.Fill(getTenant_IDDt);
                if (getTenant_IDDt.Rows.Count > 0)
                {
                    string Tenant_Id = getTenant_IDDt.Rows[0]["tenants_Tenants_ID"].ToString();
                    Response.Redirect("https://almanara.wisdom.qa/User_Page?Id=" + Tenant_Id);
                }

                _sqlCon.Close();
            }
            else
            {
                Response.Redirect(Label1.Text);
            }
        }
    }
}