using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Unit_Datials : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            _sqlCon.Open();
            string unitId = Request.QueryString["Id"];
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

                    if (unitDetailsDt.Rows[0]["Image_One_Path"].ToString() == "No File")
                    {
                        Image_1.Visible = false;
                    }
                    else
                    {
                        Image_1.ImageUrl = unitDetailsDt.Rows[0]["Image_One_Path"].ToString();
                    }

                    //***********************************************************************************
                    if (unitDetailsDt.Rows[0]["Image_Two_Path"].ToString() == "No File")
                    {
                        Image_2.Visible = false;
                    }
                    else
                    {
                        Image_2.ImageUrl = unitDetailsDt.Rows[0]["Image_Two_Path"].ToString();
                    }
                    //***********************************************************************************

                    if (unitDetailsDt.Rows[0]["Image_Three_Path"].ToString() == "No File")
                    {
                        Image_3.Visible = false;
                    }
                    else
                    {
                        Image_3.ImageUrl = unitDetailsDt.Rows[0]["Image_Three_Path"].ToString();
                    }

                    //***********************************************************************************
                    if (unitDetailsDt.Rows[0]["Image_Four_Path"].ToString() == "No File")
                    {
                        Image_4.Visible = false;
                    }
                    else
                    {
                        Image_4.ImageUrl = unitDetailsDt.Rows[0]["Image_Four_Path"].ToString();
                    }
                }
            }
        }

        protected void btn_Back_To_Unit_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Units_List.aspx");
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