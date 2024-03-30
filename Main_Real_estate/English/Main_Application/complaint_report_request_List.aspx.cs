using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class complaint_report_request_List : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Add_permission(_sqlCon, Session["Role"].ToString(), "Asset_Management", Add);
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Asset_Management", 0, "R");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!IsPostBack)
            {
                Request_List_BindData();
            }
        }
        protected void Request_List_BindData(string sortExpression = null)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("complaint_report_request", _sqlCon))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        request_List.DataSource = dt;
                        request_List.DataBind();
                    }
                }
            }
            catch
            {
                Response.Write(
                    @"<script language='javascript'>alert('OOPS!!! The Building List Cannt Display')</script>");
            }
        }

        

        protected void Edit_Request(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;

            DataTable Dt = new DataTable();
            _sqlCon.Open();
            MySqlCommand Cmd = new MySqlCommand("SELECT * FROM roles WHERE Role_ID = @ID", _sqlCon);
            MySqlDataAdapter Da = new MySqlDataAdapter(Cmd);
            Cmd.Parameters.AddWithValue("@ID", Session["Role"].ToString());
            Da.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                string[] Page = Dt.Rows[0]["Asset_Management"].ToString().Split(',');
                if (Page[2] == "E") { Response.Redirect("Edit_complaint_report_request.aspx?Id=" + id); }
            }
            _sqlCon.Close();
        }

        protected void Details_Request(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("complaint_report_request_Details.aspx?Id=" + id);
        }

        protected void request_List_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Label Priority_Danger = null;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Priority_Danger = e.Item.FindControl("lbl_priority_Danger") as Label;
                HtmlTableRow tr = e.Item.FindControl("row") as HtmlTableRow;

                if (Priority_Danger.Text == "1")
                {
                    tr.Attributes.Add("style", "background-color: #faced2; color:#000000;");
                }

                else if (Priority_Danger.Text == "2")
                {
                    tr.Attributes.Add("style", "background-color: #fbde9f; color:#000000;");
                }
                else if (Priority_Danger.Text == "3")
                {
                    tr.Attributes.Add("style", "background-color: #c5f8eb; color:#000000;");
                }
            }


        }

        protected void btn_P_1_Click(object sender, EventArgs e)
        {
            Request_List_BindData();
            Label Priority_Danger = null;
            foreach (RepeaterItem ri in request_List.Items)
            {
                Priority_Danger = ri.FindControl("lbl_priority_Danger") as Label;

                HtmlTableRow tr = ri.FindControl("row") as HtmlTableRow;

                if (Priority_Danger.Text != "1")
                {
                    tr.Attributes.Add("style", "display:none;");
                }

            }
        }

        protected void btn_P_2_Click(object sender, EventArgs e)
        {
            Request_List_BindData();
            Label Priority_Danger = null;
            foreach (RepeaterItem ri in request_List.Items)
            {
                Priority_Danger = ri.FindControl("lbl_priority_Danger") as Label;

                HtmlTableRow tr = ri.FindControl("row") as HtmlTableRow;

                if (Priority_Danger.Text != "2")
                {
                    tr.Attributes.Add("style", "display:none;");
                }

            }
        }

        protected void btn_P_3_Click(object sender, EventArgs e)
        {
            Request_List_BindData();
            Label Priority_Danger = null;
            foreach (RepeaterItem ri in request_List.Items)
            {
                Priority_Danger = ri.FindControl("lbl_priority_Danger") as Label;

                HtmlTableRow tr = ri.FindControl("row") as HtmlTableRow;

                if (Priority_Danger.Text != "3")
                {
                    tr.Attributes.Add("style", "display:none;");
                }

            }
        }

        protected void btn_all_Click(object sender, EventArgs e)
        {
            Request_List_BindData();
        }

        protected void Filter_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Request_List_BindData();
            Label lbl_Activ = null;
            foreach (RepeaterItem ri in request_List.Items)
            {
                lbl_Activ = ri.FindControl("lbl_Activ") as Label;

                HtmlTableRow tr = ri.FindControl("row") as HtmlTableRow;



                if(Filter_DropDownList.SelectedValue== "2") 
                {
                    if (lbl_Activ.Text != "معلق")
                    {
                        tr.Attributes.Add("style", "display:none;");
                    }
                }
                else if (Filter_DropDownList.SelectedValue == "3")
                {
                    if (lbl_Activ.Text != "تم أنجازه")
                    {
                        tr.Attributes.Add("style", "display:none;");
                    }
                }
                else if (Filter_DropDownList.SelectedValue == "4")
                {
                    if (lbl_Activ.Text != "تحت الإجراء")
                    {
                        tr.Attributes.Add("style", "display:none;");
                    }
                }
               




            }
        }

        protected void LinK_Complaint_Report_Request_Click(object sender, EventArgs e)
        {

        }
    }
}