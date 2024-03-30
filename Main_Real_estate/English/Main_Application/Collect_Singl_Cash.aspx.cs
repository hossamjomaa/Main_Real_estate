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
    public partial class Collect_Singl_Cash : System.Web.UI.Page
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
                Singl_Cash();
            }
        }
        protected void Singl_Cash()
        {
            string CashId = Request.QueryString["Id"];
            string getSingl_CashQuari = "select Ch_tb.*,   " +
                " T.Tenants_Arabic_Name , " +
                "T.Tenants_ID, " +
                "(select units_Unit_ID from contract where Contract_Id = Ch_tb.Contract_Id )U_ID , " +
                " (select building_Building_Id from units where Unit_ID=U_ID ) B_ID, " +
                " (select owner_ship_Owner_Ship_Id from building where Building_Id=B_ID ) O_ID, " +
                " (select Unit_Number from units where Unit_ID=U_ID)U_NO, " +
                "(select Building_Arabic_Name from building where Building_Id=B_ID)B_Name, " +
                "(select Owner_Ship_AR_Name  from owner_ship where Owner_Ship_Id=O_ID)O_Name , " +
                "(select  owner_ship_Code from owner_ship where Owner_Ship_Id=O_ID)O_Code " +
                "FROM  cash_amount Ch_tb left join  tenants T on (Ch_tb.tenant_Id = T.Tenants_ID) where Cash_Amount_ID = '" + CashId + "'";




            MySqlCommand getSingl_CashCmd = new MySqlCommand(getSingl_CashQuari, _sqlCon);
            MySqlDataAdapter getSingl_CashDt = new MySqlDataAdapter(getSingl_CashCmd);
            getSingl_CashCmd.Connection = _sqlCon;
            _sqlCon.Open();
            getSingl_CashDt.SelectCommand = getSingl_CashCmd;
            DataTable getSingl_CashDataTable = new DataTable();
            getSingl_CashDt.Fill(getSingl_CashDataTable);
            if (getSingl_CashDataTable.Rows.Count > 0)
            {
                O_ID.Text = getSingl_CashDataTable.Rows[0]["O_ID"].ToString();
                B_ID.Text = getSingl_CashDataTable.Rows[0]["B_ID"].ToString();
                U_ID.Text = getSingl_CashDataTable.Rows[0]["U_NO"].ToString();
                Tenant_ID.Text = getSingl_CashDataTable.Rows[0]["Tenants_ID"].ToString();
                Month.Text = Convert.ToString(Convert.ToDateTime(getSingl_CashDataTable.Rows[0]["Cash_Date"].ToString()).Month);
                Year.Text = Convert.ToString(Convert.ToDateTime(getSingl_CashDataTable.Rows[0]["Cash_Date"].ToString()).Year);




                txt_Cash_Date.Text = getSingl_CashDataTable.Rows[0]["Cash_Date"].ToString();
                txt_Cash_Amount.Text = getSingl_CashDataTable.Rows[0]["Cash_Amount"].ToString();
                txt_Collect_Date.Text = getSingl_CashDataTable.Rows[0]["Collection_Date"].ToString();
                Collect_Type_DropDownList.Items.FindByText(getSingl_CashDataTable.Rows[0]["Satuts"].ToString()).Selected = true;

            }
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

        protected void btn_Sumit_Collect_Click(object sender, EventArgs e)
        {
            // Record The Income In Collection Talble
            if (Collect_Type_DropDownList.SelectedValue == "2")
            {
                string Quary = "Select Collection From collection_table Where " +
                               "Ownersip_Id='" + O_ID.Text + "' And Building_Id='" + B_ID.Text + "' And Unit_Id='" + U_ID.Text + "' " +
                               "And Mounth='" + Month.Text + "' And Year='" + Year.Text + "'";
                MySqlDataAdapter CollectionSda = new MySqlDataAdapter(Quary, _sqlCon);
                DataTable getCollectionDt = new DataTable();
                CollectionSda.Fill(getCollectionDt);
                if (getCollectionDt.Rows.Count > 0)
                {
                    string UPDATECollectionQuary = "UPDATE collection_table SET " +
                                                   " Collection = @Collection Where " +
                                                   "Ownersip_Id='" + O_ID.Text + "' And Building_Id='" + B_ID.Text + "' And Unit_Id='" + U_ID.Text + "' " +
                                                   "And Mounth='" + Month.Text + "' And Year='" + Year.Text + "'";

                    _sqlCon.Open();
                    MySqlCommand UPDATECollectionCmd = new MySqlCommand(UPDATECollectionQuary, _sqlCon);
                    UPDATECollectionCmd.Parameters.AddWithValue("@Collection", txt_Cash_Amount.Text);
                    UPDATECollectionCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                else
                {
                    string AddCollectionQuary = "Insert Into collection_table" +
                                           " (Ownersip_Id,Building_Id,Unit_Id,Mounth,Year,Collection) " +
                                           "VALUES" +
                                           "(@Ownersip_Id,@Building_Id,@Unit_Id,@Mounth,@Year,@Collection)";
                    _sqlCon.Open();
                    MySqlCommand addCollectionCmd = new MySqlCommand(AddCollectionQuary, _sqlCon);
                    addCollectionCmd.Parameters.AddWithValue("@Ownersip_Id", O_ID.Text);
                    addCollectionCmd.Parameters.AddWithValue("@Building_Id", B_ID.Text);
                    addCollectionCmd.Parameters.AddWithValue("@Unit_Id", U_ID.Text);
                    addCollectionCmd.Parameters.AddWithValue("@Mounth", Month.Text);
                    addCollectionCmd.Parameters.AddWithValue("@Year", Year.Text);
                    addCollectionCmd.Parameters.AddWithValue("@Collection", txt_Cash_Amount.Text);
                    addCollectionCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                _sqlCon.Close();
            }

            else
            {
                string Quary = "Select Collection From collection_table Where " +
                               "Ownersip_Id='" + O_ID.Text + "' And Building_Id='" + B_ID.Text + "' and Unit_Id = '" + U_ID.Text + "' " +
                               "And Mounth='" + Month.Text + "' And Year='" + Year.Text + "'";
                MySqlDataAdapter CollectionSda = new MySqlDataAdapter(Quary, _sqlCon);
                DataTable getCollectionDt = new DataTable();
                CollectionSda.Fill(getCollectionDt);
                if (getCollectionDt.Rows.Count > 0)
                {
                    string UPDATECollectionQuary = "UPDATE collection_table SET " +
                                                   " Collection = @Collection Where " +
                                                   "Ownersip_Id='" + O_ID.Text + "' And Building_Id='" + B_ID.Text + "' and Unit_Id = '" + U_ID.Text + "' " +
                                                   "And Mounth='" + Month.Text + "' And Year='" + Year.Text + "'";

                    _sqlCon.Open();
                    MySqlCommand UPDATECollectionCmd = new MySqlCommand(UPDATECollectionQuary, _sqlCon);
                    UPDATECollectionCmd.Parameters.AddWithValue("@Collection", "");
                    UPDATECollectionCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
            }

            string CashId = Request.QueryString["Id"];
            string query = "UPDATE cash_amount" +
                           " SET " +
                           "Satuts = @Satuts , " +
                           "Collection_Date=@Collection_Date" +
                           " WHERE Cash_Amount_ID = @Cash_Amount_ID";
            using (MySqlCommand cmd = new MySqlCommand(query, _sqlCon))
            {
                cmd.Parameters.AddWithValue("@Cash_Amount_ID", CashId);
                cmd.Parameters.AddWithValue("@Satuts", Collect_Type_DropDownList.SelectedItem.Text.Trim());



                //if (CollectionDate_Calendar != "01/01/0001") { cmd.Parameters.AddWithValue("@Collection_Date", CollectionDate_Calendar); }
                //else { cmd.Parameters.AddWithValue("@Collection_Date", lbl_Collection_Date.Text); }



                if (Collect_Type_DropDownList.SelectedValue == "1")
                {
                    cmd.Parameters.AddWithValue("@Collection_Date", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Collection_Date", txt_Collect_Date.Text);
                }

                _sqlCon.Open(); cmd.ExecuteNonQuery();
            }
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            string Cq_T_Ca = Request.QueryString["Cq_T_Ca"];
            string Collection = Request.QueryString["Collection"];
            string Singel_Multi = Request.QueryString["Singel_Multi"];
            Response.Redirect("Income_New.aspx?Cq_T_Ca=" + Cq_T_Ca + "&Collection=" + Collection + "&Singel_Multi=" + Singel_Multi);
        }
    }
}