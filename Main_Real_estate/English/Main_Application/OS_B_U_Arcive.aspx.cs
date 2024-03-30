using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.Services.Description;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class OS_B_U_Arcive : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "properties", 0, "R");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            Get_OS_Arcive_BindData();
            Get_B_Arcive_BindData();
            Get_U_Arcive_BindData();
        }




        protected void Get_OS_Arcive_BindData()
        {
            
                string getOS_ArciveQuari = "select DA.* , UN.Users_Ar_First_Name ,  OS.Owner_Ship_AR_Name , OS.owner_ship_Code " +
                                            "from delete_archive DA " +
                                            "left join arcive_ownership OS on (DA.Item_Id = OS.Owner_Ship_Id) " +
                                            "left join users UN on (DA.User_Id = UN.user_ID) " +
                                            "where DA.OS_B_U = 'OS'";
                MySqlCommand getOS_ArciveCmd = new MySqlCommand(getOS_ArciveQuari, _sqlCon);
                MySqlDataAdapter getOS_ArciveDt = new MySqlDataAdapter(getOS_ArciveCmd);
                getOS_ArciveCmd.Connection = _sqlCon;
                _sqlCon.Open();
                getOS_ArciveDt.SelectCommand = getOS_ArciveCmd;
                DataTable getOS_ArciveDataTable = new DataTable();
                getOS_ArciveDt.Fill(getOS_ArciveDataTable);
                if (getOS_ArciveDataTable.Rows.Count > 0)
                {
                    Ownership_GridView.DataSource = getOS_ArciveDataTable;
                    Ownership_GridView.DataBind();
                }
            else
            {
                lbl_NO_O_Data.Text = "لا توجد بيانات";
            }
                
                _sqlCon.Close();
            
        }



        protected void Get_B_Arcive_BindData()
        {
           
                string getB_ArciveQuari = "select DA.* , " +
                "UN.Users_Ar_First_Name , OS.Owner_Ship_AR_Name , OS.owner_ship_Code ,  B.Building_Arabic_Name , B.Building_NO " +
                "from delete_archive DA " +
                "left join arcive_ownership OS on (DA.Item_Id = OS.Owner_Ship_Id) " +
                " left join arcive_building B on (DA.Item_Id = B.Building_Id) " +
                "left join users UN on (DA.User_Id = UN.user_ID) " +
                "where DA.OS_B_U = 'B'; ";
            MySqlCommand getB_ArciveCmd = new MySqlCommand(getB_ArciveQuari, _sqlCon);
                MySqlDataAdapter getB_ArciveDt = new MySqlDataAdapter(getB_ArciveCmd);
                getB_ArciveCmd.Connection = _sqlCon;
                _sqlCon.Open();
                getB_ArciveDt.SelectCommand = getB_ArciveCmd;
                DataTable getB_ArciveDataTable = new DataTable();
                getB_ArciveDt.Fill(getB_ArciveDataTable);
            if (getB_ArciveDataTable.Rows.Count > 0)
            {
                Building_GridView.DataSource = getB_ArciveDataTable;
                Building_GridView.DataBind();
            }
            else
            {
                lbl_NO_B_Data.Text = "لا توجد بيانات";
            }
                
                _sqlCon.Close();
           
        }



        protected void Get_U_Arcive_BindData()
        {

            string getB_ArciveQuari = "select DA.* ,  " +
                                    "UN.Users_Ar_First_Name , " +
                                    "OS.Owner_Ship_AR_Name , OS.owner_ship_Code , " +
                                    " B.Building_Arabic_Name , B.Building_NO , " +
                                    "U.Unit_Number " +
                                    "from delete_archive DA " +
                                    "left join arcive_ownership OS on(DA.Item_Id = OS.Owner_Ship_Id) " +
                                    "left join arcive_building B on(DA.Item_Id = B.Building_Id) " +
                                    "left join arcive_units U on(DA.Item_Id = U.Unit_ID) " +
                                    "left join users UN on(DA.User_Id = UN.user_ID) " +
                                    "where DA.OS_B_U = 'U'; ";




            MySqlCommand getB_ArciveCmd = new MySqlCommand(getB_ArciveQuari, _sqlCon);
            MySqlDataAdapter getB_ArciveDt = new MySqlDataAdapter(getB_ArciveCmd);
            getB_ArciveCmd.Connection = _sqlCon;
            _sqlCon.Open();
            getB_ArciveDt.SelectCommand = getB_ArciveCmd;
            DataTable getB_ArciveDataTable = new DataTable();
            getB_ArciveDt.Fill(getB_ArciveDataTable);
            if (getB_ArciveDataTable.Rows.Count > 0)
            {
                Unit_GridView.DataSource = getB_ArciveDataTable;
                Unit_GridView.DataBind();
            }
            else
            {
                lbl_NO_U_Data.Text = "لا توجد بيانات ";
            }
                
            _sqlCon.Close();

        }

        protected void A_1_ServerClick(object sender, EventArgs e)
        {
            OS_Arcive.Visible= true;
            B_Arcive.Visible = false;
            U_Arcive.Visible = false;
        }

        protected void A_2_ServerClick(object sender, EventArgs e)
        {
            OS_Arcive.Visible = false;
            B_Arcive.Visible = true;
            U_Arcive.Visible = false;
        }

        protected void A_3_ServerClick(object sender, EventArgs e)
        {
            OS_Arcive.Visible = false;
            B_Arcive.Visible = false;
            U_Arcive.Visible = true;
        }

        protected void A_4_ServerClick(object sender, EventArgs e)
        {
            OS_Arcive.Visible = true;
            B_Arcive.Visible = true;
            U_Arcive.Visible = true;
        }
    }
}