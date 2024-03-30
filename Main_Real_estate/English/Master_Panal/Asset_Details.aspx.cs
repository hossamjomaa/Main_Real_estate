using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Asset_Details : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            _sqlCon.Open();
            string AssettId = Request.QueryString["Id"];
            using (MySqlCommand AssetDetailsCmd = new MySqlCommand("Asset_Detail", _sqlCon))
            {
                AssetDetailsCmd.CommandType = CommandType.StoredProcedure;
                AssetDetailsCmd.Parameters.AddWithValue("@Id", AssettId);
                using (MySqlDataAdapter AssetDetailsSda = new MySqlDataAdapter(AssetDetailsCmd))
                {
                    DataTable AssetDetailsDt = new DataTable();
                    AssetDetailsSda.Fill(AssetDetailsDt);

                    lbl_Serial_Number.Text = AssetDetailsDt.Rows[0]["Serial_Number"].ToString();
                    lbl_Assets_Arabic_Name.Text = AssetDetailsDt.Rows[0]["Assets_Arabic_Name"].ToString();
                    lbl_Assets_English_Name.Text = AssetDetailsDt.Rows[0]["Assets_English_Name"].ToString();
                    lbl_Assets_Value.Text = AssetDetailsDt.Rows[0]["Assets_Value"].ToString();
                    lbl_Description.Text = AssetDetailsDt.Rows[0]["Description"].ToString();
                    if (AssetDetailsDt.Rows[0]["How_To_Get"].ToString() == "ضمن مشروع")
                    {
                        Contractor_Div.Visible = true;
                        Vendor_Div.Visible = true;
                        Contractor_Waranty_Div.Visible = true;
                        Contractor_Waranty_Remaining_Days_Div.Visible = true;
                        Buyer_Div.Visible = false;
                    }
                    else
                    {
                        Contractor_Div.Visible = false;
                        Vendor_Div.Visible = true;
                        Contractor_Waranty_Div.Visible = false;
                        Contractor_Waranty_Remaining_Days_Div.Visible = false;
                        Buyer_Div.Visible = true;
                    }

                    if (AssetDetailsDt.Rows[0]["Contractor_Waranty_Period"].ToString() != "")
                    {
                        if (AssetDetailsDt.Rows[0]["Purchase_Date"].ToString() != "")
                        {
                            DateTime Today = DateTime.Now;
                            DateTime Purchase_Date = Convert.ToDateTime(AssetDetailsDt.Rows[0]["Purchase_Date"].ToString());

                            int Contractor_Waranty_Period = Convert.ToInt32(AssetDetailsDt.Rows[0]["Contractor_Waranty_Period"].ToString());

                            int difference_between_dates = (int)(Today - Purchase_Date).TotalDays;
                            int Remaining_Day = Contractor_Waranty_Period - difference_between_dates;
                            if (Remaining_Day > 0)
                            {
                                lbl_Contractor_Waranty_Remaining_Days.Text = Remaining_Day.ToString() + "يوم";
                            }
                            else
                            {
                                lbl_Contractor_Waranty_Remaining_Days.Text = " منتهية";
                                lbl_Contractor_Waranty_Remaining_Days.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else
                        {
                            lbl_Contractor_Waranty_Remaining_Days.Text = "غير معروفة(يجب تحديد تاريخ الشراء)";
                        }
                        
                    }
                    if (AssetDetailsDt.Rows[0]["Waranty_Period"].ToString() != "")
                    {
                        if (AssetDetailsDt.Rows[0]["Waranty_Start_Date"].ToString() != "")
                        {
                            DateTime Today = DateTime.Now;
                            DateTime Waranty_Start_Date = Convert.ToDateTime(AssetDetailsDt.Rows[0]["Waranty_Start_Date"].ToString());
                            int Waranty_Period = Convert.ToInt32(AssetDetailsDt.Rows[0]["Waranty_Period"].ToString());
                            int difference_between_dates = (int)(Today - Waranty_Start_Date).TotalDays;
                            int Remaining_Day = Waranty_Period - difference_between_dates;


                            if (Remaining_Day > 0)
                            {
                                lbl_Waranty_Remaining_Days.Text = Remaining_Day.ToString() + "يوم";
                            }
                            else
                            {
                                lbl_Waranty_Remaining_Days.Text = " منتهية";
                                lbl_Waranty_Remaining_Days.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else
                        {
                            lbl_Waranty_Remaining_Days.Text= "غير معروفة(يجب تحديد تاريخ بدء الضمان)";
                        }

                           
                    }




                    lbl_How_To_Get.Text = AssetDetailsDt.Rows[0]["How_To_Get"].ToString();
                    lbl_Contractor.Text = AssetDetailsDt.Rows[0]["Contractor_Ar_Name"].ToString();
                    lbl_Buyer.Text = AssetDetailsDt.Rows[0]["Buyer"].ToString();
                    lbl_Vendor_Arabic_Type.Text = AssetDetailsDt.Rows[0]["Vendor_Arabic_Type"].ToString();
                    lbl_Contractor_Waranty_Period.Text = AssetDetailsDt.Rows[0]["Contractor_Waranty_Period"].ToString() + "يوم";
                    lbl_Purchase_Date.Text = AssetDetailsDt.Rows[0]["Purchase_Date"].ToString();
                    lbl_Asset_Arabic_Condition.Text = AssetDetailsDt.Rows[0]["Asset_Arabic_Condition"].ToString();

                    lbl_Main_Place.Text = AssetDetailsDt.Rows[0]["Main_Place"].ToString();

                    if (AssetDetailsDt.Rows[0]["Main_Place"].ToString() == "مخزن")
                    {
                        lbl_Location_Details.Text = AssetDetailsDt.Rows[0]["Inventory_arabic_name"].ToString() + "/" + AssetDetailsDt.Rows[0]["Inventory_Location"].ToString();

                    }
                    else
                    {
                        lbl_Location_Details.Text = AssetDetailsDt.Rows[0]["Owner_Ship_AR_Name"].ToString() + "/" +
                        AssetDetailsDt.Rows[0]["Building_Arabic_Name"].ToString() + "/" +
                        AssetDetailsDt.Rows[0]["Unit_Number"].ToString();
                    }
                    lbl_Waranty_Period.Text = AssetDetailsDt.Rows[0]["Waranty_Period"].ToString();
                    lbl_Waranty_Start_Date.Text = AssetDetailsDt.Rows[0]["Waranty_Start_Date"].ToString();
                    lbl_Waranty_End_Date.Text = AssetDetailsDt.Rows[0]["Waranty_End_Date"].ToString();


                    string Waranty_Certificate_Path = AssetDetailsDt.Rows[0]["Waranty_Certificate_Path"].ToString();
                    if (Waranty_Certificate_Path == "No File")
                    {
                        Link_Waranty_Certificate_Path.Visible = false;
                    }
                    else
                    {
                        lbl_Link_Waranty_Certificate.Text = AssetDetailsDt.Rows[0]["Waranty_Certificate"].ToString();
                        Link_Waranty_Certificate_Path.HRef = AssetDetailsDt.Rows[0]["Waranty_Certificate_Path"].ToString();
                    }

                    Link_Waranty_Certificate_Path.Target = "_blank";

                }
            }
        }

        protected void btn_Back_To_Asset_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("Asset_List.aspx");
        }
    }
}