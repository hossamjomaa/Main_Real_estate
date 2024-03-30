using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Main_Real_estate.Utilities
{
    public static class MySqlExtension
    {
        public static void EnhancedOpen(this MySqlConnection con)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
        }

        public static void EnhancedClose(this MySqlConnection con)
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
        }
    }



    //public static int WordCount(this string str)
    //{
    //    return str.Split(new char[] { ' ', '.', '?' },
    //                     StringSplitOptions.RemoveEmptyEntries).Length;
    //}
}