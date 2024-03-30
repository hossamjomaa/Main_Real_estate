using Antlr.Runtime.Misc;
using Main_Real_estate.English.Master_Panal;
using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.Services.Description;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Missing_Fields : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Deficiency_Detection", 0, "R");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!this.IsPostBack)
            {
                Ownership_All_List_BindData();
                Ownership_INFO_List_BindData();
                Ownership_Att_List_BindData();

                Building_All_List_BindData();
                Building_Info_List_BindData();
                Building_Att_List_BindData();

                Units_List_BindData();
            }
                
        }
        //-----------------------------------------------------------------------------------------
        protected void Ownership_All_List_BindData(string sortExpression = null)
        {
            string get_OwnerShip_Lists_Quari = "SELECT Owner_Ship_Id, Owner_Ship_AR_Name , owner_ship_Code , " +
                "Bond_NO , Parcel_Area , Street_Name , Street_NO , Bond_Date ,owner_ship_Certificate_Image , Property_Scheme_Image , " +
                "IF(Bond_NO !='', Bond_NO, '✘')R_Bond_NO , " +
                "IF(Parcel_Area !='', Parcel_Area, '✘')R_Parcel_Area , " +
                " IF(Bond_Date !='', Bond_Date, '✘')R_Bond_Date , " +
                " IF(Street_Name !='', Street_Name, '✘')R_Street_Name , " +
                " IF(Street_NO !='', Street_NO, '✘')R_Street_NO, " +
                " IF(owner_ship_Certificate_Image !='No File', owner_ship_Certificate_Image, '✘')R_owner_ship_Certificate_Image , " +
                "IF(Property_Scheme_Image !='No File', Property_Scheme_Image, '✘')R_Property_Scheme_Image " +
                "FROM owner_ship " +
                " where Bond_NO ='' or Parcel_Area = '' or Street_Name = '' or Street_NO = '' " +
                "or Bond_Date = '' or owner_ship_Certificate_Image ='No File' or Property_Scheme_Image = 'No File'";
            MySqlCommand get_OwnerShip_Lists_Cmd = new MySqlCommand(get_OwnerShip_Lists_Quari, _sqlCon);
            MySqlDataAdapter get_OwnerShip_Lists_Dt = new MySqlDataAdapter(get_OwnerShip_Lists_Cmd);
            get_OwnerShip_Lists_Cmd.Connection = _sqlCon;
            _sqlCon.Open();
            get_OwnerShip_Lists_Dt.SelectCommand = get_OwnerShip_Lists_Cmd;
            DataTable get_OwnerShip_Lists_DataTable = new DataTable();
            get_OwnerShip_Lists_Dt.Fill(get_OwnerShip_Lists_DataTable);
            Ownership_ALL.DataSource = get_OwnerShip_Lists_DataTable;
            Ownership_ALL.DataBind();
            _sqlCon.Close();

        }
        protected void Ownership_INFO_List_BindData(string sortExpression = null)
        {
                string get_OwnerShip_Lists_Quari = "SELECT Owner_Ship_Id , Owner_Ship_AR_Name , owner_ship_Code ,  Bond_NO , Parcel_Area , Street_Name , Street_NO , Bond_Date , " +
                "IF(Bond_NO !='', Bond_NO, '✘')R_Bond_NO , " +
                " IF(Parcel_Area !='', Parcel_Area, '✘')R_Parcel_Area , " +
                " IF(Bond_Date !='', Bond_Date, '✘')R_Bond_Date , " +
                "IF(Street_Name !='', Street_Name, '✘')R_Street_Name , " +
                " IF(Street_NO !='', Street_NO, '✘')R_Street_NO  " +
                "FROM owner_ship " +
                "where Bond_NO ='' or Parcel_Area = '' or Street_Name = '' or Street_NO = '' or Bond_Date = ''";
                MySqlCommand get_OwnerShip_Lists_Cmd = new MySqlCommand(get_OwnerShip_Lists_Quari, _sqlCon);
                MySqlDataAdapter get_OwnerShip_Lists_Dt = new MySqlDataAdapter(get_OwnerShip_Lists_Cmd);
                get_OwnerShip_Lists_Cmd.Connection = _sqlCon;
                _sqlCon.Open();
                get_OwnerShip_Lists_Dt.SelectCommand = get_OwnerShip_Lists_Cmd;
                DataTable get_OwnerShip_Lists_DataTable = new DataTable();
                get_OwnerShip_Lists_Dt.Fill(get_OwnerShip_Lists_DataTable);
                Ownership_Info_List.DataSource = get_OwnerShip_Lists_DataTable;
                Ownership_Info_List.DataBind();
            _sqlCon.Close();
        }
        protected void Ownership_Att_List_BindData(string sortExpression = null)
        {
            string get_OwnerShip_Lists_Quari = "SELECT Owner_Ship_Id, Owner_Ship_AR_Name , owner_ship_Code ,  owner_ship_Certificate_Image , Property_Scheme_Image , " +
                "IF(owner_ship_Certificate_Image !='No File', owner_ship_Certificate_Image, '✘')R_owner_ship_Certificate_Image , " +
                "IF(Property_Scheme_Image !='No File', Property_Scheme_Image, '✘')R_Property_Scheme_Image " +
                " FROM owner_ship " +
                "where owner_ship_Certificate_Image ='No File' or Property_Scheme_Image = 'No File'";
            MySqlCommand get_OwnerShip_Lists_Cmd = new MySqlCommand(get_OwnerShip_Lists_Quari, _sqlCon);
            MySqlDataAdapter get_OwnerShip_Lists_Dt = new MySqlDataAdapter(get_OwnerShip_Lists_Cmd);
            get_OwnerShip_Lists_Cmd.Connection = _sqlCon;
            _sqlCon.Open();
            get_OwnerShip_Lists_Dt.SelectCommand = get_OwnerShip_Lists_Cmd;
            DataTable get_OwnerShip_Lists_DataTable = new DataTable();
            get_OwnerShip_Lists_Dt.Fill(get_OwnerShip_Lists_DataTable);
            Ownership_Att_List.DataSource = get_OwnerShip_Lists_DataTable;
            Ownership_Att_List.DataBind();
            _sqlCon.Close();

        }
        
        protected void LinK_Owner_Ship_Arabic_Name_Click(object sender, EventArgs e)
        {
            DataTable Dt = new DataTable();
            _sqlCon.Open();
            MySqlCommand Cmd = new MySqlCommand("SELECT * FROM roles WHERE Role_ID = @ID", _sqlCon);
            MySqlDataAdapter Da = new MySqlDataAdapter(Cmd);
            Cmd.Parameters.AddWithValue("@ID", Session["Role"].ToString());
            Da.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                string[] Page = Dt.Rows[0]["Deficiency_Detection"].ToString().Split(',');
                if (Page[2] == "E") 
                {
                    Session["OW_Back"] = "3";
                    string id = (sender as LinkButton).CommandArgument;
                    Response.Redirect("Edit_Ownership.aspx?Id=" + id);
                }
            }
            _sqlCon.Close();


           
        }
        //-----------------------------------------------------------------------------------------
        protected void Building_All_List_BindData(string sortExpression = null)
        {

            string get_Building_Lists_Quari = "select  Building_Arabic_Name , Building_Id , " +
                "IF(Building_NO != '', Building_NO, '✘')Building_NO ,  " +
                "IF(Construction_Area != '', Construction_Area, '✘')Construction_Area , " +
                " IF(Maintenance_status != '', Maintenance_status, '✘')Maintenance_status , " +
                "IF(electricity_meter != '', electricity_meter, '✘')electricity_meter , " +
                "IF(Water_meter != '', Water_meter, '✘')Water_meter , " +
                "IF(Construction_Completion_Date != '', Construction_Completion_Date, '✘')Construction_Completion_Date , " +
                "IF(Building_Photo != 'No File', Building_Photo, '✘')Building_Photo , " +
                "IF(Entrance_Photo != 'No File', Entrance_Photo, '✘')Entrance_Photo , " +
                "IF(Building_Permit != 'No File', Building_Permit, '✘')Building_Permit , " +
                "IF(certificate_of_completion != 'No File', certificate_of_completion, '✘')certificate_of_completion , " +
                "IF(Map != 'No File', Map, '✘')Map , " +
                "IF(Plan != 'No File', Plan, '✘')Plan " +
                " from building where Active != '0'  " +
                "and ( Building_NO='' or   Construction_Area='' or   Maintenance_status='' or   electricity_meter='' or   Water_meter='' or  " +
                "Construction_Completion_Date='' or   Building_Photo='No File' or   Entrance_Photo='No File' or  Building_Permit='No File' or  " +
                " certificate_of_completion='No File'" +
                " or   Map='No File' or Plan='No File'  )";
            MySqlCommand get_Building_Lists_Cmd = new MySqlCommand(get_Building_Lists_Quari, _sqlCon);
            MySqlDataAdapter get_Building_Lists_Dt = new MySqlDataAdapter(get_Building_Lists_Cmd);
            get_Building_Lists_Cmd.Connection = _sqlCon;
            _sqlCon.Open();
            get_Building_Lists_Dt.SelectCommand = get_Building_Lists_Cmd;
            DataTable get_Building_Lists_DataTable = new DataTable();
            get_Building_Lists_Dt.Fill(get_Building_Lists_DataTable);
            Building_All_List.DataSource = get_Building_Lists_DataTable;
            Building_All_List.DataBind();
            _sqlCon.Close();

        }
        protected void Building_Info_List_BindData(string sortExpression = null)
        {

            string get_Building_Lists_Quari = "select  Building_Arabic_Name , Building_Id , " +
                "IF(Building_NO != '', Building_NO, '✘')Building_NO , " +
                "IF(Construction_Area != '', Construction_Area, '✘')Construction_Area , " +
                "IF(Maintenance_status != '', Maintenance_status, '✘')Maintenance_status , " +
                " IF(electricity_meter != '', electricity_meter, '✘')electricity_meter , " +
                "IF(Water_meter != '', Water_meter, '✘')Water_meter , " +
                "IF(Construction_Completion_Date != '', Construction_Completion_Date, '✘')Construction_Completion_Date " +
                "from building where Active != '0' and(Building_NO = '' or Construction_Area = '' or " +
                "Maintenance_status = '' or electricity_meter = '' or " +
                "Water_meter = '' or Construction_Completion_Date = '')";
            MySqlCommand get_Building_Lists_Cmd = new MySqlCommand(get_Building_Lists_Quari, _sqlCon);
            MySqlDataAdapter get_Building_Lists_Dt = new MySqlDataAdapter(get_Building_Lists_Cmd);
            get_Building_Lists_Cmd.Connection = _sqlCon;
            _sqlCon.Open();
            get_Building_Lists_Dt.SelectCommand = get_Building_Lists_Cmd;
            DataTable get_Building_Lists_DataTable = new DataTable();
            get_Building_Lists_Dt.Fill(get_Building_Lists_DataTable);
            Building_Info_List.DataSource = get_Building_Lists_DataTable;
            Building_Info_List.DataBind();
            _sqlCon.Close();

        }
        protected void Building_Att_List_BindData(string sortExpression = null)
        {

            string get_Building_Lists_Quari = "select  Building_Arabic_Name , Building_Id , Building_NO ," +
                "IF(Building_Photo != 'No File', Building_Photo, '✘')Building_Photo , " +
                " IF(Entrance_Photo != 'No File', Entrance_Photo, '✘')Entrance_Photo , " +
                "IF(Building_Permit != 'No File', Building_Permit, '✘')Building_Permit , " +
                "IF(certificate_of_completion != 'No File', certificate_of_completion, '✘')certificate_of_completion , " +
                "IF(Map != 'No File', Map, '✘')Map , " +
                "IF(Plan != 'No File', Plan, '✘')Plan " +
                "from building where Active != '0' " +
                " and ( Building_Photo='No File' or   Entrance_Photo='No File' or " +
                "Building_Permit='No File' or   certificate_of_completion='No File' or " +
                " Map='No File' or   Plan='No File')";
            MySqlCommand get_Building_Lists_Cmd = new MySqlCommand(get_Building_Lists_Quari, _sqlCon);
            MySqlDataAdapter get_Building_Lists_Dt = new MySqlDataAdapter(get_Building_Lists_Cmd);
            get_Building_Lists_Cmd.Connection = _sqlCon;
            _sqlCon.Open();
            get_Building_Lists_Dt.SelectCommand = get_Building_Lists_Cmd;
            DataTable get_Building_Lists_DataTable = new DataTable();
            get_Building_Lists_Dt.Fill(get_Building_Lists_DataTable);
            Building_Att_List.DataSource = get_Building_Lists_DataTable;
            Building_Att_List.DataBind();
            _sqlCon.Close();

        }
        protected void LinK_Building_Arabic_Name_Click(object sender, EventArgs e)
        {

            DataTable Dt = new DataTable();
            _sqlCon.Open();
            MySqlCommand Cmd = new MySqlCommand("SELECT * FROM roles WHERE Role_ID = @ID", _sqlCon);
            MySqlDataAdapter Da = new MySqlDataAdapter(Cmd);
            Cmd.Parameters.AddWithValue("@ID", Session["Role"].ToString());
            Da.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                string[] Page = Dt.Rows[0]["Deficiency_Detection"].ToString().Split(',');
                if (Page[2] == "E")
                {
                    Session["B_Back"] = "3";
                    string id = (sender as LinkButton).CommandArgument;
                    Response.Redirect("Edit_Building.aspx?Id=" + id);
                }
            }
            _sqlCon.Close();




            
        }
        //-----------------------------------------------------------------------------------------
        protected void Units_List_BindData(string sortExpression = null)
        {
            try
            {
                string get_Units_Lists_Quari = "select  Unit_ID , Unit_Number , " +
                    "IF(current_situation != '', current_situation, '✘')current_situation , " +
                    " IF(Oreedo_Number != '', Oreedo_Number, '✘')Oreedo_Number , " +
                    "IF(Electricityt_Number != '', Electricityt_Number, '✘')Electricityt_Number , " +
                    " IF(Water_Number != '', Water_Number, '✘')Water_Number , " +
                    "IF(virtual_Value != '0', virtual_Value, '✘')virtual_Value " +
                    "from units where Half != '1' and ( current_situation = '' or Oreedo_Number = '' or " +
                    "Electricityt_Number = '' or Water_Number = '' or virtual_Value = '') ";
                MySqlCommand get_Units_Lists_Cmd = new MySqlCommand(get_Units_Lists_Quari, _sqlCon);
                MySqlDataAdapter get_Units_Lists_Dt = new MySqlDataAdapter(get_Units_Lists_Cmd);
                get_Units_Lists_Cmd.Connection = _sqlCon;
                _sqlCon.Open();
                get_Units_Lists_Dt.SelectCommand = get_Units_Lists_Cmd;
                DataTable get_Units_Lists_DataTable = new DataTable();
                get_Units_Lists_Dt.Fill(get_Units_Lists_DataTable);
                Unit_List.DataSource = get_Units_Lists_DataTable;
                Unit_List.DataBind();
                _sqlCon.Close();
            }
            catch (Exception ex)
            {
            }
        }
        protected void LinK_Unit_Arabic_Name_Click(object sender, EventArgs e)
        {
            DataTable Dt = new DataTable();
            _sqlCon.Open();
            MySqlCommand Cmd = new MySqlCommand("SELECT * FROM roles WHERE Role_ID = @ID", _sqlCon);
            MySqlDataAdapter Da = new MySqlDataAdapter(Cmd);
            Cmd.Parameters.AddWithValue("@ID", Session["Role"].ToString());
            Da.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                string[] Page = Dt.Rows[0]["Deficiency_Detection"].ToString().Split(',');
                if (Page[2] == "E")
                {
                    Session["U_Back"] = "3";
                    string id = (sender as LinkButton).CommandArgument;
                    Response.Redirect("Edit_Units.aspx?Id=" + id);
                }
            }
            _sqlCon.Close();




            
        }
        //-----------------------------------------------------------------------------------------
        protected void A_1_ServerClick(object sender, EventArgs e)
        {
            OS_Arcive.Visible = true; B_Arcive.Visible=false; U_Arcive.Visible=false;
        }
        protected void A_2_ServerClick(object sender, EventArgs e)
        {
            OS_Arcive.Visible = false; B_Arcive.Visible = true; U_Arcive.Visible = false;
        }
        protected void A_3_ServerClick(object sender, EventArgs e)
        {
            OS_Arcive.Visible = false; B_Arcive.Visible = false; U_Arcive.Visible = true;
        }
        protected void A_4_ServerClick(object sender, EventArgs e)
        {
            OS_Arcive.Visible = true; B_Arcive.Visible = true; U_Arcive.Visible = true;
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filter_DropDownList.SelectedValue == "2")
            {
                Ownership_Info_Div.Visible= true; Ownership_Att_Div.Visible = false; Ownership_ALL_Div.Visible = false;
                Building_Info_Div.Visible= true; Building_Att_Div.Visible= false; Building_All_Div.Visible = false;
            }
            else if (Filter_DropDownList.SelectedValue == "3")
            {
                Ownership_Info_Div.Visible = false; Ownership_Att_Div.Visible = true; Ownership_ALL_Div.Visible = false;
                Building_Info_Div.Visible = false; Building_Att_Div.Visible = true; Building_All_Div.Visible = false;

                
            }
            else if (Filter_DropDownList.SelectedValue == "1")
            {
                Ownership_Info_Div.Visible = false; Ownership_Att_Div.Visible = false; Ownership_ALL_Div.Visible = true;
                Building_Info_Div.Visible = false; Building_Att_Div.Visible = false; Building_All_Div.Visible = true;

            }
        }

       
    }
}