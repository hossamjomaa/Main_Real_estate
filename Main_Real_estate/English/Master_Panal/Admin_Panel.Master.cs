using System;

namespace Main_Real_estate.English.Master_Panal
{
    public partial class Admin_Panel : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Users_Name"] != null)
            {
                Label1.Text = Session["Users_Name"].ToString();
            }
            else
            {
                Response.Redirect("~/English/Main_Application/Log_In.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/English/Main_Application/Log_In.aspx");
        }
    }
}