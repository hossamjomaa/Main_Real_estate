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
    public partial class Excel_report_New : System.Web.UI.Page
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
                Ownership_List_BindData();
                Building_List_BindData();
                Units_List_BindData();
            }
        }

        protected void Ownership_List_BindData(string sortExpression = null)
        {
            using (MySqlCommand OwnershipDetailsCmd = new MySqlCommand("New_OWnership_Excel_report", _sqlCon))
            {
                OwnershipDetailsCmd.CommandType = CommandType.StoredProcedure;
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



        protected void lnk_Contract_Id_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;


            if (id != "")
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


                    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                    {
                        RepeaterItem item_ = e.Item;
                        Label lbl_Persenteg = (item_.FindControl("lbl_Persenteg") as Label);
                        Label Label14 = (item_.FindControl("Label14") as Label);


                        if (Convert.ToInt32(lbl_Persenteg.Text) >= 80 && Convert.ToInt32(lbl_Persenteg.Text) <= 100)
                        {
                            Label14.Text ="A";
                        }
                        else if (Convert.ToInt32(lbl_Persenteg.Text) >= 60 && Convert.ToInt32(lbl_Persenteg.Text) <= 79)
                        {
                            Label14.Text = "B";
                        }
                        else if (Convert.ToInt32(lbl_Persenteg.Text) >= 40 && Convert.ToInt32(lbl_Persenteg.Text) <= 59)
                        {
                            Label14.Text = "C";
                        }
                        else if (Convert.ToInt32(lbl_Persenteg.Text) >= 20 && Convert.ToInt32(lbl_Persenteg.Text) <= 39)
                        {
                            Label14.Text = "D";
                        }
                        else 
                        {
                            Label14.Text = "E";
                        }


                        //if (lbl_Persenteg.Text != "")
                        //{


                        //    if (Convert.ToInt32(lbl_Persenteg.Text) >= 80 && Convert.ToInt32(lbl_Persenteg.Text) <= 100)
                        //    {
                        //        lbl_Persenteg.Text = "A";
                        //    }
                        //    else if (Convert.ToInt32(lbl_Persenteg.Text) >= 60 && Convert.ToInt32(lbl_Persenteg.Text) <= 79)
                        //    {
                        //        lbl_Persenteg.Text = "B";
                        //    }
                        //    else if (Convert.ToInt32(lbl_Persenteg.Text) >= 40 && Convert.ToInt32(lbl_Persenteg.Text) <= 59)
                        //    {
                        //        lbl_Persenteg.Text = "C";
                        //    }
                        //    else if (Convert.ToInt32(lbl_Persenteg.Text) >= 20 && Convert.ToInt32(lbl_Persenteg.Text) <= 39)
                        //    {
                        //        lbl_Persenteg.Text = "D";
                        //    }
                        //    else
                        //    {
                        //        lbl_Persenteg.Text = "E";
                        //    }
                        //}

                    }

                }
            }
        }

        protected void lbl_Ownership_Arabic_name_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("OwnerShip_DTL.aspx?Id=" + id);
        }

        protected void lbl_Building_Arabic_Name_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Building_Dtl.aspx?Id=" + id);
        }

        protected void lbl_Unit_Number_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Unit_DTL.aspx?Id=" + id);
        }
    }
}