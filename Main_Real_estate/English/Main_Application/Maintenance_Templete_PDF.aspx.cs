using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Maintenance_Templete_PDF : System.Web.UI.Page
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
                //    //Fill Ownership Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM owner_ship where Active !='1'", _sqlCon, Ownership_Name_DropDownList,
                "Owner_Ship_AR_Name", "Owner_Ship_Id");
                Ownership_Name_DropDownList.Items.Insert(0, "الكل ...");

                //    //Fill Building Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM building Where Active ='1'", _sqlCon, Building_Name_DropDownList,
                    "Building_Arabic_Name", "Building_Id");
                Building_Name_DropDownList.Items.Insert(0, "الكل ...");

                Helper.LoadDropDownList("SELECT * FROM employee", _sqlCon, Employee_Name_DropDownList, "Employee_Arabic_name", "Employee_Id");
                Employee_Name_DropDownList.Items.Insert(0, "الكل ...");


                Helper.LoadDropDownList("SELECT * FROM maintenece_templete  GROUP BY Date",
               _sqlCon, date_DropDownList, "Date", "Maintenece_Templete_Id");
                date_DropDownList.Items.Insert(0, "الكل ...");


                Pickup_Delivery_Listt();
            }
        }
        //******************  Get The Building Of Selected Ownership ***************************************************
        protected void Ownership_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Ownership_Name_DropDownList.SelectedItem.Text == "الكل ...")
            {
                Helper.LoadDropDownList("SELECT * FROM building Where Active ='1'", _sqlCon, Building_Name_DropDownList,
                    "Building_Arabic_Name", "Building_Id");
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

        protected void Building_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Building_Name_DropDownList.SelectedItem.Text == "الكل ...")
            {
                Helper.LoadDropDownList("SELECT * FROM maintenece_templete  GROUP BY Date",
               _sqlCon, date_DropDownList, "Date", "Maintenece_Templete_Id");
                date_DropDownList.Items.Insert(0, "الكل ...");
            }
            else
            {
                Helper.LoadDropDownList("SELECT * FROM maintenece_templete where Building_ID = '" + Building_Name_DropDownList.SelectedValue + "' GROUP BY Building_ID",
                _sqlCon, date_DropDownList, "Date", "Maintenece_Templete_Id");
                date_DropDownList.Items.Insert(0, "الكل ...");
            }
            Pickup_Delivery_Listt();
        }

        protected void Employee_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pickup_Delivery_Listt();
        }
        protected void date_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pickup_Delivery_Listt();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string getZoneQuari = "SELECT MT.* , T.Tenants_Arabic_Name , B.Building_Arabic_Name , " +
                "(SELECT IF(Clean= 1, '✔', '')) R_Clean  , " +
                "(SELECT IF(Save= 1, '✔', '')) R_Save  , " +
                "(SELECT IF(Maintenece= 1, '✔', '')) R_Maintenece  , " +
                "(SELECT IF(disclaimer= 1, '✔', '')) R_disclaimer ,  " +
                "(SELECT IF(Last_Maintenece_Type= 1, 'دورية', 'حادثة')) R_Last_Maintenece_Type , " +
                "(SELECT IF(Last_Clean_Type= 1, 'دورية', 'حادثة')) R_Last_Clean_Type  " +
                "FROM maintenece_templete MT " +
                " left join tenants T on (MT.Employee_ID = T.Tenants_ID) " +
                "left join building B on (MT.Building_ID = B.Building_Id) " +
                "where Employee_ID = '"+Employee_Name_DropDownList.SelectedValue+"' " +
                "and MT.Building_ID = '"+Building_Name_DropDownList.SelectedValue+"' and Date='"+date_DropDownList.SelectedItem.Text.Trim()+"'";
            
            
            
            
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

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem ri in Repeater1.Items)
            {
                Label lbl_Last_Maintenece_Date = (ri.FindControl("lbl_Last_Maintenece_Date") as Label);
                HtmlTableRow tr2 = ri.FindControl("row2") as HtmlTableRow;
                if (lbl_Last_Maintenece_Date.Text == "") { tr2.Visible = false; }




                Label lbl_Discription = (ri.FindControl("lbl_Discription") as Label);
                HtmlTableRow Tr2 = ri.FindControl("Tr2") as HtmlTableRow;
                if (lbl_Discription.Text == "") { Tr2.Visible = false; }




                Label lbl_Type = (ri.FindControl("lbl_Type") as Label);
                HtmlTableRow row = ri.FindControl("row") as HtmlTableRow;
                if (lbl_Type.Text == "معلومات") { row.Visible = false; }




                Label lbl_R_Last_Maintenece_Type = (ri.FindControl("lbl_R_Last_Maintenece_Type") as Label);
                Label lbl_R_Last_Clean_Type = (ri.FindControl("lbl_R_Last_Clean_Type") as Label);

                if (lbl_R_Last_Maintenece_Type.Text == "1") { lbl_R_Last_Maintenece_Type.Text = "دورية"; } else { lbl_R_Last_Maintenece_Type.Text = "حادثة"; }
                if (lbl_R_Last_Clean_Type.Text == "1") { lbl_R_Last_Clean_Type.Text = "دورية"; } else { lbl_R_Last_Clean_Type.Text = "حادثة"; }





                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Control HeaderTemplate = Repeater1.Controls[0].Controls[0]; //lbl_Type
                    Label lbl_Employee = HeaderTemplate.FindControl("lbl_Employee") as Label;
                    Label lbl_Date = HeaderTemplate.FindControl("lbl_Date") as Label;
                    Label lbl_Building = HeaderTemplate.FindControl("lbl_Building") as Label;

                    lbl_Building.Text = Label4.Text;
                    lbl_Date.Text = Label5.Text;
                    lbl_Employee.Text = Label2.Text;
                }
            }
        }








        protected void Pickup_Delivery_Listt()
        {
            string OS_ID = ""; string B_ID = ""; ; string Date = ""; string Employee = "";

            if (Ownership_Name_DropDownList.SelectedItem.Text != "الكل ...") { OS_ID = " and O.Owner_Ship_Id = " + Ownership_Name_DropDownList.SelectedValue; } else { OS_ID = ""; }
            if (Building_Name_DropDownList.SelectedItem.Text != "الكل ...") { B_ID = " and B.Building_Id = " + Building_Name_DropDownList.SelectedValue; } else { B_ID = ""; }
            if (date_DropDownList.SelectedItem.Text != "الكل ...") { Date = " and Date = '" + date_DropDownList.SelectedItem.Text.Trim() + "'"; } else { Date = ""; }
            if (Employee_Name_DropDownList.SelectedItem.Text != "الكل ...") { Employee = " and MT.Employee_ID = " + Employee_Name_DropDownList.SelectedValue; } else { Employee = ""; }

            string getpickup_deliveryQuari = "SELECT MT.* , E.Employee_Arabic_name , " +
                " B.Building_Arabic_Name , B.Building_Id , " +
                " O. Owner_Ship_AR_Name , O.Owner_Ship_Id " +
                " FROM maintenece_templete MT " +
                "left join building B on (MT.Building_ID = B.Building_Id) " +
                "left join owner_ship O on (B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
            "left join employee E on (MT.Employee_ID = E.Employee_Id) " +
            "where MT.Building_ID > 0  " + OS_ID + "  " + B_ID + "      " + Employee + "  " + Date + " " +
            "group by  MT.Building_ID ";


            MySqlCommand getpickup_deliveryCmd = new MySqlCommand(getpickup_deliveryQuari, _sqlCon);
            MySqlDataAdapter getpickup_deliveryDt = new MySqlDataAdapter(getpickup_deliveryCmd);
            getpickup_deliveryCmd.Connection = _sqlCon;
            _sqlCon.Open();
            getpickup_deliveryDt.SelectCommand = getpickup_deliveryCmd;
            DataTable getpickup_deliveryDataTable = new DataTable();
            getpickup_deliveryDt.Fill(getpickup_deliveryDataTable);
            Maintenance_Templete_List.DataSource = getpickup_deliveryDataTable;
            Maintenance_Templete_List.DataBind();
            _sqlCon.Close();
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;

            string QQ = "SELECT MT.* , E.Employee_Arabic_name , E.Employee_ID , B.Building_Arabic_Name , B.Building_Id " +
                "FROM maintenece_templete MT   " +
                "left join employee E on (MT.Employee_ID = E.Employee_Id)   " +
                "left join building B on (MT.Building_ID = B.Building_Id)   " +
                "WHERE Maintenece_Templete_Id = @ID";

            DataTable getpickup_deliveryDt = new DataTable();
            _sqlCon.Open();
            MySqlCommand getpickup_deliveryCmd = new MySqlCommand(QQ, _sqlCon);
            MySqlDataAdapter getpickup_deliveryDa = new MySqlDataAdapter(getpickup_deliveryCmd);
            getpickup_deliveryCmd.Parameters.AddWithValue("@ID", id);
            getpickup_deliveryDa.Fill(getpickup_deliveryDt);
            if (getpickup_deliveryDt.Rows.Count > 0)
            {
                string Employee_Id = getpickup_deliveryDt.Rows[0]["Employee_ID"].ToString();
                string Employee_Name = getpickup_deliveryDt.Rows[0]["Employee_Arabic_name"].ToString();

                string Building_Id = getpickup_deliveryDt.Rows[0]["Building_Id"].ToString();
                string Building_Name = getpickup_deliveryDt.Rows[0]["Building_Arabic_Name"].ToString();

                string Date = getpickup_deliveryDt.Rows[0]["Date"].ToString();


                Label1.Text = Employee_Id;
                Label2.Text = Employee_Name;

                Label3.Text = Building_Id;
                Label4.Text = Building_Name;

                Label5.Text = Date;












                string getZoneQuari = "SELECT MT.* , T.Tenants_Arabic_Name , B.Building_Arabic_Name , " +
                "(SELECT IF(Clean= 1, '✔', '')) R_Clean  , " +
                "(SELECT IF(Save= 1, '✔', '')) R_Save  , " +
                "(SELECT IF(Maintenece= 1, '✔', '')) R_Maintenece  , " +
                "(SELECT IF(disclaimer= 1, '✔', '')) R_disclaimer ,  " +
                "(SELECT IF(Last_Maintenece_Type= 1, 'دورية', 'حادثة')) R_Last_Maintenece_Type , " +
                "(SELECT IF(Last_Clean_Type= 1, 'دورية', 'حادثة')) R_Last_Clean_Type  " +
                "FROM maintenece_templete MT " +
                " left join tenants T on (MT.Employee_ID = T.Tenants_ID) " +
                "left join building B on (MT.Building_ID = B.Building_Id) " +
                "where Employee_ID = '" + Label1.Text + "' " +
                "and MT.Building_ID = '" + Label3.Text + "' and Date='" + Label5.Text + "'";




                MySqlCommand getZoneCmd = new MySqlCommand(getZoneQuari, _sqlCon);
                MySqlDataAdapter getZoneDt = new MySqlDataAdapter(getZoneCmd);
                getZoneCmd.Connection = _sqlCon;
                getZoneDt.SelectCommand = getZoneCmd;
                DataTable getZoneDataTable = new DataTable();
                getZoneDt.Fill(getZoneDataTable);
                Repeater1.DataSource = getZoneDataTable;
                Repeater1.DataBind();

                printt.Visible = true;


                _sqlCon.Close();

            }
        }

       
    }
}