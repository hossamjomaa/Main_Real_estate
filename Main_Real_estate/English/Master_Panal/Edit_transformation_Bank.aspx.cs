using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Edit_transformation_Bank : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "", "window.onload=function(){window.scrollTo(0,document.body.scrollHeight)};", true);
            if (!Page.IsPostBack)
            {

                //Get Ar_Bank_Name_DropDownList
                Helper.LoadDropDownList("SELECT * FROM bank", _sqlCon, Ar_Bank_Name_DropDownList, "Bank_Arabic_Name", "Bank_Id");
                Ar_Bank_Name_DropDownList.Items.Insert(0, "إختر اسم البنك ....");

                //Get En_Bank_Name_DropDownList
                Helper.LoadDropDownList("SELECT * FROM bank", _sqlCon, En_Bank_Name_DropDownList, "Bank_English_Name", "Bank_Id");
                En_Bank_Name_DropDownList.Items.Insert(0, "Choose the name of the bank ....");










                string bankId = Request.QueryString["Id"];
                DataTable getBankDt = new DataTable();
                _sqlCon.Open();
                MySqlCommand getBankCmd =
                    new MySqlCommand(
                        "SELECT *  FROM transformation_bank WHERE transformation_Bank_ID = @ID", _sqlCon);
                MySqlDataAdapter getBankDa = new MySqlDataAdapter(getBankCmd);

                getBankCmd.Parameters.AddWithValue("@ID", bankId);
                getBankDa.Fill(getBankDt);
                if (getBankDt.Rows.Count > 0)
                {
                    txt_Ar_Bank_NO.Text = getBankDt.Rows[0]["Bank_No"].ToString();
                    txt_En_Bank_NO.Text = getBankDt.Rows[0]["Bank_No_En"].ToString();

                    Ar_Bank_Name_DropDownList.SelectedValue = getBankDt.Rows[0]["Bank_Id"].ToString();
                    En_Bank_Name_DropDownList.SelectedValue = getBankDt.Rows[0]["Bank_Id"].ToString();

                    txt_Ar_IBAN_Number.Text = getBankDt.Rows[0]["Account_No"].ToString();
                    txt_En_IBAN_Number.Text = getBankDt.Rows[0]["Account_No_En"].ToString();

                    txt_Ar_Swift_Code.Text = getBankDt.Rows[0]["Soaft_Code_No"].ToString();
                    txt_En_Swift_Code.Text = getBankDt.Rows[0]["Soaft_Code_No_En"].ToString();

                    txt_Ar_Bank_Address.Text = getBankDt.Rows[0]["Bank_Adress"].ToString();
                    txt_En_Bank_Address.Text = getBankDt.Rows[0]["Bank_Adress_En"].ToString();

                    txt_Ar_Curacy.Text = getBankDt.Rows[0]["currency_type"].ToString();
                    txt_En_Curacy.Text = getBankDt.Rows[0]["currency_type_En"].ToString();

                    txt_Ar_Beneficiary_Name.Text = getBankDt.Rows[0]["Beneficiary_Name"].ToString();
                    txt_En_Beneficiary_Name.Text = getBankDt.Rows[0]["Beneficiary_Name_En"].ToString();

                }

                _sqlCon.Close();
            }
        }

        protected void btn_Edit_Bank_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string bankId = Request.QueryString["Id"];
                string updateBankQuary =
                    "UPDATE transformation_bank SET " +
                    "Bank_Id=@Bank_Id ," +
                    "Bank_No=@Bank_No ," +
                    "Bank_No_En=@Bank_No_En ," +

                    "Bank_Name=@Bank_Name ," +
                    "Bank_Name_En=@Bank_Name_En ," +

                    "Account_No=@Account_No ," +
                    "Account_No_En=@Account_No_En ," +

                    "Soaft_Code_No=@Soaft_Code_No ," +
                    "Soaft_Code_No_En=@Soaft_Code_No_En ," +

                    "Bank_Adress=@Bank_Adress ," +
                    "Bank_Adress_En=@Bank_Adress_En ," +

                    "currency_type=@currency_type ," +
                    "currency_type_En=@currency_type_En ," +

                    "Beneficiary_Name=@Beneficiary_Name ," +
                    " Beneficiary_Name_En=@Beneficiary_Name_En " +
                    " WHERE transformation_Bank_ID=@ID ";


                _sqlCon.Open();
                MySqlCommand EditBankCmd = new MySqlCommand(updateBankQuary, _sqlCon);

                EditBankCmd.Parameters.AddWithValue("@ID", bankId);

                EditBankCmd.Parameters.AddWithValue("@Bank_Id", Ar_Bank_Name_DropDownList.SelectedValue);
                EditBankCmd.Parameters.AddWithValue("@Bank_No", txt_Ar_Bank_NO.Text);
                EditBankCmd.Parameters.AddWithValue("@Bank_No_En", txt_En_Bank_NO.Text);

                EditBankCmd.Parameters.AddWithValue("@Bank_Name", Ar_Bank_Name_DropDownList.SelectedItem.Text);
                EditBankCmd.Parameters.AddWithValue("@Bank_Name_En", En_Bank_Name_DropDownList.SelectedItem.Text);

                EditBankCmd.Parameters.AddWithValue("@Account_No", txt_Ar_IBAN_Number.Text);
                EditBankCmd.Parameters.AddWithValue("@Account_No_En", txt_En_IBAN_Number.Text);

                EditBankCmd.Parameters.AddWithValue("@Soaft_Code_No", txt_Ar_Swift_Code.Text);
                EditBankCmd.Parameters.AddWithValue("@Soaft_Code_No_En", txt_En_Swift_Code.Text);

                EditBankCmd.Parameters.AddWithValue("@Bank_Adress", txt_Ar_Bank_Address.Text);
                EditBankCmd.Parameters.AddWithValue("@Bank_Adress_En", txt_En_Bank_Address.Text);

                EditBankCmd.Parameters.AddWithValue("@currency_type", txt_Ar_Curacy.Text);
                EditBankCmd.Parameters.AddWithValue("@currency_type_En", txt_En_Curacy.Text);

                EditBankCmd.Parameters.AddWithValue("@Beneficiary_Name", txt_Ar_Beneficiary_Name.Text);
                EditBankCmd.Parameters.AddWithValue("@Beneficiary_Name_En", txt_En_Beneficiary_Name.Text);

                EditBankCmd.ExecuteNonQuery();
                _sqlCon.Close();
                //Response.Redirect("transformation_Bank_List.aspx");
            }
        }

        protected void btn_Back_To_Bank_List_Click(object sender, EventArgs e)
        {
            Response.Redirect("transformation_Bank_List.aspx");
        }


        protected void Ar_Bank_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            En_Bank_Name_DropDownList.SelectedValue = Ar_Bank_Name_DropDownList.SelectedValue;
        }

        protected void En_Bank_Name_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ar_Bank_Name_DropDownList.SelectedValue = En_Bank_Name_DropDownList.SelectedValue;
        }

        protected void txt_Ar_Bank_NO_TextChanged(object sender, EventArgs e)
        {
            txt_En_Bank_NO.Text = txt_Ar_Bank_NO.Text.Trim();
        }

        protected void txt_En_Bank_NO_TextChanged(object sender, EventArgs e)
        {
            txt_Ar_Bank_NO.Text = txt_En_Bank_NO.Text.Trim();
        }

        protected void txt_Ar_IBAN_Number_TextChanged(object sender, EventArgs e)
        {
            txt_En_IBAN_Number.Text = txt_Ar_IBAN_Number.Text.Trim();
        }

        protected void txt_En_IBAN_Number_TextChanged(object sender, EventArgs e)
        {
            txt_Ar_IBAN_Number.Text = txt_En_IBAN_Number.Text.Trim();
        }

        protected void txt_Ar_Swift_Code_TextChanged(object sender, EventArgs e)
        {
            txt_En_Swift_Code.Text = txt_Ar_Swift_Code.Text.Trim();
        }

        protected void txt_En_Swift_Code_TextChanged(object sender, EventArgs e)
        {
            txt_Ar_Swift_Code.Text = txt_En_Swift_Code.Text.Trim();
        }
    }
}