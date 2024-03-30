using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Security.Cryptography;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Collect_Multi_Cheuqe : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Collecting", 0, "R");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!this.IsPostBack)
            {
                Multi_Chueqe();
            }
        }
        protected void Multi_Chueqe()
        {
            string ChueqeId = Request.QueryString["Id"];


            string getSingl_ChueqeQuari = "SELECT  " +
                "Cq.*,   " +
                " Cq_T.Cheque_arabic_Type  ,  " +
                "B.Bank_Arabic_Name , " +
                "T.Tenants_Arabic_Name , " +
                "T.Tenants_ID, " +
                "(select building_Building_Id from building_contract where Contract_Id = Cq.building_contract_Contract_Id )B_ID, " +
                " (select owner_ship_Owner_Ship_Id from building where Building_Id=B_ID ) O_ID, " +
                "(select Building_Arabic_Name from building where Building_Id=B_ID)B_Name, " +
                " (select Owner_Ship_AR_Name from owner_ship where Owner_Ship_Id=O_ID)O_Name , " +
                "(select owner_ship_Code from owner_ship where Owner_Ship_Id=O_ID)O_Code " +
                "FROM  building_cheques Cq " +
                "left join  cheque_type Cq_T on (Cq.cheque_type_Cheque_Type_id = Cq_T.Cheque_Type_id) " +
                " left join  bank B on (Cq.bank_Bank_Id = B.Bank_Id) " +
                "left join  tenants T on (Cq.tenants_Tenants_ID = T.Tenants_ID)  where Cheques_Id = '" + ChueqeId + "'  ";

            MySqlCommand getMulti_ChueqeCmd = new MySqlCommand(getSingl_ChueqeQuari, _sqlCon);
            MySqlDataAdapter getMulti_ChueqeDt = new MySqlDataAdapter(getMulti_ChueqeCmd);
            getMulti_ChueqeCmd.Connection = _sqlCon;
            _sqlCon.Open();
            getMulti_ChueqeDt.SelectCommand = getMulti_ChueqeCmd;
            DataTable getMulti_ChueqeDataTable = new DataTable();
            getMulti_ChueqeDt.Fill(getMulti_ChueqeDataTable);
            if (getMulti_ChueqeDataTable.Rows.Count > 0)
            {
                O_ID.Text = getMulti_ChueqeDataTable.Rows[0]["O_ID"].ToString();
                B_ID.Text = getMulti_ChueqeDataTable.Rows[0]["B_ID"].ToString();
                Tenant_ID.Text = getMulti_ChueqeDataTable.Rows[0]["Tenants_ID"].ToString();
                Month.Text = Convert.ToString(Convert.ToDateTime(getMulti_ChueqeDataTable.Rows[0]["Cheques_Date"].ToString()).Month);
                Year.Text = Convert.ToString(Convert.ToDateTime(getMulti_ChueqeDataTable.Rows[0]["Cheques_Date"].ToString()).Year);




                txt_Cheuqe_NO.Text = getMulti_ChueqeDataTable.Rows[0]["Cheques_No"].ToString();
                txt_Bank_Name.Text = getMulti_ChueqeDataTable.Rows[0]["Bank_Arabic_Name"].ToString();
                txt_Cheuqe_Date.Text = getMulti_ChueqeDataTable.Rows[0]["Cheques_Date"].ToString();
                txt_Cheuqe_Amount.Text = getMulti_ChueqeDataTable.Rows[0]["Cheques_Amount"].ToString();

                if (getMulti_ChueqeDataTable.Rows[0]["Cheques_Status"].ToString() == "محصل بالشيك" || getMulti_ChueqeDataTable.Rows[0]["Cheques_Status"].ToString() == "محصل بالتحويل" ||
                    getMulti_ChueqeDataTable.Rows[0]["Cheques_Status"].ToString() == "محصل نقداً" || getMulti_ChueqeDataTable.Rows[0]["Cheques_Status"].ToString() == "محصل")
                {
                    Cheuqe_Status_DropDownList.SelectedValue = "3";
                    Collect_Type_Div.Visible = true;
                    if (getMulti_ChueqeDataTable.Rows[0]["Collect_Type"].ToString() != "")
                    {
                        Collect_Type_DropDownList.Items.FindByText(getMulti_ChueqeDataTable.Rows[0]["Collect_Type"].ToString()).Selected = true;
                    }


                    Collect_Date_Chosee.Visible = true;
                    txt_Collect_Date.Enabled = true;
                }
                else
                {
                    Collect_Type_Div.Visible = false;
                    Cheuqe_Status_DropDownList.Items.FindByText(getMulti_ChueqeDataTable.Rows[0]["Cheques_Status"].ToString()).Selected = true;
                    Collect_Date_Chosee.Visible = false;
                    txt_Collect_Date.Enabled = false;
                }




                txt_Collect_Date.Text = getMulti_ChueqeDataTable.Rows[0]["Collection_Date"].ToString();
            }
            _sqlCon.Close();
        }
        //******************  Cheuqe_Date ***************************************************
        protected void Sign_Date_Calendar_SelectionChanged1(object sender, EventArgs e)
        {
            txt_Cheuqe_Date.Text = Cheuqe_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_Cheuqe_Date.Text != "")
            {
                Cheuqe_Date_divCalendar.Visible = false;
                ImageButton1.Visible = false;
            }
        }
        protected void Date_Chosee_Click(object sender, EventArgs e)
        {
            Cheuqe_Date_divCalendar.Visible = true;
            ImageButton1.Visible = true;
        }
        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Cheuqe_Date_divCalendar.Visible = false;
            ImageButton1.Visible = false;
        }
        //******************  Collect_Date ***************************************************
        protected void Collect_Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txt_Collect_Date.Text = Collect_Calendar.SelectedDate.ToShortDateString();
            if (txt_Collect_Date.Text != "")
            {
                Collect_Date_divCalendar.Visible = false;
                ImageButton2.Visible = false;
            }
        }
        protected void Collect_Date_Chosee_Click(object sender, EventArgs e)
        {
            Collect_Date_divCalendar.Visible = true;
            ImageButton2.Visible = true;
        }
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Collect_Date_divCalendar.Visible = false;
            ImageButton2.Visible = false;
        }
        protected void Cheuqe_Status_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cheuqe_Status_DropDownList.SelectedValue == "3")
            {
                Collect_Type_Div.Visible = true;
                Collect_Date_Chosee.Visible = true;
                txt_Collect_Date.Enabled = true;
            }
            else
            {
                Collect_Type_Div.Visible = false;
                Collect_Date_Chosee.Visible = false;
                txt_Collect_Date.Enabled = false;
            }
        }

        protected void btn_Sumit_Collect_Click(object sender, EventArgs e)
        {
            if (Cheuqe_Status_DropDownList.SelectedValue == "3")
            {
                string Quary = "Select Collection From collection_table Where " +
                               "Ownersip_Id='" + O_ID.Text + "' And Building_Id='" + B_ID.Text + "' " +
                               "And Mounth='" + Month.Text + "' And Year='" + Year.Text + "'";
                MySqlDataAdapter CollectionSda = new MySqlDataAdapter(Quary, _sqlCon);
                DataTable getCollectionDt = new DataTable();
                CollectionSda.Fill(getCollectionDt);
                if (getCollectionDt.Rows.Count > 0)
                {
                    string UPDATECollectionQuary = "UPDATE collection_table SET " +
                                                   " Collection = @Collection Where " +
                                                   "Ownersip_Id='" + O_ID.Text + "' And Building_Id='" + B_ID.Text + "'  " +
                                                   "And Mounth='" + Month.Text + "' And Year='" + Year.Text + "'";

                    _sqlCon.Open();
                    MySqlCommand UPDATECollectionCmd = new MySqlCommand(UPDATECollectionQuary, _sqlCon);
                    UPDATECollectionCmd.Parameters.AddWithValue("@Collection", txt_Cheuqe_Amount.Text);
                    UPDATECollectionCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                else
                {
                    string AddCollectionQuary = "Insert Into collection_table" +
                                           " (Ownersip_Id,Building_Id,Mounth,Year,Collection) " +
                                           "VALUES" +
                                           "(@Ownersip_Id,@Building_Id,@Mounth,@Year,@Collection)";
                    _sqlCon.Open();
                    MySqlCommand addCollectionCmd = new MySqlCommand(AddCollectionQuary, _sqlCon);
                    addCollectionCmd.Parameters.AddWithValue("@Ownersip_Id", O_ID.Text);
                    addCollectionCmd.Parameters.AddWithValue("@Building_Id", B_ID.Text);
                    addCollectionCmd.Parameters.AddWithValue("@Mounth", Month.Text);
                    addCollectionCmd.Parameters.AddWithValue("@Year", Year.Text);
                    addCollectionCmd.Parameters.AddWithValue("@Collection", txt_Cheuqe_Amount.Text);
                    addCollectionCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                _sqlCon.Close();
            }
            else if (Cheuqe_Status_DropDownList.SelectedValue == "5")
            {
                _sqlCon.Open();
                string R_Sub_Weight = "";
                DataTable getWeightDt = new DataTable();
                MySqlCommand getWeightCmd = new MySqlCommand("SELECT R_Sub_Weight  FROM sub_type_evaluation WHERE Sub_Type_Evaluation_Id = @ID", _sqlCon);
                MySqlDataAdapter getWeightDa = new MySqlDataAdapter(getWeightCmd);
                getWeightCmd.Parameters.AddWithValue("@ID", "1");
                getWeightDa.Fill(getWeightDt);
                if (getWeightDt.Rows.Count > 0) { R_Sub_Weight = getWeightDt.Rows[0]["R_Sub_Weight"].ToString(); }

                string addEvaluationQuary =
                "Insert Into tenant_evaluation (" +
                "Tenant_Id," +
                "Main_Type_Id," +
                "Weight," +
                "Sup_Type_Id , Date) " +
                "VALUES(" +
                "@Tenant_Id," +
                "@Main_Type_Id," +
                "@Weight," +
                "@Sup_Type_Id , @Date)";
                MySqlCommand addEvaluationCmd = new MySqlCommand(addEvaluationQuary, _sqlCon);
                addEvaluationCmd.Parameters.AddWithValue("@Tenant_Id", Tenant_ID.Text);
                addEvaluationCmd.Parameters.AddWithValue("@Main_Type_Id", "1");
                addEvaluationCmd.Parameters.AddWithValue("@Sup_Type_Id", "2");
                addEvaluationCmd.Parameters.AddWithValue("@Weight", R_Sub_Weight);
                addEvaluationCmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("dd/MM/yyyy"));
                addEvaluationCmd.ExecuteNonQuery();
                _sqlCon.Close();
            }
            else if (Cheuqe_Status_DropDownList.SelectedValue == "6")
            {
                string R_Sub_Weight = "";
                DataTable getTenantDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getTenantCmd = new MySqlCommand("SELECT Tenants_Mobile FROM tenants WHERE Tenants_ID = '" + Tenant_ID.Text + "'", _sqlCon);
                MySqlDataAdapter getTenantDa = new MySqlDataAdapter(getTenantCmd);
                getTenantDa.Fill(getTenantDt);
                if (getTenantDt.Rows.Count > 0)
                {
                    string Tenants_Mobile = getTenantDt.Rows[0]["Tenants_Mobile"].ToString();
                    string Sms = "  شركة المنارة : عزيزي المستأجر تم إرجاع الشيك ذو الرقم" + txt_Cheuqe_NO.Text + " من قبل البنك يرجى متابعة الأمر";
                    Utilities.Helper.SendSms(Tenants_Mobile, Sms);
                    //*************************************** Add Tenant Evaluation  ******************************************************************

                    DataTable getWeightDt = new DataTable();
                    MySqlCommand getWeightCmd = new MySqlCommand("SELECT R_Sub_Weight  FROM sub_type_evaluation WHERE Sub_Type_Evaluation_Id = @ID", _sqlCon);
                    MySqlDataAdapter getWeightDa = new MySqlDataAdapter(getWeightCmd);
                    getWeightCmd.Parameters.AddWithValue("@ID", "1");
                    getWeightDa.Fill(getWeightDt);
                    if (getWeightDt.Rows.Count > 0) { R_Sub_Weight = getWeightDt.Rows[0]["R_Sub_Weight"].ToString(); }

                    string addEvaluationQuary =
                    "Insert Into tenant_evaluation (" +
                    "Tenant_Id," +
                    "Main_Type_Id," +
                    "Weight," +
                    "Sup_Type_Id , Date) " +
                    "VALUES(" +
                    "@Tenant_Id," +
                    "@Main_Type_Id," +
                    "@Weight," +
                    "@Sup_Type_Id , @Date)";
                    MySqlCommand addEvaluationCmd = new MySqlCommand(addEvaluationQuary, _sqlCon);
                    addEvaluationCmd.Parameters.AddWithValue("@Tenant_Id", Tenant_ID.Text);
                    addEvaluationCmd.Parameters.AddWithValue("@Main_Type_Id", "1");
                    addEvaluationCmd.Parameters.AddWithValue("@Sup_Type_Id", "1");
                    addEvaluationCmd.Parameters.AddWithValue("@Weight", R_Sub_Weight);
                    addEvaluationCmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("dd/MM/yyyy"));
                    addEvaluationCmd.ExecuteNonQuery();
                }
                _sqlCon.Close();
            }
            else
            {
                string Quary = "Select Collection From collection_table Where " +
                              "Ownersip_Id='" + O_ID.Text + "' And Building_Id='" + B_ID.Text + "'  " +
                              "And Mounth='" + Month.Text + "' And Year='" + Year.Text + "'";
                MySqlDataAdapter CollectionSda = new MySqlDataAdapter(Quary, _sqlCon);
                DataTable getCollectionDt = new DataTable();
                CollectionSda.Fill(getCollectionDt);
                if (getCollectionDt.Rows.Count > 0)
                {
                    _sqlCon.Open();
                    string deleteCollectionQuary = "DELETE FROM collection_table WHERE " +
                                                   "Ownersip_Id='" + O_ID.Text + "' And Building_Id='" + B_ID.Text + "'  " +
                                                   "And Mounth='" + Month.Text + "' And Year='" + Year.Text + "'";
                    MySqlCommand mySqlCmd = new MySqlCommand(deleteCollectionQuary, _sqlCon);
                    mySqlCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
            }



            string ChueqeId = Request.QueryString["Id"];
            string query = "UPDATE building_cheques SET " +
                "Cheques_Status = @Cheques_Status , " +
                "Cheques_Date = @Cheques_Date , " +
                "Collection_Date=@Collection_Date  ," +
                "Collect_Type=@Collect_Type " +
                "WHERE Cheques_Id = @Cheques_Id";

            using (MySqlCommand cmd = new MySqlCommand(query, _sqlCon))
            {
                cmd.Parameters.AddWithValue("@Cheques_Id", ChueqeId);
                cmd.Parameters.AddWithValue("@Cheques_Status", Cheuqe_Status_DropDownList.SelectedItem.Text.Trim());
                cmd.Parameters.AddWithValue("@Cheques_Date", txt_Cheuqe_Date.Text);

                if (Cheuqe_Status_DropDownList.SelectedValue != "3")
                { cmd.Parameters.AddWithValue("@Collection_Date", ""); }
                else
                { cmd.Parameters.AddWithValue("@Collection_Date", txt_Collect_Date.Text); }

                if (Cheuqe_Status_DropDownList.SelectedValue == "3") { cmd.Parameters.AddWithValue("@Collect_Type", Collect_Type_DropDownList.SelectedItem.Text.Trim()); }
                else { cmd.Parameters.AddWithValue("@Collect_Type", ""); }
                _sqlCon.Open(); cmd.ExecuteNonQuery();
            }

            Response.Redirect("Income_New.aspx");
        }

        //******************  Collect_Function ***************************************************
        protected void btn_Back_Click(object sender, EventArgs e)
        {
            string Cq_T_Ca = Request.QueryString["Cq_T_Ca"];
            string Collection = Request.QueryString["Collection"];
            string Singel_Multi = Request.QueryString["Singel_Multi"];
            Response.Redirect("Income_New.aspx?Cq_T_Ca=" + Cq_T_Ca + "&Collection=" + Collection + "&Singel_Multi=" + Singel_Multi);
        }
    }
}