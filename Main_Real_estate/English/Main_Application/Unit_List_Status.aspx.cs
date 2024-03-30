using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Unit_List_Status : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Status_ID = Request.QueryString["Id"];
            if (Status_ID == "1") { lbl_titel_Unit_Status.Text = "المؤجرة"; }
            else if (Status_ID == "2") { lbl_titel_Unit_Status.Text = "الشاغرة"; }
            else if (Status_ID == "3") { lbl_titel_Unit_Status.Text = "تحت الإنشاء أو الصيانة"; }
            else if (Status_ID == "4") { lbl_titel_Unit_Status.Text = "موجودة النزاع"; }

            Get_Unit_List_status_BindData();
        }
        protected void Get_Unit_List_status_BindData()
        {
            try
            {
                string Status_ID = Request.QueryString["Id"];
                string getUnit_List_statusQuari = "SELECT  " +
                    "U.* ,  " +
                    "U.Image_One_Path ,  " +
                    " U.Image_Two_Path ,  " +
                    "U.Image_Three_Path , " +
                    "U.Image_Four_Path ,   " +
                    " UT.Unit_Arabic_Type  , " +
                    "UC.Unit_Arabic_Condition , " +
                    " UD.Unit_Arabic_Detail ,  " +
                    " B.Building_Arabic_Name , " +
                    " B.Building_NO , " +
                    " O.Owner_Ship_AR_Name, " +
                    " O.Street_NO, " +
                    " O.Street_Name " +
                    " FROM units U " +
                    " left join unit_type UT on(U.unit_type_Unit_Type_Id = UT.Unit_Type_Id) " +
                    " left join unit_condition UC on(U.unit_condition_Unit_Condition_Id = UC.Unit_Condition_Id) " +
                    " left join unit_detail UD on(U.unit_detail_Unit_Detail_Id = UD.Unit_Detail_Id) " +
                    " left join building B on(U.building_Building_Id = B.Building_Id) " +
                    " left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                    " where U.unit_condition_Unit_Condition_Id = '"+Status_ID+"' And U.Half = '0' ; ";

                MySqlCommand getUnit_List_statusCmd = new MySqlCommand(getUnit_List_statusQuari, _sqlCon);
                MySqlDataAdapter getUnit_List_statusDt = new MySqlDataAdapter(getUnit_List_statusCmd);
                getUnit_List_statusCmd.Connection = _sqlCon;
                _sqlCon.Open();
                getUnit_List_statusDt.SelectCommand = getUnit_List_statusCmd;
                DataTable getUnit_List_statusDataTable = new DataTable();
                getUnit_List_statusDt.Fill(getUnit_List_statusDataTable);
                eeeee.DataSource = getUnit_List_statusDataTable;
                eeeee.DataBind();
                _sqlCon.Close();
            }
            catch (Exception ex)
            {
            }
        }
    }
}