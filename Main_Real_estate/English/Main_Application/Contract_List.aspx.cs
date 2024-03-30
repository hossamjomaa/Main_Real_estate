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
    public partial class Contract_List : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Add_permission(_sqlCon, Session["Role"].ToString(), "Contracting", Add);
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Contracting", 0, "R");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!IsPostBack)
            {
                BindDataAll();
                BindData();
                Building_BindData();
            }
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

        protected void BindData(string sortExpression = null)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("Contarct_list", _sqlCon))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        contract_List.DataSource = dt;
                        contract_List.DataBind();
                    }
                }
            }
            catch
            {
                Response.Write(
                    @"<script language='javascript'>alert('OOPS!!! The Contract List Cannt Display')</script>");
            }
        }

        protected void Building_BindData(string sortExpression = null)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("Building_Contarct_list", _sqlCon))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        Building_Contarct_List.DataSource = dt;
                        Building_Contarct_List.DataBind();
                    }
                }
            }
            catch
            {
                Response.Write(@"<script language='javascript'>alert('OOPS!!! The Contract List Cannt Display')</script>");
            }
        }

        protected void Delete_Contract(object sender, EventArgs e)
        {
            try
            {
                string id = (sender as LinkButton).CommandArgument;
                _sqlCon.Open();
                string quary1 = "DELETE FROM contract WHERE Contract_Id=@ID ";
                MySqlCommand mySqlCmd = new MySqlCommand(quary1, _sqlCon);
                mySqlCmd.Parameters.AddWithValue("@ID", id);
                mySqlCmd.ExecuteNonQuery();
                _sqlCon.Close();

                Response.Redirect(Request.RawUrl);
            }
            catch
            {
                Response.Write(
                    @"<script language='javascript'>alert('This Unit Cannot Be Removed!!! Because It Contains  Tenants')</script>");
            }
        }



        //****************************************************************************************************************************************
        protected void U_Edit_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            string[] Array_id = id.Split('/');
            if (Array_id[0] == "U") { Response.Redirect("Edit_Contract.aspx?Id=" + Array_id[1]); }
            else { Response.Redirect("Edit_Building_Contract.aspx?Id=" + Array_id[1]); }
        }
        protected void Edit_Contract(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Edit_Contract.aspx?Id=" + id);
        }

        protected void Edit_B_Contract(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Edit_Building_Contract.aspx?Id=" + id);
        }

        //****************************************************************************************************************************************
        protected void Details_Contract(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Contract_Details.aspx?Id=" + id);


            //Response.Write("<script>window.open ('Contract_Details.aspx?Id=" + id + "','_blank');</script>");
        }

        protected void Details_B_Contract(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Building_Contract_Details.aspx?Id=" + id);
        }

        //****************************************************************************************************************************************
        protected void U_Renew_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            string[] Array_id = id.Split('/');
            if (Array_id[0] == "U") { Response.Redirect("Renew_Contract.aspx?Id=" + Array_id[1]); }
            else { Response.Redirect("Renew_Building_Contract.aspx?Id=" + Array_id[1]); }
        }
        protected void Renew_Contract(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Renew_Contract.aspx?Id=" + id);
        }

        protected void Renew_B_Contract(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Renew_Building_Contract.aspx?Id=" + id);
        }

        //****************************************************************************************************************************************

        protected void contract_List_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Label EndDate = null;
            Label New_ReNewed_Expaired = null;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlTableRow tr = e.Item.FindControl("row") as HtmlTableRow;
                LinkButton ReNew_btn = (e.Item.FindControl("U_Renew") as LinkButton);
                LinkButton U_Finsh = (e.Item.FindControl("U_Finsh") as LinkButton);


                LinkButton U_delete = (e.Item.FindControl("U_delete") as LinkButton);
                LinkButton U_details = (e.Item.FindControl("U_details") as LinkButton);
                Label lbl_Done_Renew = (e.Item.FindControl("lbl_Done_Renew") as Label);
                EndDate = e.Item.FindControl("lbl_End_Date") as Label;
                New_ReNewed_Expaired = e.Item.FindControl("lbl_New_ReNewed_Expaired") as Label;

                string[] Array_End_Date = EndDate.Text.Split(new char[] { '/' });
                var prevDate = new DateTime(Convert.ToInt32(Array_End_Date[2]), Convert.ToInt32(Array_End_Date[1]),Convert.ToInt32(Array_End_Date[0]));
                var today = DateTime.Now;
                var diffOfDates = prevDate - today;
                int sub = diffOfDates.Days;



                if (New_ReNewed_Expaired.Text == "1")
                {
                    // If the days difference is > 60 and [New_ReNewed_Expaired = 1 ], the line color is green and the renewal button is hidden. 
                    if (diffOfDates.Days > 60)
                    {
                        tr.Attributes.Add("style", "background-color:#c5f8eb;color:#000000;");
                        ReNew_btn.Visible= false;
                    }
                    // If the days difference is <= 60 (2 months left until expiration) and New_ReNewed_Expaired = 1, the line color is red, and the renewal button is shown.
                    else if (diffOfDates.Days >= 0 && diffOfDates.Days <= 60)
                    {
                        tr.Attributes.Add("style", "background-color:#faced2;color:#000000;");
                        ReNew_btn.Visible = true;
                    }
                    // If days difference <= 0 (2 months more than expiry) and New_ReNewed_Expaired = 1 line color black show renewal button
                    else if (diffOfDates.Days <= 0)
                    {
                        tr.Attributes.Add("style", "background-color:#cbd0d8;color:#000000;");
                        ReNew_btn.Visible = true; U_Finsh.Visible = false; tr.Visible= false;
                    }
                }
                else if (New_ReNewed_Expaired.Text == "2")
                {
                    tr.Attributes.Add("style", "background-color:#cbd0d8;color:#000000;");
                    ReNew_btn.Visible = false; U_Finsh.Visible = false; tr.Visible = false;
                }
                else if (New_ReNewed_Expaired.Text == "3")
                {
                    tr.Attributes.Add("style", "background-color:#cbd0d8;color:#000000;");
                    ReNew_btn.Visible = false; U_Finsh.Visible = false; tr.Visible = false;
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

        protected void Building_Contarct_List_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Label EndDate = null;
            Label New_ReNewed_Expaired = null;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlTableRow tr = e.Item.FindControl("row") as HtmlTableRow;
                LinkButton ReNew_btn = (e.Item.FindControl("B_Renew") as LinkButton);
                LinkButton B_Edit = (e.Item.FindControl("B_Edit") as LinkButton);
                LinkButton B_Finsh = (e.Item.FindControl("B_Finsh") as LinkButton);
                LinkButton B_details = (e.Item.FindControl("B_details") as LinkButton);
                Label lbl_Done_Renew = (e.Item.FindControl("lbl_Done_Renew") as Label);
                EndDate = e.Item.FindControl("lbl_End_Date") as Label;
                New_ReNewed_Expaired = e.Item.FindControl("lbl_New_ReNewed_Expaired") as Label;


                string[] Array_End_Date = EndDate.Text.Split(new char[] { '/' });
                var prevDate = new DateTime(Convert.ToInt32(Array_End_Date[2]), Convert.ToInt32(Array_End_Date[1]),
                    Convert.ToInt32(Array_End_Date[0]));
                var today = DateTime.Now;
                var diffOfDates = prevDate - today;
                int sub = diffOfDates.Days;


                if (New_ReNewed_Expaired.Text == "1")
                {
                    // If the days difference is > 60 and [New_ReNewed_Expaired = 1 ], the line color is green and the renewal button is hidden. 
                    if (diffOfDates.Days > 60)
                    {
                        tr.Attributes.Add("style", "background-color:#c5f8eb;color:#000000;");
                        ReNew_btn.Visible = false;
                    }
                    // If the days difference is <= 60 (2 months left until expiration) and New_ReNewed_Expaired = 1, the line color is red, and the renewal button is shown.
                    else if (diffOfDates.Days >= 0 && diffOfDates.Days <= 60)
                    {
                        tr.Attributes.Add("style", "background-color:#faced2;color:#000000;");
                        ReNew_btn.Visible = true;
                    }
                    // If days difference <= 0 (2 months more than expiry) and New_ReNewed_Expaired = 1 line color black show renewal button
                    else if (diffOfDates.Days <= 0)
                    {
                        tr.Attributes.Add("style", "background-color:#cbd0d8;color:#000000;");
                        ReNew_btn.Visible = true; B_Finsh.Visible = false; tr.Visible = false;
                    }
                }
                else if (New_ReNewed_Expaired.Text == "2")
                {
                    tr.Attributes.Add("style", "background-color:#cbd0d8;color:#000000;");
                    ReNew_btn.Visible = false; B_Finsh.Visible = false; tr.Visible = false;
                }
                else if (New_ReNewed_Expaired.Text == "3")
                {
                    tr.Attributes.Add("style", "background-color:#cbd0d8;color:#000000;");
                    ReNew_btn.Visible = false; B_Finsh.Visible = false; tr.Visible = false;
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
                            var H_Two = e.Item.FindControl("H_Two") as HtmlTableCell;
                            var H_Two_Two = e.Item.FindControl("H_Two_Two") as HtmlTableCell;
                            H_Two.Visible = false; H_Two_Two.Visible = false;
                        }
                        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                        {
                            var B_Two = e.Item.FindControl("B_Two") as HtmlTableCell;
                            var B_Two_Two = e.Item.FindControl("B_Two_Two") as HtmlTableCell;
                            B_Two.Visible = false; B_Two_Two.Visible = false;
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

        //*************************************************************************************************************

        protected void btn_New_Contarct_Click(object sender, EventArgs e)
        {
            Label EndDate = null;
            Label New_ReNewed_Expaired = null;
            BindDataAll();
            foreach (RepeaterItem ri in Repeater1.Items)
            {
                HtmlTableRow tr = ri.FindControl("row") as HtmlTableRow;
                LinkButton ReNew_btn = (ri.FindControl("U_Renew") as LinkButton);
                EndDate = ri.FindControl("lbl_End_Date") as Label;
                New_ReNewed_Expaired = ri.FindControl("lbl_New_ReNewed_Expaired") as Label;
                string[] Array_End_Date = EndDate.Text.Split(new char[] { '/' });
                var prevDate = new DateTime(Convert.ToInt32(Array_End_Date[2]), Convert.ToInt32(Array_End_Date[1]),
                    Convert.ToInt32(Array_End_Date[0]));
                var today = DateTime.Now;
                var diffOfDates = prevDate - today;
                int sub = diffOfDates.Days;


                if (New_ReNewed_Expaired.Text == "1")
                {
                    // If the days difference is > 60 and [New_ReNewed_Expaired = 1 ], the line color is green and the renewal button is hidden. 
                    if (diffOfDates.Days > 60)
                    {
                        tr.Attributes.Add("style", "background-color:#c5f8eb;color:#000000;");
                        ReNew_btn.Visible = false;
                    }
                    // If the days difference is <= 60 (2 months left until expiration) and New_ReNewed_Expaired = 1, the line color is red, and the renewal button is shown.
                    else if (diffOfDates.Days >= 0 && diffOfDates.Days <= 60)
                    {
                        tr.Visible = false;
                    }
                    // If days difference <= 0 (2 months more than expiry) and New_ReNewed_Expaired = 1 line color black show renewal button
                    else if (diffOfDates.Days <= 0)
                    {
                        tr.Visible = false;
                    }
                }
                else if (New_ReNewed_Expaired.Text == "2")
                {
                    tr.Visible = false;
                }
                else if (New_ReNewed_Expaired.Text == "3")
                {
                    tr.Visible = false;
                }
            }
            //----------------------------------------------------------------------------------------------------------------------------------
            BindData();
            foreach (RepeaterItem ri in contract_List.Items)
            {
                HtmlTableRow tr = ri.FindControl("row") as HtmlTableRow;
                LinkButton ReNew_btn = (ri.FindControl("U_Renew") as LinkButton);
                EndDate = ri.FindControl("lbl_End_Date") as Label;
                New_ReNewed_Expaired = ri.FindControl("lbl_New_ReNewed_Expaired") as Label;
                string[] Array_End_Date = EndDate.Text.Split(new char[] { '/' });
                var prevDate = new DateTime(Convert.ToInt32(Array_End_Date[2]), Convert.ToInt32(Array_End_Date[1]),
                    Convert.ToInt32(Array_End_Date[0]));
                var today = DateTime.Now;
                var diffOfDates = prevDate - today;
                int sub = diffOfDates.Days;
                if (New_ReNewed_Expaired.Text == "1")
                {
                    // If the days difference is > 60 and [New_ReNewed_Expaired = 1 ], the line color is green and the renewal button is hidden. 
                    if (diffOfDates.Days > 60)
                    {
                        tr.Attributes.Add("style", "background-color:#c5f8eb;color:#000000;");
                        ReNew_btn.Visible = false;
                    }
                    // If the days difference is <= 60 (2 months left until expiration) and New_ReNewed_Expaired = 1, the line color is red, and the renewal button is shown.
                    else if (diffOfDates.Days >= 0 && diffOfDates.Days <= 60)
                    {
                        tr.Visible = false;
                    }
                    // If days difference <= 0 (2 months more than expiry) and New_ReNewed_Expaired = 1 line color black show renewal button
                    else if (diffOfDates.Days <= 0)
                    {
                        tr.Visible = false;
                    }
                }
                else if (New_ReNewed_Expaired.Text == "2")
                {
                    tr.Visible = false;
                }
                else if (New_ReNewed_Expaired.Text == "3")
                {
                    tr.Visible = false;
                }
            }
            //----------------------------------------------------------------------------------------------------------------------------------

            Building_BindData();
            Label B_EndDate = null;
            Label B_New_ReNewed_Expaired = null;
            foreach (RepeaterItem ri in Building_Contarct_List.Items)
            {
                HtmlTableRow tr = ri.FindControl("row") as HtmlTableRow;
                LinkButton ReNew_btn = (ri.FindControl("B_Renew") as LinkButton);
                B_EndDate = ri.FindControl("lbl_End_Date") as Label;
                B_New_ReNewed_Expaired = ri.FindControl("lbl_New_ReNewed_Expaired") as Label;
                string[] Array_End_Date = B_EndDate.Text.Split(new char[] { '/' });
                var prevDate = new DateTime(Convert.ToInt32(Array_End_Date[2]), Convert.ToInt32(Array_End_Date[1]),
                    Convert.ToInt32(Array_End_Date[0]));
                var today = DateTime.Now;
                var diffOfDates = prevDate - today;
                int sub = diffOfDates.Days;
                if (New_ReNewed_Expaired.Text == "1")
                {
                    // If the days difference is > 60 and [New_ReNewed_Expaired = 1 ], the line color is green and the renewal button is hidden. 
                    if (diffOfDates.Days > 60)
                    {
                        tr.Attributes.Add("style", "background-color:#c5f8eb;color:#000000;");
                        ReNew_btn.Visible = false;
                    }
                    // If the days difference is <= 60 (2 months left until expiration) and New_ReNewed_Expaired = 1, the line color is red, and the renewal button is shown.
                    else if (diffOfDates.Days >= 0 && diffOfDates.Days <= 60)
                    {
                        tr.Visible = false;
                    }
                    // If days difference <= 0 (2 months more than expiry) and New_ReNewed_Expaired = 1 line color black show renewal button
                    else if (diffOfDates.Days <= 0)
                    {
                        tr.Visible = false;
                    }
                }
                else if (New_ReNewed_Expaired.Text == "2")
                {
                    tr.Visible = false;
                }
                else if (New_ReNewed_Expaired.Text == "3")
                {
                    tr.Visible = false;
                }
            }
        }

        //*************************************************************************************************************
        protected void btn_Under_Expaired_Contract_Click(object sender, EventArgs e)
        {
            BindDataAll();
            Label EndDate = null;
            Label New_ReNewed_Expaired = null;
            foreach (RepeaterItem ri in Repeater1.Items)
            {
                HtmlTableRow tr = ri.FindControl("row") as HtmlTableRow;
                LinkButton ReNew_btn = (ri.FindControl("U_Renew") as LinkButton);
                EndDate = ri.FindControl("lbl_End_Date") as Label;
                New_ReNewed_Expaired = ri.FindControl("lbl_New_ReNewed_Expaired") as Label;
                string[] Array_End_Date = EndDate.Text.Split(new char[] { '/' });
                var prevDate = new DateTime(Convert.ToInt32(Array_End_Date[2]), Convert.ToInt32(Array_End_Date[1]),
                    Convert.ToInt32(Array_End_Date[0]));
                var today = DateTime.Now;
                var diffOfDates = prevDate - today;
                int sub = diffOfDates.Days;


                if (New_ReNewed_Expaired.Text == "1")
                {
                    // If the days difference is > 60 and [New_ReNewed_Expaired = 1 ], the line color is green and the renewal button is hidden. 
                    if (diffOfDates.Days > 60)
                    {
                        tr.Visible = false;
                    }
                    // If the days difference is <= 60 (2 months left until expiration) and New_ReNewed_Expaired = 1, the line color is red, and the renewal button is shown.
                    else if (diffOfDates.Days >= 0 && diffOfDates.Days <= 60)
                    {
                        tr.Attributes.Add("style", "background-color:#faced2;color:#000000;");
                        ReNew_btn.Visible = true;
                    }
                    // If days difference <= 0 (2 months more than expiry) and New_ReNewed_Expaired = 1 line color black show renewal button
                    else if (diffOfDates.Days <= 0)
                    {
                        tr.Visible = false;
                    }
                }
                else if (New_ReNewed_Expaired.Text == "2")
                {
                    tr.Visible = false;
                }
                else if (New_ReNewed_Expaired.Text == "3")
                {
                    tr.Visible = false;
                }



                //if (diffOfDates.Days <= 60 && New_ReNewed_Expaired.Text == "1")
                //{
                //    ReNew_btn.Visible = true;
                //}

                //if (diffOfDates.Days > 60)
                //{
                //    tr.Attributes.Add("style", "display:none");
                //}
                //else if (diffOfDates.Days <= 0)
                //{
                //    tr.Attributes.Add("style", "display:none");
                //}
            }

            //----------------------------------------------------------------------------------------------------------------------------------
            BindData();
            foreach (RepeaterItem ri in contract_List.Items)
            {
                HtmlTableRow tr = ri.FindControl("row") as HtmlTableRow;
                LinkButton ReNew_btn = (ri.FindControl("U_Renew") as LinkButton);
                EndDate = ri.FindControl("lbl_End_Date") as Label;
                New_ReNewed_Expaired = ri.FindControl("lbl_New_ReNewed_Expaired") as Label;
                string[] Array_End_Date = EndDate.Text.Split(new char[] { '/' });
                var prevDate = new DateTime(Convert.ToInt32(Array_End_Date[2]), Convert.ToInt32(Array_End_Date[1]),
                    Convert.ToInt32(Array_End_Date[0]));
                var today = DateTime.Now;
                var diffOfDates = prevDate - today;
                int sub = diffOfDates.Days;



                if (New_ReNewed_Expaired.Text == "1")
                {
                    // If the days difference is > 60 and [New_ReNewed_Expaired = 1 ], the line color is green and the renewal button is hidden. 
                    if (diffOfDates.Days > 60)
                    {
                        tr.Visible = false;
                    }
                    // If the days difference is <= 60 (2 months left until expiration) and New_ReNewed_Expaired = 1, the line color is red, and the renewal button is shown.
                    else if (diffOfDates.Days >= 0 && diffOfDates.Days <= 60)
                    {
                        tr.Attributes.Add("style", "background-color:#faced2;color:#000000;");
                        ReNew_btn.Visible = true;
                    }
                    // If days difference <= 0 (2 months more than expiry) and New_ReNewed_Expaired = 1 line color black show renewal button
                    else if (diffOfDates.Days <= 0)
                    {
                        tr.Visible = false;
                    }
                }
                else if (New_ReNewed_Expaired.Text == "2")
                {
                    tr.Visible = false;
                }
                else if (New_ReNewed_Expaired.Text == "3")
                {
                    tr.Visible = false;
                }
            }

            //----------------------------------------------------------------------------------------------------------------------------------

            Building_BindData();
            Label B_EndDate = null;
            Label B_New_ReNewed_Expaired = null;
            foreach (RepeaterItem ri in Building_Contarct_List.Items)
            {
                HtmlTableRow tr = ri.FindControl("row") as HtmlTableRow;
                LinkButton ReNew_btn = (ri.FindControl("B_Renew") as LinkButton);
                B_EndDate = ri.FindControl("lbl_End_Date") as Label;
                B_New_ReNewed_Expaired = ri.FindControl("lbl_New_ReNewed_Expaired") as Label;
                string[] Array_End_Date = B_EndDate.Text.Split(new char[] { '/' });
                var prevDate = new DateTime(Convert.ToInt32(Array_End_Date[2]), Convert.ToInt32(Array_End_Date[1]),
                    Convert.ToInt32(Array_End_Date[0]));
                var today = DateTime.Now;
                var diffOfDates = prevDate - today;
                int sub = diffOfDates.Days;




                if (New_ReNewed_Expaired.Text == "1")
                {
                    // If the days difference is > 60 and [New_ReNewed_Expaired = 1 ], the line color is green and the renewal button is hidden. 
                    if (diffOfDates.Days > 60)
                    {
                        tr.Visible = false;
                    }
                    // If the days difference is <= 60 (2 months left until expiration) and New_ReNewed_Expaired = 1, the line color is red, and the renewal button is shown.
                    else if (diffOfDates.Days >= 0 && diffOfDates.Days <= 60)
                    {
                        tr.Attributes.Add("style", "background-color:#faced2;color:#000000;");
                        ReNew_btn.Visible = true;
                    }
                    // If days difference <= 0 (2 months more than expiry) and New_ReNewed_Expaired = 1 line color black show renewal button
                    else if (diffOfDates.Days <= 0)
                    {
                        tr.Visible = false;
                    }
                }
                else if (New_ReNewed_Expaired.Text == "2")
                {
                    tr.Visible = false;
                }
                else if (New_ReNewed_Expaired.Text == "3")
                {
                    tr.Visible = false;
                }
            }
        }

        //*************************************************************************************************************
        protected void btn_Expaired_Contract_Click(object sender, EventArgs e)
        {
            
            Label EndDate = null;
            Label New_ReNewed_Expaired = null;

            BindDataAll();
            foreach (RepeaterItem ri in Repeater1.Items)
            {
                HtmlTableRow tr = ri.FindControl("row") as HtmlTableRow;
                LinkButton ReNew_btn = (ri.FindControl("U_Renew") as LinkButton);
                EndDate = ri.FindControl("lbl_End_Date") as Label;
                New_ReNewed_Expaired = ri.FindControl("lbl_New_ReNewed_Expaired") as Label;
                string[] Array_End_Date = EndDate.Text.Split(new char[] { '/' });
                var prevDate = new DateTime(Convert.ToInt32(Array_End_Date[2]), Convert.ToInt32(Array_End_Date[1]),
                    Convert.ToInt32(Array_End_Date[0]));
                var today = DateTime.Now;
                var diffOfDates = prevDate - today;
                int sub = diffOfDates.Days;


                if (New_ReNewed_Expaired.Text == "1")
                {
                    // If the days difference is > 60 and [New_ReNewed_Expaired = 1 ], the line color is green and the renewal button is hidden. 
                    if (diffOfDates.Days > 60)
                    {
                        tr.Visible = false;
                    }
                    // If the days difference is <= 60 (2 months left until expiration) and New_ReNewed_Expaired = 1, the line color is red, and the renewal button is shown.
                    else if (diffOfDates.Days >= 0 && diffOfDates.Days <= 60)
                    {
                        tr.Visible = false;
                    }
                    // If days difference <= 0 (2 months more than expiry) and New_ReNewed_Expaired = 1 line color black show renewal button
                    else if (diffOfDates.Days <= 0)
                    {
                        tr.Visible = true;
                    }
                }
                else if (New_ReNewed_Expaired.Text == "2")
                {
                    tr.Attributes.Add("style", "background-color:#cbd0d8;color:#000000;");
                    tr.Visible = true;
                }
                else if (New_ReNewed_Expaired.Text == "3")
                {
                    tr.Attributes.Add("style", "background-color:#cbd0d8;color:#000000;");
                    tr.Visible = true;
                }
            }

            //----------------------------------------------------------------------------------------------------------------------------------
            BindData();
            foreach (RepeaterItem ri in contract_List.Items)
            {
                HtmlTableRow tr = ri.FindControl("row") as HtmlTableRow;
                LinkButton ReNew_btn = (ri.FindControl("U_Renew") as LinkButton);
                EndDate = ri.FindControl("lbl_End_Date") as Label;
                New_ReNewed_Expaired = ri.FindControl("lbl_New_ReNewed_Expaired") as Label;
                string[] Array_End_Date = EndDate.Text.Split(new char[] { '/' });
                var prevDate = new DateTime(Convert.ToInt32(Array_End_Date[2]), Convert.ToInt32(Array_End_Date[1]),
                    Convert.ToInt32(Array_End_Date[0]));
                var today = DateTime.Now;
                var diffOfDates = prevDate - today;
                int sub = diffOfDates.Days;
                if (New_ReNewed_Expaired.Text == "1")
                {
                    // If the days difference is > 60 and [New_ReNewed_Expaired = 1 ], the line color is green and the renewal button is hidden. 
                    if (diffOfDates.Days > 60)
                    {
                        tr.Visible = false;
                    }
                    // If the days difference is <= 60 (2 months left until expiration) and New_ReNewed_Expaired = 1, the line color is red, and the renewal button is shown.
                    else if (diffOfDates.Days >= 0 && diffOfDates.Days <= 60)
                    {
                        tr.Visible = false;
                    }
                    // If days difference <= 0 (2 months more than expiry) and New_ReNewed_Expaired = 1 line color black show renewal button
                    else if (diffOfDates.Days <= 0)
                    {
                        tr.Visible = true;
                    }
                }
                else if (New_ReNewed_Expaired.Text == "2")
                {
                    tr.Attributes.Add("style", "background-color:#cbd0d8;color:#000000;");
                    tr.Visible = true;
                }
                else if (New_ReNewed_Expaired.Text == "3")
                {
                    tr.Attributes.Add("style", "background-color:#cbd0d8;color:#000000;");
                    tr.Visible = true;
                }
            }

            //----------------------------------------------------------------------------------------------------------------------------------
            Building_BindData();
            Label B_EndDate = null;
            Label B_New_ReNewed_Expaired = null;
            foreach (RepeaterItem ri in Building_Contarct_List.Items)
            {
                HtmlTableRow tr = ri.FindControl("row") as HtmlTableRow;
                LinkButton ReNew_btn = (ri.FindControl("B_Renew") as LinkButton);
                B_EndDate = ri.FindControl("lbl_End_Date") as Label;
                B_New_ReNewed_Expaired = ri.FindControl("lbl_New_ReNewed_Expaired") as Label;
                string[] Array_End_Date = B_EndDate.Text.Split(new char[] { '/' });
                var prevDate = new DateTime(Convert.ToInt32(Array_End_Date[2]), Convert.ToInt32(Array_End_Date[1]),
                    Convert.ToInt32(Array_End_Date[0]));
                var today = DateTime.Now;
                var diffOfDates = prevDate - today;
                int sub = diffOfDates.Days;
                if (New_ReNewed_Expaired.Text == "1")
                {
                    // If the days difference is > 60 and [New_ReNewed_Expaired = 1 ], the line color is green and the renewal button is hidden. 
                    if (diffOfDates.Days > 60)
                    {
                        tr.Visible = false;
                    }
                    // If the days difference is <= 60 (2 months left until expiration) and New_ReNewed_Expaired = 1, the line color is red, and the renewal button is shown.
                    else if (diffOfDates.Days >= 0 && diffOfDates.Days <= 60)
                    {
                        tr.Visible = false;
                    }
                    // If days difference <= 0 (2 months more than expiry) and New_ReNewed_Expaired = 1 line color black show renewal button
                    else if (diffOfDates.Days <= 0)
                    {
                        tr.Visible = true;
                    }
                }
                else if (New_ReNewed_Expaired.Text == "2")
                {
                    tr.Attributes.Add("style", "background-color:#cbd0d8;color:#000000;");
                    tr.Visible = true;
                }
                else if (New_ReNewed_Expaired.Text == "3")
                {
                    tr.Attributes.Add("style", "background-color:#cbd0d8;color:#000000;");
                    tr.Visible = true;
                }
            }
        }

        protected void btn_all_Contract_Click(object sender, EventArgs e)
        {
            BindDataAll();
            BindData();
            Building_BindData();
        }

        protected void A_1_ServerClick(object sender, EventArgs e)
        {
            Repeater1.Visible = false;  contract_List.Visible = true; Building_Contarct_List.Visible = false;
            Label1.Text = "العقود المفردة";
        }

        protected void A_2_ServerClick(object sender, EventArgs e)
        {
            Repeater1.Visible = false; contract_List.Visible = false; Building_Contarct_List.Visible = true;
            Label1.Text = "العقود المجملة";
        }

        protected void A_3_ServerClick(object sender, EventArgs e)
        {
            Repeater1.Visible = true; contract_List.Visible = false; Building_Contarct_List.Visible = false;
            Label1.Text = " كافة العقود";
        }

        protected void C_ID_ServerClick(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Contract_Details.aspx?Id=" + id);
        }

        protected void B_Contract_NO_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Building_Contract_Details.aspx?Id=" + id);
        }

        protected void Contract_NO_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            string[] Array_id = id.Split('/');
            if (Array_id[0] == "U") { Response.Redirect("Contract_Details.aspx?Id=" + Array_id[1]); }
            else { Response.Redirect("Building_Contract_Details.aspx?Id=" + Array_id[1]); }
        }

        protected void Finsh_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            string[] Array_id = id.Split('/');
            if (Array_id[0] == "U") 
            {
                //  Update New_ReNewed_Expaired to 3 in Contract Table
                string New_ReNewed_ExpairedQuery = "UPDATE contract SET New_ReNewed_Expaired=@New_ReNewed_Expaired  WHERE Contract_Id=@ID ";
                _sqlCon.Open();
                using (MySqlCommand UpdateContractCmd = new MySqlCommand(New_ReNewed_ExpairedQuery, _sqlCon))
                {
                    UpdateContractCmd.Parameters.AddWithValue("@ID", Array_id[1]);
                    //Fill The Database with All DropDownLists Items
                    UpdateContractCmd.Parameters.AddWithValue("@New_ReNewed_Expaired", "3");
                    UpdateContractCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                Response.Redirect(Request.RawUrl);
            }
            else 
            {
                //  Update New_ReNewed_Expaired to 3 in Contract Table
                string New_ReNewed_ExpairedQuery = "UPDATE building_contract SET New_ReNewed_Expaired=@New_ReNewed_Expaired  WHERE Contract_Id=@ID ";
                _sqlCon.Open();
                using (MySqlCommand UpdateContractCmd = new MySqlCommand(New_ReNewed_ExpairedQuery, _sqlCon))
                {
                    UpdateContractCmd.Parameters.AddWithValue("@ID", Array_id[1]);
                    //Fill The Database with All DropDownLists Items
                    UpdateContractCmd.Parameters.AddWithValue("@New_ReNewed_Expaired", "3");
                    UpdateContractCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void U_Finsh_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            //  Update New_ReNewed_Expaired to 3 in Contract Table
            string New_ReNewed_ExpairedQuery = "UPDATE contract SET New_ReNewed_Expaired=@New_ReNewed_Expaired  WHERE Contract_Id=@ID ";
            _sqlCon.Open();
            using (MySqlCommand UpdateContractCmd = new MySqlCommand(New_ReNewed_ExpairedQuery, _sqlCon))
            {
                UpdateContractCmd.Parameters.AddWithValue("@ID", id);
                //Fill The Database with All DropDownLists Items
                UpdateContractCmd.Parameters.AddWithValue("@New_ReNewed_Expaired", "3");
                UpdateContractCmd.ExecuteNonQuery();
                _sqlCon.Close();
            }
            Response.Redirect(Request.RawUrl);
        }

        protected void B_Finsh_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            //  Update New_ReNewed_Expaired to 3 in Contract Table
            string New_ReNewed_ExpairedQuery = "UPDATE building_contract SET New_ReNewed_Expaired=@New_ReNewed_Expaired  WHERE Contract_Id=@ID ";
            _sqlCon.Open();
            using (MySqlCommand UpdateContractCmd = new MySqlCommand(New_ReNewed_ExpairedQuery, _sqlCon))
            {
                UpdateContractCmd.Parameters.AddWithValue("@ID", id);
                //Fill The Database with All DropDownLists Items
                UpdateContractCmd.Parameters.AddWithValue("@New_ReNewed_Expaired", "3");
                UpdateContractCmd.ExecuteNonQuery();
                _sqlCon.Close();
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}