using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Periodec_Maintenance : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Asset_Management", 0, "R");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!this.IsPostBack)
            {
                this.BindGrid_Contract_Cheque_List();

                int year = DateTime.Now.Year;
                for (int i = year - 5; i <= year + 10; i++)
                {
                    ListItem li = new ListItem(i.ToString());
                    Year_DropDownList.Items.Add(li);
                    Last_Years_DropDownList.Items.Add(li);
                }
                Year_DropDownList.Items.FindByText(year.ToString()).Selected = true;
                Last_Years_DropDownList.Items.FindByText(year.ToString()).Selected = true;


            }

        }

        private void BindGrid_Contract_Cheque_List()
        {
            _sqlCon.Open();
            string ContractId = Convert.ToString(DateTime.Now.Year);
            using (MySqlCommand Contract_ChequesCmd = new MySqlCommand("Periodec_Maintenance", _sqlCon))
            {
                Contract_ChequesCmd.CommandType = CommandType.StoredProcedure;
                Contract_ChequesCmd.Parameters.AddWithValue("@Id", ContractId);

                Contract_ChequesCmd.Parameters.AddWithValue("@O_Id", txtSearch.Text.Trim());
                Contract_ChequesCmd.Parameters.AddWithValue("@B_Id", txtSearch.Text.Trim());
                MySqlDataAdapter Contract_ChequesSda = new MySqlDataAdapter(Contract_ChequesCmd);

                DataTable Contract_ChequesDt = new DataTable();
                Contract_ChequesSda.Fill(Contract_ChequesDt);
                Contract_ChequesCmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                Contract_ChequesSda.Fill(dt);
                Periodic_Maintenence_List.DataSource = dt;
                Periodic_Maintenence_List.DataBind();
            }
            _sqlCon.Close();
        }

        protected void btn_Open_New_Year_Click(object sender, EventArgs e)
        {
            Year_Div.Visible = true;
        }
        protected void Add_New_Year_Click(object sender, ImageClickEventArgs e)
        {
            //    Get The Last periodic_maintenence Id
            using (MySqlCommand Last_periodic_maintenence_ID = new MySqlCommand("SELECT MAX(Periodic_Maintenence_ID) AS LastInsertedID from periodic_maintenence", _sqlCon))
            {
                _sqlCon.Open();
                Last_periodic_maintenence_ID.CommandType = CommandType.Text;
                object Contract_ID = Last_periodic_maintenence_ID.ExecuteScalar();
                if (Contract_ID != null)
                {
                    Last_periodic_maintenence_id.Text = Contract_ID.ToString();
                }

                _sqlCon.Close();
            }

            MySqlConnection sqlCon = Helper.GetConnection();
            MySqlDataAdapter Sda = new MySqlDataAdapter(
            "Select Year  from periodic_maintenence where Year='" + Last_Years_DropDownList.SelectedItem.Text.Trim() + "'", sqlCon);
            DataTable dt = new DataTable();
            Sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string Asset_ID_sql_Quary = "INSERT INTO `periodic_maintenence` (`Asset_ID`,`Last_Periodic_Maintenance_Date`) select  Asset_ID , Last_Periodic_Maintenance_Date from periodic_maintenence"; ;
                //Asset_ID_sql_Quary += "INSERT INTO periodic_maintenence (Asset_ID )";
                //Asset_ID_sql_Quary += "(SELECT Assets_Id FROM assets Where Main_Place != 'مخزن' " +
                //    "And maintenance_categoty_Categoty_Id = 13 or  " +
                //    "maintenance_categoty_Categoty_Id = 15 or  " +
                //    "maintenance_categoty_Categoty_Id = 36  ) ";

                _sqlCon.Open();
                MySqlCommand cmd = new MySqlCommand(Asset_ID_sql_Quary, _sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                _sqlCon.Close();
                //***********************************************************
                if (Page.IsValid)
                {
                    string updateYearQuary = "UPDATE periodic_maintenence SET Year=@Year  where Periodic_Maintenence_ID > '" + Last_periodic_maintenence_id.Text + "'";
                    _sqlCon.Open();
                    MySqlCommand updateYearCmd = new MySqlCommand(updateYearQuary, _sqlCon);
                    updateYearCmd.Parameters.AddWithValue("@Year", Year_DropDownList.SelectedItem.Text.Trim());
                    updateYearCmd.ExecuteNonQuery();
                    _sqlCon.Close();

                }
            }
            else
            {
                Response.Write(@"<script language='javascript'>alert(' قد تم إنشاء جدول صيانة دورية لهذه السنة مسبقاً')</script>");
            }
            //***********************************************************

            this.BindGrid_Contract_Cheque_List();
        }

        protected void Cancel_Add_New_Year_Click(object sender, EventArgs e)
        {
            Year_Div.Visible = false;
        }

        protected void Last_Years_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _sqlCon.Open();
            string ContractId = Last_Years_DropDownList.SelectedItem.Text.Trim();
            using (MySqlCommand Contract_ChequesCmd = new MySqlCommand("Periodec_Maintenance", _sqlCon))
            {
                Contract_ChequesCmd.CommandType = CommandType.StoredProcedure;
                Contract_ChequesCmd.Parameters.AddWithValue("@Id", ContractId);
                Contract_ChequesCmd.Parameters.AddWithValue("@O_Id", txtSearch.Text.Trim());
                Contract_ChequesCmd.Parameters.AddWithValue("@B_Id", txtSearch.Text.Trim());
                MySqlDataAdapter Contract_ChequesSda = new MySqlDataAdapter(Contract_ChequesCmd);

                DataTable Contract_ChequesDt = new DataTable();
                Contract_ChequesSda.Fill(Contract_ChequesDt);
                Contract_ChequesCmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                Contract_ChequesSda.Fill(dt);
                Periodic_Maintenence_List.DataSource = dt;
                Periodic_Maintenence_List.DataBind();
            }
            _sqlCon.Close();
        }

        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // ****************************************  Get The Last Periodic Mentanance Date *************************************************
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.FindControl("lbl_Last_Periodic_Maintenance_Date")).Text != "")
                {
                    string Last_Maintenance = ((Label)e.Row.FindControl("lbl_Last_Periodic_Maintenance_Date")).Text;
                    DateTime Today = DateTime.Now;
                    DateTime LastMaintenance = Convert.ToDateTime(Last_Maintenance);
                    int difference_between_dates = (int)(Today - LastMaintenance).TotalDays;

                    string AssetId = ((Label)e.Row.FindControl("lbl_Asset_Id")).Text;
                    DataTable getAssetDt = new DataTable();
                    MySqlCommand getAssetCmd = new MySqlCommand("SELECT * FROM assets WHERE Assets_Id = @ID", _sqlCon);
                    MySqlDataAdapter getAssetDa = new MySqlDataAdapter(getAssetCmd);
                    getAssetCmd.Parameters.AddWithValue("@ID", AssetId);
                    getAssetDa.Fill(getAssetDt);
                    if (getAssetDt.Rows[0]["maintenance_categoty_Categoty_Id"].ToString() == "15")
                    {
                        if (difference_between_dates >= 180) { e.Row.ForeColor = System.Drawing.Color.Red; e.Row.BackColor = System.Drawing.Color.MistyRose; }
                    }
                    else if (getAssetDt.Rows[0]["maintenance_categoty_Categoty_Id"].ToString() == "13" || getAssetDt.Rows[0]["maintenance_categoty_Categoty_Id"].ToString() == "36")
                    {
                        if (difference_between_dates >= 90) { e.Row.ForeColor = System.Drawing.Color.Blue; e.Row.BackColor = System.Drawing.Color.AliceBlue; }
                    }
                }

            }


            // ****************************************  Fill The DropDownList Calanders  *************************************************
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList Calendar_M_1 = (DropDownList)e.Row.FindControl("Calendar_M_1");
                for (int i = 1; i <= 31; i++)
                {
                    ListItem li = new ListItem(i.ToString());
                    if (i <= 9) { Calendar_M_1.Items.Add("0" + li); } else { Calendar_M_1.Items.Add(li); }
                }
                Calendar_M_1.Items.Insert(0, "إختر ...");

                string M_1 = DataBinder.Eval(e.Row.DataItem, "M_1").ToString();
                string[] Arr_M_1 = M_1.Split('/');
                string Selected_Date_1 = Arr_M_1[0];
                if (Selected_Date_1 != "") { Calendar_M_1.Items.FindByText(Selected_Date_1.ToString()).Selected = true; }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList Calendar_M_2 = (DropDownList)e.Row.FindControl("Calendar_M_2");
                for (int i = 1; i <= 29; i++)
                {
                    ListItem li = new ListItem(i.ToString());
                    if (i <= 9) { Calendar_M_2.Items.Add("0" + li); } else { Calendar_M_2.Items.Add(li); }
                }
                Calendar_M_2.Items.Insert(0, "إختر ...");

                string M_2 = DataBinder.Eval(e.Row.DataItem, "M_2").ToString();
                string[] Arr_M_2 = M_2.Split('/');
                string Selected_Date_2 = Arr_M_2[0];
                if (Selected_Date_2 != "") { Calendar_M_2.Items.FindByText(Selected_Date_2.ToString()).Selected = true; }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList Calendar_M_3 = (DropDownList)e.Row.FindControl("Calendar_M_3");
                for (int i = 1; i <= 31; i++)
                {
                    ListItem li = new ListItem(i.ToString());
                    if (i <= 9) { Calendar_M_3.Items.Add("0" + li); } else { Calendar_M_3.Items.Add(li); }
                }
                Calendar_M_3.Items.Insert(0, "إختر ...");

                string M_3 = DataBinder.Eval(e.Row.DataItem, "M_3").ToString();
                string[] Arr_M_3 = M_3.Split('/');
                string Selected_Date_3 = Arr_M_3[0];
                if (Selected_Date_3 != "") { Calendar_M_3.Items.FindByText(Selected_Date_3.ToString()).Selected = true; }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList Calendar_M_4 = (DropDownList)e.Row.FindControl("Calendar_M_4");
                for (int i = 1; i <= 30; i++)
                {
                    ListItem li = new ListItem(i.ToString());
                    if (i <= 9) { Calendar_M_4.Items.Add("0" + li); } else { Calendar_M_4.Items.Add(li); }
                }
                Calendar_M_4.Items.Insert(0, "إختر ...");

                string M_4 = DataBinder.Eval(e.Row.DataItem, "M_4").ToString();
                string[] Arr_M_4 = M_4.Split('/');
                string Selected_Date_4 = Arr_M_4[0];
                if (Selected_Date_4 != "") { Calendar_M_4.Items.FindByText(Selected_Date_4.ToString()).Selected = true; }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList Calendar_M_5 = (DropDownList)e.Row.FindControl("Calendar_M_5");
                for (int i = 1; i <= 31; i++)
                {
                    ListItem li = new ListItem(i.ToString());
                    if (i <= 9) { Calendar_M_5.Items.Add("0" + li); } else { Calendar_M_5.Items.Add(li); }
                }
                Calendar_M_5.Items.Insert(0, "إختر ...");

                string M_5 = DataBinder.Eval(e.Row.DataItem, "M_5").ToString();
                string[] Arr_M_5 = M_5.Split('/');
                string Selected_Date_5 = Arr_M_5[0];
                if (Selected_Date_5 != "") { Calendar_M_5.Items.FindByText(Selected_Date_5.ToString()).Selected = true; }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList Calendar_M_6 = (DropDownList)e.Row.FindControl("Calendar_M_6");
                for (int i = 1; i <= 30; i++)
                {
                    ListItem li = new ListItem(i.ToString());
                    if (i <= 9) { Calendar_M_6.Items.Add("0" + li); } else { Calendar_M_6.Items.Add(li); }
                }
                Calendar_M_6.Items.Insert(0, "إختر ...");

                string M_6 = DataBinder.Eval(e.Row.DataItem, "M_6").ToString();
                string[] Arr_M_6 = M_6.Split('/');
                string Selected_Date_6 = Arr_M_6[0];
                if (Selected_Date_6 != "") { Calendar_M_6.Items.FindByText(Selected_Date_6.ToString()).Selected = true; }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList Calendar_M_7 = (DropDownList)e.Row.FindControl("Calendar_M_7");
                for (int i = 1; i <= 31; i++)
                {
                    ListItem li = new ListItem(i.ToString());
                    if (i <= 9) { Calendar_M_7.Items.Add("0" + li); } else { Calendar_M_7.Items.Add(li); }
                }
                Calendar_M_7.Items.Insert(0, "إختر ...");

                string M_7 = DataBinder.Eval(e.Row.DataItem, "M_7").ToString();
                string[] Arr_M_7 = M_7.Split('/');
                string Selected_Date_7 = Arr_M_7[0];
                if (Selected_Date_7 != "") { Calendar_M_7.Items.FindByText(Selected_Date_7.ToString()).Selected = true; }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList Calendar_M_8 = (DropDownList)e.Row.FindControl("Calendar_M_8");
                for (int i = 1; i <= 31; i++)
                {
                    ListItem li = new ListItem(i.ToString());
                    if (i <= 9) { Calendar_M_8.Items.Add("0" + li); } else { Calendar_M_8.Items.Add(li); }
                }
                Calendar_M_8.Items.Insert(0, "إختر ...");

                string M_8 = DataBinder.Eval(e.Row.DataItem, "M_8").ToString();
                string[] Arr_M_8 = M_8.Split('/');
                string Selected_Date_8 = Arr_M_8[0];
                if (Selected_Date_8 != "") { Calendar_M_8.Items.FindByText(Selected_Date_8.ToString()).Selected = true; }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList Calendar_M_9 = (DropDownList)e.Row.FindControl("Calendar_M_9");
                for (int i = 1; i <= 30; i++)
                {
                    ListItem li = new ListItem(i.ToString());
                    if (i <= 9) { Calendar_M_9.Items.Add("0" + li); } else { Calendar_M_9.Items.Add(li); }
                }
                Calendar_M_9.Items.Insert(0, "إختر ...");

                string M_9 = DataBinder.Eval(e.Row.DataItem, "M_9").ToString();
                string[] Arr_M_9 = M_9.Split('/');
                string Selected_Date_9 = Arr_M_9[0];
                if (Selected_Date_9 != "") { Calendar_M_9.Items.FindByText(Selected_Date_9.ToString()).Selected = true; }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList Calendar_M_10 = (DropDownList)e.Row.FindControl("Calendar_M_10");
                for (int i = 1; i <= 31; i++)
                {
                    ListItem li = new ListItem(i.ToString());
                    if (i <= 9) { Calendar_M_10.Items.Add("0" + li); } else { Calendar_M_10.Items.Add(li); }
                }
                Calendar_M_10.Items.Insert(0, "إختر ...");

                string M_10 = DataBinder.Eval(e.Row.DataItem, "M_10").ToString();
                string[] Arr_M_10 = M_10.Split('/');
                string Selected_Date_10 = Arr_M_10[0];
                if (Selected_Date_10 != "") { Calendar_M_10.Items.FindByText(Selected_Date_10.ToString()).Selected = true; }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList Calendar_M_11 = (DropDownList)e.Row.FindControl("Calendar_M_11");
                for (int i = 1; i <= 30; i++)
                {
                    ListItem li = new ListItem(i.ToString());
                    if (i <= 9) { Calendar_M_11.Items.Add("0" + li); } else { Calendar_M_11.Items.Add(li); }
                }
                Calendar_M_11.Items.Insert(0, "إختر ...");

                string M_11 = DataBinder.Eval(e.Row.DataItem, "M_11").ToString();
                string[] Arr_M_11 = M_11.Split('/');
                string Selected_Date_11 = Arr_M_11[0];
                if (Selected_Date_11 != "") { Calendar_M_11.Items.FindByText(Selected_Date_11.ToString()).Selected = true; }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList Calendar_M_12 = (DropDownList)e.Row.FindControl("Calendar_M_12");
                for (int i = 1; i <= 31; i++)
                {
                    ListItem li = new ListItem(i.ToString());
                    if (i <= 9) { Calendar_M_12.Items.Add("0" + li); } else { Calendar_M_12.Items.Add(li); }
                }
                Calendar_M_12.Items.Insert(0, "إختر ...");

                string M_12 = DataBinder.Eval(e.Row.DataItem, "M_12").ToString();
                string[] Arr_M_12 = M_12.Split('/');
                string Selected_Date_12 = Arr_M_12[0];
                if (Selected_Date_12 != "") { Calendar_M_12.Items.FindByText(Selected_Date_12.ToString()).Selected = true; }
            }

            // ****************************************  Fill The Employee DropDownList   *************************************************
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList DropDownList_E_M_1 = (DropDownList)e.Row.FindControl("DropDownList_E_M_1");
                string W_atcherl_query = "SELECT * FROM employee ";
                using (MySqlDataAdapter sda = new MySqlDataAdapter(W_atcherl_query, _sqlCon))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        DropDownList_E_M_1.DataSource = dt;
                        DropDownList_E_M_1.DataTextField = "Employee_Arabic_name";
                        DropDownList_E_M_1.DataValueField = "Employee_Id";
                        DropDownList_E_M_1.DataBind();
                        DropDownList_E_M_1.Items.Insert(0, "أختر إسم الموظف ....");
                        string selected_Employee = DataBinder.Eval(e.Row.DataItem, "E_M_1").ToString();
                        if (selected_Employee != "") { DropDownList_E_M_1.Items.FindByValue(selected_Employee).Selected = true; }

                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList DropDownList_E_M_2 = (DropDownList)e.Row.FindControl("DropDownList_E_M_2");
                string W_atcherl_query = "SELECT * FROM employee ";
                using (MySqlDataAdapter sda = new MySqlDataAdapter(W_atcherl_query, _sqlCon))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        DropDownList_E_M_2.DataSource = dt;
                        DropDownList_E_M_2.DataTextField = "Employee_Arabic_name";
                        DropDownList_E_M_2.DataValueField = "Employee_Id";
                        DropDownList_E_M_2.DataBind();
                        DropDownList_E_M_2.Items.Insert(0, "أختر إسم الموظف ....");
                        string selected_Employee = DataBinder.Eval(e.Row.DataItem, "E_M_2").ToString();
                        if (selected_Employee != "")
                        {
                            DropDownList_E_M_2.Items.FindByValue(selected_Employee).Selected = true;
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList DropDownList_E_M_3 = (DropDownList)e.Row.FindControl("DropDownList_E_M_3");
                string W_atcherl_query = "SELECT * FROM employee ";
                using (MySqlDataAdapter sda = new MySqlDataAdapter(W_atcherl_query, _sqlCon))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        DropDownList_E_M_3.DataSource = dt;
                        DropDownList_E_M_3.DataTextField = "Employee_Arabic_name";
                        DropDownList_E_M_3.DataValueField = "Employee_Id";
                        DropDownList_E_M_3.DataBind();
                        DropDownList_E_M_3.Items.Insert(0, "أختر إسم الموظف ....");
                        string selected_Employee = DataBinder.Eval(e.Row.DataItem, "E_M_3").ToString();
                        if (selected_Employee != "")
                        {
                            DropDownList_E_M_3.Items.FindByValue(selected_Employee).Selected = true;
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList DropDownList_E_M_4 = (DropDownList)e.Row.FindControl("DropDownList_E_M_4");
                string W_atcherl_query = "SELECT * FROM employee ";
                using (MySqlDataAdapter sda = new MySqlDataAdapter(W_atcherl_query, _sqlCon))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        DropDownList_E_M_4.DataSource = dt;
                        DropDownList_E_M_4.DataTextField = "Employee_Arabic_name";
                        DropDownList_E_M_4.DataValueField = "Employee_Id";
                        DropDownList_E_M_4.DataBind();
                        DropDownList_E_M_4.Items.Insert(0, "أختر إسم الموظف ....");
                        string selected_Employee = DataBinder.Eval(e.Row.DataItem, "E_M_4").ToString();
                        if (selected_Employee != "")
                        {
                            DropDownList_E_M_4.Items.FindByValue(selected_Employee).Selected = true;
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList DropDownList_E_M_5 = (DropDownList)e.Row.FindControl("DropDownList_E_M_5");
                string W_atcherl_query = "SELECT * FROM employee ";
                using (MySqlDataAdapter sda = new MySqlDataAdapter(W_atcherl_query, _sqlCon))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        DropDownList_E_M_5.DataSource = dt;
                        DropDownList_E_M_5.DataTextField = "Employee_Arabic_name";
                        DropDownList_E_M_5.DataValueField = "Employee_Id";
                        DropDownList_E_M_5.DataBind();
                        DropDownList_E_M_5.Items.Insert(0, "أختر إسم الموظف ....");
                        string selected_Employee = DataBinder.Eval(e.Row.DataItem, "E_M_5").ToString();
                        if (selected_Employee != "")
                        {
                            DropDownList_E_M_5.Items.FindByValue(selected_Employee).Selected = true;
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList DropDownList_E_M_6 = (DropDownList)e.Row.FindControl("DropDownList_E_M_6");
                string W_atcherl_query = "SELECT * FROM employee ";
                using (MySqlDataAdapter sda = new MySqlDataAdapter(W_atcherl_query, _sqlCon))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        DropDownList_E_M_6.DataSource = dt;
                        DropDownList_E_M_6.DataTextField = "Employee_Arabic_name";
                        DropDownList_E_M_6.DataValueField = "Employee_Id";
                        DropDownList_E_M_6.DataBind();
                        DropDownList_E_M_6.Items.Insert(0, "أختر إسم الموظف ....");
                        string selected_Employee = DataBinder.Eval(e.Row.DataItem, "E_M_6").ToString();
                        if (selected_Employee != "")
                        {
                            DropDownList_E_M_6.Items.FindByValue(selected_Employee).Selected = true;
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList DropDownList_E_M_7 = (DropDownList)e.Row.FindControl("DropDownList_E_M_7");
                string W_atcherl_query = "SELECT * FROM employee ";
                using (MySqlDataAdapter sda = new MySqlDataAdapter(W_atcherl_query, _sqlCon))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        DropDownList_E_M_7.DataSource = dt;
                        DropDownList_E_M_7.DataTextField = "Employee_Arabic_name";
                        DropDownList_E_M_7.DataValueField = "Employee_Id";
                        DropDownList_E_M_7.DataBind();
                        DropDownList_E_M_7.Items.Insert(0, "أختر إسم الموظف ....");
                        string selected_Employee = DataBinder.Eval(e.Row.DataItem, "E_M_7").ToString();
                        if (selected_Employee != "")
                        {
                            DropDownList_E_M_7.Items.FindByValue(selected_Employee).Selected = true;
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList DropDownList_E_M_8 = (DropDownList)e.Row.FindControl("DropDownList_E_M_8");
                string W_atcherl_query = "SELECT * FROM employee ";
                using (MySqlDataAdapter sda = new MySqlDataAdapter(W_atcherl_query, _sqlCon))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        DropDownList_E_M_8.DataSource = dt;
                        DropDownList_E_M_8.DataTextField = "Employee_Arabic_name";
                        DropDownList_E_M_8.DataValueField = "Employee_Id";
                        DropDownList_E_M_8.DataBind();
                        DropDownList_E_M_8.Items.Insert(0, "أختر إسم الموظف ....");
                        string selected_Employee = DataBinder.Eval(e.Row.DataItem, "E_M_8").ToString();
                        if (selected_Employee != "")
                        {
                            DropDownList_E_M_8.Items.FindByValue(selected_Employee).Selected = true;
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList DropDownList_E_M_9 = (DropDownList)e.Row.FindControl("DropDownList_E_M_9");
                string W_atcherl_query = "SELECT * FROM employee ";
                using (MySqlDataAdapter sda = new MySqlDataAdapter(W_atcherl_query, _sqlCon))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        DropDownList_E_M_9.DataSource = dt;
                        DropDownList_E_M_9.DataTextField = "Employee_Arabic_name";
                        DropDownList_E_M_9.DataValueField = "Employee_Id";
                        DropDownList_E_M_9.DataBind();
                        DropDownList_E_M_9.Items.Insert(0, "أختر إسم الموظف ....");
                        string selected_Employee = DataBinder.Eval(e.Row.DataItem, "E_M_9").ToString();
                        if (selected_Employee != "")
                        {
                            DropDownList_E_M_9.Items.FindByValue(selected_Employee).Selected = true;
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList DropDownList_E_M_10 = (DropDownList)e.Row.FindControl("DropDownList_E_M_10");
                string W_atcherl_query = "SELECT * FROM employee ";
                using (MySqlDataAdapter sda = new MySqlDataAdapter(W_atcherl_query, _sqlCon))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        DropDownList_E_M_10.DataSource = dt;
                        DropDownList_E_M_10.DataTextField = "Employee_Arabic_name";
                        DropDownList_E_M_10.DataValueField = "Employee_Id";
                        DropDownList_E_M_10.DataBind();
                        DropDownList_E_M_10.Items.Insert(0, "أختر إسم الموظف ....");
                        string selected_Employee = DataBinder.Eval(e.Row.DataItem, "E_M_10").ToString();
                        if (selected_Employee != "")
                        {
                            DropDownList_E_M_10.Items.FindByValue(selected_Employee).Selected = true;
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList DropDownList_E_M_11 = (DropDownList)e.Row.FindControl("DropDownList_E_M_11");
                string W_atcherl_query = "SELECT * FROM employee ";
                using (MySqlDataAdapter sda = new MySqlDataAdapter(W_atcherl_query, _sqlCon))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        DropDownList_E_M_11.DataSource = dt;
                        DropDownList_E_M_11.DataTextField = "Employee_Arabic_name";
                        DropDownList_E_M_11.DataValueField = "Employee_Id";
                        DropDownList_E_M_11.DataBind();
                        DropDownList_E_M_11.Items.Insert(0, "أختر إسم الموظف ....");
                        string selected_Employee = DataBinder.Eval(e.Row.DataItem, "E_M_11").ToString();
                        if (selected_Employee != "")
                        {
                            DropDownList_E_M_11.Items.FindByValue(selected_Employee).Selected = true;
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && Periodic_Maintenence_List.EditIndex == e.Row.RowIndex)
            {
                DropDownList DropDownList_E_M_12 = (DropDownList)e.Row.FindControl("DropDownList_E_M_12");
                string W_atcherl_query = "SELECT * FROM employee ";
                using (MySqlDataAdapter sda = new MySqlDataAdapter(W_atcherl_query, _sqlCon))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        DropDownList_E_M_12.DataSource = dt;
                        DropDownList_E_M_12.DataTextField = "Employee_Arabic_name";
                        DropDownList_E_M_12.DataValueField = "Employee_Id";
                        DropDownList_E_M_12.DataBind();
                        DropDownList_E_M_12.Items.Insert(0, "أختر إسم الموظف ....");
                        string selected_Employee = DataBinder.Eval(e.Row.DataItem, "E_M_12").ToString();
                        if (selected_Employee != "")
                        {
                            DropDownList_E_M_12.Items.FindByValue(selected_Employee).Selected = true;
                        }
                    }
                }
            }
        }
        protected void EditCustomer(object sender, GridViewEditEventArgs e)
        { Periodic_Maintenence_List.EditIndex = e.NewEditIndex; this.BindGrid_Contract_Cheque_List(); }
        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        { Periodic_Maintenence_List.EditIndex = -1; this.BindGrid_Contract_Cheque_List(); }
        protected void UpdateCustomer(object sender, GridViewUpdateEventArgs e)
        {
            string DropDownList_E_M_1 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("DropDownList_E_M_1") as DropDownList).SelectedValue;
            string DropDownList_E_M_2 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("DropDownList_E_M_2") as DropDownList).SelectedValue;
            string DropDownList_E_M_3 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("DropDownList_E_M_3") as DropDownList).SelectedValue;
            string DropDownList_E_M_4 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("DropDownList_E_M_4") as DropDownList).SelectedValue;
            string DropDownList_E_M_5 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("DropDownList_E_M_5") as DropDownList).SelectedValue;
            string DropDownList_E_M_6 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("DropDownList_E_M_6") as DropDownList).SelectedValue;
            string DropDownList_E_M_7 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("DropDownList_E_M_7") as DropDownList).SelectedValue;
            string DropDownList_E_M_8 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("DropDownList_E_M_8") as DropDownList).SelectedValue;
            string DropDownList_E_M_9 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("DropDownList_E_M_9") as DropDownList).SelectedValue;
            string DropDownList_E_M_10 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("DropDownList_E_M_10") as DropDownList).SelectedValue;
            string DropDownList_E_M_11 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("DropDownList_E_M_11") as DropDownList).SelectedValue;
            string DropDownList_E_M_12 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("DropDownList_E_M_12") as DropDownList).SelectedValue;

            TextBox TextBox_D_M_1 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("TextBox_D_M_1") as TextBox);
            TextBox TextBox_D_M_2 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("TextBox_D_M_2") as TextBox);
            TextBox TextBox_D_M_3 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("TextBox_D_M_3") as TextBox);
            TextBox TextBox_D_M_4 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("TextBox_D_M_4") as TextBox);
            TextBox TextBox_D_M_5 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("TextBox_D_M_5") as TextBox);
            TextBox TextBox_D_M_6 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("TextBox_D_M_6") as TextBox);
            TextBox TextBox_D_M_7 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("TextBox_D_M_7") as TextBox);
            TextBox TextBox_D_M_8 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("TextBox_D_M_8") as TextBox);
            TextBox TextBox_D_M_9 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("TextBox_D_M_9") as TextBox);
            TextBox TextBox_D_M_10 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("TextBox_D_M_10") as TextBox);
            TextBox TextBox_D_M_11 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("TextBox_D_M_11") as TextBox);
            TextBox TextBox_D_M_12 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("TextBox_D_M_12") as TextBox);


            string Calendar_M_1 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("Calendar_M_1") as DropDownList).SelectedValue;
            string Calendar_M_2 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("Calendar_M_2") as DropDownList).SelectedValue;
            string Calendar_M_3 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("Calendar_M_3") as DropDownList).SelectedValue;
            string Calendar_M_4 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("Calendar_M_4") as DropDownList).SelectedValue;
            string Calendar_M_5 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("Calendar_M_5") as DropDownList).SelectedValue;
            string Calendar_M_6 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("Calendar_M_6") as DropDownList).SelectedValue;
            string Calendar_M_7 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("Calendar_M_7") as DropDownList).SelectedValue;
            string Calendar_M_8 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("Calendar_M_8") as DropDownList).SelectedValue;
            string Calendar_M_9 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("Calendar_M_9") as DropDownList).SelectedValue;
            string Calendar_M_10 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("Calendar_M_10") as DropDownList).SelectedValue;
            string Calendar_M_11 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("Calendar_M_11") as DropDownList).SelectedValue;
            string Calendar_M_12 = (Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("Calendar_M_12") as DropDownList).SelectedValue;

            string Periodic_Maintenence_Id = Periodic_Maintenence_List.DataKeys[e.RowIndex].Value.ToString();

            string query = "UPDATE periodic_maintenence SET" +
                            " M_1 = @M_1 ," +
                            " E_M_1 = @E_M_1 ," +
                            " D_M_1 = @D_M_1 ," +

                             " M_2 = @M_2 ," +
                            " E_M_2 = @E_M_2 ," +
                            " D_M_2 = @D_M_2 ," +

                             " M_3 = @M_3 ," +
                            " E_M_3 = @E_M_3 ," +
                            " D_M_3 = @D_M_3 ," +

                             " M_4 = @M_4 ," +
                            " E_M_4 = @E_M_4 ," +
                            " D_M_4 = @D_M_4 ," +

                             " M_5 = @M_5 ," +
                            " E_M_5 = @E_M_5 ," +
                            " D_M_5 = @D_M_5 ," +

                             " M_6 = @M_6 ," +
                            " E_M_6 = @E_M_6 ," +
                            " D_M_6 = @D_M_6 ," +

                             " M_7 = @M_7 ," +
                            " E_M_7 = @E_M_7 ," +
                            " D_M_7 = @D_M_7 ," +

                             " M_8 = @M_8 ," +
                            " E_M_8 = @E_M_8 ," +
                            " D_M_8 = @D_M_8 ," +

                             " M_9 = @M_9 ," +
                            " E_M_9 = @E_M_9 ," +
                            " D_M_9 = @D_M_9 ," +

                             " M_10 = @M_10 ," +
                            " E_M_10 = @E_M_10 ," +
                            " D_M_10 = @D_M_10 ," +

                             " M_11 = @M_11 ," +
                            " E_M_11 = @E_M_11 ," +
                            " D_M_11 = @D_M_11 ," +

                             " M_12 = @M_12 ," +
                            " E_M_12 = @E_M_12 ," +
                            " D_M_12 = @D_M_12 ," +

                            " Last_Periodic_Maintenance_Date = @Last_Periodic_Maintenance_Date " +

                            "WHERE Periodic_Maintenence_ID = @Periodic_Maintenence_ID";
            using (MySqlCommand cmd = new MySqlCommand(query, _sqlCon))
            {
                cmd.Parameters.AddWithValue("@Periodic_Maintenence_ID", Periodic_Maintenence_Id);
                if (DropDownList_E_M_1 == "أختر إسم الموظف ....") { cmd.Parameters.AddWithValue("@E_M_1", ""); } else { cmd.Parameters.AddWithValue("@E_M_1", DropDownList_E_M_1); }
                if (DropDownList_E_M_2 == "أختر إسم الموظف ....") { cmd.Parameters.AddWithValue("@E_M_2", ""); } else { cmd.Parameters.AddWithValue("@E_M_2", DropDownList_E_M_2); }
                if (DropDownList_E_M_3 == "أختر إسم الموظف ....") { cmd.Parameters.AddWithValue("@E_M_3", ""); } else { cmd.Parameters.AddWithValue("@E_M_3", DropDownList_E_M_3); }
                if (DropDownList_E_M_4 == "أختر إسم الموظف ....") { cmd.Parameters.AddWithValue("@E_M_4", ""); } else { cmd.Parameters.AddWithValue("@E_M_4", DropDownList_E_M_4); }
                if (DropDownList_E_M_5 == "أختر إسم الموظف ....") { cmd.Parameters.AddWithValue("@E_M_5", ""); } else { cmd.Parameters.AddWithValue("@E_M_5", DropDownList_E_M_5); }
                if (DropDownList_E_M_6 == "أختر إسم الموظف ....") { cmd.Parameters.AddWithValue("@E_M_6", ""); } else { cmd.Parameters.AddWithValue("@E_M_6", DropDownList_E_M_6); }
                if (DropDownList_E_M_7 == "أختر إسم الموظف ....") { cmd.Parameters.AddWithValue("@E_M_7", ""); } else { cmd.Parameters.AddWithValue("@E_M_7", DropDownList_E_M_7); }
                if (DropDownList_E_M_8 == "أختر إسم الموظف ....") { cmd.Parameters.AddWithValue("@E_M_8", ""); } else { cmd.Parameters.AddWithValue("@E_M_8", DropDownList_E_M_8); }
                if (DropDownList_E_M_9 == "أختر إسم الموظف ....") { cmd.Parameters.AddWithValue("@E_M_9", ""); } else { cmd.Parameters.AddWithValue("@E_M_9", DropDownList_E_M_9); }
                if (DropDownList_E_M_10 == "أختر إسم الموظف ....") { cmd.Parameters.AddWithValue("@E_M_10", ""); } else { cmd.Parameters.AddWithValue("@E_M_10", DropDownList_E_M_10); }
                if (DropDownList_E_M_11 == "أختر إسم الموظف ....") { cmd.Parameters.AddWithValue("@E_M_11", ""); } else { cmd.Parameters.AddWithValue("@E_M_11", DropDownList_E_M_11); }
                if (DropDownList_E_M_12 == "أختر إسم الموظف ....") { cmd.Parameters.AddWithValue("@E_M_12", ""); } else { cmd.Parameters.AddWithValue("@E_M_12", DropDownList_E_M_12); }

                if (Calendar_M_1 == "إختر ...") { cmd.Parameters.AddWithValue("@M_1", ""); } else { cmd.Parameters.AddWithValue("@M_1", Calendar_M_1 + "/01/" + Year_DropDownList.SelectedItem.Text.Trim()); }
                if (Calendar_M_2 == "إختر ...") { cmd.Parameters.AddWithValue("@M_2", ""); } else { cmd.Parameters.AddWithValue("@M_2", Calendar_M_2 + "/02/" + Year_DropDownList.SelectedItem.Text.Trim()); }
                if (Calendar_M_3 == "إختر ...") { cmd.Parameters.AddWithValue("@M_3", ""); } else { cmd.Parameters.AddWithValue("@M_3", Calendar_M_3 + "/03/" + Year_DropDownList.SelectedItem.Text.Trim()); }
                if (Calendar_M_4 == "إختر ...") { cmd.Parameters.AddWithValue("@M_4", ""); } else { cmd.Parameters.AddWithValue("@M_4", Calendar_M_4 + "/04/" + Year_DropDownList.SelectedItem.Text.Trim()); }
                if (Calendar_M_5 == "إختر ...") { cmd.Parameters.AddWithValue("@M_5", ""); } else { cmd.Parameters.AddWithValue("@M_5", Calendar_M_5 + "/05/" + Year_DropDownList.SelectedItem.Text.Trim()); }
                if (Calendar_M_6 == "إختر ...") { cmd.Parameters.AddWithValue("@M_6", ""); } else { cmd.Parameters.AddWithValue("@M_6", Calendar_M_6 + "/06/" + Year_DropDownList.SelectedItem.Text.Trim()); }
                if (Calendar_M_7 == "إختر ...") { cmd.Parameters.AddWithValue("@M_7", ""); } else { cmd.Parameters.AddWithValue("@M_7", Calendar_M_7 + "/07/" + Year_DropDownList.SelectedItem.Text.Trim()); }
                if (Calendar_M_8 == "إختر ...") { cmd.Parameters.AddWithValue("@M_8", ""); } else { cmd.Parameters.AddWithValue("@M_8", Calendar_M_8 + "/08/" + Year_DropDownList.SelectedItem.Text.Trim()); }
                if (Calendar_M_9 == "إختر ...") { cmd.Parameters.AddWithValue("@M_9", ""); } else { cmd.Parameters.AddWithValue("@M_9", Calendar_M_9 + "/09/" + Year_DropDownList.SelectedItem.Text.Trim()); }
                if (Calendar_M_10 == "إختر ...") { cmd.Parameters.AddWithValue("@M_10", ""); } else { cmd.Parameters.AddWithValue("@M_10", Calendar_M_10 + "/10/" + Year_DropDownList.SelectedItem.Text.Trim()); }
                if (Calendar_M_11 == "إختر ...") { cmd.Parameters.AddWithValue("@M_11", ""); } else { cmd.Parameters.AddWithValue("@M_11", Calendar_M_11 + "/11/" + Year_DropDownList.SelectedItem.Text.Trim()); }
                if (Calendar_M_12 == "إختر ...") { cmd.Parameters.AddWithValue("@M_12", ""); } else { cmd.Parameters.AddWithValue("@M_12", Calendar_M_12 + "/12/" + Year_DropDownList.SelectedItem.Text.Trim()); }


                cmd.Parameters.AddWithValue("@D_M_1", TextBox_D_M_1.Text);
                cmd.Parameters.AddWithValue("@D_M_2", TextBox_D_M_2.Text);
                cmd.Parameters.AddWithValue("@D_M_3", TextBox_D_M_3.Text);
                cmd.Parameters.AddWithValue("@D_M_4", TextBox_D_M_4.Text);
                cmd.Parameters.AddWithValue("@D_M_5", TextBox_D_M_5.Text);
                cmd.Parameters.AddWithValue("@D_M_6", TextBox_D_M_6.Text);
                cmd.Parameters.AddWithValue("@D_M_7", TextBox_D_M_7.Text);
                cmd.Parameters.AddWithValue("@D_M_8", TextBox_D_M_8.Text);
                cmd.Parameters.AddWithValue("@D_M_9", TextBox_D_M_9.Text);
                cmd.Parameters.AddWithValue("@D_M_10", TextBox_D_M_10.Text);
                cmd.Parameters.AddWithValue("@D_M_11", TextBox_D_M_11.Text);
                cmd.Parameters.AddWithValue("@D_M_12", TextBox_D_M_12.Text);
                cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", "");
                _sqlCon.Open();
                cmd.ExecuteNonQuery();
                _sqlCon.Close();
                Periodic_Maintenence_List.EditIndex = -1; this.BindGrid_Contract_Cheque_List();
            }
            string Last_Periodic_Maintenance_Date_query = "UPDATE periodic_maintenence SET Last_Periodic_Maintenance_Date = @Last_Periodic_Maintenance_Date WHERE Periodic_Maintenence_ID = @Periodic_Maintenence_ID";
            using (MySqlCommand Last_Periodic_Maintenance_Date_cmd = new MySqlCommand(Last_Periodic_Maintenance_Date_query, _sqlCon))
            {
                Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Periodic_Maintenence_ID", Periodic_Maintenence_Id);

                if ((Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("lbl_M_12") as Label).Text != "")
                {
                    if (Calendar_M_12 == "إختر ...") { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", ""); } else { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", Calendar_M_12 + "/12/" + Year_DropDownList.SelectedItem.Text.Trim()); }
                }
                else if ((Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("lbl_M_11") as Label).Text != "")
                {
                    if (Calendar_M_11 == "إختر ...") { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", ""); } else { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", Calendar_M_11 + "/11/" + Year_DropDownList.SelectedItem.Text.Trim()); }
                }
                else if ((Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("lbl_M_10") as Label).Text != "")
                {
                    if (Calendar_M_10 == "إختر ...") { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", ""); } else { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", Calendar_M_10 + "/10/" + Year_DropDownList.SelectedItem.Text.Trim()); }
                }
                else if ((Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("lbl_M_9") as Label).Text != "")
                {
                    if (Calendar_M_9 == "إختر ...") { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", ""); } else { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", Calendar_M_9 + "/9/" + Year_DropDownList.SelectedItem.Text.Trim()); }
                }
                else if ((Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("lbl_M_8") as Label).Text != "")
                {
                    if (Calendar_M_8 == "إختر ...") { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", ""); } else { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", Calendar_M_8 + "/08/" + Year_DropDownList.SelectedItem.Text.Trim()); }
                }
                else if ((Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("lbl_M_7") as Label).Text != "")
                {
                    if (Calendar_M_7 == "إختر ...") { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", ""); } else { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", Calendar_M_7 + "/07/" + Year_DropDownList.SelectedItem.Text.Trim()); }
                }
                else if ((Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("lbl_M_6") as Label).Text != "")
                {
                    if (Calendar_M_6 == "إختر ...") { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", ""); } else { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", Calendar_M_6 + "/06/" + Year_DropDownList.SelectedItem.Text.Trim()); }
                }
                else if ((Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("lbl_M_5") as Label).Text != "")
                {
                    if (Calendar_M_5 == "إختر ...") { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", ""); } else { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", Calendar_M_5 + "/05/" + Year_DropDownList.SelectedItem.Text.Trim()); }
                }
                else if ((Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("lbl_M_4") as Label).Text != "")
                {
                    if (Calendar_M_4 == "إختر ...") { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", ""); } else { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", Calendar_M_4 + "/04/" + Year_DropDownList.SelectedItem.Text.Trim()); }
                }
                else if ((Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("lbl_M_3") as Label).Text != "")
                {
                    if (Calendar_M_3 == "إختر ...") { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", ""); } else { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", Calendar_M_3 + "/03/" + Year_DropDownList.SelectedItem.Text.Trim()); }
                }
                else if ((Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("lbl_M_2") as Label).Text != "")
                {
                    if (Calendar_M_2 == "إختر ...") { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", ""); } else { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", Calendar_M_2 + "/02/" + Year_DropDownList.SelectedItem.Text.Trim()); }
                }
                else if ((Periodic_Maintenence_List.Rows[e.RowIndex].FindControl("lbl_M_1") as Label).Text != "")
                {
                    if (Calendar_M_1 == "إختر ...") { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", ""); } else { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", Calendar_M_1 + "/01/" + Year_DropDownList.SelectedItem.Text.Trim()); }
                }
                else { Last_Periodic_Maintenance_Date_cmd.Parameters.AddWithValue("@Last_Periodic_Maintenance_Date", ""); }
                _sqlCon.Open();
                Last_Periodic_Maintenance_Date_cmd.ExecuteNonQuery();
                _sqlCon.Close();
                Periodic_Maintenence_List.EditIndex = -1; this.BindGrid_Contract_Cheque_List();
            }

        }

        protected void Search_Btn_Click(object sender, EventArgs e)
        {
            this.BindGrid_Contract_Cheque_List();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _sqlCon.Open();
            string ContractId = Last_Years_DropDownList.SelectedItem.Text.Trim();
            using (MySqlCommand Contract_ChequesCmd = new MySqlCommand("Periodec_Maintenance", _sqlCon))
            {
                Contract_ChequesCmd.CommandType = CommandType.StoredProcedure;
                Contract_ChequesCmd.Parameters.AddWithValue("@Id", ContractId);
                Contract_ChequesCmd.Parameters.AddWithValue("@O_Id", txtSearch.Text.Trim());
                Contract_ChequesCmd.Parameters.AddWithValue("@B_Id", txtSearch.Text.Trim());
                MySqlDataAdapter Contract_ChequesSda = new MySqlDataAdapter(Contract_ChequesCmd);

                DataTable Contract_ChequesDt = new DataTable();
                Contract_ChequesSda.Fill(Contract_ChequesDt);
                Contract_ChequesCmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                Contract_ChequesSda.Fill(dt);
                Periodic_Maintenence_List.DataSource = dt;
                Periodic_Maintenence_List.DataBind();
            }
            _sqlCon.Close();
        }
    }
}