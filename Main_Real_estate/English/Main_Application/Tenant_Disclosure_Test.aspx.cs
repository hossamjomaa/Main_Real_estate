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
    public partial class Tenant_Disclosure_Test : System.Web.UI.Page
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

                Header_Repeater_DataBinder(); Body_Repeater_DataBinder();
            }
        }

        protected void Header_Repeater_DataBinder()
        {
            string Tenant = ""; string Type_e = "";
            if (Tenant_Name_DropDownList.SelectedItem.Text == "..... الكل .....") { Tenant = ""; } else { Tenant = Tenant_Name_DropDownList.SelectedItem.Text; }
            if (Typee.Text == "1") { Type_e = ""; }else if (Typee.Text == "2") { Type_e = "A"; } else if (Typee.Text == "3") { Type_e = "B"; } else { Type_e = ""; }
            { Type_e = "B"; }

            string Header_Repeater_Quari = "" +
            "select * from " +
            "(select (SELECT CAST(CONCAT('A')as char))Typee ,  C.tenants_Tenants_ID , C.Contract_Id , T.Tenants_Arabic_Name , T.Tenants_Mobile ,TN.Arabic_nationality  , O.owner_ship_Code from contract C  " +
            " left join tenants T on(C.tenants_Tenants_ID = T.Tenants_ID)  " +
            " left join nationality TN on(T.nationality_nationality_ID = TN.nationality_ID)  " +
            "left join units U on (C.units_Unit_ID = U.Unit_ID) " +
            "left join building B on (U.building_Building_Id = B.building_Id) " +
            "left join owner_ship O on (B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id)   " +
            " union " +
            "select (SELECT CAST(CONCAT('B')as char))Typee ,  C.tenants_Tenants_ID , C.Contract_Id , T.Tenants_Arabic_Name , T.Tenants_Mobile ,TN.Arabic_nationality  , O.owner_ship_Code from building_contract C    " +
            "left join tenants T on(C.tenants_Tenants_ID = T.Tenants_ID)   " +
            "left join nationality TN on(T.nationality_nationality_ID = TN.nationality_ID)  " +
            " left join building B on (C.building_Building_Id = B.Building_Id) " +
            "left join owner_ship O on (B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id))a  " +
            " where Tenants_Arabic_Name like CONCAT('%', '"+ Tenant + "', '%') " +
            " GROUP BY tenants_Tenants_ID  order by owner_ship_Code asc ";
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
        protected  void Body_Repeater_DataBinder()
        {
            string Type_e = "";
            if (Typee.Text == "1") { Type_e = ""; } else if (Typee.Text == "2") { Type_e = "A"; } else if (Typee.Text == "3") { Type_e = "B"; } else { Type_e = ""; }
            foreach (RepeaterItem item in Header_Repeater.Items)
            {
                Repeater Body_Repeater = item.FindControl("Body_Repeater") as Repeater;
                Label lbl_tenants_Tenants_ID = item.FindControl("lbl_tenants_Tenants_ID") as Label;


                using (MySqlCommand cmd = new MySqlCommand("All_Tenant_Disclosure", _sqlCon))
                {
                    cmd.Parameters.AddWithValue("@T_Id", lbl_tenants_Tenants_ID.Text);
                    cmd.Parameters.AddWithValue("@Type_e", Type_e);
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        Body_Repeater.DataSource = dt;
                        Body_Repeater.DataBind();
                    }
                }
            }
            
        }














        //************************ Filtering Functions ********************************************
        //************************ Singel Mulit Filtering Functions *******************************
        protected void A_3_ServerClick(object sender, EventArgs e)
        {
            Header_Repeater_DataBinder(); Body_Repeater_DataBinder();
            Typee.Text = "1"; lbl_titelt.Text = "كشف المستأجرين";
        }
        protected void A_1_ServerClick(object sender, EventArgs e)
        {
            Header_Repeater_DataBinder(); Body_Repeater_DataBinder();
            Typee.Text = "2"; lbl_titelt.Text = "كشف مستأجرين العقود المفردة";
        }
        protected void A_2_ServerClick(object sender, EventArgs e)
        {
            Header_Repeater_DataBinder(); Body_Repeater_DataBinder();
            Typee.Text = "3"; lbl_titelt.Text = "كشف مستأجرين العقود المجملة";
        }
        //************************ Tenant Name Filtering Functions **********************************
        protected void Tenant_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Header_Repeater_DataBinder(); Body_Repeater_DataBinder();
        }
        //************************ Export To Excel **************************************************
        protected void Excel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename='"+ lbl_titelt.Text + "'.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            Header_Repeater.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
}