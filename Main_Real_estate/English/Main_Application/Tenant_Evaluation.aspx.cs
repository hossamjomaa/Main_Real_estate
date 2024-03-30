using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Tenant_Evaluation : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Customer_Affairs", 0, "R");
            Utilities.Roles.Add_permission(_sqlCon, Session["Role"].ToString(), "Customer_Affairs", Add);
            if (!this.IsPostBack)
            {
                //Fill Main Type  DropDownList
                Helper.LoadDropDownList("SELECT * FROM main_type_evaluation", _sqlCon, Main_Type_DropDownList, "Ar_Name", "Main_Type_Evaluation_Id");
                Main_Type_DropDownList.Items.Insert(0, "أختر النوع الرئيسي....");




                //Fill Sub Type DropDownList
                Helper.LoadDropDownList("SELECT * FROM sub_type_evaluation", _sqlCon, Sub_Type_DropDownList, "Ar_Name", "Sub_Type_Evaluation_Id");
                Sub_Type_DropDownList.Items.Insert(0, "أختر النوع الفرعي....");

                //Fill Tenant _Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM tenants", _sqlCon, Tenant_Name_DropDownList, "Tenants_Arabic_Name", "Tenants_ID");
                Tenant_Name_DropDownList.Items.Insert(0, "أختر إسم العميل....");



                //Fill Tenant _Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM tenants", _sqlCon, Tenant_DropDownList, "Tenants_Arabic_Name", "Tenants_ID");
                Tenant_DropDownList.Items.Insert(0, "... الكل ...");


                // Level_DropDownList.Items.Insert(0, "... الكل ...");

                Label3.Text = "";
                Get_Evaluation_BindData();
                Get_Cases_BindData();
            }
        }

        protected void Main_Type_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Fill Sub Type DropDownList
            Helper.LoadDropDownList("SELECT * FROM sub_type_evaluation where Main_Type_Evaluation_Id = '" + Main_Type_DropDownList.SelectedValue + "'", _sqlCon, Sub_Type_DropDownList, "Ar_Name", "Sub_Type_Evaluation_Id");
            Sub_Type_DropDownList.Items.Insert(0, "أختر النوع الفرعي....");
        }

        protected void btn_Add_T_E_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addEvaluationQuary =
                    "Insert Into tenant_evaluation (" +
                    "Tenant_Id," +
                    "Main_Type_Id," +
                    "Weight," +
                    "Sup_Type_Id , Date) " +
                    "VALUES(" +
                    "@Tenant_Id," +
                    "@Main_Type_Id," +
                    "@Weight," +
                    "@Sup_Type_Id , @Date)";
                _sqlCon.Open();
                MySqlCommand addEvaluationCmd = new MySqlCommand(addEvaluationQuary, _sqlCon);
                addEvaluationCmd.Parameters.AddWithValue("@Tenant_Id", Tenant_Name_DropDownList.SelectedValue);
                addEvaluationCmd.Parameters.AddWithValue("@Main_Type_Id", Main_Type_DropDownList.SelectedValue);
                addEvaluationCmd.Parameters.AddWithValue("@Sup_Type_Id", Sub_Type_DropDownList.SelectedValue);
                addEvaluationCmd.Parameters.AddWithValue("@Weight", Label3.Text);
                addEvaluationCmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("dd/MM/yyyy"));
                addEvaluationCmd.ExecuteNonQuery();
                _sqlCon.Close();


                Response.Redirect(Request.RawUrl);
            }
        }

        protected void Delete(object sender, EventArgs e)
        {
            try
            {
                string id = (sender as LinkButton).CommandArgument;
                _sqlCon.Open();
                string quary1 = "DELETE FROM tenant_evaluation WHERE Tenant_Evaluation_Id=@ID ";
                MySqlCommand mySqlCmd = new MySqlCommand(quary1, _sqlCon);
                mySqlCmd.Parameters.AddWithValue("@ID", id);
                mySqlCmd.ExecuteNonQuery();
                _sqlCon.Close();
                Response.Redirect(Request.RawUrl);
            }
            catch
            {
                Response.Write(@"<script language='javascript'>alert('لا يمكن الحذف')</script>");
            };
        }

        //protected void Get_Evaluation_BindData()
        //{
        //    try
        //    {
        //        string Tenant = "";
        //        if(Tenant_DropDownList.SelectedItem.Text != "... الكل ...") { Tenant = " where TE.Tenant_Id = " + Tenant_DropDownList.SelectedValue; } else { Tenant = ""; }


        //        string getEvaluationQuari = "SELECT TE.*  , T.Tenants_Arabic_Name FROM tenant_evaluation TE  " +
        //            "left join  tenants T on (TE.Tenant_Id = T.Tenants_ID)  "+ Tenant + " " +
        //            "group by TE.Tenant_Id";
        //        MySqlCommand getEvaluationCmd = new MySqlCommand(getEvaluationQuari, _sqlCon);
        //        MySqlDataAdapter getEvaluationDt = new MySqlDataAdapter(getEvaluationCmd);
        //        getEvaluationCmd.Connection = _sqlCon;
        //        _sqlCon.Open();
        //        getEvaluationDt.SelectCommand = getEvaluationCmd;
        //        DataTable getEvaluationDataTable = new DataTable();
        //        getEvaluationDt.Fill(getEvaluationDataTable);
        //        Tenant_Repeater.DataSource = getEvaluationDataTable;
        //        Tenant_Repeater.DataBind();
        //        _sqlCon.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}


        //protected void Get_Cases_BindData()
        //{
        //    foreach (RepeaterItem item in Tenant_Repeater.Items)
        //    {
        //        Repeater Cases_Repeater = item.FindControl("Cases_Repeater") as Repeater;
        //        Label lbl_Tenant_Id = item.FindControl("lbl_Tenant_Id") as Label;



        //        string Cases_Repeater_Quari = "SELECT TE.*  ,  S.Ar_Name  ,  T.Tenants_Arabic_Name  ,T.Tenants_ID , COUNT(S.Sub_Type_Evaluation_Id)Cases_Count , " +
        //            "(COUNT(S.Sub_Type_Evaluation_Id)*S.R_Sub_Weight) PP " +
        //            "FROM tenant_evaluation TE " +
        //            "left join  sub_type_evaluation S on (TE.Sup_Type_Id = S.Sub_Type_Evaluation_Id) " +
        //            "left join  tenants T on (TE.Tenant_Id = T.Tenants_ID)  " +
        //            "where T.Tenants_ID = '"+ lbl_Tenant_Id.Text + "'  " +
        //            "group by S.Sub_Type_Evaluation_Id " +
        //            "HAVING COUNT(S.Sub_Type_Evaluation_Id) > 0";
        //        MySqlCommand get_Cases_Repeater_Cmd = new MySqlCommand(Cases_Repeater_Quari, _sqlCon);
        //        MySqlDataAdapter get_Cases_Repeater_Dt = new MySqlDataAdapter(get_Cases_Repeater_Cmd);
        //        get_Cases_Repeater_Cmd.Connection = _sqlCon;
        //        _sqlCon.Open();
        //        get_Cases_Repeater_Dt.SelectCommand = get_Cases_Repeater_Cmd;
        //        DataTable get_Cases_Repeater_DataTable = new DataTable();
        //        get_Cases_Repeater_Dt.Fill(get_Cases_Repeater_DataTable);
        //        Cases_Repeater.DataSource = get_Cases_Repeater_DataTable;
        //        Cases_Repeater.DataBind();


        //        int totalMarks = get_Cases_Repeater_DataTable.Select().Sum(p => Convert.ToInt32(p["PP"]));
        //        (Cases_Repeater.Controls[Cases_Repeater.Controls.Count - 1].Controls[0].FindControl("lblTotal") as Label).Text = totalMarks.ToString();
        //        (Cases_Repeater.Controls[Cases_Repeater.Controls.Count - 1].Controls[0].FindControl("lbl_Pesenteg_Total") as Label).Text = (100-totalMarks).ToString();



        //        Control FooterTemplate = Cases_Repeater.Controls[Cases_Repeater.Controls.Count - 1].Controls[0];
        //        Label lbl_Pesenteg_Total = FooterTemplate.FindControl("lbl_Pesenteg_Total") as Label;
        //        Label Label4 = FooterTemplate.FindControl("Label4") as Label;
        //        double Dbl_lbl_Persenteg = Convert.ToDouble(lbl_Pesenteg_Total.Text);

        //        if (Dbl_lbl_Persenteg >= 80 && Dbl_lbl_Persenteg <= 100)
        //        {
        //            Label4.Text = "A";
        //        }
        //        else if (Dbl_lbl_Persenteg >= 60 && Dbl_lbl_Persenteg <= 79)
        //        {
        //            Label4.Text = "B";
        //            //Tenant_Repeater.Visible= false;
        //        }
        //        else if (Dbl_lbl_Persenteg >= 40 && Dbl_lbl_Persenteg <= 59)
        //        {
        //            Label4.Text = "C";
        //        }
        //        else if (Dbl_lbl_Persenteg >= 20 && Dbl_lbl_Persenteg <= 39)
        //        {
        //            Label4.Text = "D";
        //        }
        //        else
        //        {
        //            Label4.Text = "E";
        //        }


        //        _sqlCon.Close();




        //        if (Level_DropDownList.SelectedValue == "1")
        //        {


        //                if (Label4.Text != "A")
        //                {
        //                    lbl_Pesenteg_Total.Visible = false;
        //                }


        //        }
        //    }
        //}

        protected void Get_Evaluation_BindData()
        {
            string tenant_ID = ""; string Persenteg = "";
            if (Tenant_DropDownList.SelectedItem.Text == "... الكل ...") { tenant_ID = ""; } else { tenant_ID = Tenant_DropDownList.SelectedValue; }




            string tenantListQuery = "SELECT TE.* , sum(TE.Weight) Persenteg ,  " +
                    "T.Tenants_Arabic_Name , T.Tenants_Tell , T.Tenants_Mobile , " +
                    "TN.Arabic_nationality " +
                    "FROM tenant_evaluation TE " +
                    "left join tenants T on(TE.Tenant_Id = T.Tenants_ID) " +
                    "left join nationality TN on(T.nationality_nationality_ID = TN.nationality_ID) " +
                    "where Tenant_Id like CONCAT('%', '" + tenant_ID + "', '%') " +
                    "group by Tenant_Id";

            try { Helper.GetDataReader(tenantListQuery, _sqlCon, tenant_List); }
            catch { Response.Write(@"<script language='javascript'>alert('لا يمكن عرض هذه الصفحة')</script>"); };
        }
        protected void Get_Cases_BindData()
        {
            foreach (RepeaterItem item in tenant_List.Items)
            {
                Repeater Cases_Repeater = item.FindControl("Cases_Repeater") as Repeater;
                Label Tenant_Id = item.FindControl("Tenant_Id") as Label;

                string CasestQuery = "select TE.Tenant_Evaluation_Id , TE.Sup_Type_Id , TE.Date  , STE.Ar_Name " +
                    "from tenant_evaluation TE  " +
                    "left join sub_type_evaluation STE on(TE.Sup_Type_Id = STE.Sub_Type_Evaluation_Id) where Tenant_Id = '" + Tenant_Id.Text + "';";

                //try { Helper.GetDataReader(CasestQuery, _sqlCon, Cases_Repeater); }
                //catch { Response.Write(@"<script language='javascript'>alert('لا يمكن عرض هذه الصفحة')</script>"); };
                Helper.GetDataReader(CasestQuery, _sqlCon, Cases_Repeater);
            }
        }

        protected void Sub_Type_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable getWeightDt = new DataTable();
            _sqlCon.Open();
            MySqlCommand getWeightCmd = new MySqlCommand(
                "SELECT R_Sub_Weight  FROM sub_type_evaluation WHERE Sub_Type_Evaluation_Id = @ID",
                _sqlCon);
            MySqlDataAdapter getWeightDa = new MySqlDataAdapter(getWeightCmd);

            getWeightCmd.Parameters.AddWithValue("@ID", Sub_Type_DropDownList.SelectedValue);
            getWeightDa.Fill(getWeightDt);
            if (getWeightDt.Rows.Count > 0)
            {
                Label3.Text = getWeightDt.Rows[0]["R_Sub_Weight"].ToString();
            }

            _sqlCon.Close();
        }

        protected void Tenant_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_Evaluation_BindData();
            Get_Cases_BindData();
        }

        protected void Level_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_Evaluation_BindData();
            Get_Cases_BindData();
        }

        protected void tenant_List_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem item in tenant_List.Items)
            {
                Label lbl_Persenteg = item.FindControl("lbl_Persenteg") as Label;
                Label Label5 = item.FindControl("Label5") as Label;
                double Dbl_lbl_Persenteg = 100 - Convert.ToDouble(lbl_Persenteg.Text);
                HtmlTableRow tr = item.FindControl("row") as HtmlTableRow;


                if (Dbl_lbl_Persenteg >= 80 && Dbl_lbl_Persenteg <= 100)
                {
                    Label5.Text = "A";
                }
                else if (Dbl_lbl_Persenteg >= 60 && Dbl_lbl_Persenteg <= 79)
                {
                    Label5.Text = "B";
                    //Tenant_Repeater.Visible= false;
                }
                else if (Dbl_lbl_Persenteg >= 40 && Dbl_lbl_Persenteg <= 59)
                {
                    Label5.Text = "C";
                }
                else if (Dbl_lbl_Persenteg >= 20 && Dbl_lbl_Persenteg <= 39)
                {
                    Label5.Text = "D";
                }
                else
                {
                    Label5.Text = "E";
                }




            }
        }


        //*****************************************************************************************************************************************************


    }
}