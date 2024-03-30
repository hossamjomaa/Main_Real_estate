using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Asset_List : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            Asset_List_BindData();
        }

        protected void Asset_List_BindData()
        {
            try
            {
                string assetListQuary =
                    "SELECT Assets_Id , Assets_English_Name , Assets_Arabic_Name , Assets_Value , Quantitiy  FROM assets";
                MySqlCommand assetListCmd = new MySqlCommand(assetListQuary, _sqlCon);
                MySqlDataAdapter assetListDt = new MySqlDataAdapter(assetListCmd);
                assetListCmd.Connection = _sqlCon;
                _sqlCon.Open();
                assetListDt.SelectCommand = assetListCmd;
                DataTable assetListDataTable = new DataTable();
                assetListDt.Fill(assetListDataTable);
                Asset_GridView.DataSource = assetListDataTable;
                Asset_GridView.DataBind();

                _sqlCon.Close();
            }
            catch
            {
                Response.Write(@"<script language='javascript'>alert('OOPS!!! The Asset List Cannt Display')</script>");
            }
        }

        protected void Asset_GridView_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            Asset_GridView.PageIndex = e.NewPageIndex;
            Asset_List_BindData();
        }

        protected void Delete_Asset(object sender, EventArgs e)
        {
            try
            {
                string assetRowId = (sender as LinkButton).CommandArgument;
                _sqlCon.Open();
                string deleteAssetQuary = "DELETE FROM Assets WHERE Assets_Id=@ID ";
                MySqlCommand deleteAssetCmd = new MySqlCommand(deleteAssetQuary, _sqlCon);
                deleteAssetCmd.Parameters.AddWithValue("@ID", assetRowId);
                deleteAssetCmd.ExecuteNonQuery();
                _sqlCon.Close();
                Response.Redirect(Request.RawUrl);
            }
            catch
            {
                Response.Write(
                    @"<script language='javascript'>alert('This Asset Cannot Be Removed!!! Because It Contains Items')</script>");
            }

            ;
        }

        protected void GoToAddAsset(object sender, EventArgs e)
        {
            Response.Redirect("Add_Asset.aspx");
        }

        protected void AssetDetails(object sender, EventArgs e)
        {
            Response.Redirect("Asset_Details.aspx");
        }
    }
}