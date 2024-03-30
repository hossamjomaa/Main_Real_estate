using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Test_Test : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ownership_List_BindData();
                Building_List_BindData();
            }
        }
        protected void Ownership_List_BindData(string sortExpression = null)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("Details_All_ownership", _sqlCon))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        OwnerShip_Repeater.DataSource = dt;
                        OwnerShip_Repeater.DataBind();
                    }
                }
            }
            catch
            {
                Response.Write(
                    @"<script language='javascript'>alert('OOPS!!! The Ownership List Cannt Display')</script>");
            }
        }


        protected void Building_List_BindData () 
        {
            foreach (RepeaterItem item in OwnerShip_Repeater.Items)
            {
                Repeater Building_Repeater = item.FindControl("Building_Repeater") as Repeater;
                Label Owner_Ship_Id = item.FindControl("Owner_Ship_Id") as Label;

                try
                {
                    using (MySqlCommand bulidingDetailsCmd = new MySqlCommand("Building_List_In_Ownership_Details", _sqlCon))
                    {
                        bulidingDetailsCmd.CommandType = CommandType.StoredProcedure;
                        bulidingDetailsCmd.Parameters.AddWithValue("@Id", Owner_Ship_Id.Text);
                        MySqlDataAdapter bulidingDetailsSda = new MySqlDataAdapter(bulidingDetailsCmd);

                        DataTable bulidingDetailsDt = new DataTable();
                        bulidingDetailsSda.Fill(bulidingDetailsDt);
                        bulidingDetailsCmd.CommandType = CommandType.StoredProcedure;
                        DataTable dt = new DataTable();
                        bulidingDetailsSda.Fill(dt);
                        Building_Repeater.DataSource = dt;
                        Building_Repeater.DataBind();
                        _sqlCon.Close();
                    }
                }
                catch
                {
                    Response.Write(
                        @"<script language='javascript'>alert('OOPS!!! The Building List Cannt Display')</script>");
                }
            }
        }

        protected void Show_Building(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;

            var Building_Repeater = (item.FindControl("Building_Repeater") as Repeater);
            var Show_Building = (item.FindControl("Show_Building") as LinkButton);
            var Hide_Building = (item.FindControl("Hide_Building") as LinkButton);


            Building_Repeater.Visible = true;
            Show_Building.Visible = false; Hide_Building.Visible = true;



        }

        protected void Hide_Building(object sender, EventArgs e)
        {

            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;

            var Building_Repeater = (item.FindControl("Building_Repeater") as Repeater);
            var Show_Building = (item.FindControl("Show_Building") as LinkButton);
            var Hide_Building = (item.FindControl("Hide_Building") as LinkButton);

            Building_Repeater.Visible = false;
                Show_Building.Visible = true; Hide_Building.Visible = false;
            
        }
    }
}