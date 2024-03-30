using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Ashraf : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ownership_List_BindData();
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
                        rptCustomers.DataSource = dt;
                        rptCustomers.DataBind();
                    }
                }
            }
            catch
            {
                Response.Write(
                    @"<script language='javascript'>alert('OOPS!!! The Ownership List Cannt Display')</script>");
            }
        }






        


        protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string Owner_Ship_Id = (e.Item.FindControl("Owner_Ship_Id") as HiddenField).Value;
                Repeater rptOrders = e.Item.FindControl("rptOrders") as Repeater;

                using (MySqlCommand bulidingDetailsCmd = new MySqlCommand("Building_List_In_Ownership_Details", _sqlCon))
                {
                    bulidingDetailsCmd.CommandType = CommandType.StoredProcedure;
                    bulidingDetailsCmd.Parameters.AddWithValue("@Id", Owner_Ship_Id);
                    MySqlDataAdapter bulidingDetailsSda = new MySqlDataAdapter(bulidingDetailsCmd);

                    DataTable bulidingDetailsDt = new DataTable();
                    bulidingDetailsSda.Fill(bulidingDetailsDt);
                    bulidingDetailsCmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    bulidingDetailsSda.Fill(dt);
                    rptOrders.DataSource = dt;
                    rptOrders.DataBind();
                    _sqlCon.Close();
                }

            }
        }







    }
}