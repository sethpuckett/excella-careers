using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using ExcellaCareers.Model;
using ExcellaCareers.Services;
using ExcellaCareers.Services.Impl;

namespace ExcellaCareers.Droid
{
    [Activity(Label = "Excella Careers", MainLauncher = true, Icon = "@drawable/ExcellaLogo", Theme = "@style/SplashTheme", NoHistory = true)]
    public class SplashActivty : AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();

            var startupWork = new Task(() => {
                Task.Delay(3000);  // Simulate a bit of startup work.
            });

            startupWork.ContinueWith(t => {
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            }, TaskScheduler.FromCurrentSynchronizationContext());

            startupWork.Start();
        }

    }
}