using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using Syncfusion.JavaScript;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class New_Rental_Disclosure : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Contracting", 0, "R");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!IsPostBack)
            {
                //Get Ownershi_Code_DropDownList
                Helper.LoadDropDownList("SELECT * FROM owner_ship where Active!='1'", _sqlCon, Ownershi_Code_DropDownList, "owner_ship_Code", "Owner_Ship_Id");
                Ownershi_Code_DropDownList.Items.Insert(0, "..... الكل .....");

                //Get Ownershi_Name_DropDownList
                Helper.LoadDropDownList("SELECT * FROM owner_ship where Active!='1'", _sqlCon, Ownershi_Name_DropDownList, "Owner_Ship_AR_Name", "Owner_Ship_Id");
                Ownershi_Name_DropDownList.Items.Insert(0, "..... الكل .....");

                //Get Ownershi_Name_DropDownList
                Helper.LoadDropDownList("SELECT * FROM zone", _sqlCon, Zone_N_DropDownList, "zone_arabic_name", "zone_Id");
                Zone_N_DropDownList.Items.Insert(0, "..... الكل .....");

                



                OWnership_Repeater_DataBinder();
                Building_Repeater_DataBinder();
                Body_Repeater_DataBinder();
                //------------------------------------------------
                B_OWnership_Repeater_DataBinder();
                B_Building_Repeater_DataBinder();
                B_Body_Repeater_DataBinder();
            }
               
        }


        //--------------------------- Unit Rental_Disclosure DataBinder ------------
        protected void OWnership_Repeater_DataBinder()
        {
            string Where = " ";
            if (Ownershi_Name_DropDownList.SelectedItem.Text == "..... الكل .....")
            {
                Where = " ";
            }
            else
            {
                Where = "and O.Owner_Ship_Id = '" + Ownershi_Name_DropDownList.SelectedValue + "' ";
            }


            string Zone = " ";
            if (Zone_N_DropDownList.SelectedItem.Text == "..... الكل .....")
            {
                Zone = " ";
            }
            else
            {
                Zone = "and Z.zone_Id = '" + Zone_N_DropDownList.SelectedValue + "' ";
            }

            //string Where = "and O.Owner_Ship_Id = '2'";
            string Header_Repeater_Quari = "SELECT  " +
                                    "B.Building_Id , B.Building_NO, B.Building_Arabic_Name, B.Half_Building_ID , " +
                                    "O.Street_NO , O.Street_Name , Z.zone_number , Z.zone_Id , O.Owner_Ship_Id , O.Owner_Ship_AR_Name , O.owner_ship_Code, ONR.Owner_Arabic_name FROM contract C " +
                                    "left join units U on(C.units_Unit_ID = U.Unit_Id) " +
                                    " left join building B on(U.building_Building_Id = B.building_Id) " +
                                    " left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                                    "left join zone Z on(O.zone_zone_Id = Z.zone_Id) " +
                                    "left join owner ONR on(O.owner_Owner_Id = ONR.Owner_Id) " +
                                    "where C.Contract_Id >'0' " + Where + " "+ Zone + " " +
                                    " GROUP BY O.Owner_Ship_Id; ";
            MySqlCommand get_Header_Repeater_Cmd = new MySqlCommand(Header_Repeater_Quari, _sqlCon);
            MySqlDataAdapter get_Header_Repeater_Dt = new MySqlDataAdapter(get_Header_Repeater_Cmd);
            get_Header_Repeater_Cmd.Connection = _sqlCon;
            _sqlCon.Open();
            get_Header_Repeater_Dt.SelectCommand = get_Header_Repeater_Cmd;
            DataTable get_Header_Repeater_DataTable = new DataTable();
            get_Header_Repeater_Dt.Fill(get_Header_Repeater_DataTable);
            OWnershi_Repeater.DataSource = get_Header_Repeater_DataTable;
            OWnershi_Repeater.DataBind();
            _sqlCon.Close();

        }
        protected void Building_Repeater_DataBinder()
        {
            foreach (RepeaterItem item in OWnershi_Repeater.Items)
            {
                Repeater Buildingg_Repeater = item.FindControl("Buildingg_Repeater") as Repeater;
                Label lbl_Ownersihp_Id = item.FindControl("lbl_Ownersihp_Id") as Label;
                string Building_Repeater_Quari = "SELECT   " +
                    "B.Building_NO , B.Half_Building_ID  FROM contract C  " +
                    "left join units U on(C.units_Unit_ID = U.Unit_Id) " +
                    "left join building B on(U.building_Building_Id = B.building_Id)  " +
                    "left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id)  " +
                    "where   O.Owner_Ship_Id = '" + lbl_Ownersihp_Id.Text+ "' " +
                    "GROUP BY B.Half_Building_ID;";
                MySqlCommand get_Building_Repeater_Cmd = new MySqlCommand(Building_Repeater_Quari, _sqlCon);
                MySqlDataAdapter get_Building_Repeater_Dt = new MySqlDataAdapter(get_Building_Repeater_Cmd);
                get_Building_Repeater_Cmd.Connection = _sqlCon;
                _sqlCon.Open();
                get_Building_Repeater_Dt.SelectCommand = get_Building_Repeater_Cmd;
                DataTable get_Building_Repeater_DataTable = new DataTable();
                get_Building_Repeater_Dt.Fill(get_Building_Repeater_DataTable);
                Buildingg_Repeater.DataSource = get_Building_Repeater_DataTable;
                Buildingg_Repeater.DataBind();
                _sqlCon.Close();
            }
        }
        protected void Body_Repeater_DataBinder()
        {
            foreach (RepeaterItem item in OWnershi_Repeater.Items)
            {
                Repeater Buildingg_Repeater = item.FindControl("Buildingg_Repeater") as Repeater;
                Label lbl_Ownersihp_Id = item.FindControl("lbl_Ownersihp_Id") as Label;
                foreach (RepeaterItem itm in Buildingg_Repeater.Items)
                {
                    Repeater Unit_Repeater = itm.FindControl("Unit_Repeater") as Repeater;
                    Label lbl_Building_Id = itm.FindControl("lbl_Building_Id") as Label;
                    string get_Body_Repeater_Quari = "SELECT  " +
                                           "C.* ,   " +
                                           "T.Tenants_Arabic_Name , T.tenant_type_Tenant_Type_Id ,   T.ID_NO , T.Tenants_Mobile , T.tenant_type_Tenant_Type_Id , T.business_records , T.P_O_Box  , TN.Arabic_nationality , " +
                                           " U.Unit_Number , U.Electricityt_Number , U.Water_Number ,  UT.Unit_Arabic_Type ,UD.Unit_Arabic_Detail, U.furniture_case_Furniture_case_Id, UC.Unit_Arabic_Condition , " +
                                           " B.Building_NO, B.Building_Arabic_Name, B.Building_Id , " +
                                           " O.Street_NO , O.Street_Name , Z.zone_number , O.Owner_Ship_AR_Name , O.owner_ship_Code, O.Owner_Ship_Id , ONR.Owner_Arabic_name, " +
                                           " CT.Contract_Arabic_Type, " +
                                           " FC.Furniture_Ar_case, " +
                                           "PT.payment_Arabic_type " +
                                           "FROM contract C " +
                                           "left join tenants T on(C.tenants_Tenants_ID = T.Tenants_Id) " +
                                           "left join nationality TN on(T.nationality_nationality_ID = TN.nationality_ID) " +
                                           " left join units U on(C.units_Unit_ID = U.Unit_Id) " +
                                           "left join unit_type UT on(U.unit_type_Unit_Type_Id = UT.Unit_Type_Id) " +
                                           "left join unit_detail UD on(U.unit_detail_Unit_Detail_Id = UD.Unit_Detail_Id) " +
                                           "left join unit_condition UC on(U.unit_condition_Unit_Condition_Id = UC.Unit_Condition_Id) " +
                                           "left join building B on(U.building_Building_Id = B.building_Id) " +
                                           "left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                                           "left join zone Z on(O.zone_zone_Id = Z.zone_Id) " +
                                           "left join owner ONR on(O.owner_Owner_Id = ONR.Owner_Id) " +
                                           "left join contract_type CT on(C.contract_type_Contract_Type_Id = CT.Contract_Type_Id) " +
                                           " left join furniture_case FC on(U.furniture_case_Furniture_case_Id = FC.Furniture_case_Id) " +
                                           "left join payment_type PT on(C.payment_type_payment_type_Id = PT.payment_type_Id) " +
                                           " where    B.Building_Id = '" + lbl_Building_Id.Text + "'  order by U.Unit_Number; ";
                    MySqlCommand get_Body_Repeater_Cmd = new MySqlCommand(get_Body_Repeater_Quari, _sqlCon);
                    MySqlDataAdapter get_Body_Repeater_Dt = new MySqlDataAdapter(get_Body_Repeater_Cmd);
                    get_Body_Repeater_Cmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    get_Body_Repeater_Dt.SelectCommand = get_Body_Repeater_Cmd;
                    DataTable get_Body_Repeater_DataTable = new DataTable();
                    get_Body_Repeater_Dt.Fill(get_Body_Repeater_DataTable);
                    Unit_Repeater.DataSource = get_Body_Repeater_DataTable;
                    Unit_Repeater.DataBind();
                    _sqlCon.Close();

                }

            }
        }

        //---------------------------Building Rental_Disclosure DataBinder ------------
        protected void B_OWnership_Repeater_DataBinder()
        {
            string Where = " ";
            if (Ownershi_Name_DropDownList.SelectedItem.Text == "..... الكل .....")
            {
                Where = " ";
            }
            else
            {
                Where = "and O.Owner_Ship_Id = '" + Ownershi_Name_DropDownList.SelectedValue + "' ";
            }


            string Zone = " ";
            if (Zone_N_DropDownList.SelectedItem.Text == "..... الكل .....")
            {
                Zone = " ";
            }
            else
            {
                Zone = "and Z.zone_Id = '" + Zone_N_DropDownList.SelectedValue + "' ";
            }


            string Header_Repeater_Quari = "SELECT  " +
                                    "B.Building_Id , B.Building_NO, B.Building_Arabic_Name, B.Half_Building_ID , " +
                                    "O.Street_NO , O.Street_Name , Z.zone_number , O.Owner_Ship_Id , O.Owner_Ship_AR_Name , O.owner_ship_Code, " +
                                    "ONR.Owner_Arabic_name " +
                                    "FROM building_contract C " +
                                    " left join building B on(C.building_Building_Id = B.building_Id) " +
                                    " left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                                    "left join zone Z on(O.zone_zone_Id = Z.zone_Id) " +
                                    "left join owner ONR on(O.owner_Owner_Id = ONR.Owner_Id)   " +
                                    "where C.Contract_Id >'0' " + Where + " " + Zone + " " +
                                    " GROUP BY O.Owner_Ship_Id; ";
            MySqlCommand get_Header_Repeater_Cmd = new MySqlCommand(Header_Repeater_Quari, _sqlCon);
            MySqlDataAdapter get_Header_Repeater_Dt = new MySqlDataAdapter(get_Header_Repeater_Cmd);
            get_Header_Repeater_Cmd.Connection = _sqlCon;
            _sqlCon.Open();
            get_Header_Repeater_Dt.SelectCommand = get_Header_Repeater_Cmd;
            DataTable get_Header_Repeater_DataTable = new DataTable();
            get_Header_Repeater_Dt.Fill(get_Header_Repeater_DataTable);
            B_Ownership_repeater.DataSource = get_Header_Repeater_DataTable;
            B_Ownership_repeater.DataBind();
            _sqlCon.Close();

        }
        protected void B_Building_Repeater_DataBinder()
        {
            foreach (RepeaterItem item in B_Ownership_repeater.Items)
            {
                Repeater Buildingg_Repeater = item.FindControl("Buildingg_Repeater") as Repeater;
                Label lbl_Ownersihp_Id = item.FindControl("lbl_Ownersihp_Id") as Label;
                string Building_Repeater_Quari = "SELECT   " +
                    "B.Building_NO , B.Half_Building_ID  FROM building_contract C  " +
                    "left join building B on(C.building_Building_Id = B.building_Id)  " +
                    "left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id)  " +
                    "where  O.Owner_Ship_Id = '" + lbl_Ownersihp_Id.Text + "' " +
                    "GROUP BY B.Half_Building_ID;";
                MySqlCommand get_Building_Repeater_Cmd = new MySqlCommand(Building_Repeater_Quari, _sqlCon);
                MySqlDataAdapter get_Building_Repeater_Dt = new MySqlDataAdapter(get_Building_Repeater_Cmd);
                get_Building_Repeater_Cmd.Connection = _sqlCon;
                _sqlCon.Open();
                get_Building_Repeater_Dt.SelectCommand = get_Building_Repeater_Cmd;
                DataTable get_Building_Repeater_DataTable = new DataTable();
                get_Building_Repeater_Dt.Fill(get_Building_Repeater_DataTable);
                Buildingg_Repeater.DataSource = get_Building_Repeater_DataTable;
                Buildingg_Repeater.DataBind();
                _sqlCon.Close();
            }
        }
        protected void B_Body_Repeater_DataBinder()
        {
            foreach (RepeaterItem item in B_Ownership_repeater.Items)
            {
                Repeater Buildingg_Repeater = item.FindControl("Buildingg_Repeater") as Repeater;
                Label lbl_Ownersihp_Id = item.FindControl("lbl_Ownersihp_Id") as Label;
                foreach (RepeaterItem itm in Buildingg_Repeater.Items)
                {
                    Repeater Unit_Repeater = itm.FindControl("Unit_Repeater") as Repeater;
                    Label lbl_Building_Id = itm.FindControl("lbl_Building_Id") as Label;
                    string get_Body_Repeater_Quari = "SELECT C.* ,  " +
                        " T.Tenants_Arabic_Name , T.tenant_type_Tenant_Type_Id ,   T.ID_NO , T.Tenants_Mobile , T.tenant_type_Tenant_Type_Id , T.business_records , T.P_O_Box  , TN.Arabic_nationality ,   " +
                        " U.Unit_Number , U.Electricityt_Number , U.Water_Number ,  UT.Unit_Arabic_Type ,UD.Unit_Arabic_Detail, U.furniture_case_Furniture_case_Id, UC.Unit_Arabic_Condition ,   " +
                        " B.Building_NO, B.Building_Arabic_Name, B.Building_Id ,   " +
                        " O.Street_NO , O.Street_Name , Z.zone_number , O.Owner_Ship_AR_Name , O.owner_ship_Code, O.Owner_Ship_Id , ONR.Owner_Arabic_name, " +
                        " CT.Contract_Arabic_Type,   " +
                        " FC.Furniture_Ar_case,   " +
                        " PT.payment_Arabic_type   " +
                        "FROM building_contract C  " +
                        "left join tenants T on(C.tenants_Tenants_ID = T.Tenants_Id)  " +
                        "left join nationality TN on(T.nationality_nationality_ID = TN.nationality_ID)    " +
                        "left join building B on(C.building_Building_Id = B.building_Id) " +
                        "left join units U on(U.building_Building_Id = B.Building_Id) " +
                        "left join unit_type UT on(U.unit_type_Unit_Type_Id = UT.Unit_Type_Id)  " +
                        "left join unit_detail UD on(U.unit_detail_Unit_Detail_Id = UD.Unit_Detail_Id) " +
                        "left join unit_condition UC on(U.unit_condition_Unit_Condition_Id = UC.Unit_Condition_Id) " +
                        "left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                        "left join zone Z on(O.zone_zone_Id = Z.zone_Id) " +
                        "left join owner ONR on(O.owner_Owner_Id = ONR.Owner_Id) " +
                        "left join contract_type CT on(C.contract_type_Contract_Type_Id = CT.Contract_Type_Id) " +
                        "left join furniture_case FC on(U.furniture_case_Furniture_case_Id = FC.Furniture_case_Id) " +
                        "left join payment_type PT on(C.payment_type_payment_type_Id = PT.payment_type_Id) " +
                        "where   B.Half_Building_ID = '" + lbl_Building_Id.Text + "' order by U.Unit_Number; ; ";


                    MySqlCommand get_Body_Repeater_Cmd = new MySqlCommand(get_Body_Repeater_Quari, _sqlCon);
                    MySqlDataAdapter get_Body_Repeater_Dt = new MySqlDataAdapter(get_Body_Repeater_Cmd);
                    get_Body_Repeater_Cmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    get_Body_Repeater_Dt.SelectCommand = get_Body_Repeater_Cmd;
                    DataTable get_Body_Repeater_DataTable = new DataTable();
                    get_Body_Repeater_Dt.Fill(get_Body_Repeater_DataTable);
                    Unit_Repeater.DataSource = get_Body_Repeater_DataTable;
                    Unit_Repeater.DataBind();
                    _sqlCon.Close();

                }

            }
        }

        //----------------------------------- Export To Excel ------------------------
        protected void Rental_All_Excel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=كشف المؤجرات .xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            B_Ownership_repeater.RenderControl(hw);
            OWnershi_Repeater.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=كشف المؤجرات المجملة.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            B_Ownership_repeater.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=كشف المؤجرات المفردة.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            OWnershi_Repeater.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        //-------------------------------- Filltering UL -----------------------------------
        protected void A_1_ServerClick(object sender, EventArgs e)
        {
            Unit_Contract_Div.Visible = true; Building_Contract_Div.Visible = false;
            lbl_titelt.Text = "كشف مؤجرات العقود المفردة";
            Rental_All_Excel.Visible= false;
            Rental_Unit_Excel.Visible = true;
            Rental_Building_Excel.Visible = false;
        }
        protected void A_2_ServerClick(object sender, EventArgs e)
        {
            Unit_Contract_Div.Visible = false; Building_Contract_Div.Visible = true;
            lbl_titelt.Text = "كشف مؤجرات العقود المجملة";
            Rental_All_Excel.Visible = false;
            Rental_Unit_Excel.Visible = false;
            Rental_Building_Excel.Visible = true;
        }
        protected void A_3_ServerClick(object sender, EventArgs e)
        {
            Unit_Contract_Div.Visible = true; Building_Contract_Div.Visible = true;
            lbl_titelt.Text = "كشف مؤجرات كافة العقود";
            Rental_All_Excel.Visible = true;
            Rental_Unit_Excel.Visible = false;
            Rental_Building_Excel.Visible = false;
        }

        //----------------------------------- Filltering DropDownList ------------------------
        protected void Ownershi_Code_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            string zoneId = Request.QueryString["Id"];
            DataTable getZoneDt = new DataTable();
            _sqlCon.Open();
            MySqlCommand getZoneCmd = new MySqlCommand("SELECT zone_zone_Id FROM owner_ship WHERE Owner_Ship_Id = '" + Ownershi_Code_DropDownList.SelectedValue + "'", _sqlCon);
            MySqlDataAdapter getZoneDa = new MySqlDataAdapter(getZoneCmd);
            getZoneCmd.Parameters.AddWithValue("@ID", zoneId);
            getZoneDa.Fill(getZoneDt);
            if (getZoneDt.Rows.Count > 0)
            {
                Zone_N_DropDownList.SelectedValue = getZoneDt.Rows[0]["zone_zone_Id"].ToString();
            }
            _sqlCon.Close();

            Ownershi_Name_DropDownList.SelectedValue = Ownershi_Code_DropDownList.SelectedValue;

            OWnership_Repeater_DataBinder();
            Building_Repeater_DataBinder();
            Body_Repeater_DataBinder();
            //------------------------------------------------
            B_OWnership_Repeater_DataBinder();
            B_Building_Repeater_DataBinder();
            B_Body_Repeater_DataBinder();

        }
        protected void Ownershi_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string zoneId = Request.QueryString["Id"];
            DataTable getZoneDt = new DataTable();
            _sqlCon.Open();
            MySqlCommand getZoneCmd = new MySqlCommand("SELECT zone_zone_Id FROM owner_ship WHERE Owner_Ship_Id = '" + Ownershi_Name_DropDownList.SelectedValue + "'", _sqlCon);
            MySqlDataAdapter getZoneDa = new MySqlDataAdapter(getZoneCmd);
            getZoneCmd.Parameters.AddWithValue("@ID", zoneId);
            getZoneDa.Fill(getZoneDt);
            if (getZoneDt.Rows.Count > 0)
            {
                Zone_N_DropDownList.SelectedValue = getZoneDt.Rows[0]["zone_zone_Id"].ToString();
            }
            _sqlCon.Close();

            Ownershi_Code_DropDownList.SelectedValue = Ownershi_Name_DropDownList.SelectedValue;

            OWnership_Repeater_DataBinder();
            Building_Repeater_DataBinder();
            Body_Repeater_DataBinder();
            //------------------------------------------------
            B_OWnership_Repeater_DataBinder();
            B_Building_Repeater_DataBinder();
            B_Body_Repeater_DataBinder();
        }
        protected void Zone_N_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get Ownershi_Code_DropDownList
            Helper.LoadDropDownList("SELECT * FROM owner_ship where Active!='1' and zone_zone_Id = '" + Zone_N_DropDownList.SelectedValue + "'", _sqlCon, Ownershi_Code_DropDownList, "owner_ship_Code", "Owner_Ship_Id");
            Ownershi_Code_DropDownList.Items.Insert(0, "..... الكل .....");

            //Get Ownershi_Name_DropDownList
            Helper.LoadDropDownList("SELECT * FROM owner_ship where Active!='1' and zone_zone_Id = '" + Zone_N_DropDownList.SelectedValue + "'", _sqlCon, Ownershi_Name_DropDownList, "Owner_Ship_AR_Name", "Owner_Ship_Id");
            Ownershi_Name_DropDownList.Items.Insert(0, "..... الكل .....");

            OWnership_Repeater_DataBinder();
            Building_Repeater_DataBinder();
            Body_Repeater_DataBinder();
            //------------------------------------------------
            B_OWnership_Repeater_DataBinder();
            B_Building_Repeater_DataBinder();
            B_Body_Repeater_DataBinder();
        }
    }
}