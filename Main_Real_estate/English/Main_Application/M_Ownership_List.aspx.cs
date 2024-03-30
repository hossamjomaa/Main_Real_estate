using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace Main_Real_estate.English.Main_Application
{
    public partial class M_Ownership_List : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Add_permission(_sqlCon, Session["Role"].ToString(), "properties", Add);
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!this.IsPostBack)
            {
                //Fill Ownership Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM owner_ship ", _sqlCon, ownership_Name_DropDownList, "Owner_Ship_AR_Name", "Owner_Ship_Id");
                ownership_Name_DropDownList.Items.Insert(0, "أختر إسم الملكية....");

                //Fill Bank Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM bank", _sqlCon, Bank_Name_DropDownList, "Bank_Arabic_Name", "Bank_Id");
                Bank_Name_DropDownList.Items.Insert(0, "أختر جهة الرهن....");


                BindData();
            }
        }

        protected void btn_Add_M_OwnerShip_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string add_M_OwnerShip_Quary =  "Insert Into mortgaged_wonership " +
                                                "(Ownership_Id , Bank_Id , Mortgage_Value , Installment_Value , Start_Date , End_Date , Paymen_Type) " +
                                                "VALUES" +
                                                "(@Ownership_Id , @Bank_Id , @Mortgage_Value , @Installment_Value , @Start_Date , @End_Date , @Paymen_Type)";
                _sqlCon.Open();
                MySqlCommand add_M_OwnerShip_Cmd = new MySqlCommand(add_M_OwnerShip_Quary, _sqlCon);
                add_M_OwnerShip_Cmd.Parameters.AddWithValue("@Ownership_Id", ownership_Name_DropDownList.SelectedValue);
                add_M_OwnerShip_Cmd.Parameters.AddWithValue("@Bank_Id", Bank_Name_DropDownList.SelectedValue);
                add_M_OwnerShip_Cmd.Parameters.AddWithValue("@Mortgage_Value", txt_Mortgage_Value.Text);
                add_M_OwnerShip_Cmd.Parameters.AddWithValue("@Installment_Value", txt_Installment_Value.Text);
                add_M_OwnerShip_Cmd.Parameters.AddWithValue("@Start_Date", txt_Start_Date.Text);
                add_M_OwnerShip_Cmd.Parameters.AddWithValue("@End_Date", txt_End_Date.Text);
                add_M_OwnerShip_Cmd.Parameters.AddWithValue("@Paymen_Type", Paymen_Type_DropDownList.SelectedItem.Text);
                add_M_OwnerShip_Cmd.ExecuteNonQuery();
                _sqlCon.Close();
                Response.Redirect("M_Ownership_List.aspx");
            }
        }


        //******************  Start_Date ***************************************************
        protected void Start_Date_Calendar_SelectionChanged2(object sender, EventArgs e)
        {
            string Start_Dat = DateTime.Parse(Start_Date_Calendar.SelectedDate.ToString()).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            txt_Start_Date.Text = Start_Dat;
            if (txt_Start_Date.Text != "")
            {
                Start_Date_Div.Visible = false;
                ImageButton2.Visible = false;
            }
        }

        protected void Start_Date_Chosee_Click(object sender, EventArgs e)
        {
            Start_Date_Div.Visible = true;
            ImageButton2.Visible = true;
        }

        protected void ImageButton2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Start_Date_Div.Visible = false;
            ImageButton2.Visible = false;
        }

        //******************  End_Date ***************************************************
        protected void End_Date_Chosee_Click(object sender, EventArgs e)
        {
            End_Date_Div.Visible = true;
            ImageButton3.Visible = true;
        }

        protected void ImageButton3_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            End_Date_Div.Visible = false;
            ImageButton3.Visible = false;
        }

        protected void End_Date_Calendar_SelectionChanged1(object sender, EventArgs e)
        {
            string End_Date = DateTime.Parse(End_Date_Calendar.SelectedDate.ToString()).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            txt_End_Date.Text = End_Date;
            if (txt_End_Date.Text != "")
            {
                End_Date_Div.Visible = false;
                ImageButton3.Visible = false;
            }
        }


        protected void BindData(string sortExpression = null)
        {
            //try
            //{
                using (MySqlCommand cmd = new MySqlCommand("M_OwnerShip", _sqlCon))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        M_OwnerSip_GV.DataSource = dt;
                        M_OwnerSip_GV.DataBind();
                    }
                }
            //}
            //catch
            //{
            //    Response.Write(
            //        @"<script language='javascript'>alert('OOPS!!! The Building List Cannt Display')</script>");
            //}
        }

        protected void M_OwnerSip_GV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton Delete = (e.Row.FindControl("Delete") as LinkButton);
                Utilities.Roles.Delete_permission(_sqlCon, Session["Role"].ToString(), "properties", Delete);
            }
            


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    decimal value;
                    if (decimal.TryParse(e.Row.Cells[10].Text.Trim(), out value))
                    {
                        e.Row.Cells[10].Text = Math.Round(value, 2).ToString();
                    }
                }
            }


            if (e.Row.RowType == DataControlRowType.DataRow && M_OwnerSip_GV.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddl_Bank_Name = (DropDownList)e.Row.FindControl("bank_DropDownList");
                string Bank_Name_query = "SELECT * FROM bank";
                using (MySqlDataAdapter sda = new MySqlDataAdapter(Bank_Name_query, _sqlCon))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        ddl_Bank_Name.DataSource = dt;
                        ddl_Bank_Name.DataTextField = "Bank_Arabic_Name";
                        ddl_Bank_Name.DataValueField = "Bank_Id";
                        ddl_Bank_Name.DataBind();
                        string selected_Cheque_Type = DataBinder.Eval(e.Row.DataItem, "Bank_Id").ToString();
                        ddl_Bank_Name.Items.FindByValue(selected_Cheque_Type).Selected = true;
                    }
                }
            }


            if (e.Row.RowType == DataControlRowType.DataRow && M_OwnerSip_GV.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddl_OwnerShip = (DropDownList)e.Row.FindControl("OwnerShip_DropDownList");
                string OwnerShip_Name_query = "SELECT * FROM owner_ship";
                using (MySqlDataAdapter sda = new MySqlDataAdapter(OwnerShip_Name_query, _sqlCon))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        ddl_OwnerShip.DataSource = dt;
                        ddl_OwnerShip.DataTextField = "Owner_Ship_AR_Name";
                        ddl_OwnerShip.DataValueField = "Owner_Ship_Id";
                        ddl_OwnerShip.DataBind();
                        string selected_Cheque_Type = DataBinder.Eval(e.Row.DataItem, "Ownership_Id").ToString();
                        ddl_OwnerShip.Items.FindByValue(selected_Cheque_Type).Selected = true;
                    }
                }
            }


            if (e.Row.RowType == DataControlRowType.DataRow && M_OwnerSip_GV.EditIndex == e.Row.RowIndex)
            {
                DropDownList PaymenType_DropDownList = (DropDownList)e.Row.FindControl("PaymenType_DropDownList");

                string selected_PaymenType = DataBinder.Eval(e.Row.DataItem, "Paymen_Type").ToString();
                if(selected_PaymenType == "شهري")
                {
                    PaymenType_DropDownList.SelectedValue = "1";
                }
                else
                {
                    PaymenType_DropDownList.SelectedValue = "2";
                }
            }


        }

        protected void M_OwnerSip_GV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            M_OwnerSip_GV.EditIndex = e.NewEditIndex; this.BindData();
        }
        protected void M_OwnerSip_GV_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            M_OwnerSip_GV.EditIndex = -1; this.BindData();
        }

        protected void M_OwnerSip_GV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string lbl_Mortgaged_Wonership_Id = (M_OwnerSip_GV.Rows[e.RowIndex].FindControl("lbl_Mortgaged_Wonership_Id") as Label).Text;
            _sqlCon.Open();
            MySqlCommand cmd = new MySqlCommand("delete from mortgaged_wonership where Mortgaged_Wonership_Id =@Mortgaged_Wonership_Id", _sqlCon);
            cmd.Parameters.AddWithValue("Mortgaged_Wonership_Id", lbl_Mortgaged_Wonership_Id);
            cmd.ExecuteNonQuery();
            _sqlCon.Close();
            BindData();
        }


        protected void Delete(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            _sqlCon.Open();
            string quary1 = "DELETE FROM mortgaged_wonership WHERE Mortgaged_Wonership_Id=@ID ";
            MySqlCommand MYSqlCmd = new MySqlCommand(quary1, _sqlCon);
            MYSqlCmd.Parameters.AddWithValue("@ID", id);
            MYSqlCmd.ExecuteNonQuery();
            _sqlCon.Close();
            Response.Redirect(Request.RawUrl);
        }
        protected void M_OwnerSip_GV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string lbl_Mortgaged_Wonership_Id = (M_OwnerSip_GV.Rows[e.RowIndex].FindControl("lbl_Mortgaged_Wonership_Id") as Label).Text;


            string bank_DropDownList = (M_OwnerSip_GV.Rows[e.RowIndex].FindControl("bank_DropDownList") as DropDownList).SelectedItem.Value;

            string PaymenType_DropDownList = (M_OwnerSip_GV.Rows[e.RowIndex].FindControl("PaymenType_DropDownList") as DropDownList).SelectedItem.Text;

            string OwnerShip_DropDownList = (M_OwnerSip_GV.Rows[e.RowIndex].FindControl("OwnerShip_DropDownList") as DropDownList).SelectedItem.Value;
            string txt_Mortgage_Value = (M_OwnerSip_GV.Rows[e.RowIndex].FindControl("txt_Mortgage_Value") as TextBox).Text;
            string txt_Installment_Value = (M_OwnerSip_GV.Rows[e.RowIndex].FindControl("txt_Installment_Value") as TextBox).Text;


            System.Web.UI.WebControls.Calendar Start_Date_Calendar = new System.Web.UI.WebControls.Calendar();
            Start_Date_Calendar = (System.Web.UI.WebControls.Calendar)M_OwnerSip_GV.Rows[e.RowIndex].FindControl("Start_Date_Calendar");
            string Start_calendar = Start_Date_Calendar.SelectedDate.ToString("yyyy-MM-dd");
            string lbl_StartDate = (M_OwnerSip_GV.Rows[e.RowIndex].FindControl("lbl_Start_Date") as Label).Text;



            System.Web.UI.WebControls.Calendar End_Date_Calendar = new System.Web.UI.WebControls.Calendar();
            End_Date_Calendar = (System.Web.UI.WebControls.Calendar)M_OwnerSip_GV.Rows[e.RowIndex].FindControl("End_Date_Calendar");
            string End_calendar = End_Date_Calendar.SelectedDate.ToString("yyyy-MM-dd");
            string lbl_EndDate = (M_OwnerSip_GV.Rows[e.RowIndex].FindControl("lbl_End_Date") as Label).Text;



            string query = "UPDATE mortgaged_wonership SET" +
                           " Ownership_Id = @Ownership_Id ," +
                           " Bank_Id = @Bank_Id ," +
                           " Mortgage_Value = @Mortgage_Value ," +
                           " Installment_Value = @Installment_Value ," +
                           " Start_Date = @Start_Date , " +
                           " End_Date = @End_Date , " +
                           " Paymen_Type = @Paymen_Type  " +
                           "WHERE Mortgaged_Wonership_Id = @Mortgaged_Wonership_Id";
            using (MySqlCommand cmd = new MySqlCommand(query, _sqlCon))
            {
                cmd.Parameters.AddWithValue("@Mortgaged_Wonership_Id", lbl_Mortgaged_Wonership_Id);

                cmd.Parameters.AddWithValue("@Ownership_Id", OwnerShip_DropDownList);
                cmd.Parameters.AddWithValue("@Bank_Id", bank_DropDownList);
                cmd.Parameters.AddWithValue("@Mortgage_Value", txt_Mortgage_Value);
                cmd.Parameters.AddWithValue("@Installment_Value", txt_Installment_Value);
                cmd.Parameters.AddWithValue("@Paymen_Type", PaymenType_DropDownList);


                if (Start_calendar != "0001-01-01")
                {
                    cmd.Parameters.AddWithValue("@Start_Date", Start_calendar);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Start_Date", lbl_StartDate);
                }


                if (End_calendar != "0001-01-01")
                {
                    cmd.Parameters.AddWithValue("@End_Date", End_calendar);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@End_Date", lbl_EndDate);
                }






                _sqlCon.Open();
                cmd.ExecuteNonQuery();
                _sqlCon.Close();
                //Response.Redirect(Request.RawUrl);
                M_OwnerSip_GV.EditIndex = -1; this.BindData();
            }
        }

       
    }
}