using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Periodec_Maintenance_New : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Fill Employee_DropDownList
                Helper.LoadDropDownList("SELECT * FROM employee", _sqlCon, Employee_DropDownList, "Employee_Arabic_name", "Employee_Id");
                Employee_DropDownList.Items.Insert(0, "إختر الموظف المسؤول ....");


                Asset_List_BindData();
                Periodec_Maintenance_BindData();
            }
        }
        protected void Asset_List_BindData(string sortExpression = null)
        {
            using (MySqlCommand cmd = new MySqlCommand("Periodec_Maintenance_New", _sqlCon))
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    Assset_List_1.DataSource = dt;
                    Assset_List_1.DataBind();
                }
            }
        }
        protected void Periodec_Maintenance_BindData(string sortExpression = null)
        {
            foreach (RepeaterItem item in Assset_List_1.Items)
            {
                Repeater Maintenance_Repeater = item.FindControl("Maintenance_Repeater") as Repeater;
                Label lbl_Assets_Id = item.FindControl("lbl_Assets_Id") as Label;
                string CasestQuery = "SELECT PM.* , E.Employee_Arabic_name FROM periodec_maintenance_new PM left join employee E on (PM.Employee_ID = E.Employee_Id) where Aseet_ID = '" + lbl_Assets_Id.Text+ "'";
                Helper.GetDataReader(CasestQuery, _sqlCon, Maintenance_Repeater);
            }
        }
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Add.Visible = true;
            _sqlCon.Open();
            lbl_Add_Maintenance.Text = "إضافة صيانة دورية للأصل : ";
            string Asset_ID = (sender as LinkButton).CommandArgument;
            ID.Text = Asset_ID;
            DataTable Dt = new DataTable();
            MySqlCommand Cmd = new MySqlCommand("SELECT Assets_Id , Assets_Arabic_Name , Serial_Number  FROM assets WHERE Assets_Id = @ID",  _sqlCon);
            MySqlDataAdapter Da = new MySqlDataAdapter(Cmd);
            Cmd.Parameters.AddWithValue("@ID", Asset_ID);
            Da.Fill(Dt);if (Dt.Rows.Count > 0) {txt_Asset_Name.Text = Dt.Rows[0]["Assets_Arabic_Name"].ToString()+" "+"/"+" "+ Dt.Rows[0]["Serial_Number"].ToString(); }
            _sqlCon.Close();
        }

        protected void btn_Add_Maintenance_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                _sqlCon.Open();
                //******************** Add New periodec_maintenance  *******************************************************************
                string Quary =  "Insert Into periodec_maintenance_new (Aseet_ID,Employee_ID,Datre,Notic) VALUES (@Aseet_ID,@Employee_ID,@Datre,@Notic)";
                MySqlCommand Cmd = new MySqlCommand(Quary, _sqlCon);
                Cmd.Parameters.AddWithValue("@Aseet_ID", ID.Text);
                Cmd.Parameters.AddWithValue("@Employee_ID", Employee_DropDownList.SelectedValue);
                Cmd.Parameters.AddWithValue("@Datre", txt_Date.Text);
                Cmd.Parameters.AddWithValue("@Notic", txt_Notic.Text);
                Cmd.ExecuteNonQuery();
                //******************** Update Last periodec_maintenance Date *******************************************************************
                string Quary2 = "UPDATE assets SET Last_periodec_maintenance=@Last_periodec_maintenance WHERE Assets_Id=@ID ";
                MySqlCommand Cmd2 = new MySqlCommand(Quary2, _sqlCon);
                Cmd2.Parameters.AddWithValue("@ID", ID.Text);
                Cmd2.Parameters.AddWithValue("@Last_periodec_maintenance", txt_Date.Text);
                Cmd2.ExecuteNonQuery();
                _sqlCon.Close();
                Add.Visible = false;
                Response.Redirect(Request.RawUrl);
            }
        }





        //******************  Date ***************************************************
        protected void Sign_Date_Calendar_SelectionChanged1(object sender, EventArgs e)
        {Utilities.Helper.Calendar_SelectionChanged(txt_Date, Date_Calendar, Cal_Close, Date_divCalendar);}
        protected void Date_Chosee_Click(object sender, EventArgs e)
        {Utilities.Helper.Date_Chosee_Click(Cal_Close, Date_divCalendar);}
        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        { Utilities.Helper.cal_Close(Cal_Close, Date_divCalendar); }

        protected void Assset_List_1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Image Image1 = e.Item.FindControl("Image1") as Image;
                Label Last_periodec_maintenance = e.Item.FindControl("lbl_Last_Maintanance") as Label;
                if (Last_periodec_maintenance.Text != "")
                {
                    DateTime Today = DateTime.Now;
                    DateTime LastMaintenance = Convert.ToDateTime(Last_periodec_maintenance.Text);
                    int difference_between_dates = (int)(Today - LastMaintenance).TotalDays;
                    string lbl_Assets_Id = ((Label)e.Item.FindControl("lbl_Assets_Id")).Text;
                    DataTable getAssetDt = new DataTable();
                    MySqlCommand getAssetCmd = new MySqlCommand("SELECT * FROM assets WHERE Assets_Id = @ID", _sqlCon);
                    MySqlDataAdapter getAssetDa = new MySqlDataAdapter(getAssetCmd);
                    getAssetCmd.Parameters.AddWithValue("@ID", lbl_Assets_Id);
                    getAssetDa.Fill(getAssetDt);
                    if (getAssetDt.Rows[0]["maintenance_categoty_Categoty_Id"].ToString() == "15")
                    {
                        if (difference_between_dates >= 180)
                        {
                            Image1.Visible = true;
                            Last_periodec_maintenance.ForeColor = System.Drawing.Color.Red;
                            Last_periodec_maintenance.Font.Bold = true;
                        }
                        else
                        { 
                            Image1.Visible = false;
                            Last_periodec_maintenance.ForeColor = System.Drawing.Color.Black;
                            Last_periodec_maintenance.Font.Bold = false;
                        }
                    }
                    else if (getAssetDt.Rows[0]["maintenance_categoty_Categoty_Id"].ToString() == "13" || getAssetDt.Rows[0]["maintenance_categoty_Categoty_Id"].ToString() == "36")
                    {
                        if (difference_between_dates >= 90)
                        {
                            Image1.Visible = true;
                            Last_periodec_maintenance.ForeColor = System.Drawing.Color.Red;
                            Last_periodec_maintenance.Font.Bold = true;
                        }
                        else
                        {
                            Image1.Visible = false;
                            Last_periodec_maintenance.ForeColor = System.Drawing.Color.Black;
                            Last_periodec_maintenance.Font.Bold = false;
                        }
                    }
                }
                else
                {
                    Image1.Visible = false;
                    Last_periodec_maintenance.ForeColor = System.Drawing.Color.Black;
                    Last_periodec_maintenance.Font.Bold = false;
                }

            }
        }
    }
}