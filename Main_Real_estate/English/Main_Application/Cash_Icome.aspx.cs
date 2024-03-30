using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Cash_Icome : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindData();
                Building_BindData();
                DateTime Today = DateTime.Now;
                string TD = Today.ToString("dd/MM/yyyy");
                lbl_Avilabel_transformation.Text = "* الدفعات المستحقة لغاية تاريخ اليوم" + TD;
            }
        }


        protected void BindData(string sortExpression = null)
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
        }

        protected void Avilabel_Cash_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Avilabel_Cash.EditIndex = e.NewEditIndex; this.BindData();
        }
        protected void Avilabel_Cash_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Avilabel_Cash.EditIndex = -1; this.BindData();
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


            string query = "UPDATE cash_amount" +
                           " SET " +
                           "Satuts = @Satuts , " +
                           "Collection_Date=@Collection_Date" +
                           " WHERE Cash_Amount_ID = @Cash_Amount_ID";
            using (MySqlCommand cmd = new MySqlCommand(query, _sqlCon))
            {
                cmd.Parameters.AddWithValue("@Cash_Amount_ID", Cash_Id);
                cmd.Parameters.AddWithValue("@Satuts", txt_Cash_Status);



                if (CollectionDate_Calendar != "01/01/0001") { cmd.Parameters.AddWithValue("@Collection_Date", CollectionDate_Calendar); }
                else { cmd.Parameters.AddWithValue("@Collection_Date", lbl_Collection_Date.Text); }

                _sqlCon.Open(); cmd.ExecuteNonQuery(); _sqlCon.Close(); Avilabel_Cash.EditIndex = -1; this.BindData();
            }
        }
        //*****************************************************************************************************************************


        protected void Building_BindData(string sortExpression = null)
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
        }

        protected void Building_Cash_Amount_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Building_Cash_Amount.EditIndex = e.NewEditIndex; this.Building_BindData();
        }
        protected void Building_Cash_Amount_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Building_Cash_Amount.EditIndex = -1; this.Building_BindData();
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


            string query = "UPDATE building_cash_amount" +
                           " SET " +
                           "Satuts = @Satuts , " +
                           "Collection_Date=@Collection_Date" +
                           " WHERE Cash_Amount_ID = @Cash_Amount_ID";
            using (MySqlCommand cmd = new MySqlCommand(query, _sqlCon))
            {
                cmd.Parameters.AddWithValue("@Cash_Amount_ID", Cash_Id);
                cmd.Parameters.AddWithValue("@Satuts", txt_Cash_Status);



                if (CollectionDate_Calendar != "01/01/0001") { cmd.Parameters.AddWithValue("@Collection_Date", CollectionDate_Calendar); }
                else { cmd.Parameters.AddWithValue("@Collection_Date", lbl_Collection_Date.Text); }

                _sqlCon.Open(); cmd.ExecuteNonQuery(); _sqlCon.Close(); Building_Cash_Amount.EditIndex = -1; this.Building_BindData();
            }
        }

       
    }
}