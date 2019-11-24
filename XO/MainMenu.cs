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

namespace XO
{
    [Activity(Label = "MainMenu")]
    public class MainMenu : Activity, Android.Views.View.IOnClickListener
    {
        Button startBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main_menu);
            // Create your application here
            startBtn = FindViewById<Button>(Resource.Id.startBtn);

        }

        public void OnClick(View v)
        {
            if (v == startBtn)
            {
                Intent intent = new Intent(this, typeof(GameBoard));
                StartActivity(intent);
            }
        }
    }
}