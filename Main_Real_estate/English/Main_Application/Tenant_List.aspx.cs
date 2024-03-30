using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Tenant_List : System.Web.UI.Page
    {
        private int _size = 0;
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Add_permission(_sqlCon, Session["Role"].ToString(), "Customer_Affairs", Add);
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!IsPostBack)
            {
                Tenant_List_BindData();
            }
        }

        protected void Tenant_List_BindData()
        {
            string tenantListQuery = "SELECT T.* , " +
                "(select Sum(Weight)  FROM  tenant_evaluation where Tenant_Id =  T.Tenants_ID )Points , " +
                "(SELECT IF(Points !=0, Points, 0))R_Points , " +
                "(SELECT IF((100 - R_Points) !=0, (100 - R_Points), 0)) Persenteg " +
                " FROM  tenants T";





            MySqlCommand tenantListCmd = new MySqlCommand(tenantListQuery, _sqlCon);
            MySqlDataAdapter tenantListDt = new MySqlDataAdapter(tenantListCmd);
            tenantListCmd.Connection = _sqlCon;
            _sqlCon.Open();
            tenantListDt.SelectCommand = tenantListCmd;
            DataTable tenantListDataTable = new DataTable();
            tenantListDt.Fill(tenantListDataTable);
            tenant_List.DataSource = tenantListDataTable;
            tenant_List.DataBind();
            _sqlCon.Close();
        }
       

        protected void Details_Tenant(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Tenant_Datials.aspx?Id=" + id);
        }

        protected void Tenant_Type_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Tenant_Type_DropDownList.SelectedValue == "1")
            {
                Tenant_List_BindData();
            }
            else if (Tenant_Type_DropDownList.SelectedValue == "2")
            {




                string tenantListQuery = "SELECT T.* , " +
                "(select Sum(Weight)  FROM  tenant_evaluation where Tenant_Id =  T.Tenants_ID )Points , " +
                "(SELECT IF(Points !=0, Points, 0))R_Points , " +
                "(SELECT IF((100 - R_Points) !=0, (100 - R_Points), 0)) Persenteg " +
                " FROM  tenants T where tenant_type_Tenant_Type_Id = 2";





                MySqlCommand tenantListCmd = new MySqlCommand(tenantListQuery, _sqlCon);
                MySqlDataAdapter tenantListDt = new MySqlDataAdapter(tenantListCmd);
                tenantListCmd.Connection = _sqlCon;
                _sqlCon.Open();
                tenantListDt.SelectCommand = tenantListCmd;
                DataTable tenantListDataTable = new DataTable();
                tenantListDt.Fill(tenantListDataTable);
                tenant_List.DataSource = tenantListDataTable;
                tenant_List.DataBind();
                _sqlCon.Close();
            }
            else
            {
                string tenantListQuery = "SELECT T.* , " +
                "(select Sum(Weight)  FROM  tenant_evaluation where Tenant_Id =  T.Tenants_ID )Points , " +
                "(SELECT IF(Points !=0, Points, 0))R_Points , " +
                "(SELECT IF((100 - R_Points) !=0, (100 - R_Points), 0)) Persenteg " +
                " FROM  tenants T where tenant_type_Tenant_Type_Id = 1";
                MySqlCommand tenantListCmd = new MySqlCommand(tenantListQuery, _sqlCon);
                MySqlDataAdapter tenantListDt = new MySqlDataAdapter(tenantListCmd);
                tenantListCmd.Connection = _sqlCon;
                _sqlCon.Open();
                tenantListDt.SelectCommand = tenantListCmd;
                DataTable tenantListDataTable = new DataTable();
                tenantListDt.Fill(tenantListDataTable);
                tenant_List.DataSource = tenantListDataTable;
                tenant_List.DataBind();
                _sqlCon.Close();
            }



                
        }

        protected void tenant_List_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                RepeaterItem item = e.Item;
                Label lbl_Persenteg = (item.FindControl("lbl_Persenteg") as Label);

                double Dbl_lbl_Persenteg = Convert.ToDouble(lbl_Persenteg.Text);


                if (Dbl_lbl_Persenteg >= 80 && Dbl_lbl_Persenteg<=100)
                {
                    lbl_Persenteg.Text = "A";
                }
                else if (Dbl_lbl_Persenteg >= 60 && Dbl_lbl_Persenteg <= 79)
                {
                    lbl_Persenteg.Text = "B";
                }
                else if (Dbl_lbl_Persenteg >= 40 && Dbl_lbl_Persenteg <= 59)
                {
                    lbl_Persenteg.Text = "C";
                }
                else if (Dbl_lbl_Persenteg >= 20 && Dbl_lbl_Persenteg <= 39)
                {
                    lbl_Persenteg.Text = "D";
                }
                else
                {
                    lbl_Persenteg.Text = "E";
                }
            }
        }
    }
}