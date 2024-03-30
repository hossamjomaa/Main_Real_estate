using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Rental_Disclosure_test : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
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

                Header_Repeater_DataBinder();
                Building_Repeater_DataBinder();
                Unit();
                
            }
        }
        protected void Header_Repeater_DataBinder()
        {
            string Where = ""; string typee = "";

            if (Ownershi_Code_DropDownList.SelectedItem.Text == "..... الكل .....") { Where = ""; }
            else { Where = "and Owner_Ship_Id = '" + Ownershi_Code_DropDownList.SelectedValue + "' "; }

            if (Quari.Text == "1") { typee = ""; } else if (Quari.Text == "2") { typee = "and Typee = 'A'"; } else { typee = "and Typee = 'B'"; }

            string Header_Repeater_Quari = "select * from ( " +
                "SELECT  (SELECT CAST(CONCAT('A')as char))Typee , B.Building_Id  , B.Building_NO  , B.Building_Arabic_Name  ,  " +
                "O.Owner_Ship_Id  , O.owner_ship_Code  , O.Owner_Ship_AR_Name , O.Street_NO   ,  O.Street_Name  ,   " +
                "ONR.Owner_Arabic_name  ,  " +
                "Z.zone_number   " +
                "FROM contract C    " +
                "left join units U on(C.units_Unit_ID = U.Unit_Id)  " +
                "left join building B on(U.building_Building_Id = B.building_Id)  " +
                "left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id)  " +
                "left join zone Z on(O.zone_zone_Id = Z.zone_Id)  " +
                "left join owner ONR on(O.owner_Owner_Id = ONR.Owner_Id)  " +
                "union  " +
                "SELECT   " +
                "(SELECT CAST(CONCAT('B')as char))Typee , B.Building_Id  , B.Building_NO  , B.Building_Arabic_Name  ,  " +
                "O.Owner_Ship_Id  , O.owner_ship_Code  , O.Owner_Ship_AR_Name , O.Street_NO   ,  O.Street_Name  ,   " +
                "ONR.Owner_Arabic_name  ,  " +
                "Z.zone_number " +
                "FROM building_contract C  " +
                "left join building B on(C.building_Building_Id = B.building_Id)  " +
                "left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id)  " +
                "left join zone Z on(O.zone_zone_Id = Z.zone_Id)  " +
                "left join owner ONR on(O.owner_Owner_Id = ONR.Owner_Id) ) a  where Owner_Ship_Id > '0' " + typee + "  " + Where + "" +
                "GROUP BY Owner_Ship_Id " +
                "order by owner_ship_Code asc   ";
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
                string Building_Repeater_Quari = "SELECT  " +
                    "B.Building_NO , B.Half_Building_ID FROM contract C " +
                    "left join units U on(C.units_Unit_ID = U.Unit_Id) " +
                    "left join building B on(U.building_Building_Id = B.building_Id) " +
                    "left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                    "where O.Owner_Ship_Id = '" + lbl_Ownersihp_Id.Text + "' " +
                    "GROUP BY B.Half_Building_ID " +
                    "union " +
                    "SELECT " +
                    "B.Building_NO , B.Half_Building_ID FROM building_contract C " +
                    "left join building B on(C.building_Building_Id = B.building_Id) " +
                    "left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                    "where O.Owner_Ship_Id = '" + lbl_Ownersihp_Id.Text + "' " +
                    "GROUP BY B.Half_Building_ID; ";
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
        protected void Unit()
        {
            string type_e = "";
            if (Quari.Text == "1") { type_e = ""; } else if (Quari.Text == "2") { type_e = "A"; } else { type_e = "B"; }

            foreach (RepeaterItem item in OWnershi_Repeater.Items)
            {
                Repeater Buildingg_Repeater = item.FindControl("Buildingg_Repeater") as Repeater;
                Label lbl_Ownersihp_Id = item.FindControl("lbl_Ownersihp_Id") as Label;
                foreach (RepeaterItem itm in Buildingg_Repeater.Items)
                {
                    Repeater Unit_Repeater = itm.FindControl("Unit_Repeater") as Repeater;
                    Label lbl_Building_Id = itm.FindControl("lbl_Building_Id") as Label;
                    using (MySqlCommand cmd = new MySqlCommand("All_Rental_Disclosure", _sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@B_ID", lbl_Building_Id.Text);
                        cmd.Parameters.AddWithValue("@Type_e", type_e);
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            Unit_Repeater.DataSource = dt;
                            Unit_Repeater.DataBind();
                        }
                    }
                }
            }
        }
        //****************************** Filtering Functions ***************************************

        //****************************** Singel Multi Filtering  ***************************************
        protected void A_1_ServerClick(object sender, EventArgs e)
        {
            Quari.Text = "2"; Typee.Text = "كشف المؤجرات للعقود المفردة";
            Header_Repeater_DataBinder(); Building_Repeater_DataBinder(); Unit();
        }
        protected void A_2_ServerClick(object sender, EventArgs e)
        {
            Quari.Text = "3"; Typee.Text = "كشف المؤجرات للعقود المجملة ";
            Header_Repeater_DataBinder(); Building_Repeater_DataBinder(); Unit();
        }
        protected void A_3_ServerClick(object sender, EventArgs e)
        {
            Quari.Text = "1"; Typee.Text = "كشف المؤجرات للكل ";
            Header_Repeater_DataBinder(); Building_Repeater_DataBinder(); Unit();
        }
        //****************************** DropDownList Filtering  ***************************************
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

            Header_Repeater_DataBinder(); Building_Repeater_DataBinder(); Unit();
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

            Header_Repeater_DataBinder(); Building_Repeater_DataBinder(); Unit();
        }
        protected void Zone_N_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get Ownershi_Code_DropDownList
            Helper.LoadDropDownList("SELECT * FROM owner_ship where Active!='1' and zone_zone_Id = '" + Zone_N_DropDownList.SelectedValue + "'", _sqlCon, Ownershi_Code_DropDownList, "owner_ship_Code", "Owner_Ship_Id");
            Ownershi_Code_DropDownList.Items.Insert(0, "..... الكل .....");

            //Get Ownershi_Name_DropDownList
            Helper.LoadDropDownList("SELECT * FROM owner_ship where Active!='1' and zone_zone_Id = '" + Zone_N_DropDownList.SelectedValue + "'", _sqlCon, Ownershi_Name_DropDownList, "Owner_Ship_AR_Name", "Owner_Ship_Id");
            Ownershi_Name_DropDownList.Items.Insert(0, "..... الكل .....");

            Header_Repeater_DataBinder(); Building_Repeater_DataBinder(); Unit();
        }
    }
}