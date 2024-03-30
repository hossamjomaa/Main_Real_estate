using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Security.Policy;
using System.Web.Services.Description;
using Main_Real_estate.English.Master_Panal;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Pickup_Delivery_PDF : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Asset_Management", 0, "R");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!this.IsPostBack)
            {
                //Fill Tenant Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM tenants", _sqlCon, Tenan_Name_DropDownList, "Tenants_Arabic_Name", "Tenants_ID");
                Tenan_Name_DropDownList.Items.Insert(0, "الكل ...");


                //    //Fill Ownership Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM owner_ship where Active !='1'", _sqlCon, Ownership_Name_DropDownList,
                "Owner_Ship_AR_Name", "Owner_Ship_Id");
                Ownership_Name_DropDownList.Items.Insert(0, "الكل ...");

                //    //Fill Building Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM building Where Active ='1'", _sqlCon, Building_Name_DropDownList,
                    "Building_Arabic_Name", "Building_Id");
                Building_Name_DropDownList.Items.Insert(0, "الكل ...");

                //    //Fill Units Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM units Where Half ='0'", _sqlCon, Units_DropDownList, "Unit_Number", "Unit_ID");
                Units_DropDownList.Items.Insert(0, "الكل ...");

                Prosees_DropDownList.Items.Insert(0, "الكل ...");

                //    //Fill Date DropDownList
                Helper.LoadDropDownList("SELECT * FROM pickup_delivery group by Date ", _sqlCon, date_DropDownList, "Date", "Pickup_Delivery_Id");
                date_DropDownList.Items.Insert(0, "الكل ...");

                Pickup_Delivery_Listt();
            }
        }
        protected void Tenan_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pickup_Delivery_Listt();
        }

        //******************  Get The Building Of Selected Ownership ***************************************************
        protected void Ownership_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Ownership_Name_DropDownList.SelectedItem.Text == "الكل ...")
            {
                Helper.LoadDropDownList("SELECT * FROM building Where Active ='1'", _sqlCon, Building_Name_DropDownList, "Building_Arabic_Name", "Building_Id");
                Building_Name_DropDownList.Items.Insert(0, "الكل ...");
            }
            else
            {
                Helper.LoadDropDownList(
                "SELECT * FROM building where Active ='1' and owner_ship_Owner_Ship_Id = '" +
                Ownership_Name_DropDownList.SelectedValue + "'", _sqlCon, Building_Name_DropDownList,
                "Building_Arabic_Name", "Building_Id");
                Building_Name_DropDownList.Items.Insert(0, "الكل ...");
            }
            Pickup_Delivery_Listt();
        }
        //******************  Get The Units Of Selected Building ***************************************************
        protected void Building_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(Building_Name_DropDownList.SelectedItem.Text == "الكل ...")
            {
                Helper.LoadDropDownList("SELECT * FROM units Where Half ='0'", _sqlCon, Units_DropDownList, "Unit_Number", "Unit_ID");
                Units_DropDownList.Items.Insert(0, "الكل ...");
            }
            else
            {
                Helper.LoadDropDownList("SELECT * FROM units where Half ='0' and building_Building_Id = '" + Building_Name_DropDownList.SelectedValue + "'", _sqlCon, Units_DropDownList, "Unit_Number", "Unit_ID");
                Units_DropDownList.Items.Insert(0, "الكل ...");
            }
            Pickup_Delivery_Listt();
        }
        protected void Units_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Units_DropDownList.SelectedItem.Text == "الكل ...")
            {
                Helper.LoadDropDownList("SELECT * FROM pickup_delivery group by Date ", _sqlCon, date_DropDownList, "Date", "Pickup_Delivery_Id");
                date_DropDownList.Items.Insert(0, "الكل ...");

            }
            else
            {
                Helper.LoadDropDownList("SELECT * FROM pickup_delivery where Unit_Id = '" + Units_DropDownList.SelectedValue + "' GROUP BY Unit_Id",
                _sqlCon, date_DropDownList, "Date", "Pickup_Delivery_Id");
                date_DropDownList.Items.Insert(0, "الكل ...");
            }
            Pickup_Delivery_Listt();
        }
        protected void Prosees_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pickup_Delivery_Listt();
        }
        protected void date_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pickup_Delivery_Listt();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Control HeaderTemplate = Repeater1.Controls[0].Controls[0]; //lbl_Type
                Label lbl_Building = HeaderTemplate.FindControl("lbl_Building") as Label;
                Label lbl_Unit = HeaderTemplate.FindControl("lbl_Unit") as Label;
                Label lbl_Date = HeaderTemplate.FindControl("lbl_Date") as Label;
                Label lbl_Prosess = HeaderTemplate.FindControl("lbl_Prosess") as Label;
                //lbl_Building.Text = Building_Name_DropDownList.SelectedItem.Text.Trim();
                lbl_Unit.Text = Label2.Text;
                lbl_Building.Text = Label5.Text;
                lbl_Date.Text = Label4.Text;
                lbl_Prosess.Text = Label3.Text;
            }



            foreach (RepeaterItem ri in Repeater1.Items)
            {
                Label lbl_Type = (ri.FindControl("lbl_Type") as Label);
                Label lbl_Discription = (ri.FindControl("lbl_Discription") as Label);
                HtmlTableRow tr = ri.FindControl("row") as HtmlTableRow;
                HtmlTableRow tr2 = ri.FindControl("row2") as HtmlTableRow;


                if (lbl_Type.Text == "ملاحظات") {  tr.Visible= false; }
                if (lbl_Discription.Text == "") { tr2.Visible = false; }
            }
        }


        protected void Pickup_Delivery_Listt()
        {
            string OS_ID = ""; string B_ID = ""; string U_ID = ""; string Date = ""; string Prosses = ""; string Tenant = "";
            if (Ownership_Name_DropDownList.SelectedItem.Text != "الكل ...") { OS_ID = " and O.Owner_Ship_Id = " + Ownership_Name_DropDownList.SelectedValue; } else { OS_ID = ""; }
            if (Building_Name_DropDownList.SelectedItem.Text != "الكل ...") { B_ID = " and B.Building_Id = " + Building_Name_DropDownList.SelectedValue; } else { B_ID = ""; }
            if (Units_DropDownList.SelectedItem.Text != "الكل ...") { U_ID = " and U.Unit_ID = " + Units_DropDownList.SelectedValue; } else { U_ID = ""; }
            if (date_DropDownList.SelectedItem.Text != "الكل ...") { Date = " and Date = '"+ date_DropDownList.SelectedItem.Text.Trim()+ "'"; } else { Date = ""; }
            if (Prosees_DropDownList.SelectedItem.Text != "الكل ...") { Prosses = " and PD.Prosses = " + Prosees_DropDownList.SelectedValue; } else { Prosses = ""; }
            if (Tenan_Name_DropDownList.SelectedItem.Text != "الكل ...") { Tenant = " and T.Tenants_ID = " + Tenan_Name_DropDownList.SelectedValue; } else { Tenant = ""; }

            string getpickup_deliveryQuari = "SELECT PD.* ,  " +
                "U.Unit_Number , U.Unit_ID , " +
                "B.Building_Arabic_Name , B.Building_Id , " +
                " O. Owner_Ship_AR_Name , O.Owner_Ship_Id ,  T.Tenants_Arabic_Name , T.Tenants_ID ," +
                "(SELECT IF(PD.Prosses = 1, 'تسليم', 'إستلام'))Prossess " +
                "FROM pickup_delivery PD " +
                "left join units U on (PD.Unit_Id = U.Unit_ID) " +
                "left join building B on (U.building_Building_Id = B.Building_Id) " +
                "left join owner_ship O on (B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                "left join tenants T on (PD.Tenant_ID = T.Tenants_ID) " +

                "where PD.Pickup_Delivery_Id > 0  " + OS_ID + "  "+ B_ID + "  "+ U_ID + " "+ Date + "   "+ Prosses + "  "+ Tenant + " " +
                "group by PD.Unit_Id ";


            MySqlCommand getpickup_deliveryCmd = new MySqlCommand(getpickup_deliveryQuari, _sqlCon);
            MySqlDataAdapter getpickup_deliveryDt = new MySqlDataAdapter(getpickup_deliveryCmd);
            getpickup_deliveryCmd.Connection = _sqlCon;
            _sqlCon.Open();
            getpickup_deliveryDt.SelectCommand = getpickup_deliveryCmd;
            DataTable getpickup_deliveryDataTable = new DataTable();
            getpickup_deliveryDt.Fill(getpickup_deliveryDataTable);
            Pickup_Delivery_List.DataSource = getpickup_deliveryDataTable;
            Pickup_Delivery_List.DataBind();
            _sqlCon.Close();
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            string QQ = "SELECT PD.* , U.Unit_Number , U.Unit_ID , B.Building_Arabic_Name , B.Building_Id  " +
                "FROM pickup_delivery PD " +
                " left join units U on (PD.Unit_Id = U.Unit_ID) " +
                "left join building B on (U.building_Building_Id = B.Building_Id) " +
                "WHERE Pickup_Delivery_Id = @ID";

            DataTable getpickup_deliveryDt = new DataTable();
            _sqlCon.Open();
            MySqlCommand getpickup_deliveryCmd = new MySqlCommand(QQ, _sqlCon);
            MySqlDataAdapter getpickup_deliveryDa = new MySqlDataAdapter(getpickup_deliveryCmd);
            getpickup_deliveryCmd.Parameters.AddWithValue("@ID", id);
            getpickup_deliveryDa.Fill(getpickup_deliveryDt);
            if (getpickup_deliveryDt.Rows.Count > 0)
            {
                string Unit_Id = getpickup_deliveryDt.Rows[0]["Unit_ID"].ToString();

                string Unit_Number = getpickup_deliveryDt.Rows[0]["Unit_Number"].ToString();
                string Building_Arabic_Name = getpickup_deliveryDt.Rows[0]["Building_Arabic_Name"].ToString();
                string Prosses = getpickup_deliveryDt.Rows[0]["Prosses"].ToString();
                string Date = getpickup_deliveryDt.Rows[0]["Date"].ToString();

                Label2.Text = Unit_Number;
                Label5.Text = Building_Arabic_Name;
                if (Prosses == "1") { Label3.Text = "تسليم"; }
                else { Label3.Text = "إستلام"; }
                Label4.Text = Date;



                string getZoneQuari = "SELECT PD.* , B.Building_Arabic_Name , O.Owner_Ship_AR_Name , Z.zone_arabic_name , " +
                "(SELECT IF(Status= 1, '✔', '')) good ,  " +
                "(SELECT IF(Status= 1, '', '✔')) bad  , " +
                "(SELECT IF(Prosses= 1, 'تسليم', 'إستلام')) Prossess   " +
                "FROM pickup_delivery PD " +
                "left join building B on (PD.Unit_Id = B.Building_Id)  " +
                "left join owner_ship O on (B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                "left join zone Z on (O.zone_zone_Id = Z.zone_Id) " +
                "where Unit_Id='" + Unit_Id + "' and Prosses='" + Prosses + "' and Date='" + Date + "'";
                MySqlCommand getZoneCmd = new MySqlCommand(getZoneQuari, _sqlCon);
                MySqlDataAdapter getZoneDt = new MySqlDataAdapter(getZoneCmd);
                getZoneCmd.Connection = _sqlCon;
                getZoneDt.SelectCommand = getZoneCmd;
                DataTable getZoneDataTable = new DataTable();
                getZoneDt.Fill(getZoneDataTable);
                Repeater1.DataSource = getZoneDataTable;
                Repeater1.DataBind();

                printt.Visible = true;
            }

            _sqlCon.Close();
        }






















        protected void Button1_Click1(object sender, EventArgs e)
        {
            string getZoneQuari = "SELECT PD.* , B.Building_Arabic_Name , O.Owner_Ship_AR_Name , Z.zone_arabic_name , " +
                "(SELECT IF(Status= 1, '✔', '')) good ,  " +
                "(SELECT IF(Status= 1, '', '✔')) bad  , " +
                "(SELECT IF(Prosses= 1, 'تسليم', 'إستلام')) Prossess   " +
                "FROM pickup_delivery PD " +
                "left join building B on (PD.Unit_Id = B.Building_Id)  " +
                "left join owner_ship O on (B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                "left join zone Z on (O.zone_zone_Id = Z.zone_Id) " +
                "where Unit_Id='" + Units_DropDownList.SelectedValue + "' and Prosses='" + Prosees_DropDownList.SelectedValue + "' and Date='" + date_DropDownList.SelectedItem.Text.Trim() + "'";
            MySqlCommand getZoneCmd = new MySqlCommand(getZoneQuari, _sqlCon);
            MySqlDataAdapter getZoneDt = new MySqlDataAdapter(getZoneCmd);
            getZoneCmd.Connection = _sqlCon;
            _sqlCon.Open();
            getZoneDt.SelectCommand = getZoneCmd;
            DataTable getZoneDataTable = new DataTable();
            getZoneDt.Fill(getZoneDataTable);
            Repeater1.DataSource = getZoneDataTable;
            Repeater1.DataBind();
            _sqlCon.Close();

            printt.Visible = true;
        }

       
    }
}