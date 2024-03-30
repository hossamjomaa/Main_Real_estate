using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics.Contracts;
using System.Web.Services.Description;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Contract_Arcive : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Contracting", 0, "R");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            Get_OS_Arcive_BindData();
            Get_B_Arcive_BindData();
        }


        protected void Get_OS_Arcive_BindData()
        {

            string getOS_ArciveQuari = "select DA.* , UN.Users_Ar_First_Name , " +
                "C.Contract_Id , C.Date_Of_Sgin , C.Start_Date , C.End_Date , C.Payment_Amount ,  " +
                "T.Tenants_Arabic_Name , " +
                "U.Unit_ID , U.Unit_Number ,  " +
                "B.Building_Id , B.Building_Arabic_Name , " +
                "O.Owner_Ship_AR_Name , O.owner_ship_Code " +
                " from delete_archive DA " +
                "left join arcive_contract C on(DA.Item_Id = C.Contract_Id) " +
                "left join tenants T on(C.tenants_Tenants_ID = T.Tenants_ID) " +
                "left join arcive_units U on(C.units_Unit_ID = U.Unit_ID) " +
                "left join arcive_building B on(U.building_Building_Id = B.Building_Id) " +
                "left join arcive_ownership O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                "left join users UN on(DA.User_Id = UN.user_ID) where DA.OS_B_U = 'C'";





            MySqlCommand getOS_ArciveCmd = new MySqlCommand(getOS_ArciveQuari, _sqlCon);
            MySqlDataAdapter getOS_ArciveDt = new MySqlDataAdapter(getOS_ArciveCmd);
            getOS_ArciveCmd.Connection = _sqlCon;
            _sqlCon.Open();
            getOS_ArciveDt.SelectCommand = getOS_ArciveCmd;
            DataTable getOS_ArciveDataTable = new DataTable();
            getOS_ArciveDt.Fill(getOS_ArciveDataTable);
            Ownership_GridView.DataSource = getOS_ArciveDataTable;
            Ownership_GridView.DataBind();
            _sqlCon.Close();

        }


        protected void Get_B_Arcive_BindData()
        {

            string getB_ArciveQuari = "select DA.* , UN.Users_Ar_First_Name , " +
                "C.Contract_Id , C.Date_Of_Sgin , C.Start_Date , C.End_Date , C.Payment_Amount , " +
                "T.Tenants_Arabic_Name , " +
                "B.Building_Id , B.Building_Arabic_Name , " +
                "O.Owner_Ship_AR_Name , O.owner_ship_Code " +
                "from delete_archive DA " +
                "left join arcive_building_contract C on(DA.Item_Id = C.Contract_Id) " +
                "left join tenants T on(C.tenants_Tenants_ID = T.Tenants_ID) " +
                "left join arcive_building B on(C.building_Building_Id = B.Building_Id) " +
                "left join arcive_ownership O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                "left join users UN on(DA.User_Id = UN.user_ID) " +
                "where DA.OS_B_U = 'BC'";


            MySqlCommand getB_ArciveCmd = new MySqlCommand(getB_ArciveQuari, _sqlCon);
            MySqlDataAdapter getB_ArciveDt = new MySqlDataAdapter(getB_ArciveCmd);
            getB_ArciveCmd.Connection = _sqlCon;
            _sqlCon.Open();
            getB_ArciveDt.SelectCommand = getB_ArciveCmd;
            DataTable getB_ArciveDataTable = new DataTable();
            getB_ArciveDt.Fill(getB_ArciveDataTable);
            Building_GridView.DataSource = getB_ArciveDataTable;
            Building_GridView.DataBind();
            _sqlCon.Close();

        }

        protected void A_1_ServerClick(object sender, EventArgs e)
        {
            OS_Arcive.Visible = true;
            B_Arcive.Visible = false;
            lbl_titel_Contracts_List.Text = "أرشيف العقود المفردة";
        }

        protected void A_2_ServerClick(object sender, EventArgs e)
        {
            OS_Arcive.Visible = false;
            B_Arcive.Visible = true;
            lbl_titel_Contracts_List.Text = "أرشيف العقود المجملة";
        }

        protected void A_3_ServerClick(object sender, EventArgs e)
        {
            OS_Arcive.Visible = false;
            B_Arcive.Visible = false;
            lbl_titel_Contracts_List.Text = "أرشيف كافة العقود";
        }

        protected void A_4_ServerClick(object sender, EventArgs e)
        {
            OS_Arcive.Visible = true;
            B_Arcive.Visible = true;
            lbl_titel_Contracts_List.Text = "أرشيف كافة العقود";
        }
    }
}