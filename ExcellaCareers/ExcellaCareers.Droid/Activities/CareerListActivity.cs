using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using ExcellaCareers.Model;
using Newtonsoft.Json;

namespace ExcellaCareers.Droid.Activities
{
    [Activity (Label = "Excella Careers", Icon = "@drawable/ExcellaLogo")]
    public class CareerListActivity : Activity
    {
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);
            SetContentView (Resource.Layout.CareerList);

            var jobJson = Intent.GetStringExtra("jobs");
            var jobs = JsonConvert.DeserializeObject<IEnumerable<Job>>(jobJson);

            var listAdapter = new JobListItemAdapter(this, Resource.Layout.CareerListItem, jobs.ToList());
            var listView = FindViewById<ListView>(Resource.Id.listViewJobs);
            listView.Adapter = listAdapter;

            listView.ItemClick += (sender, e) =>
            {
                var item = listAdapter.GetItem(e.Position);
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


