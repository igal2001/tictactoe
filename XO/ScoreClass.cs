using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
    [Table("Scores")]
    class ScoreClass
    {
        [PrimaryKey, AutoIncrement, Column("_num")]

        public int num { get; set; }
        public string name { get; set; }

        public int score { get; set; }

        public string phone { get; set; }

        public ScoreClass()
        {
        }

        public ScoreClass(string name, int score, string phone)
        {
            this.name = name;

            this.score = score;
            this.phone = phone;
        }

        public void IncScore()
        {
            this.score++;
        }

        public override string ToString()
        {
            string str = name + " " + phone + " " + score;
            return str;
        }
    }
}