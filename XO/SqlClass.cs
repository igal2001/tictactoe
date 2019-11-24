using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace XO
{
    class SqlClass
    {
        public static string dbname = "cooldb";

        public SqlClass()
        {

        }

        public static string Path()
        {
            string path = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), SqlClass.dbname);
            return path;
        }

        public static string StringBuilder()
        {
            string strsql = string.Format("SELECT * FROM Scores");
            return strsql;
        }

        public static string StringBuilderTopTen()
        {
            // string strsql = string.Format("SELECT TOP 5 * FROM  Scores");
            string strsql = string.Format("SELECT * FROM  Scores ORDER BY score DESC");

            //. ASC | DESC;

            return strsql;
        }


    }
}