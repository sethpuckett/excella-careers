using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using ExcellaCareers.Model;
using ExcellaCareers.Services;
using ExcellaCareers.Services.Impl;
using Newtonsoft.Json;

namespace ExcellaCareers.Droid
{
    [Activity (Label = "Excella Careers", Icon = "@drawable/ExcellaLogo")]
    public class MainActivity : ListActivity
    {
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);
            SetContentView (Resource.Layout.Main);

            var jobJson = Intent.GetStringExtra("jobs");
            var jobs = JsonConvert.DeserializeObject<IEnumerable<Job>>(jobJson);

            this.ListAdapter = new JobListItemAdapter(this, Resource.Layout.CareerListItem, jobs.ToList());

            this.ListView.ItemClick += (sender, e) =>
            {
                var item = this.ListAdapter.GetItem(e.Position).Cast<Job>();
                var sendIntent = new Intent();
                sendIntent.SetAction(Intent.ActionSend);
                sendIntent.PutExtra(Intent.ExtraText, $"Check out this opportunity with Excella! {item.Url}");
                sendIntent.PutExtra(Intent.ExtraSubject, "Opportunities with Excella");
                sendIntent.SetType("text/plain");
                StartActivity(Intent.CreateChooser(sendIntent, "Share With..."));
            };
        }
    }
}


