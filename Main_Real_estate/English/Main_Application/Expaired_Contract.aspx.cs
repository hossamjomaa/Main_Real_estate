using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using Syncfusion.JavaScript.Models;
using System;
using System.Data;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Expaired_Contract : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDataAll();
        }
        protected void BindDataAll(string sortExpression = null)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("All_Contract_List", _sqlCon))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        Repeater1.DataSource = dt;
                        Repeater1.DataBind();
                    }
                }
            }
            catch
            {
                Response.Write(
                    @"<script language='javascript'>alert('OOPS!!! The Contract List Cannt Display')</script>");
            }
        }

        protected void contract_List_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Label EndDate = null;
            Label New_ReNewed_Expaired = null;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlTableRow tr = e.Item.FindControl("row") as HtmlTableRow;
                LinkButton ReNew_btn = (e.Item.FindControl("U_Renew") as LinkButton);
                LinkButton U_delete = (e.Item.FindControl("U_delete") as LinkButton);
                LinkButton U_details = (e.Item.FindControl("U_details") as LinkButton);
                Label lbl_Done_Renew = (e.Item.FindControl("lbl_Done_Renew") as Label);
                EndDate = e.Item.FindControl("lbl_End_Date") as Label;
                New_ReNewed_Expaired = e.Item.FindControl("lbl_New_ReNewed_Expaired") as Label;

                string[] Array_End_Date = EndDate.Text.Split(new char[] { '/' });
                var prevDate = new DateTime(Convert.ToInt32(Array_End_Date[2]), Convert.ToInt32(Array_End_Date[1]), Convert.ToInt32(Array_End_Date[0]));
                var today = DateTime.Now;
                var diffOfDates = prevDate - today;
                int sub = diffOfDates.Days;



                if (diffOfDates.Days <= 60 && New_ReNewed_Expaired.Text == "1")
                {
                    ReNew_btn.Visible = true;
                }
                else if (diffOfDates.Days <= 60 && New_ReNewed_Expaired.Text == "2")
                {
                    ReNew_btn.Visible = false;
                }

                if (diffOfDates.Days > 60)
                {
                    tr.Attributes.Add("style", "background-color:#c5f8eb;color:#000000;");
                    tr.Visible = false;
                }
                else if (diffOfDates.Days <= 60 && diffOfDates.Days >= 0)
                {
                    tr.Attributes.Add("style", "background-color:#faced2;color:#000000;");
                }
                else if (diffOfDates.Days <= 0)
                {
                    tr.Attributes.Add("style", "background-color:#cbd0d8;color:#000000;");
                    tr.Visible = false;
                }
            }




            try
            {
                DataTable Dt = new DataTable();
                _sqlCon.Open();
                MySqlCommand Cmd = new MySqlCommand("SELECT * FROM roles WHERE Role_ID = @ID", _sqlCon);
                MySqlDataAdapter Da = new MySqlDataAdapter(Cmd);
                Cmd.Parameters.AddWithValue("@ID", Session["Role"].ToString());
                Da.Fill(Dt);
                if (Dt.Rows.Count > 0)
                {
                    string[] Page = Dt.Rows[0]["Contracting"].ToString().Split(',');
                    if (Page[2] != "E")
                    {
                        if (e.Item.ItemType == ListItemType.Header)
                        {
                            var H_One = e.Item.FindControl("H_One") as HtmlTableCell;
                            H_One.Visible = false;
                        }
                        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                        {
                            var B_One = e.Item.FindControl("B_One") as HtmlTableCell;
                            B_One.Visible = false;
                        }
                    }
                }
                _sqlCon.Close();
            }
            catch
            {
                Response.Redirect("Log_In.aspx");
            }
        }

        protected void U_Edit_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            string[] Array_id = id.Split('/');
            if (Array_id[0] == "U") { Response.Redirect("Edit_Contract.aspx?Id=" + Array_id[1]); }
            else { Response.Redirect("Edit_Building_Contract.aspx?Id=" + Array_id[1]); }
        }
        protected void U_Renew_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            string[] Array_id = id.Split('/');
            if (Array_id[0] == "U") { Response.Redirect("Renew_Contract.aspx?Id=" + Array_id[1]); }
            else { Response.Redirect("Renew_Building_Contract.aspx?Id=" + Array_id[1]); }
        }
        protected void Contract_NO_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            string[] Array_id = id.Split('/');
            if (Array_id[0] == "U") { Response.Redirect("Contract_Details.aspx?Id=" + Array_id[1]); }
            else { Response.Redirect("Building_Contract_Details.aspx?Id=" + Array_id[1]); }
        }
    }
}