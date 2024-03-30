using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Maintenance_SubType : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Helper.LoadDropDownList("SELECT * FROM maintenance_categoty where Main_Categoty = 0", _sqlCon, Maintenance_Types_DropDownList,
                    "Categoty_AR", "Categoty_Id");
                Maintenance_Types_DropDownList.Items.Insert(0, "إختر نوع الصيانة ....");
            }
        }
        protected void btn_Add_Maintenance_Subtypes_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addMaintenanceSubTypesQuary =
                    "Insert Into maintenance_categoty (Categoty_AR , Categoty_En , Main_Categoty,Active) " +
                    "VALUES(@Categoty_AR, @Categoty_En , @Main_Categoty,@Active)";
                _sqlCon.Open();
                MySqlCommand addMaintenanceSubTypesCmd = new MySqlCommand(addMaintenanceSubTypesQuary, _sqlCon);
                addMaintenanceSubTypesCmd.Parameters.AddWithValue("@Categoty_En", txt_En_Maintenance_Subtypes_Name.Text);
                addMaintenanceSubTypesCmd.Parameters.AddWithValue("@Categoty_AR", txt_Ar_Maintenance_Subtypes_Name.Text);
                addMaintenanceSubTypesCmd.Parameters.AddWithValue("@Main_Categoty", Maintenance_Types_DropDownList.SelectedValue);
                addMaintenanceSubTypesCmd.Parameters.AddWithValue("@Active", 1);
                addMaintenanceSubTypesCmd.ExecuteNonQuery();
                lbl_Success_Add_New_Maintenance_Subtypes.Text = "تمت الإضافة بنجاح";
                _sqlCon.Close();
                Response.Redirect("Maintenance_SubType_List.aspx");
            }
        }
        protected void btn_Back_To_Maintenance_Subtypes_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Maintenance_SubType_List.aspx");
        }
    }
}