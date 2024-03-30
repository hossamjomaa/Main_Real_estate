using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Units_List1 : System.Web.UI.Page
    {
        private int _size = 0;
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Add_permission(_sqlCon, Session["Role"].ToString(), "properties", Add);
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "properties", 0, "R");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData(string sortExpression = null)
        {
            //try
            //{
                using (MySqlCommand cmd = new MySqlCommand("Unit_List", _sqlCon))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        eeeee.DataSource = dt;
                        eeeee.DataBind();
                    }
                }
            //}
            //catch
            //{
            //    Response.Write(
            //        @"<script language='javascript'>alert('OOPS!!! The Building List Cannt Display')</script>");
            //}
        }


        protected void Edit_Unit(object sender, EventArgs e)
        {
            Session["U_Back"] = "1";
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Edit_Units.aspx?Id=" + id);
        }

        protected void Details_Unit(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Unit_DTL.aspx?Id=" + id);
        }

        protected void eeeee_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton Edit = e.Item.FindControl("Edit") as LinkButton;
                Utilities.Roles.Edit_permission(_sqlCon, Session["Role"].ToString(), "properties", Edit);
            }
        }
    }
}