using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Expenses : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Financial_Statements", 0, "R");
                Utilities.Roles.Add_permission(_sqlCon, Session["Role"].ToString(), "Financial_Statements", Add);
            }
            catch { Response.Redirect("Log_In.aspx"); }

            if (!this.IsPostBack)
            {
                //*************************************************************************
                // Fill OWnersip DropDownList
                Helper.LoadDropDownList("SELECT * FROM owner_ship", _sqlCon, Ownership_Name_DropDownList, "Owner_Ship_AR_Name", "Owner_Ship_Id");
                Ownership_Name_DropDownList.Items.Insert(0, "إختر اسم الملكية ....");

                Building_Name_DropDownList.Items.Insert(0, "إختر اسم البناء ....");

                Unit_Name_DropDownList.Items.Insert(0, "إختر رقم الوحدة ....");
                //*************************************************************************
                // Fill Year & Mounth  DropDownList
                int year = DateTime.Now.Year; int Mounth = DateTime.Now.Month;
                for (int i = year - 5; i <= year + 10; i++)
                {
                    ListItem li = new ListItem(i.ToString());
                    Year_DropDownList.Items.Add(li);
                }
                Year_DropDownList.Items.FindByText(year.ToString()).Selected = true;
                Mounth_DropDownList.SelectedValue = Mounth.ToString();
                //*************************************************************************
                // Management_Expenses
                Management_Expenses();
                Expensess_LIst();

            }
        }
        protected void O_B_U_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (O_B_U_DropDownList.SelectedValue == "1")
            {
                Ownership_Div.Visible = true; Building_Div.Visible = false; Unit_Div.Visible = false;

                Management_Expenses_Div.Visible = false;
                RealEstate_Expense_Div.Visible = true;
                Maintenance_Expenses_Div.Visible = true;
            }
            else if (O_B_U_DropDownList.SelectedValue == "2")
            {
                Ownership_Div.Visible = true; Building_Div.Visible = true; Unit_Div.Visible = false;

                Management_Expenses_Div.Visible = false;
                RealEstate_Expense_Div.Visible = true;
                Maintenance_Expenses_Div.Visible = true;
            }
            else if (O_B_U_DropDownList.SelectedValue == "3")
            {
                Ownership_Div.Visible = true; Building_Div.Visible = true; Unit_Div.Visible = true;

                Management_Expenses_Div.Visible = false;
                RealEstate_Expense_Div.Visible = true;
                Maintenance_Expenses_Div.Visible = true;
            }
            else
            {
                Ownership_Div.Visible = false; Building_Div.Visible = false; Unit_Div.Visible = false;

                Management_Expenses_Div.Visible = true;
                RealEstate_Expense_Div.Visible = false;
                Maintenance_Expenses_Div.Visible = false;
            }
        }
        protected void Ownership_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Building_Name_DropDownList.Enabled = true;
            // Fill Building DropDownList
            Helper.LoadDropDownList("SELECT * FROM building where Active ='1' and owner_ship_Owner_Ship_Id='" + Ownership_Name_DropDownList.SelectedValue + "'", _sqlCon, Building_Name_DropDownList, "Building_Arabic_Name", "Building_Id");
            Building_Name_DropDownList.Items.Insert(0, "إختر اسم البناء ....");




            Expensess_LIst();
            OwnerShip_Expenss();
        }


        protected void Building_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Fill OWnersip DropDownList
            Helper.LoadDropDownList("SELECT * FROM units where Half ='0' and building_Building_Id ='" + Building_Name_DropDownList.SelectedValue + "' ", _sqlCon, Unit_Name_DropDownList, "Unit_Number", "Unit_ID");
            Unit_Name_DropDownList.Items.Insert(0, "إختر رقم الوحدة ....");


            // Get The Cheque_Expenses , transfer_Expenses , Cash_Expenses for Chossen Building
            Building_Expenss();
            Expensess_LIst();


        }

        protected void Unit_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Uint_Expenss();
            Expensess_LIst();
        }

        protected void btn_Add_Expenses_Click(object sender, EventArgs e)
        {

            //string Qary_ID = "";    string Building_Unit_Id = "";
            string Ownersip_Id = Ownership_Name_DropDownList.SelectedValue; string Building_Id = Building_Name_DropDownList.SelectedValue; string Unit_Id = Unit_Name_DropDownList.SelectedValue;
            string Mounth = Mounth_DropDownList.SelectedValue; string Year = Year_DropDownList.SelectedValue; string Quary = "";

            if (O_B_U_DropDownList.SelectedValue == "1")
            {
                Quary = "Select Id , Type , Ownersip_Id , Mounth , Year , RealEstate_Expenses , Maintenance_Expenses  " +
                "from  collection_table  where Type = 1 and Ownersip_Id = '" + Ownersip_Id + "'  and Mounth='" + Mounth + "'and Year='" + Year + "' ";
                MySqlDataAdapter ExpensesSda = new MySqlDataAdapter(Quary, _sqlCon);
                DataTable getExpensesDt = new DataTable();
                ExpensesSda.Fill(getExpensesDt);
                if (getExpensesDt.Rows.Count > 0)
                {
                    string updateExpensesQuary = "UPDATE collection_table SET " +
                                                 "RealEstate_Expenses=@RealEstate_Expenses ," +
                                                 "Maintenance_Expenses=@Maintenance_Expenses " +
                                                 "WHERE Type = 1 and  Ownersip_Id ='" + Ownersip_Id + "' And Mounth = '" + Mounth + "' And Year = '" + Year + "' ";
                    _sqlCon.Open();
                    MySqlCommand updateExpensesCmd = new MySqlCommand(updateExpensesQuary, _sqlCon);
                    updateExpensesCmd.Parameters.AddWithValue("@RealEstate_Expenses", txt_RealEstate_Expenses.Text);
                    updateExpensesCmd.Parameters.AddWithValue("@Maintenance_Expenses", txt_Maintenance_Expenses.Text);
                    updateExpensesCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                else
                {
                    string addExpensesQuary = "Insert Into collection_table" +
                                              "(Type , Ownersip_Id , Mounth , Year , RealEstate_Expenses , Maintenance_Expenses) " +
                                              "VALUES" +
                                              "(@Type , @Ownersip_Id , @Mounth , @Year  , @RealEstate_Expenses , @Maintenance_Expenses)";
                    _sqlCon.Open();
                    MySqlCommand addExpensesCmd = new MySqlCommand(addExpensesQuary, _sqlCon);
                    addExpensesCmd.Parameters.AddWithValue("@Type", "1");
                    addExpensesCmd.Parameters.AddWithValue("@Ownersip_Id", Ownership_Name_DropDownList.SelectedValue);
                    addExpensesCmd.Parameters.AddWithValue("@Mounth", Mounth_DropDownList.SelectedValue);
                    addExpensesCmd.Parameters.AddWithValue("@Year", Year_DropDownList.SelectedValue);
                    addExpensesCmd.Parameters.AddWithValue("@RealEstate_Expenses", txt_RealEstate_Expenses.Text);
                    addExpensesCmd.Parameters.AddWithValue("@Maintenance_Expenses", txt_Maintenance_Expenses.Text);
                    addExpensesCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
            }
            else if (O_B_U_DropDownList.SelectedValue == "2")
            {
                Quary = "Select Id , Type , Ownersip_Id , Building_Id , Mounth , Year , RealEstate_Expenses , Maintenance_Expenses" +
                "  from collection_table where Type = 2 and Ownersip_Id = '" + Ownersip_Id + "'  And Building_Id = '" + Building_Id + "' and Mounth='" + Mounth + "'and Year='" + Year + "' ";
                MySqlDataAdapter ExpensesSda = new MySqlDataAdapter(Quary, _sqlCon);
                DataTable getExpensesDt = new DataTable();
                ExpensesSda.Fill(getExpensesDt);
                if (getExpensesDt.Rows.Count > 0)
                {
                    string updateExpensesQuary = "UPDATE collection_table SET " +
                                                 "RealEstate_Expenses=@RealEstate_Expenses ," +
                                                 "Maintenance_Expenses=@Maintenance_Expenses " +
                                                 "WHERE Type = 2 and Ownersip_Id ='" + Ownersip_Id + "' And Building_Id ='" + Building_Id + "'" +
                                                 " And Mounth = '" + Mounth + "' And Year = '" + Year + "' ";
                    _sqlCon.Open();
                    MySqlCommand updateExpensesCmd = new MySqlCommand(updateExpensesQuary, _sqlCon);
                    updateExpensesCmd.Parameters.AddWithValue("@RealEstate_Expenses", txt_RealEstate_Expenses.Text);
                    updateExpensesCmd.Parameters.AddWithValue("@Maintenance_Expenses", txt_Maintenance_Expenses.Text);
                    updateExpensesCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                else
                {
                    string addExpensesQuary = "Insert Into collection_table" +
                                              "(Type , Ownersip_Id ,Building_Id, Mounth ,Year ,  RealEstate_Expenses , Maintenance_Expenses) " +
                                              "VALUES" +
                                              "(@Type , @Ownersip_Id, @Building_Id , @Mounth , @Year  , @RealEstate_Expenses , @Maintenance_Expenses)";
                    _sqlCon.Open();
                    MySqlCommand addExpensesCmd = new MySqlCommand(addExpensesQuary, _sqlCon);
                    addExpensesCmd.Parameters.AddWithValue("@Type", "2");
                    addExpensesCmd.Parameters.AddWithValue("@Ownersip_Id", Ownership_Name_DropDownList.SelectedValue);
                    addExpensesCmd.Parameters.AddWithValue("@Building_Id", Building_Name_DropDownList.SelectedValue);
                    addExpensesCmd.Parameters.AddWithValue("@Mounth", Mounth_DropDownList.SelectedValue);
                    addExpensesCmd.Parameters.AddWithValue("@Year", Year_DropDownList.SelectedValue);
                    addExpensesCmd.Parameters.AddWithValue("@RealEstate_Expenses", txt_RealEstate_Expenses.Text);
                    addExpensesCmd.Parameters.AddWithValue("@Maintenance_Expenses", txt_Maintenance_Expenses.Text);
                    addExpensesCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
            }
            else if (O_B_U_DropDownList.SelectedValue == "3")
            {
                Quary = "Select Id , Type , Ownersip_Id , Building_Id , Unit_Id , Mounth , Year , RealEstate_Expenses , Maintenance_Expenses  from collection_table " +
                "where Type = 3 and Ownersip_Id = '" + Ownersip_Id + "'  And Building_Id = '" + Building_Id + "' And Unit_Id ='" + Unit_Id + "'  and Mounth='" + Mounth + "' and Year='" + Year + "' ";

                MySqlDataAdapter ExpensesSda = new MySqlDataAdapter(Quary, _sqlCon);
                DataTable getExpensesDt = new DataTable();
                ExpensesSda.Fill(getExpensesDt);
                if (getExpensesDt.Rows.Count > 0)
                {
                    string updateExpensesQuary = "UPDATE collection_table SET " +
                                                 "RealEstate_Expenses=@RealEstate_Expenses ," +
                                                 "Maintenance_Expenses=@Maintenance_Expenses " +
                                                 "WHERE Type = 3 and Ownersip_Id ='" + Ownersip_Id + "' And Building_Id ='" + Building_Id + "' And Unit_Id ='" + Unit_Id + "' " +
                                                 " And Mounth = '" + Mounth + "' And Year = '" + Year + "' ";
                    _sqlCon.Open();
                    MySqlCommand updateExpensesCmd = new MySqlCommand(updateExpensesQuary, _sqlCon);
                    updateExpensesCmd.Parameters.AddWithValue("@RealEstate_Expenses", txt_RealEstate_Expenses.Text);
                    updateExpensesCmd.Parameters.AddWithValue("@Maintenance_Expenses", txt_Maintenance_Expenses.Text);
                    updateExpensesCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                else
                {
                    string addExpensesQuary = "Insert Into collection_table" +
                                              "(Type , Ownersip_Id ,Building_Id , Unit_Id , Mounth  ,Year  , RealEstate_Expenses , Maintenance_Expenses) " +
                                              "VALUES" +
                                              "(@Type , @Ownersip_Id, @Building_Id,@Unit_Id  , @Mounth , @Year , @RealEstate_Expenses , @Maintenance_Expenses)";
                    _sqlCon.Open();
                    MySqlCommand addExpensesCmd = new MySqlCommand(addExpensesQuary, _sqlCon);
                    addExpensesCmd.Parameters.AddWithValue("@Type", "3");
                    addExpensesCmd.Parameters.AddWithValue("@Ownersip_Id", Ownership_Name_DropDownList.SelectedValue);
                    addExpensesCmd.Parameters.AddWithValue("@Building_Id", Building_Name_DropDownList.SelectedValue);
                    addExpensesCmd.Parameters.AddWithValue("@Unit_Id", Unit_Name_DropDownList.SelectedValue);
                    addExpensesCmd.Parameters.AddWithValue("@Mounth", Mounth_DropDownList.SelectedValue);
                    addExpensesCmd.Parameters.AddWithValue("@Year", Year_DropDownList.SelectedValue);
                    addExpensesCmd.Parameters.AddWithValue("@RealEstate_Expenses", txt_RealEstate_Expenses.Text);
                    addExpensesCmd.Parameters.AddWithValue("@Maintenance_Expenses", txt_Maintenance_Expenses.Text);
                    addExpensesCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
            }
            else if (O_B_U_DropDownList.SelectedValue == "4")
            {
                Quary = "Select * from management_expensess where  Mounth='" + Mounth + "' and Year='" + Year + "' ";
                MySqlDataAdapter ExpensesSda = new MySqlDataAdapter(Quary, _sqlCon);
                DataTable getExpensesDt = new DataTable();
                ExpensesSda.Fill(getExpensesDt);
                if (getExpensesDt.Rows.Count > 0)
                {
                    string updateExpensesQuary = "UPDATE management_expensess SET " +
                                                 "Management_Expensess=@Management_Expensess " +
                                                 "WHERE Mounth = '" + Mounth + "' And Year = '" + Year + "'";
                    _sqlCon.Open();
                    MySqlCommand updateExpensesCmd = new MySqlCommand(updateExpensesQuary, _sqlCon);
                    updateExpensesCmd.Parameters.AddWithValue("@Management_Expensess", txt_Management_Expenses.Text);
                    updateExpensesCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
                else
                {
                    string addExpensesQuary = "Insert Into management_expensess" +
                                              "(Mounth , Year , Management_Expensess ) " +
                                              "VALUES" +
                                              "(@Mounth , @Year , @Management_Expensess)";
                    _sqlCon.Open();
                    MySqlCommand addExpensesCmd = new MySqlCommand(addExpensesQuary, _sqlCon);
                    addExpensesCmd.Parameters.AddWithValue("@Mounth", Mounth_DropDownList.SelectedValue);
                    addExpensesCmd.Parameters.AddWithValue("@Year", Year_DropDownList.SelectedValue);
                    addExpensesCmd.Parameters.AddWithValue("@Management_Expensess", txt_Management_Expenses.Text);
                    addExpensesCmd.ExecuteNonQuery();
                    _sqlCon.Close();
                }
            }
        }

        protected void Mounth_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Management_Expenses();
            OwnerShip_Expenss();
            Building_Expenss();
            Uint_Expenss();
            Expensess_LIst();
        }

        protected void Year_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Management_Expenses();
            OwnerShip_Expenss();
            Building_Expenss();
            Uint_Expenss();
            Expensess_LIst();
        }


        protected void Management_Expenses()
        {
            string mounth = Mounth_DropDownList.SelectedValue; string Year = Year_DropDownList.SelectedValue;
            string Quary = "select (select sum(Management_Expensess) from management_expensess where Mounth='" + mounth + "'and Year='" + Year + "')Management_Expenses ";

            MySqlDataAdapter ExpensesSda = new MySqlDataAdapter(Quary, _sqlCon);
            DataTable getExpensesDt = new DataTable();
            ExpensesSda.Fill(getExpensesDt);
            if (getExpensesDt.Rows.Count > 0)
            {
                if (getExpensesDt.Rows[0]["Management_Expenses"].ToString() != "")
                {
                    txt_Management_Expenses.Text = getExpensesDt.Rows[0]["Management_Expenses"].ToString();
                }
                else
                {
                    txt_Management_Expenses.Text = "0";
                }
            }
            else
            {
                txt_Management_Expenses.Text = "0";
            }
            _sqlCon.Close();
        }


        protected void OwnerShip_Expenss()
        {
            if (O_B_U_DropDownList.SelectedValue == "1")
            {
                string ownership_Id = Ownership_Name_DropDownList.SelectedValue; string Mounth = Mounth_DropDownList.SelectedValue; string Year = Year_DropDownList.SelectedValue;
                string Quary = "select (select sum(RealEstate_Expenses) from collection_table where Type = 1 and Ownersip_Id='" + ownership_Id + "' and Mounth='" + Mounth + "'and Year='" + Year + "')RealEstate_Expenses, " +
                                   "(select sum(Maintenance_Expenses) from collection_table where Type = 1 and Ownersip_Id='" + ownership_Id + "' and Mounth='" + Mounth + "'and Year='" + Year + "')Maintenance_Expenses";

                MySqlDataAdapter ExpensesSda = new MySqlDataAdapter(Quary, _sqlCon);
                DataTable getExpensesDt = new DataTable();
                ExpensesSda.Fill(getExpensesDt);
                if (getExpensesDt.Rows.Count > 0)
                {
                    if (getExpensesDt.Rows[0]["RealEstate_Expenses"].ToString() != "" || getExpensesDt.Rows[0]["Maintenance_Expenses"].ToString() != "")
                    {
                        txt_RealEstate_Expenses.Text = getExpensesDt.Rows[0]["RealEstate_Expenses"].ToString();
                        txt_Maintenance_Expenses.Text = getExpensesDt.Rows[0]["Maintenance_Expenses"].ToString();
                    }
                    else
                    {
                        txt_RealEstate_Expenses.Text = "0";
                        txt_Maintenance_Expenses.Text = "0";
                    }
                }
                else
                {
                    txt_RealEstate_Expenses.Text = "0";
                    txt_Maintenance_Expenses.Text = "0";
                }
                _sqlCon.Close();
            }
        }

        protected void Building_Expenss()
        {
            if (O_B_U_DropDownList.SelectedValue == "2")
            {
                string Building_Id = Building_Name_DropDownList.SelectedValue; string Mounth = Mounth_DropDownList.SelectedValue; string Year = Year_DropDownList.SelectedValue;
                string Quary = "select (select sum(RealEstate_Expenses) from collection_table where Type = 2 and Building_Id='" + Building_Id + "' and Mounth='" + Mounth + "'and Year='" + Year + "')RealEstate_Expenses, " +
                                   "(select sum(Maintenance_Expenses) from collection_table where Type = 2 and Building_Id='" + Building_Id + "' and Mounth='" + Mounth + "'and Year='" + Year + "')Maintenance_Expenses";

                MySqlDataAdapter ExpensesSda = new MySqlDataAdapter(Quary, _sqlCon);
                DataTable getExpensesDt = new DataTable();
                ExpensesSda.Fill(getExpensesDt);
                if (getExpensesDt.Rows.Count > 0)
                {
                    if (getExpensesDt.Rows[0]["RealEstate_Expenses"].ToString() != "" || getExpensesDt.Rows[0]["Maintenance_Expenses"].ToString() != "")
                    {
                        txt_RealEstate_Expenses.Text = getExpensesDt.Rows[0]["RealEstate_Expenses"].ToString();
                        txt_Maintenance_Expenses.Text = getExpensesDt.Rows[0]["Maintenance_Expenses"].ToString();
                    }
                    else
                    {
                        txt_RealEstate_Expenses.Text = "0";
                        txt_Maintenance_Expenses.Text = "0";
                    }
                }
                else
                {
                    txt_RealEstate_Expenses.Text = "0";
                    txt_Maintenance_Expenses.Text = "0";
                }
                _sqlCon.Close();
            }
        }

        protected void Uint_Expenss()
        {
            if (O_B_U_DropDownList.SelectedValue == "3")
            {
                // Get The Cheque_Collection , transfer_Collection , Cash_Collection for Chossen Building
                string Unit_Id = Unit_Name_DropDownList.SelectedValue; string Mounth = Mounth_DropDownList.SelectedValue; string Year = Year_DropDownList.SelectedValue;
                string Quary = "select  RealEstate_Expenses , Maintenance_Expenses from collection_table  where Type = 3 and Unit_Id='" + Unit_Id + "' and Mounth='" + Mounth + "'and Year='" + Year + "'";
                MySqlDataAdapter ExpensesSda = new MySqlDataAdapter(Quary, _sqlCon);
                DataTable getExpensesDt = new DataTable();
                ExpensesSda.Fill(getExpensesDt);
                if (getExpensesDt.Rows.Count > 0)
                {
                    if (getExpensesDt.Rows[0]["RealEstate_Expenses"].ToString() != "" || getExpensesDt.Rows[0]["Maintenance_Expenses"].ToString() != "")
                    {
                        txt_RealEstate_Expenses.Text = getExpensesDt.Rows[0]["RealEstate_Expenses"].ToString();
                        txt_Maintenance_Expenses.Text = getExpensesDt.Rows[0]["Maintenance_Expenses"].ToString();
                    }
                    else
                    {
                        txt_RealEstate_Expenses.Text = "0";
                        txt_Maintenance_Expenses.Text = "0";
                    }
                }
                else
                {
                    txt_RealEstate_Expenses.Text = "0";
                    txt_Maintenance_Expenses.Text = "0";
                }
                _sqlCon.Close();
            }
        }




        protected void Expensess_LIst()
        {
            string O_Where = ""; string B_Where = ""; string U_Where = ""; string Mounth = "";
            if (O_B_U_DropDownList.SelectedValue == "1")
            {
                if (Ownership_Name_DropDownList.SelectedItem.Text == "إختر اسم الملكية ....") { O_Where = ""; }
                else { O_Where = "and CT.Ownersip_Id = " + Ownership_Name_DropDownList.SelectedValue + ""; }
            }
            else if (O_B_U_DropDownList.SelectedValue == "2")
            {
                if (Building_Name_DropDownList.SelectedItem.Text == "إختر اسم البناء ....") { B_Where = ""; }
                else { B_Where = "and CT.Building_Id = " + Building_Name_DropDownList.SelectedValue + " "; }
            }
            else if (O_B_U_DropDownList.SelectedValue == "3")
            {
                if (Unit_Name_DropDownList.SelectedItem.Text == "إختر رقم الوحدة ....") { U_Where = ""; }
                else { U_Where = "and CT.Unit_Id = " + Unit_Name_DropDownList.SelectedValue + ""; }
            }



            if (Mounth_DropDownList.SelectedValue == "13") { Mounth = ""; } else { Mounth = "CT.Mounth = '" + Mounth_DropDownList.SelectedValue + "' and"; }





            string Query = "select CT.Ownersip_Id , CT.Building_Id , CT.Unit_Id , CT.Mounth , CT.Year , CT.RealEstate_Expenses , CT.Maintenance_Expenses ,  " +
            "O.Owner_Ship_AR_Name , B.Building_Arabic_Name , U.Unit_Number " +
            "from collection_table CT " +
            "left join owner_ship O on (CT.Ownersip_Id = O.Owner_Ship_Id) " +
            "left join building B on (CT.Building_Id = B.Building_Id) " +
            "left join units U on (CT.Unit_Id = U.Unit_ID) " +
            "where "+ Mounth + " CT.Year = '" + Year_DropDownList.SelectedItem.Text + "' " + O_Where + " " + B_Where + " " + U_Where + " ";
            Helper.GetDataReader(Query, _sqlCon, The_Table);
        }

        protected void The_Table_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HtmlTableRow tr = e.Item.FindControl("row") as HtmlTableRow;
            Label lbl_RealEstate_Expenses = (e.Item.FindControl("lbl_RealEstate_Expenses") as Label);
            Label lbl_Maintenance_Expenses = (e.Item.FindControl("lbl_Maintenance_Expenses") as Label);

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if((lbl_RealEstate_Expenses.Text=="" && lbl_Maintenance_Expenses.Text == "") || (lbl_RealEstate_Expenses.Text == "0" && lbl_Maintenance_Expenses.Text == "0")||
                (lbl_RealEstate_Expenses.Text == "0" && lbl_Maintenance_Expenses.Text == "") || (lbl_RealEstate_Expenses.Text == ""  && lbl_Maintenance_Expenses.Text == "0"))
                { tr.Visible = false; }
                else { tr.Visible = true; }
            }
        }
    }
}