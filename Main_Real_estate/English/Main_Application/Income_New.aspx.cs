using Main_Real_estate.English.Master_Panal;
using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Income_New : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                lbl_Cash.Text = "كافة الدفعات"; lbl_Transformation.Text = "كافة الحوالات"; lbl_Cheques.Text = "كافة الشيكات";
                Back_To_Same_Filters();
                BindData_All_Cheuqe();
                BindData_All_Transformation();
                BindData_All_Cash();
            }
        }
        protected void BindData_All_Cheuqe(string sortExpression = null)
        {
            //try
            //{
            string Type_e = ""; string Datee = ""; string Datee2 = "";
            if (Singel_Multi_DropDownList.SelectedValue == "1") { Type_e = ""; }
            else if (Singel_Multi_DropDownList.SelectedValue == "2") { Type_e = "A"; }
            else { Type_e = "B"; }

            if (Date_Filter_DropDownList.SelectedValue == "1") { Datee = "01/01/1990"; Datee2 = "31/12/2500"; } 
            else if (Date_Filter_DropDownList.SelectedValue == "3") {
                DateTime currentDate = DateTime.Now;
                Datee = new DateTime(currentDate.Year, currentDate.Month, 1).ToString("dd/MM/yyyy");
                Datee2 = new DateTime(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month)).ToString("dd/MM/yyyy");
            } 
            else { Datee = DateTime.Now.ToString("dd/MM/yyyy"); Datee2 = DateTime.Now.ToString("dd/MM/yyyy"); } //current day
            //++++++++++++++++++++++++++ All_Cheuqes ++++++++++++++++++++++++++++++++++
            using (MySqlCommand cmd = new MySqlCommand("All_Avilabel_Cheuqe", _sqlCon))
            {
                cmd.Parameters.AddWithValue("@Type_e", Type_e);
                cmd.Parameters.AddWithValue("@Datee", Datee);
                cmd.Parameters.AddWithValue("@Datee2", Datee2);
                using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    Avilabel_Cheuqes.DataSource = dt;
                    Avilabel_Cheuqes.DataBind();
                }
            }

            //}catch{Response.Write( @"<script language='javascript'>alert('OOPS!!! The Building List Cannt Display')</script>");}

            
        }
        protected void BindData_All_Transformation(string sortExpression = null)
        {
            string Type_e = ""; string Datee = ""; string Datee2 = "";
            if (Singel_Multi_DropDownList.SelectedValue == "1") { Type_e = ""; }
            else if (Singel_Multi_DropDownList.SelectedValue == "2") { Type_e = "A"; }
            else { Type_e = "B"; }

            if (Date_Filter_DropDownList.SelectedValue == "1") { Datee = "01/01/1990"; Datee2 = "31/12/2500"; }
            else if (Date_Filter_DropDownList.SelectedValue == "3")
            {
                DateTime currentDate = DateTime.Now;
                Datee = new DateTime(currentDate.Year, currentDate.Month, 1).ToString("dd/MM/yyyy");
                Datee2 = new DateTime(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month)).ToString("dd/MM/yyyy");
            }
            else { Datee = DateTime.Now.ToString("dd/MM/yyyy"); Datee2 = DateTime.Now.ToString("dd/MM/yyyy"); } //current day
            using (MySqlCommand cmd = new MySqlCommand("All_Trasformatios", _sqlCon))
            {
                cmd.Parameters.AddWithValue("@Type_e", Type_e);
                cmd.Parameters.AddWithValue("@Datee", Datee);
                cmd.Parameters.AddWithValue("@Datee2", Datee2);
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
        protected void BindData_All_Cash(string sortExpression = null)
        {
            string Type_e = ""; string Datee = ""; string Datee2 = "";
            if (Singel_Multi_DropDownList.SelectedValue == "1") { Type_e = ""; }
            else if (Singel_Multi_DropDownList.SelectedValue == "2") { Type_e = "A"; }
            else { Type_e = "B"; }

            if (Date_Filter_DropDownList.SelectedValue == "1") { Datee = "01/01/1990"; Datee2 = "31/12/2500"; }
            else if (Date_Filter_DropDownList.SelectedValue == "3")
            {
                DateTime currentDate = DateTime.Now;
                Datee = new DateTime(currentDate.Year, currentDate.Month, 1).ToString("dd/MM/yyyy");
                Datee2 = new DateTime(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month)).ToString("dd/MM/yyyy");
            }
            else { Datee = DateTime.Now.ToString("dd/MM/yyyy"); Datee2 = DateTime.Now.ToString("dd/MM/yyyy"); } //current day
            using (MySqlCommand cmd = new MySqlCommand("All_Cash", _sqlCon))
            {
                cmd.Parameters.AddWithValue("@Type_e", Type_e);
                cmd.Parameters.AddWithValue("@Datee", Datee);
                cmd.Parameters.AddWithValue("@Datee2", Datee2);
                using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    Repeater2.DataSource = dt;
                    Repeater2.DataBind();
                }
            }
        }
        protected void Avilabel_Cheuqes_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlTableRow row = e.Item.FindControl("row") as HtmlTableRow;
                Label lbl_cheque_Status = (e.Item.FindControl("lbl_cheque_Status") as Label);
                string Filter = Collected_Or_NotCollected_DropDownList.SelectedValue;
                if (lbl_cheque_Status.Text == "محصل" || lbl_cheque_Status.Text == "محصل بالشيك" || lbl_cheque_Status.Text == "محصل بالتحويل" || lbl_cheque_Status.Text == "محصل نقداً")
                {
                    row.Attributes.Add("style", "background-color:#c5f8eb; ");
                }


                if (Filter == "3")
                {
                    if (lbl_cheque_Status.Text == "محصل بالشيك" || lbl_cheque_Status.Text == "محصل نقداً" || lbl_cheque_Status.Text == "محصل بالتحويل" || lbl_cheque_Status.Text == "محصل")
                    {
                        row.Visible = false;
                    }
                }
                else if (Filter == "2")
                {
                    if (lbl_cheque_Status.Text == "غير محصل" || lbl_cheque_Status.Text == "مؤجل" || lbl_cheque_Status.Text == "مرتجع")
                    {
                        row.Visible = false;
                    }
                }
                else { row.Visible = true; }
            }
        }
        //************************************************************** Filtrin Functions ******************************************************************
        //********************  Cheques , Transformation , Cash Filter ************************************
        protected void A_1_ServerClick(object sender, EventArgs e)
        {
            Cheuqe.Visible = true; Transformation.Visible = false; Cash.Visible = false;
            Cq_T_Ca.Text = "2";
        }
        protected void A_2_ServerClick(object sender, EventArgs e)
        {
            Cheuqe.Visible = false; Transformation.Visible = true; Cash.Visible = false;
            Cq_T_Ca.Text = "3";
        }
        protected void A_3_ServerClick(object sender, EventArgs e)
        {
            Cheuqe.Visible = false; Transformation.Visible = false; Cash.Visible = true;
            Cq_T_Ca.Text = "4";
        }
        protected void A_4_ServerClick(object sender, EventArgs e)
        {
            Cheuqe.Visible = true; Transformation.Visible = true; Cash.Visible = true;
            Cq_T_Ca.Text = "1";
        }
        //********************  Collected , Not Collected Filter ************************************
        protected void Collected_Or_NotCollected_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData_All_Cheuqe();
            BindData_All_Transformation();
            BindData_All_Cash();
        }
        //********************  Singel Multi Filter ************************************
        protected void Singel_Multi_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData_All_Cheuqe();
            BindData_All_Transformation();
            BindData_All_Cash();
            if (Singel_Multi_DropDownList.SelectedValue == "1") { lbl_Cash.Text = "كافة الدفعات"; lbl_Transformation.Text = "كافة الحوالات"; lbl_Cheques.Text = "كافة الشيكات"; }
            else if (Singel_Multi_DropDownList.SelectedValue == "2") { lbl_Cash.Text = "دفعات العقود المفردة"; lbl_Transformation.Text = "حوالات العقود المفردة"; lbl_Cheques.Text = "شيكات العقود المفردة"; }
            else if (Singel_Multi_DropDownList.SelectedValue == "3") { lbl_Cash.Text = "دفعات العقود المجملة"; lbl_Transformation.Text = "حوالات العقود المجملة"; lbl_Cheques.Text = "شيكات العقود المجملة"; }

        }
        //********************  Today Or All Filter ************************************
        protected void Date_Filter_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData_All_Cheuqe();
            BindData_All_Transformation();
            BindData_All_Cash();
        }



        //************************************************************** Collect Functions ******************************************************************
        protected void Collect_cheque_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            string[] Array_id = id.Split('/');
            if (Array_id[0] == "A")
            {
                Response.Redirect(string.Format("Collect_Singl_Cheuqe.aspx?Id={0}&Cq_T_Ca={1}&Collection={2}&Singel_Multi={3}",
                Array_id[1], Cq_T_Ca.Text, Collected_Or_NotCollected_DropDownList.SelectedValue, Singel_Multi_DropDownList.SelectedValue));
            }
            else
            {
                Response.Redirect(string.Format("Collect_Multi_Cheuqe.aspx?Id={0}&Cq_T_Ca={1}&Collection={2}&Singel_Multi={3}",
                Array_id[1], Cq_T_Ca.Text, Collected_Or_NotCollected_DropDownList.SelectedValue, Singel_Multi_DropDownList.SelectedValue));
            }

            ///* Response.Redirect(string.Format("Collect_Multi_Transformation.aspx?Id={0}&Date_Filter={1}&Cq_T_Ch_Filter={2}", id, Date_Filter_DropDownList.SelectedValue, lbl_Cq_T_Ch_Filter.Text)*/);
        }
        protected void Collect_transformation_Click(object sender, EventArgs e)
        {
             string id = (sender as LinkButton).CommandArgument;
            string[] Array_id = id.Split('/');
            if (Array_id[0] == "A")
            {
                Response.Redirect(string.Format("Collect_Singl_Transformation.aspx?Id={0}&Cq_T_Ca={1}&Collection={2}&Singel_Multi={3}",
                Array_id[1], Cq_T_Ca.Text, Collected_Or_NotCollected_DropDownList.SelectedValue, Singel_Multi_DropDownList.SelectedValue));
            }
            else
            {
                Response.Redirect(string.Format("Collect_Multi_Transformation.aspx?Id={0}&Cq_T_Ca={1}&Collection={2}&Singel_Multi={3}",
                Array_id[1], Cq_T_Ca.Text, Collected_Or_NotCollected_DropDownList.SelectedValue, Singel_Multi_DropDownList.SelectedValue));
            } 

        }
        protected void Collect_Cash_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            string[] Array_id = id.Split('/');
            if (Array_id[0] == "A")
            {
                Response.Redirect(string.Format("Collect_Singl_Cash.aspx?Id={0}&Cq_T_Ca={1}&Collection={2}&Singel_Multi={3}",
                Array_id[1], Cq_T_Ca.Text, Collected_Or_NotCollected_DropDownList.SelectedValue, Singel_Multi_DropDownList.SelectedValue));
            }
            else
            {
                Response.Redirect(string.Format("Collect_Multi_Cash.aspx?Id={0}&Cq_T_Ca={1}&Collection={2}&Singel_Multi={3}",
                Array_id[1], Cq_T_Ca.Text, Collected_Or_NotCollected_DropDownList.SelectedValue, Singel_Multi_DropDownList.SelectedValue));
            }
        }

        protected void Back_To_Same_Filters()
        {
            string Cq_T_Ca = Request.QueryString["Cq_T_Ca"];
            string Collection = Request.QueryString["Collection"];
            string Singel_Multi = Request.QueryString["Singel_Multi"];
            if (Cq_T_Ca == "2") { Cheuqe.Visible = true; Transformation.Visible = false; Cash.Visible = false; }
            else if (Cq_T_Ca == "3") { Cheuqe.Visible = false; Transformation.Visible = true; Cash.Visible = false; }
            else if (Cq_T_Ca == "4") { Cheuqe.Visible = false; Transformation.Visible = false; Cash.Visible = true; }
            else { Cheuqe.Visible = true; Transformation.Visible = true; Cash.Visible = true; }


            Collected_Or_NotCollected_DropDownList.SelectedValue = Collection;
            Singel_Multi_DropDownList.SelectedValue = Singel_Multi;



            if (Singel_Multi_DropDownList.SelectedValue == "1") { lbl_Cash.Text = "كافة الدفعات"; lbl_Transformation.Text = "كافة الحوالات"; lbl_Cheques.Text = "كافة الشيكات"; }
            else if (Singel_Multi_DropDownList.SelectedValue == "2") { lbl_Cash.Text = "دفعات العقود المفردة"; lbl_Transformation.Text = "حوالات العقود المفردة"; lbl_Cheques.Text = "شيكات العقود المفردة"; }
            else if (Singel_Multi_DropDownList.SelectedValue == "3") { lbl_Cash.Text = "دفعات العقود المجملة"; lbl_Transformation.Text = "حوالات العقود المجملة"; lbl_Cheques.Text = "شيكات العقود المجملة"; }

        }



    }
}