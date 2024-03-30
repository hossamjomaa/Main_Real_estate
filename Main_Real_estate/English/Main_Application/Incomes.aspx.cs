using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Incomes : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Financial_Statements", 0, "R");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!this.IsPostBack)
            {
                BindData();
                Building_BindData();
                txtSearch.Text = "";
                DateTime Today = DateTime.Now;
                string TD = Today.ToString("dd/MM/yyyy");
                lbl_Avilabel_Cheuqes.Text = "* الشيكات المستحقة لغاية تاريخ اليوم" + TD;



                //******************* تحصيل الحوالات *************************

                Transformation_BindData();
                Transformation_Building_BindData();
                lbl_Avilabel_transformation.Text = "* الحوالات المستحقة لغاية تاريخ اليوم" + TD;


                //************* تحصيل الدفعات **************************************************

                Cash_BindData();
                Cash_Building_BindData();
                lbl_Avilabel_cash.Text = "* الدفعات المستحقة لغاية تاريخ اليوم" + TD;
            }

        }
        protected void BindData(string sortExpression = null)
        {
            //try
            //{
            _sqlCon.Open();
            DateTime dateTime = DateTime.Now;
            using (MySqlCommand Contract_ChequesCmd = new MySqlCommand("Avilabel_Cheuqes", _sqlCon))
            {
                Contract_ChequesCmd.CommandType = CommandType.StoredProcedure;
                Contract_ChequesCmd.Parameters.AddWithValue("@Cheq_No", txtSearch.Text.Trim());
                Contract_ChequesCmd.Parameters.AddWithValue("@Cheq_Date", txtSearch.Text.Trim());
                Contract_ChequesCmd.Parameters.AddWithValue("@Cheq_Owner", txtSearch.Text.Trim());
                Contract_ChequesCmd.Parameters.AddWithValue("@Bank_ArabicName", txtSearch.Text.Trim());
                Contract_ChequesCmd.Parameters.AddWithValue("@Tenants_ArabicName", txtSearch.Text.Trim());
                Contract_ChequesCmd.Parameters.AddWithValue("@Cheq_Status", txtSearch.Text.Trim());
                MySqlDataAdapter Contract_ChequesSda = new MySqlDataAdapter(Contract_ChequesCmd);

                DataTable Contract_ChequesDt = new DataTable();
                Contract_ChequesSda.Fill(Contract_ChequesDt);
                Contract_ChequesCmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                Contract_ChequesSda.Fill(dt);
                Avilabel_Cheuqes.DataSource = dt;
                Avilabel_Cheuqes.DataBind();
            }
            _sqlCon.Close();
            //}
            //    catch { Response.Write(@"<script language='javascript'>alert('حدث خطأ ما لا يمكن عرض الشيكات')</script>"); }
        }
        protected void Avilabel_Cheuqes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && Avilabel_Cheuqes.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddl_Status = (DropDownList)e.Row.FindControl("cheque_Status_DropDownList");

                if (DataBinder.Eval(e.Row.DataItem, "Cheques_Status").ToString() == "غير محصل")
                { string selected_Activ = "1"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }

                else if (DataBinder.Eval(e.Row.DataItem, "Cheques_Status").ToString() == "مؤجل")
                { string selected_Activ = "2"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }

                else if (DataBinder.Eval(e.Row.DataItem, "Cheques_Status").ToString() == "مرتجع")
                { string selected_Activ = "3"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }

                else if (DataBinder.Eval(e.Row.DataItem, "Cheques_Status").ToString() == "محصل بالشيك")
                { string selected_Activ = "4"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }

                else if (DataBinder.Eval(e.Row.DataItem, "Cheques_Status").ToString() == "محصل نقداً")
                { string selected_Activ = "5"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }

                else if (DataBinder.Eval(e.Row.DataItem, "Cheques_Status").ToString() == "محصل بالتحويل")
                { string selected_Activ = "6"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }

                else if (DataBinder.Eval(e.Row.DataItem, "Cheques_Status").ToString() == "مستبدل : بالتحويل")
                { string selected_Activ = "7"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }

                else if (DataBinder.Eval(e.Row.DataItem, "Cheques_Status").ToString() == "مستبدل : نقداً")
                { string selected_Activ = "8"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }

                else { string selected_Activ = "9"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }
            }


            //*******************************************************************************
            string ChequeDate;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    ChequeDate = ((Label)e.Row.FindControl("lbl_Cheques_Date")).Text;


                    DateTime Today = DateTime.Now;
                    DateTime Cheques_date = Convert.ToDateTime(ChequeDate);
                    if (Cheques_date > Today)
                    {
                        e.Row.Visible = false;
                    }

                }
                catch
                {
                    ChequeDate = "";
                }
            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string ChequeStatus = ((Label)e.Row.FindControl("test_lbl_cheque_Status")).Text;
                if (ChequeStatus == "محصل بالشيك" || ChequeStatus == "محصل نقداً" || ChequeStatus == "محصل بالتحويل")
                {

                    e.Row.Attributes.Add("style", "background-color: #c5f8eb;");
                    // e.Row.BackColor = System.Drawing.Color.LightGreen;
                }
                else if (ChequeStatus == "مرتجع")
                {
                    e.Row.Attributes.Add("style", "background-color: #faced2;");
                    //e.Row.BackColor = System.Drawing.Color.Red;
                }
                else if (ChequeStatus == "مؤجل")
                {
                    e.Row.Attributes.Add("style", "background-color: #fbde9f;");
                    //e.Row.BackColor = System.Drawing.Color.DeepSkyBlue;
                }

            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string lbl_Status = ((Label)e.Row.FindControl("test_lbl_cheque_Status")).Text;
                string Filter = Filter_DropDownList.SelectedItem.Text.Trim();
                if (Filter == "غير محصل")
                {
                    if (lbl_Status == "محصل بالشيك" || lbl_Status == "محصل نقداً" || lbl_Status == "محصل بالتحويل")
                    {
                        e.Row.Visible = false;
                    }
                }
                else if (Filter == "محصل")
                {
                    if (lbl_Status == "غير محصل" || lbl_Status == "مؤجل" || lbl_Status == "مرتجع")
                    {
                        e.Row.Visible = false;
                    }
                }
                else { e.Row.Visible = true; }
            }
        }

        protected void Avilabel_Cheuqes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Avilabel_Cheuqes.EditIndex = e.NewEditIndex; this.BindData();
        }

        protected void Avilabel_Cheuqes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string lbl_Ownership_ID = (Avilabel_Cheuqes.Rows[e.RowIndex].FindControl("lbl_Ownership_ID") as Label).Text;
            string lbl_Building_ID = (Avilabel_Cheuqes.Rows[e.RowIndex].FindControl("lbl_Building_ID") as Label).Text;
            string lbl_Unit_ID = (Avilabel_Cheuqes.Rows[e.RowIndex].FindControl("lbl_Unit_ID") as Label).Text;
            string Month_Cheques_Date = Convert.ToString(Convert.ToDateTime((Avilabel_Cheuqes.Rows[e.RowIndex].FindControl("lbl_Cheques_Date") as Label).Text).Month);
            string Year_Cheques_Date = Convert.ToString(Convert.ToDateTime((Avilabel_Cheuqes.Rows[e.RowIndex].FindControl("lbl_Cheques_Date") as Label).Text).Year);
            string lbl_Cheques_Amount = (Avilabel_Cheuqes.Rows[e.RowIndex].FindControl("lbl_Cheques_Amount") as Label).Text;
            string lbl_Tenants_Id = (Avilabel_Cheuqes.Rows[e.RowIndex].FindControl("lbl_Tenants_Id") as Label).Text;
            string lbl_Cheques_No = (Avilabel_Cheuqes.Rows[e.RowIndex].FindControl("lbl_Cheques_No") as Label).Text;


            string txt_Cheque_Status = (Avilabel_Cheuqes.Rows[e.RowIndex].FindControl("cheque_Status_DropDownList") as DropDownList).SelectedItem.Text.Trim();
            string Value_Cheque_Status = (Avilabel_Cheuqes.Rows[e.RowIndex].FindControl("cheque_Status_DropDownList") as DropDownList).SelectedValue;
            string Cheques_Id = Avilabel_Cheuqes.DataKeys[e.RowIndex].Value.ToString();

            Calendar Calendar2 = (Avilabel_Cheuqes.Rows[e.RowIndex]).FindControl("Calendar2") as Calendar;
            string calendar2 = Calendar2.SelectedDate.ToString("dd/MM/yyyy");
            Label lbl_Cheques_Date = (Avilabel_Cheuqes.Rows[e.RowIndex].FindControl("lbl_Cheques_Date") as Label);





            Calendar Collection_Date_Calendar = (Avilabel_Cheuqes.Rows[e.RowIndex]).FindControl("Collection_Date_Calendar") as Calendar;
            string CollectionDate_Calendar = Collection_Date_Calendar.SelectedDate.ToString("dd/MM/yyyy");
            Label lbl_Collection_Date = (Avilabel_Cheuqes.Rows[e.RowIndex].FindControl("lbl_Collection_Date") as Label);



            // Record The Income In Collection Talble
            if (Value_Cheque_Status == "4" || Value_Cheque_Status == "5" || Value_Cheque_Status == "6")
            {
                string Quary = "Select Collection From collection_table Where " +
                               "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "' And Unit_Id='" + lbl_Unit_ID + "' " +
                               "And Mounth='" + Month_Cheques_Date + "' And Year='" + Year_Cheques_Date + "'";
                MySqlDataAdapter CollectionSda = new MySqlDataAdapter(Quary, _sqlCon);
                DataTable getCollectionDt = new DataTable();
                CollectionSda.Fill(getCollectionDt);
                if (getCollectionDt.Rows.Count > 0)
                {
                    string UPDATECollectionQuary = "UPDATE collection_table SET " +
                                                   " Collection = @Collection Where " +
                                                   "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "' And Unit_Id='" + lbl_Unit_ID + "' " +
                                                   "And Mounth='" + Month_Cheques_Date + "' And Year='" + Year_Cheques_Date + "'";

                    _sqlCon.Open();
                    MySqlCommand UPDATECollectionCmd = new MySqlCommand(UPDATECollectionQuary, _sqlCon);
                    UPDATECollectionCmd.Parameters.AddWithValue("@Collection", lbl_Cheques_Amount);
                    UPDATECollectionCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                else
                {
                    string AddCollectionQuary = "Insert Into collection_table" +
                                           " (Ownersip_Id,Building_Id,Unit_Id,Mounth,Year,Collection) " +
                                           "VALUES" +
                                           "(@Ownersip_Id,@Building_Id,@Unit_Id,@Mounth,@Year,@Collection)";
                    _sqlCon.Open();
                    MySqlCommand addCollectionCmd = new MySqlCommand(AddCollectionQuary, _sqlCon);
                    addCollectionCmd.Parameters.AddWithValue("@Ownersip_Id", lbl_Ownership_ID);
                    addCollectionCmd.Parameters.AddWithValue("@Building_Id", lbl_Building_ID);
                    addCollectionCmd.Parameters.AddWithValue("@Unit_Id", lbl_Unit_ID);
                    addCollectionCmd.Parameters.AddWithValue("@Mounth", Month_Cheques_Date);
                    addCollectionCmd.Parameters.AddWithValue("@Year", Year_Cheques_Date);
                    addCollectionCmd.Parameters.AddWithValue("@Collection", lbl_Cheques_Amount);
                    addCollectionCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                _sqlCon.Close();
            }
            else if (Value_Cheque_Status == "1" || Value_Cheque_Status == "2" || Value_Cheque_Status == "7" || Value_Cheque_Status == "8" || Value_Cheque_Status == "9")
            {
                string Quary = "Select Collection From collection_table Where " +
                               "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "' And Unit_Id='" + lbl_Unit_ID + "' " +
                               "And Mounth='" + Month_Cheques_Date + "' And Year='" + Year_Cheques_Date + "'";
                MySqlDataAdapter CollectionSda = new MySqlDataAdapter(Quary, _sqlCon);
                DataTable getCollectionDt = new DataTable();
                CollectionSda.Fill(getCollectionDt);
                if (getCollectionDt.Rows.Count > 0)
                {
                    _sqlCon.Open();
                    string deleteCollectionQuary = "DELETE FROM collection_table WHERE " +
                                                   "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "' And Unit_Id='" + lbl_Unit_ID + "' " +
                                                   "And Mounth='" + Month_Cheques_Date + "' And Year='" + Year_Cheques_Date + "'";
                    MySqlCommand mySqlCmd = new MySqlCommand(deleteCollectionQuary, _sqlCon);
                    mySqlCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }




                //string query2 = "UPDATE cheques SET  Collection_Date=@Collection_Date WHERE Cheques_Id = @Cheques_Id";
                //using (MySqlCommand cmd = new MySqlCommand(query2, _sqlCon))
                //{
                //    cmd.Parameters.AddWithValue("@Collection_Date", "");
                //    _sqlCon.Open(); cmd.ExecuteNonQuery(); _sqlCon.Close(); Avilabel_Cheuqes.EditIndex = -1; this.BindData();
                //}
            }
            else
            {
                Avilabel_Cheuqes.EditIndex = -1; this.BindData();

                DataTable getTenantDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getTenantCmd = new MySqlCommand("SELECT Tenants_Mobile FROM tenants WHERE Tenants_ID = '" + lbl_Tenants_Id + "'", _sqlCon);
                MySqlDataAdapter getTenantDa = new MySqlDataAdapter(getTenantCmd);
                getTenantDa.Fill(getTenantDt);
                if (getTenantDt.Rows.Count > 0)
                {
                    string Tenants_Mobile = getTenantDt.Rows[0]["Tenants_Mobile"].ToString();
                    string Sms = "  شركة المنارة : عزيزي المستأجر تم إرجاع الشيك ذو الرقم" + lbl_Cheques_No + " من قبل البنك يرجى متابعة الأمر";
                    Utilities.Helper.SendSms(Tenants_Mobile, Sms);
                }
                _sqlCon.Close();
            }

            string query = "UPDATE cheques SET Cheques_Status = @Cheques_Status , Cheques_Date = @Cheques_Date , Collection_Date=@Collection_Date WHERE Cheques_Id = @Cheques_Id";
            using (MySqlCommand cmd = new MySqlCommand(query, _sqlCon))
            {
                cmd.Parameters.AddWithValue("@Cheques_Id", Cheques_Id);
                cmd.Parameters.AddWithValue("@Cheques_Status", txt_Cheque_Status);

                if (calendar2 != "01/01/0001") { cmd.Parameters.AddWithValue("@Cheques_Date", calendar2); }
                else { cmd.Parameters.AddWithValue("@Cheques_Date", lbl_Cheques_Date.Text); }


                if (Value_Cheque_Status == "1" || Value_Cheque_Status == "2" || Value_Cheque_Status == "7" || Value_Cheque_Status == "8" || Value_Cheque_Status == "9")
                {
                    cmd.Parameters.AddWithValue("@Collection_Date", "");
                }
                else
                {
                    if (CollectionDate_Calendar != "01/01/0001") { cmd.Parameters.AddWithValue("@Collection_Date", CollectionDate_Calendar); }
                    else { cmd.Parameters.AddWithValue("@Collection_Date", lbl_Collection_Date.Text); }
                }


                    

                _sqlCon.Open(); cmd.ExecuteNonQuery(); _sqlCon.Close(); Avilabel_Cheuqes.EditIndex = -1; this.BindData();
            }
        }
        protected void Avilabel_Cheuqes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Avilabel_Cheuqes.EditIndex = -1; this.BindData();
        }

        //protected void Search_Btn_Click(object sender, EventArgs e)
        //{
        //    this.BindData();
        //}

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {

            this.BindData();


        }

        protected void Search_Btn_Click1(object sender, EventArgs e)
        {

            this.BindData();

        }
        //******************************************************************************************************************************

        protected void Building_BindData(string sortExpression = null)
        {
            //try
            //{
            _sqlCon.Open();
            DateTime dateTime = DateTime.Now;
            using (MySqlCommand Contract_ChequesCmd = new MySqlCommand("Buildings_Avilabel_Cheuqes", _sqlCon))
            {
                Contract_ChequesCmd.CommandType = CommandType.StoredProcedure;
                Contract_ChequesCmd.Parameters.AddWithValue("@Cheq_No", Building_txtSearch.Text.Trim());
                Contract_ChequesCmd.Parameters.AddWithValue("@Cheq_Date", Building_txtSearch.Text.Trim());
                Contract_ChequesCmd.Parameters.AddWithValue("@Cheq_Owner", Building_txtSearch.Text.Trim());
                Contract_ChequesCmd.Parameters.AddWithValue("@Bank_ArabicName", Building_txtSearch.Text.Trim());
                Contract_ChequesCmd.Parameters.AddWithValue("@Tenants_ArabicName", Building_txtSearch.Text.Trim());
                Contract_ChequesCmd.Parameters.AddWithValue("@Cheq_Status", Building_txtSearch.Text.Trim());
                MySqlDataAdapter Contract_ChequesSda = new MySqlDataAdapter(Contract_ChequesCmd);

                DataTable Contract_ChequesDt = new DataTable();
                Contract_ChequesSda.Fill(Contract_ChequesDt);
                Contract_ChequesCmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                Contract_ChequesSda.Fill(dt);
                Building_Avilabel_Cheuqes.DataSource = dt;
                Building_Avilabel_Cheuqes.DataBind();
            }
            _sqlCon.Close();
            //}
            //    catch { Response.Write(@"<script language='javascript'>alert('حدث خطأ ما لا يمكن عرض الشيكات')</script>"); }
        }
        protected void Building_txtSearch_TextChanged(object sender, EventArgs e)
        {
            Building_BindData();
        }

        protected void Building_Search_Btn_Click(object sender, EventArgs e)
        {
            Building_BindData();
        }

        protected void Building_Avilabel_Cheuqes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && Building_Avilabel_Cheuqes.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddl_Status = (DropDownList)e.Row.FindControl("cheque_Status_DropDownList");

                if (DataBinder.Eval(e.Row.DataItem, "Cheques_Status").ToString() == "غير محصل")
                { string selected_Activ = "1"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }

                else if (DataBinder.Eval(e.Row.DataItem, "Cheques_Status").ToString() == "مؤجل")
                { string selected_Activ = "2"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }

                else if (DataBinder.Eval(e.Row.DataItem, "Cheques_Status").ToString() == "مرتجع")
                { string selected_Activ = "3"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }

                else if (DataBinder.Eval(e.Row.DataItem, "Cheques_Status").ToString() == "محصل بالشيك")
                { string selected_Activ = "4"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }

                else if (DataBinder.Eval(e.Row.DataItem, "Cheques_Status").ToString() == "محصل نقداً")
                { string selected_Activ = "5"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }


                else if (DataBinder.Eval(e.Row.DataItem, "Cheques_Status").ToString() == "محصل بالتحويل")
                { string selected_Activ = "6"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }

                else if (DataBinder.Eval(e.Row.DataItem, "Cheques_Status").ToString() == "مستبدل : بالتحويل")
                { string selected_Activ = "7"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }

                else if (DataBinder.Eval(e.Row.DataItem, "Cheques_Status").ToString() == "مستبدل : نقداً")
                { string selected_Activ = "8"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }

                else { string selected_Activ = "9"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }
            }


            //*******************************************************************************
            string ChequeDate;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    ChequeDate = ((Label)e.Row.FindControl("lbl_Cheques_Date")).Text;


                    DateTime Today = DateTime.Now;
                    DateTime Cheques_date = Convert.ToDateTime(ChequeDate);
                    if (Cheques_date > Today)
                    {
                        e.Row.Visible = false;
                    }

                }
                catch
                {
                    ChequeDate = "";
                }
            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string ChequeStatus = ((Label)e.Row.FindControl("test_lbl_cheque_Status")).Text;

                if (ChequeStatus == "محصل بالشيك" || ChequeStatus == "محصل نقداً" || ChequeStatus == "محصل بالتحويل")
                {

                    e.Row.Attributes.Add("style", "background-color: #c5f8eb;");
                    // e.Row.BackColor = System.Drawing.Color.LightGreen;
                }
                else if (ChequeStatus == "مرتجع")
                {
                    e.Row.Attributes.Add("style", "background-color: #faced2;");
                    //e.Row.BackColor = System.Drawing.Color.Red;
                }
                else if (ChequeStatus == "مؤجل")
                {
                    e.Row.Attributes.Add("style", "background-color: #fbde9f;");
                    //e.Row.BackColor = System.Drawing.Color.DeepSkyBlue;
                }



            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string lbl_Status = ((Label)e.Row.FindControl("test_lbl_cheque_Status")).Text;
                string Filter = Filter_DropDownList.SelectedItem.Text.Trim();
                if (Filter == "غير محصل")
                {
                    if (lbl_Status == "محصل بالشيك" || lbl_Status == "محصل نقداً" || lbl_Status == "محصل بالتحويل")
                    {
                        e.Row.Visible = false;
                    }
                }
                else if (Filter == "محصل")
                {
                    if (lbl_Status == "غير محصل" || lbl_Status == "مؤجل" || lbl_Status == "مرتجع")
                    {
                        e.Row.Visible = false;
                    }
                }
                else { e.Row.Visible = true; }
            }
        }

        protected void Building_Avilabel_Cheuqes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Building_Avilabel_Cheuqes.EditIndex = e.NewEditIndex; this.Building_BindData();
        }
        protected void Building_Avilabel_Cheuqes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Building_Avilabel_Cheuqes.EditIndex = -1; this.Building_BindData();
        }
        protected void Building_Avilabel_Cheuqes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string lbl_Ownership_ID = (Building_Avilabel_Cheuqes.Rows[e.RowIndex].FindControl("lbl_Ownership_ID") as Label).Text;
            string lbl_Building_ID = (Building_Avilabel_Cheuqes.Rows[e.RowIndex].FindControl("lbl_Building_ID") as Label).Text;
            string Month_Cheques_Date = Convert.ToString(Convert.ToDateTime((Building_Avilabel_Cheuqes.Rows[e.RowIndex].FindControl("lbl_Cheques_Date") as Label).Text).Month);
            string Year_Cheques_Date = Convert.ToString(Convert.ToDateTime((Building_Avilabel_Cheuqes.Rows[e.RowIndex].FindControl("lbl_Cheques_Date") as Label).Text).Year);
            string lbl_Cheques_Amount = (Building_Avilabel_Cheuqes.Rows[e.RowIndex].FindControl("lbl_Cheques_Amount") as Label).Text;
            string lbl_Tenants_Id = (Building_Avilabel_Cheuqes.Rows[e.RowIndex].FindControl("lbl_Tenants_Id") as Label).Text;
            string lbl_Cheques_No = (Building_Avilabel_Cheuqes.Rows[e.RowIndex].FindControl("lbl_Cheques_No") as Label).Text;


            string txt_Cheque_Status = (Building_Avilabel_Cheuqes.Rows[e.RowIndex].FindControl("cheque_Status_DropDownList") as DropDownList).SelectedItem.Text.Trim();
            string Value_Cheque_Status = (Building_Avilabel_Cheuqes.Rows[e.RowIndex].FindControl("cheque_Status_DropDownList") as DropDownList).SelectedValue;
            string Cheques_Id = Building_Avilabel_Cheuqes.DataKeys[e.RowIndex].Value.ToString();

            Calendar Calendar2 = (Building_Avilabel_Cheuqes.Rows[e.RowIndex]).FindControl("Calendar2") as Calendar;
            string calendar2 = Calendar2.SelectedDate.ToString("dd/MM/yyyy");
            Label lbl_Cheques_Date = (Building_Avilabel_Cheuqes.Rows[e.RowIndex].FindControl("lbl_Cheques_Date") as Label);


            Calendar B_Collection_Date_Calendar = (Building_Avilabel_Cheuqes.Rows[e.RowIndex]).FindControl("B_Collection_Date_Calendar") as Calendar;
            string B_CollectionDate_Calendar = B_Collection_Date_Calendar.SelectedDate.ToString("dd/MM/yyyy");
            Label lbl_B_Collection_Date = (Building_Avilabel_Cheuqes.Rows[e.RowIndex].FindControl("lbl_B_Collection_Date") as Label);

            // Record The Income In Collection Talble
            if (Value_Cheque_Status == "4" || Value_Cheque_Status == "5" || Value_Cheque_Status == "6")
            {
                string Quary = "Select Collection From collection_table Where " +
                               "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "'" +
                               "And Mounth='" + Month_Cheques_Date + "' And Year='" + Year_Cheques_Date + "'";
                MySqlDataAdapter CollectionSda = new MySqlDataAdapter(Quary, _sqlCon);
                DataTable getCollectionDt = new DataTable();
                CollectionSda.Fill(getCollectionDt);
                if (getCollectionDt.Rows.Count > 0)
                {
                    string UPDATECollectionQuary = "UPDATE collection_table SET " +
                                                   " Collection = @Collection Where " +
                                                   "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "'" +
                                                   "And Mounth='" + Month_Cheques_Date + "' And Year='" + Year_Cheques_Date + "'";

                    _sqlCon.Open();
                    MySqlCommand UPDATECollectionCmd = new MySqlCommand(UPDATECollectionQuary, _sqlCon);
                    UPDATECollectionCmd.Parameters.AddWithValue("@Collection", lbl_Cheques_Amount);
                    UPDATECollectionCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                else
                {
                    string AddCollectionQuary = "Insert Into collection_table" +
                                           " (Ownersip_Id,Building_Id,Mounth,Year,Collection) " +
                                           "VALUES" +
                                           "(@Ownersip_Id,@Building_Id,@Mounth,@Year,@Collection)";
                    _sqlCon.Open();
                    MySqlCommand addCollectionCmd = new MySqlCommand(AddCollectionQuary, _sqlCon);
                    addCollectionCmd.Parameters.AddWithValue("@Ownersip_Id", lbl_Ownership_ID);
                    addCollectionCmd.Parameters.AddWithValue("@Building_Id", lbl_Building_ID);
                    addCollectionCmd.Parameters.AddWithValue("@Mounth", Month_Cheques_Date);
                    addCollectionCmd.Parameters.AddWithValue("@Year", Year_Cheques_Date);
                    addCollectionCmd.Parameters.AddWithValue("@Collection", lbl_Cheques_Amount);
                    addCollectionCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                _sqlCon.Close();
            }
            else if (Value_Cheque_Status == "1" || Value_Cheque_Status == "2" || Value_Cheque_Status == "7" || Value_Cheque_Status == "8" || Value_Cheque_Status == "9")
            {
                string Quary = "Select Collection From collection_table Where " +
                               "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "'" +
                               "And Mounth='" + Month_Cheques_Date + "' And Year='" + Year_Cheques_Date + "'";
                MySqlDataAdapter CollectionSda = new MySqlDataAdapter(Quary, _sqlCon);
                DataTable getCollectionDt = new DataTable();
                CollectionSda.Fill(getCollectionDt);
                if (getCollectionDt.Rows.Count > 0)
                {
                    _sqlCon.Open();
                    string deleteCollectionQuary = "DELETE FROM collection_table WHERE " +
                                                   "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "'" +
                                                   "And Mounth='" + Month_Cheques_Date + "' And Year='" + Year_Cheques_Date + "'";
                    MySqlCommand mySqlCmd = new MySqlCommand(deleteCollectionQuary, _sqlCon);
                    mySqlCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
            }
            else
            {
                Building_Avilabel_Cheuqes.EditIndex = -1; this.BindData();

                DataTable getTenantDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getTenantCmd = new MySqlCommand("SELECT Tenants_Mobile FROM tenants WHERE Tenants_ID = '" + lbl_Tenants_Id + "'", _sqlCon);
                MySqlDataAdapter getTenantDa = new MySqlDataAdapter(getTenantCmd);
                getTenantDa.Fill(getTenantDt);
                if (getTenantDt.Rows.Count > 0)
                {
                    string Tenants_Mobile = getTenantDt.Rows[0]["Tenants_Mobile"].ToString();
                    string Sms = "  شركة المنارة : عزيزي المستأجر تم إرجاع الشيك ذو الرقم" + lbl_Cheques_No + " من قبل البنك يرجى متابعة الأمر";
                    Utilities.Helper.SendSms(Tenants_Mobile, Sms);
                }
                _sqlCon.Close();
            }

            string query = "UPDATE building_cheques SET Cheques_Status = @Cheques_Status , Cheques_Date = @Cheques_Date , Collection_Date=@Collection_Date WHERE Cheques_Id = @Cheques_Id";
            using (MySqlCommand cmd = new MySqlCommand(query, _sqlCon))
            {
                cmd.Parameters.AddWithValue("@Cheques_Id", Cheques_Id);
                cmd.Parameters.AddWithValue("@Cheques_Status", txt_Cheque_Status);

                if (calendar2 != "01/01/0001") { cmd.Parameters.AddWithValue("@Cheques_Date", calendar2); }
                else { cmd.Parameters.AddWithValue("@Cheques_Date", lbl_Cheques_Date.Text); }



                //if (B_CollectionDate_Calendar != "01/01/0001") { cmd.Parameters.AddWithValue("@Collection_Date", B_CollectionDate_Calendar); }
                //else { cmd.Parameters.AddWithValue("@Collection_Date", lbl_B_Collection_Date.Text); }


                if (Value_Cheque_Status == "1" || Value_Cheque_Status == "2" || Value_Cheque_Status == "7" || Value_Cheque_Status == "8" || Value_Cheque_Status == "9")
                {
                    cmd.Parameters.AddWithValue("@Collection_Date", "");
                }
                else
                {
                    if (B_CollectionDate_Calendar != "01/01/0001") { cmd.Parameters.AddWithValue("@Collection_Date", B_CollectionDate_Calendar); }
                    else { cmd.Parameters.AddWithValue("@Collection_Date", lbl_B_Collection_Date.Text); }
                }


                _sqlCon.Open(); cmd.ExecuteNonQuery(); _sqlCon.Close(); Building_Avilabel_Cheuqes.EditIndex = -1; this.BindData();
            }
            Building_Avilabel_Cheuqes.EditIndex = -1; this.Building_BindData();
        }

        protected void Btn_Print_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }

        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=جدول التحصيل لشيكات العقود المفردة.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                Avilabel_Cheuqes.AllowPaging = false;
                this.BindData();

                Avilabel_Cheuqes.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in Avilabel_Cheuqes.HeaderRow.Cells)
                {
                    cell.BackColor = Avilabel_Cheuqes.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in Avilabel_Cheuqes.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = Avilabel_Cheuqes.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = Avilabel_Cheuqes.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                Avilabel_Cheuqes.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }

        }

        private void Building_ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=جدول التحصيل لشيكات العقود المجملة.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                Building_Avilabel_Cheuqes.AllowPaging = false;
                this.BindData();

                Building_Avilabel_Cheuqes.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in Building_Avilabel_Cheuqes.HeaderRow.Cells)
                {
                    cell.BackColor = Building_Avilabel_Cheuqes.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in Building_Avilabel_Cheuqes.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = Building_Avilabel_Cheuqes.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = Building_Avilabel_Cheuqes.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                Building_Avilabel_Cheuqes.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Building_ExportGridToExcel();
        }



        //*****************************************************  تحصيل الحوالات *****************************************************************
        protected void Transformation_BindData(string sortExpression = null)
        {
            //try
            //{
            _sqlCon.Open();
            DateTime dateTime = DateTime.Now;
            using (MySqlCommand Contract_ChequesCmd = new MySqlCommand("Avilable_transformation", _sqlCon))
            {
                Contract_ChequesCmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter Contract_ChequesSda = new MySqlDataAdapter(Contract_ChequesCmd);

                DataTable Contract_ChequesDt = new DataTable();
                Contract_ChequesSda.Fill(Contract_ChequesDt);
                Contract_ChequesCmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                Contract_ChequesSda.Fill(dt);
                Avilabel_transformation.DataSource = dt;
                Avilabel_transformation.DataBind();
            }
            _sqlCon.Close();
            //}
            //    catch { Response.Write(@"<script language='javascript'>alert('حدث خطأ ما لا يمكن عرض الشيكات')</script>"); }
        }

        protected void Avilabel_transformation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && Avilabel_transformation.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddl_Status = (DropDownList)e.Row.FindControl("Status_DropDownList");

                if (DataBinder.Eval(e.Row.DataItem, "Status").ToString() == "غير محصل")
                { string selected_Activ = "1"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }

                else if (DataBinder.Eval(e.Row.DataItem, "Status").ToString() == "محصل")
                { string selected_Activ = "2"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }
            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string test_lbl_Tr_Status = ((Label)e.Row.FindControl("test_lbl_Tr_Status")).Text;
                string Filter = Filter_DropDownList.SelectedItem.Text.Trim();
                if (Filter == "غير محصل")
                {
                    if (test_lbl_Tr_Status == "محصل")
                    {
                        e.Row.Visible = false;
                    }
                }
                else if (Filter == "محصل")
                {
                    if (test_lbl_Tr_Status == "غير محصل")
                    {
                        e.Row.Visible = false;
                    }
                }
                else { e.Row.Visible = true; }
            }
        }

        protected void Avilabel_transformation_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Avilabel_transformation.EditIndex = e.NewEditIndex; this.Transformation_BindData();
        }
        protected void Avilabel_transformation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Avilabel_transformation.EditIndex = -1; this.Transformation_BindData();
        }

        protected void Avilabel_transformation_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string lbl_Ownership_ID = (Avilabel_transformation.Rows[e.RowIndex].FindControl("lbl_Ownership_ID") as Label).Text;
            string lbl_Building_ID = (Avilabel_transformation.Rows[e.RowIndex].FindControl("lbl_Building_ID") as Label).Text;
            string lbl_Unit_ID = (Avilabel_transformation.Rows[e.RowIndex].FindControl("lbl_Unit_ID") as Label).Text;



            string txt_transformation_Status = (Avilabel_transformation.Rows[e.RowIndex].FindControl("Status_DropDownList") as DropDownList).SelectedItem.Text.Trim();
            string Value_transformation_Status = (Avilabel_transformation.Rows[e.RowIndex].FindControl("Status_DropDownList") as DropDownList).SelectedValue;
            string transformation_Id = Avilabel_transformation.DataKeys[e.RowIndex].Value.ToString();



            Calendar Collection_Date_Calendar = (Avilabel_transformation.Rows[e.RowIndex]).FindControl("Collection_Date_Calendar") as Calendar;
            string CollectionDate_Calendar = Collection_Date_Calendar.SelectedDate.ToString("dd/MM/yyyy");
            Label lbl_Collection_Date = (Avilabel_transformation.Rows[e.RowIndex].FindControl("lbl_Collection_Date") as Label);





            string Month_transformation_Date = Convert.ToString(Convert.ToDateTime((Avilabel_transformation.Rows[e.RowIndex].FindControl("lbl_transformation_Date") as Label).Text).Month);
            string Year_transformation_Date = Convert.ToString(Convert.ToDateTime((Avilabel_transformation.Rows[e.RowIndex].FindControl("lbl_transformation_Date") as Label).Text).Year);
            string lbl_transformation_Amount = (Avilabel_transformation.Rows[e.RowIndex].FindControl("lbl_Amount") as Label).Text;











            // Record The Income In Collection Talble
            if (Value_transformation_Status == "2")
            {
                string Quary = "Select Collection From collection_table Where " +
                               "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "' And Unit_Id='" + lbl_Unit_ID + "' " +
                               "And Mounth='" + Month_transformation_Date + "' And Year='" + Year_transformation_Date + "'";
                MySqlDataAdapter CollectionSda = new MySqlDataAdapter(Quary, _sqlCon);
                DataTable getCollectionDt = new DataTable();
                CollectionSda.Fill(getCollectionDt);
                if (getCollectionDt.Rows.Count > 0)
                {
                    string UPDATECollectionQuary = "UPDATE collection_table SET " +
                                                   " Collection = @Collection Where " +
                                                   "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "' And Unit_Id='" + lbl_Unit_ID + "' " +
                                                   "And Mounth='" + Month_transformation_Date + "' And Year='" + Year_transformation_Date + "'";

                    _sqlCon.Open();
                    MySqlCommand UPDATECollectionCmd = new MySqlCommand(UPDATECollectionQuary, _sqlCon);
                    UPDATECollectionCmd.Parameters.AddWithValue("@Collection", lbl_transformation_Amount);
                    UPDATECollectionCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                else
                {
                    string AddCollectionQuary = "Insert Into collection_table" +
                                           " (Ownersip_Id,Building_Id,Unit_Id,Mounth,Year,Collection) " +
                                           "VALUES" +
                                           "(@Ownersip_Id,@Building_Id,@Unit_Id,@Mounth,@Year,@Collection)";
                    _sqlCon.Open();
                    MySqlCommand addCollectionCmd = new MySqlCommand(AddCollectionQuary, _sqlCon);
                    addCollectionCmd.Parameters.AddWithValue("@Ownersip_Id", lbl_Ownership_ID);
                    addCollectionCmd.Parameters.AddWithValue("@Building_Id", lbl_Building_ID);
                    addCollectionCmd.Parameters.AddWithValue("@Unit_Id", lbl_Unit_ID);
                    addCollectionCmd.Parameters.AddWithValue("@Mounth", Month_transformation_Date);
                    addCollectionCmd.Parameters.AddWithValue("@Year", Year_transformation_Date);
                    addCollectionCmd.Parameters.AddWithValue("@Collection", lbl_transformation_Amount);
                    addCollectionCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                _sqlCon.Close();
            }
            else
            {
                string Quary = "Select Collection From collection_table Where " +
                               "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "' And Unit_Id='" + lbl_Unit_ID + "' " +
                               "And Mounth='" + Month_transformation_Date + "' And Year='" + Year_transformation_Date + "'";
                MySqlDataAdapter CollectionSda = new MySqlDataAdapter(Quary, _sqlCon);
                DataTable getCollectionDt = new DataTable();
                CollectionSda.Fill(getCollectionDt);
                if (getCollectionDt.Rows.Count > 0)
                {
                    string UPDATECollectionQuary = "UPDATE collection_table SET " +
                                                   " Collection = @Collection Where " +
                                                   "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "' And Unit_Id='" + lbl_Unit_ID + "' " +
                                                   "And Mounth='" + Month_transformation_Date + "' And Year='" + Year_transformation_Date + "'";

                    _sqlCon.Open();
                    MySqlCommand UPDATECollectionCmd = new MySqlCommand(UPDATECollectionQuary, _sqlCon);
                    UPDATECollectionCmd.Parameters.AddWithValue("@Collection", "");
                    UPDATECollectionCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
            }




            string query = "UPDATE transformation_table" +
                        " SET " +
                        "Status = @Status , " +
                        "Collection_Date=@Collection_Date" +
                        " WHERE transformation_Table_ID = @transformation_Table_ID";
            using (MySqlCommand cmd = new MySqlCommand(query, _sqlCon))
            {
                cmd.Parameters.AddWithValue("@transformation_Table_ID", transformation_Id);
                cmd.Parameters.AddWithValue("@Status", txt_transformation_Status);



                //if (CollectionDate_Calendar != "01/01/0001") { cmd.Parameters.AddWithValue("@Collection_Date", CollectionDate_Calendar); }
                //else { cmd.Parameters.AddWithValue("@Collection_Date", lbl_Collection_Date.Text); }



                if (Value_transformation_Status == "1")
                {
                    cmd.Parameters.AddWithValue("@Collection_Date", "");
                }
                else
                {
                    if (CollectionDate_Calendar != "01/01/0001") { cmd.Parameters.AddWithValue("@Collection_Date", CollectionDate_Calendar); }
                    else { cmd.Parameters.AddWithValue("@Collection_Date", lbl_Collection_Date.Text); }
                }

                _sqlCon.Open(); cmd.ExecuteNonQuery(); _sqlCon.Close(); Avilabel_transformation.EditIndex = -1; this.Transformation_BindData();
            }


        }


        //*****************************************************************************************************************************************************




        protected void Transformation_Building_BindData(string sortExpression = null)
        {
            //try
            //{
            _sqlCon.Open();
            DateTime dateTime = DateTime.Now;
            using (MySqlCommand Contract_ChequesCmd = new MySqlCommand("Building_Avilable_transformation", _sqlCon))
            {
                Contract_ChequesCmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter Contract_ChequesSda = new MySqlDataAdapter(Contract_ChequesCmd);

                DataTable Contract_ChequesDt = new DataTable();
                Contract_ChequesSda.Fill(Contract_ChequesDt);
                Contract_ChequesCmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                Contract_ChequesSda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            _sqlCon.Close();
            //}
            //    catch { Response.Write(@"<script language='javascript'>alert('حدث خطأ ما لا يمكن عرض الشيكات')</script>"); }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddl_Status = (DropDownList)e.Row.FindControl("Status_DropDownList");

                if (DataBinder.Eval(e.Row.DataItem, "Status").ToString() == "غير محصل")
                { string selected_Activ = "1"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }

                else if (DataBinder.Eval(e.Row.DataItem, "Status").ToString() == "محصل")
                { string selected_Activ = "2"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string test_lbl_Tr_Status = ((Label)e.Row.FindControl("test_lbl_Tr_Status")).Text;
                string Filter = Filter_DropDownList.SelectedItem.Text.Trim();
                if (Filter == "غير محصل")
                {
                    if (test_lbl_Tr_Status == "محصل")
                    {
                        e.Row.Visible = false;
                    }
                }
                else if (Filter == "محصل")
                {
                    if (test_lbl_Tr_Status == "غير محصل")
                    {
                        e.Row.Visible = false;
                    }
                }
                else { e.Row.Visible = true; }
            }
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex; this.Transformation_Building_BindData();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1; this.Transformation_Building_BindData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            string lbl_Ownership_ID = (GridView1.Rows[e.RowIndex].FindControl("lbl_Ownership_ID") as Label).Text;
            string lbl_Building_ID = (GridView1.Rows[e.RowIndex].FindControl("lbl_Building_ID") as Label).Text;



            string txt_transformation_Status = (GridView1.Rows[e.RowIndex].FindControl("Status_DropDownList") as DropDownList).SelectedItem.Text.Trim();
            string Value_transformation_Status = (GridView1.Rows[e.RowIndex].FindControl("Status_DropDownList") as DropDownList).SelectedValue;
            string transformation_Id = GridView1.DataKeys[e.RowIndex].Value.ToString();



            Calendar Collection_Date_Calendar = (GridView1.Rows[e.RowIndex]).FindControl("Collection_Date_Calendar") as Calendar;
            string CollectionDate_Calendar = Collection_Date_Calendar.SelectedDate.ToString("dd/MM/yyyy");
            Label lbl_Collection_Date = (GridView1.Rows[e.RowIndex].FindControl("lbl_Collection_Date") as Label);





            string Month_transformation_Date = Convert.ToString(Convert.ToDateTime((GridView1.Rows[e.RowIndex].FindControl("lbl_transformation_Date") as Label).Text).Month);
            string Year_transformation_Date = Convert.ToString(Convert.ToDateTime((GridView1.Rows[e.RowIndex].FindControl("lbl_transformation_Date") as Label).Text).Year);
            string lbl_transformation_Amount = (GridView1.Rows[e.RowIndex].FindControl("lbl_Amount") as Label).Text;






            if (Value_transformation_Status == "2")
            {
                string Quary = "Select Collection From collection_table Where " +
                               "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "'  " +
                               "And Mounth='" + Month_transformation_Date + "' And Year='" + Year_transformation_Date + "'";
                MySqlDataAdapter CollectionSda = new MySqlDataAdapter(Quary, _sqlCon);
                DataTable getCollectionDt = new DataTable();
                CollectionSda.Fill(getCollectionDt);
                if (getCollectionDt.Rows.Count > 0)
                {
                    string UPDATECollectionQuary = "UPDATE collection_table SET " +
                                                   " Collection = @Collection Where " +
                                                   "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "'" +
                                                   "And Mounth='" + Month_transformation_Date + "' And Year='" + Year_transformation_Date + "'";

                    _sqlCon.Open();
                    MySqlCommand UPDATECollectionCmd = new MySqlCommand(UPDATECollectionQuary, _sqlCon);
                    UPDATECollectionCmd.Parameters.AddWithValue("@Collection", lbl_transformation_Amount);
                    UPDATECollectionCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                else
                {
                    string AddCollectionQuary = "Insert Into collection_table" +
                                           " (Ownersip_Id,Building_Id, Mounth,Year,Collection) " +
                                           "VALUES" +
                                           "(@Ownersip_Id,@Building_Id, @Mounth,@Year,@Collection)";
                    _sqlCon.Open();
                    MySqlCommand addCollectionCmd = new MySqlCommand(AddCollectionQuary, _sqlCon);
                    addCollectionCmd.Parameters.AddWithValue("@Ownersip_Id", lbl_Ownership_ID);
                    addCollectionCmd.Parameters.AddWithValue("@Building_Id", lbl_Building_ID);
                    addCollectionCmd.Parameters.AddWithValue("@Mounth", Month_transformation_Date);
                    addCollectionCmd.Parameters.AddWithValue("@Year", Year_transformation_Date);
                    addCollectionCmd.Parameters.AddWithValue("@Collection", lbl_transformation_Amount);
                    addCollectionCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                _sqlCon.Close();
            }
            else
            {
                string Quary = "Select Collection From collection_table Where " +
                               "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "'  " +
                               "And Mounth='" + Month_transformation_Date + "' And Year='" + Year_transformation_Date + "'";
                MySqlDataAdapter CollectionSda = new MySqlDataAdapter(Quary, _sqlCon);
                DataTable getCollectionDt = new DataTable();
                CollectionSda.Fill(getCollectionDt);
                if (getCollectionDt.Rows.Count > 0)
                {
                    string UPDATECollectionQuary = "UPDATE collection_table SET " +
                                                   " Collection = @Collection Where " +
                                                   "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "'  " +
                                                   "And Mounth='" + Month_transformation_Date + "' And Year='" + Year_transformation_Date + "'";

                    _sqlCon.Open();
                    MySqlCommand UPDATECollectionCmd = new MySqlCommand(UPDATECollectionQuary, _sqlCon);
                    UPDATECollectionCmd.Parameters.AddWithValue("@Collection", "");
                    UPDATECollectionCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
            }




            string query = "UPDATE building_transformation_table" +
                            " SET " +
                            "Status = @Status , " +
                            "Collection_Date=@Collection_Date" +
                            " WHERE transformation_Table_ID = @transformation_Table_ID";
            using (MySqlCommand cmd = new MySqlCommand(query, _sqlCon))
            {
                cmd.Parameters.AddWithValue("@transformation_Table_ID", transformation_Id);
                cmd.Parameters.AddWithValue("@Status", txt_transformation_Status);



                //if (CollectionDate_Calendar != "01/01/0001") { cmd.Parameters.AddWithValue("@Collection_Date", CollectionDate_Calendar); }
                //else { cmd.Parameters.AddWithValue("@Collection_Date", lbl_Collection_Date.Text); }



                if (Value_transformation_Status == "1")
                {
                    cmd.Parameters.AddWithValue("@Collection_Date", "");
                }
                else
                {
                    if (CollectionDate_Calendar != "01/01/0001") { cmd.Parameters.AddWithValue("@Collection_Date", CollectionDate_Calendar); }
                    else { cmd.Parameters.AddWithValue("@Collection_Date", lbl_Collection_Date.Text); }
                }

                _sqlCon.Open(); cmd.ExecuteNonQuery(); _sqlCon.Close(); GridView1.EditIndex = -1; this.Transformation_Building_BindData();
            }
        }


        //******************************************************************* تحصيل الدفعات **************************************************

        protected void  Cash_BindData(string sortExpression = null)
        {
            //try
            //{
            _sqlCon.Open();
            DateTime dateTime = DateTime.Now;
            using (MySqlCommand Contract_CashCmd = new MySqlCommand("Avilabel_Cash_Amount", _sqlCon))
            {
                Contract_CashCmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter Contract_CashSda = new MySqlDataAdapter(Contract_CashCmd);

                DataTable Contract_CashDt = new DataTable();
                Contract_CashSda.Fill(Contract_CashDt);
                Contract_CashCmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                Contract_CashSda.Fill(dt);
                Avilabel_Cash.DataSource = dt;
                Avilabel_Cash.DataBind();
            }
            _sqlCon.Close();
            //}
            //    catch { Response.Write(@"<script language='javascript'>alert('حدث خطأ ما لا يمكن عرض الشيكات')</script>"); }
        }

        protected void Avilabel_Cash_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && Avilabel_Cash.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddl_Status = (DropDownList)e.Row.FindControl("Status_DropDownList");

                if (DataBinder.Eval(e.Row.DataItem, "Satuts").ToString() == "غير محصل")
                { string selected_Activ = "1"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }

                else if (DataBinder.Eval(e.Row.DataItem, "Satuts").ToString() == "محصل")
                { string selected_Activ = "2"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }
            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string test_lbl_Tr_Status = ((Label)e.Row.FindControl("test_lbl_Tr_Status")).Text;
                string Filter = Filter_DropDownList.SelectedItem.Text.Trim();
                if (Filter == "غير محصل")
                {
                    if (test_lbl_Tr_Status == "محصل")
                    {
                        e.Row.Visible = false;
                    }
                }
                else if (Filter == "محصل")
                {
                    if (test_lbl_Tr_Status == "غير محصل")
                    {
                        e.Row.Visible = false;
                    }
                }
                else { e.Row.Visible = true; }
            }
        }

        protected void Avilabel_Cash_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Avilabel_Cash.EditIndex = e.NewEditIndex; this.Cash_BindData();
        }
        protected void Avilabel_Cash_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Avilabel_Cash.EditIndex = -1; this.Cash_BindData();
        }
        protected void Avilabel_Cash_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string lbl_Ownership_ID = (Avilabel_Cash.Rows[e.RowIndex].FindControl("lbl_Ownership_ID") as Label).Text;
            string lbl_Building_ID = (Avilabel_Cash.Rows[e.RowIndex].FindControl("lbl_Building_ID") as Label).Text;
            string lbl_Unit_ID = (Avilabel_Cash.Rows[e.RowIndex].FindControl("lbl_Unit_ID") as Label).Text;



            string txt_Cash_Status = (Avilabel_Cash.Rows[e.RowIndex].FindControl("Status_DropDownList") as DropDownList).SelectedItem.Text.Trim();
            string Value_Cash_Status = (Avilabel_Cash.Rows[e.RowIndex].FindControl("Status_DropDownList") as DropDownList).SelectedValue;
            string Cash_Id = Avilabel_Cash.DataKeys[e.RowIndex].Value.ToString();



            Calendar Collection_Date_Calendar = (Avilabel_Cash.Rows[e.RowIndex]).FindControl("Collection_Date_Calendar") as Calendar;
            string CollectionDate_Calendar = Collection_Date_Calendar.SelectedDate.ToString("dd/MM/yyyy");
            Label lbl_Collection_Date = (Avilabel_Cash.Rows[e.RowIndex].FindControl("lbl_Collection_Date") as Label);





            string Month_Cash_Date = Convert.ToString(Convert.ToDateTime((Avilabel_Cash.Rows[e.RowIndex].FindControl("lbl_Cash_Date") as Label).Text).Month);
            string Year_Cash_Date = Convert.ToString(Convert.ToDateTime((Avilabel_Cash.Rows[e.RowIndex].FindControl("lbl_Cash_Date") as Label).Text).Year);
            string lbl_Cash_Amount = (Avilabel_Cash.Rows[e.RowIndex].FindControl("lbl_Cash_Amount") as Label).Text;






            // Record The Income In Collection Talble
            if (Value_Cash_Status == "2")
            {
                string Quary = "Select Collection From collection_table Where " +
                               "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "' And Unit_Id='" + lbl_Unit_ID + "' " +
                               "And Mounth='" + Month_Cash_Date + "' And Year='" + Year_Cash_Date + "'";
                MySqlDataAdapter CollectionSda = new MySqlDataAdapter(Quary, _sqlCon);
                DataTable getCollectionDt = new DataTable();
                CollectionSda.Fill(getCollectionDt);
                if (getCollectionDt.Rows.Count > 0)
                {
                    string UPDATECollectionQuary = "UPDATE collection_table SET " +
                                                   " Collection = @Collection Where " +
                                                   "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "' And Unit_Id='" + lbl_Unit_ID + "' " +
                                                   "And Mounth='" + Month_Cash_Date + "' And Year='" + Year_Cash_Date + "'";

                    _sqlCon.Open();
                    MySqlCommand UPDATECollectionCmd = new MySqlCommand(UPDATECollectionQuary, _sqlCon);
                    UPDATECollectionCmd.Parameters.AddWithValue("@Collection", lbl_Cash_Amount);
                    UPDATECollectionCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                else
                {
                    string AddCollectionQuary = "Insert Into collection_table" +
                                           " (Ownersip_Id,Building_Id,Unit_Id,Mounth,Year,Collection) " +
                                           "VALUES" +
                                           "(@Ownersip_Id,@Building_Id,@Unit_Id,@Mounth,@Year,@Collection)";
                    _sqlCon.Open();
                    MySqlCommand addCollectionCmd = new MySqlCommand(AddCollectionQuary, _sqlCon);
                    addCollectionCmd.Parameters.AddWithValue("@Ownersip_Id", lbl_Ownership_ID);
                    addCollectionCmd.Parameters.AddWithValue("@Building_Id", lbl_Building_ID);
                    addCollectionCmd.Parameters.AddWithValue("@Unit_Id", lbl_Unit_ID);
                    addCollectionCmd.Parameters.AddWithValue("@Mounth", Month_Cash_Date);
                    addCollectionCmd.Parameters.AddWithValue("@Year", Year_Cash_Date);
                    addCollectionCmd.Parameters.AddWithValue("@Collection", lbl_Cash_Amount);
                    addCollectionCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                _sqlCon.Close();
            }

            else
            {
                string Quary = "Select Collection From collection_table Where " +
                               "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "' and Unit_Id = '"+lbl_Unit_ID+"' " +
                               "And Mounth='" + Month_Cash_Date + "' And Year='" + Year_Cash_Date + "'";
                MySqlDataAdapter CollectionSda = new MySqlDataAdapter(Quary, _sqlCon);
                DataTable getCollectionDt = new DataTable();
                CollectionSda.Fill(getCollectionDt);
                if (getCollectionDt.Rows.Count > 0)
                {
                    string UPDATECollectionQuary = "UPDATE collection_table SET " +
                                                   " Collection = @Collection Where " +
                                                   "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "' and Unit_Id = '"+lbl_Unit_ID+"' " +
                                                   "And Mounth='" + Month_Cash_Date + "' And Year='" + Year_Cash_Date + "'";

                    _sqlCon.Open();
                    MySqlCommand UPDATECollectionCmd = new MySqlCommand(UPDATECollectionQuary, _sqlCon);
                    UPDATECollectionCmd.Parameters.AddWithValue("@Collection", "");
                    UPDATECollectionCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
            }


            string query = "UPDATE cash_amount" +
                           " SET " +
                           "Satuts = @Satuts , " +
                           "Collection_Date=@Collection_Date" +
                           " WHERE Cash_Amount_ID = @Cash_Amount_ID";
            using (MySqlCommand cmd = new MySqlCommand(query, _sqlCon))
            {
                cmd.Parameters.AddWithValue("@Cash_Amount_ID", Cash_Id);
                cmd.Parameters.AddWithValue("@Satuts", txt_Cash_Status);



                //if (CollectionDate_Calendar != "01/01/0001") { cmd.Parameters.AddWithValue("@Collection_Date", CollectionDate_Calendar); }
                //else { cmd.Parameters.AddWithValue("@Collection_Date", lbl_Collection_Date.Text); }



                if (Value_Cash_Status == "1")
                {
                    cmd.Parameters.AddWithValue("@Collection_Date", "");
                }
                else
                {
                    if (CollectionDate_Calendar != "01/01/0001") { cmd.Parameters.AddWithValue("@Collection_Date", CollectionDate_Calendar); }
                    else { cmd.Parameters.AddWithValue("@Collection_Date", lbl_Collection_Date.Text); }
                }

                _sqlCon.Open(); cmd.ExecuteNonQuery(); _sqlCon.Close(); Avilabel_Cash.EditIndex = -1; this.Cash_BindData();
            }
        }
        //*****************************************************************************************************************************


        protected void Cash_Building_BindData(string sortExpression = null)
        {
            //try
            //{
            _sqlCon.Open();
            DateTime dateTime = DateTime.Now;
            using (MySqlCommand Contract_CashCmd = new MySqlCommand("Building_Avilable_Cash", _sqlCon))
            {
                Contract_CashCmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter Contract_CashSda = new MySqlDataAdapter(Contract_CashCmd);

                DataTable Contract_CashDt = new DataTable();
                Contract_CashSda.Fill(Contract_CashDt);
                Contract_CashCmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                Contract_CashSda.Fill(dt);
                Building_Cash_Amount.DataSource = dt;
                Building_Cash_Amount.DataBind();
            }
            _sqlCon.Close();
            //}
            //    catch { Response.Write(@"<script language='javascript'>alert('حدث خطأ ما لا يمكن عرض الشيكات')</script>"); }
        }
        protected void Building_Cash_Amount_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && Building_Cash_Amount.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddl_Status = (DropDownList)e.Row.FindControl("Status_DropDownList");

                if (DataBinder.Eval(e.Row.DataItem, "Satuts").ToString() == "غير محصل")
                { string selected_Activ = "1"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }

                else if (DataBinder.Eval(e.Row.DataItem, "Satuts").ToString() == "محصل")
                { string selected_Activ = "2"; ddl_Status.Items.FindByValue(selected_Activ).Selected = true; }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string test_lbl_Tr_Status = ((Label)e.Row.FindControl("test_lbl_Tr_Status")).Text;
                string Filter = Filter_DropDownList.SelectedItem.Text.Trim();
                if (Filter == "غير محصل")
                {
                    if (test_lbl_Tr_Status == "محصل")
                    {
                        e.Row.Visible = false;
                    }
                }
                else if (Filter == "محصل")
                {
                    if (test_lbl_Tr_Status == "غير محصل")
                    {
                        e.Row.Visible = false;
                    }
                }
                else { e.Row.Visible = true; }
            }
        }

        protected void Building_Cash_Amount_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Building_Cash_Amount.EditIndex = e.NewEditIndex; this.Cash_Building_BindData();
        }
        protected void Building_Cash_Amount_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Building_Cash_Amount.EditIndex = -1; this.Cash_Building_BindData();
        }
        protected void Building_Cash_Amount_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string lbl_Ownership_ID = (Building_Cash_Amount.Rows[e.RowIndex].FindControl("lbl_Ownership_ID") as Label).Text;
            string lbl_Building_ID = (Building_Cash_Amount.Rows[e.RowIndex].FindControl("lbl_Building_ID") as Label).Text;



            string txt_Cash_Status = (Building_Cash_Amount.Rows[e.RowIndex].FindControl("Status_DropDownList") as DropDownList).SelectedItem.Text.Trim();
            string Value_Cash_Status = (Building_Cash_Amount.Rows[e.RowIndex].FindControl("Status_DropDownList") as DropDownList).SelectedValue;
            string Cash_Id = Building_Cash_Amount.DataKeys[e.RowIndex].Value.ToString();



            Calendar Collection_Date_Calendar = (Building_Cash_Amount.Rows[e.RowIndex]).FindControl("Collection_Date_Calendar") as Calendar;
            string CollectionDate_Calendar = Collection_Date_Calendar.SelectedDate.ToString("dd/MM/yyyy");
            Label lbl_Collection_Date = (Building_Cash_Amount.Rows[e.RowIndex].FindControl("lbl_Collection_Date") as Label);





            string Month_Cash_Date = Convert.ToString(Convert.ToDateTime((Building_Cash_Amount.Rows[e.RowIndex].FindControl("lbl_Cash_Date") as Label).Text).Month);
            string Year_Cash_Date = Convert.ToString(Convert.ToDateTime((Building_Cash_Amount.Rows[e.RowIndex].FindControl("lbl_Cash_Date") as Label).Text).Year);
            string lbl_Cash_Amount = (Building_Cash_Amount.Rows[e.RowIndex].FindControl("lbl_Cash_Amount") as Label).Text;






            // Record The Income In Collection Talble
            if (Value_Cash_Status == "2")
            {
                string Quary = "Select Collection From collection_table Where " +
                               "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "' " +
                               "And Mounth='" + Month_Cash_Date + "' And Year='" + Year_Cash_Date + "'";
                MySqlDataAdapter CollectionSda = new MySqlDataAdapter(Quary, _sqlCon);
                DataTable getCollectionDt = new DataTable();
                CollectionSda.Fill(getCollectionDt);
                if (getCollectionDt.Rows.Count > 0)
                {
                    string UPDATECollectionQuary = "UPDATE collection_table SET " +
                                                   " Collection = @Collection Where " +
                                                   "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "' " +
                                                   "And Mounth='" + Month_Cash_Date + "' And Year='" + Year_Cash_Date + "'";

                    _sqlCon.Open();
                    MySqlCommand UPDATECollectionCmd = new MySqlCommand(UPDATECollectionQuary, _sqlCon);
                    UPDATECollectionCmd.Parameters.AddWithValue("@Collection", lbl_Cash_Amount);
                    UPDATECollectionCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                else
                {
                    string AddCollectionQuary = "Insert Into collection_table" +
                                           " (Ownersip_Id,Building_Id,Mounth,Year,Collection) " +
                                           "VALUES" +
                                           "(@Ownersip_Id,@Building_Id,@Mounth,@Year,@Collection)";
                    _sqlCon.Open();
                    MySqlCommand addCollectionCmd = new MySqlCommand(AddCollectionQuary, _sqlCon);
                    addCollectionCmd.Parameters.AddWithValue("@Ownersip_Id", lbl_Ownership_ID);
                    addCollectionCmd.Parameters.AddWithValue("@Building_Id", lbl_Building_ID);
                    addCollectionCmd.Parameters.AddWithValue("@Mounth", Month_Cash_Date);
                    addCollectionCmd.Parameters.AddWithValue("@Year", Year_Cash_Date);
                    addCollectionCmd.Parameters.AddWithValue("@Collection", lbl_Cash_Amount);
                    addCollectionCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                _sqlCon.Close();
            }
            else
            {
                string Quary = "Select Collection From collection_table Where " +
                               "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "'  " +
                               "And Mounth='" + Month_Cash_Date + "' And Year='" + Year_Cash_Date + "'";
                MySqlDataAdapter CollectionSda = new MySqlDataAdapter(Quary, _sqlCon);
                DataTable getCollectionDt = new DataTable();
                CollectionSda.Fill(getCollectionDt);
                if (getCollectionDt.Rows.Count > 0)
                {
                    string UPDATECollectionQuary = "UPDATE collection_table SET " +
                                                   " Collection = @Collection Where " +
                                                   "Ownersip_Id='" + lbl_Ownership_ID + "' And Building_Id='" + lbl_Building_ID + "'  " +
                                                   "And Mounth='" + Month_Cash_Date + "' And Year='" + Year_Cash_Date + "'";

                    _sqlCon.Open();
                    MySqlCommand UPDATECollectionCmd = new MySqlCommand(UPDATECollectionQuary, _sqlCon);
                    UPDATECollectionCmd.Parameters.AddWithValue("@Collection", "");
                    UPDATECollectionCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
            }


            string query = "UPDATE building_cash_amount" +
                           " SET " +
                           "Satuts = @Satuts , " +
                           "Collection_Date=@Collection_Date" +
                           " WHERE Cash_Amount_ID = @Cash_Amount_ID";
            using (MySqlCommand cmd = new MySqlCommand(query, _sqlCon))
            {
                cmd.Parameters.AddWithValue("@Cash_Amount_ID", Cash_Id);
                cmd.Parameters.AddWithValue("@Satuts", txt_Cash_Status);



                //if (CollectionDate_Calendar != "01/01/0001") { cmd.Parameters.AddWithValue("@Collection_Date", CollectionDate_Calendar); }
                //else { cmd.Parameters.AddWithValue("@Collection_Date", lbl_Collection_Date.Text); }


                if (Value_Cash_Status == "1")
                {
                    cmd.Parameters.AddWithValue("@Collection_Date", "");
                }
                else
                {
                    if (CollectionDate_Calendar != "01/01/0001") { cmd.Parameters.AddWithValue("@Collection_Date", CollectionDate_Calendar); }
                    else { cmd.Parameters.AddWithValue("@Collection_Date", lbl_Collection_Date.Text); }
                }

                _sqlCon.Open(); cmd.ExecuteNonQuery(); _sqlCon.Close(); Building_Cash_Amount.EditIndex = -1; this.Cash_Building_BindData();
            }
        }

        protected void A_1_ServerClick(object sender, EventArgs e)
        {
            Cheuqes_Div.Visible = true; transformation_Div.Visible = false; cash_Div.Visible = false;
        }

        protected void A_2_ServerClick(object sender, EventArgs e)
        {
            Cheuqes_Div.Visible = false; transformation_Div.Visible = true; cash_Div.Visible = false;
        }

        protected void A_3_ServerClick(object sender, EventArgs e)
        {
            Cheuqes_Div.Visible = false; transformation_Div.Visible = false; cash_Div.Visible = true;
        }

        protected void A_4_ServerClick(object sender, EventArgs e)
        {
            Cheuqes_Div.Visible = true; transformation_Div.Visible = true; cash_Div.Visible = true;
        }

        protected void Filter_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
            Building_BindData();
            //******************* تحصيل الحوالات *************************
            Transformation_BindData();
            Transformation_Building_BindData();
            //************* تحصيل الدفعات **************************************************
            Cash_BindData();
            Cash_Building_BindData();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "1")
            {
                Cheuqes_Mfrade.Visible = true; transformation_Mufrade.Visible = true; cash_Mufrade_Div.Visible = true;
                Cheuqes_Mujmale.Visible = true; transformation_Mujmale.Visible= true; Cash_Mujmale_Deiv.Visible = true;
                Label1.Text = ""; Label2.Text = ""; 
                Label3.Text = ""; Label4.Text = ""; 
                Label6.Text = ""; Label7.Text = "";
            }
            else if (DropDownList1.SelectedValue == "2")
            {
                Cheuqes_Mfrade.Visible = true; transformation_Mufrade.Visible = true; cash_Mufrade_Div.Visible = true;
                Cheuqes_Mujmale.Visible = false; transformation_Mujmale.Visible = false; Cash_Mujmale_Deiv.Visible = false;

                Label1.Text = "شيكات العقود المفردة"; Label2.Text = ""; 
                Label3.Text = "حوالات العقود المفردة"; Label4.Text = ""; 
                Label6.Text = "دفعات العقود المفردة"; Label7.Text = "";
            }
            else
            {
                Cheuqes_Mfrade.Visible = false; transformation_Mufrade.Visible = false; cash_Mufrade_Div.Visible = false;
                Cheuqes_Mujmale.Visible = true; transformation_Mujmale.Visible = true; Cash_Mujmale_Deiv.Visible = true;
                Label1.Text = ""; Label2.Text = "شيكات العقود المجملة";
                Label3.Text = ""; Label4.Text = "حوالات العقود المجملة";
                Label6.Text = ""; Label7.Text = "دفعات العقود المجملة ";

            }
        }
    }
}