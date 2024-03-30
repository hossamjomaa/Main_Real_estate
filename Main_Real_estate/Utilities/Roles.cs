using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Net.Http;
using System.Web.UI.WebControls;
using Main_Real_estate.Enums;
using Ubiety.Dns.Core;
using System.Web.UI.HtmlControls;
using Main_Real_estate.English.Main_Application;
using System.Web;

namespace Main_Real_estate.Utilities
{
    public class Roles
    {
        public static void Master_Page_permission(MySqlConnection connection, string Role_ID,
        HtmlGenericControl Ownership_Div, HtmlGenericControl Contract_Div, HtmlGenericControl Tenant_Div, HtmlGenericControl complaintreport_Div, HtmlGenericControl Income_Expensess_Div,
        HtmlGenericControl Financial_Statements_Div, HtmlGenericControl Markting_Div, HtmlGenericControl Task_Managements_Div, HtmlGenericControl lists_Div, HtmlGenericControl Sitting_Div )
        {
            try
            {
                DataTable Dt = new DataTable();
                connection.Open();
                MySqlCommand Cmd = new MySqlCommand("SELECT * FROM roles WHERE Role_ID = @ID", connection);
                MySqlDataAdapter Da = new MySqlDataAdapter(Cmd);
                Cmd.Parameters.AddWithValue("@ID", Role_ID);
                Da.Fill(Dt);
                if (Dt.Rows.Count > 0)
                {
                    string[] Pro = Dt.Rows[0]["properties"].ToString().Split(',');
                    string[] Con = Dt.Rows[0]["Contracting"].ToString().Split(',');
                    string[] Ten = Dt.Rows[0]["Customer_Affairs"].ToString().Split(',');
                    string[] AsM = Dt.Rows[0]["Asset_Management"].ToString().Split(',');
                    string[] Col = Dt.Rows[0]["Collecting"].ToString().Split(',');
                    string[] FS = Dt.Rows[0]["Financial_Statements"].ToString().Split(',');
                    string[] Mar = Dt.Rows[0]["Marketing"].ToString().Split(',');
                    string[] TM = Dt.Rows[0]["Task_Management"].ToString().Split(',');
                    string[] MF = Dt.Rows[0]["Deficiency_Detection"].ToString().Split(',');

                    if (Pro[0] == "R") { Ownership_Div.Visible = true; } else { Ownership_Div.Visible = false; }
                    if (Con[0] == "R") { Contract_Div.Visible = true; } else { Contract_Div.Visible = false; }
                    if (Ten[0] == "R") { Tenant_Div.Visible = true; } else { Tenant_Div.Visible = false; }
                    if (AsM[0] == "R") { complaintreport_Div.Visible = true; } else { complaintreport_Div.Visible = false; }
                    if (Col[0] == "R") { Income_Expensess_Div.Visible = true; } else { Income_Expensess_Div.Visible = false; }
                    if (FS[0] == "R") { Financial_Statements_Div.Visible = true; } else { Financial_Statements_Div.Visible = false; }
                    if (Mar[0] == "R") { Markting_Div.Visible = true; } else { Markting_Div.Visible = false; }
                    if (TM[0] == "R") { Task_Managements_Div.Visible = true; } else { Task_Managements_Div.Visible = false; }
                    if (MF[0] == "R") { lists_Div.Visible = true; } else { lists_Div.Visible = false; }
                    if (Dt.Rows[0]["System_Settings"].ToString() == "R") { Sitting_Div.Visible = true; } else { Sitting_Div.Visible = false; }
                }
                connection.Close();
            }
            catch
            {
                HttpContext.Current.Response.Redirect("Log_In.aspx");
            }
            
        }







        public static void Singel_Page_permission(MySqlConnection connection, string Role_ID , string Column ,  int i, string permission)
        {
            try
            {
                DataTable Dt = new DataTable();
                connection.Open();
                MySqlCommand Cmd = new MySqlCommand("SELECT * FROM roles WHERE Role_ID = @ID", connection);
                MySqlDataAdapter Da = new MySqlDataAdapter(Cmd);
                Cmd.Parameters.AddWithValue("@ID", Role_ID);
                Da.Fill(Dt);
                if (Dt.Rows.Count > 0)
                {
                    string[] Page = Dt.Rows[0][Column].ToString().Split(',');
                    if (Page[i] != permission) { HttpContext.Current.Response.Redirect("Log_In.aspx"); }
                }
                connection.Close();
            }
            catch
            {
                HttpContext.Current.Response.Redirect("Log_In.aspx");
            }
            
        }


        public static void Add_permission(MySqlConnection connection, string Role_ID, string Column , LinkButton Add )
        {
            try
            {
                DataTable Dt = new DataTable();
                connection.Open();
                MySqlCommand Cmd = new MySqlCommand("SELECT * FROM roles WHERE Role_ID = @ID", connection);
                MySqlDataAdapter Da = new MySqlDataAdapter(Cmd);
                Cmd.Parameters.AddWithValue("@ID", Role_ID);
                Da.Fill(Dt);
                if (Dt.Rows.Count > 0)
                {
                    string[] Page = Dt.Rows[0][Column].ToString().Split(',');
                    if (Page[1].ToString() != "A") { Add.Visible = false; }
                }
                connection.Close();
            }
            catch
            {
                HttpContext.Current.Response.Redirect("Log_In.aspx");
            }
            
        }


        public static void Edit_permission(MySqlConnection connection, string Role_ID, string Column , LinkButton Edit)
        {
            try
            {
                DataTable Dt = new DataTable();
                connection.Open();
                MySqlCommand Cmd = new MySqlCommand("SELECT * FROM roles WHERE Role_ID = @ID", connection);
                MySqlDataAdapter Da = new MySqlDataAdapter(Cmd);
                Cmd.Parameters.AddWithValue("@ID", Role_ID);
                Da.Fill(Dt);
                if (Dt.Rows.Count > 0)
                {
                    string[] Page = Dt.Rows[0][Column].ToString().Split(',');
                    if (Page[2] != "E") { Edit.Visible = false; }
                }
                connection.Close();
            }
            catch
            {
                HttpContext.Current.Response.Redirect("Log_In.aspx");
            }
            
        }


        public static void Delete_permission(MySqlConnection connection, string Role_ID, string Column , LinkButton Delete)
        {
            try
            {
                DataTable Dt = new DataTable();
                connection.Open();
                MySqlCommand Cmd = new MySqlCommand("SELECT * FROM roles WHERE Role_ID = @ID", connection);
                MySqlDataAdapter Da = new MySqlDataAdapter(Cmd);
                Cmd.Parameters.AddWithValue("@ID", Role_ID);
                Da.Fill(Dt);
                if (Dt.Rows.Count > 0)
                {
                    string[] Page = Dt.Rows[0][Column].ToString().Split(',');
                    if (Page[3] != "D") { Delete.Visible = false; }
                }
                connection.Close();
            }
            catch
            {
                HttpContext.Current.Response.Redirect("Log_In.aspx");
            }
            
        }


        public static void Delete_permission_With_Reason(MySqlConnection connection, string Role_ID, string Column, LinkButton Delete , HtmlGenericControl Reason_Div)
        {
            try
            {
                DataTable Dt = new DataTable();
                connection.Open();
                MySqlCommand Cmd = new MySqlCommand("SELECT * FROM roles WHERE Role_ID = @ID", connection);
                MySqlDataAdapter Da = new MySqlDataAdapter(Cmd);
                Cmd.Parameters.AddWithValue("@ID", Role_ID);
                Da.Fill(Dt);
                if (Dt.Rows.Count > 0)
                {
                    string[] Page = Dt.Rows[0][Column].ToString().Split(',');
                    if (Page[3] != "D") { Delete.Visible = false; Reason_Div.Visible = false; }
                }
                connection.Close();
            }
            catch
            {
                HttpContext.Current.Response.Redirect("Log_In.aspx");
            }
            
        }
    }
}