using Main_Real_estate.English.Master_Panal;
using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics.Contracts;
using System.IO;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Edit_Ownership : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "properties", 0, "R");
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "properties", 2, "E");
                Utilities.Roles.Delete_permission_With_Reason(_sqlCon, Session["Role"].ToString(), "properties", Delete_Ownership, Delete_Reason);
                Utilities.Roles.Delete_permission(_sqlCon, Session["Role"].ToString(), "properties", Remove_Certificates);
                Utilities.Roles.Delete_permission(_sqlCon, Session["Role"].ToString(), "properties", Remove_Scheme);
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!Page.IsPostBack)
            {
                Statment();

                

                //    //*****************  Ownership DropDownList ********************
                //    //Get Owner DropDownList
                using (MySqlCommand getOwnerDropDownListCmd = new MySqlCommand("SELECT * FROM owner"))
                {
                    getOwnerDropDownListCmd.CommandType = CommandType.Text;
                    getOwnerDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    Owner_DropDownList.DataSource = getOwnerDropDownListCmd.ExecuteReader();
                    Owner_DropDownList.DataTextField = "Owner_Arabic_name";
                    Owner_DropDownList.DataValueField = "Owner_Id";
                    Owner_DropDownList.DataBind();
                    Owner_DropDownList.Items.Insert(0, "اختر إسم المالك ....");
                    _sqlCon.Close();
                }

                //    //Get Zone Name DropDownList
                using (MySqlCommand getZoneDropDownListCmd = new MySqlCommand("SELECT * FROM zone"))
                {
                    getZoneDropDownListCmd.CommandType = CommandType.Text;
                    getZoneDropDownListCmd.Connection = _sqlCon;
                    _sqlCon.Open();
                    Zone_Name_DropDownList.DataSource = getZoneDropDownListCmd.ExecuteReader();
                    Zone_Name_DropDownList.DataTextField = "zone_Arabic_name";
                    Zone_Name_DropDownList.DataValueField = "zone_Id";
                    Zone_Name_DropDownList.DataBind();
                    Zone_Name_DropDownList.Items.Insert(0, "أختر إسم المنطقة ....");
                    _sqlCon.Close();
                }

                string ownershipId = Request.QueryString["Id"];
                DataTable getOwnershipDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getOwnershipCmd =
                    new MySqlCommand("SELECT * FROM owner_ship WHERE Owner_Ship_Id = @ID", _sqlCon);
                MySqlDataAdapter getOwnershipDa = new MySqlDataAdapter(getOwnershipCmd);
                getOwnershipCmd.Parameters.AddWithValue("@ID", ownershipId);
                getOwnershipDa.Fill(getOwnershipDt);
                if (getOwnershipDt.Rows.Count > 0)
                {
                    txt_En_Ownership_Name.Text = getOwnershipDt.Rows[0]["Owner_Ship_EN_Name"].ToString();
                    txt_Ar_Ownership_Name.Text = getOwnershipDt.Rows[0]["Owner_Ship_AR_Name"].ToString();
                    txt_Ownership_Number.Text = getOwnershipDt.Rows[0]["ownership_NO"].ToString();
                    txt_Parcel_Area.Text = getOwnershipDt.Rows[0]["Parcel_Area"].ToString();
                    txt_Bond_No.Text = getOwnershipDt.Rows[0]["Bond_NO"].ToString();
                    txt_Street_No.Text = getOwnershipDt.Rows[0]["Street_NO"].ToString();
                    txt_Street_Name.Text = getOwnershipDt.Rows[0]["Street_Name"].ToString();
                    txt_Lande_Value.Text = getOwnershipDt.Rows[0]["Land_Value"].ToString();

                    if (getOwnershipDt.Rows[0]["Appreciation_octagon"].ToString() == "تقديري")
                    {
                        CheckBox_Appreciation.Checked = true;
                    }
                    else if (getOwnershipDt.Rows[0]["Appreciation_octagon"].ToString() == "مثمن")
                    {
                        CheckBox_octagon.Checked = true;
                    }
                    else
                    {
                        CheckBox_Appreciation.Checked = false;
                        CheckBox_octagon.Checked = false;
                    }

                    txt_PIN_Number.Text = getOwnershipDt.Rows[0]["PIN_Number"].ToString();
                    lbl_Name_Of_Ownership.Text = getOwnershipDt.Rows[0]["Owner_Ship_Ar_Name"].ToString();



                    Ownership_Certificates_FilePath.Text =  getOwnershipDt.Rows[0]["owner_ship_Certificate_Image_Path"].ToString();
                    Ownership_Certificates_FileName.Text =  getOwnershipDt.Rows[0]["owner_ship_Certificate_Image"].ToString();



                    if(getOwnershipDt.Rows[0]["owner_ship_Certificate_Image"].ToString() != "No File")  { Ownership_Certificate_Div.Visible = true;  }
                    else { Ownership_Certificate_Div.Visible = false; }

                    if (getOwnershipDt.Rows[0]["Property_Scheme_Image"].ToString() != "No File") { Property_Scheme_Div.Visible = true; }
                    else { Property_Scheme_Div.Visible = false; }


                    lbl_Link_Ownership_Certificate_Pdf.Text = getOwnershipDt.Rows[0]["owner_ship_Certificate_Image"].ToString();
                    Link_Ownership_Certificate_Pdf.HRef = getOwnershipDt.Rows[0]["owner_ship_Certificate_Image_Path"].ToString();
                    Link_Ownership_Certificate_Pdf.Target = "_blank";


                    lbl_Link_Property_Scheme_Pdf.Text = getOwnershipDt.Rows[0]["Property_Scheme_Image"].ToString();
                    Link_Property_Scheme_Pdf.HRef = getOwnershipDt.Rows[0]["Property_Scheme_Image_Path"].ToString();
                    Link_Property_Scheme_Pdf.Target = "_blank";





                    Property_Scheme_FilePath.Text = getOwnershipDt.Rows[0]["Property_Scheme_Image_Path"].ToString();
                    Property_Scheme_FileName.Text = getOwnershipDt.Rows[0]["Property_Scheme_Image"].ToString();

                    Owner_DropDownList.SelectedValue = getOwnershipDt.Rows[0]["owner_Owner_Id"].ToString();
                    Zone_Name_DropDownList.SelectedValue = getOwnershipDt.Rows[0]["zone_zone_Id"].ToString();
                    txt_Map_Url.Text = getOwnershipDt.Rows[0]["Mab_Url"].ToString();
                }

                _sqlCon.Close();



                if (Session["OW_Back"].ToString() == "1")
                {
                    btn_Back_To_OwnerShip_List.Text = "العودة لقائمة الملكيات";
                }
                else if (Session["OW_Back"].ToString() == "2")
                {
                    btn_Back_To_OwnerShip_List.Text = "العودة لعمليات الملكيات";
                }
                else if (Session["OW_Back"].ToString() == "3")
                {
                    btn_Back_To_OwnerShip_List.Text = "العودة لكشف النواقص";
                }
                else
                {
                    btn_Back_To_OwnerShip_List.Text = "العودة لقائمة الملكيات";
                }
            }
        }

        protected void btn_Add_Ownership_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string ownershipId = Request.QueryString["ID"];

                string updateOwnershipQuery = "UPDATE owner_ship SET " +
                                                "Owner_Ship_EN_Name=@Owner_Ship_EN_Name , " +
                                                "Owner_Ship_AR_Name=@Owner_Ship_AR_Name , " +
                                                "ownership_NO=@ownership_NO," +
                                                "Parcel_Area=@Parcel_Area , " +
                                                "Bond_NO=@Bond_NO," +
                                                "Bond_Date=@Bond_Date," +
                                                "Street_NO=@Street_NO," +
                                                "Street_Name=@Street_Name," +
                                                "Land_Value=@Land_Value , " +

                                                "Appreciation_octagon=@Appreciation_octagon , " +

                                                "PIN_Number=@PIN_Number , " +
                                                "owner_ship_Code=@owner_ship_Code , " +
                                                "Mab_Url=@Mab_Url , " +
                                                "owner_Owner_Id=@owner_Owner_Id , " +
                                                "zone_zone_Id=@zone_zone_Id, " +
                                                "owner_ship_Certificate_Image=@owner_ship_Certificate_Image , " +
                                                "owner_ship_Certificate_Image_Path=@owner_ship_Certificate_Image_Path , " +
                                                "Property_Scheme_Image=@Property_Scheme_Image , " +
                                                "Property_Scheme_Image_Path=@Property_Scheme_Image_Path  " +
                                                "WHERE Owner_Ship_Id=@ID ";

                _sqlCon.Open();
                MySqlCommand updateOwnershipCmd = new MySqlCommand(updateOwnershipQuery, _sqlCon);

                // Edit The  Textboxs
                updateOwnershipCmd.Parameters.AddWithValue("@ID", ownershipId);
                updateOwnershipCmd.Parameters.AddWithValue("@Owner_Ship_EN_Name", txt_En_Ownership_Name.Text);
                updateOwnershipCmd.Parameters.AddWithValue("@Owner_Ship_AR_Name", txt_Ar_Ownership_Name.Text);
                updateOwnershipCmd.Parameters.AddWithValue("@ownership_NO", txt_Ownership_Number.Text);
                updateOwnershipCmd.Parameters.AddWithValue("@Parcel_Area", txt_Parcel_Area.Text);
                updateOwnershipCmd.Parameters.AddWithValue("@Bond_NO", txt_Bond_No.Text);
                updateOwnershipCmd.Parameters.AddWithValue("@Bond_Date", txt_bond_Date.Text);
                updateOwnershipCmd.Parameters.AddWithValue("@Street_NO", txt_Street_No.Text);
                updateOwnershipCmd.Parameters.AddWithValue("@Street_Name", txt_Street_Name.Text);
                updateOwnershipCmd.Parameters.AddWithValue("@Land_Value", txt_Lande_Value.Text);
                if (txt_Map_Url.Text == "")
                {
                    updateOwnershipCmd.Parameters.AddWithValue("@Mab_Url", "No File");
                }
                else
                {
                    updateOwnershipCmd.Parameters.AddWithValue("@Mab_Url", txt_Map_Url.Text);
                }

                //***************************** Appreciation_octagon ************************************************
                if (CheckBox_Appreciation.Checked == true)
                {
                    updateOwnershipCmd.Parameters.AddWithValue("@Appreciation_octagon", "تقديري");
                }
                else if (CheckBox_octagon.Checked == true)
                {
                    updateOwnershipCmd.Parameters.AddWithValue("@Appreciation_octagon", "مثمن");
                }
                else
                {
                    updateOwnershipCmd.Parameters.AddWithValue("@Appreciation_octagon", " ");
                }
                //***************************************************************************************************

                char[] spaceNumberWords = txt_PIN_Number.Text.ToCharArray();
                if (spaceNumberWords.Length == 8)
                {
                    updateOwnershipCmd.Parameters.AddWithValue("@PIN_Number", txt_PIN_Number.Text);
                    updateOwnershipCmd.Parameters.AddWithValue("@owner_ship_Code", spaceNumberWords[0].ToString() + spaceNumberWords[1].ToString() + "/" +
                        txt_Ownership_Number.Text);
                }
                else
                {
                    int numberDifference = 8 - spaceNumberWords.Length;
                    string countOfZeros = new String('0', numberDifference);
                    updateOwnershipCmd.Parameters.AddWithValue("@PIN_Number", countOfZeros + txt_PIN_Number.Text);
                    updateOwnershipCmd.Parameters.AddWithValue("@owner_ship_Code",
                        spaceNumberWords[0].ToString() + "/" + txt_Ownership_Number.Text);
                }

                //********   Edit The  DropDownList  ***************************************************************************************************************
                updateOwnershipCmd.Parameters.AddWithValue("@owner_Owner_Id", Owner_DropDownList.SelectedValue);
                updateOwnershipCmd.Parameters.AddWithValue("@zone_zone_Id", Zone_Name_DropDownList.SelectedValue);

                //*******   Edit The  FileUpload   ****************************************************************************************************************
                if (Ownership_Certificate_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(Ownership_Certificate_FileUpload.PostedFile.FileName);
                    Ownership_Certificate_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/Ownership_Images/Ownership_Certificate/") +
                        fileName1);
                    updateOwnershipCmd.Parameters.AddWithValue("@owner_ship_Certificate_Image", fileName1);
                    updateOwnershipCmd.Parameters.AddWithValue("@owner_ship_Certificate_Image_Path",
                        "/English/Main_Application/Ownership_Images/Ownership_Certificate/" + fileName1);
                }
                else
                {
                    string fileName2 = Path.GetFileName(Ownership_Certificate_FileUpload.PostedFile.FileName);
                    updateOwnershipCmd.Parameters.AddWithValue("@owner_ship_Certificate_Image",
                        Ownership_Certificates_FileName.Text);
                    updateOwnershipCmd.Parameters.AddWithValue("@owner_ship_Certificate_Image_Path",
                        Ownership_Certificates_FilePath.Text);
                }

                // *************************************************************************************************************

                if (Property_Scheme_FileUpload.HasFile)
                {
                    string fileName3 = Path.GetFileName(Property_Scheme_FileUpload.PostedFile.FileName);
                    Property_Scheme_FileUpload.PostedFile.SaveAs(
                        Server.MapPath("/English/Main_Application/Ownership_Images/Property_Scheme/") + fileName3);
                    updateOwnershipCmd.Parameters.AddWithValue("@Property_Scheme_Image", fileName3);
                    updateOwnershipCmd.Parameters.AddWithValue("@Property_Scheme_Image_Path",
                        "/English/Main_Application/Ownership_Images/Property_Scheme/" + fileName3);
                }
                else
                {
                    string fileName4 = Path.GetFileName(Property_Scheme_FileUpload.PostedFile.FileName);
                    updateOwnershipCmd.Parameters.AddWithValue("@Property_Scheme_Image",
                        Property_Scheme_FileName.Text);
                    updateOwnershipCmd.Parameters.AddWithValue("@Property_Scheme_Image_Path",
                        Property_Scheme_FilePath.Text);
                }

                updateOwnershipCmd.ExecuteNonQuery();
                _sqlCon.Close();



                Edit_Arcived_Ownersip();


                lbl_Success_Add_New_Ownership.Text = "تم التعديل بنجاح";

                //****************************************************************************************************************
            }
        }

        protected void txt_PIN_Number_TextChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(txt_PIN_Number.Text);

            try
            {
                char[] pinNumber = txt_PIN_Number.Text.ToCharArray();
                if (pinNumber.Length == 7)
                {
                    string zoneNo = (pinNumber[0]).ToString();
                    _sqlCon.EnhancedOpen();
                    MySqlDataAdapter Check_Zone_NO_DA = new MySqlDataAdapter("Select * from zone where zone_number='" + zoneNo + "'", _sqlCon);
                    DataTable Check_Zone_NO_dt = new DataTable();
                    Check_Zone_NO_DA.Fill(Check_Zone_NO_dt);
                    if (Check_Zone_NO_dt.Rows.Count > 0)
                    {
                        Helper.LoadDropDownList("SELECT * FROM zone where zone_number = '" + zoneNo + "'", _sqlCon, Zone_Name_DropDownList, "zone_Arabic_name", "zone_Id");
                        Pin_No_Worrnig.Visible = false;
                    }
                    else
                    {
                        Helper.LoadDropDownList("SELECT * FROM zone", _sqlCon, Zone_Name_DropDownList, "zone_Arabic_name", "zone_Id");
                        Zone_Name_DropDownList.Items.Insert(0, "أختر إسم المنطقة ....");
                        Pin_No_Worrnig.Visible = true;
                        Pin_No_Worrnig.Text = "لم يتم إدراج منطقة لهذا الرقم المساحي ... أختر يدوياً إذا أردت";
                    }
                    _sqlCon.EnhancedClose();
                }
                else if (pinNumber.Length == 8)
                {
                    string zoneNo = (pinNumber[0]).ToString() + (pinNumber[1]).ToString();
                    _sqlCon.EnhancedOpen();
                    MySqlDataAdapter Check_Zone_NO_DA = new MySqlDataAdapter("Select * from zone where zone_number='" + zoneNo + "'", _sqlCon);
                    DataTable Check_Zone_NO_dt = new DataTable();
                    Check_Zone_NO_DA.Fill(Check_Zone_NO_dt);
                    if (Check_Zone_NO_dt.Rows.Count > 0)
                    {
                        Helper.LoadDropDownList("SELECT * FROM zone where zone_number = '" + zoneNo + "'", _sqlCon, Zone_Name_DropDownList, "zone_Arabic_name", "zone_Id");
                        Pin_No_Worrnig.Visible = false;
                    }
                    else
                    {
                        Helper.LoadDropDownList("SELECT * FROM zone", _sqlCon, Zone_Name_DropDownList, "zone_Arabic_name", "zone_Id");
                        Zone_Name_DropDownList.Items.Insert(0, "أختر إسم المنطقة ....");
                        Pin_No_Worrnig.Visible = true;
                        Pin_No_Worrnig.Text = "لم يتم إدراج منطقة لهذا الرقم المساحي ... أختر يدوياً إذا أردت";
                    }
                    _sqlCon.EnhancedClose();
                }
                else
                {
                    Helper.LoadDropDownList("SELECT * FROM zone", _sqlCon, Zone_Name_DropDownList, "zone_Arabic_name", "zone_Id");
                    Zone_Name_DropDownList.Items.Insert(0, "أختر إسم المنطقة ....");
                    Pin_No_Worrnig.Visible = true;
                    Pin_No_Worrnig.Text = "تأكد من صحة الرقم المساحي";
                }
            }
            catch
            {
                Response.Write(@"<script language='javascript'>alert('الرجاء التأكد من صحة الرقم المساحي')</script>");
            }
        }

        protected void Zone_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pin_No_Worrnig.Visible = false;
        }

        protected void btn_Back_To_OwnerShip_List_Click1(object sender, EventArgs e)
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

        protected void CheckBox_Appreciation_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_Appreciation.Checked == true)
            {
                CheckBox_octagon.Checked = false;
            }
        }

        protected void CheckBox_octagon_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_octagon.Checked == true)
            {
                CheckBox_Appreciation.Checked = false;
            }
        }

        protected void Remove_Ownership_Certificates_Click(object sender, EventArgs e)
        {
            string ownershipId = Request.QueryString["ID"];

            string updateOwnershipQuery =   "UPDATE owner_ship SET " +
                                            " owner_ship_Certificate_Image=@owner_ship_Certificate_Image ," +
                                            " owner_ship_Certificate_Image_Path=@owner_ship_Certificate_Image_Path  " +
                                            "WHERE Owner_Ship_Id=@ID";
            _sqlCon.Open();
            MySqlCommand updateOwnershipCmd = new MySqlCommand(updateOwnershipQuery, _sqlCon);
            updateOwnershipCmd.Parameters.AddWithValue("@ID", ownershipId);
            updateOwnershipCmd.Parameters.AddWithValue("@owner_ship_Certificate_Image", "No File");
            updateOwnershipCmd.Parameters.AddWithValue("@owner_ship_Certificate_Image_Path", "No File");
            updateOwnershipCmd.ExecuteNonQuery();
            _sqlCon.Close();

            Response.Redirect("Edit_Ownership.aspx?Id=" + ownershipId);
        }

        protected void Remove_Property_Scheme_Click(object sender, EventArgs e)
        {
            string ownershipId = Request.QueryString["ID"];

            string updateOwnershipQuery = "UPDATE owner_ship SET " +
                                            " Property_Scheme_Image=@Property_Scheme_Image ," +
                                            " Property_Scheme_Image_Path=@Property_Scheme_Image_Path  " +
                                            "WHERE Owner_Ship_Id=@ID";
            _sqlCon.Open();
            MySqlCommand updateOwnershipCmd = new MySqlCommand(updateOwnershipQuery, _sqlCon);
            updateOwnershipCmd.Parameters.AddWithValue("@ID", ownershipId);
            updateOwnershipCmd.Parameters.AddWithValue("@Property_Scheme_Image", "No File");
            updateOwnershipCmd.Parameters.AddWithValue("@Property_Scheme_Image_Path", "No File");
            updateOwnershipCmd.ExecuteNonQuery();
            _sqlCon.Close();

            Response.Redirect("Edit_Ownership.aspx?Id="+ ownershipId);
        }

        protected void btn_Back_To_OS_Lists_Click(object sender, EventArgs e)
        {
            Response.Redirect("lists.aspx");
        }

        protected void Delete_Ownership_Click(object sender, EventArgs e)
        {
            string ownershipId = Request.QueryString["ID"];

            try
            {
                _sqlCon.Open();
                string deleteOwnershipQuary = "DELETE FROM owner_ship WHERE Owner_Ship_Id=@ID ";
                MySqlCommand mySqlCmd = new MySqlCommand(deleteOwnershipQuary, _sqlCon);
                mySqlCmd.Parameters.AddWithValue("@ID", ownershipId);
                mySqlCmd.ExecuteNonQuery();



                string addArciveOwnershipQuary = "Insert Into delete_archive " +
                                                            "(User_Id," +
                                                            "Delete_Date," +
                                                            "OS_B_U," +
                                                            "Item_Id," +
                                                            "Reason_Delete) " +
                                                            "VALUES" +
                                                            "(@User_Id," +
                                                            "@Delete_Date," +
                                                            "@OS_B_U," +
                                                            "@Item_Id," +
                                                            "@Reason_Delete)";
                MySqlCommand addArciveOwnershipCmd = new MySqlCommand(addArciveOwnershipQuary, _sqlCon);
                addArciveOwnershipCmd.Parameters.AddWithValue("@User_Id", Session["user_ID"].ToString());
                addArciveOwnershipCmd.Parameters.AddWithValue("@Delete_Date", DateTime.Now.ToString("dd/MM/yyyy"));
                addArciveOwnershipCmd.Parameters.AddWithValue("@OS_B_U", "OS");
                addArciveOwnershipCmd.Parameters.AddWithValue("@Item_Id", ownershipId);
                addArciveOwnershipCmd.Parameters.AddWithValue("@Reason_Delete", txt_Reason_Delete.Text);
                addArciveOwnershipCmd.ExecuteNonQuery();


                Response.Redirect("Ownership_List.aspx");
            }
            catch
            {
                Response.Write(@"<script language='javascript'>alert('لا يمكن حذف هذه الملكية لنها تحتوي على أبنية و وحدات')</script>");
            };
            _sqlCon.Close();
        }

        protected void Statment()
        {
            string getStatmentQuari = "SELECT * FROM ownership_statment where Ownership_Id = '" + Request.QueryString["ID"] +"'";
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
        protected void btn_Add_Statment_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            string addStatmentQuary = "Insert Into ownership_statment " +
                                        "(Ownership_Id," +
                                        "Statment_FileName," +
                                        "Statment_Path," +
                                        " Statment_Date) " +
                                        "VALUES" +
                                        "(@Ownership_Id," +
                                        "@Statment_FileName," +
                                        "@Statment_Path," +
                                        "@Statment_Date) ";

            _sqlCon.Open();
            using (MySqlCommand addStatmentCmd = new MySqlCommand(addStatmentQuary, _sqlCon))
            {
                addStatmentCmd.Parameters.AddWithValue("@Ownership_Id", Request.QueryString["ID"]);
                addStatmentCmd.Parameters.AddWithValue("@Statment_Date", txt_Statment_Date.Text);
                

               
                string fileName = Path.GetFileName(Statment_FileUpload.PostedFile.FileName);
                Statment_FileUpload.PostedFile.SaveAs(Server.MapPath("/English/Main_Application/Ownership_Images/Statment/") + fileName);
                addStatmentCmd.Parameters.AddWithValue("@Statment_FileName", fileName);
                addStatmentCmd.Parameters.AddWithValue("@Statment_Path", "/English/Main_Application/Ownership_Images/Statment/" + fileName);
               

                addStatmentCmd.ExecuteNonQuery();
                _sqlCon.Close();
            }

            Statment();
        }

        protected void Statment_delete_Click(object sender, EventArgs e)
        {
            try
            {
                string StatmentRowId = (sender as LinkButton).CommandArgument;
                _sqlCon.Open();
                string deleteStatmentQuary = "DELETE FROM ownership_statment WHERE Statment_Id=@ID ";
                MySqlCommand mySqlCmd = new MySqlCommand(deleteStatmentQuary, _sqlCon);
                mySqlCmd.Parameters.AddWithValue("@ID", StatmentRowId);
                mySqlCmd.ExecuteNonQuery();
                _sqlCon.Close();
                Response.Redirect(Request.RawUrl);
            }
            catch
            {
                Response.Write(
                    @"<script language='javascript'>alert('لا يمكن حذف هذه اللإفادة')</script>");
            };
        }


        protected void Edit_Arcived_Ownersip()
        {
            string ownershipId = Request.QueryString["ID"];
            string updateOwnershipQuery = "UPDATE arcive_ownership SET " +
                                                "Owner_Ship_EN_Name=@Owner_Ship_EN_Name , " +
                                                "Owner_Ship_AR_Name=@Owner_Ship_AR_Name , " +
                                                "ownership_NO=@ownership_NO," +
                                                "Parcel_Area=@Parcel_Area , " +
                                                "Bond_NO=@Bond_NO," +
                                                "Bond_Date=@Bond_Date," +
                                                "Street_NO=@Street_NO," +
                                                "Street_Name=@Street_Name," +
                                                "Land_Value=@Land_Value , " +

                                                "Appreciation_octagon=@Appreciation_octagon , " +

                                                "PIN_Number=@PIN_Number , " +
                                                "owner_ship_Code=@owner_ship_Code , " +
                                                "Mab_Url=@Mab_Url , " +
                                                "owner_Owner_Id=@owner_Owner_Id , " +
                                                "zone_zone_Id=@zone_zone_Id, " +
                                                "owner_ship_Certificate_Image=@owner_ship_Certificate_Image , " +
                                                "owner_ship_Certificate_Image_Path=@owner_ship_Certificate_Image_Path , " +
                                                "Property_Scheme_Image=@Property_Scheme_Image , " +
                                                "Property_Scheme_Image_Path=@Property_Scheme_Image_Path  " +
                                                "WHERE Owner_Ship_Id=@ID ";

            _sqlCon.Open();
            MySqlCommand updateOwnershipCmd = new MySqlCommand(updateOwnershipQuery, _sqlCon);

            // Edit The  Textboxs
            updateOwnershipCmd.Parameters.AddWithValue("@ID", ownershipId);
            updateOwnershipCmd.Parameters.AddWithValue("@Owner_Ship_EN_Name", txt_En_Ownership_Name.Text);
            updateOwnershipCmd.Parameters.AddWithValue("@Owner_Ship_AR_Name", txt_Ar_Ownership_Name.Text);
            updateOwnershipCmd.Parameters.AddWithValue("@ownership_NO", txt_Ownership_Number.Text);
            updateOwnershipCmd.Parameters.AddWithValue("@Parcel_Area", txt_Parcel_Area.Text);
            updateOwnershipCmd.Parameters.AddWithValue("@Bond_NO", txt_Bond_No.Text);
            updateOwnershipCmd.Parameters.AddWithValue("@Bond_Date", txt_bond_Date.Text);
            updateOwnershipCmd.Parameters.AddWithValue("@Street_NO", txt_Street_No.Text);
            updateOwnershipCmd.Parameters.AddWithValue("@Street_Name", txt_Street_Name.Text);
            updateOwnershipCmd.Parameters.AddWithValue("@Land_Value", txt_Lande_Value.Text);
            if (txt_Map_Url.Text == "")
            {
                updateOwnershipCmd.Parameters.AddWithValue("@Mab_Url", "No File");
            }
            else
            {
                updateOwnershipCmd.Parameters.AddWithValue("@Mab_Url", txt_Map_Url.Text);
            }

            //***************************** Appreciation_octagon ************************************************
            if (CheckBox_Appreciation.Checked == true)
            {
                updateOwnershipCmd.Parameters.AddWithValue("@Appreciation_octagon", "تقديري");
            }
            else if (CheckBox_octagon.Checked == true)
            {
                updateOwnershipCmd.Parameters.AddWithValue("@Appreciation_octagon", "مثمن");
            }
            else
            {
                updateOwnershipCmd.Parameters.AddWithValue("@Appreciation_octagon", " ");
            }
            //***************************************************************************************************

            char[] spaceNumberWords = txt_PIN_Number.Text.ToCharArray();
            if (spaceNumberWords.Length == 8)
            {
                updateOwnershipCmd.Parameters.AddWithValue("@PIN_Number", txt_PIN_Number.Text);
                updateOwnershipCmd.Parameters.AddWithValue("@owner_ship_Code", spaceNumberWords[0].ToString() + spaceNumberWords[1].ToString() + "/" +
                    txt_Ownership_Number.Text);
            }
            else
            {
                int numberDifference = 8 - spaceNumberWords.Length;
                string countOfZeros = new String('0', numberDifference);
                updateOwnershipCmd.Parameters.AddWithValue("@PIN_Number", countOfZeros + txt_PIN_Number.Text);
                updateOwnershipCmd.Parameters.AddWithValue("@owner_ship_Code",
                    spaceNumberWords[0].ToString() + "/" + txt_Ownership_Number.Text);
            }

            //********   Edit The  DropDownList  ***************************************************************************************************************
            updateOwnershipCmd.Parameters.AddWithValue("@owner_Owner_Id", Owner_DropDownList.SelectedValue);
            updateOwnershipCmd.Parameters.AddWithValue("@zone_zone_Id", Zone_Name_DropDownList.SelectedValue);

            //*******   Edit The  FileUpload   ****************************************************************************************************************
            if (Ownership_Certificate_FileUpload.HasFile)
            {
                string fileName1 = Path.GetFileName(Ownership_Certificate_FileUpload.PostedFile.FileName);
                Ownership_Certificate_FileUpload.PostedFile.SaveAs(
                    Server.MapPath("/English/Main_Application/Ownership_Images/Ownership_Certificate/") +
                    fileName1);
                updateOwnershipCmd.Parameters.AddWithValue("@owner_ship_Certificate_Image", fileName1);
                updateOwnershipCmd.Parameters.AddWithValue("@owner_ship_Certificate_Image_Path",
                    "/English/Main_Application/Ownership_Images/Ownership_Certificate/" + fileName1);
            }
            else
            {
                string fileName2 = Path.GetFileName(Ownership_Certificate_FileUpload.PostedFile.FileName);
                updateOwnershipCmd.Parameters.AddWithValue("@owner_ship_Certificate_Image",
                    Ownership_Certificates_FileName.Text);
                updateOwnershipCmd.Parameters.AddWithValue("@owner_ship_Certificate_Image_Path",
                    Ownership_Certificates_FilePath.Text);
            }

            // *************************************************************************************************************

            if (Property_Scheme_FileUpload.HasFile)
            {
                string fileName3 = Path.GetFileName(Property_Scheme_FileUpload.PostedFile.FileName);
                Property_Scheme_FileUpload.PostedFile.SaveAs(
                    Server.MapPath("/English/Main_Application/Ownership_Images/Property_Scheme/") + fileName3);
                updateOwnershipCmd.Parameters.AddWithValue("@Property_Scheme_Image", fileName3);
                updateOwnershipCmd.Parameters.AddWithValue("@Property_Scheme_Image_Path",
                    "/English/Main_Application/Ownership_Images/Property_Scheme/" + fileName3);
            }
            else
            {
                string fileName4 = Path.GetFileName(Property_Scheme_FileUpload.PostedFile.FileName);
                updateOwnershipCmd.Parameters.AddWithValue("@Property_Scheme_Image",
                    Property_Scheme_FileName.Text);
                updateOwnershipCmd.Parameters.AddWithValue("@Property_Scheme_Image_Path",
                    Property_Scheme_FilePath.Text);
            }

            updateOwnershipCmd.ExecuteNonQuery();
            _sqlCon.Close();
        }

        protected void Statment_List_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            foreach (RepeaterItem ri in Statment_List.Items)
            {
                _sqlCon.Close();
                LinkButton Statment_delete = ri.FindControl("Statment_delete") as LinkButton;
                Utilities.Roles.Delete_permission(_sqlCon, Session["Role"].ToString(), "properties", Statment_delete);
            }
        }
    }
}