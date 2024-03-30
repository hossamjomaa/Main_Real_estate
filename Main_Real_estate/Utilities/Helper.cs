using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Net.Http;
using System.Web.UI.WebControls;
using Main_Real_estate.Enums;
using Ubiety.Dns.Core;
using System.Web.UI.HtmlControls;

namespace Main_Real_estate.Utilities
{
    public static class Helper
    {
        private static LinkButton sender;

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }


        //******************  Calaner ***************************************************
            public static void Calendar_SelectionChanged(TextBox txt , Calendar cal , ImageButton imgbtn , HtmlGenericControl Div)
            {
                txt.Text = cal.SelectedDate.ToShortDateString();
                if (txt.Text != "") {  Div.Visible = false; imgbtn.Visible = false; }
            }
            public static void Date_Chosee_Click(ImageButton imgbtn, HtmlGenericControl Div) { Div.Visible = true; imgbtn.Visible = true; }
            public static void cal_Close(ImageButton imgbtn, HtmlGenericControl Div) {Div.Visible = false; imgbtn.Visible = false; }
        


        public static void GetDataReader(string Quari, MySqlConnection connection, Repeater Repeater_ID)
        {
            
                MySqlCommand GetCmd = new MySqlCommand(Quari, connection);
                MySqlDataAdapter GetDt = new MySqlDataAdapter(GetCmd);
                GetCmd.Connection = connection;
                connection.Open();
                GetDt.SelectCommand = GetCmd;
                DataTable GetDataTable = new DataTable();
                GetDt.Fill(GetDataTable);
                Repeater_ID.DataSource = GetDataTable;
                Repeater_ID.DataBind();
                connection.Close();
           
        }
        public static bool LoadDropDownList(string commandText, MySqlConnection connection, DropDownList dropdownList, string dataTextField, string dataValueField)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand(commandText))
                {
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.EnhancedOpen();
                    dropdownList.DataSource = command.ExecuteReader();
                    dropdownList.DataTextField = dataTextField;
                    dropdownList.DataValueField = dataValueField;
                    dropdownList.DataBind();
                    connection.EnhancedClose();
                }
        }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static bool SendSms(string destination, string message)
        {

            const string key = "Amlak@123";

            var apiUrl = "http://localhost:5000/api/sms";
            var configValue = ConfigurationManager.AppSettings["ApiUrl"];

            if (!string.IsNullOrWhiteSpace(configValue))
            {
                apiUrl = configValue;
            }

            var result = false;
            
            var response = new SmsMessage()
            {
                Key = key,
                Number = destination,
                Message = message //?????
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                var responseTask = client.PostAsJsonAsync<SmsMessage>("api/sms/SendSms", response);
                responseTask.Wait();
                var resultTask = responseTask.Result;
                if (resultTask.IsSuccessStatusCode)
                {
                    result = true;
                }
            }


            return result;
        }

        public static bool Log(string logByUser, LogTypes logType, string logItem, string logData)
        {
            var insertCommandString =
                    $"Insert into translogs (LogTime, LogByUser, LogReferenceType, ReferenceItem, LogData, IsActive) VALUES ('{DateTime.Now}', '{logByUser}', '{logType.ToString()}', '{logItem}','{logData}',{true})";

            return MySqlInsert(insertCommandString);


            //try
            //{
            //    var con = GetConnection();
            //    con.EnhancedOpen();

            //    //var insertCommandString =
            //    //    $"INSERT INTO logs (LogTime, LogByUser, Ownership, Building, Unit, Contract, LogData, IsActive) values ({DateTime.Now}, '{logByUser}' '{ownership}','{building}', '{unit}', '{contract}', '{logData}', {true})";

            //    var insertCommandString =
            //        $"Insert into translogs (LogTime, LogByUser, LogReferenceType, ReferenceItem, LogData, IsActive) VALUES ('{DateTime.Now}', '{logByUser}', '{logType.ToString()}', '{logItem}','{logData}',{true})";

            //    using (MySqlCommand insertCommand = new MySqlCommand(insertCommandString, con))
            //    {
            //        insertCommand.ExecuteNonQuery();
            //        con.Close();
            //    }

            //    return true;

            //}
            //catch (Exception e)
            //{
            //    return false;
            //}

            //INSERT INTO logs (LogTime, LogByUser, Ownership, Building, Unit, Contract, LogData, IsActive) values ()
            
        }

        public static bool AddRelatedDocuments(string transactionByUser, DocumentReferenceTypes referenceType, string referenceItem, string documentUrl, string notes = "")
        {

            var insertCommandString =
                   $"Insert into relateddocumentsrecords (TransactionTime, TransactionByUser, ReferenceType, ReferenceItem, DocumentUrl, Note, IsActive) values ({DateTime.Now}, '{transactionByUser}', '{referenceType.ToString()}', '{referenceItem}', '{documentUrl}', '{notes}', {true})";

            return MySqlInsert(insertCommandString);


            //Insert into relateddocuments (DocId, TransactionTime, TransactionByUser, Ownership, Building, Unit, Tenant, Contract, Note, IsActive) values ()

            //try
            //{
            //    var con = GetConnection();
            //    con.EnhancedOpen();

            //    //var insertCommandString =
            //    //    $"Insert into RelatedDocuments (TransactionTime, TransactionByUser, Ownership, Building, Unit, Tenant, Contract, Note, IsActive) values ({DateTime.Now}, '{transactionByUser}', '{ownership}', '{building}', '{unit}', '{tenant}', '{contract}', '{note}', {true})";

            //    var insertCommandString =
            //        $"Insert into relateddocumentsrecords (TransactionTime, TransactionByUser, ReferenceType, ReferenceItem, DocumentUrl, Note, IsActive) values ({DateTime.Now}, '{transactionByUser}', '{referenceType.ToString()}', '{referenceItem}', '{documentUrl}', '{notes}', {true})";

            //    using (MySqlCommand insertCommand = new MySqlCommand(insertCommandString, con))
            //    {
            //        insertCommand.ExecuteNonQuery();
            //        con.Close();
            //    }

            //    return true;

            //}
            //catch (Exception e) 
            //{
            //    return false;
            //}
        }

        public static bool MySqlInsert(string insertCommandString)
        {
            try
            {
                var con = GetConnection();
                con.EnhancedOpen();

                using (MySqlCommand insertCommand = new MySqlCommand(insertCommandString, con))
                {
                    insertCommand.ExecuteNonQuery();
                    con.Close();
                }
                return true;


            }
            catch (Exception e)
            {
                return false;
            }
        }

    }

    
}