using Main_Real_estate.English.Master_Panal;
using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using Syncfusion.JavaScript.DataVisualization;
using Syncfusion.JavaScript.DataVisualization.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iTextSharp.text.pdf.AcroFields;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Excel_Report : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "properties", 0, "R");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!this.IsPostBack)
            {
                //Get Ownershi_Name_DropDownList
                Helper.LoadDropDownList("SELECT * FROM owner_ship where Active!='1'", _sqlCon, Ownershi_Name_DropDownList, "Owner_Ship_AR_Name", "Owner_Ship_Id");
                Ownershi_Name_DropDownList.Items.Insert(0, "..... الكل .....");
            }
        }
        protected void Ownership_List_BindData(string sortExpression = null)
        {
            using (MySqlCommand OwnershipDetailsCmd = new MySqlCommand("Onership_Excel_report", _sqlCon))
            {
                OwnershipDetailsCmd.CommandType = CommandType.StoredProcedure;
                OwnershipDetailsCmd.Parameters.AddWithValue("@Id", Ownershi_Name_DropDownList.SelectedValue);
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
                    bulidingDetailsCmd.Parameters.AddWithValue("@Id", Ownershi_Name_DropDownList.SelectedValue);
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
        protected void Ownership_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Ownershi_Name_DropDownList.SelectedItem.Text != "..... الكل .....")
            {
                Chart_Div.Visible= true;   
                Ownership_List_BindData();
                Building_List_BindData();
                Units_List_BindData();
                Unit_Statu_Chart();
            }
        }

        protected void lnk_Contract_Id_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;


            if(id != "")
            {
                Response.Redirect("Contract_Details.aspx?Id=" + id);
            }
        }

        protected void Units_List_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem item in ownership_List.Items)
            {
                Repeater building_List = item.FindControl("building_List") as Repeater;
                foreach (RepeaterItem Building_item in building_List.Items)
                {
                    Repeater Units_List = Building_item.FindControl("Units_List") as Repeater;
                    foreach (RepeaterItem Unit_item in Units_List.Items)
                    {
                        LinkButton lnk_Contract_Id = (Unit_item.FindControl("lnk_Contract_Id") as LinkButton);
                        Label lbl_Contract_Id = (Unit_item.FindControl("lbl_Contract_Id") as Label);

                        if (lbl_Contract_Id.Text == "") { lnk_Contract_Id.Visible = false; }
                    }

                }
            }
        }



        protected void Unit_Statu_Chart()
        {
            string Available = "0"; string Rented = "0"; string Undermaintenance = "0"; string UnderProplem = "0";
            //string Quairy = @"SELECT 
            //                    (Select Count(*) FROM units where Half != 1 and Delete_Active != 1 and unit_condition_Unit_Condition_Id = 1 )as Rented ,
            //                    (Select count(*) from units where Half != 1 and Delete_Active != 1 and unit_condition_Unit_Condition_Id = 2) as Available  ,
            //                    (Select count(*) from units where Half != 1 and Delete_Active != 1 and unit_condition_Unit_Condition_Id = 3) as Undermaintenance ,
            //                    (Select count(*) from units where Half != 1 and Delete_Active != 1 and unit_condition_Unit_Condition_Id = 4) as UnderProplem; ";
            //_sqlCon.Open();
            //DataTable getUnitStatusChartDt = new DataTable();
            //MySqlCommand getUnitStatusChartCmd = new MySqlCommand(Quairy, _sqlCon);
            //MySqlDataAdapter getUnitStatusChartDa = new MySqlDataAdapter(getUnitStatusChartCmd);
            //getUnitStatusChartDa.Fill(getUnitStatusChartDt);
            //if (getUnitStatusChartDt.Rows.Count > 0)
            //{
            //    Available = getUnitStatusChartDt.Rows[0]["Available"].ToString();
            //    Rented = getUnitStatusChartDt.Rows[0]["Rented"].ToString();
            //    Undermaintenance = getUnitStatusChartDt.Rows[0]["Undermaintenance"].ToString();
            //    UnderProplem = getUnitStatusChartDt.Rows[0]["UnderProplem"].ToString();

            //}




            using (MySqlCommand bulidingDetailsCmd = new MySqlCommand("Onership_Excel_report", _sqlCon))
            {
                bulidingDetailsCmd.CommandType = CommandType.StoredProcedure;
                bulidingDetailsCmd.Parameters.AddWithValue("@Id", Ownershi_Name_DropDownList.SelectedValue);
                MySqlDataAdapter bulidingDetailsSda = new MySqlDataAdapter(bulidingDetailsCmd);

                DataTable bulidingDetailsDt = new DataTable();
                bulidingDetailsSda.Fill(bulidingDetailsDt);
                bulidingDetailsCmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                bulidingDetailsSda.Fill(dt);
                if (dt.Rows.Count > 0)
                {




                    Available = dt.Rows[0]["Shager"].ToString();
                    Rented = dt.Rows[0]["Muajar"].ToString();
                    Undermaintenance = dt.Rows[0]["Inshaa"].ToString();
                    UnderProplem = dt.Rows[0]["Nizza"].ToString();
                }
            }




            _sqlCon.Close();
            Series series = Unit_Status_Char.Series[0];
            series.Points.Clear();
            series.Points.Add(new Points("شاغر", double.Parse(Available)));
            series.Points.Add(new Points("مؤجر", double.Parse(Rented)));
            series.Points.Add(new Points("تحت الانشاء أو الصيانة", double.Parse(Undermaintenance)));
            series.Points.Add(new Points("موجد نزاع", double.Parse(UnderProplem)));
        }

        
    }
}