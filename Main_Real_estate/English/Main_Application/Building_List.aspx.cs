using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Building_List : System.Web.UI.Page
    {
        private int _size = 0;

        //MySqlConnection SqlCon = Helper.GetConnection();
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
                Building_List_BindData();
            }
        }

        protected void Building_List_BindData(string sortExpression = null)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("Buliding_list", _sqlCon))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        building_List.DataSource = dt;
                        building_List.DataBind();
                    }
                }
            }
            catch
            {
                Response.Write(
                    @"<script language='javascript'>alert('OOPS!!! The Building List Cannt Display')</script>");
            }
        }

        protected void Delete_Building(object sender, EventArgs e)
        {
            try
            {
                string buildingId = (sender as LinkButton).CommandArgument;
                _sqlCon.Open();
                string deleteBuildingQuary = "DELETE FROM building WHERE Building_Id=@ID ";
                MySqlCommand deleteBuildingCmd = new MySqlCommand(deleteBuildingQuary, _sqlCon);
                deleteBuildingCmd.Parameters.AddWithValue("@ID", buildingId);
                deleteBuildingCmd.ExecuteNonQuery();
                _sqlCon.Close();
                Response.Redirect(Request.RawUrl);
            }
            catch
            {
                Response.Write(
                    @"<script language='javascript'>alert('This Building Cannot Be Removed!!! Because It Contains  Units')</script>");
            }
        }

        protected void Edit_Building(object sender, EventArgs e)
        {
            Session["B_Back"] = "1";
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Edit_Building.aspx?Id=" + id);
        }

        protected void Details_Building(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Building_Dtl.aspx?Id=" + id);
        }

        protected void building_List_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton Edit = e.Item.FindControl("Edit") as LinkButton;
                Utilities.Roles.Edit_permission(_sqlCon, Session["Role"].ToString(), "properties", Edit);

                Label lbl_Building_Image = e.Item.FindControl("lbl_Building_Image") as Label;
                Image Building_Image = e.Item.FindControl("Building_Image") as Image;
                if (lbl_Building_Image.Text == "No File") { Building_Image.Visible = false; } else { Building_Image.Visible = true; }
            }
        }
    }
}