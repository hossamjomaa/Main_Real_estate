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
    public partial class transformation_Icome : System.Web.UI.Page
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
                lbl_Avilabel_transformation.Text = "* الحوالات المستحقة لغاية تاريخ اليوم" + TD;
            }
        }

        protected void BindData(string sortExpression = null)
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
        }

        protected void Avilabel_transformation_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Avilabel_transformation.EditIndex = e.NewEditIndex; this.BindData();
        }
        protected void Avilabel_transformation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Avilabel_transformation.EditIndex = -1; this.BindData();
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
            if (Value_transformation_Status == "2" )
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
            



                string query = "UPDATE transformation_table" +
                            " SET " +
                            "Status = @Status , " +
                            "Collection_Date=@Collection_Date" +
                            " WHERE transformation_Table_ID = @transformation_Table_ID";
                using (MySqlCommand cmd = new MySqlCommand(query, _sqlCon))
                {
                    cmd.Parameters.AddWithValue("@transformation_Table_ID", transformation_Id);
                    cmd.Parameters.AddWithValue("@Status", txt_transformation_Status);



                    if (CollectionDate_Calendar != "01/01/0001") { cmd.Parameters.AddWithValue("@Collection_Date", CollectionDate_Calendar); }
                    else { cmd.Parameters.AddWithValue("@Collection_Date", lbl_Collection_Date.Text); }

                    _sqlCon.Open(); cmd.ExecuteNonQuery(); _sqlCon.Close(); Avilabel_transformation.EditIndex = -1; this.BindData();
                }
            

        }

       
        //*****************************************************************************************************************************************************




        protected void Building_BindData(string sortExpression = null)
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
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex; this.Building_BindData();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1; this.Building_BindData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            string lbl_Ownership_ID = (GridView1.Rows[e.RowIndex].FindControl("lbl_Ownership_ID") as Label).Text;
            string lbl_Building_ID = (GridView1.Rows[e.RowIndex].FindControl("lbl_Building_ID") as Label).Text;
            string lbl_Unit_ID = (GridView1.Rows[e.RowIndex].FindControl("lbl_Unit_ID") as Label).Text;



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




            string query = "UPDATE building_transformation_table" +
                            " SET " +
                            "Status = @Status , " +
                            "Collection_Date=@Collection_Date" +
                            " WHERE transformation_Table_ID = @transformation_Table_ID";
            using (MySqlCommand cmd = new MySqlCommand(query, _sqlCon))
            {
                cmd.Parameters.AddWithValue("@transformation_Table_ID", transformation_Id);
                cmd.Parameters.AddWithValue("@Status", txt_transformation_Status);



                if (CollectionDate_Calendar != "01/01/0001") { cmd.Parameters.AddWithValue("@Collection_Date", CollectionDate_Calendar); }
                else { cmd.Parameters.AddWithValue("@Collection_Date", lbl_Collection_Date.Text); }

                _sqlCon.Open(); cmd.ExecuteNonQuery(); _sqlCon.Close(); GridView1.EditIndex = -1; this.Building_BindData();
            }
        }

        
    }
}