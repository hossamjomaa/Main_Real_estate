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


using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;

namespace Main_Real_estate.English.Main_Application
{
    public partial class DashBoard : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            if (!this.IsPostBack)
            {
                // Get OwnerShip Count
                DataTable getOwnerShipDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getOwnerShipCmd = new MySqlCommand("select ( select count(*) from owner_ship)as OwnwerShip_Count", _sqlCon);
                MySqlDataAdapter getOwnerShipDa = new MySqlDataAdapter(getOwnerShipCmd);
                getOwnerShipDa.Fill(getOwnerShipDt);
                if (getOwnerShipDt.Rows.Count > 0)
                { lbl_OwnerShip_Count.Text = getOwnerShipDt.Rows[0]["OwnwerShip_Count"].ToString(); }
                _sqlCon.Close();


                // Get Building Count
                DataTable getBuildingDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getBuildingCmd = new MySqlCommand("select ( select count(*) from building where Active != 0)as building_Count", _sqlCon);
                MySqlDataAdapter getBuildingDa = new MySqlDataAdapter(getBuildingCmd);
                getBuildingDa.Fill(getBuildingDt);
                if (getBuildingDt.Rows.Count > 0)
                { lbl_Building_Count.Text = getBuildingDt.Rows[0]["building_Count"].ToString(); }
                _sqlCon.Close();


                // Get Units Count
                DataTable getUnitsDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getUnitsCmd = new MySqlCommand("select ( select count(*) from units where Half != 1)as units_Count", _sqlCon);
                MySqlDataAdapter getUnitsDa = new MySqlDataAdapter(getUnitsCmd);
                getUnitsDa.Fill(getUnitsDt);
                if (getUnitsDt.Rows.Count > 0)
                { lbl_Units_Count.Text = getUnitsDt.Rows[0]["units_Count"].ToString(); }
                _sqlCon.Close();



                // Fill Year &Mounth  DropDownList
                int year = DateTime.Now.Year; int Mounth = DateTime.Now.Month;
                for (int i = year - 5; i <= year + 10; i++)
                {
                    ListItem li = new ListItem(i.ToString());
                    Year_DropDownList.Items.Add(li);
                }
                Year_DropDownList.Items.FindByText("2023").Selected = true;
                //*************************************************************************
                // Fill OWnersip DropDownList
                Helper.LoadDropDownList("SELECT * FROM owner_ship", _sqlCon, Ownership_Name_DropDownList, "Owner_Ship_AR_Name", "Owner_Ship_Id");
                Ownership_Name_DropDownList.Items.Insert(0, "كل الملكيات");
                //****************************************************************************
                Mounth_DropDownList.Items.Insert(0, "كل الأشهر");

                DashBoard_Function();



            }
            //}
            //catch
            //{
            //    Response.Redirect(Request.RawUrl);
            //}


            // *********************************************************** جلب قيم لوحة المؤشرات *************************************************
        }
        protected void DashBoard_Function()
        {

            string Year = Year_DropDownList.SelectedValue; string Mounth = Mounth_DropDownList.SelectedValue;
            string OwnerShip = Ownership_Name_DropDownList.SelectedValue; string Building = Building_Name_DropDownList.SelectedValue;

            double Sum_virtual_Value = 0;

            string Collection_D_Y = "0";
            string Management_Expenses_D_Y = "0";
            string RealEstate_Expenses_D_Y = "0";
            string Maintenance_Expenses_D_Y = "0";

            string Collection_D_Y_O = "0";
            string Management_Expenses_D_Y_O = "0";
            string RealEstate_Expenses_D_Y_O = "0";
            string Maintenance_Expenses_D_Y_O = "0";

            string Collection_D_Y_O_B = "0";
            string Management_Expenses_D_Y_O_B = "0";
            string RealEstate_Expenses_D_Y_O_B = "0";
            string Maintenance_Expenses_D_Y_O_B = "0";

            string Collection_D_Y_M = "0";
            string Management_Expenses_D_Y_M = "0";
            string RealEstate_Expenses_D_Y_M = "0";
            string Maintenance_Expenses_D_Y_M = "0";

            string Collection_D_Y_M_O = "0";
            string Management_Expenses_D_Y_M_O = "0";
            string RealEstate_Expenses_D_Y_M_O = "0";
            string Maintenance_Expenses_D_Y_M_O = "0";

            string Collection_D_Y_M_O_B = "0";
            string Management_Expenses_D_Y_M_O_B = "0";
            string RealEstate_Expenses_D_Y_M_O_B = "0";
            string Maintenance_Expenses_D_Y_M_O_B = "0";

            double Sum_Expected_Y_M_1 = 0; double Sum_Expected_Y_M_5 = 0; double Sum_Expected_Y_M_9 = 0;
            double Sum_Expected_Y_M_2 = 0; double Sum_Expected_Y_M_6 = 0; double Sum_Expected_Y_M_10 = 0;
            double Sum_Expected_Y_M_3 = 0; double Sum_Expected_Y_M_7 = 0; double Sum_Expected_Y_M_11 = 0;
            double Sum_Expected_Y_M_4 = 0; double Sum_Expected_Y_M_8 = 0; double Sum_Expected_Y_M_12 = 0;



            double Sum_Expected_Y_O_M_1 = 0; double Sum_Expected_Y_O_M_5 = 0; double Sum_Expected_Y_O_M_9 = 0;
            double Sum_Expected_Y_O_M_2 = 0; double Sum_Expected_Y_O_M_6 = 0; double Sum_Expected_Y_O_M_10 = 0;
            double Sum_Expected_Y_O_M_3 = 0; double Sum_Expected_Y_O_M_7 = 0; double Sum_Expected_Y_O_M_11 = 0;
            double Sum_Expected_Y_O_M_4 = 0; double Sum_Expected_Y_O_M_8 = 0; double Sum_Expected_Y_O_M_12 = 0;



            double Sum_Expected_Y_O_B_M_1 = 0; double Sum_Expected_Y_O_B_M_5 = 0; double Sum_Expected_Y_O_B_M_9 = 0;
            double Sum_Expected_Y_O_B_M_2 = 0; double Sum_Expected_Y_O_B_M_6 = 0; double Sum_Expected_Y_O_B_M_10 = 0;
            double Sum_Expected_Y_O_B_M_3 = 0; double Sum_Expected_Y_O_B_M_7 = 0; double Sum_Expected_Y_O_B_M_11 = 0;
            double Sum_Expected_Y_O_B_M_4 = 0; double Sum_Expected_Y_O_B_M_8 = 0; double Sum_Expected_Y_O_B_M_12 = 0;



            string Sum_Income_Y_M_1 = "0"; string Sum_Income_Y_M_5 = "0"; string Sum_Income_Y_M_9 = "0";
            string Sum_Income_Y_M_2 = "0"; string Sum_Income_Y_M_6 = "0"; string Sum_Income_Y_M_10 = "0";
            string Sum_Income_Y_M_3 = "0"; string Sum_Income_Y_M_7 = "0"; string Sum_Income_Y_M_11 = "0";
            string Sum_Income_Y_M_4 = "0"; string Sum_Income_Y_M_8 = "0"; string Sum_Income_Y_M_12 = "0";

            string Sum_Income_Y_O_M_1 = "0"; string Sum_Income_Y_O_M_5 = "0"; string Sum_Income_Y_O_M_9 = "0";
            string Sum_Income_Y_O_M_2 = "0"; string Sum_Income_Y_O_M_6 = "0"; string Sum_Income_Y_O_M_10 = "0";
            string Sum_Income_Y_O_M_3 = "0"; string Sum_Income_Y_O_M_7 = "0"; string Sum_Income_Y_O_M_11 = "0";
            string Sum_Income_Y_O_M_4 = "0"; string Sum_Income_Y_O_M_8 = "0"; string Sum_Income_Y_O_M_12 = "0";

            string Sum_Income_Y_O_B_M_1 = "0"; string Sum_Income_Y_O_B_M_5 = "0"; string Sum_Income_Y_O_B_M_9 = "0";
            string Sum_Income_Y_O_B_M_2 = "0"; string Sum_Income_Y_O_B_M_6 = "0"; string Sum_Income_Y_O_B_M_10 = "0";
            string Sum_Income_Y_O_B_M_3 = "0"; string Sum_Income_Y_O_B_M_7 = "0"; string Sum_Income_Y_O_B_M_11 = "0";
            string Sum_Income_Y_O_B_M_4 = "0"; string Sum_Income_Y_O_B_M_8 = "0"; string Sum_Income_Y_O_B_M_12 = "0";


            string Sum_Management_Expenses_Y_M_1 = "0"; string Sum_Management_Expenses_Y_M_5 = "0"; string Sum_Management_Expenses_Y_M_9 = "0";
            string Sum_Management_Expenses_Y_M_2 = "0"; string Sum_Management_Expenses_Y_M_6 = "0"; string Sum_Management_Expenses_Y_M_10 = "0";
            string Sum_Management_Expenses_Y_M_3 = "0"; string Sum_Management_Expenses_Y_M_7 = "0"; string Sum_Management_Expenses_Y_M_11 = "0";
            string Sum_Management_Expenses_Y_M_4 = "0"; string Sum_Management_Expenses_Y_M_8 = "0"; string Sum_Management_Expenses_Y_M_12 = "0";

            string Sum_Management_Expenses_Y_O_M_1 = "0"; string Sum_Management_Expenses_Y_O_M_5 = "0"; string Sum_Management_Expenses_Y_O_M_9 = "0";
            string Sum_Management_Expenses_Y_O_M_2 = "0"; string Sum_Management_Expenses_Y_O_M_6 = "0"; string Sum_Management_Expenses_Y_O_M_10 = "0";
            string Sum_Management_Expenses_Y_O_M_3 = "0"; string Sum_Management_Expenses_Y_O_M_7 = "0"; string Sum_Management_Expenses_Y_O_M_11 = "0";
            string Sum_Management_Expenses_Y_O_M_4 = "0"; string Sum_Management_Expenses_Y_O_M_8 = "0"; string Sum_Management_Expenses_Y_O_M_12 = "0";

            string Sum_RealEstate_Expenses_Y_M_1 = "0"; string Sum_RealEstate_Expenses_Y_M_5 = "0"; string Sum_RealEstate_Expenses_Y_M_9 = "0";
            string Sum_RealEstate_Expenses_Y_M_2 = "0"; string Sum_RealEstate_Expenses_Y_M_6 = "0"; string Sum_RealEstate_Expenses_Y_M_10 = "0";
            string Sum_RealEstate_Expenses_Y_M_3 = "0"; string Sum_RealEstate_Expenses_Y_M_7 = "0"; string Sum_RealEstate_Expenses_Y_M_11 = "0";
            string Sum_RealEstate_Expenses_Y_M_4 = "0"; string Sum_RealEstate_Expenses_Y_M_8 = "0"; string Sum_RealEstate_Expenses_Y_M_12 = "0";

            string Sum_RealEstate_Expenses_Y_O_M_1 = "0"; string Sum_RealEstate_Expenses_Y_O_M_5 = "0"; string Sum_RealEstate_Expenses_Y_O_M_9 = "0";
            string Sum_RealEstate_Expenses_Y_O_M_2 = "0"; string Sum_RealEstate_Expenses_Y_O_M_6 = "0"; string Sum_RealEstate_Expenses_Y_O_M_10 = "0";
            string Sum_RealEstate_Expenses_Y_O_M_3 = "0"; string Sum_RealEstate_Expenses_Y_O_M_7 = "0"; string Sum_RealEstate_Expenses_Y_O_M_11 = "0";
            string Sum_RealEstate_Expenses_Y_O_M_4 = "0"; string Sum_RealEstate_Expenses_Y_O_M_8 = "0"; string Sum_RealEstate_Expenses_Y_O_M_12 = "0";

            string Sum_Maintenance_Expenses_Y_M_1 = "0"; string Sum_Maintenance_Expenses_Y_M_5 = "0"; string Sum_Maintenance_Expenses_Y_M_9 = "0";
            string Sum_Maintenance_Expenses_Y_M_2 = "0"; string Sum_Maintenance_Expenses_Y_M_6 = "0"; string Sum_Maintenance_Expenses_Y_M_10 = "0";
            string Sum_Maintenance_Expenses_Y_M_3 = "0"; string Sum_Maintenance_Expenses_Y_M_7 = "0"; string Sum_Maintenance_Expenses_Y_M_11 = "0";
            string Sum_Maintenance_Expenses_Y_M_4 = "0"; string Sum_Maintenance_Expenses_Y_M_8 = "0"; string Sum_Maintenance_Expenses_Y_M_12 = "0";

            string Sum_Maintenance_Expenses_Y_O_M_1 = "0"; string Sum_Maintenance_Expenses_Y_O_M_5 = "0"; string Sum_Maintenance_Expenses_Y_O_M_9 = "0";
            string Sum_Maintenance_Expenses_Y_O_M_2 = "0"; string Sum_Maintenance_Expenses_Y_O_M_6 = "0"; string Sum_Maintenance_Expenses_Y_O_M_10 = "0";
            string Sum_Maintenance_Expenses_Y_O_M_3 = "0"; string Sum_Maintenance_Expenses_Y_O_M_7 = "0"; string Sum_Maintenance_Expenses_Y_O_M_11 = "0";
            string Sum_Maintenance_Expenses_Y_O_M_4 = "0"; string Sum_Maintenance_Expenses_Y_O_M_8 = "0"; string Sum_Maintenance_Expenses_Y_O_M_12 = "0";

            string Sum_Management_Expenses_Y_O_B_M_1 = "0"; string Sum_Management_Expenses_Y_O_B_M_5 = "0"; string Sum_Management_Expenses_Y_O_B_M_9 = "0";
            string Sum_Management_Expenses_Y_O_B_M_2 = "0"; string Sum_Management_Expenses_Y_O_B_M_6 = "0"; string Sum_Management_Expenses_Y_O_B_M_10 = "0";
            string Sum_Management_Expenses_Y_O_B_M_3 = "0"; string Sum_Management_Expenses_Y_O_B_M_7 = "0"; string Sum_Management_Expenses_Y_O_B_M_11 = "0";
            string Sum_Management_Expenses_Y_O_B_M_4 = "0"; string Sum_Management_Expenses_Y_O_B_M_8 = "0"; string Sum_Management_Expenses_Y_O_B_M_12 = "0";

            string Sum_RealEstate_Expenses_Y_O_B_M_1 = "0"; string Sum_RealEstate_Expenses_Y_O_B_M_5 = "0"; string Sum_RealEstate_Expenses_Y_O_B_M_9 = "0";
            string Sum_RealEstate_Expenses_Y_O_B_M_2 = "0"; string Sum_RealEstate_Expenses_Y_O_B_M_6 = "0"; string Sum_RealEstate_Expenses_Y_O_B_M_10 = "0";
            string Sum_RealEstate_Expenses_Y_O_B_M_3 = "0"; string Sum_RealEstate_Expenses_Y_O_B_M_7 = "0"; string Sum_RealEstate_Expenses_Y_O_B_M_11 = "0";
            string Sum_RealEstate_Expenses_Y_O_B_M_4 = "0"; string Sum_RealEstate_Expenses_Y_O_B_M_8 = "0"; string Sum_RealEstate_Expenses_Y_O_B_M_12 = "0";

            string Sum_Maintenance_Expenses_Y_O_B_M_1 = "0"; string Sum_Maintenance_Expenses_Y_O_B_M_5 = "0"; string Sum_Maintenance_Expenses_Y_O_B_M_9 = "0";
            string Sum_Maintenance_Expenses_Y_O_B_M_2 = "0"; string Sum_Maintenance_Expenses_Y_O_B_M_6 = "0"; string Sum_Maintenance_Expenses_Y_O_B_M_10 = "0";
            string Sum_Maintenance_Expenses_Y_O_B_M_3 = "0"; string Sum_Maintenance_Expenses_Y_O_B_M_7 = "0"; string Sum_Maintenance_Expenses_Y_O_B_M_11 = "0";
            string Sum_Maintenance_Expenses_Y_O_B_M_4 = "0"; string Sum_Maintenance_Expenses_Y_O_B_M_8 = "0"; string Sum_Maintenance_Expenses_Y_O_B_M_12 = "0";

            string Sum_Bulidng_Value = "0"; string Sum_Land_Value = "0";




            string Quary = "select(select Sum(Collection) from collection_table Where Year ='" + Year + "') Collection_D_Y," +
                            "(select Sum(Collection) from collection_table Where Year ='" + Year + "' And Ownersip_Id = '" + OwnerShip + "') Collection_D_Y_O," +
                            "(select Sum(Collection) from collection_table Where Year ='" + Year + "' And Ownersip_Id = '" + OwnerShip + "' And Building_Id = '" + Building + "') Collection_D_Y_O_B," +
                            "(select Sum(Collection) from collection_table Where Year ='" + Year + "' And Mounth = '" + Mounth + "') Collection_D_Y_M," +
                            "(select Sum(Collection) from collection_table Where Year ='" + Year + "' And Mounth = '" + Mounth + "' And Ownersip_Id = '" + OwnerShip + "') Collection_D_Y_M_O," +
                            "(select Sum(Collection) from collection_table Where Year ='" + Year + "' And Mounth = '" + Mounth + "' And Ownersip_Id = '" + OwnerShip + "' And Building_Id = '" + Building + "') Collection_D_Y_M_O_B," +
                           "(select Sum(Management_Expensess) from management_expensess Where Year ='" + Year + "') Management_Expenses_D_Y," +
                           "(select Sum(RealEstate_Expenses) from collection_table Where Year ='" + Year + "') RealEstate_Expenses_D_Y," +
                           "(select Sum(Maintenance_Expenses) from collection_table Where Year ='" + Year + "') Maintenance_Expenses_D_Y," +
                           "(select Sum(Management_Expensess) from management_expensess Where Year ='" + Year + "') Management_Expenses_D_Y_O," +
                           "(select Sum(RealEstate_Expenses) from collection_table Where Year ='" + Year + "' And Ownersip_Id = '" + OwnerShip + "') RealEstate_Expenses_D_Y_O," +
                           "(select Sum(Maintenance_Expenses) from collection_table Where Year ='" + Year + "' And Ownersip_Id = '" + OwnerShip + "') Maintenance_Expenses_D_Y_O," +
                           "(select Sum(Management_Expensess) from management_expensess Where Year ='" + Year + "' ) Management_Expenses_D_Y_O_B," +
                           "(select Sum(RealEstate_Expenses) from collection_table Where Year ='" + Year + "' And Ownersip_Id = '" + OwnerShip + "' And Building_Id = '" + Building + "') RealEstate_Expenses_D_Y_O_B," +
                           "(select Sum(Maintenance_Expenses) from collection_table Where Year ='" + Year + "' And Ownersip_Id = '" + OwnerShip + "' And Building_Id = '" + Building + "') Maintenance_Expenses_D_Y_O_B, " +
                           "(select Sum(Management_Expensess) from management_expensess Where Year ='" + Year + "' And Mounth = '" + Mounth + "') Management_Expenses_D_Y_M," +
                           "(select Sum(RealEstate_Expenses) from collection_table Where Year ='" + Year + "' And Mounth = '" + Mounth + "') RealEstate_Expenses_D_Y_M," +
                           "(select Sum(Maintenance_Expenses) from collection_table Where Year ='" + Year + "' And Mounth = '" + Mounth + "') Maintenance_Expenses_D_Y_M, " +
                           "(select Sum(Management_Expensess) from management_expensess Where Year ='" + Year + "' And Mounth = '" + Mounth + "' ) Management_Expenses_D_Y_M_O," +
                           "(select Sum(RealEstate_Expenses) from collection_table Where Year ='" + Year + "' And Mounth = '" + Mounth + "' And Ownersip_Id = '" + OwnerShip + "') RealEstate_Expenses_D_Y_M_O," +
                           "(select Sum(Maintenance_Expenses) from collection_table Where Year ='" + Year + "' And Mounth = '" + Mounth + "' And Ownersip_Id = '" + OwnerShip + "') Maintenance_Expenses_D_Y_M_O , " +
                           "(select Sum(Management_Expensess) from management_expensess Where Year ='" + Year + "' And Mounth = '" + Mounth + "') Management_Expenses_D_Y_M_O_B," +
                           "(select Sum(RealEstate_Expenses) from collection_table Where Year ='" + Year + "' And Mounth = '" + Mounth + "' And Ownersip_Id = '" + OwnerShip + "' And Building_Id = '" + Building + "') RealEstate_Expenses_D_Y_M_O_B," +
                           "(select Sum(Maintenance_Expenses) from collection_table Where Year ='" + Year + "' And Mounth = '" + Mounth + "' And Ownersip_Id = '" + OwnerShip + "' And Building_Id = '" + Building + "') Maintenance_Expenses_D_Y_M_O_B ";

            MySqlDataAdapter CollectionSda = new MySqlDataAdapter(Quary, _sqlCon);
            DataTable getCollectionDt = new DataTable();
            CollectionSda.Fill(getCollectionDt);
            if (getCollectionDt.Rows.Count > 0)
            {
                if (getCollectionDt.Rows[0]["Collection_D_Y"].ToString() == "") { Collection_D_Y = "0"; } else { Collection_D_Y = getCollectionDt.Rows[0]["Collection_D_Y"].ToString(); }
                if (getCollectionDt.Rows[0]["Collection_D_Y_O"].ToString() == "") { Collection_D_Y_O = "0"; } else { Collection_D_Y_O = getCollectionDt.Rows[0]["Collection_D_Y_O"].ToString(); }
                if (getCollectionDt.Rows[0]["Collection_D_Y_O_B"].ToString() == "") { Collection_D_Y_O_B = "0"; } else { Collection_D_Y_O_B = getCollectionDt.Rows[0]["Collection_D_Y_O_B"].ToString(); }
                if (getCollectionDt.Rows[0]["Collection_D_Y_M"].ToString() == "") { Collection_D_Y_M = "0"; } else { Collection_D_Y_M = getCollectionDt.Rows[0]["Collection_D_Y_M"].ToString(); }
                if (getCollectionDt.Rows[0]["Collection_D_Y_M_O"].ToString() == "") { Collection_D_Y_M_O = "0"; } else { Collection_D_Y_M_O = getCollectionDt.Rows[0]["Collection_D_Y_M_O"].ToString(); }
                if (getCollectionDt.Rows[0]["Collection_D_Y_M_O_B"].ToString() == "") { Collection_D_Y_M_O_B = "0"; } else { Collection_D_Y_M_O_B = getCollectionDt.Rows[0]["Collection_D_Y_M_O_B"].ToString(); }



                if (getCollectionDt.Rows[0]["Management_Expenses_D_Y"].ToString() == "") { Management_Expenses_D_Y = "0"; } else { Management_Expenses_D_Y = getCollectionDt.Rows[0]["Management_Expenses_D_Y"].ToString(); }
                if (getCollectionDt.Rows[0]["RealEstate_Expenses_D_Y"].ToString() == "") { RealEstate_Expenses_D_Y = "0"; } else { RealEstate_Expenses_D_Y = getCollectionDt.Rows[0]["RealEstate_Expenses_D_Y"].ToString(); }
                if (getCollectionDt.Rows[0]["Maintenance_Expenses_D_Y"].ToString() == "") { Maintenance_Expenses_D_Y = "0"; } else { Maintenance_Expenses_D_Y = getCollectionDt.Rows[0]["Maintenance_Expenses_D_Y"].ToString(); }

                if (getCollectionDt.Rows[0]["Management_Expenses_D_Y_O"].ToString() == "") { Management_Expenses_D_Y_O = "0"; } else { Management_Expenses_D_Y_O = getCollectionDt.Rows[0]["Management_Expenses_D_Y_O"].ToString(); }
                if (getCollectionDt.Rows[0]["RealEstate_Expenses_D_Y_O"].ToString() == "") { RealEstate_Expenses_D_Y_O = "0"; } else { RealEstate_Expenses_D_Y_O = getCollectionDt.Rows[0]["RealEstate_Expenses_D_Y_O"].ToString(); }
                if (getCollectionDt.Rows[0]["Maintenance_Expenses_D_Y_O"].ToString() == "") { Maintenance_Expenses_D_Y_O = "0"; } else { Maintenance_Expenses_D_Y_O = getCollectionDt.Rows[0]["Maintenance_Expenses_D_Y_O"].ToString(); }

                if (getCollectionDt.Rows[0]["Management_Expenses_D_Y_O_B"].ToString() == "") { Management_Expenses_D_Y_O_B = "0"; } else { Management_Expenses_D_Y_O_B = getCollectionDt.Rows[0]["Management_Expenses_D_Y_O_B"].ToString(); }
                if (getCollectionDt.Rows[0]["RealEstate_Expenses_D_Y_O_B"].ToString() == "") { RealEstate_Expenses_D_Y_O_B = "0"; } else { RealEstate_Expenses_D_Y_O_B = getCollectionDt.Rows[0]["RealEstate_Expenses_D_Y_O_B"].ToString(); }
                if (getCollectionDt.Rows[0]["Maintenance_Expenses_D_Y_O_B"].ToString() == "") { Maintenance_Expenses_D_Y_O_B = "0"; } else { Maintenance_Expenses_D_Y_O_B = getCollectionDt.Rows[0]["Maintenance_Expenses_D_Y_O_B"].ToString(); }

                if (getCollectionDt.Rows[0]["Management_Expenses_D_Y_M"].ToString() == "") { Management_Expenses_D_Y_M = "0"; } else { Management_Expenses_D_Y_M = getCollectionDt.Rows[0]["Management_Expenses_D_Y_M"].ToString(); }
                if (getCollectionDt.Rows[0]["RealEstate_Expenses_D_Y_M"].ToString() == "") { RealEstate_Expenses_D_Y_M = "0"; } else { RealEstate_Expenses_D_Y_M = getCollectionDt.Rows[0]["RealEstate_Expenses_D_Y_M"].ToString(); }
                if (getCollectionDt.Rows[0]["Maintenance_Expenses_D_Y_M"].ToString() == "") { Maintenance_Expenses_D_Y_M = "0"; } else { Maintenance_Expenses_D_Y_M = getCollectionDt.Rows[0]["Maintenance_Expenses_D_Y_M"].ToString(); }

                if (getCollectionDt.Rows[0]["Management_Expenses_D_Y_M_O"].ToString() == "") { Management_Expenses_D_Y_M_O = "0"; } else { Management_Expenses_D_Y_M_O = getCollectionDt.Rows[0]["Management_Expenses_D_Y_M_O"].ToString(); }
                if (getCollectionDt.Rows[0]["RealEstate_Expenses_D_Y_M_O"].ToString() == "") { RealEstate_Expenses_D_Y_M_O = "0"; } else { RealEstate_Expenses_D_Y_M_O = getCollectionDt.Rows[0]["RealEstate_Expenses_D_Y_M_O"].ToString(); }
                if (getCollectionDt.Rows[0]["Maintenance_Expenses_D_Y_M_O"].ToString() == "") { Maintenance_Expenses_D_Y_M_O = "0"; } else { Maintenance_Expenses_D_Y_M_O = getCollectionDt.Rows[0]["Maintenance_Expenses_D_Y_M_O"].ToString(); }

                if (getCollectionDt.Rows[0]["Management_Expenses_D_Y_M_O_B"].ToString() == "") { Management_Expenses_D_Y_M_O_B = "0"; } else { Management_Expenses_D_Y_M_O_B = getCollectionDt.Rows[0]["Management_Expenses_D_Y_M_O_B"].ToString(); }
                if (getCollectionDt.Rows[0]["RealEstate_Expenses_D_Y_M_O_B"].ToString() == "") { RealEstate_Expenses_D_Y_M_O_B = "0"; } else { RealEstate_Expenses_D_Y_M_O_B = getCollectionDt.Rows[0]["RealEstate_Expenses_D_Y_M_O_B"].ToString(); }
                if (getCollectionDt.Rows[0]["Maintenance_Expenses_D_Y_M_O_B"].ToString() == "") { Maintenance_Expenses_D_Y_M_O_B = "0"; } else { Maintenance_Expenses_D_Y_M_O_B = getCollectionDt.Rows[0]["Maintenance_Expenses_D_Y_M_O_B"].ToString(); }
                _sqlCon.Close();
            }

            if (Mounth_DropDownList.SelectedItem.Text == "كل الأشهر")
            {
                // 1-1
                if (Ownership_Name_DropDownList.SelectedItem.Text == "كل الملكيات")
                {
                    All_Building_Condition();
                    // **************************** النسب المئوية للجنسيات ********************************************************
                    percent_nationality_GridView();
                    Tenant_Evaluation();
                    //****************************** الرهن العقاري *****************************************************************
                    Mortgage_All();
                    //***************************************** حالات الوحدات *******************************************************
                    _sqlCon.Open();
                    string Available = "0"; string Rented = "0"; string Undermaintenance = "0"; string UnderProplem = "0";
                    string Quairy = @"SELECT (Select Count(*)FROM units where Half != 1 and unit_condition_Unit_Condition_Id = 1 )as Rented ,
                                (Select count(*) from units where Half != 1 and unit_condition_Unit_Condition_Id = 2) as Available  ,
                                (Select count(*) from units where Half != 1 and unit_condition_Unit_Condition_Id = 3) as Undermaintenance ,
                                (Select count(*) from units where Half != 1 and unit_condition_Unit_Condition_Id = 4) as UnderProplem; ";

                    DataTable getUnitStatusChartDt = new DataTable();
                    MySqlCommand getUnitStatusChartCmd = new MySqlCommand(Quairy, _sqlCon);
                    MySqlDataAdapter getUnitStatusChartDa = new MySqlDataAdapter(getUnitStatusChartCmd);
                    getUnitStatusChartDa.Fill(getUnitStatusChartDt);
                    if (getUnitStatusChartDt.Rows.Count > 0)
                    {
                        Available = getUnitStatusChartDt.Rows[0]["Available"].ToString();
                        Rented = getUnitStatusChartDt.Rows[0]["Rented"].ToString();
                        Undermaintenance = getUnitStatusChartDt.Rows[0]["Undermaintenance"].ToString();
                        UnderProplem = getUnitStatusChartDt.Rows[0]["UnderProplem"].ToString();
                    }
                    //-----------------------------------------------------------------------------------------------------------------------
                    double U_C = 0; double B_C = 0;
                    DataTable Dt = new DataTable();
                    MySqlCommand Cmd = new MySqlCommand("SELECT End_Date  FROM contract where New_ReNewed_Expaired = 1", _sqlCon);
                    MySqlDataAdapter Da = new MySqlDataAdapter(Cmd);
                    Da.Fill(Dt);
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        string EndDate = Dt.Rows[i]["End_Date"].ToString();
                        DateTime End_Date = Convert.ToDateTime(EndDate);
                        var today = DateTime.Now;
                        var diffOfDates = (End_Date - today).Days;
                        if (diffOfDates >= 0 && diffOfDates <= 60) { U_C++; }
                    }

                    DataTable Dt2 = new DataTable();
                    MySqlCommand Cmd2 = new MySqlCommand("SELECT End_Date  FROM building_contract where New_ReNewed_Expaired = 1 ", _sqlCon);
                    MySqlDataAdapter Da2 = new MySqlDataAdapter(Cmd2);
                    Da2.Fill(Dt2);
                    for (int i = 0; i < Dt2.Rows.Count; i++)
                    {
                        string EndDate = Dt2.Rows[i]["End_Date"].ToString();
                        DateTime End_Date = Convert.ToDateTime(EndDate);
                        var today = DateTime.Now;
                        var diffOfDates = (End_Date - today).Days;
                        if (diffOfDates >= 0 && diffOfDates <= 60) { B_C++; }
                    }
                    //-----------------------------------------------------------------------------------------------------------------------

                    _sqlCon.Close();
                    Syncfusion.JavaScript.DataVisualization.Models.Series series = Units_Statuse.Series[0];
                    series.Points.Clear();
                    series.Points.Add(new Points("شاغر", double.Parse(Available)));
                    series.Points.Add(new Points("مؤجر", double.Parse(Rented)));
                    series.Points.Add(new Points("تحت الانشاء أو الصيانة", double.Parse(Undermaintenance)));
                    series.Points.Add(new Points("موجد نزاع", double.Parse(UnderProplem)));
                    series.Points.Add(new Points("", 0));
                    series.Points.Add(new Points("قيد الإنتهاء", (U_C + B_C)));

                    // ********************************  المصاريف الإدارية و العقارية و الصيانة************************************
                    Syncfusion.JavaScript.DataVisualization.Models.Series series1 = Expenses_Chart.Series[0];
                    List<ColumnChartData> data = new List<ColumnChartData>();
                    data.Add(new ColumnChartData("المصاريف لكافة العقارات", Convert.ToDouble(Management_Expenses_D_Y), Convert.ToDouble(RealEstate_Expenses_D_Y), Convert.ToDouble(Maintenance_Expenses_D_Y)));
                    this.Expenses_Chart.DataSource = data;
                    this.Expenses_Chart.DataBind();

                    // ********************************    العائد الفعلي **********************************
                    double total_Expensess = Convert.ToDouble(Convert.ToDouble(Management_Expenses_D_Y) + Convert.ToDouble(RealEstate_Expenses_D_Y) + Convert.ToDouble(Maintenance_Expenses_D_Y));
                    lbl_Real_Income.Text = "العائد الفعلي";
                    double Real_Income = Convert.ToDouble(Collection_D_Y) - total_Expensess;
                    Syncfusion.JavaScript.DataVisualization.Models.Series Real_Income_series = Real_Income_Chart_2.Series[0];
                    List<ColumnChartData> Real_Income_data = new List<ColumnChartData>();
                    Real_Income_data.Add(new ColumnChartData("العائد الفعلي", Convert.ToDouble(Collection_D_Y), Real_Income, total_Expensess));
                    this.Real_Income_Chart_2.DataSource = Real_Income_data;
                    this.Real_Income_Chart_2.DataBind();
                    _sqlCon.Close();
                    //************************************* الربح الصافي **********************************************************
                    string Sum_Building_Value_Quary = "Select Sum(Building_Value)Sum_Building_Value From building";
                    string Sum_Building_Value = "0";
                    _sqlCon.Open();
                    MySqlDataAdapter VSum_Building_Value_Sda = new MySqlDataAdapter(Sum_Building_Value_Quary, _sqlCon);
                    DataTable VSum_Building_Value_Dt = new DataTable();
                    VSum_Building_Value_Sda.Fill(VSum_Building_Value_Dt);
                    if (VSum_Building_Value_Dt.Rows.Count > 0)
                    {
                        if (VSum_Building_Value_Dt.Rows[0]["Sum_Building_Value"].ToString() == "") { Sum_Building_Value = "0"; } else { Sum_Building_Value = VSum_Building_Value_Dt.Rows[0]["Sum_Building_Value"].ToString(); }
                    }
                    _sqlCon.Close();

                    Label1.Text = Convert.ToString(Convert.ToDouble(Sum_Building_Value) / Convert.ToDouble(txt_Destruction_Value.Text));

                    //الربح المجمل
                    Label2.Text = Convert.ToString((Convert.ToDouble(Collection_D_Y) - total_Expensess));

                    Label3.Text = Convert.ToString((Convert.ToDouble(Sum_Building_Value) / Convert.ToDouble(txt_Destruction_Value.Text)) - ((Convert.ToDouble(Collection_D_Y) - total_Expensess)));


                    Syncfusion.JavaScript.DataVisualization.Models.Series series_Chart2 = Chart2.Series[0];
                    List<ColumnChartData> data_Chart2 = new List<ColumnChartData>();
                    data_Chart2.Add(new ColumnChartData("", Convert.ToDouble(Label1.Text), Convert.ToDouble(Label3.Text), (Convert.ToDouble(Label2.Text))));
                    this.Chart2.DataSource = data_Chart2;
                    this.Chart2.DataBind();
                    //********************************* متبقي التوزيع  ************************************
                    string Sum_Remainder_Distribution_Quary = "select Sum(Salary)Sum_Salary  From owner ";
                    string Sum_Remainder_Distribution = "0";
                    _sqlCon.Open();
                    MySqlDataAdapter Sum_Remainder_Distribution_Sda = new MySqlDataAdapter(Sum_Remainder_Distribution_Quary, _sqlCon);
                    DataTable Sum_Remainder_Distribution_Dt = new DataTable();
                    Sum_Remainder_Distribution_Sda.Fill(Sum_Remainder_Distribution_Dt);
                    if (Sum_Remainder_Distribution_Dt.Rows.Count > 0)
                    {
                        if (Sum_Remainder_Distribution_Dt.Rows[0]["Sum_Salary"].ToString() == "") { Sum_Remainder_Distribution = "0"; } else { Sum_Remainder_Distribution = Sum_Remainder_Distribution_Dt.Rows[0]["Sum_Salary"].ToString(); }
                    }

                    //الرواتب
                    Label4.Text = Convert.ToString(Convert.ToDouble(Sum_Remainder_Distribution) * 12);

                    // الربح الصافي
                    Label5.Text = Label3.Text;

                    double X = Convert.ToDouble(Label5.Text) - Convert.ToDouble(Label4.Text);
                    Label6.Text = Convert.ToString(X);
                    Syncfusion.JavaScript.DataVisualization.Models.Series series_Chart3 = Chart3.Series[0];
                    List<ColumnChartData> data_Chart3 = new List<ColumnChartData>();
                    data_Chart3.Add(new ColumnChartData("", Convert.ToDouble(Label4.Text), Convert.ToDouble(Label5.Text), (Convert.ToDouble(Label6.Text))));
                    this.Chart3.DataSource = data_Chart3;
                    this.Chart3.DataBind();
                    _sqlCon.Close();
                    // ********************************    التدفق النقدي **********************************
                    lbl_Cash_Flow.Text = "التدفق النقدي لكافة الملكيات لعام " + Year_DropDownList.SelectedItem.Text;

                    _sqlCon.Open();
                    using (MySqlCommand Cash_flow_Cmd = new MySqlCommand("Dashboard_Test", _sqlCon))
                    {
                        Cash_flow_Cmd.CommandType = CommandType.StoredProcedure;
                        using (MySqlDataAdapter Cash_flow_Sda = new MySqlDataAdapter(Cash_flow_Cmd))
                        {
                            DataTable Cash_flow_Dt = new DataTable();
                            Cash_flow_Sda.Fill(Cash_flow_Dt);
                            if (Cash_flow_Dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < Cash_flow_Dt.Rows.Count; i++)
                                {
                                    string Y_Cheques_Date = Convert.ToString(Convert.ToDateTime(Cash_flow_Dt.Rows[i]["Datee"].ToString()).Year);
                                    string M_Cheques_Date = Convert.ToString(Convert.ToDateTime(Cash_flow_Dt.Rows[i]["Datee"].ToString()).Month);
                                    string O_ID = Cash_flow_Dt.Rows[i]["O_ID"].ToString();
                                    string B_ID = Cash_flow_Dt.Rows[i]["B_ID"].ToString();

                                    Label7.Text = Convert.ToString(Convert.ToDateTime(Cash_flow_Dt.Rows[1]["Datee"].ToString()).Month);


                                    if (M_Cheques_Date == "1" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_1 = Sum_Expected_Y_M_1 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "2" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_2 = Sum_Expected_Y_M_2 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "3" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_3 = Sum_Expected_Y_M_3 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "4" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_4 = Sum_Expected_Y_M_4 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "5" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_5 = Sum_Expected_Y_M_5 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "6" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_6 = Sum_Expected_Y_M_6 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "7" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_7 = Sum_Expected_Y_M_7 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "8" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_8 = Sum_Expected_Y_M_8 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "9" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_9 = Sum_Expected_Y_M_9 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "10" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_10 = Sum_Expected_Y_M_10 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "11" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_11 = Sum_Expected_Y_M_11 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "12" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_12 = Sum_Expected_Y_M_12 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }


                                }

                            }
                        }
                    }
                    _sqlCon.Close();
                    string Quary2 = "select " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '1')Sum_Income_Y_M_1,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '2')Sum_Income_Y_M_2,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '3')Sum_Income_Y_M_3,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '4')Sum_Income_Y_M_4,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '5')Sum_Income_Y_M_5,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '6')Sum_Income_Y_M_6,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '7')Sum_Income_Y_M_7,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '8')Sum_Income_Y_M_8, " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '9')Sum_Income_Y_M_9,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '10')Sum_Income_Y_M_10,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '11')Sum_Income_Y_M_11,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '12')Sum_Income_Y_M_12, " +

                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '1')Sum_Management_Expenses_Y_M_1,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '2')Sum_Management_Expenses_Y_M_2,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '3')Sum_Management_Expenses_Y_M_3,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '4')Sum_Management_Expenses_Y_M_4,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '5')Sum_Management_Expenses_Y_M_5,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '6')Sum_Management_Expenses_Y_M_6,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '7')Sum_Management_Expenses_Y_M_7,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '8')Sum_Management_Expenses_Y_M_8, " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '9')Sum_Management_Expenses_Y_M_9,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '10')Sum_Management_Expenses_Y_M_10,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '11')Sum_Management_Expenses_Y_M_11,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '12')Sum_Management_Expenses_Y_M_12 ," +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '1')Sum_RealEstate_Expenses_Y_M_1,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '2')Sum_RealEstate_Expenses_Y_M_2,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '3')Sum_RealEstate_Expenses_Y_M_3,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '4')Sum_RealEstate_Expenses_Y_M_4,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '5')Sum_RealEstate_Expenses_Y_M_5,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '6')Sum_RealEstate_Expenses_Y_M_6,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '7')Sum_RealEstate_Expenses_Y_M_7,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '8')Sum_RealEstate_Expenses_Y_M_8, " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '9')Sum_RealEstate_Expenses_Y_M_9,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '10')Sum_RealEstate_Expenses_Y_M_10,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '11')Sum_RealEstate_Expenses_Y_M_11,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '12')Sum_RealEstate_Expenses_Y_M_12, " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '1')Sum_Maintenance_Expenses_Y_M_1,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '2')Sum_Maintenance_Expenses_Y_M_2,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '3')Sum_Maintenance_Expenses_Y_M_3,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '4')Sum_Maintenance_Expenses_Y_M_4,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '5')Sum_Maintenance_Expenses_Y_M_5,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '6')Sum_Maintenance_Expenses_Y_M_6,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '7')Sum_Maintenance_Expenses_Y_M_7,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '8')Sum_Maintenance_Expenses_Y_M_8, " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '9')Sum_Maintenance_Expenses_Y_M_9,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '10')Sum_Maintenance_Expenses_Y_M_10,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '11')Sum_Maintenance_Expenses_Y_M_11,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '12')Sum_Maintenance_Expenses_Y_M_12";
                    _sqlCon.Open();
                    MySqlDataAdapter Collection_Expenses_Sda = new MySqlDataAdapter(Quary2, _sqlCon);
                    DataTable getCollection_Expenses_Dt = new DataTable();
                    Collection_Expenses_Sda.Fill(getCollection_Expenses_Dt);
                    if (getCollection_Expenses_Dt.Rows.Count > 0)
                    {
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_1"].ToString() == "") { Sum_Income_Y_M_1 = "0"; } else { Sum_Income_Y_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_2"].ToString() == "") { Sum_Income_Y_M_2 = "0"; } else { Sum_Income_Y_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_3"].ToString() == "") { Sum_Income_Y_M_3 = "0"; } else { Sum_Income_Y_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_4"].ToString() == "") { Sum_Income_Y_M_4 = "0"; } else { Sum_Income_Y_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_5"].ToString() == "") { Sum_Income_Y_M_5 = "0"; } else { Sum_Income_Y_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_6"].ToString() == "") { Sum_Income_Y_M_6 = "0"; } else { Sum_Income_Y_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_7"].ToString() == "") { Sum_Income_Y_M_7 = "0"; } else { Sum_Income_Y_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_8"].ToString() == "") { Sum_Income_Y_M_8 = "0"; } else { Sum_Income_Y_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_9"].ToString() == "") { Sum_Income_Y_M_9 = "0"; } else { Sum_Income_Y_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_10"].ToString() == "") { Sum_Income_Y_M_10 = "0"; } else { Sum_Income_Y_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_11"].ToString() == "") { Sum_Income_Y_M_11 = "0"; } else { Sum_Income_Y_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_12"].ToString() == "") { Sum_Income_Y_M_12 = "0"; } else { Sum_Income_Y_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_12"].ToString(); }

                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_1"].ToString() == "") { Sum_Management_Expenses_Y_M_1 = "0"; } else { Sum_Management_Expenses_Y_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_2"].ToString() == "") { Sum_Management_Expenses_Y_M_2 = "0"; } else { Sum_Management_Expenses_Y_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_3"].ToString() == "") { Sum_Management_Expenses_Y_M_3 = "0"; } else { Sum_Management_Expenses_Y_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_4"].ToString() == "") { Sum_Management_Expenses_Y_M_4 = "0"; } else { Sum_Management_Expenses_Y_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_5"].ToString() == "") { Sum_Management_Expenses_Y_M_5 = "0"; } else { Sum_Management_Expenses_Y_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_6"].ToString() == "") { Sum_Management_Expenses_Y_M_6 = "0"; } else { Sum_Management_Expenses_Y_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_7"].ToString() == "") { Sum_Management_Expenses_Y_M_7 = "0"; } else { Sum_Management_Expenses_Y_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_8"].ToString() == "") { Sum_Management_Expenses_Y_M_8 = "0"; } else { Sum_Management_Expenses_Y_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_9"].ToString() == "") { Sum_Management_Expenses_Y_M_9 = "0"; } else { Sum_Management_Expenses_Y_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_10"].ToString() == "") { Sum_Management_Expenses_Y_M_10 = "0"; } else { Sum_Management_Expenses_Y_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_11"].ToString() == "") { Sum_Management_Expenses_Y_M_11 = "0"; } else { Sum_Management_Expenses_Y_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_12"].ToString() == "") { Sum_Management_Expenses_Y_M_12 = "0"; } else { Sum_Management_Expenses_Y_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_12"].ToString(); }

                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_1"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_1 = "0"; } else { Sum_RealEstate_Expenses_Y_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_2"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_2 = "0"; } else { Sum_RealEstate_Expenses_Y_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_3"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_3 = "0"; } else { Sum_RealEstate_Expenses_Y_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_4"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_4 = "0"; } else { Sum_RealEstate_Expenses_Y_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_5"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_5 = "0"; } else { Sum_RealEstate_Expenses_Y_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_6"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_6 = "0"; } else { Sum_RealEstate_Expenses_Y_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_7"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_7 = "0"; } else { Sum_RealEstate_Expenses_Y_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_8"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_8 = "0"; } else { Sum_RealEstate_Expenses_Y_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_9"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_9 = "0"; } else { Sum_RealEstate_Expenses_Y_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_10"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_10 = "0"; } else { Sum_RealEstate_Expenses_Y_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_11"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_11 = "0"; } else { Sum_RealEstate_Expenses_Y_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_12"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_12 = "0"; } else { Sum_RealEstate_Expenses_Y_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_12"].ToString(); }

                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_1"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_1 = "0"; } else { Sum_Maintenance_Expenses_Y_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_2"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_2 = "0"; } else { Sum_Maintenance_Expenses_Y_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_3"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_3 = "0"; } else { Sum_Maintenance_Expenses_Y_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_4"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_4 = "0"; } else { Sum_Maintenance_Expenses_Y_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_5"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_5 = "0"; } else { Sum_Maintenance_Expenses_Y_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_6"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_6 = "0"; } else { Sum_Maintenance_Expenses_Y_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_7"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_7 = "0"; } else { Sum_Maintenance_Expenses_Y_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_8"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_8 = "0"; } else { Sum_Maintenance_Expenses_Y_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_9"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_9 = "0"; } else { Sum_Maintenance_Expenses_Y_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_10"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_10 = "0"; } else { Sum_Maintenance_Expenses_Y_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_11"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_11 = "0"; } else { Sum_Maintenance_Expenses_Y_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_12"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_12 = "0"; } else { Sum_Maintenance_Expenses_Y_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_12"].ToString(); }
                    }

                    List<LineChartData> Data = new List<LineChartData>();
                    Data.Add(new LineChartData(01, Sum_Expected_Y_M_1, Convert.ToDouble(Sum_Income_Y_M_1), Convert.ToDouble(Sum_Management_Expenses_Y_M_1) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_1) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_1)));
                    Data.Add(new LineChartData(02, Sum_Expected_Y_M_2, Convert.ToDouble(Sum_Income_Y_M_2), Convert.ToDouble(Sum_Management_Expenses_Y_M_2) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_2) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_2)));
                    Data.Add(new LineChartData(03, Sum_Expected_Y_M_3, Convert.ToDouble(Sum_Income_Y_M_3), Convert.ToDouble(Sum_Management_Expenses_Y_M_3) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_3) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_3)));
                    Data.Add(new LineChartData(04, Sum_Expected_Y_M_4, Convert.ToDouble(Sum_Income_Y_M_4), Convert.ToDouble(Sum_Management_Expenses_Y_M_4) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_4) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_4)));
                    Data.Add(new LineChartData(05, Sum_Expected_Y_M_5, Convert.ToDouble(Sum_Income_Y_M_5), Convert.ToDouble(Sum_Management_Expenses_Y_M_5) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_5) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_5)));
                    Data.Add(new LineChartData(06, Sum_Expected_Y_M_6, Convert.ToDouble(Sum_Income_Y_M_6), Convert.ToDouble(Sum_Management_Expenses_Y_M_6) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_6) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_6)));
                    Data.Add(new LineChartData(07, Sum_Expected_Y_M_7, Convert.ToDouble(Sum_Income_Y_M_7), Convert.ToDouble(Sum_Management_Expenses_Y_M_7) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_7) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_7)));
                    Data.Add(new LineChartData(08, Sum_Expected_Y_M_8, Convert.ToDouble(Sum_Income_Y_M_8), Convert.ToDouble(Sum_Management_Expenses_Y_M_8) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_8) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_8)));
                    Data.Add(new LineChartData(09, Sum_Expected_Y_M_9, Convert.ToDouble(Sum_Income_Y_M_9), Convert.ToDouble(Sum_Management_Expenses_Y_M_9) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_9) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_9)));
                    Data.Add(new LineChartData(10, Sum_Expected_Y_M_10, Convert.ToDouble(Sum_Income_Y_M_10), Convert.ToDouble(Sum_Management_Expenses_Y_M_10) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_10) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_10)));
                    Data.Add(new LineChartData(11, Sum_Expected_Y_M_11, Convert.ToDouble(Sum_Income_Y_M_11), Convert.ToDouble(Sum_Management_Expenses_Y_M_11) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_11) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_11)));
                    Data.Add(new LineChartData(12, Sum_Expected_Y_M_12, Convert.ToDouble(Sum_Income_Y_M_12), Convert.ToDouble(Sum_Management_Expenses_Y_M_12) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_12) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_12)));
                    this.Chart1.DataSource = Data;
                    this.Chart1.DataBind();
                    _sqlCon.Close();
                    //****************************************************  القيمة الإيجارية **********************************************************************************************************

                    string Quary_virtual_Value = "select U.* ,O.Owner_Ship_Id FROM units U " +
                        "left join building B on(U.building_Building_Id = B.building_Id) " +
                        "left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) Where Half != 1";
                    _sqlCon.Open();
                    MySqlDataAdapter virtual_Value_Sda = new MySqlDataAdapter(Quary_virtual_Value, _sqlCon);
                    DataTable virtual_Value_Dt = new DataTable();
                    virtual_Value_Sda.Fill(virtual_Value_Dt);
                    if (virtual_Value_Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < virtual_Value_Dt.Rows.Count; i++)
                        {
                            if (virtual_Value_Dt.Rows[i]["virtual_Value"].ToString() == "") { Sum_virtual_Value = Sum_virtual_Value + 0; } else { Sum_virtual_Value = Sum_virtual_Value + Convert.ToDouble(virtual_Value_Dt.Rows[i]["virtual_Value"].ToString()); }
                        }
                    }
                    Syncfusion.JavaScript.DataVisualization.Models.Series series_Rental_Value = Rental_Value.Series[0];
                    List<ColumnChartData> data_Rental_Value = new List<ColumnChartData>();
                    double Total_Expected = 0;
                    Total_Expected = Sum_Expected_Y_M_1 + Sum_Expected_Y_M_2 + Sum_Expected_Y_M_3 + Sum_Expected_Y_M_4 + Sum_Expected_Y_M_5 + Sum_Expected_Y_M_6 + Sum_Expected_Y_M_7 +
                        Sum_Expected_Y_M_8 + Sum_Expected_Y_M_9 + Sum_Expected_Y_M_10 + Sum_Expected_Y_M_11 + Sum_Expected_Y_M_12;
                    double Total_Income = 0;
                    Total_Income = Convert.ToDouble(Sum_Income_Y_M_1) + Convert.ToDouble(Sum_Income_Y_M_2) + Convert.ToDouble(Sum_Income_Y_M_3) + Convert.ToDouble(Sum_Income_Y_M_4) +
                            Convert.ToDouble(Sum_Income_Y_M_5) + Convert.ToDouble(Sum_Income_Y_M_6) + Convert.ToDouble(Sum_Income_Y_M_7) + Convert.ToDouble(Sum_Income_Y_M_8) +
                            Convert.ToDouble(Sum_Income_Y_M_9) + Convert.ToDouble(Sum_Income_Y_M_10) + Convert.ToDouble(Sum_Income_Y_M_11) + Convert.ToDouble(Sum_Income_Y_M_12);


                    data_Rental_Value.Add(new ColumnChartData("القيمة الغيجارية لكافة العقارات", Sum_virtual_Value, Total_Expected, Total_Income));
                    this.Rental_Value.DataSource = data_Rental_Value;
                    this.Rental_Value.DataBind();
                    _sqlCon.Close();

                    //****************************************************  القيمة القارية **********************************************************************************************************
                    string Sum_Collection = "0";
                    string Rental_Value_Quary = "Select(Select Sum(Building_Value) From building)Sum_Bulidng_Value," +
                                                "(Select Sum(Land_Value) From owner_ship)Sum_Land_Value," +
                                                "(Select Sum(Collection) From collection_table where Year='" + Year + "' )Sum_Collection";
                    _sqlCon.Open();
                    MySqlDataAdapter Value_Quary_Sda = new MySqlDataAdapter(Rental_Value_Quary, _sqlCon);
                    DataTable get_Value_Quary_Dt = new DataTable();
                    Value_Quary_Sda.Fill(get_Value_Quary_Dt);
                    if (get_Value_Quary_Dt.Rows.Count > 0)
                    {
                        if (get_Value_Quary_Dt.Rows[0]["Sum_Bulidng_Value"].ToString() == "") { Sum_Bulidng_Value = "0"; } else { Sum_Bulidng_Value = get_Value_Quary_Dt.Rows[0]["Sum_Bulidng_Value"].ToString(); }
                        if (get_Value_Quary_Dt.Rows[0]["Sum_Land_Value"].ToString() == "") { Sum_Land_Value = "0"; } else { Sum_Land_Value = get_Value_Quary_Dt.Rows[0]["Sum_Land_Value"].ToString(); }
                        if (get_Value_Quary_Dt.Rows[0]["Sum_Collection"].ToString() == "") { Sum_Collection = "0"; } else { Sum_Collection = get_Value_Quary_Dt.Rows[0]["Sum_Collection"].ToString(); }
                    }
                    Lbl_RealEstae.Text = "العائد على القيمة العقارية";
                    Syncfusion.JavaScript.DataVisualization.Models.Series series4 = RealEstae_Chart.Series[0];
                    series4.Points.Clear();
                    series4.Points.Add(new Points("الدخل السنوي", Convert.ToDouble(Sum_Collection)));
                    series4.Points.Add(new Points("قيمة العقار", Convert.ToDouble(Sum_Bulidng_Value) + Convert.ToDouble(Sum_Land_Value)));
                    _sqlCon.Close();


                    lbl_RealEstate_Value.Text = (Convert.ToDouble(Sum_Bulidng_Value) + Convert.ToDouble(Sum_Land_Value)).ToString("###,###,###");
                    Yearly_Income.Text = (Convert.ToDouble(Sum_Collection)).ToString("###,###,###");
                    lbl_RealEstate_Value_percentage.Text = (((Convert.ToDouble(Sum_Collection)) / (Convert.ToDouble(Sum_Bulidng_Value) + Convert.ToDouble(Sum_Land_Value))) * 100).ToString("0.00 ") + "%";

                    //*************************** الإستدامة و  النمو **********************************************************************************************************************************
                    Real_Estate_Sustainability();
                    //*************************** الإهلاك **********************************************************************************************************************************
                    div_1.Visible = false; div_2.Visible = true;
                    Label22.Text = "الهالك السنوي لكل الملكيات  :";
                    Label23.Text = (Convert.ToDouble(Sum_Bulidng_Value) / Convert.ToDouble(txt_Destruction_Value.Text)).ToString("###,###,###");

                    Label24.Text = " االمتبقي من قيمة كل الملكيات  :";
                    Label25.Text = (Convert.ToDouble(Sum_Bulidng_Value) - Convert.ToDouble(Label23.Text)).ToString("###,###,###");

                    Syncfusion.JavaScript.DataVisualization.Models.Series series5 = destruction_Char.Series[0];
                    series5.Points.Clear();
                }
                // 1-2
                else if (Ownership_Name_DropDownList.SelectedItem.Text != "كل الملكيات" && Building_Name_DropDownList.SelectedItem.Text == "كل الأبنية")
                {
                    Building_Condition();
                    // **************************** النسب المئوية للجنسيات ********************************************************
                    percent_nationality_GridView();
                    Tenant_Evaluation();
                    //****************************** الرهن العقاري *****************************************************************
                    Mortgage_All();
                    //******************************************************* حالات الوحدات ***********************************************************
                    double Available = 0; double Rented = 0; double Undermaintenance = 0; double UnderProplem = 0;
                    string Building_Id_Quairy = "select Building_Id from building where  owner_ship_Owner_Ship_Id ='" + Ownership_Name_DropDownList.SelectedValue + "'";
                    _sqlCon.Open();
                    DataTable get_Building_Id_Dt = new DataTable();
                    MySqlCommand get_Building_Id_Cmd = new MySqlCommand(Building_Id_Quairy, _sqlCon);
                    MySqlDataAdapter get_Building_Id_Da = new MySqlDataAdapter(get_Building_Id_Cmd);
                    get_Building_Id_Da.Fill(get_Building_Id_Dt);
                    if (get_Building_Id_Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < get_Building_Id_Dt.Rows.Count; i++)
                        {
                            string Building_Id = get_Building_Id_Dt.Rows[i]["Building_Id"].ToString();
                            string Quairy = "select " +
                                "( Select count(*) from units where Half != 1 and building_Building_Id = '" + Building_Id + "' and unit_condition_Unit_Condition_Id='1')Rented , " +
                                "(Select count(*) from units where Half != 1 and building_Building_Id = '" + Building_Id + "' and unit_condition_Unit_Condition_Id = '2')Available , " +
                                "(Select count(*) from units where Half != 1 and building_Building_Id = '" + Building_Id + "' and unit_condition_Unit_Condition_Id = '3')Under_Maintenance ," +
                                "(Select count(*) from units where Half != 1 and building_Building_Id = '" + Building_Id + "' and unit_condition_Unit_Condition_Id = '4')Under_Proplem ";

                            DataTable getUnitStatusChartDt = new DataTable();
                            MySqlCommand getUnitStatusChartCmd = new MySqlCommand(Quairy, _sqlCon);
                            MySqlDataAdapter getUnitStatusChartDa = new MySqlDataAdapter(getUnitStatusChartCmd);
                            getUnitStatusChartDa.Fill(getUnitStatusChartDt);
                            if (getUnitStatusChartDt.Rows.Count > 0)
                            {
                                Available = Available + double.Parse(getUnitStatusChartDt.Rows[0]["Available"].ToString());
                                Rented = Rented + double.Parse(getUnitStatusChartDt.Rows[0]["Rented"].ToString());
                                Undermaintenance = Undermaintenance + double.Parse(getUnitStatusChartDt.Rows[0]["Under_Maintenance"].ToString());
                                UnderProplem = UnderProplem + double.Parse(getUnitStatusChartDt.Rows[0]["Under_Proplem"].ToString());

                            }
                            //-----------------------------------------------------------------------------------------------------------------------
                            double U_C = 0; double B_C = 0;
                            string Q = "SELECT  C.End_Date , C.units_Unit_ID ,  " +
                                        "B.Building_Id , O.Owner_Ship_Id FROM contract C " +
                                        "left join units U on (C.units_Unit_ID = U.Unit_Id) " +
                                        "left join building B on (U.building_Building_Id = B.building_Id) " +
                                        "left join owner_ship O on (B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                                        "where C.New_ReNewed_Expaired ='1' and  O.Owner_Ship_Id = '" + Ownership_Name_DropDownList.SelectedValue + "';";
                            DataTable Dt = new DataTable();
                            MySqlCommand Cmd = new MySqlCommand(Q, _sqlCon);
                            MySqlDataAdapter Da = new MySqlDataAdapter(Cmd);
                            Da.Fill(Dt);
                            for (int K = 0; K < Dt.Rows.Count; K++)
                            {
                                string EndDate = Dt.Rows[K]["End_Date"].ToString();
                                DateTime End_Date = Convert.ToDateTime(EndDate);
                                var today = DateTime.Now;
                                var diffOfDates = (End_Date - today).Days;
                                if (diffOfDates >= 0 && diffOfDates <= 60) { U_C++; }
                            }



                            string Q2 = "SELECT  C.End_Date , C.building_Building_Id ,  " +
                                        "O.Owner_Ship_Id " +
                                        "FROM building_contract C " +
                                        "left join building B on(C.building_Building_Id = B.Building_Id) " +
                                        "left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                                        "where C.New_ReNewed_Expaired ='1' and O.Owner_Ship_Id = '" + Ownership_Name_DropDownList.SelectedValue + "'; ";
                            DataTable Dt2 = new DataTable();
                            MySqlCommand Cmd2 = new MySqlCommand(Q2, _sqlCon);
                            MySqlDataAdapter Da2 = new MySqlDataAdapter(Cmd2);
                            Da2.Fill(Dt2);
                            for (int K = 0; K < Dt2.Rows.Count; K++)
                            {
                                string EndDate = Dt2.Rows[K]["End_Date"].ToString();
                                DateTime End_Date = Convert.ToDateTime(EndDate);
                                var today = DateTime.Now;
                                var diffOfDates = (End_Date - today).Days;
                                if (diffOfDates >= 0 && diffOfDates <= 60) { B_C++; }
                            }
                            //-----------------------------------------------------------------------------------------------------------------------
                            Syncfusion.JavaScript.DataVisualization.Models.Series series = Units_Statuse.Series[0];
                            series.Points.Clear();
                            series.Points.Add(new Points("شاغر", Available));
                            series.Points.Add(new Points("مؤجر", Rented));
                            series.Points.Add(new Points("تحت الانشاء أو الصيانة", Undermaintenance));
                            series.Points.Add(new Points("موجر نزاع", UnderProplem));
                            series.Points.Add(new Points("", 0));
                            series.Points.Add(new Points("قيد الإنتهاء", (U_C + B_C)));
                        }
                    }

                    // ********************************  المصاريف الغدارية و العقارية و الصيانة************************************
                    Syncfusion.JavaScript.DataVisualization.Models.Series series1 = Expenses_Chart.Series[0];
                    List<ColumnChartData> data = new List<ColumnChartData>();
                    data.Add(new ColumnChartData(Ownership_Name_DropDownList.SelectedItem.Text, Convert.ToDouble(Management_Expenses_D_Y_O), Convert.ToDouble(RealEstate_Expenses_D_Y_O), Convert.ToDouble(Maintenance_Expenses_D_Y_O)));
                    this.Expenses_Chart.DataSource = data;
                    this.Expenses_Chart.DataBind();

                    // ********************************    العائد الفعلي **********************************
                    double total_Expensess = Convert.ToDouble(Convert.ToDouble(Management_Expenses_D_Y_O) + Convert.ToDouble(RealEstate_Expenses_D_Y_O) + Convert.ToDouble(Maintenance_Expenses_D_Y_O));
                    lbl_Real_Income.Text = "العائد الفعلي";

                    double Real_Income = Convert.ToDouble(Collection_D_Y_O) - total_Expensess;
                    Syncfusion.JavaScript.DataVisualization.Models.Series Real_Income_series = Real_Income_Chart_2.Series[0];
                    List<ColumnChartData> Real_Income_data = new List<ColumnChartData>();
                    Real_Income_data.Add(new ColumnChartData("العائد الفعلي", Convert.ToDouble(Collection_D_Y_O), Real_Income, total_Expensess));
                    this.Real_Income_Chart_2.DataSource = Real_Income_data;
                    this.Real_Income_Chart_2.DataBind();
                    _sqlCon.Close();

                    //************************************* الربح الصافي **********************************************************
                    string Sum_Building_Value_Quary = "Select Sum(Building_Value) Sum_Building_Value From building where owner_ship_Owner_Ship_Id ='" + OwnerShip + "'";
                    string Sum_Building_Value = "0";
                    _sqlCon.Open();
                    MySqlDataAdapter VSum_Building_Value_Sda = new MySqlDataAdapter(Sum_Building_Value_Quary, _sqlCon);
                    DataTable VSum_Building_Value_Dt = new DataTable();
                    VSum_Building_Value_Sda.Fill(VSum_Building_Value_Dt);
                    if (VSum_Building_Value_Dt.Rows.Count > 0)
                    {
                        if (VSum_Building_Value_Dt.Rows[0]["Sum_Building_Value"].ToString() == "") { Sum_Building_Value = "0"; } else { Sum_Building_Value = VSum_Building_Value_Dt.Rows[0]["Sum_Building_Value"].ToString(); }
                    }

                    Label1.Text = Convert.ToString(Convert.ToDouble(Sum_Building_Value) / Convert.ToDouble(txt_Destruction_Value.Text));

                    Label2.Text = Convert.ToString((Convert.ToDouble(Collection_D_Y_O) - total_Expensess));

                    Label3.Text = Convert.ToString((Convert.ToDouble(Sum_Building_Value) / Convert.ToDouble(txt_Destruction_Value.Text)) - ((Convert.ToDouble(Collection_D_Y_O) - total_Expensess)));


                    Syncfusion.JavaScript.DataVisualization.Models.Series series_Chart2 = Chart2.Series[0];
                    List<ColumnChartData> data_Chart2 = new List<ColumnChartData>();
                    data_Chart2.Add(new ColumnChartData("", Convert.ToDouble(Label1.Text), Convert.ToDouble(Label3.Text), (Convert.ToDouble(Label2.Text))));

                    this.Chart2.DataSource = data_Chart2;
                    this.Chart2.DataBind();
                    _sqlCon.Close();

                    //********************************* متبقي التوزيع  ************************************
                    string Sum_Remainder_Distribution_Quary = "select(select owner_Owner_Id from owner_ship where Owner_Ship_Id='" + OwnerShip + "')OwnerID,(select Salary from owner where Owner_Id = OwnerID)Sum_Salary";
                    string Sum_Remainder_Distribution = "0";
                    _sqlCon.Open();
                    MySqlDataAdapter Sum_Remainder_Distribution_Sda = new MySqlDataAdapter(Sum_Remainder_Distribution_Quary, _sqlCon);
                    DataTable Sum_Remainder_Distribution_Dt = new DataTable();
                    Sum_Remainder_Distribution_Sda.Fill(Sum_Remainder_Distribution_Dt);
                    if (Sum_Remainder_Distribution_Dt.Rows.Count > 0)
                    {
                        if (Sum_Remainder_Distribution_Dt.Rows[0]["Sum_Salary"].ToString() == "") { Sum_Remainder_Distribution = "0"; } else { Sum_Remainder_Distribution = Sum_Remainder_Distribution_Dt.Rows[0]["Sum_Salary"].ToString(); }
                    }
                    //الرواتب
                    Label4.Text = Convert.ToString(Convert.ToDouble(Sum_Remainder_Distribution) * 12);

                    // الربح الصافي
                    Label5.Text = Label3.Text;

                    double X = Convert.ToDouble(Label5.Text) - Convert.ToDouble(Label4.Text);
                    Label6.Text = Convert.ToString(X);
                    Syncfusion.JavaScript.DataVisualization.Models.Series series_Chart3 = Chart3.Series[0];
                    List<ColumnChartData> data_Chart3 = new List<ColumnChartData>();
                    data_Chart3.Add(new ColumnChartData("", Convert.ToDouble(Label4.Text), Convert.ToDouble(Label5.Text), (Convert.ToDouble(Label6.Text))));
                    this.Chart3.DataSource = data_Chart3;
                    this.Chart3.DataBind();
                    _sqlCon.Close();
                    // ********************************    التدفق النقدي **********************************
                    lbl_Cash_Flow.Text = "التدفق النقدي لكافة الملكيات لعام " + Year_DropDownList.SelectedItem.Text + " والملكية   " + Ownership_Name_DropDownList.SelectedItem.Text;
                    _sqlCon.Open();
                    using (MySqlCommand Cash_flow_Cmd = new MySqlCommand("Dashboard_Test", _sqlCon))
                    {
                        Cash_flow_Cmd.CommandType = CommandType.StoredProcedure;
                        using (MySqlDataAdapter Cash_flow_Sda = new MySqlDataAdapter(Cash_flow_Cmd))
                        {
                            DataTable Cash_flow_Dt = new DataTable();
                            Cash_flow_Sda.Fill(Cash_flow_Dt);
                            if (Cash_flow_Dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < Cash_flow_Dt.Rows.Count; i++)
                                {
                                    string Y_Cheques_Date = Convert.ToString(Convert.ToDateTime(Cash_flow_Dt.Rows[i]["Datee"].ToString()).Year);
                                    string M_Cheques_Date = Convert.ToString(Convert.ToDateTime(Cash_flow_Dt.Rows[i]["Datee"].ToString()).Month);
                                    string O_ID = Cash_flow_Dt.Rows[i]["O_ID"].ToString();
                                    string B_ID = Cash_flow_Dt.Rows[i]["B_ID"].ToString();

                                    if (M_Cheques_Date == "1" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_1 = Sum_Expected_Y_O_M_1 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "2" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_2 = Sum_Expected_Y_O_M_2 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "3" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_3 = Sum_Expected_Y_O_M_3 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "4" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_4 = Sum_Expected_Y_O_M_4 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "5" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_5 = Sum_Expected_Y_O_M_5 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "6" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_6 = Sum_Expected_Y_O_M_6 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "7" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_7 = Sum_Expected_Y_O_M_7 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "8" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_8 = Sum_Expected_Y_O_M_8 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "9" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_9 = Sum_Expected_Y_O_M_9 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "10" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_10 = Sum_Expected_Y_O_M_10 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "11" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_11 = Sum_Expected_Y_O_M_11 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "12" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_12 = Sum_Expected_Y_O_M_12 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }


                                }
                            }
                        }
                    }
                    _sqlCon.Close();
                    string Quary2 = "select " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "'  and Mounth = '1')Sum_Income_Y_O_M_1,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "'  and Mounth = '2')Sum_Income_Y_O_M_2,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "'  and Mounth = '3')Sum_Income_Y_O_M_3,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '4')Sum_Income_Y_O_M_4,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "'  and Mounth = '5')Sum_Income_Y_O_M_5,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "'  and Mounth = '6')Sum_Income_Y_O_M_6,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "'  and Mounth = '7')Sum_Income_Y_O_M_7,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "'  and Mounth = '8')Sum_Income_Y_O_M_8, " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "'  and Mounth = '9')Sum_Income_Y_O_M_9,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "'  and Mounth = '10')Sum_Income_Y_O_M_10,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "'  and Mounth = '11')Sum_Income_Y_O_M_11,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '12')Sum_Income_Y_O_M_12, " +

                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '1')Sum_Management_Expenses_Y_O_M_1,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '2')Sum_Management_Expenses_Y_O_M_2,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '3')Sum_Management_Expenses_Y_O_M_3,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '4')Sum_Management_Expenses_Y_O_M_4,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '5')Sum_Management_Expenses_Y_O_M_5,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '6')Sum_Management_Expenses_Y_O_M_6,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '7')Sum_Management_Expenses_Y_O_M_7,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '8')Sum_Management_Expenses_Y_O_M_8, " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '9')Sum_Management_Expenses_Y_O_M_9,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '10')Sum_Management_Expenses_Y_O_M_10,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '11')Sum_Management_Expenses_Y_O_M_11,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '12')Sum_Management_Expenses_Y_O_M_12 ," +

                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '1')Sum_RealEstate_Expenses_Y_O_M_1,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '2')Sum_RealEstate_Expenses_Y_O_M_2,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '3')Sum_RealEstate_Expenses_Y_O_M_3,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '4')Sum_RealEstate_Expenses_Y_O_M_4,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '5')Sum_RealEstate_Expenses_Y_O_M_5,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '6')Sum_RealEstate_Expenses_Y_O_M_6,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '7')Sum_RealEstate_Expenses_Y_O_M_7,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '8')Sum_RealEstate_Expenses_Y_O_M_8, " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '9')Sum_RealEstate_Expenses_Y_O_M_9,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '10')Sum_RealEstate_Expenses_Y_O_M_10,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '11')Sum_RealEstate_Expenses_Y_O_M_11,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '12')Sum_RealEstate_Expenses_Y_O_M_12, " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '1')Sum_Maintenance_Expenses_Y_O_M_1,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '2')Sum_Maintenance_Expenses_Y_O_M_2,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '3')Sum_Maintenance_Expenses_Y_O_M_3,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '4')Sum_Maintenance_Expenses_Y_O_M_4,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '5')Sum_Maintenance_Expenses_Y_O_M_5,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '6')Sum_Maintenance_Expenses_Y_O_M_6,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '7')Sum_Maintenance_Expenses_Y_O_M_7,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '8')Sum_Maintenance_Expenses_Y_O_M_8, " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '9')Sum_Maintenance_Expenses_Y_O_M_9,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '10')Sum_Maintenance_Expenses_Y_O_M_10,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '11')Sum_Maintenance_Expenses_Y_O_M_11,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '12')Sum_Maintenance_Expenses_Y_O_M_12";
                    _sqlCon.Open();
                    MySqlDataAdapter Collection_Expenses_Sda = new MySqlDataAdapter(Quary2, _sqlCon);
                    DataTable getCollection_Expenses_Dt = new DataTable();
                    Collection_Expenses_Sda.Fill(getCollection_Expenses_Dt);
                    if (getCollection_Expenses_Dt.Rows.Count > 0)
                    {
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_1"].ToString() == "") { Sum_Income_Y_O_M_1 = "0"; } else { Sum_Income_Y_O_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_2"].ToString() == "") { Sum_Income_Y_O_M_2 = "0"; } else { Sum_Income_Y_O_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_3"].ToString() == "") { Sum_Income_Y_O_M_3 = "0"; } else { Sum_Income_Y_O_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_4"].ToString() == "") { Sum_Income_Y_O_M_4 = "0"; } else { Sum_Income_Y_O_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_5"].ToString() == "") { Sum_Income_Y_O_M_5 = "0"; } else { Sum_Income_Y_O_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_6"].ToString() == "") { Sum_Income_Y_O_M_6 = "0"; } else { Sum_Income_Y_O_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_7"].ToString() == "") { Sum_Income_Y_O_M_7 = "0"; } else { Sum_Income_Y_O_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_8"].ToString() == "") { Sum_Income_Y_O_M_8 = "0"; } else { Sum_Income_Y_O_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_9"].ToString() == "") { Sum_Income_Y_O_M_9 = "0"; } else { Sum_Income_Y_O_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_10"].ToString() == "") { Sum_Income_Y_O_M_10 = "0"; } else { Sum_Income_Y_O_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_11"].ToString() == "") { Sum_Income_Y_O_M_11 = "0"; } else { Sum_Income_Y_O_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_12"].ToString() == "") { Sum_Income_Y_O_M_12 = "0"; } else { Sum_Income_Y_O_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_12"].ToString(); }

                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_1"].ToString() == "") { Sum_Management_Expenses_Y_O_M_1 = "0"; } else { Sum_Management_Expenses_Y_O_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_2"].ToString() == "") { Sum_Management_Expenses_Y_O_M_2 = "0"; } else { Sum_Management_Expenses_Y_O_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_3"].ToString() == "") { Sum_Management_Expenses_Y_O_M_3 = "0"; } else { Sum_Management_Expenses_Y_O_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_4"].ToString() == "") { Sum_Management_Expenses_Y_O_M_4 = "0"; } else { Sum_Management_Expenses_Y_O_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_5"].ToString() == "") { Sum_Management_Expenses_Y_O_M_5 = "0"; } else { Sum_Management_Expenses_Y_O_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_6"].ToString() == "") { Sum_Management_Expenses_Y_O_M_6 = "0"; } else { Sum_Management_Expenses_Y_O_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_7"].ToString() == "") { Sum_Management_Expenses_Y_O_M_7 = "0"; } else { Sum_Management_Expenses_Y_O_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_8"].ToString() == "") { Sum_Management_Expenses_Y_O_M_8 = "0"; } else { Sum_Management_Expenses_Y_O_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_9"].ToString() == "") { Sum_Management_Expenses_Y_O_M_9 = "0"; } else { Sum_Management_Expenses_Y_O_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_10"].ToString() == "") { Sum_Management_Expenses_Y_O_M_10 = "0"; } else { Sum_Management_Expenses_Y_O_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_11"].ToString() == "") { Sum_Management_Expenses_Y_O_M_11 = "0"; } else { Sum_Management_Expenses_Y_O_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_12"].ToString() == "") { Sum_Management_Expenses_Y_O_M_12 = "0"; } else { Sum_Management_Expenses_Y_O_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_12"].ToString(); }

                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_1"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_1 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_2"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_2 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_3"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_3 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_4"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_4 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_5"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_5 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_6"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_6 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_7"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_7 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_8"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_8 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_9"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_9 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_10"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_10 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_11"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_11 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_12"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_12 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_12"].ToString(); }

                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_1"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_1 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_2"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_2 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_3"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_3 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_4"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_4 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_5"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_5 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_6"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_6 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_7"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_7 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_8"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_8 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_9"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_9 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_10"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_10 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_11"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_11 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_12"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_12 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_12"].ToString(); }
                    }
                    List<LineChartData> Data = new List<LineChartData>();
                    Data.Add(new LineChartData(01, Sum_Expected_Y_O_M_1, Convert.ToDouble(Sum_Income_Y_O_M_1), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_1) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_1) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_1)));
                    Data.Add(new LineChartData(02, Sum_Expected_Y_O_M_2, Convert.ToDouble(Sum_Income_Y_O_M_2), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_2) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_2) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_2)));
                    Data.Add(new LineChartData(03, Sum_Expected_Y_O_M_3, Convert.ToDouble(Sum_Income_Y_O_M_3), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_3) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_3) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_3)));
                    Data.Add(new LineChartData(04, Sum_Expected_Y_O_M_4, Convert.ToDouble(Sum_Income_Y_O_M_4), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_4) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_4) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_4)));
                    Data.Add(new LineChartData(05, Sum_Expected_Y_O_M_5, Convert.ToDouble(Sum_Income_Y_O_M_5), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_5) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_5) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_5)));
                    Data.Add(new LineChartData(06, Sum_Expected_Y_O_M_6, Convert.ToDouble(Sum_Income_Y_O_M_6), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_6) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_6) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_6)));
                    Data.Add(new LineChartData(07, Sum_Expected_Y_O_M_7, Convert.ToDouble(Sum_Income_Y_O_M_7), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_7) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_7) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_7)));
                    Data.Add(new LineChartData(08, Sum_Expected_Y_O_M_8, Convert.ToDouble(Sum_Income_Y_O_M_8), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_8) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_8) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_8)));
                    Data.Add(new LineChartData(09, Sum_Expected_Y_O_M_9, Convert.ToDouble(Sum_Income_Y_O_M_9), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_9) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_9) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_9)));
                    Data.Add(new LineChartData(10, Sum_Expected_Y_O_M_10, Convert.ToDouble(Sum_Income_Y_O_M_10), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_10) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_10) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_10)));
                    Data.Add(new LineChartData(11, Sum_Expected_Y_O_M_11, Convert.ToDouble(Sum_Income_Y_O_M_11), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_11) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_11) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_11)));
                    Data.Add(new LineChartData(12, Sum_Expected_Y_O_M_12, Convert.ToDouble(Sum_Income_Y_O_M_12), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_12) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_12) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_1)));
                    this.Chart1.DataSource = Data;
                    this.Chart1.DataBind();
                    _sqlCon.Close();
                    //****************************************************  القيمة الإيجارية **********************************************************************************************************

                    string Quary_virtual_Value = "select U.* ,O.Owner_Ship_Id FROM units U  " +
                        "left join building B on(U.building_Building_Id = B.building_Id) " +
                        "left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) Where Half != 1 ";
                    _sqlCon.Open();
                    MySqlDataAdapter virtual_Value_Sda = new MySqlDataAdapter(Quary_virtual_Value, _sqlCon);
                    DataTable virtual_Value_Dt = new DataTable();
                    virtual_Value_Sda.Fill(virtual_Value_Dt);
                    if (virtual_Value_Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < virtual_Value_Dt.Rows.Count; i++)
                        {
                            string Owner_Ship_Id = virtual_Value_Dt.Rows[i]["Owner_Ship_Id"].ToString();
                            if (Owner_Ship_Id == Ownership_Name_DropDownList.SelectedValue)
                            {
                                if (virtual_Value_Dt.Rows[i]["virtual_Value"].ToString() == "") { Sum_virtual_Value = Sum_virtual_Value + 0; } else { Sum_virtual_Value = Sum_virtual_Value + Convert.ToDouble(virtual_Value_Dt.Rows[i]["virtual_Value"].ToString()); }
                            }
                        }
                    }
                    Syncfusion.JavaScript.DataVisualization.Models.Series series_Rental_Value = Rental_Value.Series[0];
                    List<ColumnChartData> data_Rental_Value = new List<ColumnChartData>();
                    double Total_Expected = 0;
                    Total_Expected = Sum_Expected_Y_O_M_1 + Sum_Expected_Y_O_M_2 + Sum_Expected_Y_O_M_3 + Sum_Expected_Y_O_M_4 + Sum_Expected_Y_O_M_5 + Sum_Expected_Y_O_M_6 + Sum_Expected_Y_O_M_7 +
                        Sum_Expected_Y_O_M_8 + Sum_Expected_Y_O_M_9 + Sum_Expected_Y_O_M_10 + Sum_Expected_Y_O_M_11 + Sum_Expected_Y_O_M_12;

                    double Total_Income = 0;
                    Total_Income = Convert.ToDouble(Sum_Income_Y_O_M_1) + Convert.ToDouble(Sum_Income_Y_O_M_2) + Convert.ToDouble(Sum_Income_Y_O_M_3) + Convert.ToDouble(Sum_Income_Y_O_M_4) +
                            Convert.ToDouble(Sum_Income_Y_O_M_5) + Convert.ToDouble(Sum_Income_Y_O_M_6) + Convert.ToDouble(Sum_Income_Y_O_M_7) + Convert.ToDouble(Sum_Income_Y_O_M_8) +
                            Convert.ToDouble(Sum_Income_Y_O_M_9) + Convert.ToDouble(Sum_Income_Y_O_M_10) + Convert.ToDouble(Sum_Income_Y_O_M_11) + Convert.ToDouble(Sum_Income_Y_O_M_12);


                    data_Rental_Value.Add(new ColumnChartData(Ownership_Name_DropDownList.SelectedItem.Text + " القيمة الإيجارية للملكية ", Sum_virtual_Value, Total_Expected, Total_Income));
                    this.Rental_Value.DataSource = data_Rental_Value;
                    this.Rental_Value.DataBind();
                    _sqlCon.Close();
                    //****************************************************  القيمة القارية **********************************************************************************************************
                    string Sum_Collection = "0";
                    string Rental_Value_Quary = "Select(Select Sum(Building_Value) From building Where owner_ship_Owner_Ship_Id='" + OwnerShip + "')Sum_Bulidng_Value," +
                                                "(Select Sum(Land_Value) From owner_ship Where Owner_Ship_Id='" + OwnerShip + "')Sum_Land_Value," +
                                                "(Select Sum(Collection) From collection_table where Year='" + Year + "' And Ownersip_Id ='" + OwnerShip + "')Sum_Collection";
                    _sqlCon.Open();
                    MySqlDataAdapter Value_Quary_Sda = new MySqlDataAdapter(Rental_Value_Quary, _sqlCon);
                    DataTable get_Value_Quary_Dt = new DataTable();
                    Value_Quary_Sda.Fill(get_Value_Quary_Dt);
                    if (get_Value_Quary_Dt.Rows.Count > 0)
                    {
                        if (get_Value_Quary_Dt.Rows[0]["Sum_Bulidng_Value"].ToString() == "") { Sum_Bulidng_Value = "0"; } else { Sum_Bulidng_Value = get_Value_Quary_Dt.Rows[0]["Sum_Bulidng_Value"].ToString(); }
                        if (get_Value_Quary_Dt.Rows[0]["Sum_Land_Value"].ToString() == "") { Sum_Land_Value = "0"; } else { Sum_Land_Value = get_Value_Quary_Dt.Rows[0]["Sum_Land_Value"].ToString(); }
                        if (get_Value_Quary_Dt.Rows[0]["Sum_Collection"].ToString() == "") { Sum_Collection = "0"; } else { Sum_Collection = get_Value_Quary_Dt.Rows[0]["Sum_Collection"].ToString(); }
                    }
                    Lbl_RealEstae.Text = "العائد على القيمة العقارية";
                    Syncfusion.JavaScript.DataVisualization.Models.Series series4 = RealEstae_Chart.Series[0];
                    series4.Points.Clear();
                    series4.Points.Add(new Points("الدخل السنوي", Convert.ToDouble(Sum_Collection)));
                    series4.Points.Add(new Points("قيمة العقار", Convert.ToDouble(Sum_Bulidng_Value) + Convert.ToDouble(Sum_Land_Value)));
                    _sqlCon.Close();

                    lbl_RealEstate_Value.Text = (Convert.ToDouble(Sum_Bulidng_Value) + Convert.ToDouble(Sum_Land_Value)).ToString("###,###,###");
                    Yearly_Income.Text = (Convert.ToDouble(Sum_Collection)).ToString("###,###,###");
                    lbl_RealEstate_Value_percentage.Text = (((Convert.ToDouble(Sum_Collection)) / (Convert.ToDouble(Sum_Bulidng_Value) + Convert.ToDouble(Sum_Land_Value))) * 100).ToString("0.00 ") + "%";
                    //*************************** الإستدامة و  النمو **********************************************************************************************************************************
                    Real_Estate_Sustainability();
                    //*************************** الإهلاك **********************************************************************************************************************************
                    div_1.Visible = false; div_2.Visible = true;
                    Label22.Text = "الهالك السنوي لكل الأبنية في الملكية  :" + Ownership_Name_DropDownList.SelectedItem.Text;
                    Label23.Text = (Convert.ToDouble(Sum_Bulidng_Value) / Convert.ToDouble(txt_Destruction_Value.Text)).ToString("###,###,###");

                    Label24.Text = " االمتبقي من قيمة كل الأبنية في الملكية  :" + Ownership_Name_DropDownList.SelectedItem.Text;
                    Label25.Text = (Convert.ToDouble(Sum_Bulidng_Value) - Convert.ToDouble(Label23.Text)).ToString("###,###,###");

                    Syncfusion.JavaScript.DataVisualization.Models.Series series5 = destruction_Char.Series[0];
                    series5.Points.Clear();

                }
                // 1-3
                else if (Ownership_Name_DropDownList.SelectedItem.Text != "كل الملكيات" && Building_Name_DropDownList.SelectedItem.Text != "كل الأبنية")
                {
                    // **************************** النسب المئوية للجنسيات ********************************************************
                    percent_nationality_GridView();
                    Tenant_Evaluation();
                    //****************************** الرهن العقاري *****************************************************************
                    Mortgage_All();
                    //***************************************** حالات الوحدات *******************************************************



                    string Available = "0"; string Rented = "0"; string Undermaintenance = "0"; string UnderProplem = "0";
                    string Building_Id_Quairy = "select Building_Id from building where  owner_ship_Owner_Ship_Id ='" + Ownership_Name_DropDownList.SelectedValue + "'";
                    _sqlCon.Open();
                    DataTable get_Building_Id_Dt = new DataTable();
                    MySqlCommand get_Building_Id_Cmd = new MySqlCommand(Building_Id_Quairy, _sqlCon);
                    MySqlDataAdapter get_Building_Id_Da = new MySqlDataAdapter(get_Building_Id_Cmd);
                    get_Building_Id_Da.Fill(get_Building_Id_Dt);
                    if (get_Building_Id_Dt.Rows.Count > 0)
                    {
                        string Building_Id = Building_Name_DropDownList.SelectedValue;

                        string Quairy = "select ( Select count(*) from units where Half != 1 and building_Building_Id = '" + Building_Id + "' and unit_condition_Unit_Condition_Id='1')Rented , " +
                            "(Select count(*) from units where Half != 1 and building_Building_Id = '" + Building_Id + "' and unit_condition_Unit_Condition_Id = '2')Available , " +
                            "(Select count(*) from units where Half != 1 and building_Building_Id = '" + Building_Id + "' and unit_condition_Unit_Condition_Id = '3')Under_Maintenance ," +
                            "(Select count(*) from units where Half != 1 and building_Building_Id = '" + Building_Id + "' and unit_condition_Unit_Condition_Id = '4')Under_Proplem ";

                        DataTable getUnitStatusChartDt = new DataTable();
                        MySqlCommand getUnitStatusChartCmd = new MySqlCommand(Quairy, _sqlCon);
                        MySqlDataAdapter getUnitStatusChartDa = new MySqlDataAdapter(getUnitStatusChartCmd);
                        getUnitStatusChartDa.Fill(getUnitStatusChartDt);
                        if (getUnitStatusChartDt.Rows.Count > 0)
                        {
                            Available = getUnitStatusChartDt.Rows[0]["Available"].ToString();
                            Rented = getUnitStatusChartDt.Rows[0]["Rented"].ToString();
                            Undermaintenance = getUnitStatusChartDt.Rows[0]["Under_Maintenance"].ToString();
                            UnderProplem = getUnitStatusChartDt.Rows[0]["Under_Proplem"].ToString();
                        }

                        //-----------------------------------------------------------------------------------------------------------------------
                        double U_C = 0; double B_C = 0;
                        string Q = "SELECT  C.End_Date , C.units_Unit_ID ,  " +
                                    "B.Building_Id , O.Owner_Ship_Id FROM contract C " +
                                    "left join units U on (C.units_Unit_ID = U.Unit_Id) " +
                                    "left join building B on (U.building_Building_Id = B.building_Id) " +
                                    "left join owner_ship O on (B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                                    "where C.New_ReNewed_Expaired ='1' and B.Building_Id = '" + Building_Name_DropDownList.SelectedValue + "';";
                        DataTable Dt = new DataTable();
                        MySqlCommand Cmd = new MySqlCommand(Q, _sqlCon);
                        MySqlDataAdapter Da = new MySqlDataAdapter(Cmd);
                        Da.Fill(Dt);
                        for (int C = 0; C < Dt.Rows.Count; C++)
                        {
                            string EndDate = Dt.Rows[C]["End_Date"].ToString();
                            DateTime End_Date = Convert.ToDateTime(EndDate);
                            var today = DateTime.Now;
                            var diffOfDates = (End_Date - today).Days;
                            if (diffOfDates >= 0 && diffOfDates <= 60) { U_C++; }
                        }



                        string Q2 = "SELECT End_Date from building_contract where New_ReNewed_Expaired ='1' and building_Building_Id = '" + Building_Name_DropDownList.SelectedValue + "'";
                        DataTable Dt2 = new DataTable();
                        MySqlCommand Cmd2 = new MySqlCommand(Q2, _sqlCon);
                        MySqlDataAdapter Da2 = new MySqlDataAdapter(Cmd2);
                        Da2.Fill(Dt2);
                        for (int C = 0; C < Dt2.Rows.Count; C++)
                        {
                            string EndDate = Dt2.Rows[C]["End_Date"].ToString();
                            DateTime End_Date = Convert.ToDateTime(EndDate);
                            var today = DateTime.Now;
                            var diffOfDates = (End_Date - today).Days;
                            if (diffOfDates >= 0 && diffOfDates <= 60) { B_C++; }
                        }
                        //-----------------------------------------------------------------------------------------------------------------------
                        Syncfusion.JavaScript.DataVisualization.Models.Series series = Units_Statuse.Series[0];
                        series.Points.Clear();
                        series.Points.Add(new Points("شاغر", double.Parse(Available)));
                        series.Points.Add(new Points("مؤجر", double.Parse(Rented)));
                        series.Points.Add(new Points("تحت الانشاء أو الصيانة", double.Parse(Undermaintenance)));
                        series.Points.Add(new Points("موجر نزاع", double.Parse(UnderProplem)));
                        series.Points.Add(new Points("", 0));
                        series.Points.Add(new Points("قيد الإنتهاء", (U_C + B_C)));
                    }



                    // ********************************  المصاريف الغدارية و العقارية و الصيانة************************************
                    Syncfusion.JavaScript.DataVisualization.Models.Series series1 = Expenses_Chart.Series[0];
                    List<ColumnChartData> data = new List<ColumnChartData>();
                    data.Add(new ColumnChartData(Building_Name_DropDownList.SelectedItem.Text, Convert.ToDouble(Management_Expenses_D_Y_O_B), Convert.ToDouble(RealEstate_Expenses_D_Y_O_B), Convert.ToDouble(Maintenance_Expenses_D_Y_O_B)));
                    this.Expenses_Chart.DataSource = data;
                    this.Expenses_Chart.DataBind();

                    // ********************************    العائد الفعلي **********************************
                    double total_Expensess = Convert.ToDouble(Convert.ToDouble(Management_Expenses_D_Y_O_B) + Convert.ToDouble(RealEstate_Expenses_D_Y_O_B) + Convert.ToDouble(Maintenance_Expenses_D_Y_O_B));
                    lbl_Real_Income.Text = "العائد الفعلي";

                    double Real_Income = Convert.ToDouble(Collection_D_Y_O_B) - total_Expensess;
                    Syncfusion.JavaScript.DataVisualization.Models.Series Real_Income_series = Real_Income_Chart_2.Series[0];
                    List<ColumnChartData> Real_Income_data = new List<ColumnChartData>();
                    Real_Income_data.Add(new ColumnChartData("العائد الفعلي", Convert.ToDouble(Collection_D_Y_O_B), Real_Income, total_Expensess));
                    this.Real_Income_Chart_2.DataSource = Real_Income_data;
                    this.Real_Income_Chart_2.DataBind();
                    _sqlCon.Close();
                    //************************************* الربح الصافي **********************************************************
                    string Sum_Building_Value_Quary = "Select Sum(Building_Value) Sum_Building_Value From building where Building_Id ='" + Building + "'";
                    string Sum_Building_Value = "0";
                    _sqlCon.Open();
                    MySqlDataAdapter VSum_Building_Value_Sda = new MySqlDataAdapter(Sum_Building_Value_Quary, _sqlCon);
                    DataTable VSum_Building_Value_Dt = new DataTable();
                    VSum_Building_Value_Sda.Fill(VSum_Building_Value_Dt);
                    if (VSum_Building_Value_Dt.Rows.Count > 0)
                    {
                        if (VSum_Building_Value_Dt.Rows[0]["Sum_Building_Value"].ToString() == "") { Sum_Building_Value = "0"; } else { Sum_Building_Value = VSum_Building_Value_Dt.Rows[0]["Sum_Building_Value"].ToString(); }
                    }

                    Label1.Text = Convert.ToString(Convert.ToDouble(Sum_Building_Value) / Convert.ToDouble(txt_Destruction_Value.Text));

                    Label2.Text = Convert.ToString((Convert.ToDouble(Collection_D_Y_O_B) - total_Expensess));

                    Label3.Text = Convert.ToString((Convert.ToDouble(Sum_Building_Value) / Convert.ToDouble(txt_Destruction_Value.Text)) - ((Convert.ToDouble(Collection_D_Y_O_B) - total_Expensess)));


                    Syncfusion.JavaScript.DataVisualization.Models.Series series_Chart2 = Chart2.Series[0];
                    List<ColumnChartData> data_Chart2 = new List<ColumnChartData>();
                    data_Chart2.Add(new ColumnChartData("", Convert.ToDouble(Label1.Text), Convert.ToDouble(Label3.Text), (Convert.ToDouble(Label2.Text))));

                    this.Chart2.DataSource = data_Chart2;
                    this.Chart2.DataBind();
                    _sqlCon.Close();
                    //********************************* متبقي التوزيع  ************************************
                    string Sum_Remainder_Distribution_Quary = "select(select owner_Owner_Id from owner_ship where Owner_Ship_Id='" + OwnerShip + "')OwnerID,(select Salary from owner where Owner_Id = OwnerID)Sum_Salary";
                    string Sum_Remainder_Distribution = "0";
                    _sqlCon.Open();
                    MySqlDataAdapter Sum_Remainder_Distribution_Sda = new MySqlDataAdapter(Sum_Remainder_Distribution_Quary, _sqlCon);
                    DataTable Sum_Remainder_Distribution_Dt = new DataTable();
                    Sum_Remainder_Distribution_Sda.Fill(Sum_Remainder_Distribution_Dt);
                    if (Sum_Remainder_Distribution_Dt.Rows.Count > 0)
                    {
                        if (Sum_Remainder_Distribution_Dt.Rows[0]["Sum_Salary"].ToString() == "") { Sum_Remainder_Distribution = "0"; } else { Sum_Remainder_Distribution = Sum_Remainder_Distribution_Dt.Rows[0]["Sum_Salary"].ToString(); }
                    }
                    //الرواتب
                    Label4.Text = Convert.ToString(Convert.ToDouble(Sum_Remainder_Distribution) * 12);

                    // الربح الصافي
                    Label5.Text = Label3.Text;

                    double X = Convert.ToDouble(Label5.Text) - Convert.ToDouble(Label4.Text);
                    Label6.Text = Convert.ToString(X);
                    Syncfusion.JavaScript.DataVisualization.Models.Series series_Chart3 = Chart3.Series[0];
                    List<ColumnChartData> data_Chart3 = new List<ColumnChartData>();
                    data_Chart3.Add(new ColumnChartData("", Convert.ToDouble(Label4.Text), Convert.ToDouble(Label5.Text), (Convert.ToDouble(Label6.Text))));
                    this.Chart3.DataSource = data_Chart3;
                    this.Chart3.DataBind();
                    _sqlCon.Close();
                    // ********************************    التدفق النقدي **********************************
                    lbl_Cash_Flow.Text = "التدفق النقدي لكافة الملكيات لعام " + Year_DropDownList.SelectedItem.Text + " والبناء   " + Building_Name_DropDownList.SelectedItem.Text;
                    _sqlCon.Open();
                    using (MySqlCommand Cash_flow_Cmd = new MySqlCommand("Dashboard_Test", _sqlCon))
                    {
                        Cash_flow_Cmd.CommandType = CommandType.StoredProcedure;
                        using (MySqlDataAdapter Cash_flow_Sda = new MySqlDataAdapter(Cash_flow_Cmd))
                        {
                            DataTable Cash_flow_Dt = new DataTable();
                            Cash_flow_Sda.Fill(Cash_flow_Dt);
                            if (Cash_flow_Dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < Cash_flow_Dt.Rows.Count; i++)
                                {
                                    string Y_Cheques_Date = Convert.ToString(Convert.ToDateTime(Cash_flow_Dt.Rows[i]["Datee"].ToString()).Year);
                                    string M_Cheques_Date = Convert.ToString(Convert.ToDateTime(Cash_flow_Dt.Rows[i]["Datee"].ToString()).Month);
                                    string O_ID = Cash_flow_Dt.Rows[i]["O_ID"].ToString();
                                    string B_ID = Cash_flow_Dt.Rows[i]["B_ID"].ToString();

                                    if (M_Cheques_Date == "1" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_1 = Sum_Expected_Y_O_B_M_1 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "2" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_2 = Sum_Expected_Y_O_B_M_2 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "3" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_3 = Sum_Expected_Y_O_B_M_3 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "4" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_4 = Sum_Expected_Y_O_B_M_4 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "5" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_5 = Sum_Expected_Y_O_B_M_5 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "6" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_6 = Sum_Expected_Y_O_B_M_6 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "7" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_7 = Sum_Expected_Y_O_B_M_7 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "8" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_8 = Sum_Expected_Y_O_B_M_8 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "9" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_9 = Sum_Expected_Y_O_B_M_9 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "10" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_10 = Sum_Expected_Y_O_B_M_10 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "11" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_11 = Sum_Expected_Y_O_B_M_11 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "12" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_12 = Sum_Expected_Y_O_B_M_12 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }
                                }
                            }
                        }
                    }
                    _sqlCon.Close();
                    string Quary3 = "select " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "'  and Mounth = '1')Sum_Income_Y_O_B_M_1,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "'  and Mounth = '2')Sum_Income_Y_O_B_M_2,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "'  and Mounth = '3')Sum_Income_Y_O_B_M_3,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '4')Sum_Income_Y_O_B_M_4,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "'  and Mounth = '5')Sum_Income_Y_O_B_M_5,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "'  and Mounth = '6')Sum_Income_Y_O_B_M_6,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "'  and Mounth = '7')Sum_Income_Y_O_B_M_7,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "'  and Mounth = '8')Sum_Income_Y_O_B_M_8, " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "'  and Mounth = '9')Sum_Income_Y_O_B_M_9,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "'  and Mounth = '10')Sum_Income_Y_O_B_M_10,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "'  and Mounth = '11')Sum_Income_Y_O_B_M_11,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '12')Sum_Income_Y_O_B_M_12, " +

                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '1')Sum_Management_Expenses_Y_O_B_M_1,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '2')Sum_Management_Expenses_Y_O_B_M_2,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '3')Sum_Management_Expenses_Y_O_B_M_3,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '4')Sum_Management_Expenses_Y_O_B_M_4,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '5')Sum_Management_Expenses_Y_O_B_M_5,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '6')Sum_Management_Expenses_Y_O_B_M_6,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '7')Sum_Management_Expenses_Y_O_B_M_7,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '8')Sum_Management_Expenses_Y_O_B_M_8, " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '9')Sum_Management_Expenses_Y_O_B_M_9,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '10')Sum_Management_Expenses_Y_O_B_M_10,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '11')Sum_Management_Expenses_Y_O_B_M_11,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '12')Sum_Management_Expenses_Y_O_B_M_12 ," +

                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '1')Sum_RealEstate_Expenses_Y_O_B_M_1,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '2')Sum_RealEstate_Expenses_Y_O_B_M_2,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '3')Sum_RealEstate_Expenses_Y_O_B_M_3,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '4')Sum_RealEstate_Expenses_Y_O_B_M_4,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '5')Sum_RealEstate_Expenses_Y_O_B_M_5,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '6')Sum_RealEstate_Expenses_Y_O_B_M_6,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '7')Sum_RealEstate_Expenses_Y_O_B_M_7,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '8')Sum_RealEstate_Expenses_Y_O_B_M_8, " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '9')Sum_RealEstate_Expenses_Y_O_B_M_9,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '10')Sum_RealEstate_Expenses_Y_O_B_M_10,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '11')Sum_RealEstate_Expenses_Y_O_B_M_11,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '12')Sum_RealEstate_Expenses_Y_O_B_M_12, " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '1')Sum_Maintenance_Expenses_Y_O_B_M_1,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '2')Sum_Maintenance_Expenses_Y_O_B_M_2,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '3')Sum_Maintenance_Expenses_Y_O_B_M_3,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '4')Sum_Maintenance_Expenses_Y_O_B_M_4,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '5')Sum_Maintenance_Expenses_Y_O_B_M_5,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '6')Sum_Maintenance_Expenses_Y_O_B_M_6,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '7')Sum_Maintenance_Expenses_Y_O_B_M_7,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '8')Sum_Maintenance_Expenses_Y_O_B_M_8, " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '9')Sum_Maintenance_Expenses_Y_O_B_M_9,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '10')Sum_Maintenance_Expenses_Y_O_B_M_10,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '11')Sum_Maintenance_Expenses_Y_O_B_M_11,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '12')Sum_Maintenance_Expenses_Y_O_B_M_12";
                    _sqlCon.Open();
                    MySqlDataAdapter Collection_Expenses_Sda = new MySqlDataAdapter(Quary3, _sqlCon);
                    DataTable getCollection_Expenses_Dt = new DataTable();
                    Collection_Expenses_Sda.Fill(getCollection_Expenses_Dt);
                    if (getCollection_Expenses_Dt.Rows.Count > 0)
                    {
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_1"].ToString() == "") { Sum_Income_Y_O_B_M_1 = "0"; } else { Sum_Income_Y_O_B_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_2"].ToString() == "") { Sum_Income_Y_O_B_M_2 = "0"; } else { Sum_Income_Y_O_B_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_3"].ToString() == "") { Sum_Income_Y_O_B_M_3 = "0"; } else { Sum_Income_Y_O_B_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_4"].ToString() == "") { Sum_Income_Y_O_B_M_4 = "0"; } else { Sum_Income_Y_O_B_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_5"].ToString() == "") { Sum_Income_Y_O_B_M_5 = "0"; } else { Sum_Income_Y_O_B_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_6"].ToString() == "") { Sum_Income_Y_O_B_M_6 = "0"; } else { Sum_Income_Y_O_B_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_7"].ToString() == "") { Sum_Income_Y_O_B_M_7 = "0"; } else { Sum_Income_Y_O_B_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_8"].ToString() == "") { Sum_Income_Y_O_B_M_8 = "0"; } else { Sum_Income_Y_O_B_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_9"].ToString() == "") { Sum_Income_Y_O_B_M_9 = "0"; } else { Sum_Income_Y_O_B_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_10"].ToString() == "") { Sum_Income_Y_O_B_M_10 = "0"; } else { Sum_Income_Y_O_B_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_11"].ToString() == "") { Sum_Income_Y_O_B_M_11 = "0"; } else { Sum_Income_Y_O_B_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_12"].ToString() == "") { Sum_Income_Y_O_B_M_12 = "0"; } else { Sum_Income_Y_O_B_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_12"].ToString(); }

                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_1"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_1 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_2"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_2 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_3"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_3 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_4"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_4 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_5"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_5 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_6"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_6 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_7"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_7 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_8"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_8 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_9"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_9 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_10"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_10 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_11"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_11 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_12"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_12 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_12"].ToString(); }

                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_1"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_1 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_2"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_2 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_3"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_3 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_4"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_4 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_5"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_5 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_6"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_6 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_7"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_7 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_8"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_8 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_9"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_9 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_10"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_10 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_11"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_11 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_12"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_12 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_12"].ToString(); }

                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_1"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_1 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_2"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_2 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_3"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_3 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_4"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_4 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_5"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_5 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_6"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_6 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_7"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_7 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_8"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_8 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_9"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_9 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_10"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_10 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_11"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_11 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_12"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_12 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_12"].ToString(); }

                    }
                    List<LineChartData> Data = new List<LineChartData>();
                    Data.Add(new LineChartData(01, Sum_Expected_Y_O_B_M_1, Convert.ToDouble(Sum_Income_Y_O_B_M_1), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_1) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_1) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_1)));
                    Data.Add(new LineChartData(02, Sum_Expected_Y_O_B_M_2, Convert.ToDouble(Sum_Income_Y_O_B_M_2), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_2) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_2) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_2)));
                    Data.Add(new LineChartData(03, Sum_Expected_Y_O_B_M_3, Convert.ToDouble(Sum_Income_Y_O_B_M_3), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_3) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_3) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_3)));
                    Data.Add(new LineChartData(04, Sum_Expected_Y_O_B_M_4, Convert.ToDouble(Sum_Income_Y_O_B_M_4), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_4) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_4) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_4)));
                    Data.Add(new LineChartData(05, Sum_Expected_Y_O_B_M_5, Convert.ToDouble(Sum_Income_Y_O_B_M_5), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_5) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_5) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_5)));
                    Data.Add(new LineChartData(06, Sum_Expected_Y_O_B_M_6, Convert.ToDouble(Sum_Income_Y_O_B_M_6), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_6) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_6) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_6)));
                    Data.Add(new LineChartData(07, Sum_Expected_Y_O_B_M_7, Convert.ToDouble(Sum_Income_Y_O_B_M_7), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_7) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_7) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_7)));
                    Data.Add(new LineChartData(08, Sum_Expected_Y_O_B_M_8, Convert.ToDouble(Sum_Income_Y_O_B_M_8), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_8) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_8) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_8)));
                    Data.Add(new LineChartData(09, Sum_Expected_Y_O_B_M_9, Convert.ToDouble(Sum_Income_Y_O_B_M_9), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_9) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_9) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_9)));
                    Data.Add(new LineChartData(10, Sum_Expected_Y_O_B_M_10, Convert.ToDouble(Sum_Income_Y_O_B_M_10), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_10) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_10) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_10)));
                    Data.Add(new LineChartData(11, Sum_Expected_Y_O_B_M_11, Convert.ToDouble(Sum_Income_Y_O_B_M_11), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_11) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_11) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_11)));
                    Data.Add(new LineChartData(12, Sum_Expected_Y_O_B_M_12, Convert.ToDouble(Sum_Income_Y_O_B_M_12), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_12) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_12) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_12)));

                    //Binding Datasource to Chart
                    this.Chart1.DataSource = Data;
                    this.Chart1.DataBind();
                    _sqlCon.Close();
                    //****************************************************  القيمة الإيجارية **********************************************************************************************************

                    string Quary_virtual_Value = "select U.* ,O.Owner_Ship_Id FROM units U " +
                        "left join building B on(U.building_Building_Id = B.building_Id) " +
                        "left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id)  Where Half != 1 ";
                    _sqlCon.Open();
                    MySqlDataAdapter virtual_Value_Sda = new MySqlDataAdapter(Quary_virtual_Value, _sqlCon);
                    DataTable virtual_Value_Dt = new DataTable();
                    virtual_Value_Sda.Fill(virtual_Value_Dt);
                    if (virtual_Value_Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < virtual_Value_Dt.Rows.Count; i++)
                        {
                            string Owner_Ship_Id = virtual_Value_Dt.Rows[i]["Owner_Ship_Id"].ToString();
                            string Building_Id = virtual_Value_Dt.Rows[i]["building_Building_Id"].ToString();
                            if (Owner_Ship_Id == Ownership_Name_DropDownList.SelectedValue && Building_Id == Building_Name_DropDownList.SelectedValue)
                            {
                                if (virtual_Value_Dt.Rows[i]["virtual_Value"].ToString() == "") { Sum_virtual_Value = Sum_virtual_Value + 0; } else { Sum_virtual_Value = Sum_virtual_Value + Convert.ToDouble(virtual_Value_Dt.Rows[i]["virtual_Value"].ToString()); }
                            }
                        }
                    }
                    Syncfusion.JavaScript.DataVisualization.Models.Series series_Rental_Value = Rental_Value.Series[0];
                    List<ColumnChartData> data_Rental_Value = new List<ColumnChartData>();
                    double Total_Expected = 0;
                    Total_Expected = Sum_Expected_Y_O_B_M_1 + Sum_Expected_Y_O_B_M_2 + Sum_Expected_Y_O_B_M_3 + Sum_Expected_Y_O_B_M_4 + Sum_Expected_Y_O_B_M_5 + Sum_Expected_Y_O_B_M_6 + Sum_Expected_Y_O_B_M_7 +
                        Sum_Expected_Y_O_B_M_8 + Sum_Expected_Y_O_B_M_9 + Sum_Expected_Y_O_B_M_10 + Sum_Expected_Y_O_B_M_11 + Sum_Expected_Y_O_B_M_12;

                    double Total_Income = 0;
                    Total_Income = Convert.ToDouble(Sum_Income_Y_O_B_M_1) + Convert.ToDouble(Sum_Income_Y_O_B_M_2) + Convert.ToDouble(Sum_Income_Y_O_B_M_3) + Convert.ToDouble(Sum_Income_Y_O_B_M_4) +
                            Convert.ToDouble(Sum_Income_Y_O_B_M_5) + Convert.ToDouble(Sum_Income_Y_O_B_M_6) + Convert.ToDouble(Sum_Income_Y_O_B_M_7) + Convert.ToDouble(Sum_Income_Y_O_B_M_8) +
                            Convert.ToDouble(Sum_Income_Y_O_B_M_9) + Convert.ToDouble(Sum_Income_Y_O_B_M_10) + Convert.ToDouble(Sum_Income_Y_O_B_M_11) + Convert.ToDouble(Sum_Income_Y_O_B_M_12);


                    data_Rental_Value.Add(new ColumnChartData(Building_Name_DropDownList.SelectedItem.Text + " القيمة الإيجارية للبناء  ", Sum_virtual_Value, Total_Expected, Total_Income));
                    this.Rental_Value.DataSource = data_Rental_Value;
                    this.Rental_Value.DataBind();
                    _sqlCon.Close();
                    //****************************************************  القيمة العقارية **********************************************************************************************************
                    string Sum_Collection = "0";
                    string Rental_Value_Quary = "Select(Select Sum(Building_Value) From building Where owner_ship_Owner_Ship_Id='" + OwnerShip + "' And Building_Id = '" + Building + "')Sum_Bulidng_Value," +
                                                "(Select Sum(Land_Value) From owner_ship Where Owner_Ship_Id='" + OwnerShip + "')Sum_Land_Value," +
                                                "(Select Sum(Collection) From collection_table where Year='" + Year + "' And Ownersip_Id ='" + OwnerShip + "' And Building_Id = '" + Building + "')Sum_Collection";
                    _sqlCon.Open();
                    MySqlDataAdapter Value_Quary_Sda = new MySqlDataAdapter(Rental_Value_Quary, _sqlCon);
                    DataTable get_Value_Quary_Dt = new DataTable();
                    Value_Quary_Sda.Fill(get_Value_Quary_Dt);
                    if (get_Value_Quary_Dt.Rows.Count > 0)
                    {
                        if (get_Value_Quary_Dt.Rows[0]["Sum_Bulidng_Value"].ToString() == "") { Sum_Bulidng_Value = "0"; } else { Sum_Bulidng_Value = get_Value_Quary_Dt.Rows[0]["Sum_Bulidng_Value"].ToString(); }
                        if (get_Value_Quary_Dt.Rows[0]["Sum_Land_Value"].ToString() == "") { Sum_Land_Value = "0"; } else { Sum_Land_Value = get_Value_Quary_Dt.Rows[0]["Sum_Land_Value"].ToString(); }
                        if (get_Value_Quary_Dt.Rows[0]["Sum_Collection"].ToString() == "") { Sum_Collection = "0"; } else { Sum_Collection = get_Value_Quary_Dt.Rows[0]["Sum_Collection"].ToString(); }
                    }
                    Lbl_RealEstae.Text = "العائد على القيمة العقارية";
                    Syncfusion.JavaScript.DataVisualization.Models.Series series4 = RealEstae_Chart.Series[0];
                    series4.Points.Clear();
                    series4.Points.Add(new Points("الدخل السنوي", Convert.ToDouble(Sum_Collection)));
                    series4.Points.Add(new Points("قيمة العقار", Convert.ToDouble(Sum_Bulidng_Value) + Convert.ToDouble(Sum_Land_Value)));
                    _sqlCon.Close();

                    lbl_RealEstate_Value.Text = (Convert.ToDouble(Sum_Bulidng_Value) + Convert.ToDouble(Sum_Land_Value)).ToString("###,###,###");
                    Yearly_Income.Text = (Convert.ToDouble(Sum_Collection)).ToString("###,###,###");
                    lbl_RealEstate_Value_percentage.Text = (((Convert.ToDouble(Sum_Collection)) / (Convert.ToDouble(Sum_Bulidng_Value) + Convert.ToDouble(Sum_Land_Value))) * 100).ToString("0.00 ") + "%";
                    //********************************************** الإهلاك **********************************************************************************
                    string Construction_Completion_Date_Quary = "select Construction_Completion_Date from building where Building_Id = '" + Building + "'";
                    string Construction_Completion_Date = "0";

                    _sqlCon.Open();
                    MySqlDataAdapter VConstruction_Completion_Date_Sda = new MySqlDataAdapter(Construction_Completion_Date_Quary, _sqlCon);
                    DataTable VConstruction_Completion_Date_Dt = new DataTable();
                    VConstruction_Completion_Date_Sda.Fill(VConstruction_Completion_Date_Dt);
                    if (VConstruction_Completion_Date_Dt.Rows.Count > 0)
                    {
                        if (VConstruction_Completion_Date_Dt.Rows[0]["Construction_Completion_Date"].ToString() == "") { Construction_Completion_Date = "0"; } else { Construction_Completion_Date = VConstruction_Completion_Date_Dt.Rows[0]["Construction_Completion_Date"].ToString(); }
                    }
                    Syncfusion.JavaScript.DataVisualization.Models.Series series5 = destruction_Char.Series[0];
                    series5.Points.Clear();
                    series5.Points.Add(new Points("عمر البناء", (Convert.ToDouble(Year) - Convert.ToDouble(Construction_Completion_Date))));
                    series5.Points.Add(new Points("المتبقي من عمر البناء", (Convert.ToDouble(txt_Destruction_Value.Text) - (Convert.ToDouble(Year) - Convert.ToDouble(Construction_Completion_Date)))));
                    _sqlCon.Close();

                    div_1.Visible = true; div_2.Visible = false;
                    Label13.Text = (Convert.ToDouble(Year) - Convert.ToDouble(Construction_Completion_Date)).ToString("###,###,###");
                    Label15.Text = (Convert.ToDouble(Sum_Bulidng_Value) / Convert.ToDouble(txt_Destruction_Value.Text)).ToString("###,###,###");

                    Label17.Text = (Convert.ToDouble(Label15.Text) * (Convert.ToDouble(Year) - Convert.ToDouble(Construction_Completion_Date))).ToString("###,###,###");
                    Label19.Text = (Convert.ToDouble(txt_Destruction_Value.Text) - Convert.ToDouble(Label13.Text)).ToString("###,###,###");
                    Label21.Text = (Convert.ToDouble(Sum_Bulidng_Value) - Convert.ToDouble(Label17.Text)).ToString("###,###,###");

                    lbl_Depreciation_percentage.Text = "النسبة الئوية : " + (((Convert.ToDouble(Label13.Text)) / (Convert.ToDouble(Label19.Text))) * 100).ToString("0.00") + "%";
                    //*************************** الإستدامة و  النمو **********************************************************************************************************************************
                    Real_Estate_Sustainability();
                }
            }
            else
            {
                // 2-1
                if (Ownership_Name_DropDownList.SelectedItem.Text == "كل الملكيات")
                {
                    All_Building_Condition();
                    // **************************** النسب المئوية للجنسيات ********************************************************
                    percent_nationality_GridView();
                    Tenant_Evaluation();
                    //****************************** الرهن العقاري *****************************************************************
                    Mortgage_All();
                    //***************************************** حالات الوحدات *******************************************************



                    string Available = "0"; string Rented = "0"; string Undermaintenance = "0"; string UnderProplem = "0";
                    string Quairy = @"SELECT (Select Count(*)FROM units where Half != 1 and unit_condition_Unit_Condition_Id = 1 )as Rented ,
                                (Select count(*) from units where Half != 1 and unit_condition_Unit_Condition_Id = 2) as Available  ,
                                (Select count(*) from units where Half != 1 and unit_condition_Unit_Condition_Id = 3) as Undermaintenance ,
                                (Select count(*) from units where Half != 1 and unit_condition_Unit_Condition_Id = 4) as UnderProplem; ";
                    _sqlCon.Open();
                    DataTable getUnitStatusChartDt = new DataTable();
                    MySqlCommand getUnitStatusChartCmd = new MySqlCommand(Quairy, _sqlCon);
                    MySqlDataAdapter getUnitStatusChartDa = new MySqlDataAdapter(getUnitStatusChartCmd);
                    getUnitStatusChartDa.Fill(getUnitStatusChartDt);
                    if (getUnitStatusChartDt.Rows.Count > 0)
                    {
                        Available = getUnitStatusChartDt.Rows[0]["Available"].ToString();
                        Rented = getUnitStatusChartDt.Rows[0]["Rented"].ToString();
                        Undermaintenance = getUnitStatusChartDt.Rows[0]["Undermaintenance"].ToString();
                        UnderProplem = getUnitStatusChartDt.Rows[0]["UnderProplem"].ToString();
                    }
                    //-----------------------------------------------------------------------------------------------------------------------
                    double U_C = 0; double B_C = 0;
                    DataTable Dt = new DataTable();
                    MySqlCommand Cmd = new MySqlCommand("SELECT End_Date  FROM contract where New_ReNewed_Expaired ='1'", _sqlCon);
                    MySqlDataAdapter Da = new MySqlDataAdapter(Cmd);
                    Da.Fill(Dt);
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        string EndDate = Dt.Rows[i]["End_Date"].ToString();
                        DateTime End_Date = Convert.ToDateTime(EndDate);
                        var today = DateTime.Now;
                        var diffOfDates = (End_Date - today).Days;
                        if (diffOfDates >= 0 && diffOfDates <= 60) { U_C++; }
                    }

                    DataTable Dt2 = new DataTable();
                    MySqlCommand Cmd2 = new MySqlCommand("SELECT End_Date  FROM building_contract where New_ReNewed_Expaired ='1' ", _sqlCon);
                    MySqlDataAdapter Da2 = new MySqlDataAdapter(Cmd2);
                    Da2.Fill(Dt2);
                    for (int i = 0; i < Dt2.Rows.Count; i++)
                    {
                        string EndDate = Dt2.Rows[i]["End_Date"].ToString();
                        DateTime End_Date = Convert.ToDateTime(EndDate);
                        var today = DateTime.Now;
                        var diffOfDates = (End_Date - today).Days;
                        if (diffOfDates >= 0 && diffOfDates <= 60) { B_C++; }
                    }
                    //-----------------------------------------------------------------------------------------------------------------------
                    _sqlCon.Close();
                    Syncfusion.JavaScript.DataVisualization.Models.Series series = Units_Statuse.Series[0];
                    series.Points.Clear();
                    series.Points.Add(new Points("شاغر", double.Parse(Available)));
                    series.Points.Add(new Points("مؤجر", double.Parse(Rented)));
                    series.Points.Add(new Points("تحت الانشاء أو الصيانة", double.Parse(Undermaintenance)));
                    series.Points.Add(new Points("موجد نزاع", double.Parse(UnderProplem)));
                    series.Points.Add(new Points("", 0));
                    series.Points.Add(new Points("قيد الإنتهاء", (U_C + B_C)));




                    // ********************************  المصاريف الغدارية و العقارية و الصيانة************************************
                    Syncfusion.JavaScript.DataVisualization.Models.Series series1 = Expenses_Chart.Series[0];
                    List<ColumnChartData> data = new List<ColumnChartData>();
                    data.Add(new ColumnChartData("المصاريف لكافة العقارات", Convert.ToDouble(Management_Expenses_D_Y_M), Convert.ToDouble(RealEstate_Expenses_D_Y_M), Convert.ToDouble(Maintenance_Expenses_D_Y_M)));
                    this.Expenses_Chart.DataSource = data;
                    this.Expenses_Chart.DataBind();

                    // ********************************    العائد الفعلي **********************************
                    double total_Expensess = Convert.ToDouble(Convert.ToDouble(Management_Expenses_D_Y_M) + Convert.ToDouble(RealEstate_Expenses_D_Y_M) + Convert.ToDouble(Maintenance_Expenses_D_Y_M));
                    lbl_Real_Income.Text = "العائد الفعلي";

                    double Real_Income = Convert.ToDouble(Collection_D_Y_M) - total_Expensess;
                    Syncfusion.JavaScript.DataVisualization.Models.Series Real_Income_series = Real_Income_Chart_2.Series[0];
                    List<ColumnChartData> Real_Income_data = new List<ColumnChartData>();
                    Real_Income_data.Add(new ColumnChartData("العائد الفعلي", Convert.ToDouble(Collection_D_Y_M), Real_Income, total_Expensess));
                    this.Real_Income_Chart_2.DataSource = Real_Income_data;
                    this.Real_Income_Chart_2.DataBind();
                    _sqlCon.Close();
                    //************************************* الربح الصافي **********************************************************
                    string Sum_Building_Value_Quary = "Select Sum(Building_Value)Sum_Building_Value From building";
                    string Sum_Building_Value = "0";
                    _sqlCon.Open();
                    MySqlDataAdapter VSum_Building_Value_Sda = new MySqlDataAdapter(Sum_Building_Value_Quary, _sqlCon);
                    DataTable VSum_Building_Value_Dt = new DataTable();
                    VSum_Building_Value_Sda.Fill(VSum_Building_Value_Dt);
                    if (VSum_Building_Value_Dt.Rows.Count > 0)
                    {
                        if (VSum_Building_Value_Dt.Rows[0]["Sum_Building_Value"].ToString() == "") { Sum_Building_Value = "0"; } else { Sum_Building_Value = VSum_Building_Value_Dt.Rows[0]["Sum_Building_Value"].ToString(); }
                    }

                    Label1.Text = Convert.ToString(Convert.ToDouble(Sum_Building_Value) / Convert.ToDouble(txt_Destruction_Value.Text));

                    Label2.Text = Convert.ToString((Convert.ToDouble(Collection_D_Y) - total_Expensess));

                    Label3.Text = Convert.ToString((Convert.ToDouble(Sum_Building_Value) / Convert.ToDouble(txt_Destruction_Value.Text)) - ((Convert.ToDouble(Collection_D_Y) - total_Expensess)));


                    Syncfusion.JavaScript.DataVisualization.Models.Series series_Chart2 = Chart2.Series[0];
                    List<ColumnChartData> data_Chart2 = new List<ColumnChartData>();
                    data_Chart2.Add(new ColumnChartData("", Convert.ToDouble(Label1.Text), Convert.ToDouble(Label3.Text), (Convert.ToDouble(Label2.Text))));
                    this.Chart2.DataSource = data_Chart2;
                    this.Chart2.DataBind();
                    _sqlCon.Close();
                    //********************************* متبقي التوزيع  ************************************
                    string Sum_Remainder_Distribution_Quary = "select Sum(Salary)Sum_Salary  From owner ";
                    string Sum_Remainder_Distribution = "0";
                    _sqlCon.Open();
                    MySqlDataAdapter Sum_Remainder_Distribution_Sda = new MySqlDataAdapter(Sum_Remainder_Distribution_Quary, _sqlCon);
                    DataTable Sum_Remainder_Distribution_Dt = new DataTable();
                    Sum_Remainder_Distribution_Sda.Fill(Sum_Remainder_Distribution_Dt);
                    if (Sum_Remainder_Distribution_Dt.Rows.Count > 0)
                    {
                        if (Sum_Remainder_Distribution_Dt.Rows[0]["Sum_Salary"].ToString() == "") { Sum_Remainder_Distribution = "0"; } else { Sum_Remainder_Distribution = Sum_Remainder_Distribution_Dt.Rows[0]["Sum_Salary"].ToString(); }
                    }
                    //الرواتب
                    Label4.Text = Convert.ToString(Convert.ToDouble(Sum_Remainder_Distribution));

                    // الربح الصافي
                    Label5.Text = Label3.Text;

                    double X = Convert.ToDouble(Label5.Text) - Convert.ToDouble(Label4.Text);
                    Label6.Text = Convert.ToString(X);
                    Syncfusion.JavaScript.DataVisualization.Models.Series series_Chart3 = Chart3.Series[0];
                    List<ColumnChartData> data_Chart3 = new List<ColumnChartData>();
                    data_Chart3.Add(new ColumnChartData("", Convert.ToDouble(Label4.Text), Convert.ToDouble(Label5.Text), (Convert.ToDouble(Label6.Text))));
                    this.Chart3.DataSource = data_Chart3;
                    this.Chart3.DataBind();
                    _sqlCon.Close();
                    // ********************************    التدفق النقدي **********************************
                    lbl_Cash_Flow.Text = "التدفق النقدي لكافة الملكيات لعام " + Year_DropDownList.SelectedItem.Text;

                    _sqlCon.Open();
                    using (MySqlCommand Cash_flow_Cmd = new MySqlCommand("Dashboard_Test", _sqlCon))
                    {
                        Cash_flow_Cmd.CommandType = CommandType.StoredProcedure;
                        using (MySqlDataAdapter Cash_flow_Sda = new MySqlDataAdapter(Cash_flow_Cmd))
                        {
                            DataTable Cash_flow_Dt = new DataTable();
                            Cash_flow_Sda.Fill(Cash_flow_Dt);
                            if (Cash_flow_Dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < Cash_flow_Dt.Rows.Count; i++)
                                {
                                    string Y_Cheques_Date = Convert.ToString(Convert.ToDateTime(Cash_flow_Dt.Rows[i]["Datee"].ToString()).Year);
                                    string M_Cheques_Date = Convert.ToString(Convert.ToDateTime(Cash_flow_Dt.Rows[i]["Datee"].ToString()).Month);
                                    string O_ID = Cash_flow_Dt.Rows[i]["O_ID"].ToString();
                                    string B_ID = Cash_flow_Dt.Rows[i]["B_ID"].ToString();

                                    if (M_Cheques_Date == "1" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_1 = Sum_Expected_Y_M_1 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "2" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_2 = Sum_Expected_Y_M_2 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "3" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_3 = Sum_Expected_Y_M_3 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "4" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_4 = Sum_Expected_Y_M_4 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "5" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_5 = Sum_Expected_Y_M_5 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "6" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_6 = Sum_Expected_Y_M_6 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "7" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_7 = Sum_Expected_Y_M_7 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "8" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_8 = Sum_Expected_Y_M_8 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "9" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_9 = Sum_Expected_Y_M_9 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "10" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_10 = Sum_Expected_Y_M_10 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "11" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_11 = Sum_Expected_Y_M_11 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "12" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text)
                                    { Sum_Expected_Y_M_12 = Sum_Expected_Y_M_12 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }


                                }
                            }
                        }
                    }
                    _sqlCon.Close();
                    string Quary2 = "select " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '1')Sum_Income_Y_M_1,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '2')Sum_Income_Y_M_2,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '3')Sum_Income_Y_M_3,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '4')Sum_Income_Y_M_4,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '5')Sum_Income_Y_M_5,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '6')Sum_Income_Y_M_6,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '7')Sum_Income_Y_M_7,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '8')Sum_Income_Y_M_8, " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '9')Sum_Income_Y_M_9,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '10')Sum_Income_Y_M_10,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '11')Sum_Income_Y_M_11,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Mounth = '12')Sum_Income_Y_M_12, " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '1')Sum_Management_Expenses_Y_M_1,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '2')Sum_Management_Expenses_Y_M_2,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '3')Sum_Management_Expenses_Y_M_3,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '4')Sum_Management_Expenses_Y_M_4,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '5')Sum_Management_Expenses_Y_M_5,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '6')Sum_Management_Expenses_Y_M_6,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '7')Sum_Management_Expenses_Y_M_7,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '8')Sum_Management_Expenses_Y_M_8, " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '9')Sum_Management_Expenses_Y_M_9,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '10')Sum_Management_Expenses_Y_M_10,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '11')Sum_Management_Expenses_Y_M_11,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and Mounth = '12')Sum_Management_Expenses_Y_M_12 ," +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '1')Sum_RealEstate_Expenses_Y_M_1,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '2')Sum_RealEstate_Expenses_Y_M_2,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '3')Sum_RealEstate_Expenses_Y_M_3,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '4')Sum_RealEstate_Expenses_Y_M_4,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '5')Sum_RealEstate_Expenses_Y_M_5,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '6')Sum_RealEstate_Expenses_Y_M_6,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '7')Sum_RealEstate_Expenses_Y_M_7,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '8')Sum_RealEstate_Expenses_Y_M_8, " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '9')Sum_RealEstate_Expenses_Y_M_9,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '10')Sum_RealEstate_Expenses_Y_M_10,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '11')Sum_RealEstate_Expenses_Y_M_11,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '12')Sum_RealEstate_Expenses_Y_M_12, " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '1')Sum_Maintenance_Expenses_Y_M_1,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '2')Sum_Maintenance_Expenses_Y_M_2,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '3')Sum_Maintenance_Expenses_Y_M_3,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '4')Sum_Maintenance_Expenses_Y_M_4,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '5')Sum_Maintenance_Expenses_Y_M_5,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '6')Sum_Maintenance_Expenses_Y_M_6,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '7')Sum_Maintenance_Expenses_Y_M_7,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '8')Sum_Maintenance_Expenses_Y_M_8, " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '9')Sum_Maintenance_Expenses_Y_M_9,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '10')Sum_Maintenance_Expenses_Y_M_10,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '11')Sum_Maintenance_Expenses_Y_M_11,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Mounth = '12')Sum_Maintenance_Expenses_Y_M_12";
                    _sqlCon.Open();
                    MySqlDataAdapter Collection_Expenses_Sda = new MySqlDataAdapter(Quary2, _sqlCon);
                    DataTable getCollection_Expenses_Dt = new DataTable();
                    Collection_Expenses_Sda.Fill(getCollection_Expenses_Dt);
                    if (getCollection_Expenses_Dt.Rows.Count > 0)
                    {
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_1"].ToString() == "") { Sum_Income_Y_M_1 = "0"; } else { Sum_Income_Y_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_2"].ToString() == "") { Sum_Income_Y_M_2 = "0"; } else { Sum_Income_Y_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_3"].ToString() == "") { Sum_Income_Y_M_3 = "0"; } else { Sum_Income_Y_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_4"].ToString() == "") { Sum_Income_Y_M_4 = "0"; } else { Sum_Income_Y_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_5"].ToString() == "") { Sum_Income_Y_M_5 = "0"; } else { Sum_Income_Y_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_6"].ToString() == "") { Sum_Income_Y_M_6 = "0"; } else { Sum_Income_Y_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_7"].ToString() == "") { Sum_Income_Y_M_7 = "0"; } else { Sum_Income_Y_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_8"].ToString() == "") { Sum_Income_Y_M_8 = "0"; } else { Sum_Income_Y_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_9"].ToString() == "") { Sum_Income_Y_M_9 = "0"; } else { Sum_Income_Y_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_10"].ToString() == "") { Sum_Income_Y_M_10 = "0"; } else { Sum_Income_Y_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_11"].ToString() == "") { Sum_Income_Y_M_11 = "0"; } else { Sum_Income_Y_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_12"].ToString() == "") { Sum_Income_Y_M_12 = "0"; } else { Sum_Income_Y_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_M_12"].ToString(); }

                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_1"].ToString() == "") { Sum_Management_Expenses_Y_M_1 = "0"; } else { Sum_Management_Expenses_Y_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_2"].ToString() == "") { Sum_Management_Expenses_Y_M_2 = "0"; } else { Sum_Management_Expenses_Y_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_3"].ToString() == "") { Sum_Management_Expenses_Y_M_3 = "0"; } else { Sum_Management_Expenses_Y_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_4"].ToString() == "") { Sum_Management_Expenses_Y_M_4 = "0"; } else { Sum_Management_Expenses_Y_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_5"].ToString() == "") { Sum_Management_Expenses_Y_M_5 = "0"; } else { Sum_Management_Expenses_Y_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_6"].ToString() == "") { Sum_Management_Expenses_Y_M_6 = "0"; } else { Sum_Management_Expenses_Y_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_7"].ToString() == "") { Sum_Management_Expenses_Y_M_7 = "0"; } else { Sum_Management_Expenses_Y_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_8"].ToString() == "") { Sum_Management_Expenses_Y_M_8 = "0"; } else { Sum_Management_Expenses_Y_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_9"].ToString() == "") { Sum_Management_Expenses_Y_M_9 = "0"; } else { Sum_Management_Expenses_Y_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_10"].ToString() == "") { Sum_Management_Expenses_Y_M_10 = "0"; } else { Sum_Management_Expenses_Y_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_11"].ToString() == "") { Sum_Management_Expenses_Y_M_11 = "0"; } else { Sum_Management_Expenses_Y_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_12"].ToString() == "") { Sum_Management_Expenses_Y_M_12 = "0"; } else { Sum_Management_Expenses_Y_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_M_12"].ToString(); }

                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_1"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_1 = "0"; } else { Sum_RealEstate_Expenses_Y_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_2"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_2 = "0"; } else { Sum_RealEstate_Expenses_Y_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_3"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_3 = "0"; } else { Sum_RealEstate_Expenses_Y_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_4"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_4 = "0"; } else { Sum_RealEstate_Expenses_Y_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_5"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_5 = "0"; } else { Sum_RealEstate_Expenses_Y_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_6"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_6 = "0"; } else { Sum_RealEstate_Expenses_Y_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_7"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_7 = "0"; } else { Sum_RealEstate_Expenses_Y_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_8"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_8 = "0"; } else { Sum_RealEstate_Expenses_Y_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_9"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_9 = "0"; } else { Sum_RealEstate_Expenses_Y_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_10"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_10 = "0"; } else { Sum_RealEstate_Expenses_Y_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_11"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_11 = "0"; } else { Sum_RealEstate_Expenses_Y_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_12"].ToString() == "") { Sum_RealEstate_Expenses_Y_M_12 = "0"; } else { Sum_RealEstate_Expenses_Y_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_M_12"].ToString(); }

                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_1"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_1 = "0"; } else { Sum_Maintenance_Expenses_Y_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_2"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_2 = "0"; } else { Sum_Maintenance_Expenses_Y_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_3"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_3 = "0"; } else { Sum_Maintenance_Expenses_Y_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_4"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_4 = "0"; } else { Sum_Maintenance_Expenses_Y_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_5"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_5 = "0"; } else { Sum_Maintenance_Expenses_Y_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_6"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_6 = "0"; } else { Sum_Maintenance_Expenses_Y_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_7"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_7 = "0"; } else { Sum_Maintenance_Expenses_Y_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_8"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_8 = "0"; } else { Sum_Maintenance_Expenses_Y_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_9"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_9 = "0"; } else { Sum_Maintenance_Expenses_Y_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_10"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_10 = "0"; } else { Sum_Maintenance_Expenses_Y_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_11"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_11 = "0"; } else { Sum_Maintenance_Expenses_Y_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_12"].ToString() == "") { Sum_Maintenance_Expenses_Y_M_12 = "0"; } else { Sum_Maintenance_Expenses_Y_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_M_12"].ToString(); }
                    }
                    List<LineChartData> Data = new List<LineChartData>();
                    Data.Add(new LineChartData(01, Sum_Expected_Y_M_1, Convert.ToDouble(Sum_Income_Y_M_1), Convert.ToDouble(Sum_Management_Expenses_Y_M_1) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_1) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_1)));
                    Data.Add(new LineChartData(02, Sum_Expected_Y_M_2, Convert.ToDouble(Sum_Income_Y_M_2), Convert.ToDouble(Sum_Management_Expenses_Y_M_2) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_2) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_2)));
                    Data.Add(new LineChartData(03, Sum_Expected_Y_M_3, Convert.ToDouble(Sum_Income_Y_M_3), Convert.ToDouble(Sum_Management_Expenses_Y_M_3) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_3) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_3)));
                    Data.Add(new LineChartData(04, Sum_Expected_Y_M_4, Convert.ToDouble(Sum_Income_Y_M_4), Convert.ToDouble(Sum_Management_Expenses_Y_M_4) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_4) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_4)));
                    Data.Add(new LineChartData(05, Sum_Expected_Y_M_5, Convert.ToDouble(Sum_Income_Y_M_5), Convert.ToDouble(Sum_Management_Expenses_Y_M_5) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_5) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_5)));
                    Data.Add(new LineChartData(06, Sum_Expected_Y_M_6, Convert.ToDouble(Sum_Income_Y_M_6), Convert.ToDouble(Sum_Management_Expenses_Y_M_6) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_6) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_6)));
                    Data.Add(new LineChartData(07, Sum_Expected_Y_M_7, Convert.ToDouble(Sum_Income_Y_M_7), Convert.ToDouble(Sum_Management_Expenses_Y_M_7) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_7) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_7)));
                    Data.Add(new LineChartData(08, Sum_Expected_Y_M_8, Convert.ToDouble(Sum_Income_Y_M_8), Convert.ToDouble(Sum_Management_Expenses_Y_M_8) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_8) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_8)));
                    Data.Add(new LineChartData(09, Sum_Expected_Y_M_9, Convert.ToDouble(Sum_Income_Y_M_9), Convert.ToDouble(Sum_Management_Expenses_Y_M_9) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_9) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_9)));
                    Data.Add(new LineChartData(10, Sum_Expected_Y_M_10, Convert.ToDouble(Sum_Income_Y_M_10), Convert.ToDouble(Sum_Management_Expenses_Y_M_10) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_10) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_10)));
                    Data.Add(new LineChartData(11, Sum_Expected_Y_M_11, Convert.ToDouble(Sum_Income_Y_M_11), Convert.ToDouble(Sum_Management_Expenses_Y_M_11) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_11) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_11)));
                    Data.Add(new LineChartData(12, Sum_Expected_Y_M_12, Convert.ToDouble(Sum_Income_Y_M_12), Convert.ToDouble(Sum_Management_Expenses_Y_M_12) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_M_12) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_M_12)));
                    this.Chart1.DataSource = Data;
                    this.Chart1.DataBind();
                    _sqlCon.Close();
                    //****************************************************  القيمة الإيجارية **********************************************************************************************************
                    string Quary_virtual_Value = "select U.* ,O.Owner_Ship_Id FROM units U  " +
                        "left join building B on(U.building_Building_Id = B.building_Id) " +
                        "left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) Where Half != 1 ";
                    _sqlCon.Open();
                    MySqlDataAdapter virtual_Value_Sda = new MySqlDataAdapter(Quary_virtual_Value, _sqlCon);
                    DataTable virtual_Value_Dt = new DataTable();
                    virtual_Value_Sda.Fill(virtual_Value_Dt);
                    if (virtual_Value_Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < virtual_Value_Dt.Rows.Count; i++)
                        {
                            if (virtual_Value_Dt.Rows[i]["virtual_Value"].ToString() == "") { Sum_virtual_Value = Sum_virtual_Value + 0; }
                            else { if (virtual_Value_Dt.Rows[i]["virtual_Value"].ToString() == "") { Sum_virtual_Value = Sum_virtual_Value + 0; } else { Sum_virtual_Value = Sum_virtual_Value + Convert.ToDouble(virtual_Value_Dt.Rows[i]["virtual_Value"].ToString()); } }

                        }
                    }
                    Syncfusion.JavaScript.DataVisualization.Models.Series series_Rental_Value = Rental_Value.Series[0];
                    List<ColumnChartData> data_Rental_Value = new List<ColumnChartData>();
                    double Total_Expected = 0;
                    Total_Expected = Sum_Expected_Y_M_1 + Sum_Expected_Y_M_2 + Sum_Expected_Y_M_3 + Sum_Expected_Y_M_4 + Sum_Expected_Y_M_5 + Sum_Expected_Y_M_6 + Sum_Expected_Y_M_7 +
                        Sum_Expected_Y_M_8 + Sum_Expected_Y_M_9 + Sum_Expected_Y_M_10 + Sum_Expected_Y_M_11 + Sum_Expected_Y_M_12;
                    double Total_Income = 0;
                    Total_Income = Convert.ToDouble(Sum_Income_Y_M_1) + Convert.ToDouble(Sum_Income_Y_M_2) + Convert.ToDouble(Sum_Income_Y_M_3) + Convert.ToDouble(Sum_Income_Y_M_4) +
                            Convert.ToDouble(Sum_Income_Y_M_5) + Convert.ToDouble(Sum_Income_Y_M_6) + Convert.ToDouble(Sum_Income_Y_M_7) + Convert.ToDouble(Sum_Income_Y_M_8) +
                            Convert.ToDouble(Sum_Income_Y_M_9) + Convert.ToDouble(Sum_Income_Y_M_10) + Convert.ToDouble(Sum_Income_Y_M_11) + Convert.ToDouble(Sum_Income_Y_M_12);


                    data_Rental_Value.Add(new ColumnChartData("القيمة الإيجارية لكافة العقارات", Sum_virtual_Value, Total_Expected, Total_Income));
                    this.Rental_Value.DataSource = data_Rental_Value;
                    this.Rental_Value.DataBind();
                    _sqlCon.Close();
                    //****************************************************  القيمة القارية **********************************************************************************************************
                    string Sum_Collection = "0";
                    string Rental_Value_Quary = "Select(Select Sum(Building_Value) From building )Sum_Bulidng_Value," +
                                                "(Select Sum(Land_Value) From owner_ship )Sum_Land_Value," +
                                                "(Select Sum(Collection) From collection_table where Year='" + Year + "')Sum_Collection";
                    _sqlCon.Open();
                    MySqlDataAdapter Value_Quary_Sda = new MySqlDataAdapter(Rental_Value_Quary, _sqlCon);
                    DataTable get_Value_Quary_Dt = new DataTable();
                    Value_Quary_Sda.Fill(get_Value_Quary_Dt);
                    if (get_Value_Quary_Dt.Rows.Count > 0)
                    {
                        if (get_Value_Quary_Dt.Rows[0]["Sum_Bulidng_Value"].ToString() == "") { Sum_Bulidng_Value = "0"; } else { Sum_Bulidng_Value = get_Value_Quary_Dt.Rows[0]["Sum_Bulidng_Value"].ToString(); }
                        if (get_Value_Quary_Dt.Rows[0]["Sum_Land_Value"].ToString() == "") { Sum_Land_Value = "0"; } else { Sum_Land_Value = get_Value_Quary_Dt.Rows[0]["Sum_Land_Value"].ToString(); }
                        if (get_Value_Quary_Dt.Rows[0]["Sum_Collection"].ToString() == "") { Sum_Collection = "0"; } else { Sum_Collection = get_Value_Quary_Dt.Rows[0]["Sum_Collection"].ToString(); }
                    }
                    Lbl_RealEstae.Text = "العائد على القيمة العقارية";
                    Syncfusion.JavaScript.DataVisualization.Models.Series series4 = RealEstae_Chart.Series[0];
                    series4.Points.Clear();
                    series4.Points.Add(new Points("الدخل السنوي", Convert.ToDouble(Sum_Collection)));
                    series4.Points.Add(new Points("قيمة العقار", Convert.ToDouble(Sum_Bulidng_Value) + Convert.ToDouble(Sum_Land_Value)));
                    _sqlCon.Close();

                    lbl_RealEstate_Value.Text = (Convert.ToDouble(Sum_Bulidng_Value) + Convert.ToDouble(Sum_Land_Value)).ToString("###,###,###");
                    Yearly_Income.Text = (Convert.ToDouble(Sum_Collection)).ToString("###,###,###");
                    lbl_RealEstate_Value_percentage.Text = (((Convert.ToDouble(Sum_Collection)) / (Convert.ToDouble(Sum_Bulidng_Value) + Convert.ToDouble(Sum_Land_Value))) * 100).ToString("0.00 ") + "%";
                    //*************************** الإستدامة و  النمو **********************************************************************************************************************************
                    Real_Estate_Sustainability();
                    //*************************** الإهلاك **********************************************************************************************************************************
                    div_1.Visible = false; div_2.Visible = true;
                    Label22.Text = "الهالك السنوي لكل الملكيات  :";
                    Label23.Text = (Convert.ToDouble(Sum_Bulidng_Value) / Convert.ToDouble(txt_Destruction_Value.Text)).ToString("###,###,###");

                    Label24.Text = " االمتبقي من قيمة كل الملكيات  :";
                    Label25.Text = (Convert.ToDouble(Sum_Bulidng_Value) - Convert.ToDouble(Label23.Text)).ToString("###,###,###");

                    Syncfusion.JavaScript.DataVisualization.Models.Series series5 = destruction_Char.Series[0];
                    series5.Points.Clear();
                }
                // 2-2
                else if (Ownership_Name_DropDownList.SelectedItem.Text != "كل الملكيات" && Building_Name_DropDownList.SelectedItem.Text == "كل الأبنية")
                {
                    Building_Condition();
                    // **************************** النسب المئوية للجنسيات ********************************************************
                    percent_nationality_GridView();
                    Tenant_Evaluation();
                    //****************************** الرهن العقاري *****************************************************************
                    Mortgage_All();
                    // ******************************حالات الوحدات *******************************************************************




                    double Available = 0; double Rented = 0; double Undermaintenance = 0; double UnderProplem = 0;
                    string Building_Id_Quairy = "select Building_Id from building where owner_ship_Owner_Ship_Id ='" + Ownership_Name_DropDownList.SelectedValue + "'";
                    _sqlCon.Open();
                    DataTable get_Building_Id_Dt = new DataTable();
                    MySqlCommand get_Building_Id_Cmd = new MySqlCommand(Building_Id_Quairy, _sqlCon);
                    MySqlDataAdapter get_Building_Id_Da = new MySqlDataAdapter(get_Building_Id_Cmd);
                    get_Building_Id_Da.Fill(get_Building_Id_Dt);
                    if (get_Building_Id_Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < get_Building_Id_Dt.Rows.Count; i++)
                        {
                            string Building_Id = get_Building_Id_Dt.Rows[i]["Building_Id"].ToString();
                            string Quairy = "select " +
                                "( Select count(*) from units where Half != 1 and building_Building_Id = '" + Building_Id + "' and unit_condition_Unit_Condition_Id='1')Rented , " +
                                "(Select count(*) from units where Half != 1 and building_Building_Id = '" + Building_Id + "' and unit_condition_Unit_Condition_Id = '2')Available , " +
                                "(Select count(*) from units where Half != 1 and building_Building_Id = '" + Building_Id + "' and unit_condition_Unit_Condition_Id = '3')Under_Maintenance ," +
                                "(Select count(*) from units where Half != 1 and building_Building_Id = '" + Building_Id + "' and unit_condition_Unit_Condition_Id = '4')Under_Proplem ";

                            DataTable getUnitStatusChartDt = new DataTable();
                            MySqlCommand getUnitStatusChartCmd = new MySqlCommand(Quairy, _sqlCon);
                            MySqlDataAdapter getUnitStatusChartDa = new MySqlDataAdapter(getUnitStatusChartCmd);
                            getUnitStatusChartDa.Fill(getUnitStatusChartDt);
                            if (getUnitStatusChartDt.Rows.Count > 0)
                            {
                                Available = Available + double.Parse(getUnitStatusChartDt.Rows[0]["Available"].ToString());
                                Rented = Rented + double.Parse(getUnitStatusChartDt.Rows[0]["Rented"].ToString());
                                Undermaintenance = Undermaintenance + double.Parse(getUnitStatusChartDt.Rows[0]["Under_Maintenance"].ToString());
                                UnderProplem = UnderProplem + double.Parse(getUnitStatusChartDt.Rows[0]["Under_Proplem"].ToString());

                            }
                            //-----------------------------------------------------------------------------------------------------------------------
                            double U_C = 0; double B_C = 0;
                            string Q = "SELECT  C.End_Date , C.units_Unit_ID ,  " +
                                        "B.Building_Id , O.Owner_Ship_Id FROM contract C " +
                                        "left join units U on (C.units_Unit_ID = U.Unit_Id) " +
                                        "left join building B on (U.building_Building_Id = B.building_Id) " +
                                        "left join owner_ship O on (B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                                        "where C.New_ReNewed_Expaired ='1' and  O.Owner_Ship_Id = '" + Ownership_Name_DropDownList.SelectedValue + "';";
                            DataTable Dt = new DataTable();
                            MySqlCommand Cmd = new MySqlCommand(Q, _sqlCon);
                            MySqlDataAdapter Da = new MySqlDataAdapter(Cmd);
                            Da.Fill(Dt);
                            for (int K = 0; K < Dt.Rows.Count; K++)
                            {
                                string EndDate = Dt.Rows[K]["End_Date"].ToString();
                                DateTime End_Date = Convert.ToDateTime(EndDate);
                                var today = DateTime.Now;
                                var diffOfDates = (End_Date - today).Days;
                                if (diffOfDates >= 0 && diffOfDates <= 60) { U_C++; }
                            }



                            string Q2 = "SELECT  C.End_Date , C.building_Building_Id ,  " +
                                        "O.Owner_Ship_Id " +
                                        "FROM building_contract C " +
                                        "left join building B on(C.building_Building_Id = B.Building_Id) " +
                                        "left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                                        "where C.New_ReNewed_Expaired ='1' and   O.Owner_Ship_Id = '" + Ownership_Name_DropDownList.SelectedValue + "'; ";
                            DataTable Dt2 = new DataTable();
                            MySqlCommand Cmd2 = new MySqlCommand(Q2, _sqlCon);
                            MySqlDataAdapter Da2 = new MySqlDataAdapter(Cmd2);
                            Da2.Fill(Dt2);
                            for (int K = 0; K < Dt2.Rows.Count; K++)
                            {
                                string EndDate = Dt2.Rows[K]["End_Date"].ToString();
                                DateTime End_Date = Convert.ToDateTime(EndDate);
                                var today = DateTime.Now;
                                var diffOfDates = (End_Date - today).Days;
                                if (diffOfDates >= 0 && diffOfDates <= 60) { B_C++; }
                            }
                            //-----------------------------------------------------------------------------------------------------------------------
                            Syncfusion.JavaScript.DataVisualization.Models.Series series = Units_Statuse.Series[0];
                            series.Points.Clear();
                            series.Points.Add(new Points("شاغر", Available));
                            series.Points.Add(new Points("مؤجر", Rented));
                            series.Points.Add(new Points("تحت الانشاء أو الصيانة", Undermaintenance));
                            series.Points.Add(new Points("موجر نزاع", UnderProplem));
                            series.Points.Add(new Points("", 0));
                            series.Points.Add(new Points("قيد الإنتهاء", (U_C + B_C)));


                        }
                    }




                    // ********************************  المصاريف الغدارية و العقارية و الصيانة************************************
                    Syncfusion.JavaScript.DataVisualization.Models.Series series1 = Expenses_Chart.Series[0];
                    List<ColumnChartData> data = new List<ColumnChartData>();
                    data.Add(new ColumnChartData(Ownership_Name_DropDownList.SelectedItem.Text, Convert.ToDouble(Management_Expenses_D_Y_M_O), Convert.ToDouble(RealEstate_Expenses_D_Y_M_O), Convert.ToDouble(Maintenance_Expenses_D_Y_M_O)));
                    this.Expenses_Chart.DataSource = data;
                    this.Expenses_Chart.DataBind();

                    // ********************************    العائد الفعلي **********************************
                    double total_Expensess = Convert.ToDouble(Convert.ToDouble(Management_Expenses_D_Y_M_O) + Convert.ToDouble(RealEstate_Expenses_D_Y_M_O) + Convert.ToDouble(Maintenance_Expenses_D_Y_M_O));
                    lbl_Real_Income.Text = "العائد الفعلي";

                    double Real_Income = Convert.ToDouble(Collection_D_Y_M_O) - total_Expensess;
                    Syncfusion.JavaScript.DataVisualization.Models.Series Real_Income_series = Real_Income_Chart_2.Series[0];
                    List<ColumnChartData> Real_Income_data = new List<ColumnChartData>();
                    Real_Income_data.Add(new ColumnChartData("العائد الفعلي", Convert.ToDouble(Collection_D_Y_M_O), Real_Income, total_Expensess));
                    this.Real_Income_Chart_2.DataSource = Real_Income_data;
                    this.Real_Income_Chart_2.DataBind();
                    _sqlCon.Close();
                    //************************************* الربح الصافي **********************************************************
                    string Sum_Building_Value_Quary = "Select Sum(Building_Value) Sum_Building_Value From building where owner_ship_Owner_Ship_Id ='" + OwnerShip + "'";
                    string Sum_Building_Value = "0";
                    _sqlCon.Open();
                    MySqlDataAdapter VSum_Building_Value_Sda = new MySqlDataAdapter(Sum_Building_Value_Quary, _sqlCon);
                    DataTable VSum_Building_Value_Dt = new DataTable();
                    VSum_Building_Value_Sda.Fill(VSum_Building_Value_Dt);
                    if (VSum_Building_Value_Dt.Rows.Count > 0)
                    {
                        if (VSum_Building_Value_Dt.Rows[0]["Sum_Building_Value"].ToString() == "") { Sum_Building_Value = "0"; } else { Sum_Building_Value = VSum_Building_Value_Dt.Rows[0]["Sum_Building_Value"].ToString(); }
                    }

                    Label1.Text = Convert.ToString(Convert.ToDouble(Sum_Building_Value) / Convert.ToDouble(txt_Destruction_Value.Text));

                    Label2.Text = Convert.ToString((Convert.ToDouble(Collection_D_Y_O) - total_Expensess));

                    Label3.Text = Convert.ToString((Convert.ToDouble(Sum_Building_Value) / Convert.ToDouble(txt_Destruction_Value.Text)) - ((Convert.ToDouble(Collection_D_Y_O) - total_Expensess)));


                    Syncfusion.JavaScript.DataVisualization.Models.Series series_Chart2 = Chart2.Series[0];
                    List<ColumnChartData> data_Chart2 = new List<ColumnChartData>();
                    data_Chart2.Add(new ColumnChartData("", Convert.ToDouble(Label1.Text), Convert.ToDouble(Label3.Text), (Convert.ToDouble(Label2.Text))));

                    this.Chart2.DataSource = data_Chart2;
                    this.Chart2.DataBind();
                    _sqlCon.Close();
                    //********************************* متبقي التوزيع  ************************************
                    string Sum_Remainder_Distribution_Quary = "select(select owner_Owner_Id from owner_ship where Owner_Ship_Id='" + OwnerShip + "')OwnerID,(select Salary from owner where Owner_Id = OwnerID)Sum_Salary";
                    string Sum_Remainder_Distribution = "0";
                    _sqlCon.Open();
                    MySqlDataAdapter Sum_Remainder_Distribution_Sda = new MySqlDataAdapter(Sum_Remainder_Distribution_Quary, _sqlCon);
                    DataTable Sum_Remainder_Distribution_Dt = new DataTable();
                    Sum_Remainder_Distribution_Sda.Fill(Sum_Remainder_Distribution_Dt);
                    if (Sum_Remainder_Distribution_Dt.Rows.Count > 0)
                    {
                        if (Sum_Remainder_Distribution_Dt.Rows[0]["Sum_Salary"].ToString() == "") { Sum_Remainder_Distribution = "0"; } else { Sum_Remainder_Distribution = Sum_Remainder_Distribution_Dt.Rows[0]["Sum_Salary"].ToString(); }
                    }
                    //الرواتب
                    Label4.Text = Convert.ToString(Convert.ToDouble(Sum_Remainder_Distribution));

                    // الربح الصافي
                    Label5.Text = Label3.Text;

                    double X = Convert.ToDouble(Label5.Text) - Convert.ToDouble(Label4.Text);
                    Label6.Text = Convert.ToString(X);
                    Syncfusion.JavaScript.DataVisualization.Models.Series series_Chart3 = Chart3.Series[0];
                    List<ColumnChartData> data_Chart3 = new List<ColumnChartData>();
                    data_Chart3.Add(new ColumnChartData("", Convert.ToDouble(Label4.Text), Convert.ToDouble(Label5.Text), (Convert.ToDouble(Label6.Text))));
                    this.Chart3.DataSource = data_Chart3;
                    this.Chart3.DataBind();
                    _sqlCon.Close();

                    // ********************************    التدفق النقدي **********************************
                    lbl_Cash_Flow.Text = "التدفق النقدي لكافة الملكيات لعام " + Year_DropDownList.SelectedItem.Text + " و البناء   " + Building_Name_DropDownList.SelectedItem.Text;
                    _sqlCon.Open();
                    using (MySqlCommand Cash_flow_Cmd = new MySqlCommand("Dashboard_Test", _sqlCon))
                    {
                        Cash_flow_Cmd.CommandType = CommandType.StoredProcedure;
                        using (MySqlDataAdapter Cash_flow_Sda = new MySqlDataAdapter(Cash_flow_Cmd))
                        {
                            DataTable Cash_flow_Dt = new DataTable();
                            Cash_flow_Sda.Fill(Cash_flow_Dt);
                            if (Cash_flow_Dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < Cash_flow_Dt.Rows.Count; i++)
                                {
                                    string Y_Cheques_Date = Convert.ToString(Convert.ToDateTime(Cash_flow_Dt.Rows[i]["Datee"].ToString()).Year);
                                    string M_Cheques_Date = Convert.ToString(Convert.ToDateTime(Cash_flow_Dt.Rows[i]["Datee"].ToString()).Month);
                                    string O_ID = Cash_flow_Dt.Rows[i]["O_ID"].ToString();
                                    string B_ID = Cash_flow_Dt.Rows[i]["B_ID"].ToString();

                                    if (M_Cheques_Date == "1" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_1 = Sum_Expected_Y_O_M_1 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "2" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_2 = Sum_Expected_Y_O_M_2 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "3" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_3 = Sum_Expected_Y_O_M_3 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "4" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_4 = Sum_Expected_Y_O_M_4 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "5" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_5 = Sum_Expected_Y_O_M_5 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "6" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_6 = Sum_Expected_Y_O_M_6 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "7" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_7 = Sum_Expected_Y_O_M_7 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "8" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_8 = Sum_Expected_Y_O_M_8 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "9" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_9 = Sum_Expected_Y_O_M_9 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "10" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_10 = Sum_Expected_Y_O_M_10 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "11" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_11 = Sum_Expected_Y_O_M_11 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "12" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_M_12 = Sum_Expected_Y_O_M_12 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }


                                }
                            }
                        }
                    }
                    _sqlCon.Close();
                    string Quary2 = "select " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "'  and Mounth = '1')Sum_Income_Y_O_M_1,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "'  and Mounth = '2')Sum_Income_Y_O_M_2,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "'  and Mounth = '3')Sum_Income_Y_O_M_3,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '4')Sum_Income_Y_O_M_4,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "'  and Mounth = '5')Sum_Income_Y_O_M_5,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "'  and Mounth = '6')Sum_Income_Y_O_M_6,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "'  and Mounth = '7')Sum_Income_Y_O_M_7,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "'  and Mounth = '8')Sum_Income_Y_O_M_8, " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "'  and Mounth = '9')Sum_Income_Y_O_M_9,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "'  and Mounth = '10')Sum_Income_Y_O_M_10,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "'  and Mounth = '11')Sum_Income_Y_O_M_11,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '12')Sum_Income_Y_O_M_12, " +

                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '1')Sum_Management_Expenses_Y_O_M_1,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '2')Sum_Management_Expenses_Y_O_M_2,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '3')Sum_Management_Expenses_Y_O_M_3,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '4')Sum_Management_Expenses_Y_O_M_4,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '5')Sum_Management_Expenses_Y_O_M_5,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '6')Sum_Management_Expenses_Y_O_M_6,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '7')Sum_Management_Expenses_Y_O_M_7,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '8')Sum_Management_Expenses_Y_O_M_8, " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '9')Sum_Management_Expenses_Y_O_M_9,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '10')Sum_Management_Expenses_Y_O_M_10,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '11')Sum_Management_Expenses_Y_O_M_11,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "' and  Mounth = '12')Sum_Management_Expenses_Y_O_M_12 ," +

                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '1')Sum_RealEstate_Expenses_Y_O_M_1,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '2')Sum_RealEstate_Expenses_Y_O_M_2,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '3')Sum_RealEstate_Expenses_Y_O_M_3,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '4')Sum_RealEstate_Expenses_Y_O_M_4,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '5')Sum_RealEstate_Expenses_Y_O_M_5,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '6')Sum_RealEstate_Expenses_Y_O_M_6,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '7')Sum_RealEstate_Expenses_Y_O_M_7,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '8')Sum_RealEstate_Expenses_Y_O_M_8, " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '9')Sum_RealEstate_Expenses_Y_O_M_9,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '10')Sum_RealEstate_Expenses_Y_O_M_10,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '11')Sum_RealEstate_Expenses_Y_O_M_11,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '12')Sum_RealEstate_Expenses_Y_O_M_12, " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '1')Sum_Maintenance_Expenses_Y_O_M_1,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '2')Sum_Maintenance_Expenses_Y_O_M_2,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '3')Sum_Maintenance_Expenses_Y_O_M_3,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '4')Sum_Maintenance_Expenses_Y_O_M_4,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '5')Sum_Maintenance_Expenses_Y_O_M_5,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '6')Sum_Maintenance_Expenses_Y_O_M_6,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '7')Sum_Maintenance_Expenses_Y_O_M_7,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '8')Sum_Maintenance_Expenses_Y_O_M_8, " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '9')Sum_Maintenance_Expenses_Y_O_M_9,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '10')Sum_Maintenance_Expenses_Y_O_M_10,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '11')Sum_Maintenance_Expenses_Y_O_M_11,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Mounth = '12')Sum_Maintenance_Expenses_Y_O_M_12";
                    _sqlCon.Open();
                    MySqlDataAdapter Collection_Expenses_Sda = new MySqlDataAdapter(Quary2, _sqlCon);
                    DataTable getCollection_Expenses_Dt = new DataTable();
                    Collection_Expenses_Sda.Fill(getCollection_Expenses_Dt);
                    if (getCollection_Expenses_Dt.Rows.Count > 0)
                    {
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_1"].ToString() == "") { Sum_Income_Y_O_M_1 = "0"; } else { Sum_Income_Y_O_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_2"].ToString() == "") { Sum_Income_Y_O_M_2 = "0"; } else { Sum_Income_Y_O_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_3"].ToString() == "") { Sum_Income_Y_O_M_3 = "0"; } else { Sum_Income_Y_O_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_4"].ToString() == "") { Sum_Income_Y_O_M_4 = "0"; } else { Sum_Income_Y_O_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_5"].ToString() == "") { Sum_Income_Y_O_M_5 = "0"; } else { Sum_Income_Y_O_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_6"].ToString() == "") { Sum_Income_Y_O_M_6 = "0"; } else { Sum_Income_Y_O_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_7"].ToString() == "") { Sum_Income_Y_O_M_7 = "0"; } else { Sum_Income_Y_O_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_8"].ToString() == "") { Sum_Income_Y_O_M_8 = "0"; } else { Sum_Income_Y_O_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_9"].ToString() == "") { Sum_Income_Y_O_M_9 = "0"; } else { Sum_Income_Y_O_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_10"].ToString() == "") { Sum_Income_Y_O_M_10 = "0"; } else { Sum_Income_Y_O_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_11"].ToString() == "") { Sum_Income_Y_O_M_11 = "0"; } else { Sum_Income_Y_O_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_12"].ToString() == "") { Sum_Income_Y_O_M_12 = "0"; } else { Sum_Income_Y_O_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_M_12"].ToString(); }

                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_1"].ToString() == "") { Sum_Management_Expenses_Y_O_M_1 = "0"; } else { Sum_Management_Expenses_Y_O_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_2"].ToString() == "") { Sum_Management_Expenses_Y_O_M_2 = "0"; } else { Sum_Management_Expenses_Y_O_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_3"].ToString() == "") { Sum_Management_Expenses_Y_O_M_3 = "0"; } else { Sum_Management_Expenses_Y_O_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_4"].ToString() == "") { Sum_Management_Expenses_Y_O_M_4 = "0"; } else { Sum_Management_Expenses_Y_O_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_5"].ToString() == "") { Sum_Management_Expenses_Y_O_M_5 = "0"; } else { Sum_Management_Expenses_Y_O_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_6"].ToString() == "") { Sum_Management_Expenses_Y_O_M_6 = "0"; } else { Sum_Management_Expenses_Y_O_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_7"].ToString() == "") { Sum_Management_Expenses_Y_O_M_7 = "0"; } else { Sum_Management_Expenses_Y_O_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_8"].ToString() == "") { Sum_Management_Expenses_Y_O_M_8 = "0"; } else { Sum_Management_Expenses_Y_O_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_9"].ToString() == "") { Sum_Management_Expenses_Y_O_M_9 = "0"; } else { Sum_Management_Expenses_Y_O_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_10"].ToString() == "") { Sum_Management_Expenses_Y_O_M_10 = "0"; } else { Sum_Management_Expenses_Y_O_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_11"].ToString() == "") { Sum_Management_Expenses_Y_O_M_11 = "0"; } else { Sum_Management_Expenses_Y_O_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_12"].ToString() == "") { Sum_Management_Expenses_Y_O_M_12 = "0"; } else { Sum_Management_Expenses_Y_O_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_M_12"].ToString(); }

                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_1"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_1 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_2"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_2 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_3"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_3 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_4"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_4 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_5"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_5 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_6"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_6 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_7"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_7 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_8"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_8 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_9"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_9 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_10"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_10 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_11"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_11 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_12"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_M_12 = "0"; } else { Sum_RealEstate_Expenses_Y_O_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_M_12"].ToString(); }

                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_1"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_1 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_2"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_2 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_3"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_3 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_4"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_4 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_5"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_5 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_6"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_6 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_7"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_7 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_8"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_8 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_9"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_9 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_10"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_10 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_11"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_11 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_12"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_M_12 = "0"; } else { Sum_Maintenance_Expenses_Y_O_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_M_12"].ToString(); }

                    }


                    List<LineChartData> Data = new List<LineChartData>();
                    Data.Add(new LineChartData(01, Sum_Expected_Y_O_M_1, Convert.ToDouble(Sum_Income_Y_O_M_1), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_1) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_1) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_1)));
                    Data.Add(new LineChartData(02, Sum_Expected_Y_O_M_2, Convert.ToDouble(Sum_Income_Y_O_M_2), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_2) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_2) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_2)));
                    Data.Add(new LineChartData(03, Sum_Expected_Y_O_M_3, Convert.ToDouble(Sum_Income_Y_O_M_3), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_3) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_3) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_3)));
                    Data.Add(new LineChartData(04, Sum_Expected_Y_O_M_4, Convert.ToDouble(Sum_Income_Y_O_M_4), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_4) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_4) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_4)));
                    Data.Add(new LineChartData(05, Sum_Expected_Y_O_M_5, Convert.ToDouble(Sum_Income_Y_O_M_5), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_5) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_5) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_5)));
                    Data.Add(new LineChartData(06, Sum_Expected_Y_O_M_6, Convert.ToDouble(Sum_Income_Y_O_M_6), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_6) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_6) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_6)));
                    Data.Add(new LineChartData(07, Sum_Expected_Y_O_M_7, Convert.ToDouble(Sum_Income_Y_O_M_7), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_7) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_7) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_7)));
                    Data.Add(new LineChartData(08, Sum_Expected_Y_O_M_8, Convert.ToDouble(Sum_Income_Y_O_M_8), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_8) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_8) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_8)));
                    Data.Add(new LineChartData(09, Sum_Expected_Y_O_M_9, Convert.ToDouble(Sum_Income_Y_O_M_9), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_9) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_9) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_9)));
                    Data.Add(new LineChartData(10, Sum_Expected_Y_O_M_10, Convert.ToDouble(Sum_Income_Y_O_M_10), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_10) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_10) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_10)));
                    Data.Add(new LineChartData(11, Sum_Expected_Y_O_M_11, Convert.ToDouble(Sum_Income_Y_O_M_11), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_11) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_11) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_11)));
                    Data.Add(new LineChartData(12, Sum_Expected_Y_O_M_12, Convert.ToDouble(Sum_Income_Y_O_M_12), Convert.ToDouble(Sum_Management_Expenses_Y_O_M_12) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_M_12) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_M_12)));


                    //Binding Datasource to Chart
                    this.Chart1.DataSource = Data;
                    this.Chart1.DataBind();
                    _sqlCon.Close();
                    //****************************************************
                    //**********************************************************************************************************

                    string Quary_virtual_Value = "select U.* ,O.Owner_Ship_Id FROM units U   " +
                        "left join building B on(U.building_Building_Id = B.building_Id) " +
                        "left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) Where Half != 1 ";
                    _sqlCon.Open();
                    MySqlDataAdapter virtual_Value_Sda = new MySqlDataAdapter(Quary_virtual_Value, _sqlCon);
                    DataTable virtual_Value_Dt = new DataTable();
                    virtual_Value_Sda.Fill(virtual_Value_Dt);
                    if (virtual_Value_Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < virtual_Value_Dt.Rows.Count; i++)
                        {
                            string Owner_Ship_Id = virtual_Value_Dt.Rows[i]["Owner_Ship_Id"].ToString();
                            if (Owner_Ship_Id == Ownership_Name_DropDownList.SelectedValue)
                            {
                                if (virtual_Value_Dt.Rows[i]["virtual_Value"].ToString() == "") { Sum_virtual_Value = Sum_virtual_Value + 0; } else { Sum_virtual_Value = Sum_virtual_Value + Convert.ToDouble(virtual_Value_Dt.Rows[i]["virtual_Value"].ToString()); }
                            }
                        }
                    }
                    Syncfusion.JavaScript.DataVisualization.Models.Series series_Rental_Value = Rental_Value.Series[0];
                    List<ColumnChartData> data_Rental_Value = new List<ColumnChartData>();
                    double Total_Income = 0;
                    double Total_Expected = 0;
                    if (Mounth_DropDownList.SelectedValue == "1") { Total_Expected = Sum_Expected_Y_O_M_1; Total_Income = Convert.ToDouble(Sum_Income_Y_O_M_1); }
                    else if (Mounth_DropDownList.SelectedValue == "2") { Total_Expected = Sum_Expected_Y_O_M_2; Total_Income = Convert.ToDouble(Sum_Income_Y_O_M_2); }
                    else if (Mounth_DropDownList.SelectedValue == "3") { Total_Expected = Sum_Expected_Y_O_M_3; Total_Income = Convert.ToDouble(Sum_Income_Y_O_M_3); }
                    else if (Mounth_DropDownList.SelectedValue == "4") { Total_Expected = Sum_Expected_Y_O_M_4; Total_Income = Convert.ToDouble(Sum_Income_Y_O_M_4); }
                    else if (Mounth_DropDownList.SelectedValue == "5") { Total_Expected = Sum_Expected_Y_O_M_5; Total_Income = Convert.ToDouble(Sum_Income_Y_O_M_5); }
                    else if (Mounth_DropDownList.SelectedValue == "6") { Total_Expected = Sum_Expected_Y_O_M_6; Total_Income = Convert.ToDouble(Sum_Income_Y_O_M_6); }
                    else if (Mounth_DropDownList.SelectedValue == "7") { Total_Expected = Sum_Expected_Y_O_M_7; Total_Income = Convert.ToDouble(Sum_Income_Y_O_M_7); }
                    else if (Mounth_DropDownList.SelectedValue == "8") { Total_Expected = Sum_Expected_Y_O_M_8; Total_Income = Convert.ToDouble(Sum_Income_Y_O_M_8); }
                    else if (Mounth_DropDownList.SelectedValue == "9") { Total_Expected = Sum_Expected_Y_O_M_9; Total_Income = Convert.ToDouble(Sum_Income_Y_O_M_9); }
                    else if (Mounth_DropDownList.SelectedValue == "10") { Total_Expected = Sum_Expected_Y_O_M_10; Total_Income = Convert.ToDouble(Sum_Income_Y_O_M_10); }
                    else if (Mounth_DropDownList.SelectedValue == "11") { Total_Expected = Sum_Expected_Y_O_M_11; Total_Income = Convert.ToDouble(Sum_Income_Y_O_M_11); }
                    else if (Mounth_DropDownList.SelectedValue == "12") { Total_Expected = Sum_Expected_Y_O_M_12; Total_Income = Convert.ToDouble(Sum_Income_Y_O_M_12); }

                    data_Rental_Value.Add(new ColumnChartData(Ownership_Name_DropDownList.SelectedItem.Text + " القيمة الإيجارية للملكية ", Sum_virtual_Value, Total_Expected, Total_Income));
                    this.Rental_Value.DataSource = data_Rental_Value;
                    this.Rental_Value.DataBind();
                    _sqlCon.Close();
                    //****************************************************  القيمة القارية **********************************************************************************************************
                    string Sum_Collection = "0";
                    string Rental_Value_Quary = "Select(Select Sum(Building_Value) From building Where owner_ship_Owner_Ship_Id='" + OwnerShip + "')Sum_Bulidng_Value," +
                                                "(Select Sum(Land_Value) From owner_ship Where Owner_Ship_Id='" + OwnerShip + "')Sum_Land_Value," +
                                                "(Select Sum(Collection) From collection_table where Year='" + Year + "' And Ownersip_Id ='" + OwnerShip + "')Sum_Collection";
                    _sqlCon.Open();
                    MySqlDataAdapter Value_Quary_Sda = new MySqlDataAdapter(Rental_Value_Quary, _sqlCon);
                    DataTable get_Value_Quary_Dt = new DataTable();
                    Value_Quary_Sda.Fill(get_Value_Quary_Dt);
                    if (get_Value_Quary_Dt.Rows.Count > 0)
                    {
                        if (get_Value_Quary_Dt.Rows[0]["Sum_Bulidng_Value"].ToString() == "") { Sum_Bulidng_Value = "0"; } else { Sum_Bulidng_Value = get_Value_Quary_Dt.Rows[0]["Sum_Bulidng_Value"].ToString(); }
                        if (get_Value_Quary_Dt.Rows[0]["Sum_Land_Value"].ToString() == "") { Sum_Land_Value = "0"; } else { Sum_Land_Value = get_Value_Quary_Dt.Rows[0]["Sum_Land_Value"].ToString(); }
                        if (get_Value_Quary_Dt.Rows[0]["Sum_Collection"].ToString() == "") { Sum_Collection = "0"; } else { Sum_Collection = get_Value_Quary_Dt.Rows[0]["Sum_Collection"].ToString(); }
                    }
                    Lbl_RealEstae.Text = "العائد على القيمة العقارية";
                    Syncfusion.JavaScript.DataVisualization.Models.Series series4 = RealEstae_Chart.Series[0];
                    series4.Points.Clear();
                    series4.Points.Add(new Points("الدخل السنوي", Convert.ToDouble(Sum_Collection)));
                    series4.Points.Add(new Points("قيمة العقار", Convert.ToDouble(Sum_Bulidng_Value) + Convert.ToDouble(Sum_Land_Value)));
                    _sqlCon.Close();

                    lbl_RealEstate_Value.Text = (Convert.ToDouble(Sum_Bulidng_Value) + Convert.ToDouble(Sum_Land_Value)).ToString("###,###,###");
                    Yearly_Income.Text = (Convert.ToDouble(Sum_Collection)).ToString("###,###,###");
                    lbl_RealEstate_Value_percentage.Text = (((Convert.ToDouble(Sum_Collection)) / (Convert.ToDouble(Sum_Bulidng_Value) + Convert.ToDouble(Sum_Land_Value))) * 100).ToString("0.00 ") + "%";
                    //*************************** الإستدامة و  النمو **********************************************************************************************************************************

                    Real_Estate_Sustainability();

                    //*************************** الإهلاك **********************************************************************************************************************************
                    div_1.Visible = false; div_2.Visible = true;
                    Label22.Text = "الهالك السنوي لكل الأبنية في الملكية  :" + Ownership_Name_DropDownList.SelectedItem.Text;
                    Label23.Text = (Convert.ToDouble(Sum_Bulidng_Value) / Convert.ToDouble(txt_Destruction_Value.Text)).ToString("###,###,###");

                    Label24.Text = " االمتبقي من قيمة كل الأبنية في الملكية  :" + Ownership_Name_DropDownList.SelectedItem.Text;
                    Label25.Text = (Convert.ToDouble(Sum_Bulidng_Value) - Convert.ToDouble(Label23.Text)).ToString("###,###,###");

                    Syncfusion.JavaScript.DataVisualization.Models.Series series5 = destruction_Char.Series[0];
                    series5.Points.Clear();
                }

                // 2-3
                else if (Ownership_Name_DropDownList.SelectedItem.Text != "كل الملكيات" && Building_Name_DropDownList.SelectedItem.Text != "كل الأبنية")
                {
                    // **************************** النسب المئوية للجنسيات ********************************************************
                    percent_nationality_GridView();
                    Tenant_Evaluation();
                    //****************************** الرهن العقاري *****************************************************************
                    Mortgage_All();
                    //***************************************** حالات الوحدات *******************************************************




                    string Available = "0"; string Rented = "0"; string Undermaintenance = "0"; string UnderProplem = "0";
                    string Building_Id_Quairy = "select Building_Id from building where owner_ship_Owner_Ship_Id ='" + Ownership_Name_DropDownList.SelectedValue + "'";
                    _sqlCon.Open();
                    DataTable get_Building_Id_Dt = new DataTable();
                    MySqlCommand get_Building_Id_Cmd = new MySqlCommand(Building_Id_Quairy, _sqlCon);
                    MySqlDataAdapter get_Building_Id_Da = new MySqlDataAdapter(get_Building_Id_Cmd);
                    get_Building_Id_Da.Fill(get_Building_Id_Dt);
                    if (get_Building_Id_Dt.Rows.Count > 0)
                    {
                        string Building_Id = Building_Name_DropDownList.SelectedValue;

                        string Quairy = "select " +
                            "( Select count(*) from units where Half != 1 and building_Building_Id = '" + Building_Id + "' and unit_condition_Unit_Condition_Id='1')Available , " +
                            "(Select count(*) from units where Half != 1 and building_Building_Id = '" + Building_Id + "' and unit_condition_Unit_Condition_Id = '2')Rented , " +
                            "(Select count(*) from units where Half != 1 and building_Building_Id = '" + Building_Id + "' and unit_condition_Unit_Condition_Id = '3')Under_Maintenance ," +
                            "(Select count(*) from units where Half != 1 and building_Building_Id = '" + Building_Id + "' and unit_condition_Unit_Condition_Id = '4')Under_Proplem ";

                        DataTable getUnitStatusChartDt = new DataTable();
                        MySqlCommand getUnitStatusChartCmd = new MySqlCommand(Quairy, _sqlCon);
                        MySqlDataAdapter getUnitStatusChartDa = new MySqlDataAdapter(getUnitStatusChartCmd);
                        getUnitStatusChartDa.Fill(getUnitStatusChartDt);
                        if (getUnitStatusChartDt.Rows.Count > 0)
                        {
                            Available = getUnitStatusChartDt.Rows[0]["Available"].ToString();
                            Rented = getUnitStatusChartDt.Rows[0]["Rented"].ToString();
                            Undermaintenance = getUnitStatusChartDt.Rows[0]["Under_Maintenance"].ToString();
                            UnderProplem = getUnitStatusChartDt.Rows[0]["Under_Proplem"].ToString();

                        }
                        //-----------------------------------------------------------------------------------------------------------------------
                        double U_C = 0; double B_C = 0;
                        string Q = "SELECT  C.End_Date , C.units_Unit_ID ,  " +
                                    "B.Building_Id , O.Owner_Ship_Id FROM contract C " +
                                    "left join units U on (C.units_Unit_ID = U.Unit_Id) " +
                                    "left join building B on (U.building_Building_Id = B.building_Id) " +
                                    "left join owner_ship O on (B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                                    "where C.New_ReNewed_Expaired ='1' and B.Building_Id = '" + Building_Name_DropDownList.SelectedValue + "';";
                        DataTable Dt = new DataTable();
                        MySqlCommand Cmd = new MySqlCommand(Q, _sqlCon);
                        MySqlDataAdapter Da = new MySqlDataAdapter(Cmd);
                        Da.Fill(Dt);
                        for (int C = 0; C < Dt.Rows.Count; C++)
                        {
                            string EndDate = Dt.Rows[C]["End_Date"].ToString();
                            DateTime End_Date = Convert.ToDateTime(EndDate);
                            var today = DateTime.Now;
                            var diffOfDates = (End_Date - today).Days;
                            if (diffOfDates >= 0 && diffOfDates <= 60) { U_C++; }
                        }



                        string Q2 = "SELECT End_Date from building_contract where New_ReNewed_Expaired ='1' and  building_Building_Id = '" + Building_Name_DropDownList.SelectedValue + "'";
                        DataTable Dt2 = new DataTable();
                        MySqlCommand Cmd2 = new MySqlCommand(Q2, _sqlCon);
                        MySqlDataAdapter Da2 = new MySqlDataAdapter(Cmd2);
                        Da2.Fill(Dt2);
                        for (int C = 0; C < Dt2.Rows.Count; C++)
                        {
                            string EndDate = Dt2.Rows[C]["End_Date"].ToString();
                            DateTime End_Date = Convert.ToDateTime(EndDate);
                            var today = DateTime.Now;
                            var diffOfDates = (End_Date - today).Days;
                            if (diffOfDates >= 0 && diffOfDates <= 60) { B_C++; }
                        }
                        //-----------------------------------------------------------------------------------------------------------------------
                        Syncfusion.JavaScript.DataVisualization.Models.Series series = Units_Statuse.Series[0];
                        series.Points.Clear();
                        series.Points.Add(new Points("شاغر", double.Parse(Available)));
                        series.Points.Add(new Points("مؤجر", double.Parse(Rented)));
                        series.Points.Add(new Points("تحت الانشاء أو الصيانة", double.Parse(Undermaintenance)));
                        series.Points.Add(new Points("موجر نزاع", double.Parse(UnderProplem)));
                        series.Points.Add(new Points("", 0));
                        series.Points.Add(new Points("قيد الإنتهاء", (U_C + B_C)));
                    }





                    // ********************************  المصاريف الغدارية و العقارية و الصيانة************************************
                    Syncfusion.JavaScript.DataVisualization.Models.Series series1 = Expenses_Chart.Series[0];
                    List<ColumnChartData> data = new List<ColumnChartData>();
                    data.Add(new ColumnChartData(Building_Name_DropDownList.SelectedItem.Text, Convert.ToDouble(Management_Expenses_D_Y_M_O_B), Convert.ToDouble(RealEstate_Expenses_D_Y_M_O_B), Convert.ToDouble(Maintenance_Expenses_D_Y_M_O_B)));
                    this.Expenses_Chart.DataSource = data;
                    this.Expenses_Chart.DataBind();

                    // ********************************    العائد الفعلي **********************************
                    double total_Expensess = Convert.ToDouble(Convert.ToDouble(Management_Expenses_D_Y_M_O_B) + Convert.ToDouble(RealEstate_Expenses_D_Y_M_O_B) + Convert.ToDouble(Maintenance_Expenses_D_Y_M_O_B));
                    lbl_Real_Income.Text = "العائد الفعلي";

                    double Real_Income = Convert.ToDouble(Management_Expenses_D_Y_M_O_B) - total_Expensess;
                    Syncfusion.JavaScript.DataVisualization.Models.Series Real_Income_series = Real_Income_Chart_2.Series[0];
                    List<ColumnChartData> Real_Income_data = new List<ColumnChartData>();
                    Real_Income_data.Add(new ColumnChartData("العائد الفعلي", Convert.ToDouble(Management_Expenses_D_Y_M_O_B), Real_Income, total_Expensess));
                    this.Real_Income_Chart_2.DataSource = Real_Income_data;
                    this.Real_Income_Chart_2.DataBind();
                    _sqlCon.Close();
                    //************************************* الربح الصافي **********************************************************
                    string Sum_Building_Value_Quary = "Select Sum(Building_Value) Sum_Building_Value From building where Building_Id ='" + Building + "'";
                    string Sum_Building_Value = "0";
                    _sqlCon.Open();
                    MySqlDataAdapter VSum_Building_Value_Sda = new MySqlDataAdapter(Sum_Building_Value_Quary, _sqlCon);
                    DataTable VSum_Building_Value_Dt = new DataTable();
                    VSum_Building_Value_Sda.Fill(VSum_Building_Value_Dt);
                    if (VSum_Building_Value_Dt.Rows.Count > 0)
                    {
                        if (VSum_Building_Value_Dt.Rows[0]["Sum_Building_Value"].ToString() == "") { Sum_Building_Value = "0"; } else { Sum_Building_Value = VSum_Building_Value_Dt.Rows[0]["Sum_Building_Value"].ToString(); }
                    }

                    Label1.Text = Convert.ToString(Convert.ToDouble(Sum_Building_Value) / Convert.ToDouble(txt_Destruction_Value.Text));

                    Label2.Text = Convert.ToString((Convert.ToDouble(Collection_D_Y_O_B) - total_Expensess));

                    Label3.Text = Convert.ToString((Convert.ToDouble(Sum_Building_Value) / Convert.ToDouble(txt_Destruction_Value.Text)) - ((Convert.ToDouble(Collection_D_Y_O_B) - total_Expensess)));


                    Syncfusion.JavaScript.DataVisualization.Models.Series series_Chart2 = Chart2.Series[0];
                    List<ColumnChartData> data_Chart2 = new List<ColumnChartData>();
                    data_Chart2.Add(new ColumnChartData("", Convert.ToDouble(Label1.Text), Convert.ToDouble(Label3.Text), (Convert.ToDouble(Label2.Text))));

                    this.Chart2.DataSource = data_Chart2;
                    this.Chart2.DataBind();
                    _sqlCon.Close();
                    //********************************* متبقي التوزيع  ************************************
                    string Sum_Remainder_Distribution_Quary = "select(select owner_Owner_Id from owner_ship where Owner_Ship_Id='" + OwnerShip + "')OwnerID,(select Salary from owner where Owner_Id = OwnerID)Sum_Salary";
                    string Sum_Remainder_Distribution = "0";
                    _sqlCon.Open();
                    MySqlDataAdapter Sum_Remainder_Distribution_Sda = new MySqlDataAdapter(Sum_Remainder_Distribution_Quary, _sqlCon);
                    DataTable Sum_Remainder_Distribution_Dt = new DataTable();
                    Sum_Remainder_Distribution_Sda.Fill(Sum_Remainder_Distribution_Dt);
                    if (Sum_Remainder_Distribution_Dt.Rows.Count > 0)
                    {
                        if (Sum_Remainder_Distribution_Dt.Rows[0]["Sum_Salary"].ToString() == "") { Sum_Remainder_Distribution = "0"; } else { Sum_Remainder_Distribution = Sum_Remainder_Distribution_Dt.Rows[0]["Sum_Salary"].ToString(); }
                    }
                    //الرواتب
                    Label4.Text = Convert.ToString(Convert.ToDouble(Sum_Remainder_Distribution));

                    // الربح الصافي
                    Label5.Text = Label3.Text;

                    double X = Convert.ToDouble(Label5.Text) - Convert.ToDouble(Label4.Text);
                    Label6.Text = Convert.ToString(X);
                    Syncfusion.JavaScript.DataVisualization.Models.Series series_Chart3 = Chart3.Series[0];
                    List<ColumnChartData> data_Chart3 = new List<ColumnChartData>();
                    data_Chart3.Add(new ColumnChartData("", Convert.ToDouble(Label4.Text), Convert.ToDouble(Label5.Text), (Convert.ToDouble(Label6.Text))));
                    this.Chart3.DataSource = data_Chart3;
                    this.Chart3.DataBind();
                    _sqlCon.Close();
                    // ********************************    التدفق النقدي ********************************** 
                    lbl_Cash_Flow.Text = "التدفق النقدي لكافة الملكيات لعام " + Year_DropDownList.SelectedItem.Text + " والبناء    " + Building_Name_DropDownList.SelectedItem.Text;
                    _sqlCon.Open();
                    using (MySqlCommand Cash_flow_Cmd = new MySqlCommand("Dashboard_Test", _sqlCon))
                    {
                        Cash_flow_Cmd.CommandType = CommandType.StoredProcedure;
                        using (MySqlDataAdapter Cash_flow_Sda = new MySqlDataAdapter(Cash_flow_Cmd))
                        {
                            DataTable Cash_flow_Dt = new DataTable();
                            Cash_flow_Sda.Fill(Cash_flow_Dt);
                            if (Cash_flow_Dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < Cash_flow_Dt.Rows.Count; i++)
                                {
                                    string Y_Cheques_Date = Convert.ToString(Convert.ToDateTime(Cash_flow_Dt.Rows[i]["Datee"].ToString()).Year);
                                    string M_Cheques_Date = Convert.ToString(Convert.ToDateTime(Cash_flow_Dt.Rows[i]["Datee"].ToString()).Month);
                                    string O_ID = Cash_flow_Dt.Rows[i]["O_ID"].ToString();
                                    string B_ID = Cash_flow_Dt.Rows[i]["B_ID"].ToString();

                                    if (M_Cheques_Date == "1" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_1 = Sum_Expected_Y_O_B_M_1 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "2" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_2 = Sum_Expected_Y_O_B_M_2 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "3" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_3 = Sum_Expected_Y_O_B_M_3 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "4" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_4 = Sum_Expected_Y_O_B_M_4 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "5" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_5 = Sum_Expected_Y_O_B_M_5 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "6" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_6 = Sum_Expected_Y_O_B_M_6 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "7" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_7 = Sum_Expected_Y_O_B_M_7 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "8" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_8 = Sum_Expected_Y_O_B_M_8 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "9" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_9 = Sum_Expected_Y_O_B_M_9 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "10" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_10 = Sum_Expected_Y_O_B_M_10 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "11" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_11 = Sum_Expected_Y_O_B_M_11 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }

                                    else if (M_Cheques_Date == "12" && Y_Cheques_Date == Year_DropDownList.SelectedItem.Text && O_ID == Ownership_Name_DropDownList.SelectedValue && B_ID == Building_Name_DropDownList.SelectedValue)
                                    { Sum_Expected_Y_O_B_M_12 = Sum_Expected_Y_O_B_M_12 + Convert.ToDouble(Cash_flow_Dt.Rows[i]["Amount"].ToString()); }
                                }
                            }
                        }
                    }
                    _sqlCon.Close();
                    string Quary3 = "select " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "'  and Mounth = '1')Sum_Income_Y_O_B_M_1,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "'  and Mounth = '2')Sum_Income_Y_O_B_M_2,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "'  and Mounth = '3')Sum_Income_Y_O_B_M_3,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '4')Sum_Income_Y_O_B_M_4,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "'  and Mounth = '5')Sum_Income_Y_O_B_M_5,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "'  and Mounth = '6')Sum_Income_Y_O_B_M_6,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "'  and Mounth = '7')Sum_Income_Y_O_B_M_7,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "'  and Mounth = '8')Sum_Income_Y_O_B_M_8, " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "'  and Mounth = '9')Sum_Income_Y_O_B_M_9,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "'  and Mounth = '10')Sum_Income_Y_O_B_M_10,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "'  and Mounth = '11')Sum_Income_Y_O_B_M_11,  " +
                                    "(select Sum(Collection) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '12')Sum_Income_Y_O_B_M_12, " +

                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '1')Sum_Management_Expenses_Y_O_B_M_1,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '2')Sum_Management_Expenses_Y_O_B_M_2,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '3')Sum_Management_Expenses_Y_O_B_M_3,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '4')Sum_Management_Expenses_Y_O_B_M_4,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '5')Sum_Management_Expenses_Y_O_B_M_5,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '6')Sum_Management_Expenses_Y_O_B_M_6,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '7')Sum_Management_Expenses_Y_O_B_M_7,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '8')Sum_Management_Expenses_Y_O_B_M_8, " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '9')Sum_Management_Expenses_Y_O_B_M_9,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '10')Sum_Management_Expenses_Y_O_B_M_10,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '11')Sum_Management_Expenses_Y_O_B_M_11,  " +
                                    "(select Sum(Management_Expensess) from management_expensess Where Year = '" + Year + "'  and Mounth = '12')Sum_Management_Expenses_Y_O_B_M_12 ," +

                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '1')Sum_RealEstate_Expenses_Y_O_B_M_1,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '2')Sum_RealEstate_Expenses_Y_O_B_M_2,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '3')Sum_RealEstate_Expenses_Y_O_B_M_3,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '4')Sum_RealEstate_Expenses_Y_O_B_M_4,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '5')Sum_RealEstate_Expenses_Y_O_B_M_5,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '6')Sum_RealEstate_Expenses_Y_O_B_M_6,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '7')Sum_RealEstate_Expenses_Y_O_B_M_7,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '8')Sum_RealEstate_Expenses_Y_O_B_M_8, " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '9')Sum_RealEstate_Expenses_Y_O_B_M_9,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '10')Sum_RealEstate_Expenses_Y_O_B_M_10,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '11')Sum_RealEstate_Expenses_Y_O_B_M_11,  " +
                                    "(select Sum(RealEstate_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '12')Sum_RealEstate_Expenses_Y_O_B_M_12, " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '1')Sum_Maintenance_Expenses_Y_O_B_M_1,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '2')Sum_Maintenance_Expenses_Y_O_B_M_2,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '3')Sum_Maintenance_Expenses_Y_O_B_M_3,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '4')Sum_Maintenance_Expenses_Y_O_B_M_4,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '5')Sum_Maintenance_Expenses_Y_O_B_M_5,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '6')Sum_Maintenance_Expenses_Y_O_B_M_6,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '7')Sum_Maintenance_Expenses_Y_O_B_M_7,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '8')Sum_Maintenance_Expenses_Y_O_B_M_8, " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '9')Sum_Maintenance_Expenses_Y_O_B_M_9,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '10')Sum_Maintenance_Expenses_Y_O_B_M_10,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '11')Sum_Maintenance_Expenses_Y_O_B_M_11,  " +
                                    "(select Sum(Maintenance_Expenses) from collection_table Where Year = '" + Year + "' and Ownersip_Id = '" + OwnerShip + "' and Building_Id =  '" + Building + "' and Mounth = '12')Sum_Maintenance_Expenses_Y_O_B_M_12";
                    _sqlCon.Open();
                    MySqlDataAdapter Collection_Expenses_Sda = new MySqlDataAdapter(Quary3, _sqlCon);
                    DataTable getCollection_Expenses_Dt = new DataTable();
                    Collection_Expenses_Sda.Fill(getCollection_Expenses_Dt);
                    if (getCollection_Expenses_Dt.Rows.Count > 0)
                    {
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_1"].ToString() == "") { Sum_Income_Y_O_B_M_1 = "0"; } else { Sum_Income_Y_O_B_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_2"].ToString() == "") { Sum_Income_Y_O_B_M_2 = "0"; } else { Sum_Income_Y_O_B_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_3"].ToString() == "") { Sum_Income_Y_O_B_M_3 = "0"; } else { Sum_Income_Y_O_B_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_4"].ToString() == "") { Sum_Income_Y_O_B_M_4 = "0"; } else { Sum_Income_Y_O_B_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_5"].ToString() == "") { Sum_Income_Y_O_B_M_5 = "0"; } else { Sum_Income_Y_O_B_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_6"].ToString() == "") { Sum_Income_Y_O_B_M_6 = "0"; } else { Sum_Income_Y_O_B_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_7"].ToString() == "") { Sum_Income_Y_O_B_M_7 = "0"; } else { Sum_Income_Y_O_B_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_8"].ToString() == "") { Sum_Income_Y_O_B_M_8 = "0"; } else { Sum_Income_Y_O_B_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_9"].ToString() == "") { Sum_Income_Y_O_B_M_9 = "0"; } else { Sum_Income_Y_O_B_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_10"].ToString() == "") { Sum_Income_Y_O_B_M_10 = "0"; } else { Sum_Income_Y_O_B_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_11"].ToString() == "") { Sum_Income_Y_O_B_M_11 = "0"; } else { Sum_Income_Y_O_B_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_12"].ToString() == "") { Sum_Income_Y_O_B_M_12 = "0"; } else { Sum_Income_Y_O_B_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_Income_Y_O_B_M_12"].ToString(); }

                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_1"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_1 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_2"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_2 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_3"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_3 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_4"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_4 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_5"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_5 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_6"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_6 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_7"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_7 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_8"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_8 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_9"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_9 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_10"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_10 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_11"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_11 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_12"].ToString() == "") { Sum_Management_Expenses_Y_O_B_M_12 = "0"; } else { Sum_Management_Expenses_Y_O_B_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_Management_Expenses_Y_O_B_M_12"].ToString(); }

                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_1"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_1 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_2"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_2 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_3"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_3 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_4"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_4 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_5"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_5 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_6"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_6 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_7"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_7 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_8"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_8 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_9"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_9 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_10"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_10 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_11"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_11 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_12"].ToString() == "") { Sum_RealEstate_Expenses_Y_O_B_M_12 = "0"; } else { Sum_RealEstate_Expenses_Y_O_B_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_RealEstate_Expenses_Y_O_B_M_12"].ToString(); }

                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_1"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_1 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_1 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_1"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_2"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_2 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_2 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_2"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_3"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_3 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_3 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_3"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_4"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_4 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_4 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_4"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_5"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_5 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_5 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_5"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_6"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_6 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_6 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_6"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_7"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_7 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_7 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_7"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_8"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_8 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_8 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_8"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_9"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_9 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_9 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_9"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_10"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_10 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_10 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_10"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_11"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_11 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_11 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_11"].ToString(); }
                        if (getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_12"].ToString() == "") { Sum_Maintenance_Expenses_Y_O_B_M_12 = "0"; } else { Sum_Maintenance_Expenses_Y_O_B_M_12 = getCollection_Expenses_Dt.Rows[0]["Sum_Maintenance_Expenses_Y_O_B_M_12"].ToString(); }

                    }
                    List<LineChartData> Data = new List<LineChartData>();
                    Data.Add(new LineChartData(01, Sum_Expected_Y_O_B_M_1, Convert.ToDouble(Sum_Income_Y_O_B_M_1), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_1) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_1) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_1)));
                    Data.Add(new LineChartData(02, Sum_Expected_Y_O_B_M_2, Convert.ToDouble(Sum_Income_Y_O_B_M_2), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_2) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_2) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_2)));
                    Data.Add(new LineChartData(03, Sum_Expected_Y_O_B_M_3, Convert.ToDouble(Sum_Income_Y_O_B_M_3), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_3) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_3) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_3)));
                    Data.Add(new LineChartData(04, Sum_Expected_Y_O_B_M_4, Convert.ToDouble(Sum_Income_Y_O_B_M_4), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_4) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_4) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_4)));
                    Data.Add(new LineChartData(05, Sum_Expected_Y_O_B_M_5, Convert.ToDouble(Sum_Income_Y_O_B_M_5), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_5) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_5) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_5)));
                    Data.Add(new LineChartData(06, Sum_Expected_Y_O_B_M_6, Convert.ToDouble(Sum_Income_Y_O_B_M_6), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_6) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_6) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_6)));
                    Data.Add(new LineChartData(07, Sum_Expected_Y_O_B_M_7, Convert.ToDouble(Sum_Income_Y_O_B_M_7), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_7) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_7) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_7)));
                    Data.Add(new LineChartData(08, Sum_Expected_Y_O_B_M_8, Convert.ToDouble(Sum_Income_Y_O_B_M_8), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_8) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_8) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_8)));
                    Data.Add(new LineChartData(09, Sum_Expected_Y_O_B_M_9, Convert.ToDouble(Sum_Income_Y_O_B_M_9), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_9) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_9) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_9)));
                    Data.Add(new LineChartData(10, Sum_Expected_Y_O_B_M_10, Convert.ToDouble(Sum_Income_Y_O_B_M_10), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_10) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_10) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_10)));
                    Data.Add(new LineChartData(11, Sum_Expected_Y_O_B_M_11, Convert.ToDouble(Sum_Income_Y_O_B_M_11), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_11) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_11) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_11)));
                    Data.Add(new LineChartData(12, Sum_Expected_Y_O_B_M_12, Convert.ToDouble(Sum_Income_Y_O_B_M_12), Convert.ToDouble(Sum_Management_Expenses_Y_O_B_M_12) + Convert.ToDouble(Sum_RealEstate_Expenses_Y_O_B_M_12) + Convert.ToDouble(Sum_Maintenance_Expenses_Y_O_B_M_12)));

                    //Binding Datasource to Chart
                    this.Chart1.DataSource = Data;
                    this.Chart1.DataBind();
                    _sqlCon.Close();
                    //********************************************* القيمة الإيجارية ******************************************************************************************
                    string Quary_virtual_Value = "select U.* ,O.Owner_Ship_Id FROM units U  " +
                        "left join building B on(U.building_Building_Id = B.building_Id) " +
                        "left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) Where Half != 1";
                    _sqlCon.Open();
                    MySqlDataAdapter virtual_Value_Sda = new MySqlDataAdapter(Quary_virtual_Value, _sqlCon);
                    DataTable virtual_Value_Dt = new DataTable();
                    virtual_Value_Sda.Fill(virtual_Value_Dt);
                    if (virtual_Value_Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < virtual_Value_Dt.Rows.Count; i++)
                        {
                            string Owner_Ship_Id = virtual_Value_Dt.Rows[i]["Owner_Ship_Id"].ToString();
                            string Building_Id = virtual_Value_Dt.Rows[i]["building_Building_Id"].ToString();
                            if (Owner_Ship_Id == Ownership_Name_DropDownList.SelectedValue && Building_Id == Building_Name_DropDownList.SelectedValue)
                            {
                                if (virtual_Value_Dt.Rows[i]["virtual_Value"].ToString() == "") { Sum_virtual_Value = Sum_virtual_Value + 0; } else { Sum_virtual_Value = Sum_virtual_Value + Convert.ToDouble(virtual_Value_Dt.Rows[i]["virtual_Value"].ToString()); }
                            }
                        }
                    }
                    Syncfusion.JavaScript.DataVisualization.Models.Series series_Rental_Value = Rental_Value.Series[0];
                    List<ColumnChartData> data_Rental_Value = new List<ColumnChartData>();
                    double Total_Income = 0;
                    double Total_Expected = 0;
                    if (Mounth_DropDownList.SelectedValue == "1") { Total_Expected = Sum_Expected_Y_O_B_M_1; Total_Income = Convert.ToDouble(Sum_Income_Y_O_B_M_1); }
                    else if (Mounth_DropDownList.SelectedValue == "2") { Total_Expected = Sum_Expected_Y_O_B_M_2; Total_Income = Convert.ToDouble(Sum_Income_Y_O_B_M_2); }
                    else if (Mounth_DropDownList.SelectedValue == "3") { Total_Expected = Sum_Expected_Y_O_B_M_3; Total_Income = Convert.ToDouble(Sum_Income_Y_O_B_M_3); }
                    else if (Mounth_DropDownList.SelectedValue == "4") { Total_Expected = Sum_Expected_Y_O_B_M_4; Total_Income = Convert.ToDouble(Sum_Income_Y_O_B_M_4); }
                    else if (Mounth_DropDownList.SelectedValue == "5") { Total_Expected = Sum_Expected_Y_O_B_M_5; Total_Income = Convert.ToDouble(Sum_Income_Y_O_B_M_5); }
                    else if (Mounth_DropDownList.SelectedValue == "6") { Total_Expected = Sum_Expected_Y_O_B_M_6; Total_Income = Convert.ToDouble(Sum_Income_Y_O_B_M_6); }
                    else if (Mounth_DropDownList.SelectedValue == "7") { Total_Expected = Sum_Expected_Y_O_B_M_7; Total_Income = Convert.ToDouble(Sum_Income_Y_O_B_M_7); }
                    else if (Mounth_DropDownList.SelectedValue == "8") { Total_Expected = Sum_Expected_Y_O_B_M_8; Total_Income = Convert.ToDouble(Sum_Income_Y_O_B_M_8); }
                    else if (Mounth_DropDownList.SelectedValue == "9") { Total_Expected = Sum_Expected_Y_O_B_M_9; Total_Income = Convert.ToDouble(Sum_Income_Y_O_B_M_9); }
                    else if (Mounth_DropDownList.SelectedValue == "10") { Total_Expected = Sum_Expected_Y_O_B_M_10; Total_Income = Convert.ToDouble(Sum_Income_Y_O_B_M_10); }
                    else if (Mounth_DropDownList.SelectedValue == "11") { Total_Expected = Sum_Expected_Y_O_B_M_11; Total_Income = Convert.ToDouble(Sum_Income_Y_O_B_M_11); }
                    else if (Mounth_DropDownList.SelectedValue == "12") { Total_Expected = Sum_Expected_Y_O_B_M_12; Total_Income = Convert.ToDouble(Sum_Income_Y_O_B_M_12); }

                    data_Rental_Value.Add(new ColumnChartData(Building_Name_DropDownList.SelectedItem.Text + " القيمة الإيجارية للبناء ", Sum_virtual_Value, Total_Expected, Total_Income));
                    this.Rental_Value.DataSource = data_Rental_Value;
                    this.Rental_Value.DataBind();
                    _sqlCon.Close();
                    //****************************************************  القيمة القارية **********************************************************************************************************
                    string Sum_Collection = "0";
                    string Rental_Value_Quary = "Select(Select Sum(Building_Value) From building Where owner_ship_Owner_Ship_Id='" + OwnerShip + "' And Building_Id = '" + Building + "')Sum_Bulidng_Value," +
                                                "(Select Sum(Land_Value) From owner_ship Where Owner_Ship_Id='" + OwnerShip + "')Sum_Land_Value," +
                                                "(Select Sum(Collection) From collection_table where Year='" + Year + "' And Ownersip_Id ='" + OwnerShip + "' And Building_Id = '" + Building + "')Sum_Collection";
                    _sqlCon.Open();
                    MySqlDataAdapter Value_Quary_Sda = new MySqlDataAdapter(Rental_Value_Quary, _sqlCon);
                    DataTable get_Value_Quary_Dt = new DataTable();
                    Value_Quary_Sda.Fill(get_Value_Quary_Dt);
                    if (get_Value_Quary_Dt.Rows.Count > 0)
                    {
                        if (get_Value_Quary_Dt.Rows[0]["Sum_Bulidng_Value"].ToString() == "") { Sum_Bulidng_Value = "0"; } else { Sum_Bulidng_Value = get_Value_Quary_Dt.Rows[0]["Sum_Bulidng_Value"].ToString(); }
                        if (get_Value_Quary_Dt.Rows[0]["Sum_Land_Value"].ToString() == "") { Sum_Land_Value = "0"; } else { Sum_Land_Value = get_Value_Quary_Dt.Rows[0]["Sum_Land_Value"].ToString(); }
                        if (get_Value_Quary_Dt.Rows[0]["Sum_Collection"].ToString() == "") { Sum_Collection = "0"; } else { Sum_Collection = get_Value_Quary_Dt.Rows[0]["Sum_Collection"].ToString(); }
                    }
                    Lbl_RealEstae.Text = "العائد على القيمة العقارية";
                    Syncfusion.JavaScript.DataVisualization.Models.Series series4 = RealEstae_Chart.Series[0];
                    series4.Points.Clear();
                    series4.Points.Add(new Points("الدخل السنوي", Convert.ToDouble(Sum_Collection)));
                    series4.Points.Add(new Points("قيمة العقار", Convert.ToDouble(Sum_Bulidng_Value) + Convert.ToDouble(Sum_Land_Value)));
                    _sqlCon.Close();

                    lbl_RealEstate_Value.Text = (Convert.ToDouble(Sum_Bulidng_Value) + Convert.ToDouble(Sum_Land_Value)).ToString("###,###,###");
                    Yearly_Income.Text = (Convert.ToDouble(Sum_Collection)).ToString("###,###,###");
                    lbl_RealEstate_Value_percentage.Text = (((Convert.ToDouble(Sum_Collection)) / (Convert.ToDouble(Sum_Bulidng_Value) + Convert.ToDouble(Sum_Land_Value))) * 100).ToString("0.00 ") + "%";
                    //********************************************** الإهلاك **********************************************************************************
                    string Construction_Completion_Date_Quary = "select Construction_Completion_Date from building where Building_Id = '" + Building + "'";
                    string Construction_Completion_Date = "0";

                    _sqlCon.Open();
                    MySqlDataAdapter VConstruction_Completion_Date_Sda = new MySqlDataAdapter(Construction_Completion_Date_Quary, _sqlCon);
                    DataTable VConstruction_Completion_Date_Dt = new DataTable();
                    VConstruction_Completion_Date_Sda.Fill(VConstruction_Completion_Date_Dt);
                    if (VConstruction_Completion_Date_Dt.Rows.Count > 0)
                    {
                        if (VConstruction_Completion_Date_Dt.Rows[0]["Construction_Completion_Date"].ToString() == "") { Construction_Completion_Date = "0"; } else { Construction_Completion_Date = VConstruction_Completion_Date_Dt.Rows[0]["Construction_Completion_Date"].ToString(); }
                    }
                    Syncfusion.JavaScript.DataVisualization.Models.Series series5 = destruction_Char.Series[0];
                    series5.Points.Clear();
                    series5.Points.Add(new Points("عمر البناء", (Convert.ToDouble(Year) - Convert.ToDouble(Construction_Completion_Date))));
                    series5.Points.Add(new Points("المتبقي من عمر البناء", (Convert.ToDouble(txt_Destruction_Value.Text) - (Convert.ToDouble(Year) - Convert.ToDouble(Construction_Completion_Date)))));
                    _sqlCon.Close();

                    div_1.Visible = true; div_2.Visible = false;
                    Label13.Text = (Convert.ToDouble(Year) - Convert.ToDouble(Construction_Completion_Date)).ToString("###,###,###");
                    Label15.Text = (Convert.ToDouble(Sum_Bulidng_Value) / Convert.ToDouble(txt_Destruction_Value.Text)).ToString("###,###,###");

                    Label17.Text = (Convert.ToDouble(Label15.Text) * (Convert.ToDouble(Year) - Convert.ToDouble(Construction_Completion_Date))).ToString("###,###,###");
                    Label19.Text = (Convert.ToDouble(txt_Destruction_Value.Text) - Convert.ToDouble(Label13.Text)).ToString("###,###,###");
                    Label21.Text = (Convert.ToDouble(Sum_Bulidng_Value) - Convert.ToDouble(Label17.Text)).ToString("###,###,###");

                    lbl_Depreciation_percentage.Text = "النسبة الئوية : " + (((Convert.ToDouble(Label13.Text)) / (Convert.ToDouble(Label19.Text))) * 100).ToString("0.00") + "%";
                    //*************************** الإستدامة و  النمو **********************************************************************************************************************************
                    Real_Estate_Sustainability();

                }
            }
        }


        protected void Mounth_DropDownList_SelectedIndexChanged(object sender, EventArgs e) { DashBoard_Function(); }
        protected void Year_DropDownList_SelectedIndexChanged(object sender, EventArgs e) { DashBoard_Function(); }
        protected void Ownership_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Building_Name_DropDownList.Enabled = true;
            // Fill Building DropDownList
            Helper.LoadDropDownList("SELECT * FROM building where  Active != 0 and owner_ship_Owner_Ship_Id='" + Ownership_Name_DropDownList.SelectedValue + "'", _sqlCon, Building_Name_DropDownList, "Building_Arabic_Name", "Building_Id");
            Building_Name_DropDownList.Items.Insert(0, "كل الأبنية");
            DashBoard_Function();
        }
        protected void Building_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e) { DashBoard_Function(); }
        protected void txt_Destruction_Value_TextChanged(object sender, EventArgs e) { DashBoard_Function(); }

        protected void Real_Estate_Sustainability()
        {
            //// *******************************  الإستدامة العقارية ******************************************************************************************
            _sqlCon.Open();

            double sum_18 = 0, sum_19 = 0, sum_20 = 0, sum_21 = 0, sum_22 = 0, sum_23 = 0, sum_24 = 0, sum_25 = 0, sum_26 = 0, sum_27 = 0, sum_28 = 0;

            double N_2018 = 0, N_2019 = 0, N_2020 = 0, N_2021 = 0, N_2022 = 0, N_2023 = 0, N_2024 = 0, N_2025 = 0, N_2026 = 0, N_2027 = 0, N_2028 = 0;

            double destruction_2018 = 0, destruction_2019 = 0, destruction_2020 = 0, destruction_2021 = 0, destruction_2022 = 0,
            destruction_2023 = 0, destruction_2024 = 0, destruction_2025 = 0, destruction_2026 = 0, destruction_2027 = 0, destruction_2028 = 0;

            double REI_2018 = 0, REI_2019 = 0, REI_2020 = 0, REI_2021 = 0, REI_2022 = 0, REI_2023 = 0, REI_2024 = 0, REI_2025 = 0, REI_2026 = 0, REI_2027 = 0, REI_2028 = 0;

            double Yearly_Depreciation = 0, Construction_Completion_Date = 0;

            double Sum_Land_Valuee = 0, Building_Value = 0;


            double Real_Estae_Value_18 = 0, Real_Estae_Value_19 = 0, Real_Estae_Value_20 = 0, Real_Estae_Value_21 = 0, Real_Estae_Value_22 = 0, Real_Estae_Value_23 = 0,
                Real_Estae_Value_24 = 0, Real_Estae_Value_25 = 0, Real_Estae_Value_26 = 0, Real_Estae_Value_27 = 0, Real_Estae_Value_28 = 0;

            double Sum_Yearly_Depreciation = 0;

            string D_Year = DateTime.Now.Year.ToString();

            string Quari = "select Construction_Completion_Date , Building_Value from building where Active !=0  and  IsRealEsataeInvesment = '0'";
            MySqlCommand Cmd = new MySqlCommand(Quari, _sqlCon);
            MySqlDataAdapter Dt = new MySqlDataAdapter(Cmd);
            Cmd.Connection = _sqlCon;
            Dt.SelectCommand = Cmd;
            DataTable DataTable = new DataTable();
            Dt.Fill(DataTable);
            if (DataTable.Rows.Count > 0)
            {
                for (int i = 0; i < DataTable.Rows.Count; i++)
                {
                    if (DataTable.Rows[i]["Building_Value"].ToString() == "") { Yearly_Depreciation = 0; } else { Yearly_Depreciation = (Convert.ToDouble(DataTable.Rows[i]["Building_Value"].ToString()) / Convert.ToDouble("30")); }
                    if (DataTable.Rows[i]["Construction_Completion_Date"].ToString() == "") { Construction_Completion_Date = 0; } else { Construction_Completion_Date = (Convert.ToDouble(DataTable.Rows[i]["Construction_Completion_Date"].ToString()) / Convert.ToDouble("30")); }



                    N_2018 = Yearly_Depreciation * (2018 - Construction_Completion_Date);
                    N_2019 = Yearly_Depreciation * (2019 - Construction_Completion_Date);
                    N_2020 = Yearly_Depreciation * (2020 - Construction_Completion_Date);
                    N_2021 = Yearly_Depreciation * (2021 - Construction_Completion_Date);
                    N_2022 = Yearly_Depreciation * (2022 - Construction_Completion_Date);
                    N_2023 = Yearly_Depreciation * (2023 - Construction_Completion_Date);
                    N_2024 = Yearly_Depreciation * (2024 - Construction_Completion_Date);
                    N_2025 = Yearly_Depreciation * (2025 - Construction_Completion_Date);
                    N_2026 = Yearly_Depreciation * (2026 - Construction_Completion_Date);
                    N_2027 = Yearly_Depreciation * (2027 - Construction_Completion_Date);
                    N_2028 = Yearly_Depreciation * (2028 - Construction_Completion_Date);


                    sum_18 += N_2018; sum_19 += N_2019; sum_20 += N_2020; sum_21 += N_2021; sum_22 += N_2022; sum_23 += N_2023; sum_24 += N_2024;
                    sum_25 += N_2025; sum_26 += N_2026; sum_27 += N_2027; sum_28 += N_2028;

                    Sum_Yearly_Depreciation += Yearly_Depreciation;



                    destruction_2018 = sum_18;
                    destruction_2019 = sum_19 + sum_18;
                    destruction_2020 = sum_20 + sum_19 + sum_18;
                    destruction_2021 = sum_21 + sum_20 + sum_19 + sum_18;
                    destruction_2022 = sum_22 + sum_21 + sum_20 + sum_19 + sum_18;
                    destruction_2023 = sum_23 + sum_22 + sum_21 + sum_20 + sum_19 + sum_18;


                    destruction_2024 = sum_24 + sum_23 + sum_22 + sum_21 + sum_20 + sum_19 + sum_18;
                    destruction_2025 = sum_25 + sum_24 + sum_23 + sum_22 + sum_21 + sum_20 + sum_19 + sum_18;
                    destruction_2026 = sum_26 + sum_25 + sum_24 + sum_23 + sum_22 + sum_21 + sum_20 + sum_19 + sum_18;
                    destruction_2027 = sum_27 + sum_26 + sum_25 + sum_24 + sum_23 + sum_22 + sum_21 + sum_20 + sum_19 + sum_18;
                    destruction_2028 = sum_28 + sum_27 + sum_26 + sum_25 + sum_24 + sum_23 + sum_22 + sum_21 + sum_20 + sum_19 + sum_18;



                }
            }




            string Quari_2 = "select(select sum(Value) from real_estate_investment where Year='2018')REI_2018," +
                            "(select sum(Value) from real_estate_investment where Year = '2019')REI_2019," +
                            "(select sum(Value) from real_estate_investment where Year = '2020')REI_2020," +
                            "(select sum(Value) from real_estate_investment where Year = '2021')REI_2021," +
                            "(select sum(Value) from real_estate_investment where Year = '2022')REI_2022," +
                            "(select sum(Value) from real_estate_investment where Year = '2023')REI_2023," +
                            "(select sum(Value) from real_estate_investment where Year = '2024')REI_2024," +
                            "(select sum(Value) from real_estate_investment where Year = '2025')REI_2025," +
                            "(select sum(Value) from real_estate_investment where Year = '2026')REI_2026," +
                            "(select sum(Value) from real_estate_investment where Year = '2027')REI_2027," +
                            "(select sum(Value) from real_estate_investment where Year = '2028')REI_2028; ";
            MySqlCommand Cmd_2 = new MySqlCommand(Quari_2, _sqlCon);
            MySqlDataAdapter Dt_2 = new MySqlDataAdapter(Cmd_2);
            Cmd_2.Connection = _sqlCon;
            Dt_2.SelectCommand = Cmd_2;
            DataTable DataTable_2 = new DataTable();
            Dt_2.Fill(DataTable_2);
            if (DataTable_2.Rows.Count > 0)
            {
                if (DataTable_2.Rows[0]["REI_2018"].ToString() == "") { REI_2018 = 0; } else { REI_2018 = Convert.ToDouble(DataTable_2.Rows[0]["REI_2018"].ToString()); }
                if (DataTable_2.Rows[0]["REI_2019"].ToString() == "") { REI_2019 = 0; } else { REI_2019 = Convert.ToDouble(DataTable_2.Rows[0]["REI_2019"].ToString()); }
                if (DataTable_2.Rows[0]["REI_2020"].ToString() == "") { REI_2020 = 0; } else { REI_2020 = Convert.ToDouble(DataTable_2.Rows[0]["REI_2020"].ToString()); }
                if (DataTable_2.Rows[0]["REI_2021"].ToString() == "") { REI_2021 = 0; } else { REI_2021 = Convert.ToDouble(DataTable_2.Rows[0]["REI_2021"].ToString()); }
                if (DataTable_2.Rows[0]["REI_2022"].ToString() == "") { REI_2022 = 0; } else { REI_2022 = Convert.ToDouble(DataTable_2.Rows[0]["REI_2022"].ToString()); }
                if (DataTable_2.Rows[0]["REI_2023"].ToString() == "") { REI_2023 = 0; } else { REI_2023 = Convert.ToDouble(DataTable_2.Rows[0]["REI_2023"].ToString()); }
                if (DataTable_2.Rows[0]["REI_2024"].ToString() == "") { REI_2024 = 0; } else { REI_2024 = Convert.ToDouble(DataTable_2.Rows[0]["REI_2024"].ToString()); }
                if (DataTable_2.Rows[0]["REI_2025"].ToString() == "") { REI_2025 = 0; } else { REI_2025 = Convert.ToDouble(DataTable_2.Rows[0]["REI_2025"].ToString()); }
                if (DataTable_2.Rows[0]["REI_2026"].ToString() == "") { REI_2026 = 0; } else { REI_2026 = Convert.ToDouble(DataTable_2.Rows[0]["REI_2026"].ToString()); }
                if (DataTable_2.Rows[0]["REI_2027"].ToString() == "") { REI_2027 = 0; } else { REI_2027 = Convert.ToDouble(DataTable_2.Rows[0]["REI_2027"].ToString()); }
                if (DataTable_2.Rows[0]["REI_2028"].ToString() == "") { REI_2028 = 0; } else { REI_2028 = Convert.ToDouble(DataTable_2.Rows[0]["REI_2028"].ToString()); }
            }
            if (Realestate_sustainability_Radio.SelectedValue == "1")
            {
                if (D_Year == "2028")
                {
                    List<E_R_S_LINE_CHART> Real_Estate_Sustainability_Data = new List<E_R_S_LINE_CHART>();
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2018, Sum_Yearly_Depreciation, REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2019, Sum_Yearly_Depreciation, REI_2019));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2020, Sum_Yearly_Depreciation, REI_2020));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2021, Sum_Yearly_Depreciation, REI_2021));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2022, Sum_Yearly_Depreciation, REI_2022));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2023, Sum_Yearly_Depreciation, REI_2023));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2024, Sum_Yearly_Depreciation, REI_2024));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2025, Sum_Yearly_Depreciation, REI_2025));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2026, Sum_Yearly_Depreciation, REI_2026));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2027, Sum_Yearly_Depreciation, REI_2027));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2028, Sum_Yearly_Depreciation, REI_2028));
                    this.Chart4.DataSource = Real_Estate_Sustainability_Data;
                    this.Chart4.DataBind();
                    _sqlCon.Close();
                }
                else if (D_Year == "2027")
                {
                    List<E_R_S_LINE_CHART> Real_Estate_Sustainability_Data = new List<E_R_S_LINE_CHART>();
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2018, Sum_Yearly_Depreciation, REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2019, Sum_Yearly_Depreciation, REI_2019));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2020, Sum_Yearly_Depreciation, REI_2020));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2021, Sum_Yearly_Depreciation, REI_2021));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2022, Sum_Yearly_Depreciation, REI_2022));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2023, Sum_Yearly_Depreciation, REI_2023));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2024, Sum_Yearly_Depreciation, REI_2024));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2025, Sum_Yearly_Depreciation, REI_2025));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2026, Sum_Yearly_Depreciation, REI_2026));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2027, Sum_Yearly_Depreciation, REI_2027));
                    this.Chart4.DataSource = Real_Estate_Sustainability_Data;
                    this.Chart4.DataBind();
                    _sqlCon.Close();
                }
                else if (D_Year == "2026")
                {
                    List<E_R_S_LINE_CHART> Real_Estate_Sustainability_Data = new List<E_R_S_LINE_CHART>();
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2018, Sum_Yearly_Depreciation, REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2019, Sum_Yearly_Depreciation, REI_2019));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2020, Sum_Yearly_Depreciation, REI_2020));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2021, Sum_Yearly_Depreciation, REI_2021));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2022, Sum_Yearly_Depreciation, REI_2022));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2023, Sum_Yearly_Depreciation, REI_2023));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2024, Sum_Yearly_Depreciation, REI_2024));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2025, Sum_Yearly_Depreciation, REI_2025));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2026, Sum_Yearly_Depreciation, REI_2026));
                    this.Chart4.DataSource = Real_Estate_Sustainability_Data;
                    this.Chart4.DataBind();
                    _sqlCon.Close();
                }
                else if (D_Year == "2025")
                {
                    List<E_R_S_LINE_CHART> Real_Estate_Sustainability_Data = new List<E_R_S_LINE_CHART>();
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2018, Sum_Yearly_Depreciation, REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2019, Sum_Yearly_Depreciation, REI_2019));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2020, Sum_Yearly_Depreciation, REI_2020));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2021, Sum_Yearly_Depreciation, REI_2021));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2022, Sum_Yearly_Depreciation, REI_2022));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2023, Sum_Yearly_Depreciation, REI_2023));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2024, Sum_Yearly_Depreciation, REI_2024));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2025, Sum_Yearly_Depreciation, REI_2025));
                    this.Chart4.DataSource = Real_Estate_Sustainability_Data;
                    this.Chart4.DataBind();
                    _sqlCon.Close();
                }
                else if (D_Year == "2024")
                {
                    List<E_R_S_LINE_CHART> Real_Estate_Sustainability_Data = new List<E_R_S_LINE_CHART>();
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2018, Sum_Yearly_Depreciation, REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2019, Sum_Yearly_Depreciation, REI_2019));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2020, Sum_Yearly_Depreciation, REI_2020));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2021, Sum_Yearly_Depreciation, REI_2021));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2022, Sum_Yearly_Depreciation, REI_2022));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2023, Sum_Yearly_Depreciation, REI_2023));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2024, Sum_Yearly_Depreciation, REI_2024));
                    this.Chart4.DataSource = Real_Estate_Sustainability_Data;
                    this.Chart4.DataBind();
                    _sqlCon.Close();
                }
                else
                {
                    List<E_R_S_LINE_CHART> Real_Estate_Sustainability_Data = new List<E_R_S_LINE_CHART>();
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2018, Sum_Yearly_Depreciation, REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2019, Sum_Yearly_Depreciation, REI_2019));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2020, Sum_Yearly_Depreciation, REI_2020));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2021, Sum_Yearly_Depreciation, REI_2021));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2022, Sum_Yearly_Depreciation, REI_2022));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2023, Sum_Yearly_Depreciation, REI_2023));
                    this.Chart4.DataSource = Real_Estate_Sustainability_Data;
                    this.Chart4.DataBind();
                    _sqlCon.Close();
                }
            }
            else
            {
                if (D_Year == "2028")
                {
                    List<E_R_S_LINE_CHART> Real_Estate_Sustainability_Data = new List<E_R_S_LINE_CHART>();
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2018, destruction_2018, REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2019, destruction_2019, REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2020, destruction_2020, REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2021, destruction_2021, REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2022, destruction_2022, REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2023, destruction_2023, REI_2023 + REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2024, destruction_2024, REI_2024 + REI_2023 + REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2025, destruction_2025, REI_2025 + REI_2024 + REI_2023 + REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2026, destruction_2026, REI_2026 + REI_2025 + REI_2024 + REI_2023 + REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2027, destruction_2027, REI_2027 + REI_2026 + REI_2025 + REI_2024 + REI_2023 + REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2028, destruction_2028, REI_2028 + REI_2027 + REI_2026 + REI_2025 + REI_2024 + REI_2023 + REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    this.Chart4.DataSource = Real_Estate_Sustainability_Data;
                    this.Chart4.DataBind();
                    _sqlCon.Close();
                }
                else if (D_Year == "2027")
                {
                    List<E_R_S_LINE_CHART> Real_Estate_Sustainability_Data = new List<E_R_S_LINE_CHART>();
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2018, destruction_2018, REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2019, destruction_2019, REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2020, destruction_2020, REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2021, destruction_2021, REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2022, destruction_2022, REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2023, destruction_2023, REI_2023 + REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2024, destruction_2024, REI_2024 + REI_2023 + REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2025, destruction_2025, REI_2025 + REI_2024 + REI_2023 + REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2026, destruction_2026, REI_2026 + REI_2025 + REI_2024 + REI_2023 + REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2027, destruction_2027, REI_2027 + REI_2026 + REI_2025 + REI_2024 + REI_2023 + REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    this.Chart4.DataSource = Real_Estate_Sustainability_Data;
                    this.Chart4.DataBind();
                    _sqlCon.Close();
                }
                else if (D_Year == "2026")
                {
                    List<E_R_S_LINE_CHART> Real_Estate_Sustainability_Data = new List<E_R_S_LINE_CHART>();
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2018, destruction_2018, REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2019, destruction_2019, REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2020, destruction_2020, REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2021, destruction_2021, REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2022, destruction_2022, REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2023, destruction_2023, REI_2023 + REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2024, destruction_2024, REI_2024 + REI_2023 + REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2025, destruction_2025, REI_2025 + REI_2024 + REI_2023 + REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2026, destruction_2026, REI_2026 + REI_2025 + REI_2024 + REI_2023 + REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    this.Chart4.DataSource = Real_Estate_Sustainability_Data;
                    this.Chart4.DataBind();
                    _sqlCon.Close();
                }
                else if (D_Year == "2025")
                {
                    List<E_R_S_LINE_CHART> Real_Estate_Sustainability_Data = new List<E_R_S_LINE_CHART>();
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2018, destruction_2018, REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2019, destruction_2019, REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2020, destruction_2020, REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2021, destruction_2021, REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2022, destruction_2022, REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2023, destruction_2023, REI_2023 + REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2024, destruction_2024, REI_2024 + REI_2023 + REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2025, destruction_2025, REI_2025 + REI_2024 + REI_2023 + REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    this.Chart4.DataSource = Real_Estate_Sustainability_Data;
                    this.Chart4.DataBind();
                    _sqlCon.Close();
                }
                else if (D_Year == "2024")
                {
                    List<E_R_S_LINE_CHART> Real_Estate_Sustainability_Data = new List<E_R_S_LINE_CHART>();
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2018, destruction_2018, REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2019, destruction_2019, REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2020, destruction_2020, REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2021, destruction_2021, REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2022, destruction_2022, REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2023, destruction_2023, REI_2023 + REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2024, destruction_2024, REI_2024 + REI_2023 + REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    this.Chart4.DataSource = Real_Estate_Sustainability_Data;
                    this.Chart4.DataBind();
                    _sqlCon.Close();
                }
                else
                {
                    List<E_R_S_LINE_CHART> Real_Estate_Sustainability_Data = new List<E_R_S_LINE_CHART>();
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2018, destruction_2018, REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2019, destruction_2019, REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2020, destruction_2020, REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2021, destruction_2021, REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2022, destruction_2022, REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2023, destruction_2023, REI_2023 + REI_2022 + REI_2021 + REI_2020 + REI_2019 + REI_2018));
                    this.Chart4.DataSource = Real_Estate_Sustainability_Data;
                    this.Chart4.DataBind();
                    _sqlCon.Close();
                }
            }


            // *******************************  القيمة العقارية ******************************************************************************************


            string Quari_3 = "select (select sum(Building_Value) from building where Active !=0 )Building_Value,(select sum(Land_Value) from owner_ship)Land_Value; ";
            MySqlCommand Cmd_3 = new MySqlCommand(Quari_3, _sqlCon);
            MySqlDataAdapter Dt_3 = new MySqlDataAdapter(Cmd_3);
            Cmd_3.Connection = _sqlCon;
            Dt_3.SelectCommand = Cmd_3;
            DataTable DataTable_3 = new DataTable();
            Dt_3.Fill(DataTable_3);
            if (DataTable_3.Rows.Count > 0)
            {
                if (DataTable_3.Rows[0]["Land_Value"].ToString() == "") { Sum_Land_Valuee = 0; } else { Sum_Land_Valuee = Convert.ToDouble(DataTable_3.Rows[0]["Land_Value"].ToString()); }
                if (DataTable_3.Rows[0]["Building_Value"].ToString() == "") { Building_Value = 0; } else { Building_Value = Convert.ToDouble(DataTable_3.Rows[0]["Building_Value"].ToString()); }
            }

            //Real_Estae_Value_18 = Sum_Land_Valuee + Building_Value + REI_2018;
            //Real_Estae_Value_19 = Sum_Land_Valuee + Building_Value + REI_2019;
            //Real_Estae_Value_20 = Sum_Land_Valuee + Building_Value + REI_2020;
            //Real_Estae_Value_21 = Sum_Land_Valuee + Building_Value + REI_2021;
            //Real_Estae_Value_22 = Sum_Land_Valuee + Building_Value + REI_2022;
            //Real_Estae_Value_23 = Sum_Land_Valuee + Building_Value + REI_2023;
            //Real_Estae_Value_24 = Sum_Land_Valuee + Building_Value + REI_2024;
            //Real_Estae_Value_25 = Sum_Land_Valuee + Building_Value + REI_2025;
            //Real_Estae_Value_26 = Sum_Land_Valuee + Building_Value + REI_2026;
            //Real_Estae_Value_27 = Sum_Land_Valuee + Building_Value + REI_2027;
            //Real_Estae_Value_28 = Sum_Land_Valuee + Building_Value + REI_2028;

            Real_Estae_Value_18 = Sum_Land_Valuee + Building_Value ;
            Real_Estae_Value_19 = Sum_Land_Valuee + Building_Value ;
            Real_Estae_Value_20 = Sum_Land_Valuee + Building_Value ;
            Real_Estae_Value_21 = Sum_Land_Valuee + Building_Value ;
            Real_Estae_Value_22 = Sum_Land_Valuee + Building_Value ;
            Real_Estae_Value_23 = Sum_Land_Valuee + Building_Value ;
            Real_Estae_Value_24 = Sum_Land_Valuee + Building_Value ;
            Real_Estae_Value_25 = Sum_Land_Valuee + Building_Value ;
            Real_Estae_Value_26 = Sum_Land_Valuee + Building_Value ;
            Real_Estae_Value_27 = Sum_Land_Valuee + Building_Value ;
            Real_Estae_Value_28 = Sum_Land_Valuee + Building_Value ;


            if (D_Year == "2028")
            {
                List<E_R_S_LINE_CHART> Real_Estate_Sustainability_Data = new List<E_R_S_LINE_CHART>();
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2018, Real_Estae_Value_18, Real_Estae_Value_18 - destruction_2018));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2019, Real_Estae_Value_19, Real_Estae_Value_19 - destruction_2019));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2020, Real_Estae_Value_20, Real_Estae_Value_20 - destruction_2020));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2021, Real_Estae_Value_21, Real_Estae_Value_21 - destruction_2022));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2022, Real_Estae_Value_22, Real_Estae_Value_22 - destruction_2022));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2023, Real_Estae_Value_23, Real_Estae_Value_23 - destruction_2023));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2024, Real_Estae_Value_24, Real_Estae_Value_24 - destruction_2024));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2025, Real_Estae_Value_25, Real_Estae_Value_25 - destruction_2025));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2026, Real_Estae_Value_26, Real_Estae_Value_26 - destruction_2026));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2027, Real_Estae_Value_27, Real_Estae_Value_27 - destruction_2027));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2028, Real_Estae_Value_28, Real_Estae_Value_28 - destruction_2028));
                this.Chart5.DataSource = Real_Estate_Sustainability_Data;
                this.Chart5.DataBind();


                // ***************** مؤشر الإستدامة التاركمي
                Syncfusion.JavaScript.DataVisualization.Models.Series series7 = Chart7.Series[0];
                series7.Points.Clear();
                series7.Points.Add(new Points("مجموع الهالك التراكمي", destruction_2028));
                series7.Points.Add(new Points("مجموع القيم العقارية الكلية", Sum_Land_Valuee + Building_Value));

                lbl_MHT.Text = destruction_2028.ToString("###,###,###");
                lbl_MKA.Text = (Sum_Land_Valuee + Building_Value).ToString("###,###,###");
                lbl_Cumulative_Sustainability_percentage.Text = (((Sum_Land_Valuee + Building_Value) / (destruction_2028)) * 100).ToString("0.00") + "%";
            }
            else if (D_Year == "2027")
            {
                List<E_R_S_LINE_CHART> Real_Estate_Sustainability_Data = new List<E_R_S_LINE_CHART>();
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2018, Real_Estae_Value_18, Real_Estae_Value_18 - destruction_2018));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2019, Real_Estae_Value_19, Real_Estae_Value_19 - destruction_2019));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2020, Real_Estae_Value_20, Real_Estae_Value_20 - destruction_2020));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2021, Real_Estae_Value_21, Real_Estae_Value_21 - destruction_2022));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2022, Real_Estae_Value_22, Real_Estae_Value_22 - destruction_2022));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2023, Real_Estae_Value_23, Real_Estae_Value_23 - destruction_2023));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2024, Real_Estae_Value_24, Real_Estae_Value_24 - destruction_2024));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2025, Real_Estae_Value_25, Real_Estae_Value_25 - destruction_2025));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2026, Real_Estae_Value_26, Real_Estae_Value_26 - destruction_2026));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2027, Real_Estae_Value_27, Real_Estae_Value_27 - destruction_2027));
                this.Chart5.DataSource = Real_Estate_Sustainability_Data;
                this.Chart5.DataBind();




                // ***************** مؤشر الإستدامة التاركمي
                Syncfusion.JavaScript.DataVisualization.Models.Series series7 = Chart7.Series[0];
                series7.Points.Clear();
                series7.Points.Add(new Points("مجموع الهالك التراكمي", destruction_2027));
                series7.Points.Add(new Points("مجموع القيم العقارية الكلية", Sum_Land_Valuee + Building_Value));

                lbl_MHT.Text = destruction_2027.ToString("###,###,###");
                lbl_MKA.Text = (Sum_Land_Valuee + Building_Value).ToString("###,###,###");
                lbl_Cumulative_Sustainability_percentage.Text = (((Sum_Land_Valuee + Building_Value) / (destruction_2027)) * 100).ToString("0.00") + "%";
            }
            else if (D_Year == "2026")
            {
                List<E_R_S_LINE_CHART> Real_Estate_Sustainability_Data = new List<E_R_S_LINE_CHART>();
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2018, Real_Estae_Value_18, Real_Estae_Value_18 - destruction_2018));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2019, Real_Estae_Value_19, Real_Estae_Value_19 - destruction_2019));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2020, Real_Estae_Value_20, Real_Estae_Value_20 - destruction_2020));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2021, Real_Estae_Value_21, Real_Estae_Value_21 - destruction_2022));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2022, Real_Estae_Value_22, Real_Estae_Value_22 - destruction_2022));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2023, Real_Estae_Value_23, Real_Estae_Value_23 - destruction_2023));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2024, Real_Estae_Value_24, Real_Estae_Value_24 - destruction_2024));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2025, Real_Estae_Value_25, Real_Estae_Value_25 - destruction_2025));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2026, Real_Estae_Value_26, Real_Estae_Value_26 - destruction_2026));
                this.Chart5.DataSource = Real_Estate_Sustainability_Data;
                this.Chart5.DataBind();








                // ***************** مؤشر الإستدامة التاركمي
                Syncfusion.JavaScript.DataVisualization.Models.Series series7 = Chart7.Series[0];
                series7.Points.Clear();
                series7.Points.Add(new Points("مجموع الهالك التراكمي", destruction_2026));
                series7.Points.Add(new Points("مجموع القيم العقارية الكلية", Sum_Land_Valuee + Building_Value));

                lbl_MHT.Text = destruction_2026.ToString("###,###,###");
                lbl_MKA.Text = (Sum_Land_Valuee + Building_Value).ToString("###,###,###");
                lbl_Cumulative_Sustainability_percentage.Text = (((Sum_Land_Valuee + Building_Value) / (destruction_2026)) * 100).ToString("0.00") + "%";
            }
            else if (D_Year == "2025")
            {
                List<E_R_S_LINE_CHART> Real_Estate_Sustainability_Data = new List<E_R_S_LINE_CHART>();
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2018, Real_Estae_Value_18, Real_Estae_Value_18 - destruction_2018));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2019, Real_Estae_Value_19, Real_Estae_Value_19 - destruction_2019));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2020, Real_Estae_Value_20, Real_Estae_Value_20 - destruction_2020));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2021, Real_Estae_Value_21, Real_Estae_Value_21 - destruction_2022));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2022, Real_Estae_Value_22, Real_Estae_Value_22 - destruction_2022));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2023, Real_Estae_Value_23, Real_Estae_Value_23 - destruction_2023));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2024, Real_Estae_Value_24, Real_Estae_Value_24 - destruction_2024));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2025, Real_Estae_Value_25, Real_Estae_Value_25 - destruction_2025));
                this.Chart5.DataSource = Real_Estate_Sustainability_Data;
                this.Chart5.DataBind();




                // ***************** مؤشر الإستدامة التاركمي
                Syncfusion.JavaScript.DataVisualization.Models.Series series7 = Chart7.Series[0];
                series7.Points.Clear();
                series7.Points.Add(new Points("مجموع الهالك التراكمي", destruction_2025));
                series7.Points.Add(new Points("مجموع القيم العقارية الكلية", Sum_Land_Valuee + Building_Value));

                lbl_MHT.Text = destruction_2025.ToString("###,###,###");
                lbl_MKA.Text = (Sum_Land_Valuee + Building_Value).ToString("###,###,###");
                lbl_Cumulative_Sustainability_percentage.Text = (((Sum_Land_Valuee + Building_Value) / (destruction_2025)) * 100).ToString("0.00") + "%";
            }
            else if (D_Year == "2024")
            {
                List<E_R_S_LINE_CHART> Real_Estate_Sustainability_Data = new List<E_R_S_LINE_CHART>();
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2018, Real_Estae_Value_18, Real_Estae_Value_18 - destruction_2018));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2019, Real_Estae_Value_19, Real_Estae_Value_19 - destruction_2019));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2020, Real_Estae_Value_20, Real_Estae_Value_20 - destruction_2020));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2021, Real_Estae_Value_21, Real_Estae_Value_21 - destruction_2022));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2022, Real_Estae_Value_22, Real_Estae_Value_22 - destruction_2022));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2023, Real_Estae_Value_23, Real_Estae_Value_23 - destruction_2023));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2024, Real_Estae_Value_24, Real_Estae_Value_24 - destruction_2024));
                this.Chart5.DataSource = Real_Estate_Sustainability_Data;
                this.Chart5.DataBind();




                // ***************** مؤشر الإستدامة التاركمي
                Syncfusion.JavaScript.DataVisualization.Models.Series series7 = Chart7.Series[0];
                series7.Points.Clear();
                series7.Points.Add(new Points("مجموع الهالك التراكمي", destruction_2024));
                series7.Points.Add(new Points("مجموع القيم العقارية الكلية", Sum_Land_Valuee + Building_Value));
                lbl_MHT.Text = destruction_2024.ToString("###,###,###");
                lbl_MKA.Text = (Sum_Land_Valuee + Building_Value).ToString("###,###,###");
                lbl_Cumulative_Sustainability_percentage.Text = (((Sum_Land_Valuee + Building_Value) / (destruction_2024)) * 100).ToString("0.00") + "%";
            }
            else
            {
                List<E_R_S_LINE_CHART> Real_Estate_Sustainability_Data = new List<E_R_S_LINE_CHART>();
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2018, Real_Estae_Value_18, Real_Estae_Value_18 - destruction_2018));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2019, Real_Estae_Value_19, Real_Estae_Value_19 - destruction_2019));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2020, Real_Estae_Value_20, Real_Estae_Value_20 - destruction_2020));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2021, Real_Estae_Value_21, Real_Estae_Value_21 - destruction_2022));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2022, Real_Estae_Value_22, Real_Estae_Value_22 - destruction_2022));
                Real_Estate_Sustainability_Data.Add(new E_R_S_LINE_CHART(2023, Real_Estae_Value_23, Real_Estae_Value_23 - destruction_2023));
                this.Chart5.DataSource = Real_Estate_Sustainability_Data;
                this.Chart5.DataBind();



                // ***************** مؤشر الإستدامة التاركمي
                Syncfusion.JavaScript.DataVisualization.Models.Series series7 = Chart7.Series[0];
                series7.Points.Clear();
                series7.Points.Add(new Points("مجموع الهالك التراكمي", destruction_2023));
                series7.Points.Add(new Points("مجموع القيم العقارية الكلية", Sum_Land_Valuee + Building_Value));
                lbl_MHT.Text = destruction_2023.ToString("###,###,###");
                lbl_MKA.Text = (Sum_Land_Valuee + Building_Value).ToString("###,###,###");
                lbl_Cumulative_Sustainability_percentage.Text = (((Sum_Land_Valuee + Building_Value) / (destruction_2023)) * 100).ToString("0.00") + "%";
                double Sub1 = (((Sum_Land_Valuee + Building_Value) / (destruction_2023)) * 100);
                Label35.Text = (100 - Sub1).ToString("0.00") + "%";
            }


            Syncfusion.JavaScript.DataVisualization.Models.Series series6 = Chart6.Series[0];
            series6.Points.Clear();
            series6.Points.Add(new Points("مجموع الهالك السنوي", Sum_Yearly_Depreciation));
            series6.Points.Add(new Points("مجموع القيم العقارية الكلية", Sum_Land_Valuee + Building_Value));
            lbl_Total_Annual_Loss.Text = Sum_Yearly_Depreciation.ToString("###,###,###");
            lbl_All_OwnerShip_Value.Text = (Sum_Land_Valuee + Building_Value).ToString("###,###,###");
            lbl_Annual_Sustainability_percentage.Text = (((Sum_Yearly_Depreciation) / (Sum_Land_Valuee + Building_Value)) * 100).ToString("0.00") + "%";
            // 
            double Sub2 = (((Sum_Yearly_Depreciation) / (Sum_Land_Valuee + Building_Value)) * 100);
            Label34.Text = (100 - Sub2).ToString("0.00") + "%";








        }














        protected void Mortgage_All()
        {
            string M_Land_Value = "0";
            string M_Building_Value = "0";

            string All_Land_Value = "0";
            string All_Building_Value = "0";

            string Amount_Paid = "0";
            string Remaining_Amount = "0";



            string All_M_Land_Value_quiry = "select sum(O.Land_Value) M_Land_Value  from mortgaged_wonership M  left join owner_ship O on (M.Ownership_Id = O.Owner_Ship_Id);";
            DataTable get_Mortgage_Dt = new DataTable();
            _sqlCon.Open();
            MySqlCommand get_Mortgage_Cmd = new MySqlCommand(All_M_Land_Value_quiry, _sqlCon);
            MySqlDataAdapter get_Mortgage_Da = new MySqlDataAdapter(get_Mortgage_Cmd);
            get_Mortgage_Da.Fill(get_Mortgage_Dt);
            if (get_Mortgage_Dt.Rows.Count > 0)
            {
                if (get_Mortgage_Dt.Rows[0]["M_Land_Value"].ToString() == "") { M_Land_Value = "0"; }
                else { M_Land_Value = get_Mortgage_Dt.Rows[0]["M_Land_Value"].ToString(); }
            }
            _sqlCon.Close();




            string All_M_Building_Value_quiry = "select sum(B.Building_Value) M_Building_Value from mortgaged_wonership M left join building B on (M.Ownership_Id = B.owner_ship_Owner_Ship_Id);";
            DataTable get_Building_Mortgage_Dt = new DataTable();
            _sqlCon.Open();
            MySqlCommand get_Building_Mortgage_Cmd = new MySqlCommand(All_M_Building_Value_quiry, _sqlCon);
            MySqlDataAdapter get_Building_Mortgage_Da = new MySqlDataAdapter(get_Building_Mortgage_Cmd);
            get_Building_Mortgage_Da.Fill(get_Building_Mortgage_Dt);
            if (get_Building_Mortgage_Dt.Rows.Count > 0)
            {
                if (get_Building_Mortgage_Dt.Rows[0]["M_Building_Value"].ToString() == "") { M_Building_Value = "0"; }
                else { M_Building_Value = get_Building_Mortgage_Dt.Rows[0]["M_Building_Value"].ToString(); }
            }
            _sqlCon.Close();

            //************************************ قيمة كل الملكيات ********************************************************************
            string All_Ownership_Value_quiry = "select (select sum(Land_Value) from owner_ship) All_Land_Value ,  (select sum(Building_Value) from building) All_Building_Value ";
            DataTable get_All_Ownership_Value_Dt = new DataTable();
            _sqlCon.Open();
            MySqlCommand get_All_Ownership_Value_Cmd = new MySqlCommand(All_Ownership_Value_quiry, _sqlCon);
            MySqlDataAdapter get_All_Ownership_Value_Da = new MySqlDataAdapter(get_All_Ownership_Value_Cmd);
            get_All_Ownership_Value_Da.Fill(get_All_Ownership_Value_Dt);
            if (get_All_Ownership_Value_Dt.Rows.Count > 0)
            {
                if (get_All_Ownership_Value_Dt.Rows[0]["All_Land_Value"].ToString() == "") { All_Land_Value = "0"; }
                else { All_Land_Value = get_All_Ownership_Value_Dt.Rows[0]["All_Land_Value"].ToString(); }


                if (get_All_Ownership_Value_Dt.Rows[0]["All_Building_Value"].ToString() == "") { All_Building_Value = "0"; }
                else { All_Building_Value = get_All_Ownership_Value_Dt.Rows[0]["All_Building_Value"].ToString(); }
            }
            _sqlCon.Close();




            //************************************ قيمة المبلغ المتبقي و المسدد ********************************************************************
            string All_Remaining_Remaining_quiry = "" +
                "select sum((TIMESTAMPDIFF(MONTH, Start_Date , Now()) *  Installment_Value ))as Amount_Paid , " +
                "sum((Mortgage_Value - (TIMESTAMPDIFF(MONTH, Start_Date , Now()) *  Installment_Value ))) as Remaining_Amount " +
                "from mortgaged_wonership M left join owner_ship O on (M.Ownership_Id = O.owner_Ship_Id)";




            DataTable get_All_Remaining_Remaining_Dt = new DataTable();
            _sqlCon.Open();
            MySqlCommand get_All_Remaining_Remaining_Cmd = new MySqlCommand(All_Remaining_Remaining_quiry, _sqlCon);
            MySqlDataAdapter get_All_Remaining_Remaining_Da = new MySqlDataAdapter(get_All_Remaining_Remaining_Cmd);
            get_All_Remaining_Remaining_Da.Fill(get_All_Remaining_Remaining_Dt);
            if (get_All_Remaining_Remaining_Dt.Rows.Count > 0)
            {
                if (get_All_Remaining_Remaining_Dt.Rows[0]["Amount_Paid"].ToString() == "") { Amount_Paid = "0"; }
                else { Amount_Paid = get_All_Remaining_Remaining_Dt.Rows[0]["Amount_Paid"].ToString(); }


                if (get_All_Remaining_Remaining_Dt.Rows[0]["Remaining_Amount"].ToString() == "") { Remaining_Amount = "0"; }
                else { Remaining_Amount = get_All_Remaining_Remaining_Dt.Rows[0]["Remaining_Amount"].ToString(); }
            }
            _sqlCon.Close();




            //*****************مؤشر قيم الملكيات  المرهونة و الغير مرهونة


            double T = Convert.ToDouble(M_Land_Value) + Convert.ToDouble(M_Building_Value);



            string X = T.ToString();






            Syncfusion.JavaScript.DataVisualization.Models.Series seriesM = Chart8.Series[0];
            seriesM.Points.Clear();
            seriesM.Points.Add(new Points("قيمة الملكيات المرهونة", Convert.ToDouble(Convert.ToDouble(X).ToString(""))));
            seriesM.Points.Add(new Points("قيم جميع الملكيات", (Convert.ToDouble(All_Land_Value) + Convert.ToDouble(All_Building_Value)) - T));
            Label37.Text = T.ToString("###,###,###");
            Label40.Text = (Convert.ToDouble(All_Land_Value) + Convert.ToDouble(All_Building_Value)).ToString("###,###,###");
            All_Ownership_Value.Text = (((Convert.ToDouble(M_Land_Value) + Convert.ToDouble(M_Building_Value)) / (Convert.ToDouble(All_Land_Value) + Convert.ToDouble(All_Building_Value))) * 100).ToString("0.00") + "%";
            double Sum3 = ((Convert.ToDouble(M_Land_Value) + Convert.ToDouble(M_Building_Value)) / (Convert.ToDouble(All_Land_Value) + Convert.ToDouble(All_Building_Value))) * 100;
            //Label41.Text = (100 - Sum3).ToString("0.00") + "%";

            Label56.Text = ((Convert.ToDouble(All_Land_Value) + Convert.ToDouble(All_Building_Value)) - T).ToString("###,###,###");
            Label57.Text = (100 - Sum3).ToString("0.00") + "%";



            // ***************** المبالغ المسددة و المبالغ المتبقية
            Syncfusion.JavaScript.DataVisualization.Models.Series seriesM_2 = Chart9.Series[0];
            seriesM_2.Points.Clear();
            seriesM_2.Points.Add(new Points("المبلغ المسددة", Convert.ToDouble(Amount_Paid)));
            seriesM_2.Points.Add(new Points("المبلغ المتبقي", Convert.ToDouble(Remaining_Amount)));
            Label42.Text = Convert.ToDouble(Amount_Paid).ToString("###,###,###");
            Label45.Text = Convert.ToDouble(Remaining_Amount).ToString("###,###,###");
            All_Paid_Amount.Text = ((100 - (Convert.ToDouble(Remaining_Amount) / (Convert.ToDouble(Amount_Paid))) * 100)).ToString("0.00") + "%";
            Label46.Text = ((Convert.ToDouble(Remaining_Amount) / (Convert.ToDouble(Amount_Paid))) * 100).ToString("0.00") + "%";

            Label59.Text = (Convert.ToDouble(Amount_Paid) + Convert.ToDouble(Remaining_Amount)).ToString("###,###,###");

        }
        protected void percent_nationality_GridView()
        {
            Chart12.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            _sqlCon.Open();
            string contract_Count = "0"; string building_contract_Count = "0";
            string Contract_CountQuari = "select(select COUNT(Contract_Id)from building_contract)building_contract_Count,(select COUNT(Contract_Id)from contract)contract_Count";
            MySqlCommand Contract_CountCmd = new MySqlCommand(Contract_CountQuari, _sqlCon);
            MySqlDataAdapter Contract_CountDt = new MySqlDataAdapter(Contract_CountCmd);
            Contract_CountCmd.Connection = _sqlCon;
            Contract_CountDt.SelectCommand = Contract_CountCmd;
            DataTable Contract_CountDataTable = new DataTable();
            Contract_CountDt.Fill(Contract_CountDataTable);
            contract_Count = Contract_CountDataTable.Rows[0]["contract_Count"].ToString();
            building_contract_Count = Contract_CountDataTable.Rows[0]["building_contract_Count"].ToString();
            //--------------------------------------------------------------------------------------------------
            string Quary = "SELECT  T.Tenants_Arabic_Name ,  " +
                "TN.Arabic_nationality , " +
                " COUNT(TN.Arabic_nationality) 'عدد الجنسيات' , " +
                "  ((COUNT(TN.Arabic_nationality) / '" + contract_Count + "') * 100)percent " +
                " FROM contract C " +
                "left join tenants T on(C.tenants_Tenants_ID = T.Tenants_Id) " +
                " left join nationality TN on(T.nationality_nationality_ID = TN.nationality_ID) " +
                " GROUP BY TN.Arabic_nationality " +
                " HAVING COUNT(TN.Arabic_nationality) > 0; ";
            DataTable Dt = new DataTable();
            DataSet ds = new DataSet();
            MySqlCommand Cmd = new MySqlCommand(Quary, _sqlCon);
            MySqlDataAdapter Da = new MySqlDataAdapter(Cmd);
            Da.Fill(ds);
            DataTable ChartData = ds.Tables[0];
            string[] XPointMember = new string[ChartData.Rows.Count];
            int[] YPointMember = new int[ChartData.Rows.Count];
            for (int count = 0; count < ChartData.Rows.Count; count++)
            {
                XPointMember[count] = ChartData.Rows[count]["Arabic_nationality"].ToString();
                YPointMember[count] = Convert.ToInt32(ChartData.Rows[count]["percent"]);
                Chart12.Series[0].Points.DataBindXY(XPointMember, YPointMember);
                Chart12.Series[0].BorderWidth = 10;
                Chart12.Series[0].ChartType = SeriesChartType.Column;
            }
            //--------------------------------------------------------------------------------------------------
            string Quary2 = "SELECT  T.Tenants_Arabic_Name ,  " +
                "TN.Arabic_nationality , " +
                " COUNT(TN.Arabic_nationality) 'عدد الجنسيات' , " +
                "  ((COUNT(TN.Arabic_nationality) / '" + building_contract_Count + "') * 100)percent " +
                " FROM building_contract C " +
                "left join tenants T on(C.tenants_Tenants_ID = T.Tenants_Id) " +
                " left join nationality TN on(T.nationality_nationality_ID = TN.nationality_ID) " +
                " GROUP BY TN.Arabic_nationality " +
                " HAVING COUNT(TN.Arabic_nationality) > 0; ";
            DataTable Dt2 = new DataTable();
            DataSet ds2 = new DataSet();
            MySqlCommand Cmd2 = new MySqlCommand(Quary2, _sqlCon);
            MySqlDataAdapter Da2 = new MySqlDataAdapter(Cmd2);
            Da2.Fill(ds2);
            DataTable ChartData2 = ds2.Tables[0];
            string[] XPointMember2 = new string[ChartData2.Rows.Count];
            int[] YPointMember2 = new int[ChartData2.Rows.Count];
            for (int count = 0; count < ChartData2.Rows.Count; count++)
            {
                XPointMember2[count] = ChartData2.Rows[count]["Arabic_nationality"].ToString();
                YPointMember2[count] = Convert.ToInt32(ChartData2.Rows[count]["percent"]);
                Chart13.Series[0].Points.DataBindXY(XPointMember2, YPointMember2);
                Chart13.Series[0].BorderWidth = 10;
                Chart13.Series[0].ChartType = SeriesChartType.Column;
            }

            _sqlCon.Close();
        }
        protected void Tenant_Evaluation()
        {
            using (MySqlCommand TenanatEvaluationCmd = new MySqlCommand("Evaluation_Chart", _sqlCon))
            {
                TenanatEvaluationCmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter TenanatEvaluationSda = new MySqlDataAdapter(TenanatEvaluationCmd);

                DataTable TenanatEvaluationDt = new DataTable();
                TenanatEvaluationSda.Fill(TenanatEvaluationDt);
                TenanatEvaluationCmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                TenanatEvaluationSda.Fill(dt);




                Syncfusion.JavaScript.DataVisualization.Models.Series seriesE = Chart10.Series[0];
                seriesE.Points.Clear();

                seriesE.Points.Add(new Points("", 0));
                seriesE.Points.Add(new Points("", 0));
                seriesE.Points.Add(new Points("", 0));
                seriesE.Points.Add(new Points("", 0));
                seriesE.Points.Add(new Points("", 0));
                seriesE.Points.Add(new Points("", 0));

                seriesE.Points.Add(new Points("A", Convert.ToDouble(dt.Rows[0]["R_A"].ToString())));
                seriesE.Points.Add(new Points("B", Convert.ToDouble(dt.Rows[0]["R_B"].ToString())));
                seriesE.Points.Add(new Points("C", Convert.ToDouble(dt.Rows[0]["R_C"].ToString())));
                seriesE.Points.Add(new Points("D", Convert.ToDouble(dt.Rows[0]["R_D"].ToString())));
                seriesE.Points.Add(new Points("E", Convert.ToDouble(dt.Rows[0]["R_E"].ToString())));



                _sqlCon.Close();
            }
        }
        protected void Undermaintenance_Click(object sender, EventArgs e)
        {
            Response.Redirect("Unit_List_Status.aspx?Id=3");
        }
        protected void Available_Click(object sender, EventArgs e)
        {
            Response.Redirect("Unit_List_Status.aspx?Id=2");
        }
        protected void UnderProplem_Click(object sender, EventArgs e)
        {
            Response.Redirect("Unit_List_Status.aspx?Id=4");
        }
        protected void Rented_Click(object sender, EventArgs e)
        {
            Response.Redirect("Unit_List_Status.aspx?Id=1");
        }
        protected void Expaired_Contract(object sender, EventArgs e)
        {
            Response.Redirect("Expaired_Contract.aspx");
        }





        protected void All_Building_Condition()
        {
            string Construction_Completion_Date_Quary = "select (select count(*) from building where building_condition_Building_Condition_Id = '1' and Active = '1' )All_Building_C1 , " +
                "(select count(*) from building where building_condition_Building_Condition_Id = '5' and Active = '1')All_Building_C2 , " +
                "(select count(*) from building where building_condition_Building_Condition_Id = '6' and Active = '1')All_Building_C3 , " +
                "(select count(*) from building where building_condition_Building_Condition_Id = '7' and Active = '1')All_Building_C4 , " +
                "(select count(*) from building where building_condition_Building_Condition_Id = '8' and Active = '1')All_Building_C5 , " +
                "(select count(*) from building where building_condition_Building_Condition_Id = '9' and Active = '1')All_Building_C6 , " +
                " (select count(*) from building where building_condition_Building_Condition_Id = '10' and Active = '1')All_Building_C7 ,  " +
                "(SELECT IF(All_Building_C1 != 0, All_Building_C1, 0))R_All_Building_C1 , " +
                " (SELECT IF(All_Building_C2 != 0, All_Building_C2, 0))R_All_Building_C2 , " +
                "(SELECT IF(All_Building_C3 != 0, All_Building_C3, 0))R_All_Building_C3 , " +
                " (SELECT IF(All_Building_C4 != 0, All_Building_C4, 0))R_All_Building_C4 , " +
                " (SELECT IF(All_Building_C5 != 0, All_Building_C5, 0))R_All_Building_C5 , " +
                "(SELECT IF(All_Building_C6 != 0, All_Building_C6, 0))R_All_Building_C6 , " +
                " (SELECT IF(All_Building_C7 != 0, All_Building_C7, 0))R_All_Building_C7 ";
            _sqlCon.Open();
            MySqlDataAdapter VConstruction_Completion_Date_Sda = new MySqlDataAdapter(Construction_Completion_Date_Quary, _sqlCon);
            DataTable VConstruction_Completion_Date_Dt = new DataTable();
            VConstruction_Completion_Date_Sda.Fill(VConstruction_Completion_Date_Dt);
            Syncfusion.JavaScript.DataVisualization.Models.Series series5 = Chart11.Series[0];
            series5.Points.Clear();
            series5.Points.Add(new Points("جديد", Convert.ToDouble(VConstruction_Completion_Date_Dt.Rows[0]["R_All_Building_C1"].ToString())));
            series5.Points.Add(new Points("متابعة", Convert.ToDouble(VConstruction_Completion_Date_Dt.Rows[0]["R_All_Building_C2"].ToString())));
            series5.Points.Add(new Points("دراسة صيانة", Convert.ToDouble(VConstruction_Completion_Date_Dt.Rows[0]["R_All_Building_C3"].ToString())));
            series5.Points.Add(new Points("دراسة صيانة اثنان", Convert.ToDouble(VConstruction_Completion_Date_Dt.Rows[0]["R_All_Building_C4"].ToString())));
            series5.Points.Add(new Points("متهالك", Convert.ToDouble(VConstruction_Completion_Date_Dt.Rows[0]["R_All_Building_C5"].ToString())));
            series5.Points.Add(new Points("غير صالح", Convert.ToDouble(VConstruction_Completion_Date_Dt.Rows[0]["R_All_Building_C6"].ToString())));
            series5.Points.Add(new Points("متعدد", Convert.ToDouble(VConstruction_Completion_Date_Dt.Rows[0]["R_All_Building_C7"].ToString())));
            _sqlCon.Close();
        }



        protected void Building_Condition()
        {
            string Construction_Completion_Date_Quary = "select " +
        "(select count(*) from building where building_condition_Building_Condition_Id = '1' and Active = '1' and owner_ship_Owner_Ship_Id ='" + Ownership_Name_DropDownList.SelectedValue + "')All_Building_C1 , " +
        "(select count(*) from building where building_condition_Building_Condition_Id = '5' and Active = '1' and owner_ship_Owner_Ship_Id ='" + Ownership_Name_DropDownList.SelectedValue + "')All_Building_C2 , " +
        "(select count(*) from building where building_condition_Building_Condition_Id = '6' and Active = '1' and owner_ship_Owner_Ship_Id ='" + Ownership_Name_DropDownList.SelectedValue + "')All_Building_C3 , " +
        "(select count(*) from building where building_condition_Building_Condition_Id = '7' and Active = '1' and owner_ship_Owner_Ship_Id ='" + Ownership_Name_DropDownList.SelectedValue + "')All_Building_C4 , " +
        "(select count(*) from building where building_condition_Building_Condition_Id = '8' and Active = '1' and owner_ship_Owner_Ship_Id ='" + Ownership_Name_DropDownList.SelectedValue + "')All_Building_C5 , " +
        "(select count(*) from building where building_condition_Building_Condition_Id = '9' and Active = '1' and owner_ship_Owner_Ship_Id ='" + Ownership_Name_DropDownList.SelectedValue + "')All_Building_C6 , " +
        " (select count(*) from building where building_condition_Building_Condition_Id = '10' and Active = '1' and owner_ship_Owner_Ship_Id ='" + Ownership_Name_DropDownList.SelectedValue + "' )All_Building_C7 ,  " +
        "(SELECT IF(All_Building_C1 != 0, All_Building_C1, 0))R_All_Building_C1 , " +
        " (SELECT IF(All_Building_C2 != 0, All_Building_C2, 0))R_All_Building_C2 , " +
        "(SELECT IF(All_Building_C3 != 0, All_Building_C3, 0))R_All_Building_C3 , " +
        " (SELECT IF(All_Building_C4 != 0, All_Building_C4, 0))R_All_Building_C4 , " +
        " (SELECT IF(All_Building_C5 != 0, All_Building_C5, 0))R_All_Building_C5 , " +
        "(SELECT IF(All_Building_C6 != 0, All_Building_C6, 0))R_All_Building_C6 , " +
        " (SELECT IF(All_Building_C7 != 0, All_Building_C7, 0))R_All_Building_C7 ";
            _sqlCon.Open();
            MySqlDataAdapter VConstruction_Completion_Date_Sda = new MySqlDataAdapter(Construction_Completion_Date_Quary, _sqlCon);
            DataTable VConstruction_Completion_Date_Dt = new DataTable();
            VConstruction_Completion_Date_Sda.Fill(VConstruction_Completion_Date_Dt);
            Syncfusion.JavaScript.DataVisualization.Models.Series series5 = Chart11.Series[0];
            series5.Points.Clear();
            series5.Points.Add(new Points("جديد", Convert.ToDouble(VConstruction_Completion_Date_Dt.Rows[0]["R_All_Building_C1"].ToString())));
            series5.Points.Add(new Points("متابعة", Convert.ToDouble(VConstruction_Completion_Date_Dt.Rows[0]["R_All_Building_C2"].ToString())));
            series5.Points.Add(new Points("دراسة صيانة", Convert.ToDouble(VConstruction_Completion_Date_Dt.Rows[0]["R_All_Building_C3"].ToString())));
            series5.Points.Add(new Points("دراسة صيانة اثنان", Convert.ToDouble(VConstruction_Completion_Date_Dt.Rows[0]["R_All_Building_C4"].ToString())));
            series5.Points.Add(new Points("متهالك", Convert.ToDouble(VConstruction_Completion_Date_Dt.Rows[0]["R_All_Building_C5"].ToString())));
            series5.Points.Add(new Points("غير صالح", Convert.ToDouble(VConstruction_Completion_Date_Dt.Rows[0]["R_All_Building_C6"].ToString())));
            series5.Points.Add(new Points("متعدد", Convert.ToDouble(VConstruction_Completion_Date_Dt.Rows[0]["R_All_Building_C7"].ToString())));
            _sqlCon.Close();
        }

        protected void Realestate_sustainability_Radio_SelectedIndexChanged(object sender, EventArgs e)
        {
            Real_Estate_Sustainability();
        }
    }
}