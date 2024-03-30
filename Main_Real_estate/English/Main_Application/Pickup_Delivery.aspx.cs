using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Pickup_Delivery : System.Web.UI.Page
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

                //Fill Tenant Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM tenants", _sqlCon, Tenan_Name_DropDownList, "Tenants_Arabic_Name", "Tenants_ID");
                Tenan_Name_DropDownList.Items.Insert(0, "إختر المستأجر ...");


                //    //Fill Ownership Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM owner_ship where Active !='1'", _sqlCon, Ownership_Name_DropDownList,
                "Owner_Ship_AR_Name", "Owner_Ship_Id");
                Ownership_Name_DropDownList.Items.Insert(0, "إختر الملكية ....");

                //    //Fill Building Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM building Where Active ='1'", _sqlCon, Building_Name_DropDownList,
                    "Building_Arabic_Name", "Building_Id");
                Building_Name_DropDownList.Items.Insert(0, "إختر البناء ....");

                //    //Fill Units Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM units Where Half ='0'", _sqlCon, Units_DropDownList, "Unit_Number", "Unit_ID");
                Units_DropDownList.Items.Insert(0, "إختر الوحدة ....");



                Prosees_DropDownList.Items.Insert(0, "إختر العملية ....");
            }
                
        }

        protected void btn_Pickup_Delivery_Click(object sender, EventArgs e)
        {
            string addPickup_DeliveryQuary = "Insert Into pickup_delivery " +
                "(Unit_Id , Type , Status , Note , Date , Prosses , Tenant_ID) " +
                "VALUES" +
                "(@Unit_Id , @Type , @Status , @Note , @Date ,  @Prosses , @Tenant_ID)";

            _sqlCon.Open();
            MySqlCommand addPickup_DeliveryCmd = new MySqlCommand(addPickup_DeliveryQuary, _sqlCon);
            addPickup_DeliveryCmd.Parameters.AddWithValue("@Unit_Id", Units_DropDownList.SelectedValue);
            addPickup_DeliveryCmd.Parameters.AddWithValue("@Type", "المفاتيح");
            addPickup_DeliveryCmd.Parameters.AddWithValue("@Status", Key_Radio.SelectedValue);
            addPickup_DeliveryCmd.Parameters.AddWithValue("@Note", txt_Key.Text);
            addPickup_DeliveryCmd.Parameters.AddWithValue("@Date",txt_Sign_Date.Text);
            addPickup_DeliveryCmd.Parameters.AddWithValue("@Prosses", Prosees_DropDownList.SelectedValue);
            addPickup_DeliveryCmd.Parameters.AddWithValue("@Tenant_ID", Tenan_Name_DropDownList.SelectedValue);
            addPickup_DeliveryCmd.ExecuteNonQuery();
            _sqlCon.Close();


            
            _sqlCon.Open();
            MySqlCommand addPickup_DeliveryCmd_2 = new MySqlCommand(addPickup_DeliveryQuary, _sqlCon);
            addPickup_DeliveryCmd_2.Parameters.AddWithValue("@Unit_Id", Units_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_2.Parameters.AddWithValue("@Type", "الأثاث");
            addPickup_DeliveryCmd_2.Parameters.AddWithValue("@Status", Ferneture_Radio.SelectedValue);
            addPickup_DeliveryCmd_2.Parameters.AddWithValue("@Note", txt_Ferneture.Text);
            addPickup_DeliveryCmd_2.Parameters.AddWithValue("@Date", txt_Sign_Date.Text);
            addPickup_DeliveryCmd_2.Parameters.AddWithValue("@Prosses", Prosees_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_2.Parameters.AddWithValue("@Tenant_ID", Tenan_Name_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_2.ExecuteNonQuery();
            _sqlCon.Close();


            _sqlCon.Open();
            MySqlCommand addPickup_DeliveryCmd_3 = new MySqlCommand(addPickup_DeliveryQuary, _sqlCon);
            addPickup_DeliveryCmd_3.Parameters.AddWithValue("@Unit_Id", Units_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_3.Parameters.AddWithValue("@Type", "الأجهزة المنزلية");
            addPickup_DeliveryCmd_3.Parameters.AddWithValue("@Status", Device_Radio.SelectedValue);
            addPickup_DeliveryCmd_3.Parameters.AddWithValue("@Note", txt_Device.Text);
            addPickup_DeliveryCmd_3.Parameters.AddWithValue("@Date", txt_Sign_Date.Text);
            addPickup_DeliveryCmd_3.Parameters.AddWithValue("@Prosses", Prosees_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_3.Parameters.AddWithValue("@Tenant_ID", Tenan_Name_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_3.ExecuteNonQuery();
            _sqlCon.Close();


            _sqlCon.Open();
            MySqlCommand addPickup_DeliveryCmd_4 = new MySqlCommand(addPickup_DeliveryQuary, _sqlCon);
            addPickup_DeliveryCmd_4.Parameters.AddWithValue("@Unit_Id", Units_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_4.Parameters.AddWithValue("@Type", "المطبخ");
            addPickup_DeliveryCmd_4.Parameters.AddWithValue("@Status", kitchen_Radio.SelectedValue);
            addPickup_DeliveryCmd_4.Parameters.AddWithValue("@Note", txt_kitchen.Text);
            addPickup_DeliveryCmd_4.Parameters.AddWithValue("@Date", txt_Sign_Date.Text);
            addPickup_DeliveryCmd_4.Parameters.AddWithValue("@Prosses", Prosees_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_4.Parameters.AddWithValue("@Tenant_ID", Tenan_Name_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_4.ExecuteNonQuery();
            _sqlCon.Close();



            _sqlCon.Open();
            MySqlCommand addPickup_DeliveryCmd_5 = new MySqlCommand(addPickup_DeliveryQuary, _sqlCon);
            addPickup_DeliveryCmd_5.Parameters.AddWithValue("@Unit_Id", Units_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_5.Parameters.AddWithValue("@Type", "المنافذ الكهربائية");
            addPickup_DeliveryCmd_5.Parameters.AddWithValue("@Status", electricity_Radio.SelectedValue);
            addPickup_DeliveryCmd_5.Parameters.AddWithValue("@Note", txt_electricity.Text);
            addPickup_DeliveryCmd_5.Parameters.AddWithValue("@Date", txt_Sign_Date.Text);
            addPickup_DeliveryCmd_5.Parameters.AddWithValue("@Prosses", Prosees_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_5.Parameters.AddWithValue("@Tenant_ID", Tenan_Name_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_5.ExecuteNonQuery();
            _sqlCon.Close();



            _sqlCon.Open();
            MySqlCommand addPickup_DeliveryCmd_6 = new MySqlCommand(addPickup_DeliveryQuary, _sqlCon);
            addPickup_DeliveryCmd_6.Parameters.AddWithValue("@Unit_Id", Units_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_6.Parameters.AddWithValue("@Type", "الأرضيات");
            addPickup_DeliveryCmd_6.Parameters.AddWithValue("@Status", Floor_Radio.SelectedValue);
            addPickup_DeliveryCmd_6.Parameters.AddWithValue("@Note", txt_Floor.Text);
            addPickup_DeliveryCmd_6.Parameters.AddWithValue("@Date", txt_Sign_Date.Text);
            addPickup_DeliveryCmd_6.Parameters.AddWithValue("@Prosses", Prosees_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_6.Parameters.AddWithValue("@Tenant_ID", Tenan_Name_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_6.ExecuteNonQuery();
            _sqlCon.Close();



            _sqlCon.Open();
            MySqlCommand addPickup_DeliveryCmd_7 = new MySqlCommand(addPickup_DeliveryQuary, _sqlCon);
            addPickup_DeliveryCmd_7.Parameters.AddWithValue("@Unit_Id", Units_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_7.Parameters.AddWithValue("@Type", "الحمامات / غرف الغسيل");
            addPickup_DeliveryCmd_7.Parameters.AddWithValue("@Status", Pathroom_Radio.SelectedValue);
            addPickup_DeliveryCmd_7.Parameters.AddWithValue("@Note", txt_Pathroom.Text);
            addPickup_DeliveryCmd_7.Parameters.AddWithValue("@Date", txt_Sign_Date.Text);
            addPickup_DeliveryCmd_7.Parameters.AddWithValue("@Prosses", Prosees_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_7.Parameters.AddWithValue("@Tenant_ID", Tenan_Name_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_7.ExecuteNonQuery();
            _sqlCon.Close();


            _sqlCon.Open();
            MySqlCommand addPickup_DeliveryCmd_8 = new MySqlCommand(addPickup_DeliveryQuary, _sqlCon);
            addPickup_DeliveryCmd_8.Parameters.AddWithValue("@Unit_Id", Units_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_8.Parameters.AddWithValue("@Type", "الجدران و الأسقف");
            addPickup_DeliveryCmd_8.Parameters.AddWithValue("@Status", Wall_Radio.SelectedValue);
            addPickup_DeliveryCmd_8.Parameters.AddWithValue("@Note", txt_Wall.Text);
            addPickup_DeliveryCmd_8.Parameters.AddWithValue("@Date", txt_Sign_Date.Text);
            addPickup_DeliveryCmd_8.Parameters.AddWithValue("@Prosses", Prosees_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_8.Parameters.AddWithValue("@Tenant_ID", Tenan_Name_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_8.ExecuteNonQuery();
            _sqlCon.Close();


            _sqlCon.Open();
            MySqlCommand addPickup_DeliveryCmd_9 = new MySqlCommand(addPickup_DeliveryQuary, _sqlCon);
            addPickup_DeliveryCmd_9.Parameters.AddWithValue("@Unit_Id", Units_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_9.Parameters.AddWithValue("@Type", "الأبواب");
            addPickup_DeliveryCmd_9.Parameters.AddWithValue("@Status", Door_Radio.SelectedValue);
            addPickup_DeliveryCmd_9.Parameters.AddWithValue("@Note", txt_Dor.Text);
            addPickup_DeliveryCmd_9.Parameters.AddWithValue("@Date", txt_Sign_Date.Text);
            addPickup_DeliveryCmd_9.Parameters.AddWithValue("@Prosses", Prosees_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_9.Parameters.AddWithValue("@Tenant_ID", Tenan_Name_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_9.ExecuteNonQuery();
            _sqlCon.Close();



            _sqlCon.Open();
            MySqlCommand addPickup_DeliveryCmd_10 = new MySqlCommand(addPickup_DeliveryQuary, _sqlCon);
            addPickup_DeliveryCmd_10.Parameters.AddWithValue("@Unit_Id", Units_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_10.Parameters.AddWithValue("@Type", "النوافذ");
            addPickup_DeliveryCmd_10.Parameters.AddWithValue("@Status", Window_Radio.SelectedValue);
            addPickup_DeliveryCmd_10.Parameters.AddWithValue("@Note", txt_Window.Text);
            addPickup_DeliveryCmd_10.Parameters.AddWithValue("@Date", txt_Sign_Date.Text);
            addPickup_DeliveryCmd_10.Parameters.AddWithValue("@Prosses", Prosees_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_10.Parameters.AddWithValue("@Tenant_ID", Tenan_Name_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_10.ExecuteNonQuery();
            _sqlCon.Close();



            _sqlCon.Open();
            MySqlCommand addPickup_DeliveryCmd_11 = new MySqlCommand(addPickup_DeliveryQuary, _sqlCon);
            addPickup_DeliveryCmd_11.Parameters.AddWithValue("@Unit_Id", Units_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_11.Parameters.AddWithValue("@Type", "المكيفات");
            addPickup_DeliveryCmd_11.Parameters.AddWithValue("@Status", AC_Radio.SelectedValue);
            addPickup_DeliveryCmd_11.Parameters.AddWithValue("@Note", txt_AC.Text);
            addPickup_DeliveryCmd_11.Parameters.AddWithValue("@Date", txt_Sign_Date.Text);
            addPickup_DeliveryCmd_11.Parameters.AddWithValue("@Prosses", Prosees_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_11.Parameters.AddWithValue("@Tenant_ID", Tenan_Name_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_11.ExecuteNonQuery();
            _sqlCon.Close();





            string addPickup_DeliveryQuary_Dis = "Insert Into pickup_delivery " +
                "(Unit_Id , Type , Status ,  Date , Prosses , Discription , Tenant_ID) " +
                "VALUES" +
                "(@Unit_Id , @Type , @Status ,  @Date ,  @Prosses , @Discription , @Tenant_ID)";
            _sqlCon.Open();
            MySqlCommand addPickup_DeliveryCmd_Dis = new MySqlCommand(addPickup_DeliveryQuary_Dis, _sqlCon);
            addPickup_DeliveryCmd_Dis.Parameters.AddWithValue("@Unit_Id", Units_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_Dis.Parameters.AddWithValue("@Type", "ملاحظات");
            addPickup_DeliveryCmd_Dis.Parameters.AddWithValue("@Status", "0");
            addPickup_DeliveryCmd_Dis.Parameters.AddWithValue("@Discription", txt_Discription.Text);
            addPickup_DeliveryCmd_Dis.Parameters.AddWithValue("@Date", txt_Sign_Date.Text);
            addPickup_DeliveryCmd_Dis.Parameters.AddWithValue("@Prosses", Prosees_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_Dis.Parameters.AddWithValue("@Tenant_ID", Tenan_Name_DropDownList.SelectedValue);
            addPickup_DeliveryCmd_Dis.ExecuteNonQuery();
            _sqlCon.Close();

        }





























        //******************  Get The Building Of Selected Ownership ***************************************************
        protected void Ownership_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    //Fill Buildings Name DropDownList
            Helper.LoadDropDownList(
                "SELECT * FROM building where Active ='1' and owner_ship_Owner_Ship_Id = '" +
                Ownership_Name_DropDownList.SelectedValue + "'", _sqlCon, Building_Name_DropDownList,
                "Building_Arabic_Name", "Building_Id");
            Building_Name_DropDownList.Items.Insert(0, "إختر البناء ....");
        }

        //******************  Get The Units Of Selected Building ***************************************************
        protected void Building_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    //Fill units Name DropDownList
            Helper.LoadDropDownList("SELECT * FROM units where Half ='0' and building_Building_Id = '" + Building_Name_DropDownList.SelectedValue + "'", _sqlCon, Units_DropDownList, "Unit_Number", "Unit_ID");
            Units_DropDownList.Items.Insert(0, "إختر الوحدة ....");
        }

        //******************  Date ***************************************************
        protected void Sign_Date_Calendar_SelectionChanged1(object sender, EventArgs e)
        {
            txt_Sign_Date.Text = Sign_Date_Calendar.SelectedDate.ToShortDateString();
            if (txt_Sign_Date.Text != "")
            {
                Sign_Date_divCalendar.Visible = false;
                ImageButton1.Visible = false;
            }
        }

        protected void Date_Chosee_Click(object sender, EventArgs e)
        {
            Sign_Date_divCalendar.Visible = true;
            ImageButton1.Visible = true;
        }

        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Sign_Date_divCalendar.Visible = false;
            ImageButton1.Visible = false;
        }
    }
}