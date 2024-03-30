﻿using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Owner_List : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            try  { Helper.GetDataReader("SELECT * FROM owner", _sqlCon, The_Table); }
            catch {  Response.Write(@"<script language='javascript'>alert('لا يمكن عرض هذه الصفحة')</script>"); };
        }


        protected void Delete(object sender, EventArgs e)
        {
            try
            {
                string id = (sender as LinkButton).CommandArgument;
                _sqlCon.Open();
                string quary1 = "DELETE FROM owner WHERE Owner_Id=@ID ";
                MySqlCommand mySqlCmd = new MySqlCommand(quary1, _sqlCon);
                mySqlCmd.Parameters.AddWithValue("@ID", id);
                mySqlCmd.ExecuteNonQuery();
                _sqlCon.Close();
                Response.Redirect(Request.RawUrl);
            }
            catch
            {
                Response.Write(  @"<script language='javascript'>alert('This Owner cannot be deleted because he owns Ownerships')</script>");
            } ;
        }
        protected void Edit(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            Response.Redirect("Edit_Owner.aspx?Id=" + id);
        }
        protected void Go_To_Add_Owner(object sender, EventArgs e)
        {
            Response.Redirect("Add_Owner.aspx");
        }

        
    }
}