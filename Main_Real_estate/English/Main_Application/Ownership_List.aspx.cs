using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Ownership_List : System.Web.UI.Page
    {
        private int _size = 0;
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Add_permission(_sqlCon, Session["Role"].ToString(), "properties", Add);
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!IsPostBack)
            {
                Ownership_List_BindData();
            }
        }

        protected void Ownership_List_BindData(string sortExpression = null)
        {
            //try
            //{
                using (MySqlCommand cmd = new MySqlCommand("Details_All_ownership", _sqlCon))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        ownership_List.DataSource = dt;
                        ownership_List.DataBind();
                    }
                }
            //}
            //catch
            //{
            //    Response.Write(
            //        @"<script language='javascript'>alert('OOPS!!! The Ownership List Cannt Display')</script>");
            //}
        }

        protected void Edit_Ownership(object sender, EventArgs e)
        {
            Session["OW_Back"] = "1";

            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Edit_Ownership.aspx?Id=" + id);
        }

        protected void Details_Ownership(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("OwnerShip_DTL.aspx?Id=" + id);
        }

        protected void ownership_List_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton Edit = e.Item.FindControl("Edit") as LinkButton;
                Utilities.Roles.Edit_permission(_sqlCon, Session["Role"].ToString(), "properties", Edit);
            }

        }
    }
}