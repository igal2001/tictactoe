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
    [Activity(Label = "GameController")]
    public class GameController : Activity
    {
        GameLogic gl = new GameLogic();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }

        public void StartGame()
        {
            gl.Start();
        }
    }
}