using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class All_Income : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindData_All_Cheuqe();
                BindData_All_Transformation();
                BindData_All_Cash();

                lbl_Cash.Text = "كافة الدفعات";
                lbl_Transformation.Text = "كافة الحوالات";
                lbl_Cheques.Text = "كافة الشيكات";
            }

        }
        protected void BindData_All_Cheuqe(string sortExpression = null)
        {
            string Type_e = ""; string Datee = "";
            if (Singel_Multi_DropDownList.SelectedValue == "1") { Type_e = ""; }
            else if (Singel_Multi_DropDownList.SelectedValue == "2") { Type_e = "A"; }
            else { Type_e = "B"; }

            if (Date_Filter_DropDownList.SelectedValue == "1") { Datee = ""; } else { Datee = DateTime.Now.ToString("dd/MM/yyyy"); }
            //++++++++++++++++++++++++++ All_Cheuqes ++++++++++++++++++++++++++++++++++
            using (MySqlCommand cmd = new MySqlCommand("All_Avilabel_Cheuqe", _sqlCon))
            {
                cmd.Parameters.AddWithValue("@Type_e", Type_e);
                cmd.Parameters.AddWithValue("@Datee", Datee);
                cmd.Parameters.AddWithValue("@Datee2", DateTime.Now.ToString("dd/MM/yyyy"));
                using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    Avilabel_Cheuqes.DataSource = dt;
                    Avilabel_Cheuqes.DataBind();
                }
            }
        }
        protected void BindData_All_Transformation(string sortExpression = null)
        {
            string Type_e = ""; string Datee = "";
            if (Singel_Multi_DropDownList.SelectedValue == "1") { Type_e = ""; }
            else if (Singel_Multi_DropDownList.SelectedValue == "2") { Type_e = "A"; }
            else { Type_e = "B"; }

            if (Date_Filter_DropDownList.SelectedValue == "1") { Datee = ""; } else { Datee = DateTime.Now.ToString("dd/MM/yyyy"); }
            using (MySqlCommand cmd = new MySqlCommand("All_Trasformatios", _sqlCon))
            {
                cmd.Parameters.AddWithValue("@Type_e", Type_e);
                cmd.Parameters.AddWithValue("@Datee", Datee);
                cmd.Parameters.AddWithValue("@Datee2", DateTime.Now.ToString("dd/MM/yyyy"));
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
            string Type_e = ""; string Datee = "";
            if (Singel_Multi_DropDownList.SelectedValue == "1") { Type_e = ""; }
            else if (Singel_Multi_DropDownList.SelectedValue == "2") { Type_e = "A"; }
            else { Type_e = "B"; }

            if (Date_Filter_DropDownList.SelectedValue == "1") { Datee = ""; } else { Datee = DateTime.Now.ToString("dd/MM/yyyy"); }
            using (MySqlCommand cmd = new MySqlCommand("All_Cash", _sqlCon))
            {
                cmd.Parameters.AddWithValue("@Type_e", Type_e);
                cmd.Parameters.AddWithValue("@Datee", Datee);
                cmd.Parameters.AddWithValue("@Datee2", DateTime.Now.ToString("dd/MM/yyyy"));
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
        }
        protected void A_2_ServerClick(object sender, EventArgs e)
        {
            Cheuqe.Visible = false; Transformation.Visible = true; Cash.Visible = false;
        }
        protected void A_3_ServerClick(object sender, EventArgs e)
        {
            Cheuqe.Visible = false; Transformation.Visible = false; Cash.Visible = true;
        }
        protected void A_4_ServerClick(object sender, EventArgs e)
        {
            Cheuqe.Visible = true; Transformation.Visible = true; Cash.Visible = true;
        }
        //********************  Collected , Not Collected Filter ************************************
        protected void Collected_Or_NotCollected_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData_All_Cheuqe();
            BindData_All_Transformation();
            BindData_All_Cash();
        }
        //********************  Today Or All Filter ************************************
        protected void Date_Filter_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}