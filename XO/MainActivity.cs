using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace XO
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, Android.Views.View.IOnClickListener
    {
        Button startBtn;
        Button settingsBtn;
        Button instructionBtn;
        Button scoreBtn;
        Button inputBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            // Create your application here

            //startBtn = FindViewById<Button>(Resource.Id.startBtn);
            //settingsBtn = FindViewById<Button>(Resource.Id.settingBtn);
            //instructionBtn = FindViewById<Button>(Resource.Id.instructionBtn);
            scoreBtn = FindViewById<Button>(Resource.Id.scoreBtn);
            inputBtn = FindViewById<Button>(Resource.Id.inputBtn);

            //startBtn.SetOnClickListener(this);
            //settingsBtn.SetOnClickListener(this);
            //instructionBtn.SetOnClickListener(this);
            scoreBtn.SetOnClickListener(this);
            inputBtn.SetOnClickListener(this);

        }

        public void OnClick(View v)
        {
            //if (v == startBtn)
            //{
            //    Intent intent = new Intent(this, typeof(GameBoard));
            //    StartActivity(intent);
            //}
            //if(v == settingsBtn)
            //{
            //    Intent intent = new Intent(this, typeof(Settings));
            //    StartActivity(intent);
            //}
            //if(v == instructionBtn)
            //{
            //    Intent intent = new Intent(this, typeof(Instruction));
            //    StartActivity(intent);
            //}
            if(v == scoreBtn)
            {
                Intent intent = new Intent(this, typeof(AllActivity));
                StartActivity(intent);
            }
            if(v == inputBtn)
            {
                Intent intent = new Intent(this, typeof(InputActivity));
                StartActivity(intent);
            }
        }
    }
}