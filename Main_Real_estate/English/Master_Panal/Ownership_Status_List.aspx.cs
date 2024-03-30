using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Ownership_Status_List : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        private int _size = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = BindGridView();
                TableCell tableCell = Ownership_Status_GridView1.HeaderRow.Cells[1];
                Image img = new Image();
                img.ImageUrl = "Images/down_arrow.png";
                img.Width = img.Height = 20;
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                ViewState["tables"] = dt;
            }
        }

        private DataTable BindGridView()
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter adapt = new MySqlDataAdapter("select * from ownership_status", _sqlCon);
            _sqlCon.Open();
            adapt.Fill(dt);
            _sqlCon.Close();
            Ownership_Status_GridView1.DataSource = dt;
            Ownership_Status_GridView1.DataBind();
            return dt;
        }

        //******************************************** Gridview Paging Functions ********************************************
        protected void Ownership_Status_GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Ownership_Status_GridView1.PageIndex = e.NewPageIndex;
            this.BindGridView();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _size = int.Parse(DropDownList1.SelectedItem.Value.ToString());
            Ownership_Status_GridView1.PageSize = _size;
            BindGridView();
        }

        //******************************************** Gridview Sorting Functions ********************************************
        public SortDirection Dir
        {
            get
            {
                if (ViewState["dirState"] == null)
                {
                    ViewState["dirState"] = SortDirection.Ascending;
                }

                return (SortDirection)ViewState["dirState"];
            }
            set { ViewState["dirState"] = value; }
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortDir = string.Empty;
            DataTable dt = new DataTable();
            dt = ViewState["tables"] as DataTable;
            {
                if (Dir == SortDirection.Ascending)
                {
                    Dir = SortDirection.Descending;
                    sortDir = "Desc";

                    TableCell tableCell = Ownership_Status_GridView1.HeaderRow.Cells[1];
                    Image img = new Image();
                    img.ImageUrl = "Images/down_arrow.png";
                    img.Width = img.Height = 20;
                    tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                    tableCell.Controls.Add(img);
                }
                else
                {
                    Dir = SortDirection.Ascending;
                    sortDir = "Asc";

                    TableCell tableCell = Ownership_Status_GridView1.HeaderRow.Cells[1];
                    Image img = new Image();
                    img.ImageUrl = "Images/up_arrow.png";
                    img.Width = img.Height = 20;
                    tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                    tableCell.Controls.Add(img);
                }

                DataView sortedView = new DataView(dt);
                sortedView.Sort = e.SortExpression + " " + sortDir;
                Ownership_Status_GridView1.DataSource = sortedView;
                Ownership_Status_GridView1.DataBind();

                //for (int i = 0; i < Ownership_Status_GridView1.Columns.Count; i++)
                //{
                //    string lbText = ((LinkButton)Ownership_Status_GridView1.HeaderRow.Cells[i].Controls[0]).Text;
                //    if (e.SortExpression.Equals(lbText))
                //    {
                //        TableCell tableCell = Ownership_Status_GridView1.HeaderRow.Cells[i];
                //        Image img = new Image();
                //        img.ImageUrl = (SortDir == "Asc") ? "Images/down_arrow.png" : "Images/up_arrow.png";
                //        img.Width = img.Height = 20;
                //        tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                //        tableCell.Controls.Add(img);
                //    }
                //}
            }
        }

        //******************************************** Gridview Seacrch Function ********************************************
        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            string searchInOwnershipStatusListQuary =
                "SELECT * FROM ownership_status where ownership_arabic_status" +
                " like '%" + txt_Search_In_Ownership_Status.Text + "%' " +
                "OR ownership_status_id like '%" + txt_Search_In_Ownership_Status.Text + "%' " +
                "OR ownership_english_status like '%" + txt_Search_In_Ownership_Status.Text + "%'";

            MySqlCommand searchInOwnershipStatusListCmd =
                new MySqlCommand(searchInOwnershipStatusListQuary, _sqlCon);
            MySqlDataAdapter searchInOwnershipStatusListDt =
                new MySqlDataAdapter(searchInOwnershipStatusListCmd);
            searchInOwnershipStatusListCmd.Connection = _sqlCon;
            _sqlCon.Open();
            searchInOwnershipStatusListDt.SelectCommand = searchInOwnershipStatusListCmd;
            DataTable searchInOwnershipStatusListDataTable = new DataTable();
            searchInOwnershipStatusListDt.Fill(searchInOwnershipStatusListDataTable);
            Ownership_Status_GridView1.DataSource = searchInOwnershipStatusListDataTable;
            Ownership_Status_GridView1.DataBind();
            _sqlCon.Close();
        }

        //************************************************************************************************************

        protected void Delete_Ownership_Status(object sender, EventArgs e)
        {
            try
            {
                string id = (sender as LinkButton).CommandArgument;
                _sqlCon.Open();
                string quary1 = "DELETE FROM ownership_status WHERE ownership_status_id=@ID ";
                MySqlCommand mySqlCmd = new MySqlCommand(quary1, _sqlCon);
                mySqlCmd.Parameters.AddWithValue("@ID", id);
                mySqlCmd.ExecuteNonQuery();
                _sqlCon.Close();
                Response.Redirect(Request.RawUrl);
            }
            catch
            {
                Response.Write(
                    @"<script language='javascript'>alert('This Ownership Status Cannot Be Deleted Because It Is Related To An Ownerships')</script>");
            }

            ;
        }

        protected void GoToAddBuildinType(object sender, EventArgs e)
        {
            Response.Redirect("Add_Ownership_status.aspx");
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue == "1")
            {
                string searchInOwnershipStatusListQuary =
                    "SELECT * FROM ownership_status ORDER BY ownership_arabic_status ASC ";

                MySqlCommand searchInOwnershipStatusListCmd =
                    new MySqlCommand(searchInOwnershipStatusListQuary, _sqlCon);
                MySqlDataAdapter searchInOwnershipStatusListDt =
                    new MySqlDataAdapter(searchInOwnershipStatusListCmd);
                searchInOwnershipStatusListCmd.Connection = _sqlCon;
                _sqlCon.Open();
                searchInOwnershipStatusListDt.SelectCommand = searchInOwnershipStatusListCmd;
                DataTable searchInOwnershipStatusListDataTable = new DataTable();
                searchInOwnershipStatusListDt.Fill(searchInOwnershipStatusListDataTable);
                Ownership_Status_GridView1.DataSource = searchInOwnershipStatusListDataTable;
                Ownership_Status_GridView1.DataBind();
                _sqlCon.Close();
            }
            else if (DropDownList2.SelectedValue == "2")
            {
                string searchInOwnershipStatusListQuary =
                    "SELECT * FROM ownership_status ORDER BY ownership_arabic_status  DESC";

                MySqlCommand searchInOwnershipStatusListCmd =
                    new MySqlCommand(searchInOwnershipStatusListQuary, _sqlCon);
                MySqlDataAdapter searchInOwnershipStatusListDt =
                    new MySqlDataAdapter(searchInOwnershipStatusListCmd);
                searchInOwnershipStatusListCmd.Connection = _sqlCon;
                _sqlCon.Open();
                searchInOwnershipStatusListDt.SelectCommand = searchInOwnershipStatusListCmd;
                DataTable searchInOwnershipStatusListDataTable = new DataTable();
                searchInOwnershipStatusListDt.Fill(searchInOwnershipStatusListDataTable);
                Ownership_Status_GridView1.DataSource = searchInOwnershipStatusListDataTable;
                Ownership_Status_GridView1.DataBind();
                _sqlCon.Close();
            }
            else if (DropDownList2.SelectedValue == "3")
            {
                string searchInOwnershipStatusListQuary =
                    "SELECT * FROM ownership_status ORDER BY ownership_English_status ASC ";

                MySqlCommand searchInOwnershipStatusListCmd =
                    new MySqlCommand(searchInOwnershipStatusListQuary, _sqlCon);
                MySqlDataAdapter searchInOwnershipStatusListDt =
                    new MySqlDataAdapter(searchInOwnershipStatusListCmd);
                searchInOwnershipStatusListCmd.Connection = _sqlCon;
                _sqlCon.Open();
                searchInOwnershipStatusListDt.SelectCommand = searchInOwnershipStatusListCmd;
                DataTable searchInOwnershipStatusListDataTable = new DataTable();
                searchInOwnershipStatusListDt.Fill(searchInOwnershipStatusListDataTable);
                Ownership_Status_GridView1.DataSource = searchInOwnershipStatusListDataTable;
                Ownership_Status_GridView1.DataBind();
                _sqlCon.Close();
            }
            else if (DropDownList2.SelectedValue == "4")
            {
                string searchInOwnershipStatusListQuary =
                    "SELECT * FROM ownership_status ORDER BY ownership_English_status DESC";

                MySqlCommand searchInOwnershipStatusListCmd =
                    new MySqlCommand(searchInOwnershipStatusListQuary, _sqlCon);
                MySqlDataAdapter searchInOwnershipStatusListDt =
                    new MySqlDataAdapter(searchInOwnershipStatusListCmd);
                searchInOwnershipStatusListCmd.Connection = _sqlCon;
                _sqlCon.Open();
                searchInOwnershipStatusListDt.SelectCommand = searchInOwnershipStatusListCmd;
                DataTable searchInOwnershipStatusListDataTable = new DataTable();
                searchInOwnershipStatusListDt.Fill(searchInOwnershipStatusListDataTable);
                Ownership_Status_GridView1.DataSource = searchInOwnershipStatusListDataTable;
                Ownership_Status_GridView1.DataBind();
                _sqlCon.Close();
            }
            else if (DropDownList2.SelectedValue == "5")
            {
                string searchInOwnershipStatusListQuary =
                    "SELECT * FROM ownership_status ORDER BY ownership_status_id ASC ";

                MySqlCommand searchInOwnershipStatusListCmd =
                    new MySqlCommand(searchInOwnershipStatusListQuary, _sqlCon);
                MySqlDataAdapter searchInOwnershipStatusListDt =
                    new MySqlDataAdapter(searchInOwnershipStatusListCmd);
                searchInOwnershipStatusListCmd.Connection = _sqlCon;
                _sqlCon.Open();
                searchInOwnershipStatusListDt.SelectCommand = searchInOwnershipStatusListCmd;
                DataTable searchInOwnershipStatusListDataTable = new DataTable();
                searchInOwnershipStatusListDt.Fill(searchInOwnershipStatusListDataTable);
                Ownership_Status_GridView1.DataSource = searchInOwnershipStatusListDataTable;
                Ownership_Status_GridView1.DataBind();
                _sqlCon.Close();
            }
            else if (DropDownList2.SelectedValue == "6")
            {
                string searchInOwnershipStatusListQuary =
                    "SELECT * FROM ownership_status ORDER BY ownership_status_id DESC";

                MySqlCommand searchInOwnershipStatusListCmd =
                    new MySqlCommand(searchInOwnershipStatusListQuary, _sqlCon);
                MySqlDataAdapter searchInOwnershipStatusListDt =
                    new MySqlDataAdapter(searchInOwnershipStatusListCmd);
                searchInOwnershipStatusListCmd.Connection = _sqlCon;
                _sqlCon.Open();
                searchInOwnershipStatusListDt.SelectCommand = searchInOwnershipStatusListCmd;
                DataTable searchInOwnershipStatusListDataTable = new DataTable();
                searchInOwnershipStatusListDt.Fill(searchInOwnershipStatusListDataTable);
                Ownership_Status_GridView1.DataSource = searchInOwnershipStatusListDataTable;
                Ownership_Status_GridView1.DataBind();
                _sqlCon.Close();
            }
        }
    }
}