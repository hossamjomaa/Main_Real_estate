using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Website_Info : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //  ownership_Name_DropDownList
                Helper.LoadDropDownList("SELECT * FROM owner_ship", _sqlCon, ownership_Name_DropDownList, "Owner_Ship_AR_Name", "Owner_Ship_Id");
                ownership_Name_DropDownList.Items.Insert(0, "أختر إسم الملكية ....");
                //  Building_Name_DropDownList Defult Value
                Building_Name_DropDownList.Items.Insert(0, "أختر إسم البناء ....");
                //***************************************************************************************************************************************
                DataTable get_Website_Dt = new DataTable();
                _sqlCon.Open();
                MySqlCommand get_Website_Cmd = new MySqlCommand("SELECT * FROM websit_info WHERE WebSit_Info_Id > 0", _sqlCon);
                MySqlDataAdapter get_Website_Da = new MySqlDataAdapter(get_Website_Cmd);
                get_Website_Da.Fill(get_Website_Dt);
                if (get_Website_Dt.Rows.Count > 0)
                {
                    txt_Ar_Who_Are_We.Text = get_Website_Dt.Rows[0]["Who_Are_We_Ar"].ToString();
                    txt_En_Who_Are_We.Text = get_Website_Dt.Rows[0]["Who_Are_We_En"].ToString();
                    txt_Ar_Address.Text = get_Website_Dt.Rows[0]["Adress_Ar"].ToString();
                    txt_En_Address.Text = get_Website_Dt.Rows[0]["Adress_En"].ToString();
                    txt_Phone.Text = get_Website_Dt.Rows[0]["Phone"].ToString();
                    txt_Email.Text = get_Website_Dt.Rows[0]["Email"].ToString();
                    txt_FaceBook.Text = get_Website_Dt.Rows[0]["Facebook"].ToString();
                    txt_Whatssapp.Text = get_Website_Dt.Rows[0]["Whatssapp"].ToString();
                }
                _sqlCon.Close();
                //*********************************************************************************************************************************************
                DataTable get_Service_Dt = new DataTable();
                _sqlCon.Open();
                MySqlCommand get_Service_Cmd = new MySqlCommand("SELECT * FROM website_servic_info WHERE Id > 0", _sqlCon);
                MySqlDataAdapter get_Service_Da = new MySqlDataAdapter(get_Service_Cmd);
                get_Service_Da.Fill(get_Service_Dt);
                if (get_Service_Dt.Rows.Count > 0)
                {
                    Service_GridView.DataSource = get_Service_Dt;
                    Service_GridView.DataBind();
                }
                _sqlCon.Close();
                //*********************************************************************************************************************************************
                refreshdata();
            }
        }
        public void refreshdata()
        {
            using (MySqlCommand cmd = new MySqlCommand("Unit_List", _sqlCon))
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void ownership_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  Building_Name_DropDownList
            Helper.LoadDropDownList("SELECT * FROM building Where Active ='1' and owner_ship_Owner_Ship_Id = '" + ownership_Name_DropDownList.SelectedValue + "'", _sqlCon, Building_Name_DropDownList, "Building_Arabic_Name", "Building_Id");
            Building_Name_DropDownList.Items.Insert(0, "أختر إسم البناء ....");
        }

        protected void Building_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string get_Unit_Photo_Quari = "SELECT " +
                    "U.* , UT.* , UC.* ,UD.* , B.* ,O.* , Z.* FROM units U " +
                    "left join unit_type UT on(U.unit_type_Unit_Type_Id = UT.Unit_Type_Id) " +
                    "left join unit_condition UC on(U.unit_condition_Unit_Condition_Id = UC.Unit_Condition_Id) " +
                    "left join unit_detail UD on(U.unit_detail_Unit_Detail_Id = UD.Unit_Detail_Id) " +
                    "left join building B on(U.building_Building_Id = B.Building_Id) " +
                    "left join owner_ship O on(B.owner_ship_Owner_Ship_Id = O.Owner_Ship_Id) " +
                    "left join zone Z on(O.zone_zone_Id = Z.zone_Id) " +
                    "where U.Half ='0' and building_Building_Id = '" + Building_Name_DropDownList.SelectedValue+"' ";

            MySqlCommand get_Unit_Photo_Cmd = new MySqlCommand(get_Unit_Photo_Quari, _sqlCon);
            MySqlDataAdapter get_Unit_Photo_Dt = new MySqlDataAdapter(get_Unit_Photo_Cmd);
            get_Unit_Photo_Cmd.Connection = _sqlCon;
            _sqlCon.Open();
            get_Unit_Photo_Dt.SelectCommand = get_Unit_Photo_Cmd;
            get_Unit_Photo_Cmd.Parameters.AddWithValue("@ID", "1");
            DataTable get_Unit_Photo_DataTable = new DataTable();
            get_Unit_Photo_Dt.Fill(get_Unit_Photo_DataTable);
            GridView1.DataSource = get_Unit_Photo_DataTable;
            GridView1.DataBind();
            _sqlCon.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
                if (checkbox.Checked == true)
                {
                    var lbl_Image_One = gvrow.FindControl("lbl_Image_One") as Label;
                    var lbl_Image_Two = gvrow.FindControl("lbl_Image_Two") as Label;
                    var lbl_Image_Three = gvrow.FindControl("lbl_Image_Three") as Label;
                    var lbl_Image_Four = gvrow.FindControl("lbl_Image_Four") as Label;
                    var lbl_Unit_Id = gvrow.FindControl("lbl_Unit_Id") as Label;


                    MySqlCommand cmd = new MySqlCommand("UPDATE units SET " +
                                                        "Image_One_Path_Website = @Image_One_Path_Website ," +
                                                        "Image_Two_Path_Website = @Image_Two_Path_Website ," +
                                                        "Image_Three_Path_Website = @Image_Three_Path_Website ," +
                                                        "Image_Four_Path_Website = @Image_Four_Path_Website ," +
                                                        " Active=@Active " +
                                                        "WHERE Unit_ID ='"+ lbl_Unit_Id .Text+ "'", _sqlCon);

                    cmd.Parameters.AddWithValue("Image_One_Path_Website", "https://amlak2.wisdom.qa/English/Main_Application/units_Photo/" + lbl_Image_One.Text);
                    cmd.Parameters.AddWithValue("Image_Two_Path_Website", "https://amlak2.wisdom.qa/English/Main_Application/units_Photo/" + lbl_Image_Two.Text);
                    cmd.Parameters.AddWithValue("Image_Three_Path_Website", "https://amlak2.wisdom.qa/English/Main_Application/units_Photo/" + lbl_Image_Three.Text);
                    cmd.Parameters.AddWithValue("Image_Four_Path_Website", "https://amlak2.wisdom.qa/English/Main_Application/units_Photo/" + lbl_Image_Four.Text);
                    cmd.Parameters.AddWithValue("Active", "1");
                    _sqlCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    _sqlCon.Close();
                    refreshdata();
                }
                else
                {
                    var lbl_Image_One = gvrow.FindControl("lbl_Image_One") as Label;
                    var lbl_Image_Two = gvrow.FindControl("lbl_Image_Two") as Label;
                    var lbl_Image_Three = gvrow.FindControl("lbl_Image_Three") as Label;
                    var lbl_Image_Four = gvrow.FindControl("lbl_Image_Four") as Label;
                    var lbl_Unit_Id = gvrow.FindControl("lbl_Unit_Id") as Label;


                    MySqlCommand cmd = new MySqlCommand("UPDATE units SET " +
                                                        "Image_One_Path_Website = @Image_One_Path_Website ," +
                                                        "Image_Two_Path_Website = @Image_Two_Path_Website ," +
                                                        "Image_Three_Path_Website = @Image_Three_Path_Website ," +
                                                        "Image_Four_Path_Website = @Image_Four_Path_Website ," +
                                                        " Active=@Active " +
                                                        "WHERE Unit_ID ='" + lbl_Unit_Id.Text + "'", _sqlCon);

                    cmd.Parameters.AddWithValue("Image_One_Path_Website", "");
                    cmd.Parameters.AddWithValue("Image_Two_Path_Website", "");
                    cmd.Parameters.AddWithValue("Image_Three_Path_Website", "");
                    cmd.Parameters.AddWithValue("Image_Four_Path_Website", "");
                    cmd.Parameters.AddWithValue("Active", "0");
                    _sqlCon.Open();
                    int i = cmd.ExecuteNonQuery();
                    _sqlCon.Close();
                    refreshdata();
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string Active; CheckBox CB;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    Active = ((Label)e.Row.FindControl("lbl_Activ")).Text;
                    CB = ((CheckBox)e.Row.FindControl("CheckBox1"));
                    if (Active == "True")
                    {
                        e.Row.ForeColor = System.Drawing.Color.Blue;
                        e.Row.BackColor = System.Drawing.Color.AliceBlue;
                        CB.Checked=true;
                    }
                }
                catch
                {
                    Active = "";
                }
            }
        }

        protected void Add_website_Info_Click(object sender, EventArgs e)
        {
            MySqlConnection con = Helper.GetConnection();
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from websit_info", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                MySqlCommand Website_cmd = new MySqlCommand("UPDATE websit_info SET " +
                                                            "Who_Are_We_Ar = @Who_Are_We_Ar ," +
                                                            "Who_Are_We_En = @Who_Are_We_En ," +
                                                            "Adress_Ar = @Adress_Ar ," +
                                                            "Adress_En = @Adress_En ," +
                                                            "Phone=@Phone ," +
                                                            "Email=@Email ," +
                                                            "Facebook=@Facebook ," +
                                                            "Whatssapp=@Whatssapp, " +

                                                            "Email_From=@Email_From ," +
                                                            "Email_To=@Email_To ," +
                                                            "Email_STMP=@Email_STMP ," +
                                                            "Email_Port=@Email_Port ," +
                                                            "Email_Password=@Email_Password " +

                                                            "WHERE WebSit_Info_Id > 0", _sqlCon);

                Website_cmd.Parameters.AddWithValue("@Who_Are_We_Ar", txt_Ar_Who_Are_We.Text);
                Website_cmd.Parameters.AddWithValue("@Who_Are_We_En", txt_En_Who_Are_We.Text);
                Website_cmd.Parameters.AddWithValue("@Adress_Ar", txt_Ar_Address.Text);
                Website_cmd.Parameters.AddWithValue("@Adress_En", txt_En_Address.Text);
                Website_cmd.Parameters.AddWithValue("@Phone", txt_Phone.Text);
                Website_cmd.Parameters.AddWithValue("@Email", txt_Email.Text);
                Website_cmd.Parameters.AddWithValue("@Facebook", txt_FaceBook.Text);
                Website_cmd.Parameters.AddWithValue("@Whatssapp", txt_Whatssapp.Text);

                Website_cmd.Parameters.AddWithValue("@Email_From", txt_Email_From.Text);
                Website_cmd.Parameters.AddWithValue("@Email_To", txt_Email_To.Text);
                Website_cmd.Parameters.AddWithValue("@Email_STMP", txt_Email_STMP.Text);
                Website_cmd.Parameters.AddWithValue("@Email_Port", txt_Email_Port.Text);
                Website_cmd.Parameters.AddWithValue("@Email_Password", txt_Email_Password.Text);
                _sqlCon.Open();
                 Website_cmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_WebSite_Info.Text = "تمت الإضافة بنجاح";
            }
            else
            {
                MySqlCommand Website_cmd = new MySqlCommand("Insert Into websit_info " +
                                                            "(Who_Are_We_Ar," +
                                                            "Who_Are_We_En," +
                                                            "Adress_Ar," +
                                                            "Adress_En," +
                                                            "Phone," +
                                                            "Email," +
                                                            "Facebook," +

                                                            "Email_From," +
                                                            "Email_To," +
                                                            "Email_STMP," +
                                                            "Email_Port," +
                                                            "Email_Password," +

                                                            "Whatssapp) " +
                                                            "VALUES " +
                                                            "(@Who_Are_We_Ar," +
                                                            "@Who_Are_We_En," +
                                                            "@Adress_Ar," +
                                                            "@Adress_En," +
                                                            "@Phone," +
                                                            "@Email," +
                                                            "@Facebook," +
                                                            "@Email_From," +
                                                            "@Email_To," +
                                                            "@Email_STMP," +
                                                            "@Email_Port," +
                                                            "@Email_Password," +
                                                            "@Whatssapp )", _sqlCon);

                Website_cmd.Parameters.AddWithValue("Who_Are_We_Ar", txt_Ar_Who_Are_We.Text);
                Website_cmd.Parameters.AddWithValue("Who_Are_We_En", txt_En_Who_Are_We.Text);
                Website_cmd.Parameters.AddWithValue("Adress_Ar", txt_Ar_Address.Text);
                Website_cmd.Parameters.AddWithValue("Adress_En", txt_En_Address.Text);
                Website_cmd.Parameters.AddWithValue("Phone", txt_Phone.Text);
                Website_cmd.Parameters.AddWithValue("Email", txt_Email.Text);
                Website_cmd.Parameters.AddWithValue("Facebook", txt_FaceBook.Text);
                Website_cmd.Parameters.AddWithValue("Whatssapp", txt_Whatssapp.Text);

                Website_cmd.Parameters.AddWithValue("@Email_From", txt_Email_From.Text);
                Website_cmd.Parameters.AddWithValue("@Email_To", txt_Email_To.Text);
                Website_cmd.Parameters.AddWithValue("@Email_STMP", txt_Email_STMP.Text);
                Website_cmd.Parameters.AddWithValue("@Email_Port", txt_Email_Port.Text);
                Website_cmd.Parameters.AddWithValue("@Email_Password", txt_Email_Password.Text);
                _sqlCon.Open();
                Website_cmd.ExecuteNonQuery();
                _sqlCon.Close();
                lbl_WebSite_Info.Text = "تمت الإضافة بنجاح";
            }
        }
        protected void BTN_Add_Servic_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string addServiceQuary = "Insert Into website_servic_info " +
                    "(Arabic_Titel , English_Titel ,Arabic_Description , English_Description , Servic_Image_Name , Servic_Image_Path , Servic_Image_Path_WebSite) " +
                    "VALUES" +
                    "(@Arabic_Titel , @English_Titel ,@Arabic_Description , @English_Description , @Servic_Image_Name , @Servic_Image_Path , @Servic_Image_Path_WebSite)";
                _sqlCon.Open();
                MySqlCommand addServiceCmd = new MySqlCommand(addServiceQuary, _sqlCon);
                addServiceCmd.Parameters.AddWithValue("@Arabic_Titel", txt_Servic_AR_Title.Text);
                addServiceCmd.Parameters.AddWithValue("@English_Titel", txt_Servic_EN_Title.Text);
                addServiceCmd.Parameters.AddWithValue("@Arabic_Description", txt_Servic_AR_Description.Text);
                addServiceCmd.Parameters.AddWithValue("@English_Description", txt_Servic_EN_Description.Text);


                if (FUL_Servic_Imag.HasFile)
                {
                    string fileName = Path.GetFileName(FUL_Servic_Imag.PostedFile.FileName);
                    FUL_Servic_Imag.PostedFile.SaveAs(Server.MapPath("/English/Master_Panal/Service_Image/") + fileName);

                    addServiceCmd.Parameters.AddWithValue("@Servic_Image_Name", fileName);
                    addServiceCmd.Parameters.AddWithValue("@Servic_Image_Path", "/English/Master_Panal/Service_Image/" + fileName);

                    addServiceCmd.Parameters.AddWithValue("@Servic_Image_Path_WebSite", "https://amlak2.wisdom.qa/English/Master_Panal/Service_Image/"+ fileName);
                }
                else
                {
                    addServiceCmd.Parameters.AddWithValue("@Servic_Image_Name", "empty_Image");
                    addServiceCmd.Parameters.AddWithValue("@Servic_Image_Path", "/English/Main_Application/Main_Image/empty_Image.jpg/");

                    addServiceCmd.Parameters.AddWithValue("@Servic_Image_Path_WebSite", "https://amlak2.wisdom.qa/English/Main_Application/Main_Image/empty_Image.jpg/");
                }
                addServiceCmd.ExecuteNonQuery();
                _sqlCon.Close();
            }
            Response.Redirect("Website_Info.aspx");
        }

        protected void Delete_Servic(object sender, EventArgs e)
        {
            try
            {
                string ServicRowId = (sender as LinkButton).CommandArgument;
                _sqlCon.Open();
                string deleteServiceQuary = "DELETE FROM website_servic_info WHERE Id=@ID ";
                MySqlCommand mySqlCmd = new MySqlCommand(deleteServiceQuary, _sqlCon);
                mySqlCmd.Parameters.AddWithValue("@ID", ServicRowId);
                mySqlCmd.ExecuteNonQuery();
                _sqlCon.Close();
                Response.Redirect(Request.RawUrl);
            }
            catch{ Response.Write(@"<script language='javascript'>alert('This Servic Cannot Be Deleted ')</script>");};
        }
    }
}