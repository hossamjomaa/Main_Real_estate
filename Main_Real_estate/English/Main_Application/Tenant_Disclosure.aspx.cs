using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Tenant_Disclosure : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Customer_Affairs", 0, "R");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!this.IsPostBack)
            {
                //Fill Tenant Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM tenants", _sqlCon, Tenant_Name_DropDownList, "Tenants_Arabic_Name", "Tenants_ID");
                Tenant_Name_DropDownList.Items.Insert(0, "..... الكل .....");

                Header_Repeater_DataBinder();
                Body_Repeater_DataBinder();
                //*************** العقود المجملة ***************
                B_Header_Repeater_DataBinder();
                B_Body_Repeater_DataBinder();
            }
                
        }
        //--------------------------- Unit Tenant Rental Disclosure DataBinder ------------
        protected void Header_Repeater_DataBinder()
        {
            string Where = "";
            if (Tenant_Name_DropDownList.SelectedItem.Text == "..... الكل ....."){Where = " ";} else {Where = " and C.tenants_Tenants_ID = '" + Tenant_Name_DropDownList.SelectedValue + "' "; }

            string Header_Repeater_Quari =  "select  C.tenants_Tenants_ID , C.Contract_Id ,  " +
                                            "T.Tenants_Arabic_Name , T.Tenants_Mobile ,TN.Arabic_nationality " +
                                            "from contract C " +
                                            "left join tenants T on(C.tenants_Tenants_ID = T.Tenants_ID) " +
                                            "left join nationality TN on(T.nationality_nationality_ID = TN.nationality_ID) " +
                                            "where C.Contract_Id > '0' " + Where + "" +
                                            " GROUP BY C.tenants_Tenants_ID  ; ";
            MySqlCommand get_Header_Repeater_Cmd = new MySqlCommand(Header_Repeater_Quari, _sqlCon);
            MySqlDataAdapter get_Header_Repeater_Dt = new MySqlDataAdapter(get_Header_Repeater_Cmd);
            get_Header_Repeater_Cmd.Connection = _sqlCon;
            _sqlCon.Open();
            get_Header_Repeater_Dt.SelectCommand = get_Header_Repeater_Cmd;
            DataTable get_Header_Repeater_DataTable = new DataTable();
            get_Header_Repeater_Dt.Fill(get_Header_Repeater_DataTable);
            Header_Repeater.DataSource = get_Header_Repeater_DataTable;
            Header_Repeater.DataBind();
            _sqlCon.Close();
        }
        protected void Body_Repeater_DataBinder()
        {
            foreach (RepeaterItem item in Header_Repeater.Items)
            {
                Repeater Body_Repeater = item.FindControl("Body_Repeater") as Repeater;
                Label lbl_tenants_Tenants_ID = item.FindControl("lbl_tenants_Tenants_ID") as Label;


                string get_Body_Repeater_Quari = "SELECT  " +
                                           "C.* ,   " +
                                           " U.Unit_Number , U.Electricityt_Number , U.Water_Number ,  UT.Unit_Arabic_Type ,UD.Unit_Arabic_Detail, U.furniture_case_Furniture_case_Id, UC.Unit_Arabic_Condition , " +
                                           " B.Building_NO, B.Building_Arabic_Name, B.Building_Id , " +
                                           " O.Street_NO , O.Street_Name , Z.zone_number , O.Owner_Ship_AR_Name , O.owner_ship_Code, O.Owner_Ship_Id , ONR.Owner_Arabic_name, " +
                                           " CT.Contract_Arabic_Type, " +
                                           " FC.Furniture_Ar_case, " +
                                           "PT.payment_Arabic_type " +
                                           "FROM contract C " +
                                          
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
                                           " where  C.tenants_Tenants_ID = '"+ lbl_tenants_Tenants_ID.Text+ "';  ";
                MySqlCommand get_Body_Repeater_Cmd = new MySqlCommand(get_Body_Repeater_Quari, _sqlCon);
                MySqlDataAdapter get_Body_Repeater_Dt = new MySqlDataAdapter(get_Body_Repeater_Cmd);
                get_Body_Repeater_Cmd.Connection = _sqlCon;
                _sqlCon.Open();
                get_Body_Repeater_Dt.SelectCommand = get_Body_Repeater_Cmd;
                DataTable get_Body_Repeater_DataTable = new DataTable();
                get_Body_Repeater_Dt.Fill(get_Body_Repeater_DataTable);
                Body_Repeater.DataSource = get_Body_Repeater_DataTable;
                Body_Repeater.DataBind();
                _sqlCon.Close();
            }
        }
        //--------------------------- Building Tenant Rental Disclosure DataBinder ------------
        protected void B_Header_Repeater_DataBinder()
        {
            string Where = "";
            if (Tenant_Name_DropDownList.SelectedItem.Text == "..... الكل .....")
            {
                Where = " ";
            }
            else
            {
                Where = " and C.tenants_Tenants_ID = '" + Tenant_Name_DropDownList.SelectedValue + "' ";
            }
            string B_Header_Repeater_Quari = "select  C.tenants_Tenants_ID , C.Contract_Id ,  " +
                                            "T.Tenants_Arabic_Name , T.Tenants_Mobile ,TN.Arabic_nationality " +
                                            "from building_contract C  " +
                                            "left join tenants T on(C.tenants_Tenants_ID = T.Tenants_ID) " +
                                            "left join nationality TN on(T.nationality_nationality_ID = TN.nationality_ID) " +
                                            "where C.Contract_Id > '0' " + Where + "" +
                                            " GROUP BY C.tenants_Tenants_ID  ; ";
            MySqlCommand get_B_Header_Repeater_Cmd = new MySqlCommand(B_Header_Repeater_Quari, _sqlCon);
            MySqlDataAdapter get_B_Header_Repeater_Dt = new MySqlDataAdapter(get_B_Header_Repeater_Cmd);
            get_B_Header_Repeater_Cmd.Connection = _sqlCon;
            _sqlCon.Open();
            get_B_Header_Repeater_Dt.SelectCommand = get_B_Header_Repeater_Cmd;
            DataTable get_B_Header_Repeater_DataTable = new DataTable();
            get_B_Header_Repeater_Dt.Fill(get_B_Header_Repeater_DataTable);
            B_Header_Repeater.DataSource = get_B_Header_Repeater_DataTable;
            B_Header_Repeater.DataBind();
            _sqlCon.Close();
        }
        protected void B_Body_Repeater_DataBinder()
        {
            foreach (RepeaterItem item in B_Header_Repeater.Items)
            {
                Repeater B_Body_Repeater = item.FindControl("B_Body_Repeater") as Repeater;
                Label lbl_tenants_Tenants_ID = item.FindControl("lbl_tenants_Tenants_ID") as Label;


                //string get_B_Body_Repeater_Quari = "SELECT  " +
                //                           "C.* ,   " +
                //                           " U.Unit_Number , U.Electricityt_Number , U.Water_Number ,  UT.Unit_Arabic_Type ,UD.Unit_Arabic_Detail, U.furniture_case_Furniture_case_Id, UC.Unit_Arabic_Condition , " +
                //                           " B.Building_NO, B.Building_Arabic_Name, B.Building_Id , " +
                //                           " O.Street_NO , O.Street_Name , Z.zone_number , O.Owner_Ship_AR_Name , O.owner_ship_Code, O.Owner_Ship_Id , ONR.Owner_Arabic_name, " +
                //                           " CT.Contract_Arabic_Type, " +
                //                           " FC.Furniture_Ar_case, " +
                //                           "PT.payment_Arabic_type " +
                //                           "FROM building_contract C " +

                //                           " left join units U on(C.units_Unit_ID = U.Unit_Id) " +
                //                           "left join unit_type UT on(U.unit_type_Unit_Type_Id = UT.Unit_Type_Id) " +
                //                           "left join unit_detail UD on(U.unit_detail_Unit_Detail_Id = UD.Unit_Detail_Id) " +
                //                           "left join unit_condition UC on(U.unit_condition_Unit_Condition_Id = UC.Unit_Condition_Id) " +
                //                           "left join building B on(U.building_Building_Id = B.building_Id) " +
                //                           "left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                //                           "left join zone Z on(O.zone_zone_Id = Z.zone_Id) " +
                //                           "left join owner ONR on(O.owner_Owner_Id = ONR.Owner_Id) " +
                //                           "left join contract_type CT on(C.contract_type_Contract_Type_Id = CT.Contract_Type_Id) " +
                //                           " left join furniture_case FC on(U.furniture_case_Furniture_case_Id = FC.Furniture_case_Id) " +
                //                           "left join payment_type PT on(C.payment_type_payment_type_Id = PT.payment_type_Id) " +
                //                           " where  C.tenants_Tenants_ID = '" + lbl_tenants_Tenants_ID.Text + "';  ";


                string get_B_Body_Repeater_Quari = "select U.Unit_ID , U.Unit_Number , U.Water_Number , U.Electricityt_Number , " +
                    "UD.Unit_Arabic_Detail ,  UC.Unit_Arabic_Condition , " +
                    "B.Building_Id , B.Building_Arabic_Name , B.Building_NO , " +
                    "O.Owner_Ship_Id , O.Owner_Ship_AR_Name , O.owner_ship_Code , " +
                    "C.tenants_Tenants_ID , C.Number_Of_Years , C.Start_Date , C.End_Date , C.Payment_Amount , C.Paymen_Method , C.Contract_Details  " +
                    "from units U " +
                    "left join unit_detail UD on(U.unit_detail_Unit_Detail_Id = UD.Unit_Detail_Id) " +
                    "left join unit_condition UC on(U.unit_condition_Unit_Condition_Id = UC.Unit_Condition_Id) " +
                    "left join building B on(U.building_Building_Id = B.Building_Id) " +
                    "left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                    "left join building_contract C on(C.building_Building_Id = B.Building_Id) " +
                    "where C.tenants_Tenants_ID  = '" + lbl_tenants_Tenants_ID.Text + "';  ";


                MySqlCommand get_B_Body_Repeater_Cmd = new MySqlCommand(get_B_Body_Repeater_Quari, _sqlCon);
                MySqlDataAdapter get_B_Body_Repeater_Dt = new MySqlDataAdapter(get_B_Body_Repeater_Cmd);
                get_B_Body_Repeater_Cmd.Connection = _sqlCon;
                _sqlCon.Open();
                get_B_Body_Repeater_Dt.SelectCommand = get_B_Body_Repeater_Cmd;
                DataTable get_B_Body_Repeater_DataTable = new DataTable();
                get_B_Body_Repeater_Dt.Fill(get_B_Body_Repeater_DataTable);
                B_Body_Repeater.DataSource = get_B_Body_Repeater_DataTable;
                B_Body_Repeater.DataBind();
                _sqlCon.Close();
            }
        }
        //--------------------------------------- Export To Excel  -----------------------------
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=كشف مستأجرين العقود المفردة.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            Header_Repeater.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=كشف مستأجرين العقود المجملة .xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            B_Header_Repeater.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=كشف المستأجرين .xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            Header_Repeater.RenderControl(hw);
            B_Header_Repeater.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        //--------------------------------------- Filltering UL  -----------------------------
        protected void A_1_ServerClick(object sender, EventArgs e)
        {
            Unit_Contract_Div.Visible = true; Building_Contract_Div.Visible = false;

            lbl_titelt.Text = "كشف مستأجرين العقود المفردة";
            Button3.Visible = false;
            Button1.Visible = true;
            Button2.Visible = false;
        }
        protected void A_2_ServerClick(object sender, EventArgs e)
        {
            Unit_Contract_Div.Visible = false; Building_Contract_Div.Visible = true;

            lbl_titelt.Text = "كشف مستأجرين العقود المجملة";
            Button3.Visible = false;
            Button1.Visible = false;
            Button2.Visible = true;
        }
        protected void A_3_ServerClick(object sender, EventArgs e)
        {
            Unit_Contract_Div.Visible = true; Building_Contract_Div.Visible = true;

            lbl_titelt.Text = "كشف المستأجرين";
            Button3.Visible = true;
            Button1.Visible = false;
            Button2.Visible = false;
        }
        //--------------------------------------- Filltering DropDownList  -----------------------------
        protected void Tenant_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Header_Repeater_DataBinder();
            Body_Repeater_DataBinder();


            B_Header_Repeater_DataBinder();
            B_Body_Repeater_DataBinder();
        }
    }
}