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
    [Activity(Label = "GameBoard")]
    public class GameBoard : Activity,Android.Views.View.IOnClickListener
    {
        GameLogic gl = new GameLogic();

        Button btn00;
        Button btn01;
        Button btn02;
        Button btn10;
        Button btn11;
        Button btn12;
        Button btn20;
        Button btn21;
        Button btn22;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.game_board);

            btn00 = FindViewById<Button>(Resource.Id.btn00);
            btn01 = FindViewById<Button>(Resource.Id.btn01);
            btn02 = FindViewById<Button>(Resource.Id.btn02);
            btn10 = FindViewById<Button>(Resource.Id.btn10);
            btn11 = FindViewById<Button>(Resource.Id.btn11);
            btn12 = FindViewById<Button>(Resource.Id.btn12);
            btn20 = FindViewById<Button>(Resource.Id.btn20);
            btn21 = FindViewById<Button>(Resource.Id.btn21);
            btn22 = FindViewById<Button>(Resource.Id.btn22);

            btn00.SetOnClickListener(this);
            btn01.SetOnClickListener(this);
            btn02.SetOnClickListener(this);
            btn10.SetOnClickListener(this);
            btn11.SetOnClickListener(this);
            btn12.SetOnClickListener(this);
            btn20.SetOnClickListener(this);
            btn21.SetOnClickListener(this);
            btn22.SetOnClickListener(this);
            gl.Start();

        }
        public override
            void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnClick(View v)
        {
            if (gl.turn == 1)
            {
                if (v == btn00)
                {
                    gl.GetPos(00);
                    btn00.Text = "x";
                    //btn00.Enabled = false;
                    //btn00.SetBackgroundResource(Resource.Drawable.xx);
                }
                if (v == btn01)
                {
                    btn01.Text = "X";
                    gl.GetPos(01);
                }
                if (v == btn02)
                {
                    btn02.Text = "X";
                    gl.GetPos(02);
                }

                if (v == btn10)
                {
                    btn10.Text = "x";
                    gl.GetPos(10);
                }

                if (v == btn11)
                {
                    btn11.Text = "X";
                    gl.GetPos(11);
                }
                if (v == btn12)
                {
                    btn12.Text = "X";
                    gl.GetPos(12);
                }

                if (v == btn20)
                {
                    btn20.Text = "X";
                    gl.GetPos(20);
                }

                if (v == btn21)
                {
                    btn21.Text = "X";
                    gl.GetPos(21);
                }
                if (v == btn22)
                {
                    btn22.Text = "X";
                    gl.GetPos(22);
                }
            }
            else if (gl.turn == 2)
            {
                if (v == btn00)
                {
                    btn00.Text = "O";
                    int num = 00;
                    gl.GetPos(num);
                    //                    btn00.SetBackgroundResource(Resource.Drawable.o);
                }
                if (v == btn01)
                {
                    btn01.Text = "O";
                    gl.GetPos(01);
                }
                if (v == btn02)
                {
                    btn02.Text = "O";
                    gl.GetPos(02);
                }

                if (v == btn10)
                {
                    btn10.Text = "O";
                    gl.GetPos(10);
                }

                if (v == btn11)
                {
                    btn11.Text = "O";
                    gl.GetPos(11);
                }
                if (v == btn12)
                {
                    btn12.Text = "O";
                    gl.GetPos(12);
                }

                if (v == btn20)
                {
                    btn20.Text = "O";
                    gl.GetPos(20);
                }

                if (v == btn21)
                {
                    btn21.Text = "O";
                    gl.GetPos(21);
                }
                if (v == btn22)
                {
                    btn22.Text = "O";
                    gl.GetPos(22);
                }
            }

            gl.CheckWinCond();
            gl.ChangeTurn();
        }
    }
}