using System.Threading.Tasks;
using Android.Animation;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using Android.Views;
using AndroidX.AppCompat.App;
using LongoToDo.Forms.Droid;
using Xamarin.Forms;

namespace BarsMobileApp.Droid
{
    [Activity(
        Theme = "@style/LaunchScreenTheme",
        MainLauncher = true,
        NoHistory = true,
        ScreenOrientation = ScreenOrientation.Portrait,
        LaunchMode = LaunchMode.SingleTask)]
    public class LaunchScreenActivity : AppCompatActivity
    {
        #region Attributes

        private Bundle bundle;

        #endregion Attributes

        #region Operations

        protected override void OnCreate(Bundle bundle)
        {
            this.bundle = bundle;
            base.OnCreate(bundle);
        }

        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(new Intent(Android.App.Application.Context, typeof(MainActivity)));
        }

        #endregion Operations
    }
}