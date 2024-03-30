using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Maintenance_Type : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_Add_Maintenance_Type_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //string addMaintenanceTypesQuary =
                //    "Insert Into maintenance_type (Maintenance_English_Type,Maintenance_Arabic_Type) VALUES(@Maintenance_English_Type,@Maintenance_Arabic_Type)";


                string addMaintenanceTypesQuary =
                   "Insert Into maintenance_categoty (Categoty_AR,Categoty_En,Main_Categoty,Active) VALUES(@Categoty_AR,@Categoty_En,@Main_Categoty,@Active)";

                _sqlCon.Open();
                MySqlCommand addMaintenanceTypesCmd = new MySqlCommand(addMaintenanceTypesQuary, _sqlCon);
                addMaintenanceTypesCmd.Parameters.AddWithValue("@Categoty_En", txt_En_Maintenance_Type_Name.Text);
                addMaintenanceTypesCmd.Parameters.AddWithValue("@Categoty_AR", txt_Ar_Maintenance_Type_Name.Text);

                addMaintenanceTypesCmd.Parameters.AddWithValue("@Main_Categoty", 0);
                addMaintenanceTypesCmd.Parameters.AddWithValue("@Active", 1);

                addMaintenanceTypesCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Maintenance_Type.Text = "تمت الإضافة بنجاح";

                _sqlCon.Close();
                Response.Redirect("Maintenance_Type_List.aspx");
            }
        }

        protected void btn_Back_To_Maintenance_Type_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Maintenance_Type_List.aspx");
        }
    }
}