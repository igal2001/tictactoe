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
    [Activity(Label = "InputActivity")]
    public class InputActivity : Activity
    {
        EditText edname;
        EditText edphone;
        Button save;

        ScoreClass person;

        string path;
        public int count = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.inputlayout);
            edname = FindViewById<EditText>(Resource.Id.name);
            edphone = FindViewById<EditText>(Resource.Id.phone);
            save = FindViewById<Button>(Resource.Id.save);

            save.Click += Save_Click;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            bool b = IsInList(edname.Text);
            if (b == false)
            {
                path = SqlClass.Path();
                var db = new SQLiteConnection(path);
                db.CreateTable<ScoreClass>();
                person = new ScoreClass(edname.Text, 1, edphone.Text);

                Toast.MakeText(this, person.ToString(), ToastLength.Short).Show();

                count++;
                db.Insert(person);
                Toast.MakeText(this, "insert record", ToastLength.Short).Show();
            }
        }

        public static bool IsInList(string name)
        {
            var db = new SQLiteConnection(SqlClass.Path());

            var players = db.Query<ScoreClass>(SqlClass.StringBuilder());

            List<string> mygamelist = new List<string>();

            if(players != null && players.Count > 0)
            {
                foreach (var item in players)
                {
                    if(item.name == name)
                    {
                        item.IncScore();
                        db.Update(item);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}