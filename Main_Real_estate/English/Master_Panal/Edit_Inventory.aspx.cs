using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_Inventory : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Fill storekeeper_DropDownList
                Helper.LoadDropDownList("SELECT * FROM employee", _sqlCon, storekeeper_DropDownList, "Employee_Arabic_name", "Employee_Id");
                storekeeper_DropDownList.Items.Insert(0, "إختر أمين المخزن  ....");


                string inventoryId = Request.QueryString["Id"];
                DataTable getInventoryDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getInventoryCmd =
                    new MySqlCommand("SELECT * FROM Inventory WHERE Inventory_Id = @ID", _sqlCon);
                MySqlDataAdapter getInventoryDa = new MySqlDataAdapter(getInventoryCmd);

                getInventoryCmd.Parameters.AddWithValue("@ID", inventoryId);
                getInventoryDa.Fill(getInventoryDt);
                if (getInventoryDt.Rows.Count > 0)
                {
                    txt_En_Inventory_Name.Text = getInventoryDt.Rows[0]["Inventory_English_name"].ToString();
                    txt_Ar_Inventory_Name.Text = getInventoryDt.Rows[0]["Inventory_arabic_name"].ToString();
                    txt_Inventory_Location.Text = getInventoryDt.Rows[0]["Inventory_Location"].ToString();
                    storekeeper_DropDownList.SelectedValue = getInventoryDt.Rows[0]["employee_Employee_Id"].ToString();
                    lbl_titel_Name_Edit_Inventory.Text = getInventoryDt.Rows[0]["Inventory_arabic_name"].ToString();
                }

                _sqlCon.Close();
            }
        }

        protected void btn_Back_To_Inventory_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inventory_List.aspx");
        }

        protected void btn_Add_Inventory_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string inventoryId = Request.QueryString["Id"];
                string updateInventoryQuary =
                    "UPDATE Inventory SET " +
                    "employee_Employee_Id=@employee_Employee_Id ," +
                    "Inventory_English_name=@Inventory_English_name ," +
                    " Inventory_arabic_name=@Inventory_arabic_name , " +
                    "Inventory_Location=@Inventory_Location WHERE Inventory_Id=@ID ";
                _sqlCon.Open();
                MySqlCommand updateInventoryCmd = new MySqlCommand(updateInventoryQuary, _sqlCon);
                updateInventoryCmd.Parameters.AddWithValue("@ID", inventoryId);
                updateInventoryCmd.Parameters.AddWithValue("@employee_Employee_Id", storekeeper_DropDownList.SelectedValue);
                updateInventoryCmd.Parameters.AddWithValue("@Inventory_English_name", txt_En_Inventory_Name.Text);
                updateInventoryCmd.Parameters.AddWithValue("@Inventory_arabic_name", txt_Ar_Inventory_Name.Text);
                updateInventoryCmd.Parameters.AddWithValue("@Inventory_Location", txt_Inventory_Location.Text);
                updateInventoryCmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_Success_Edit_Inventory.Text = "تم التعديل بنجاح";
                Response.Redirect("Inventory_List.aspx");
            }
        }
    }
}