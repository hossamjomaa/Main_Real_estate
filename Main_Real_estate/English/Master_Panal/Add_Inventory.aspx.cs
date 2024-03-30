using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Add_Inventory : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Fill storekeeper_DropDownList
                Helper.LoadDropDownList("SELECT * FROM employee", _sqlCon, storekeeper_DropDownList, "Employee_Arabic_name", "Employee_Id");
                storekeeper_DropDownList.Items.Insert(0, "إختر أمين المخزن  ....");
            }
        }

        protected void btn_Add_Inventory_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addInventoryQuary =
                    "Insert Into Inventory " +
                    "(Inventory_English_name,Inventory_arabic_name,Inventory_Location,employee_Employee_Id) " +
                    "VALUES" +
                    "(@Inventory_English_name,@Inventory_arabic_name,@Inventory_Location,@employee_Employee_Id)";
                _sqlCon.Open();
                MySqlCommand addInventoryCmd = new MySqlCommand(addInventoryQuary, _sqlCon);
                addInventoryCmd.Parameters.AddWithValue("@Inventory_English_name", txt_En_Inventory_Name.Text);
                addInventoryCmd.Parameters.AddWithValue("@Inventory_arabic_name", txt_Ar_Inventory_Name.Text);
                addInventoryCmd.Parameters.AddWithValue("@Inventory_Location", txt_Inventory_Location.Text);
                addInventoryCmd.Parameters.AddWithValue("@employee_Employee_Id", storekeeper_DropDownList.SelectedValue);
                addInventoryCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Add_New_Inventory.Text = "تمت الإضافة بنجاح";
                Response.Redirect("Inventory_List.aspx");
            }
        }

        protected void btn_Back_To_Inventory_List_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Inventory_List.aspx");
        }
    }
}