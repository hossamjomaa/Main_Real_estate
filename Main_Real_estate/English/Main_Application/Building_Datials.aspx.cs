using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Building_Datials : System.Web.UI.Page
    {
        private int _size = 0;
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "properties", 0, "R");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            _sqlCon.Open();
            string buildingId = Request.QueryString["Id"];
            using (MySqlCommand buildingDetailsCmd = new MySqlCommand("Building_Details", _sqlCon))
            {
                buildingDetailsCmd.CommandType = CommandType.StoredProcedure;
                buildingDetailsCmd.Parameters.AddWithValue("@Id", buildingId);
                using (MySqlDataAdapter buildingDetailsSda = new MySqlDataAdapter(buildingDetailsCmd))
                {
                    DataTable bulidingDetailsDt = new DataTable();
                    buildingDetailsSda.Fill(bulidingDetailsDt);

                    lbl_Details_Building_Name.Text = bulidingDetailsDt.Rows[0]["Building_Arabic_Name"].ToString();
                    lbl_Dtl_Name_EN.Text = bulidingDetailsDt.Rows[0]["Building_English_Name"].ToString();
                    lbl_Dtl_Name_Ar.Text = bulidingDetailsDt.Rows[0]["Building_Arabic_Name"].ToString();
                    lbl_Dtl_Number.Text = bulidingDetailsDt.Rows[0]["Building_NO"].ToString();
                    lbl_Dtl_electricity_meter.Text = bulidingDetailsDt.Rows[0]["electricity_meter"].ToString();
                    lbl_Dtl_Water_meter.Text = bulidingDetailsDt.Rows[0]["Water_meter"].ToString();
                    lbl_Dtl_Construction_Area.Text = bulidingDetailsDt.Rows[0]["Construction_Area"].ToString();
                    lbl_Dtl_Maintenance_status.Text = bulidingDetailsDt.Rows[0]["Maintenance_status"].ToString();
                    lbl_Dtl_Building_Value.Text = bulidingDetailsDt.Rows[0]["Building_Value"].ToString();
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

                using (MySqlCommand numberOfUnitsCmd = new MySqlCommand("SELECT COUNT(*) FROM units Where building_Building_Id =@Id", _sqlCon))
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
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData(string sortExpression = null)
        {
            string buildingId = Request.QueryString["Id"];
            try
            {
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
            }
            catch
            {
                Response.Write(
                    @"<script language='javascript'>alert('OOPS!!! The Building List Cannt Display')</script>");
            }
        }

        

        protected void Edit_Unit(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Edit_Unit_In_Building_Details.aspx?Id=" + id);
        }

        protected void Details_Unit(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            _sqlCon.Open();
            string unitId = (sender as LinkButton).CommandArgument;
            using (MySqlCommand unitDetailsCmd = new MySqlCommand("Unit_Details", _sqlCon))
            {
                unitDetailsCmd.CommandType = CommandType.StoredProcedure;
                unitDetailsCmd.Parameters.AddWithValue("@Id", unitId);
                using (MySqlDataAdapter unitDetailsSda = new MySqlDataAdapter(unitDetailsCmd))
                {
                    DataTable unitDetailsDt = new DataTable();
                    unitDetailsSda.Fill(unitDetailsDt);
                    lbl_Details_Unit_Name.Text = "الوحدة " + unitDetailsDt.Rows[0]["Unit_Number"].ToString();

                    lbl_Dtl_Unit_Number.Text = "الوحدة " + unitDetailsDt.Rows[0]["Unit_Number"].ToString();
                    lbl_Dtl_Floor_Number.Text = unitDetailsDt.Rows[0]["Floor_Number"].ToString();
                    lbl_Dtl_Unit_Sapce.Text = unitDetailsDt.Rows[0]["Unit_Space"].ToString();
                    lbl_Dtl_current_situation.Text = unitDetailsDt.Rows[0]["current_situation"].ToString();
                    lbl_Dtl_Oreedo_Number.Text = unitDetailsDt.Rows[0]["Oreedo_Number"].ToString();
                    lbl_Dtl_Electricity_Number.Text = unitDetailsDt.Rows[0]["Electricityt_Number"].ToString();
                    lbl_Dtl_Water_Number.Text = unitDetailsDt.Rows[0]["Water_Number"].ToString();
                    lbl_Dtl_Unit_type.Text = unitDetailsDt.Rows[0]["Unit_Arabic_Type"].ToString();
                    lbl_Dtl_Unit_Condition.Text = unitDetailsDt.Rows[0]["Unit_Arabic_Condition"].ToString();
                    lbl_Dtl_Unit_Detail.Text = unitDetailsDt.Rows[0]["Unit_Arabic_Detail"].ToString();

                    string imageOnePath = unitDetailsDt.Rows[0]["Image_One_Path"].ToString();
                    if (imageOnePath == "No File")
                    {
                        Image_1.Visible = false;    
                    }
                    else
                    {
                        Image_1.ImageUrl = unitDetailsDt.Rows[0]["Image_One_Path"].ToString();
                    }

                    //************************************************************************************************************
                    string imageTwoPath = unitDetailsDt.Rows[0]["Image_Two_Path"].ToString();
                    if (imageTwoPath == "No File")
                    {
                        Image_2.Visible = false;
                    }
                    else
                    {
                        Image_2.ImageUrl = unitDetailsDt.Rows[0]["Image_Two_Path"].ToString();
                    }

                    //************************************************************************************************************
                    string imageThreePath = unitDetailsDt.Rows[0]["Image_Three_Path"].ToString();
                    if (imageThreePath == "No File")
                    {
                        Image_3.Visible = false;
                    }
                    else
                    {
                        Image_3.ImageUrl = unitDetailsDt.Rows[0]["Image_Three_Path"].ToString();
                    }

                    //************************************************************************************************************
                    string imageFourPath = unitDetailsDt.Rows[0]["Image_Four_Path"].ToString();
                    if (imageFourPath == "No File")
                    {
                        Image_4.Visible = false;
                    }
                    else
                    {
                        Image_4.ImageUrl = unitDetailsDt.Rows[0]["Image_Four_Path"].ToString();
                    }
                }
            }

            Page.SetFocus(Image_1.ClientID);
        }

        protected void btn_Back_To_Building_List_Click(object sender, EventArgs e)
        {
            if (Session["B_Back"].ToString() == "1")
            {
                Response.Redirect("Excel_report_New.aspx");
            }
            else if (Session["B_Back"].ToString() == "2")
            {
                Response.Redirect("Test_4.aspx?Id=2");
            }
            else if (Session["B_Back"].ToString() == "3")
            {
                Response.Redirect("Missing_Fields.aspx");
            }
            else
            {
                Response.Redirect("Building_List.aspx");
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

        protected void Photo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(Image_1.ImageUrl);
        }

        protected void Image_2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(Image_2.ImageUrl);
        }

        protected void Image_3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(Image_3.ImageUrl);
        }

        protected void Image_4_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(Image_4.ImageUrl);
        }
    }
}