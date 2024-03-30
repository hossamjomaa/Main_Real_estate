using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class lists : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ownership_List_BindData();
                Building_List_BindData();
                Units_List_BindData();
            }
        }
        //************************ OwnerShip Lists ********************************************************
        protected void Ownership_List_BindData(string sortExpression = null)
        {
            try
            {
                string get_OwnerShip_Lists_Quari = "select Owner_Ship_Id , Owner_Ship_AR_Name , owner_ship_Code ," +
                    " IF(Bond_NO != '', Bond_NO, '✔')Bond_NO ,  " +
                    " IF(Parcel_Area != '', Parcel_Area, '✔')Parcel_Area , " +
                    " IF(Street_Name != '', Street_Name, '✔')Street_Name , " +
                    "IF(Street_NO != '', Street_NO, '✔')Street_NO , " +
                    "IF(owner_ship_Certificate_Image != 'No File', owner_ship_Certificate_Image, '✔')Certificate , " +
                    " IF(Property_Scheme_Image != 'No File', Property_Scheme_Image, '✔')Scheme  from owner_ship";




                MySqlCommand get_OwnerShip_Lists_Cmd = new MySqlCommand(get_OwnerShip_Lists_Quari, _sqlCon);
                MySqlDataAdapter get_OwnerShip_Lists_Dt = new MySqlDataAdapter(get_OwnerShip_Lists_Cmd);
                get_OwnerShip_Lists_Cmd.Connection = _sqlCon;
                _sqlCon.Open();
                get_OwnerShip_Lists_Dt.SelectCommand = get_OwnerShip_Lists_Cmd;
                DataTable get_OwnerShip_Lists_DataTable = new DataTable();
                get_OwnerShip_Lists_Dt.Fill(get_OwnerShip_Lists_DataTable);
                Ownership_Repeater.DataSource = get_OwnerShip_Lists_DataTable;
                Ownership_Repeater.DataBind();
                _sqlCon.Close();
            }
            catch (Exception ex)
            {
            }
        }

        protected void Ownership_Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem ri in Ownership_Repeater.Items)
            {
                Label lbl_Bond_NO = ri.FindControl("lbl_Bond_NO") as Label;
                Label lbl_owner_Owner_Id = ri.FindControl("lbl_owner_Owner_Id") as Label;
                Label lbl_Parcel_Area = ri.FindControl("lbl_Parcel_Area") as Label;
                Label lbl_Street_Name = ri.FindControl("lbl_Street_Name") as Label;
                Label lbl_Street_NO = ri.FindControl("lbl_Street_NO") as Label;
                Label lbl_Certificate = ri.FindControl("lbl_owner_ship_Certificate") as Label;
                Label lbl_Scheme = ri.FindControl("lbl_Property_Scheme") as Label;
                HtmlControl Ownership_Div = ri.FindControl("Ownership_Div") as HtmlControl;

                if(lbl_Bond_NO.Text != "رقم السند |" && lbl_owner_Owner_Id.Text != "اسم المالك |" && lbl_Parcel_Area.Text != "مساحة الأرض |"
                    && lbl_Street_Name.Text != "اسم الشارع |" && lbl_Street_NO.Text != "رقم الشارع |" && lbl_Certificate.Text != " (مرفق) سند الملكية |" && lbl_Scheme.Text != "(مرفق) المخطط |")
                {
                    Ownership_Div.Visible = false;
                }


                if(Filter_DropDownList.SelectedValue == "2")
                {
                    lbl_Bond_NO.Visible= true; lbl_owner_Owner_Id.Visible= true; 
                    lbl_Parcel_Area.Visible= true; lbl_Street_Name.Visible= true; 
                    lbl_Street_NO.Visible= true;

                    lbl_Scheme.Visible= false; lbl_Certificate.Visible= false;  
                }
                else if (Filter_DropDownList.SelectedValue == "3")
                {
                    lbl_Bond_NO.Visible = false; lbl_owner_Owner_Id.Visible = false;
                    lbl_Parcel_Area.Visible = false; lbl_Street_Name.Visible = false;
                    lbl_Street_NO.Visible = false;

                    lbl_Scheme.Visible = true; lbl_Certificate.Visible = true;
                }
            }
        }

        protected void Edit_Ownership(object sender, EventArgs e)
        {

            Session["OW_Lists"] = "1";

            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Edit_Ownership.aspx?Id=" + id);
        }

        //************************ Building Lists ********************************************************

        protected void Building_List_BindData(string sortExpression = null)
        {
            try
            {
                string get_Building_Lists_Quari = "select  Building_Arabic_Name , Building_Id , " +
                    "IF(Building_NO != '', Building_NO, '✔')Building_NO ,  " +
                    "IF(Construction_Area != '', Construction_Area, '✔')Construction_Area , " +
                    " IF(Maintenance_status != '', Maintenance_status, '✔')Maintenance_status , " +
                    "IF(electricity_meter != '', electricity_meter, '✔')electricity_meter , " +
                    "IF(Water_meter != '', Water_meter, '✔')Water_meter , " +
                    "IF(Construction_Completion_Date != '', Construction_Completion_Date, '✔')Construction_Completion_Date , " +
                    "IF(Building_Photo != 'No File', '', '✔')Building_Photo , " +
                    "IF(Entrance_Photo != 'No File', '', '✔')Entrance_Photo , " +
                    " IF(Statement != 'No File', '', '✔')Statement , " +
                    "IF(Building_Permit != 'No File', '', '✔')Building_Permit , " +
                    "IF(certificate_of_completion != 'No File', '', '✔')certificate_of_completion , " +
                    "IF(Map != 'No File', '', '✔')Map , " +
                    "IF(Plan != 'No File', '', '✔')Plan " +
                    " from building where Active != '0' and Delete_Active !='1'";




                MySqlCommand get_Building_Lists_Cmd = new MySqlCommand(get_Building_Lists_Quari, _sqlCon);
                MySqlDataAdapter get_Building_Lists_Dt = new MySqlDataAdapter(get_Building_Lists_Cmd);
                get_Building_Lists_Cmd.Connection = _sqlCon;
                _sqlCon.Open();
                get_Building_Lists_Dt.SelectCommand = get_Building_Lists_Cmd;
                DataTable get_Building_Lists_DataTable = new DataTable();
                get_Building_Lists_Dt.Fill(get_Building_Lists_DataTable);
                Building_Repeater.DataSource = get_Building_Lists_DataTable;
                Building_Repeater.DataBind();
                _sqlCon.Close();
            }
            catch (Exception ex)
            {
            }
        }

        protected void Building_Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem ri in Building_Repeater.Items)
            {
                Label lbl_Building_NO = ri.FindControl("lbl_Building_NO") as Label;
                Label lbl_Construction_Area = ri.FindControl("lbl_Construction_Area") as Label;
                Label lbl_Maintenance_status = ri.FindControl("lbl_Maintenance_status") as Label;
                Label lbl_electricity_meter = ri.FindControl("lbl_electricity_meter") as Label;
                Label lbl_Water_meter = ri.FindControl("lbl_Water_meter") as Label;
                Label lbl_Construction_Completion_Date = ri.FindControl("lbl_Construction_Completion_Date") as Label;
                Label lbl_Building_Photo = ri.FindControl("lbl_Building_Photo") as Label;
                Label lbl_Entrance_Photo = ri.FindControl("lbl_Entrance_Photo") as Label;
                Label lbl_Statement = ri.FindControl("lbl_Statement") as Label;
                Label lbl_Building_Permit = ri.FindControl("lbl_Building_Permit") as Label;
                Label lbl_certificate_of_completion = ri.FindControl("lbl_certificate_of_completion") as Label;
                Label lbl_Map = ri.FindControl("lbl_Map") as Label;
                Label lbl_Plan = ri.FindControl("lbl_Plan") as Label;



                HtmlControl Building_Div = ri.FindControl("Building_Div") as HtmlControl;

                if (lbl_Building_NO.Text != "رقم البناء |" && lbl_Construction_Area.Text != "مساحة البناء |" && lbl_Maintenance_status.Text != "وضع الصيانة |"
                    && lbl_electricity_meter.Text != "عداد الكهرباء |" && lbl_Water_meter.Text != "عداد المياه |" && lbl_Construction_Completion_Date.Text != "تاريخ إتمام البناء |" &&
                    lbl_Building_Photo.Text != "(مرفق) صورة البناء |" && lbl_Entrance_Photo.Text != "(مرفق) صورة المدخل |" && lbl_Statement.Text != "(مرفق) الإفادة |"
                    && lbl_Building_Permit.Text != "(مرفق) رخصة البناء |" && lbl_certificate_of_completion.Text != "(مرفق) شهادة إتمام البناء |" && lbl_Map.Text != "(مرفق) الخرائط |" &&
                    lbl_Plan.Text != "(مرفق) المسقط الأفقي |")
                {
                    Building_Div.Visible = false;
                }


                if (Filter_DropDownList.SelectedValue == "2")
                {
                    lbl_Building_NO.Visible = true; lbl_Construction_Area.Visible = true;
                    lbl_Maintenance_status.Visible = true; lbl_electricity_meter.Visible = true;
                    lbl_Water_meter.Visible = true; lbl_Construction_Completion_Date.Visible = true;

                    lbl_Building_Photo.Visible = false; lbl_Entrance_Photo.Visible = false;
                    lbl_Statement.Visible = false; lbl_Building_Permit.Visible = false;
                    lbl_certificate_of_completion.Visible = false; lbl_Map.Visible = false;
                    lbl_Plan.Visible = false; 
                }
                else if (Filter_DropDownList.SelectedValue == "3")
                {
                    lbl_Building_NO.Visible = false; lbl_Construction_Area.Visible = false;
                    lbl_Maintenance_status.Visible = false; lbl_electricity_meter.Visible = false;
                    lbl_Water_meter.Visible = false; lbl_Construction_Completion_Date.Visible = false;

                    lbl_Building_Photo.Visible = true; lbl_Entrance_Photo.Visible = true;
                    lbl_Statement.Visible = true; lbl_Building_Permit.Visible = true;
                    lbl_certificate_of_completion.Visible = true; lbl_Map.Visible = true;
                    lbl_Plan.Visible = true;
                }
            }
        }

        protected void Edit_Building(object sender, EventArgs e)
        {

            Session["B_Lists"] = "1";

            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Edit_Building.aspx?Id=" + id);
        }

        //************************ Units Lists ********************************************************

        protected void Units_List_BindData(string sortExpression = null)
        {
            try
            {
                string get_Units_Lists_Quari = "select  Unit_ID , Unit_Number , " +
                    "IF(current_situation != '', current_situation, '✔')current_situation , " +
                    " IF(Oreedo_Number != '', Oreedo_Number, '✔')Oreedo_Number , " +
                    "IF(Electricityt_Number != '', Electricityt_Number, '✔')Electricityt_Number , " +
                    " IF(Water_Number != '', Water_Number, '✔')Water_Number , " +
                    "IF(virtual_Value != '', virtual_Value, '✔')virtual_Value " +
                    "from units where Half != '1' and Delete_Active !='1'";




                MySqlCommand get_Units_Lists_Cmd = new MySqlCommand(get_Units_Lists_Quari, _sqlCon);
                MySqlDataAdapter get_Units_Lists_Dt = new MySqlDataAdapter(get_Units_Lists_Cmd);
                get_Units_Lists_Cmd.Connection = _sqlCon;
                _sqlCon.Open();
                get_Units_Lists_Dt.SelectCommand = get_Units_Lists_Cmd;
                DataTable get_Units_Lists_DataTable = new DataTable();
                get_Units_Lists_Dt.Fill(get_Units_Lists_DataTable);
                Units_Repeater.DataSource = get_Units_Lists_DataTable;
                Units_Repeater.DataBind();
                _sqlCon.Close();
            }
            catch (Exception ex)
            {
            }
        }

        protected void Units_Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem ri in Units_Repeater.Items)
            {
                Label lbl_current_situation = ri.FindControl("lbl_current_situation") as Label;
                Label lbl_Oreedo_Number = ri.FindControl("lbl_Oreedo_Number") as Label;
                Label lbl_Electricityt_Number = ri.FindControl("lbl_Electricityt_Number") as Label;
                Label lbl_Water_Number = ri.FindControl("lbl_Water_Number") as Label;
                Label lbl_virtual_Value = ri.FindControl("lbl_virtual_Value") as Label;
                HtmlControl Unit_Div = ri.FindControl("Unit_Div") as HtmlControl;

                if (lbl_current_situation.Text != "الوضع الحالي |" && lbl_Oreedo_Number.Text != "رقم اوريدو |" && lbl_Electricityt_Number.Text != "عداد الكهرباء |"
                    && lbl_Water_Number.Text != "عداد المياه |" && lbl_virtual_Value.Text != "القيمة الإفتراضية |")
                {
                    Unit_Div.Visible = false;
                }


                if (Filter_DropDownList.SelectedValue == "2")
                {
                    lbl_current_situation.Visible = true; lbl_Oreedo_Number.Visible = true;
                    lbl_Electricityt_Number.Visible = true; lbl_Water_Number.Visible = true;
                    lbl_virtual_Value.Visible = true; Unit_Div.Visible = true;
                }
                else if (Filter_DropDownList.SelectedValue == "3")
                {
                    lbl_current_situation.Visible = false; lbl_Oreedo_Number.Visible = false;
                    lbl_Electricityt_Number.Visible = false; lbl_Water_Number.Visible = false;
                    lbl_virtual_Value.Visible = false; Unit_Div.Visible = false;
                }
            }
        }

        protected void Edit_Units(object sender, EventArgs e)
        {

            Session["U_Lists"] = "1";

            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Edit_Units.aspx?Id=" + id);
        }

        protected void A_1_ServerClick(object sender, EventArgs e)
        {
            OS.Visible= true; B.Visible= false; U.Visible= false;
        }

        protected void A_2_ServerClick(object sender, EventArgs e)
        {
            OS.Visible = false; B.Visible = true; U.Visible = false;
        }

        protected void A_3_ServerClick(object sender, EventArgs e)
        {
            OS.Visible = false; B.Visible = false; U.Visible = true;
        }

        protected void A_4_ServerClick(object sender, EventArgs e)
        {
            OS.Visible = true; B.Visible = true; U.Visible = true;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ownership_List_BindData();
            Building_List_BindData();
            Units_List_BindData();
        }
    }
}