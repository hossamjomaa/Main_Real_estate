using Main_Real_estate.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;

//using iTextSharp.tool.xml;

namespace Main_Real_estate.English.Main_Application
{
    public partial class Detais_All_Ownership : System.Web.UI.Page
    {
        private readonly MySqlConnection _sqlCon = Helper.GetConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindRepeater();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."
        }

        private void BindRepeater()
        {
            using (MySqlCommand cmd = new MySqlCommand("Details_All_ownership", _sqlCon))
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    Unit_GridView.DataSource = dt;
                    Unit_GridView.DataBind();
                }
            }
        }

        protected void Exprt_Excel_ServerClick(object sender, EventArgs e)
        {
            //Response.Clear();
            //Response.Buffer = true;
            //Response.ClearContent();
            //Response.ClearHeaders();
            //Response.Charset = "";
            //string FileName = "Vithal" + DateTime.Now + ".xls";
            //StringWriter strwritter = new StringWriter();
            //HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.ContentType = "application/vnd.ms-excel";
            //Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            //Unit_GridView.GridLines = GridLines.Both;
            //Unit_GridView.HeaderStyle.Font.Bold = true;
            //Unit_GridView.RenderControl(htmltextwrtter);
            //Response.Write(strwritter.ToString());
            //Response.End();
        }

        protected void btnExport_ServerClick(object sender, EventArgs e)
        {
            //Unit_GridView.AllowPaging = false;
            //DataBind(); string fileName = "ExportToPdf_" + DateTime.Now.ToShortDateString();
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName + ".pdf"));
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //StringWriter objSW = new StringWriter();
            //HtmlTextWriter objTW = new HtmlTextWriter(objSW);
            //Unit_GridView.RenderControl(objTW);
            //StringReader objSR = new StringReader(objSW.ToString());
            //Document objPDF = new Document(PageSize.A4, 100f, 100f, 100f, 100f);
            //HTMLWorker objHW = new HTMLWorker(objPDF);
            //PdfWriter.GetInstance(objPDF, Response.OutputStream);
            //objPDF.Open();
            //objHW.Parse(objSR);
            //objPDF.Close();
            //Response.Write(objPDF);
            //Response.End();
        }
    }
}