using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


//using Excel = Microsoft.Office.Interop.Excel;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Rental_Disclosure : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Get Ownershi_Code_DropDownList
                Helper.LoadDropDownList("SELECT * FROM owner_ship", _sqlCon, Ownershi_Code_DropDownList, "owner_ship_Code", "Owner_Ship_Id");
                Ownershi_Code_DropDownList.Items.Insert(0, "..... الكل .....");

                //Get Ownershi_Name_DropDownList
                Helper.LoadDropDownList("SELECT * FROM owner_ship", _sqlCon, Ownershi_Name_DropDownList, "Owner_Ship_AR_Name", "Owner_Ship_Id");
                Ownershi_Name_DropDownList.Items.Insert(0, "..... الكل .....");

                //Get Ownershi_Name_DropDownList
                Helper.LoadDropDownList("SELECT * FROM owner_ship", _sqlCon, Street_N_DropDownList, "Street_NO", "Owner_Ship_Id");
                Street_N_DropDownList.Items.Insert(0, "..... الكل .....");

                //Get Ownershi_Code_DropDownList
                Helper.LoadDropDownList("SELECT * FROM building", _sqlCon, Building_No_DropDownList, "Building_NO", "Building_Id");
                Building_No_DropDownList.Items.Insert(0, "..... الكل .....");

                




                Header_Repeater_DataBinder();
                Body_Repeater_DataBinder();

                //-------------------------------
                B_Header_Repeater_DataBinder();
                B_Body_Repeater_DataBinder();
            }
        }
        protected void Header_Repeater_DataBinder()
        {
            string Where = "";
            if(Ownershi_Code_DropDownList.SelectedItem.Text== "..... الكل .....")
            {
                Where = " ";
            }
            else
            {
                Where = "Where O.Owner_Ship_Id = '" + Ownershi_Code_DropDownList.SelectedValue + "' ";
            }

            string Header_Repeater_Quari = "SELECT  " +
                                    "B.Building_Id , B.Building_NO, B.Building_Arabic_Name, " +
                                    "O.Street_NO , O.Street_Name , Z.zone_number , O.Owner_Ship_Id , O.Owner_Ship_AR_Name , O.owner_ship_Code, ONR.Owner_Arabic_name FROM contract C " +
                                    "left join units U on(C.units_Unit_ID = U.Unit_Id) " +
                                    " left join building B on(U.building_Building_Id = B.building_Id) " +
                                    " left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                                    "left join zone Z on(O.zone_zone_Id = Z.zone_Id) " +
                                    "left join owner ONR on(O.owner_Owner_Id = ONR.Owner_Id) "+ Where + " " +
                                    " GROUP BY B.Building_Id; ";
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
                Label lbl_Building_Id = item.FindControl("lbl_Building_Id") as Label;


                string get_Body_Repeater_Quari =    "SELECT  " +
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
                                           " where B.Building_Id = '"+ lbl_Building_Id.Text+ "'; ";
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

        //-------------------------------------------------------------------------------------------------------------------------------

        protected void B_Header_Repeater_DataBinder()
        {
            string Where = "";
            if (Ownershi_Code_DropDownList.SelectedItem.Text == "..... الكل .....")
            {
                Where = " ";
            }
            else
            {
                Where = "Where O.Owner_Ship_Id = '" + Ownershi_Code_DropDownList.SelectedValue + "' ";
            }
            string B_Header_Repeater_Quari = "SELECT  " +
                                            " B.Building_Id , B.Building_NO , B.Building_Arabic_Name ,  " +
                                            " O.Street_NO , O.Street_Name , O.Owner_Ship_AR_Name, O.owner_ship_Code, Z.zone_number , ONR.Owner_Arabic_name " +
                                            " FROM building_contract C " +
                                            " left join building B on(C.building_Building_Id = B.Building_Id) " +
                                            "left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                                            "left join zone Z on(O.zone_zone_Id = Z.zone_Id) " +
                                            " left join owner ONR on(O.owner_Owner_Id = ONR.Owner_Id) "+ Where + " " +
                                            "GROUP BY B.Building_Id; ";



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
                Label lbl_Building_Id = item.FindControl("lbl_Building_Id") as Label;


                string get_B_Body_Repeater_Quari = "SELECT  " +
                    " C.Number_Of_Years ,  C.Start_Date , C.End_Date , C.Paymen_Method , C.Payment_Amount , C.Contract_Details , " +
                    " T.Tenants_Arabic_Name , T.tenant_type_Tenant_Type_Id ,   T.ID_NO , T.Tenants_Mobile  ,  T.P_O_Box  ,  " +
                    " B.Building_Arabic_Name, B.Building_Id ,  " +
                    " U.Unit_Number , U.Unit_ID , U.Electricityt_Number , U.Water_Number ,  " +
                    "UD.Unit_Arabic_Detail  ,  UC.Unit_Arabic_Condition   , " +
                    " O.Street_NO , O.Street_Name , O.Owner_Ship_AR_Name, Z.zone_number " +
                    " FROM building_contract C " +
                    " left join tenants T on(C.tenants_Tenants_ID = T.Tenants_Id) " +
                    " left join nationality TN on(T.nationality_nationality_ID = TN.nationality_ID) " +
                    " left join building B on(C.building_Building_Id = B.Building_Id) " +
                    " left join units U on(U.building_Building_Id = B.Building_Id) " +
                    " left join unit_detail UD on(U.unit_detail_Unit_Detail_Id = UD.Unit_Detail_Id) " +
                    " left join unit_condition UC on(U.unit_condition_Unit_Condition_Id = UC.Unit_Condition_Id) " +
                    " left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                    " left join zone Z on(O.zone_zone_Id = Z.zone_Id) " +
                    "left join contract_type CT on(C.contract_type_Contract_Type_Id = CT.Contract_Type_Id) " +
                    " where B.Building_Id = '"+ lbl_Building_Id.Text+ "'; ";
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=كشف المؤجرات المفردة.xls");
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
            Response.AddHeader("content-disposition", "attachment;filename=كشف المؤجرات المجملة .xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            B_Header_Repeater.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        protected void A_1_ServerClick(object sender, EventArgs e)
        {
            Unit_Contract_Div.Visible = true;  Building_Contract_Div.Visible = false; 
        }

        protected void A_2_ServerClick(object sender, EventArgs e)
        {
            Unit_Contract_Div.Visible = false; Building_Contract_Div.Visible = true;
        }

        protected void A_3_ServerClick(object sender, EventArgs e)
        {
            Unit_Contract_Div.Visible = true; Building_Contract_Div.Visible = true;
        }

        protected void Ownershi_Code_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ownershi_Name_DropDownList.SelectedValue = Ownershi_Code_DropDownList.SelectedValue;
            Street_N_DropDownList.SelectedValue = Ownershi_Code_DropDownList.SelectedValue;
            
            //Get Ownershi_Code_DropDownList
            Helper.LoadDropDownList("SELECT * FROM building where owner_ship_Owner_Ship_Id = '"+ Ownershi_Code_DropDownList.SelectedValue + "'", _sqlCon, Building_No_DropDownList, "Building_NO", "Building_Id");
            Building_No_DropDownList.Items.Insert(0, "..... الكل .....");

            Header_Repeater_DataBinder();
            Body_Repeater_DataBinder();

            B_Header_Repeater_DataBinder();
            B_Body_Repeater_DataBinder();

        }

        protected void Ownershi_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ownershi_Code_DropDownList.SelectedValue = Ownershi_Name_DropDownList.SelectedValue;
            Street_N_DropDownList.SelectedValue = Ownershi_Name_DropDownList.SelectedValue;

            //Get Ownershi_Code_DropDownList
            Helper.LoadDropDownList("SELECT * FROM building where owner_ship_Owner_Ship_Id = '" + Ownershi_Code_DropDownList.SelectedValue + "'", _sqlCon, Building_No_DropDownList, "Building_NO", "Building_Id");
            Building_No_DropDownList.Items.Insert(0, "..... الكل .....");

            Header_Repeater_DataBinder();
            Body_Repeater_DataBinder();

            B_Header_Repeater_DataBinder();
            B_Body_Repeater_DataBinder();
        }
        protected void Street_N_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ownershi_Code_DropDownList.SelectedValue = Street_N_DropDownList.SelectedValue;
            Ownershi_Name_DropDownList.SelectedValue = Street_N_DropDownList.SelectedValue;

            //Get Ownershi_Code_DropDownList
            Helper.LoadDropDownList("SELECT * FROM building where owner_ship_Owner_Ship_Id = '" + Ownershi_Code_DropDownList.SelectedValue + "'", _sqlCon, Building_No_DropDownList, "Building_NO", "Building_Id");
            Building_No_DropDownList.Items.Insert(0, "..... الكل .....");

            Header_Repeater_DataBinder();
            Body_Repeater_DataBinder();

            B_Header_Repeater_DataBinder();
            B_Body_Repeater_DataBinder();
        }


        //protected void Where_Quary()
        //{
        //    string Building_No = ""; string owner_ship_Code = ""; string Owner_Ship_AR_Name = "";


        //    if (Building_No_DropDownList.SelectedItem.Text != "..... الكل .....")
        //    { Building_No = "And Z.zone_Id = '" + Building_No_DropDownList.SelectedValue + "' "; }
        //    else { Building_No = ""; }

        //    if (Ownershi_Code_DropDownList.SelectedItem.Text != "..... الكل .....")
        //    { owner_ship_Code = "And O.owner_ship_Code = '" + Ownershi_Code_DropDownList.SelectedItem.Text + "' "; }
        //    else { owner_ship_Code = ""; }

        //    if (Ownershi_Name_DropDownList.SelectedItem.Text != "..... الكل .....")
        //    { Owner_Ship_AR_Name = "And O.Owner_Ship_AR_Name = '" + Ownershi_Name_DropDownList.SelectedItem.Text + "' "; }
        //    else { Owner_Ship_AR_Name = ""; }


        //    Quari.Text = Building_No + owner_ship_Code + Owner_Ship_AR_Name;
        //}

    }
}