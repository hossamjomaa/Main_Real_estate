using Main_Real_estate.English.Master_Panal;
using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using Syncfusion.JavaScript;
using System;
using System.Data;
using System.Diagnostics.Contracts;
using System.Security.Policy;
using System.Web.Services.Description;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Test_4 : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] == "1") { lbl_titel_Ownership_List.Text = "كشف الملكيات ";  }
            else if (Request.QueryString["Id"] == "2"){ lbl_titel_Ownership_List.Text = "عمليات الملكيات "; }
            else { lbl_titel_Ownership_List.Text = "القيم العقارية "; }

            if (!IsPostBack)
            {

                //Get Zone Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM Zone", _sqlCon, Zone_Name_DropDownList, "zone_arabic_name", "zone_Id");
                Zone_Name_DropDownList.Items.Insert(0, "..... الكل .....");

                //Get Ownershi_Code_DropDownList
                Helper.LoadDropDownList("SELECT * FROM owner_ship where Active!='1' ", _sqlCon, Ownershi_Code_DropDownList, "owner_ship_Code", "Owner_Ship_Id");
                Ownershi_Code_DropDownList.Items.Insert(0, "..... الكل .....");

                //Get Ownershi_Name_DropDownList
                Helper.LoadDropDownList("SELECT * FROM owner_ship where Active!='1'", _sqlCon, Ownershi_Name_DropDownList, "Owner_Ship_AR_Name", "Owner_Ship_Id");
                Ownershi_Name_DropDownList.Items.Insert(0, "..... الكل .....");

                Quari.Text = "";

                Ownership_List_BindData(); 
                Building_List_BindData();
                Units_List_BindData();
            }
        }
        protected void Ownership_List_BindData(string sortExpression = null)
        {
            using (MySqlCommand OwnershipDetailsCmd = new MySqlCommand("OwnerShip_Test_4", _sqlCon))
            {
                OwnershipDetailsCmd.CommandType = CommandType.StoredProcedure;
                OwnershipDetailsCmd.Parameters.AddWithValue("@OS_N", Quari.Text);
                OwnershipDetailsCmd.Parameters.AddWithValue("@OS_Code", Quari.Text);
                OwnershipDetailsCmd.Parameters.AddWithValue("@Z_N", Quari.Text);
                MySqlDataAdapter OwnershipDetailsSda = new MySqlDataAdapter(OwnershipDetailsCmd);

                DataTable OwnershipDetailsDt = new DataTable();
                OwnershipDetailsSda.Fill(OwnershipDetailsDt);
                OwnershipDetailsCmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                OwnershipDetailsSda.Fill(dt);
                ownership_List.DataSource = dt;
                ownership_List.DataBind();
                _sqlCon.Close();
            }
        }
        protected void Building_List_BindData()
        {
            foreach (RepeaterItem item in ownership_List.Items)
            {
                Repeater building_List = item.FindControl("building_List") as Repeater;
                Label lbl_Owner_Ship_Id = item.FindControl("lbl_Owner_Ship_Id") as Label;


                using (MySqlCommand bulidingDetailsCmd = new MySqlCommand("Building_List_In_Ownership_Details", _sqlCon))
                {
                    bulidingDetailsCmd.CommandType = CommandType.StoredProcedure;
                    bulidingDetailsCmd.Parameters.AddWithValue("@Id", lbl_Owner_Ship_Id.Text);
                    MySqlDataAdapter bulidingDetailsSda = new MySqlDataAdapter(bulidingDetailsCmd);

                    DataTable bulidingDetailsDt = new DataTable();
                    bulidingDetailsSda.Fill(bulidingDetailsDt);
                    bulidingDetailsCmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    bulidingDetailsSda.Fill(dt);
                    building_List.DataSource = dt;
                    building_List.DataBind();
                    _sqlCon.Close();
                }
            }


        }
        protected void Units_List_BindData()
        {
            foreach (RepeaterItem item in ownership_List.Items)
            {
                Repeater building_List = item.FindControl("building_List") as Repeater;
                foreach (RepeaterItem Building_item in building_List.Items)
                {
                    Repeater Units_List = Building_item.FindControl("Units_List") as Repeater;
                    Label lbl_Building_Id = Building_item.FindControl("lbl_Building_Id") as Label;
                    using (MySqlCommand unitDetailsCmd = new MySqlCommand("Unit_List_In_Building_Details", _sqlCon))
                    {
                        unitDetailsCmd.CommandType = CommandType.StoredProcedure;
                        unitDetailsCmd.Parameters.AddWithValue("@Id", lbl_Building_Id.Text);
                        MySqlDataAdapter unitDetailsSda = new MySqlDataAdapter(unitDetailsCmd);

                        DataTable unitDetailsDt = new DataTable();
                        unitDetailsSda.Fill(unitDetailsDt);
                        unitDetailsCmd.CommandType = CommandType.StoredProcedure;
                        DataTable dt = new DataTable();
                        unitDetailsSda.Fill(dt);
                        Units_List.DataSource = dt;
                        Units_List.DataBind();
                    }

                }

            }
        }
        protected void Zone_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get Ownershi_Code_DropDownList
            Helper.LoadDropDownList("SELECT * FROM owner_ship where Active!='1' ", _sqlCon, Ownershi_Code_DropDownList, "owner_ship_Code", "Owner_Ship_Id");
            Ownershi_Code_DropDownList.Items.Insert(0, "..... الكل .....");
            //Get Ownershi_Name_DropDownList
            Helper.LoadDropDownList("SELECT * FROM owner_ship where Active!='1'", _sqlCon, Ownershi_Name_DropDownList, "Owner_Ship_AR_Name", "Owner_Ship_Id");
            Ownershi_Name_DropDownList.Items.Insert(0, "..... الكل .....");
            if (Zone_Name_DropDownList.SelectedItem.Text != "..... الكل .....") { Quari.Text = Zone_Name_DropDownList.SelectedItem.Text.Trim(); }
            else  { Quari.Text = "";  }
            Ownership_List_BindData(); Building_List_BindData(); Units_List_BindData();
        }
        protected void Ownershi_Code_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get Zone Name DropDownList
            Helper.LoadDropDownList("SELECT * FROM Zone", _sqlCon, Zone_Name_DropDownList, "zone_arabic_name", "zone_Id");
            Zone_Name_DropDownList.Items.Insert(0, "..... الكل .....");
            //Get Ownershi_Name_DropDownList
            Helper.LoadDropDownList("SELECT * FROM owner_ship where Active!='1'", _sqlCon, Ownershi_Name_DropDownList, "Owner_Ship_AR_Name", "Owner_Ship_Id");
            Ownershi_Name_DropDownList.Items.Insert(0, "..... الكل .....");
            if (Ownershi_Code_DropDownList.SelectedItem.Text != "..... الكل .....") { Quari.Text = Ownershi_Code_DropDownList.SelectedItem.Text.Trim(); ; }
            else { Quari.Text = ""; }
            Ownership_List_BindData();  Building_List_BindData(); Units_List_BindData();
        }
        protected void Ownershi_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get Zone Name DropDownList
            Helper.LoadDropDownList("SELECT * FROM Zone", _sqlCon, Zone_Name_DropDownList, "zone_arabic_name", "zone_Id");
            Zone_Name_DropDownList.Items.Insert(0, "..... الكل .....");
            //Get Ownershi_Code_DropDownList
            Helper.LoadDropDownList("SELECT * FROM owner_ship where Active!='1'", _sqlCon, Ownershi_Code_DropDownList, "owner_ship_Code", "Owner_Ship_Id");
            Ownershi_Code_DropDownList.Items.Insert(0, "..... الكل .....");
            if (Ownershi_Name_DropDownList.SelectedItem.Text != "..... الكل .....") { Quari.Text = Ownershi_Name_DropDownList.SelectedItem.Text.Trim(); }
            else { Quari.Text = ""; }
            Ownership_List_BindData();  Building_List_BindData(); Units_List_BindData();
        }


        protected void Edit_Ownership(object sender, EventArgs e)
        {
            Session["OW_Back"] = "2";
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Edit_Ownership.aspx?Id=" + id);
        }

        protected void Edit_Building(object sender, EventArgs e)
        {
            Session["B_Back"] = "2";
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Edit_Building.aspx?Id=" + id);
        }

        protected void Edit_Unit(object sender, EventArgs e)
        {
            Session["U_Back"] = "2";
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Edit_Units.aspx?Id=" + id);
        }


        protected void Add_Building(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Add_Building.aspx?Id=" + id);
        }

        protected void Add_Unit(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Add_Unit.aspx?Id=" + id);
        }







        protected void ownership_List_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (Request.QueryString["Id"] == "1")
            {
                if (e.Item.ItemType == ListItemType.Header)
                {
                    var H_Add = e.Item.FindControl("H_Add") as HtmlTableCell;
                    var H_Edit = e.Item.FindControl("H_Edit") as HtmlTableCell;


                    var H_Lan_Value = e.Item.FindControl("H_Lan_Value") as HtmlTableCell;

                    var H_Onee = e.Item.FindControl("H_Onee") as HtmlTableCell;
                    var H_Two = e.Item.FindControl("H_Two") as HtmlTableCell;
                    var H_Three = e.Item.FindControl("H_Three") as HtmlTableCell;
                    var H_Four = e.Item.FindControl("H_Four") as HtmlTableCell;
                    var H_Five = e.Item.FindControl("H_Five") as HtmlTableCell;
                    var H_six = e.Item.FindControl("H_six") as HtmlTableCell;
                    var H_seven = e.Item.FindControl("H_seven") as HtmlTableCell;
                    var H_Eghit = e.Item.FindControl("H_Eghit") as HtmlTableCell;
                    var H_Nine = e.Item.FindControl("H_Nine") as HtmlTableCell;

                    H_Add.Visible = false; H_Edit.Visible= false; 
                    
                    H_Lan_Value.Visible= false;
                    H_Onee.Visible = false;
                    H_Two.Visible = false;
                    H_Three.Visible = false;
                    H_Four.Visible = false;
                    H_Five.Visible = false;
                    H_six.Visible = false;
                    H_seven.Visible = false;
                    H_Eghit.Visible = false;
                    H_Nine.Visible = false;

                }
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    var B_Add = e.Item.FindControl("B_Add") as HtmlTableCell;
                    var B_Edit = e.Item.FindControl("B_Edit") as HtmlTableCell;
                    var B_Lan_Value = e.Item.FindControl("B_Lan_Value") as HtmlTableCell;


                    var B_Onee = e.Item.FindControl("B_Onee") as HtmlTableCell;
                    var B_Two = e.Item.FindControl("B_Two") as HtmlTableCell;
                    var B_Three = e.Item.FindControl("B_Three") as HtmlTableCell;
                    var B_Four = e.Item.FindControl("B_Four") as HtmlTableCell;
                    var B_Five = e.Item.FindControl("B_Five") as HtmlTableCell;
                    var B_six = e.Item.FindControl("B_six") as HtmlTableCell;
                    var B_seven = e.Item.FindControl("B_seven") as HtmlTableCell;
                    var B_Eghit = e.Item.FindControl("B_Eghit") as HtmlTableCell;
                    var B_Nine = e.Item.FindControl("B_Nine") as HtmlTableCell;

                    B_Add.Visible = false; B_Edit.Visible = false; 
                    
                    B_Lan_Value.Visible = false;
                    B_Onee.Visible = false;
                    B_Two.Visible = false;
                    B_Three.Visible = false;
                    B_Four.Visible = false;
                    B_Five.Visible = false;
                    B_six.Visible = false;
                    B_seven.Visible = false;
                    B_Eghit.Visible = false;
                    B_Nine.Visible = false;
                }
            }
            else if (Request.QueryString["Id"] == "2")
            {
                if (e.Item.ItemType == ListItemType.Header)
                {
                    var H_Add = e.Item.FindControl("H_Add") as HtmlTableCell;
                    var H_Edit = e.Item.FindControl("H_Edit") as HtmlTableCell;
                    var H_Lan_Value = e.Item.FindControl("H_Lan_Value") as HtmlTableCell;

                    var H_Onee = e.Item.FindControl("H_Onee") as HtmlTableCell;
                    var H_Two = e.Item.FindControl("H_Two") as HtmlTableCell;
                    var H_Three = e.Item.FindControl("H_Three") as HtmlTableCell;
                    var H_Four = e.Item.FindControl("H_Four") as HtmlTableCell;
                    var H_Five = e.Item.FindControl("H_Five") as HtmlTableCell;
                    var H_six = e.Item.FindControl("H_six") as HtmlTableCell;
                    var H_seven = e.Item.FindControl("H_seven") as HtmlTableCell;
                    var H_Eghit = e.Item.FindControl("H_Eghit") as HtmlTableCell;
                    var H_Nine = e.Item.FindControl("H_Nine") as HtmlTableCell;

                    H_Add.Visible = true; H_Edit.Visible = true; 
                    
                    H_Lan_Value.Visible = false;
                    H_Onee.Visible = false;
                    H_Two.Visible = false;
                    H_Three.Visible = false;
                    H_Four.Visible = false;
                    H_Five.Visible = false;
                    H_six.Visible = false;
                    H_seven.Visible = false;
                    H_Eghit.Visible = false;
                    H_Nine.Visible = false;

                }
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    var B_Add = e.Item.FindControl("B_Add") as HtmlTableCell;
                    var B_Edit = e.Item.FindControl("B_Edit") as HtmlTableCell;
                    var B_Lan_Value = e.Item.FindControl("B_Lan_Value") as HtmlTableCell;

                    var B_Onee = e.Item.FindControl("B_Onee") as HtmlTableCell;
                    var B_Two = e.Item.FindControl("B_Two") as HtmlTableCell;
                    var B_Three = e.Item.FindControl("B_Three") as HtmlTableCell;
                    var B_Four = e.Item.FindControl("B_Four") as HtmlTableCell;
                    var B_Five = e.Item.FindControl("B_Five") as HtmlTableCell;
                    var B_six = e.Item.FindControl("B_six") as HtmlTableCell;
                    var B_seven = e.Item.FindControl("B_seven") as HtmlTableCell;
                    var B_Eghit = e.Item.FindControl("B_Eghit") as HtmlTableCell;
                    var B_Nine = e.Item.FindControl("B_Nine") as HtmlTableCell;

                    B_Add.Visible = true; B_Edit.Visible = true; 
                    B_Lan_Value.Visible = false;
                    B_Onee.Visible = false;
                    B_Two.Visible = false;
                    B_Three.Visible = false;
                    B_Four.Visible = false;
                    B_Five.Visible = false;
                    B_six.Visible = false;
                    B_seven.Visible = false;
                    B_Eghit.Visible = false;
                    B_Nine.Visible = false;
                }
            }
            else
            {
                if (e.Item.ItemType == ListItemType.Header)
                {
                    var H_Add = e.Item.FindControl("H_Add") as HtmlTableCell;
                    var H_Edit = e.Item.FindControl("H_Edit") as HtmlTableCell;
                    var H_Lan_Value = e.Item.FindControl("H_Lan_Value") as HtmlTableCell;

                    var H_Onee = e.Item.FindControl("H_Onee") as HtmlTableCell;
                    var H_Two = e.Item.FindControl("H_Two") as HtmlTableCell;
                    var H_Three = e.Item.FindControl("H_Three") as HtmlTableCell;
                    var H_Four = e.Item.FindControl("H_Four") as HtmlTableCell;
                    var H_Five = e.Item.FindControl("H_Five") as HtmlTableCell;
                    var H_six = e.Item.FindControl("H_six") as HtmlTableCell;
                    var H_seven = e.Item.FindControl("H_seven") as HtmlTableCell;
                    var H_Eghit = e.Item.FindControl("H_Eghit") as HtmlTableCell;
                    var H_Nine = e.Item.FindControl("H_Nine") as HtmlTableCell;

                    H_Add.Visible = false; H_Edit.Visible = false; 
                    
                    H_Lan_Value.Visible = true;
                    H_Onee.Visible = true;
                    H_Two.Visible = true;
                    H_Three.Visible = true;
                    H_Four.Visible = true;
                    H_Five.Visible = true;
                    H_six.Visible = true;
                    H_seven.Visible = true;
                    H_Eghit.Visible = true;
                    H_Nine.Visible = true;

                }
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    var B_Add = e.Item.FindControl("B_Add") as HtmlTableCell;
                    var B_Edit = e.Item.FindControl("B_Edit") as HtmlTableCell;
                    var B_Lan_Value = e.Item.FindControl("B_Lan_Value") as HtmlTableCell;

                    var B_Onee = e.Item.FindControl("B_Onee") as HtmlTableCell;
                    var B_Two = e.Item.FindControl("B_Two") as HtmlTableCell;
                    var B_Three = e.Item.FindControl("B_Three") as HtmlTableCell;
                    var B_Four = e.Item.FindControl("B_Four") as HtmlTableCell;
                    var B_Five = e.Item.FindControl("B_Five") as HtmlTableCell;
                    var B_six = e.Item.FindControl("B_six") as HtmlTableCell;
                    var B_seven = e.Item.FindControl("B_seven") as HtmlTableCell;
                    var B_Eghit = e.Item.FindControl("B_Eghit") as HtmlTableCell;
                    var B_Nine = e.Item.FindControl("B_Nine") as HtmlTableCell;

                    B_Add.Visible = false; B_Edit.Visible = false; 
                    
                    
                    B_Lan_Value.Visible = true;
                    B_Onee.Visible = true;
                    B_Two.Visible = true;
                    B_Three.Visible = true;
                    B_Four.Visible = true;
                    B_Five.Visible = true;
                    B_six.Visible = true;
                    B_seven.Visible = true;
                    B_Eghit.Visible = true;
                    B_Nine.Visible = true;
                }
            }

            
        }






        protected void building_List_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem item in ownership_List.Items)
            {
                Repeater building_List = item.FindControl("building_List") as Repeater;
                foreach (RepeaterItem Building_item in building_List.Items)
                {
                    Label lbl_Building_Image = Building_item.FindControl("lbl_Building_Image") as Label;
                    Image Building_Image = Building_item.FindControl("Building_Image") as Image;

                    if (lbl_Building_Image.Text == "No File")
                    {
                        Building_Image.Visible= false;
                    }
                    else
                    {
                        Building_Image.Visible= true;
                    }
                }

                if (Request.QueryString["Id"] == "1")
                {
                    if (e.Item.ItemType == ListItemType.Header)
                    {
                        var H_Building_Value = e.Item.FindControl("H_Building_Value") as HtmlTableCell;
                        var H_Building_Age = e.Item.FindControl("H_Building_Age") as HtmlTableCell;
                        var H_Still_Age = e.Item.FindControl("H_Still_Age") as HtmlTableCell;
                        var H_Annual_Waste = e.Item.FindControl("H_Annual_Waste") as HtmlTableCell;
                        var H_Cumulative_Waste = e.Item.FindControl("H_Cumulative_Waste") as HtmlTableCell;
                        var H_Building_Add = e.Item.FindControl("H_Building_Add") as HtmlTableCell;
                        var H_Building_Edit = e.Item.FindControl("H_Building_Edit") as HtmlTableCell;
                        var H_Sum_virtual_Value = e.Item.FindControl("H_Sum_virtual_Value") as HtmlTableCell;

                        var H_Ijar_Taakudy = e.Item.FindControl("H_Ijar_Taakudy") as HtmlTableCell;
                        var H_R_NotBook_Still = e.Item.FindControl("H_R_NotBook_Still") as HtmlTableCell;
                        var H_Dakhel_FUly = e.Item.FindControl("H_Dakhel_FUly") as HtmlTableCell;

                        var H_Stiil_Building_Value = e.Item.FindControl("H_Stiil_Building_Value") as HtmlTableCell;




                        H_Building_Value.Visible = false; H_Building_Age.Visible = false; H_Still_Age.Visible = false; H_Sum_virtual_Value.Visible=false;
                        H_Annual_Waste.Visible = false; H_Cumulative_Waste.Visible = false; H_Building_Add.Visible = false; H_Building_Edit.Visible = false;

                        H_Ijar_Taakudy.Visible = false; H_R_NotBook_Still.Visible = false; H_Dakhel_FUly.Visible = false; H_Stiil_Building_Value.Visible = false;

                    }
                    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                    {
                        var B_Building_Value = e.Item.FindControl("B_Building_Value") as HtmlTableCell;
                        var B_Building_Age = e.Item.FindControl("B_Building_Age") as HtmlTableCell;
                        var B_Still_Age = e.Item.FindControl("B_Still_Age") as HtmlTableCell;
                        var B_Annual_Waste = e.Item.FindControl("B_Annual_Waste") as HtmlTableCell;
                        var B_Cumulative_Waste = e.Item.FindControl("B_Cumulative_Waste") as HtmlTableCell;
                        var B_Building_Add = e.Item.FindControl("B_Building_Add") as HtmlTableCell;
                        var B_Building_Edit = e.Item.FindControl("B_Building_Edit") as HtmlTableCell;
                        var H_Sum_virtual_Value = e.Item.FindControl("B_Sum_virtual_Value") as HtmlTableCell;

                        var B_Ijar_Taakudy = e.Item.FindControl("B_Ijar_Taakudy") as HtmlTableCell;
                        var B_R_NotBook_Still = e.Item.FindControl("B_R_NotBook_Still") as HtmlTableCell;
                        var B_Dakhel_FUly = e.Item.FindControl("B_Dakhel_FUly") as HtmlTableCell;


                        var B_Stiil_Building_Value = e.Item.FindControl("B_Stiil_Building_Value") as HtmlTableCell;

                        B_Building_Value.Visible = false; B_Building_Age.Visible = false; B_Still_Age.Visible = false; H_Sum_virtual_Value.Visible=false;
                        B_Annual_Waste.Visible = false; B_Cumulative_Waste.Visible = false; B_Building_Add.Visible = false; B_Building_Edit.Visible = false;

                        B_Ijar_Taakudy.Visible = false; B_R_NotBook_Still.Visible = false; B_Dakhel_FUly.Visible = false; B_Stiil_Building_Value.Visible = false;
                    }
                }
                else if (Request.QueryString["Id"] == "2")
                {
                    if (e.Item.ItemType == ListItemType.Header)
                    {
                        var H_Building_Value = e.Item.FindControl("H_Building_Value") as HtmlTableCell;
                        var H_Building_Age = e.Item.FindControl("H_Building_Age") as HtmlTableCell;
                        var H_Still_Age = e.Item.FindControl("H_Still_Age") as HtmlTableCell;
                        var H_Annual_Waste = e.Item.FindControl("H_Annual_Waste") as HtmlTableCell;
                        var H_Cumulative_Waste = e.Item.FindControl("H_Cumulative_Waste") as HtmlTableCell;
                        var H_Sum_virtual_Value = e.Item.FindControl("H_Sum_virtual_Value") as HtmlTableCell;
                        var H_Ijar_Taakudy = e.Item.FindControl("H_Ijar_Taakudy") as HtmlTableCell;
                        var H_R_NotBook_Still = e.Item.FindControl("H_R_NotBook_Still") as HtmlTableCell;
                        var H_Dakhel_FUly = e.Item.FindControl("H_Dakhel_FUly") as HtmlTableCell;

                        var H_Stiil_Building_Value = e.Item.FindControl("H_Stiil_Building_Value") as HtmlTableCell;

                        var H_Building_Add = e.Item.FindControl("H_Building_Add") as HtmlTableCell;
                        var H_Building_Edit = e.Item.FindControl("H_Building_Edit") as HtmlTableCell;


                        H_Building_Value.Visible = false; H_Building_Age.Visible = false; H_Still_Age.Visible = false;
                        H_Annual_Waste.Visible = false; H_Cumulative_Waste.Visible = false; H_Sum_virtual_Value.Visible=false;
                        H_Ijar_Taakudy.Visible = false; H_R_NotBook_Still.Visible = false; H_Dakhel_FUly.Visible = false;
                        H_Stiil_Building_Value.Visible = false;

                        H_Building_Add.Visible = true; H_Building_Edit.Visible = true;

                    }
                    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                    {
                        var B_Building_Value = e.Item.FindControl("B_Building_Value") as HtmlTableCell;
                        var B_Building_Age = e.Item.FindControl("B_Building_Age") as HtmlTableCell;
                        var B_Still_Age = e.Item.FindControl("B_Still_Age") as HtmlTableCell;
                        var B_Annual_Waste = e.Item.FindControl("B_Annual_Waste") as HtmlTableCell;
                        var B_Cumulative_Waste = e.Item.FindControl("B_Cumulative_Waste") as HtmlTableCell;
                        var B_Sum_virtual_Value = e.Item.FindControl("B_Sum_virtual_Value") as HtmlTableCell;

                        var B_Ijar_Taakudy = e.Item.FindControl("B_Ijar_Taakudy") as HtmlTableCell;
                        var B_R_NotBook_Still = e.Item.FindControl("B_R_NotBook_Still") as HtmlTableCell;
                        var B_Dakhel_FUly = e.Item.FindControl("B_Dakhel_FUly") as HtmlTableCell;

                        var B_Stiil_Building_Value = e.Item.FindControl("B_Stiil_Building_Value") as HtmlTableCell;

                        var B_Building_Add = e.Item.FindControl("B_Building_Add") as HtmlTableCell;
                        var B_Building_Edit = e.Item.FindControl("B_Building_Edit") as HtmlTableCell;

                        B_Building_Value.Visible = false; B_Building_Age.Visible = false; B_Still_Age.Visible = false;
                        B_Annual_Waste.Visible = false; B_Cumulative_Waste.Visible = false; B_Sum_virtual_Value.Visible=false;
                        B_Ijar_Taakudy.Visible = false; B_R_NotBook_Still.Visible = false; B_Dakhel_FUly.Visible = false;
                        B_Stiil_Building_Value.Visible=false;


                        B_Building_Add.Visible = true; B_Building_Edit.Visible = true;
                    }
                }
                else
                {
                    if (e.Item.ItemType == ListItemType.Header)
                    {
                        var H_Building_Value = e.Item.FindControl("H_Building_Value") as HtmlTableCell;
                        var H_Building_Age = e.Item.FindControl("H_Building_Age") as HtmlTableCell;
                        var H_Still_Age = e.Item.FindControl("H_Still_Age") as HtmlTableCell;
                        var H_Annual_Waste = e.Item.FindControl("H_Annual_Waste") as HtmlTableCell;
                        var H_Cumulative_Waste = e.Item.FindControl("H_Cumulative_Waste") as HtmlTableCell;
                        var H_Sum_virtual_Value = e.Item.FindControl("H_Sum_virtual_Value") as HtmlTableCell;

                        var H_Ijar_Taakudy = e.Item.FindControl("H_Ijar_Taakudy") as HtmlTableCell;
                        var H_R_NotBook_Still = e.Item.FindControl("H_R_NotBook_Still") as HtmlTableCell;
                        var H_Dakhel_FUly = e.Item.FindControl("H_Dakhel_FUly") as HtmlTableCell;

                        var H_Stiil_Building_Value = e.Item.FindControl("H_Stiil_Building_Value") as HtmlTableCell;

                        var H_Building_Add = e.Item.FindControl("H_Building_Add") as HtmlTableCell;
                        var H_Building_Edit = e.Item.FindControl("H_Building_Edit") as HtmlTableCell;


                        H_Building_Value.Visible = true; H_Building_Age.Visible = true; H_Still_Age.Visible = true; 
                        H_Annual_Waste.Visible = true; H_Cumulative_Waste.Visible = true; H_Sum_virtual_Value.Visible=true;
                        H_Ijar_Taakudy.Visible = true; H_R_NotBook_Still.Visible = true; H_Dakhel_FUly.Visible = true;
                        H_Stiil_Building_Value.Visible = true;

                        H_Building_Add.Visible = false; H_Building_Edit.Visible = false;

                    }
                    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                    {
                        var B_Building_Value = e.Item.FindControl("B_Building_Value") as HtmlTableCell;
                        var B_Building_Age = e.Item.FindControl("B_Building_Age") as HtmlTableCell;
                        var B_Still_Age = e.Item.FindControl("B_Still_Age") as HtmlTableCell;
                        var B_Annual_Waste = e.Item.FindControl("B_Annual_Waste") as HtmlTableCell;
                        var B_Cumulative_Waste = e.Item.FindControl("B_Cumulative_Waste") as HtmlTableCell;
                        var B_Sum_virtual_Value = e.Item.FindControl("B_Sum_virtual_Value") as HtmlTableCell;

                        var B_Ijar_Taakudy = e.Item.FindControl("B_Ijar_Taakudy") as HtmlTableCell;
                        var B_R_NotBook_Still = e.Item.FindControl("B_R_NotBook_Still") as HtmlTableCell;
                        var B_Dakhel_FUly = e.Item.FindControl("B_Dakhel_FUly") as HtmlTableCell;

                        var B_Stiil_Building_Value = e.Item.FindControl("B_Stiil_Building_Value") as HtmlTableCell;

                        var B_Building_Add = e.Item.FindControl("B_Building_Add") as HtmlTableCell;
                        var B_Building_Edit = e.Item.FindControl("B_Building_Edit") as HtmlTableCell;

                        B_Building_Value.Visible = true; B_Building_Age.Visible = true; B_Still_Age.Visible = true;
                        B_Annual_Waste.Visible = true; B_Cumulative_Waste.Visible = true; B_Sum_virtual_Value.Visible=true;
                        B_Ijar_Taakudy.Visible = true; B_R_NotBook_Still.Visible = true; B_Dakhel_FUly.Visible = true;
                        B_Stiil_Building_Value.Visible = true;

                        B_Building_Add.Visible = false; B_Building_Edit.Visible = false;
                    }
                }
            }

        }

        protected void Units_List_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (Request.QueryString["Id"] == "1")
            {
                if (e.Item.ItemType == ListItemType.Header)
                {
                    var H_Unit_Edit = e.Item.FindControl("H_Unit_Edit") as HtmlTableCell;

                    H_Unit_Edit.Visible = false; 

                }
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    var B_Unit_Edit = e.Item.FindControl("B_Unit_Edit") as HtmlTableCell;

                    B_Unit_Edit.Visible = false;
                }
            }
            else if (Request.QueryString["Id"] == "2")
            {
                if (e.Item.ItemType == ListItemType.Header)
                {
                    var H_Unit_Edit = e.Item.FindControl("H_Unit_Edit") as HtmlTableCell;

                    H_Unit_Edit.Visible = true;

                }
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    var B_Unit_Edit = e.Item.FindControl("B_Unit_Edit") as HtmlTableCell;

                    B_Unit_Edit.Visible = true;
                }
            }
            else
            {
                if (e.Item.ItemType == ListItemType.Header)
                {
                    var H_Unit_Edit = e.Item.FindControl("H_Unit_Edit") as HtmlTableCell;

                    H_Unit_Edit.Visible = false;

                }
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    var B_Unit_Edit = e.Item.FindControl("B_Unit_Edit") as HtmlTableCell;

                    B_Unit_Edit.Visible = false;
                }
            }
        }

        protected void lnk_Owner_Ship_AR_Name_Click(object sender, EventArgs e)
        {
            Session["U_Back"] = "2";
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Ownership_Details_Tabel.aspx?Id=" + id);
        }

        protected void lnk_Building_Arabic_Name_Click(object sender, EventArgs e)
        {
            Session["B_Back"] = "2";
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Building_Datials.aspx?Id=" + id);
        }

        protected void lnk_Unit_Number_Click(object sender, EventArgs e)
        {
            Session["U_Back"] = "2";
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Unit_Datials.aspx?Id=" + id);
        }
    }
}