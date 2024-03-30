using Syncfusion.JavaScript.DataVisualization.Models;
using System;
using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Main_Real_estate.Models;
using System.Web.UI.WebControls;
using Syncfusion.JavaScript.Models;
using System.Web.Services.Description;
using Main_Real_estate.English.Master_Panal;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Amlak_Dashboard : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DDL(DDL_Expenses_Year);
                //--------------------------------------------------------------------------------------------------------------------------------
                DDL_Expenses_Month.Items.Insert(0, "كل الأشهر");
                //--------------------------------------------------------------------------------------------------------------------------------
                Helper.LoadDropDownList("SELECT * FROM owner_ship", _sqlCon, DDL_Expenses_Ownership, "Owner_Ship_AR_Name", "Owner_Ship_Id");
                DDL_Expenses_Ownership.Items.Insert(0, "كل الملكيات");
                //--------------------------------------------------------------------------------------------------------------------------------
                DDL_Expenses_Building.Items.Insert(0, "كل الأبنية");
                //--------------------------------------------------------------------------------------------------------------------------------



                DDL(DDL_Rental_Value_Year);
                //--------------------------------------------------------------------------------------------------------------------------------
                DDL_Rental_Value_Month.Items.Insert(0, "كل الأشهر");
                //--------------------------------------------------------------------------------------------------------------------------------
                Helper.LoadDropDownList("SELECT * FROM owner_ship", _sqlCon, DDL_Rental_Value_Ownership, "Owner_Ship_AR_Name", "Owner_Ship_Id");
                DDL_Rental_Value_Ownership.Items.Insert(0, "كل الملكيات");
                //--------------------------------------------------------------------------------------------------------------------------------
                DDL_Rental_Value_Building.Items.Insert(0, "كل الأبنية");
                //--------------------------------------------------------------------------------------------------------------------------------
                Expensess(); Rental_Value();
            }
        }
        //******************************************************** المصاريف  ******************************************************************
        protected void Expensess()
        {
            string Mounth; string O_ID; string B_ID;
            if (DDL_Expenses_Month.SelectedItem.Text == "كل الأشهر") { Mounth = ""; } else { Mounth = "and Mounth = '" + DDL_Expenses_Month.SelectedValue + "'"; }
            if (DDL_Expenses_Ownership.SelectedItem.Text== "كل الملكيات") { O_ID = ""; } else { O_ID = "and Ownersip_Id = '" + DDL_Expenses_Ownership.SelectedValue + "'"; }
            if (DDL_Expenses_Building.SelectedItem.Text == "كل الأبنية") { B_ID = ""; } else { B_ID = "and Building_Id = '" + DDL_Expenses_Building.SelectedValue + "'"; }

            string Quary = 
            "select (SELECT IF(sum(RealEstate_Expenses)!='', sum(RealEstate_Expenses), 0)from  collection_table where Year = '" + DDL_Expenses_Year .SelectedItem.Text+ "' "+ Mounth + " "+ O_ID + " "+ B_ID + ") RealEstate_Expenses , " +
            "(SELECT IF(sum(Maintenance_Expenses)!='', sum(Maintenance_Expenses), 0)from  collection_table where Year = '" + DDL_Expenses_Year .SelectedItem.Text + "' "+ Mounth + " "+ O_ID + " "+ B_ID + ") Maintenance_Expenses , "  +
            "(SELECT IF(sum(Management_Expensess)!='', sum(Management_Expensess), 0)from management_expensess where Year='" + DDL_Expenses_Year .SelectedItem.Text + "' "+ Mounth + ")management_expensess";
            MySqlDataAdapter CollectionSda = new MySqlDataAdapter(Quary, _sqlCon);
            DataTable getCollectionDt = new DataTable();
            CollectionSda.Fill(getCollectionDt);
            if (getCollectionDt.Rows.Count > 0) 
            {
                Syncfusion.JavaScript.DataVisualization.Models.Series series1 = Expenses_Chart.Series[0];
                List<ColumnChartData> data = new List<ColumnChartData>();
                data.Add(new ColumnChartData
                ("المصاريف لكافة العقارات", 
                Convert.ToDouble(getCollectionDt.Rows[0]["RealEstate_Expenses"].ToString()),
                Convert.ToDouble(getCollectionDt.Rows[0]["Maintenance_Expenses"].ToString()), 
                Convert.ToDouble(getCollectionDt.Rows[0]["management_expensess"].ToString())));
                this.Expenses_Chart.DataSource = data;
                this.Expenses_Chart.DataBind();
            }
        }
        //******************************************************** القيمة الإيجارية  ******************************************************************
        protected void Rental_Value()
        {
            string Expected;
            string Mounth; string O_ID; string B_ID;
            if (DDL_Rental_Value_Month.SelectedItem.Text == "كل الأشهر") { Mounth = ""; } else { Mounth = "and Mounth = '" + DDL_Rental_Value_Month.SelectedValue + "'"; }
            if (DDL_Rental_Value_Ownership.SelectedItem.Text == "كل الملكيات") { O_ID = ""; } else { O_ID = "and O_ID = '" + DDL_Rental_Value_Ownership.SelectedValue + "'"; }
            if (DDL_Rental_Value_Building.SelectedItem.Text == "كل الأبنية") { B_ID = ""; } else { B_ID = "and Building_Id = '" + DDL_Rental_Value_Building.SelectedValue + "'"; }

            string Quary =
            "select sum(Amount) Expected from (Select (SELECT CAST(CONCAT('U_Cq/' ,Cq.Cheques_Id)as char))Id  , Cq.Cheques_Date as Datee  ,Cq.Cheques_Amount as  Amount, " +
            "(select units_Unit_ID from contract where Contract_Id = Cq.contract_Contract_Id )U_ID ,  " +
            "(select building_Building_Id from units where Unit_ID=U_ID ) B_ID, " +
            "(select owner_ship_Owner_Ship_Id from building where Building_Id= B_ID) O_ID ,  " +
            "(select Owner_Ship_AR_Name from owner_ship where Owner_Ship_Id=O_ID)O_Name from cheques Cq  " +
            "Union All " +
            "Select (SELECT CAST(CONCAT('B_Cq/' ,Cq.Cheques_Id)as char) )Id , Cq.Cheques_Date as Datee  ,Cq.Cheques_Amount as  Amount , " +
            "(select building_Building_Id from building_contract where Contract_Id = Cq.building_contract_Contract_Id )B_ID ,  " +
            "(select building_Building_Id from building_contract where Contract_Id = Cq.building_contract_Contract_Id )B_ID , " +
            "(select owner_ship_Owner_Ship_Id from building where Building_Id=B_ID ) O_ID ,  " +
            "(select Owner_Ship_AR_Name from owner_ship where Owner_Ship_Id=O_ID)O_Name from building_cheques Cq  " +
            "Union All " +
            "select  (SELECT CAST(CONCAT('U_Tr/' ,T.transformation_Table_ID)as char))Id , T.transformation_Date as Datee , T.Amount as  Amount , " +
            "(select units_Unit_ID from contract where Contract_Id = T.Contract_Id )U_ID , " +
            "(select building_Building_Id from units where Unit_ID=U_ID ) B_ID, " +
            "(select owner_ship_Owner_Ship_Id from building where Building_Id= B_ID) O_ID ,  " +
            "(select Owner_Ship_AR_Name  from owner_ship where Owner_Ship_Id=O_ID)O_Name from transformation_table T  " +
            "Union All " +
            "select (SELECT CAST(CONCAT('B_Tr/' ,T.transformation_Table_ID)as char) )Id  , T.transformation_Date as Datee , T.Amount as  Amount , " +
            "(select building_Building_Id from building_contract where Contract_Id = T.Contract_Id )B_ID ,  " +
            "(select building_Building_Id from building_contract where Contract_Id = T.Contract_Id )B_ID , " +
            "(select owner_ship_Owner_Ship_Id from building where Building_Id=B_ID ) O_ID ,  " +
            "(select Owner_Ship_AR_Name  from owner_ship where Owner_Ship_Id=O_ID)O_Name from building_transformation_table T " +
            "Union All " +
            "Select (SELECT CAST(CONCAT('U_Ca/' ,CA.Cash_Amount_ID)as char) )Id  ,  CA.Cash_Date as Datee , CA.Cash_Amount as  Amount ,   " +
            "(select units_Unit_ID from contract where Contract_Id = CA.Contract_Id )U_ID , " +
            "(select building_Building_Id from units where Unit_ID=U_ID ) B_ID, " +
            "(select owner_ship_Owner_Ship_Id from building where Building_Id= B_ID) O_ID , " +
            "(select Owner_Ship_AR_Name  from owner_ship where Owner_Ship_Id=O_ID)O_Name from cash_amount CA " +
            "Union All " +
            "Select (SELECT CAST(CONCAT('B_Ca/' ,CA.Cash_Amount_ID)as char) )Id ,   CA.Cash_Date as Datee , CA.Cash_Amount as  Amount ,   " +
            "(select building_Building_Id from building_contract where Contract_Id = CA.Contract_Id )B_ID ,  " +
            "(select building_Building_Id from building_contract where Contract_Id = CA.Contract_Id )B_ID , " +
            "(select owner_ship_Owner_Ship_Id from building where Building_Id=B_ID ) O_ID ,  " +
            "(select Owner_Ship_AR_Name  from owner_ship where Owner_Ship_Id=O_ID)O_Name from building_cash_amount CA )a where SUBSTRING(Datee,7,4) = '"+DDL_Rental_Value_Year.SelectedItem.Text+"' " + O_ID + " "+ B_ID + "  ";
            MySqlDataAdapter CollectionSda = new MySqlDataAdapter(Quary, _sqlCon);
            DataTable getCollectionDt = new DataTable();
            CollectionSda.Fill(getCollectionDt);
            if (getCollectionDt.Rows.Count > 0)
            {
                if (getCollectionDt.Rows[0]["Expected"].ToString() == "") { Expected = "0"; } else { Expected = getCollectionDt.Rows[0]["Expected"].ToString(); }
                Syncfusion.JavaScript.DataVisualization.Models.Series series1 = Rental_Value_Chart.Series[0];
                List<ColumnChartData> data = new List<ColumnChartData>();
                data.Add(new ColumnChartData
                ("المصاريف لكافة العقارات",
                Convert.ToDouble(Expected),
                Convert.ToDouble(10000),
                Convert.ToDouble(10000)));
                this.Rental_Value_Chart.DataSource = data;
                this.Rental_Value_Chart.DataBind();
            }
        }








































        //******************************************************** DropDownLists  ******************************************************************
        //-------------------------------------------------------- Expenses ------------------------------------------------------------------------ 
        protected void DDL( DropDownList DDL)
        {
            int year = DateTime.Now.Year; int Mounth = DateTime.Now.Month;
            for (int i = year - 5; i <= year + 10; i++)
            { ListItem li = new ListItem(i.ToString());  DDL.Items.Add(li);  }
            DDL.Items.FindByText("2023").Selected = true;
        }
        protected void DDL_Expenses_Year_SelectedIndexChanged(object sender, EventArgs e) {Expensess(); }
        protected void DDL_Expenses_Ownership_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Fill Building DropDownList
            Helper.LoadDropDownList("SELECT * FROM building where  Active != 0 and owner_ship_Owner_Ship_Id='" + DDL_Expenses_Ownership.SelectedValue + "'", _sqlCon, DDL_Expenses_Building, "Building_Arabic_Name", "Building_Id");
            DDL_Expenses_Building.Items.Insert(0, "كل الأبنية");Expensess();
        }
        protected void DDL_Expenses_Building_SelectedIndexChanged(object sender, EventArgs e) {Expensess();}
        protected void DDL_Expenses_Month_SelectedIndexChanged(object sender, EventArgs e) { Expensess(); }

        //-------------------------------------------------------- Rental Value ------------------------------------------------------------------------
        protected void DDL_Rental_Value_Month_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDL_Rental_Value_Year_SelectedIndexChanged(object sender, EventArgs e){Rental_Value(); }
        protected void DDL_Rental_Value_Ownership_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Fill Building DropDownList
            Helper.LoadDropDownList("SELECT * FROM building where  Active != 0 and owner_ship_Owner_Ship_Id='" + DDL_Rental_Value_Ownership.SelectedValue + "'", _sqlCon, DDL_Rental_Value_Building, "Building_Arabic_Name", "Building_Id");
            DDL_Rental_Value_Building.Items.Insert(0, "كل الأبنية"); Rental_Value();
        }
        protected void DDL_Rental_Value_Building_SelectedIndexChanged(object sender, EventArgs e) {Rental_Value(); }
    }
}