using Main_Real_estate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main_Real_estate.English
{
    public partial class SMSTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendSmsButton_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.SendSms("97430646636", "Test");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}