using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Ownership_Details_Tabel : System.Web.UI.Page
    {
        private int _size = 0;
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {

            Statment();
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
                    // lbl_Dtl_Name_En.Text = Ownership_Details_dt.Rows[0]["Owner_Ship_EN_Name"].ToString();
                    lbl_Details_ownership_Name.Text = ownershipDetailsDt.Rows[0]["Owner_Ship_AR_Name"].ToString();
                    lbl_Dtl_Name_En.Text = ownershipDetailsDt.Rows[0]["Owner_Ship_En_Name"].ToString();
                    lbl_Dtl_Name_Ar.Text = ownershipDetailsDt.Rows[0]["Owner_Ship_Ar_Name"].ToString();
                    lbl_Dtl_Parcel_Area.Text = ownershipDetailsDt.Rows[0]["Parcel_Area"].ToString();
                    lbl_Dtl_Bond_No.Text = ownershipDetailsDt.Rows[0]["Bond_NO"].ToString();
                    lbl_Dtl_Street_NO.Text = ownershipDetailsDt.Rows[0]["Street_NO"].ToString();
                    lbl_Dtl_Street_Name.Text = ownershipDetailsDt.Rows[0]["Street_Name"].ToString();
                    lbl_Dtl_Land_Value.Text = ownershipDetailsDt.Rows[0]["Land_Value"].ToString();
                    lbl_Dtl_PIN.Text = ownershipDetailsDt.Rows[0]["PIN_Number"].ToString();
                    lbl_Dtl_Code.Text = ownershipDetailsDt.Rows[0]["owner_ship_Code"].ToString();
                    lbl_Dtl_Landlord.Text = ownershipDetailsDt.Rows[0]["Owner_Arabic_name"].ToString();
                    lbl_Dtl_Zone_NO.Text = ownershipDetailsDt.Rows[0]["zone_number"].ToString();
                    lbl_Dtl_Zone_Name.Text = ownershipDetailsDt.Rows[0]["zone_arabic_name"].ToString();
                    // lbl_Dtl_Ownership_Status.Text = Ownership_Details_dt.Rows[0]["ownership_arabic_status"].ToString();

                    lbl_Link_Ownership_Certificate_Pdf.Text = ownershipDetailsDt.Rows[0]["owner_ship_Certificate_Image"].ToString();
                    Link_Ownership_Certificate_Pdf.HRef = ownershipDetailsDt.Rows[0]["owner_ship_Certificate_Image_Path"].ToString();
                    Link_Ownership_Certificate_Pdf.Target = "_blank";

                    lbl_Link_Property_Scheme_Pdf.Text = ownershipDetailsDt.Rows[0]["Property_Scheme_Image"].ToString();
                    Link_Property_Scheme.HRef = ownershipDetailsDt.Rows[0]["Property_Scheme_Image_Path"].ToString();
                    Link_Property_Scheme.Target = "_blank";

                    if (lbl_Link_Ownership_Certificate_Pdf.Text == "No File")
                    {
                        Link_Ownership_Certificate_Pdf.Visible = false;
                    }

                    if (lbl_Link_Property_Scheme_Pdf.Text == "No File")
                    {
                        Link_Property_Scheme.Visible = false;
                    }

                    using (MySqlCommand numberOfBuildingCmd =
                           new MySqlCommand("SELECT COUNT(*) FROM building Where owner_ship_Owner_Ship_Id =@Id",
                               _sqlCon))
                    {
                        string ownerId = Request.QueryString["Id"];
                        numberOfBuildingCmd.Parameters.AddWithValue("@Id", ownerId);
                        numberOfBuildingCmd.CommandType = CommandType.Text;
                        object o = numberOfBuildingCmd.ExecuteScalar();
                        if (o != null)
                        {
                            lbl_Dtl_Number_Of_Building.Text = o.ToString();
                        }
                    }
                }
            }

            _sqlCon.Close();
            if (!IsPostBack)
            {
                Building_List_BindData();






                
            }
        }

        protected void Building_List_BindData(string sortExpression = null)
        {
            //try
            //{
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
            // }
            //catch { Response.Write(@"<script language='javascript'>alert('OOPS!!! The Building List Cannt Display')</script>"); }
        }

        protected void Delete_Building(object sender, EventArgs e)
        {
            try
            {
                string buildingId = (sender as LinkButton).CommandArgument;
                _sqlCon.Open();
                string deleteBuildingQuary = "DELETE FROM building WHERE Building_Id=@ID ";
                MySqlCommand deleteBuildingCmd = new MySqlCommand(deleteBuildingQuary, _sqlCon);
                deleteBuildingCmd.Parameters.AddWithValue("@ID", buildingId);
                deleteBuildingCmd.ExecuteNonQuery();
                _sqlCon.Close();
                Response.Redirect(Request.RawUrl);
            }
            catch { Response.Write(@"<script language='javascript'>alert('This Building Cannot Be Removed!!! Because It Contains  Units')</script>"); }
        }

        protected void Edit_Building(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Edit_Building_In_Ownership_Detais.aspx?Id=" + id);
        }

        protected void Details_Building(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            _sqlCon.Open();
            string buildingId = (sender as LinkButton).CommandArgument;
            using (MySqlCommand buildingDetailsCmd = new MySqlCommand("Building_Details", _sqlCon))
            {
                buildingDetailsCmd.CommandType = CommandType.StoredProcedure;
                buildingDetailsCmd.Parameters.AddWithValue("@Id", buildingId);
                using (MySqlDataAdapter buildingDetailsSda = new MySqlDataAdapter(buildingDetailsCmd))
                {
                    DataTable bulidingDetailsDt = new DataTable();
                    buildingDetailsSda.Fill(bulidingDetailsDt);

                    lbl_Details_Building_Name.Text = bulidingDetailsDt.Rows[0]["Building_Arabic_Name"].ToString();
                    lbl_Tiltel_Buliding_En_Name.Text = bulidingDetailsDt.Rows[0]["Building_English_Name"].ToString();
                    lbl_Dtl_Buliding_Ar_Name.Text = bulidingDetailsDt.Rows[0]["Building_Arabic_Name"].ToString();
                    lbl_Dtl_Number.Text = bulidingDetailsDt.Rows[0]["Building_NO"].ToString();
                    lbl_Dtl_electricity_meter.Text = bulidingDetailsDt.Rows[0]["electricity_meter"].ToString();
                    lbl_Dtl_Water_meter.Text = bulidingDetailsDt.Rows[0]["Water_meter"].ToString();
                    lbl_Dtl_Construction_Area.Text = bulidingDetailsDt.Rows[0]["Construction_Area"].ToString();
                    lbl_Dtl_Maintenance_status.Text = bulidingDetailsDt.Rows[0]["Maintenance_status"].ToString();
                    lbl_Dtl_Building_Condition.Text =
                        bulidingDetailsDt.Rows[0]["Building_Arabic_Condition"].ToString();
                    lbl_Dtl_Building_Type.Text = bulidingDetailsDt.Rows[0]["Building_Arabic_Type"].ToString();
                    lbl_Dtl_Building_Ownership.Text = bulidingDetailsDt.Rows[0]["Owner_Ship_Ar_Name"].ToString();

                    //**************************************************************************************************
                    string buildingPhotoPath = bulidingDetailsDt.Rows[0]["Building_Photo_Path"].ToString();
                    if (buildingPhotoPath == "No File")
                    {
                        Building_Photo.Visible = false;
                    }
                    else
                    {
                        Building_Photo.ImageUrl = bulidingDetailsDt.Rows[0]["Building_Photo_Path"].ToString();
                    }

                    //**************************************************************************************************
                    string entrancePhotoPath = bulidingDetailsDt.Rows[0]["Entrance_Photo_Path"].ToString();
                    if (entrancePhotoPath == "No File")
                    {
                        Entrance.Visible = false;
                    }
                    else
                    {
                        Entrance.ImageUrl = bulidingDetailsDt.Rows[0]["Entrance_Photo_Path"].ToString();
                    }

                    //**************************************************************************************************
                    string planoPath = bulidingDetailsDt.Rows[0]["Plano_Path"].ToString();
                    if (planoPath == "No File")
                    {
                        Plan.Visible = false;
                    }
                    else
                    {
                        Plan.ImageUrl = bulidingDetailsDt.Rows[0]["Plano_Path"].ToString();
                    }

                    //**************************************************************************************************
                    string imagePath = bulidingDetailsDt.Rows[0]["Image_Path"].ToString();
                    if (imagePath == "No File")
                    {
                        Image.Visible = false;
                    }
                    else
                    {
                        Image.ImageUrl = bulidingDetailsDt.Rows[0]["Image_Path"].ToString();
                    }
                    //**************************************************************************************************
                    string buildingPermitPath = bulidingDetailsDt.Rows[0]["Building_Permit_Path"].ToString();
                    if (buildingPermitPath == "No File")
                    {
                        Link_Building_Permit.Visible = false;
                    }
                    else
                    {
                        lbl_Link_Building_Permit_Pdf.Text = bulidingDetailsDt.Rows[0]["Building_Permit"].ToString();
                        Link_Building_Permit.HRef = bulidingDetailsDt.Rows[0]["Building_Permit_Path"].ToString();
                    }

                    Link_Building_Permit.Target = "_blank";
                    //**************************************************************************************************
                    string certificateOfCompletionPath =
                        bulidingDetailsDt.Rows[0]["certificate_of_completion_Path"].ToString();
                    if (certificateOfCompletionPath == "No File")
                    {
                        Link_certificate_of_completion.Visible = false;
                    }
                    else
                    {
                        lbl_Link_certificate_of_completion_Pdf.Text =
                            bulidingDetailsDt.Rows[0]["certificate_of_completion"].ToString();
                        Link_certificate_of_completion.HRef =
                            bulidingDetailsDt.Rows[0]["certificate_of_completion_Path"].ToString();
                    }

                    Link_certificate_of_completion.Target = "_blank";

                    //**********************************************************************************************************************
                    string mapPath = bulidingDetailsDt.Rows[0]["Map_path"].ToString();
                    if (mapPath == "No File")
                    {
                        Link_Map.Visible = false;
                    }
                    else
                    {
                        lbl_Link_Map.Text = bulidingDetailsDt.Rows[0]["Map"].ToString();
                        Link_Map.HRef = bulidingDetailsDt.Rows[0]["Map_path"].ToString();
                    }

                    Link_Map.Target = "_blank";
                }

                using (MySqlCommand numberOfUnitsCmd =
                       new MySqlCommand("SELECT COUNT(*) FROM units Where building_Building_Id =@Id", _sqlCon))
                {
                    numberOfUnitsCmd.Parameters.AddWithValue("@Id", buildingId);
                    numberOfUnitsCmd.CommandType = CommandType.Text;
                    object numberOfBuilding = numberOfUnitsCmd.ExecuteScalar();
                    if (numberOfBuilding != null)
                    {
                        lbl_Dtl_Number_Of_Units.Text = numberOfBuilding.ToString();
                    }
                }
            }

            _sqlCon.Close();



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
                Unit_List.DataSource = dt;
                Unit_List.DataBind();
            }
            _sqlCon.Close();



            Page.SetFocus(Building_Photo.ClientID);
        }

        protected void btn_Back_To_OwnerShip_List_Click(object sender, EventArgs e)
        {
            if (Session["OW_Back"].ToString() == "1")
            {
                Response.Redirect("Ownership_List.aspx");
            }
            else if (Session["OW_Back"].ToString() == "2")
            {
                Response.Redirect("Test_4.aspx?Id=2");
            }
            else
            {
                Response.Redirect("Missing_Fields.aspx");
            }
        }

        protected void Building_Photo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(Building_Photo.ImageUrl);
        }

        protected void Entrance_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(Entrance.ImageUrl);
        }

        protected void Plan_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(Plan.ImageUrl);
        }

        protected void Image_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(Image.ImageUrl);
        }

        protected void btn_Close_QID_Panel_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }































        

        protected void Delete_Unit(object sender, EventArgs e)
        {
            try
            {
                string id = (sender as LinkButton).CommandArgument;
                _sqlCon.Open();
                string quary1 = "DELETE FROM units WHERE unit_Id=@ID ";
                MySqlCommand mySqlCmd = new MySqlCommand(quary1, _sqlCon);
                mySqlCmd.Parameters.AddWithValue("@ID", id);
                mySqlCmd.ExecuteNonQuery();
                _sqlCon.Close();

                Response.Redirect(Request.RawUrl);
            }
            catch
            {
                Response.Write(
                    @"<script language='javascript'>alert('This Unit Cannot Be Removed!!! Because It Contains  Tenants')</script>");
            }

            ;
        }

        protected void Edit_Unit(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;

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
    }
}