using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.EnterpriseServices;
using System.IO;
using System.Security.Cryptography;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Contact_With_Tenant : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Utilities.Roles.Singel_Page_permission(_sqlCon, Session["Role"].ToString(), "Customer_Affairs", 0, "R");
            }
            catch { Response.Redirect("Log_In.aspx"); }
            
            if (!this.IsPostBack)
            {
                //Fill Tenant _Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM tenants", _sqlCon, Tenan_DropDownList, "Tenants_Arabic_Name", "Tenants_ID");
                Tenan_DropDownList.Items.Insert(0, "...... كل المستأجرين........");

                Type_DropDownList.Items.Insert(0, "...... الكل........");




                //Fill Tenant _Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM tenants", _sqlCon, Tenant_Name_DropDownList, "Tenants_Arabic_Name", "Tenants_ID");
                Tenant_Name_DropDownList.Items.Insert(0, "...... كل المستأجرين........");

                //    //Fill Building Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM building Where Active ='1'", _sqlCon, Building_Name_DropDownList, "Building_Arabic_Name", "Building_Id");
                Building_Name_DropDownList.Items.Insert(0, "إختر البناء ....");

                //    //Fill Building Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM building Where Active ='1'", _sqlCon, Att_Building_Name_DropDownList, "Building_Arabic_Name", "Building_Id");
                Att_Building_Name_DropDownList.Items.Insert(0, "إختر البناء ....");

                //Fill Tenant _Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM tenants", _sqlCon, Att_Tenant_Name_DropDownList, "Tenants_Arabic_Name", "Tenants_ID");
                Att_Tenant_Name_DropDownList.Items.Insert(0, "...... كل المستأجرين........");


                //Fill Tenant _Name DropDownList
                Helper.LoadDropDownList("SELECT * FROM tenants", _sqlCon, DropDownList1, "Tenants_Arabic_Name", "Tenants_Mobile");
                DropDownList1.Items.Insert(0, "...... كل المستأجرين........");


                DataTable Ch_Dt = new DataTable();
                Ch_Dt.Columns.AddRange(new DataColumn[2]
                {
                    new DataColumn("tenant_Name"),
                    new DataColumn("ID"),
                });
                ViewState["Cash_Customers"] = Ch_Dt;
                this.BindGrid();


                Tenant_List_BindData();


            }
        }

        private void BindGrid()
        {
            Cheque_GridView.DataSource = (DataTable)ViewState["Cash_Customers"];
            Cheque_GridView.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt1 = (DataTable)ViewState["Cash_Customers"];
            dt1.Rows.Add
            (
                DropDownList1.SelectedItem.Text.Trim(),
                DropDownList1.SelectedValue
            );
            ViewState["Cash_Customers"] = dt1;
            this.BindGrid();
        }

        protected void Cheque_GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = ViewState["Cash_Customers"] as DataTable;
            dt.Rows[index].Delete();
            ViewState["Cash_Customers"] = dt;
            BindGrid();
        }



        protected void btn_Send_Sms_Click(object sender, EventArgs e)
        {
            lbl_Send_Sussefilly.Text = "تم الإرسال لجميع العملاء بنجاح";
            if (Level_DropDownList.SelectedValue == "1")
            {
                string tenantListQuery = "SELECT Tenants_ID , Tenants_Mobile From tenants";
                MySqlCommand tenantListCmd = new MySqlCommand(tenantListQuery, _sqlCon);
                MySqlDataAdapter tenantListDt = new MySqlDataAdapter(tenantListCmd);
                tenantListCmd.Connection = _sqlCon;
                _sqlCon.Open();
                tenantListDt.SelectCommand = tenantListCmd;
                DataTable tenantListDataTable = new DataTable();
                tenantListDt.Fill(tenantListDataTable);
                for (int i = 0;i < tenantListDataTable.Rows.Count; i++)
                {
                    Utilities.Helper.SendSms(tenantListDataTable.Rows[i]["Tenants_Mobile"].ToString(),txt_tenant_Sms.Text);
                }
                
                _sqlCon.Close();
                // ******************  Get User Name *****************************************************************************

                string UserNameQuery = "SELECT Users_Ar_First_Name  From users Where user_ID = '"+ Session["user_ID"].ToString() + "'";
                MySqlCommand UserNameCmd = new MySqlCommand(UserNameQuery, _sqlCon);
                MySqlDataAdapter UserNameDt = new MySqlDataAdapter(UserNameCmd);
                UserNameCmd.Connection = _sqlCon;
                _sqlCon.Open();
                UserNameDt.SelectCommand = UserNameCmd;
                DataTable UserNameDataTable = new DataTable();
                UserNameDt.Fill(UserNameDataTable);
                _sqlCon.Close();






                string addSMSQuary =
                   "Insert Into tenant_sending (" +
                   "Level , " +
                   "Type , " +
                   "Mounth , " +
                   "Year , " +
                   "User_Name , " +
                   "SMS) " +
                   "VALUES(" +
                   "@Level , " +
                   "@Type , " +
                   "@Mounth , " +
                   "@Year , " +
                   "@User_Name , " +
                   "@SMS)";
                _sqlCon.Open();
                MySqlCommand addSMSCmd = new MySqlCommand(addSMSQuary, _sqlCon);
                addSMSCmd.Parameters.AddWithValue("@Level", "جميع العملاء");
                addSMSCmd.Parameters.AddWithValue("@Type", "رسالة SMS");
                addSMSCmd.Parameters.AddWithValue("@Mounth", DateTime.Now.Month.ToString());
                addSMSCmd.Parameters.AddWithValue("@Year", DateTime.Now.Year.ToString());
                addSMSCmd.Parameters.AddWithValue("@User_Name", UserNameDataTable.Rows[0]["Users_Ar_First_Name"].ToString());
                addSMSCmd.Parameters.AddWithValue("@SMS", txt_tenant_Sms.Text);
                addSMSCmd.ExecuteNonQuery();
                _sqlCon.Close();

            }
            else if (Level_DropDownList.SelectedValue == "3")
            {
                Utilities.Helper.SendSms(txt_tenant_NO.Text, txt_tenant_Sms.Text);
                lbl_Send_Sussefilly.Text = "تم الإرسال للعميل بنجاح";



                string UserNameQuery = "SELECT Users_Ar_First_Name  From users Where user_ID = '" + Session["user_ID"].ToString() + "'";
                MySqlCommand UserNameCmd = new MySqlCommand(UserNameQuery, _sqlCon);
                MySqlDataAdapter UserNameDt = new MySqlDataAdapter(UserNameCmd);
                UserNameCmd.Connection = _sqlCon;
                _sqlCon.Open();
                UserNameDt.SelectCommand = UserNameCmd;
                DataTable UserNameDataTable = new DataTable();
                UserNameDt.Fill(UserNameDataTable);
                _sqlCon.Close();




                string addSMSQuary =
                   "Insert Into tenant_sending (" +
                   "Level , " +
                   "Type , " +
                   "Mounth , " +
                   "Year , " +
                   "User_Name , " +
                   "Tenant_Tenant_Id , " +
                   "SMS ) " +
                   "VALUES(" +
                   "@Level , " +
                   "@Type , " +
                   "@Mounth , " +
                   "@Year , " +
                   "@User_Name , " +
                   "@Tenant_Tenant_Id , " +
                   "@SMS)";
                _sqlCon.Open();
                MySqlCommand addSMSCmd = new MySqlCommand(addSMSQuary, _sqlCon);
                addSMSCmd.Parameters.AddWithValue("@Level", "عميل محدد");
                addSMSCmd.Parameters.AddWithValue("@Type", "رسالة SMS");
                addSMSCmd.Parameters.AddWithValue("@Mounth", DateTime.Now.Month.ToString());
                addSMSCmd.Parameters.AddWithValue("@Year", DateTime.Now.Year.ToString());
                addSMSCmd.Parameters.AddWithValue("@User_Name", UserNameDataTable.Rows[0]["Users_Ar_First_Name"].ToString());
                addSMSCmd.Parameters.AddWithValue("@Tenant_Tenant_Id", Tenant_Name_DropDownList.SelectedValue);
                addSMSCmd.Parameters.AddWithValue("@SMS", txt_tenant_Sms.Text);
                addSMSCmd.ExecuteNonQuery();
                _sqlCon.Close();
            }
            else  if (Level_DropDownList.SelectedValue == "4")
            {
                foreach (GridViewRow g1 in Cheque_GridView.Rows)
                {
                    Utilities.Helper.SendSms(g1.Cells[1].Text, txt_tenant_Sms.Text);
                }
                string UserNameQuery = "SELECT Users_Ar_First_Name  From users Where user_ID = '" + Session["user_ID"].ToString() + "'";
                MySqlCommand UserNameCmd = new MySqlCommand(UserNameQuery, _sqlCon);
                MySqlDataAdapter UserNameDt = new MySqlDataAdapter(UserNameCmd);
                UserNameCmd.Connection = _sqlCon;
                _sqlCon.Open();
                UserNameDt.SelectCommand = UserNameCmd;
                DataTable UserNameDataTable = new DataTable();
                UserNameDt.Fill(UserNameDataTable);
                _sqlCon.Close();

                string addSMSQuary =
                  "Insert Into tenant_sending (" +
                  "Level , " +
                  "Type , " +
                  "Mounth , " +
                  "Year , " +
                  "User_Name , " +
                  "SMS ) " +
                  "VALUES(" +
                  "@Level , " +
                  "@Type , " +
                  "@Mounth , " +
                  "@Year , " +
                  "@User_Name , " +
                  "@SMS)";
                _sqlCon.Open();
                MySqlCommand addSMSCmd = new MySqlCommand(addSMSQuary, _sqlCon);
                addSMSCmd.Parameters.AddWithValue("@Level", "مجموعة محددة من العملاء");
                addSMSCmd.Parameters.AddWithValue("@Type", "رسالة SMS");
                addSMSCmd.Parameters.AddWithValue("@Mounth", DateTime.Now.Month.ToString());
                addSMSCmd.Parameters.AddWithValue("@Year", DateTime.Now.Year.ToString());
                addSMSCmd.Parameters.AddWithValue("@User_Name", UserNameDataTable.Rows[0]["Users_Ar_First_Name"].ToString());
                addSMSCmd.Parameters.AddWithValue("@SMS", txt_tenant_Sms.Text);
                addSMSCmd.ExecuteNonQuery();
                _sqlCon.Close();


            }
                Response.Redirect(Request.RawUrl);
        }

        protected void btn_Att_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string Level = ""; string Type = ""; string Tenant_Tenant_Id ="";

                if (Att_Level_DropDownList.SelectedValue == "1")
                {
                    Level = "كافة العملاء";
                    Type = "مرفق";
                    Tenant_Tenant_Id = ""; 
                    
                }
                else if (Att_Level_DropDownList.SelectedValue == "2")
                {
                    Level = "عملاء في بناء محدد";
                    Type = "مرفق";
                    Tenant_Tenant_Id = "";
                }
                else
                {
                    Level = "عميل محدد";
                    Type = "مرفق";
                    Tenant_Tenant_Id = Tenant_Name_DropDownList.SelectedValue;
                }








                string UserNameQuery = "SELECT Users_Ar_First_Name  From users Where user_ID = '" + Session["user_ID"].ToString() + "'";
                MySqlCommand UserNameCmd = new MySqlCommand(UserNameQuery, _sqlCon);
                MySqlDataAdapter UserNameDt = new MySqlDataAdapter(UserNameCmd);
                UserNameCmd.Connection = _sqlCon;
                _sqlCon.Open();
                UserNameDt.SelectCommand = UserNameCmd;
                DataTable UserNameDataTable = new DataTable();
                UserNameDt.Fill(UserNameDataTable);
                _sqlCon.Close();


                string addAttQuary =
                   "Insert Into tenant_sending (" +
                   "Level , " +
                   "Type , " +
                   "Mounth , " +
                   "Year , " +
                   "User_Name , " +
                   "Tenant_Tenant_Id , " +
                   "Attatchment_File_Name , " +
                   "Attatchment_File_Path , " +
                   "Discription) " +
                   "VALUES(" +
                   "@Level , " +
                   "@Type , " +
                   "@Mounth , " +
                   "@Year , " +
                   "@User_Name , " +
                   "@Tenant_Tenant_Id , " +
                   "@Attatchment_File_Name , " +
                   "@Attatchment_File_Path , " +
                   "@Discription)";
                _sqlCon.Open();
                MySqlCommand addAttCmd = new MySqlCommand(addAttQuary, _sqlCon);
                addAttCmd.Parameters.AddWithValue("@Level", Level);
                addAttCmd.Parameters.AddWithValue("@Type", Type);
                addAttCmd.Parameters.AddWithValue("@Mounth", DateTime.Now.Month.ToString());
                addAttCmd.Parameters.AddWithValue("@Year", DateTime.Now.Year.ToString());
                addAttCmd.Parameters.AddWithValue("@User_Name", UserNameDataTable.Rows[0]["Users_Ar_First_Name"].ToString());
                addAttCmd.Parameters.AddWithValue("@Tenant_Tenant_Id", Tenant_Tenant_Id);
                addAttCmd.Parameters.AddWithValue("@Discription", txt_Att_Discription.Text);

                if (Att_FileUpload.HasFile)
                {
                    string fileName1 = Path.GetFileName(Att_FileUpload.PostedFile.FileName);
                    Att_FileUpload.PostedFile.SaveAs(Server.MapPath("/English/Main_Application/Tenant_Att/") + fileName1);
                    addAttCmd.Parameters.AddWithValue("@Attatchment_File_Name", fileName1);
                    addAttCmd.Parameters.AddWithValue("@Attatchment_File_Path", "/English/Main_Application/Tenant_Att/" + fileName1);
                }
                else
                {
                    addAttCmd.Parameters.AddWithValue("@Attatchment_File_Name", "No File");
                    addAttCmd.Parameters.AddWithValue("@Attatchment_File_Path", "No File");
                }
                addAttCmd.ExecuteNonQuery();
                _sqlCon.Close();





            }
            Response.Redirect(Request.RawUrl);
        }

        protected void Tenant_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable getSMS_NODt = new DataTable();
            _sqlCon.Open();
            MySqlCommand getSMS_NOCmd = new MySqlCommand("SELECT Tenants_Mobile FROM tenants WHERE Tenants_ID = @ID", _sqlCon);
            MySqlDataAdapter getSMS_NODa = new MySqlDataAdapter(getSMS_NOCmd);
            getSMS_NOCmd.Parameters.AddWithValue("@ID", Tenant_Name_DropDownList.SelectedValue);
            getSMS_NODa.Fill(getSMS_NODt);
            if (getSMS_NODt.Rows.Count > 0)
            {
                txt_tenant_NO.Text = getSMS_NODt.Rows[0]["Tenants_Mobile"].ToString();
            }

            _sqlCon.Close();
        }





        protected void Tenant_List_BindData()
        {
            string Tenant = ""; string Type = "";
            if (Tenan_DropDownList.SelectedItem.Text != "...... كل المستأجرين........") { Tenant = " and TS.Tenant_Tenant_Id = " + Tenan_DropDownList.SelectedValue; } else { Tenant = ""; }
            if (Type_DropDownList.SelectedItem.Text != "...... الكل........") { Type = " and TS.Type = '" + Type_DropDownList.SelectedItem.Text.Trim() + "'"; } else { Type = ""; }

            string tenantListQuery = "SELECT TS.* , T.* " +
                                     "FROM tenant_sending TS " +
                                     "left join  tenants T on (TS.Tenant_Tenant_Id = T.Tenants_ID)  " +
                                     "where TS.Tenant_Sending_Id > 0  " + Tenant + "  " + Type + "    ";



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

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void Level_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Level_DropDownList.SelectedValue == "1")
            {
                Building_div.Visible=false; Tenant_div.Visible= false; Tenant_NO_div.Visible= false; Div1.Visible = false;
            }
            else if (Level_DropDownList.SelectedValue == "2")
            {
                Building_div.Visible = true; Tenant_div.Visible = false; Tenant_NO_div.Visible = false; Div1.Visible = false;
            }
            else  if (Level_DropDownList.SelectedValue == "3")
            {
                Building_div.Visible = false; Tenant_div.Visible = true; Tenant_NO_div.Visible = true; Div1.Visible = false;
            }
            else
            {
                Building_div.Visible = false; Tenant_div.Visible = false; Tenant_NO_div.Visible = false; Div1.Visible = true;
            }
        }

        protected void Att_Level_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Att_Level_DropDownList.SelectedValue == "1")
            {
                Att_Building_div.Visible = false; Att_Tenant_div.Visible = false; 
            }
            else if (Att_Level_DropDownList.SelectedValue == "2")
            {
                Att_Building_div.Visible = true; Att_Tenant_div.Visible = false;
            }
            else
            {
                Att_Building_div.Visible = false; Att_Tenant_div.Visible = true; 
            }
        }

        protected void Tenan_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tenant_List_BindData();
        }

        protected void Type_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tenant_List_BindData();
        }
    }
}