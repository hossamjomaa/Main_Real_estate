using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Main_Real_estate.English.Master_Panal;

namespace Main_Real_estate.English.Main_Application
{
    public partial class OwnerShip_DTL : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "properties", 0, "R");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            Statment();
            Building_List_BindData();
            _sqlCon.Open();
            string ownershipId = Request.QueryString["Id"];
            using (MySqlCommand ownershipDetailsCmd = new MySqlCommand("Ownership_Details", _sqlCon))
            {
                ownershipDetailsCmd.CommandType = CommandType.StoredProcedure;
                ownershipDetailsCmd.Parameters.AddWithValue("@Id", ownershipId);
                using (MySqlDataAdapter ownershipDetailsSda = new MySqlDataAdapter(ownershipDetailsCmd))
                {
                    DataTable ownershipDetailsDt = new DataTable();
                    ownershipDetailsSda.Fill(ownershipDetailsDt);
                    lbl_Details_ownership_Name.Text = "تفاصيل الملكية : " + ownershipDetailsDt.Rows[0]["Owner_Ship_AR_Name"].ToString();
                    lbl_Dtl_Parcel_Area.Text = ownershipDetailsDt.Rows[0]["Parcel_Area"].ToString();
                    lbl_Dtl_Bond_No.Text = ownershipDetailsDt.Rows[0]["Bond_NO"].ToString();
                    lbl_Dtl_Street_NO.Text = ownershipDetailsDt.Rows[0]["Street_NO"].ToString();
                    lbl_Dtl_Street_Name.Text = ownershipDetailsDt.Rows[0]["Street_Name"].ToString();
                    lbl_Dtl_Land_Value.Text = ownershipDetailsDt.Rows[0]["Land_Value"].ToString();
                    lbl_Dtl_PIN.Text = ownershipDetailsDt.Rows[0]["PIN_Number"].ToString();
                    lbl_Dtl_Code.Text = ownershipDetailsDt.Rows[0]["owner_ship_Code"].ToString();
                    lbl_Dtl_Zone_Name.Text = ownershipDetailsDt.Rows[0]["zone_arabic_name"].ToString();

                    Link_Ownership_Certificate_Pdf.HRef = ownershipDetailsDt.Rows[0]["owner_ship_Certificate_Image_Path"].ToString();
                    Link_Ownership_Certificate_Pdf.Target = "_blank";

                    Link_Property_Scheme.HRef = ownershipDetailsDt.Rows[0]["Property_Scheme_Image_Path"].ToString();
                    Link_Property_Scheme.Target = "_blank";

                    Link_Stetmant.HRef = ownershipDetailsDt.Rows[0]["Statment_Id"].ToString();
                    Link_Stetmant.Target = "_blank";

                    if (ownershipDetailsDt.Rows[0]["owner_ship_Certificate_Image_Path"].ToString() == "No File")
                    {
                        Link_Ownership_Certificate_Pdf.Visible = false;
                    }

                    if (ownershipDetailsDt.Rows[0]["Property_Scheme_Image_Path"].ToString() == "No File")
                    {
                        Link_Property_Scheme.Visible = false;
                    }

                    if (ownershipDetailsDt.Rows[0]["Statment_Id"].ToString() == "")
                    {
                        Link_Stetmant.Visible = false;
                        lbl_No_Statment.Text = "لم يتم إرفاق أي إفادات";
                    }
                }
            }
        }

        protected void Statment()
        {
            string getStatmentQuari = "SELECT * FROM ownership_statment where Ownership_Id = '" + Request.QueryString["ID"] + "'";
            MySqlCommand getStatmentCmd = new MySqlCommand(getStatmentQuari, _sqlCon);
            MySqlDataAdapter getStatmentDt = new MySqlDataAdapter(getStatmentCmd);
            getStatmentCmd.Connection = _sqlCon;
            _sqlCon.Open();
            getStatmentDt.SelectCommand = getStatmentCmd;
            DataTable getStatmentDataTable = new DataTable();
            getStatmentDt.Fill(getStatmentDataTable);
            Statment_List.DataSource = getStatmentDataTable;
            Statment_List.DataBind();
            _sqlCon.Close();
        }

        protected void Building_List_BindData(string sortExpression = null)
        {
            try
            {
                _sqlCon.Open();
                string ownershipId = Request.QueryString["Id"];
                using (MySqlCommand bulidingDetailsCmd = new MySqlCommand("Building_List_In_Ownership_Details", _sqlCon))
                {
                    bulidingDetailsCmd.CommandType = CommandType.StoredProcedure;
                    bulidingDetailsCmd.Parameters.AddWithValue("@Id", ownershipId);
                    MySqlDataAdapter bulidingDetailsSda = new MySqlDataAdapter(bulidingDetailsCmd);

                    DataTable bulidingDetailsDt = new DataTable();
                    bulidingDetailsSda.Fill(bulidingDetailsDt);
                    bulidingDetailsCmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    bulidingDetailsSda.Fill(dt);
                    building_List.DataSource = dt;
                    building_List.DataBind();
                    _sqlCon.Close();
                }
            }
            catch { Response.Write(@"<script language='javascript'>alert('لا يمكن عرض هذه الصفحة')</script>"); }
        }
        protected void Building_Details(object sender, EventArgs e)
        {
            T_B_D.Text = "تفاصيل البناء";
            btn_Close.Visible = true;
            string buildingId = (sender as LinkButton).CommandArgument;
            using (MySqlCommand bulidingDetailsCmd = new MySqlCommand("Building_Details", _sqlCon))
            {
                bulidingDetailsCmd.CommandType = CommandType.StoredProcedure;
                bulidingDetailsCmd.Parameters.AddWithValue("@Id", buildingId);
                MySqlDataAdapter bulidingDetailsSda = new MySqlDataAdapter(bulidingDetailsCmd);

                DataTable bulidingDetailsDt = new DataTable();
                bulidingDetailsSda.Fill(bulidingDetailsDt);
                bulidingDetailsCmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                bulidingDetailsSda.Fill(dt);
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                _sqlCon.Close();
            }
            //***************************************************************************
            _sqlCon.Open();
            using (MySqlCommand unitDetailsCmd = new MySqlCommand("Unit_List_In_Building_Details", _sqlCon))
            {
                unitDetailsCmd.CommandType = CommandType.StoredProcedure;
                unitDetailsCmd.Parameters.AddWithValue("@Id", buildingId);
                MySqlDataAdapter unitDetailsSda = new MySqlDataAdapter(unitDetailsCmd);

                DataTable unitDetailsDt = new DataTable();
                unitDetailsSda.Fill(unitDetailsDt);
                unitDetailsCmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                unitDetailsSda.Fill(dt);
                eeeee.DataSource = dt;
                eeeee.DataBind();
            }
            _sqlCon.Close();

        }

        protected void btn_Close_Click(object sender, EventArgs e)
        {

            T_B_D.Text = string.Empty;

            eeeee.DataSource = null;
            eeeee.DataSourceID = null;
            eeeee.DataBind();

            Repeater1.DataSource = null;
            Repeater1.DataSourceID = null;
            Repeater1.DataBind();


            btn_Close.Visible = false;
        }
    }
}