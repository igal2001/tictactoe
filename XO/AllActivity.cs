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
    [Activity(Label = "AllActivity")]
    public class AllActivity : Activity
    {
        string path;
        public int count = 0;

        ArrayAdapter<string> arrayAdapter;
        private static List<ScoreClass> scores;
        ScoreAdapter scoreAdapter;

        ListView lv;

        internal static List<ScoreClass> Scores { get => scores; set => scores = value; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.winlayout);

            path = SqlClass.Path();

            var db = new SQLiteConnection(path);
            db.CreateTable<ScoreClass>();

            scoreAdapter = new ScoreAdapter(this, scores);

            List<string> l = GetAll();

            if (l != null && count > 0 && l.Count > 0)
            {
                lv = FindViewById<ListView>(Resource.Id.list_item);
                arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, l);

            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            Toast.MakeText(this, "ON RESUME ON CALLED", ToastLength.Short).Show();
            scoreAdapter.NotifyDataSetChanged();
        }

        public static List<string> GetAll()
        {
            var db = new SQLiteConnection(SqlClass.Path());
            string strsql = string.Format(SqlClass.StringBuilder());

            List<string> mygamelist = new List<string>();

            var students = db.Query<ScoreClass>(strsql);

            if(students != null && students.Count > 0)
            {
                int counter = 0;
                foreach (var item in students)
                {
                    counter++;

                    string str = counter + " : " + item.name + " " + item.phone + " " + item.score;

                    mygamelist.Add(str);
                    }
                }
            return mygamelist;
        }
    }
    
}
