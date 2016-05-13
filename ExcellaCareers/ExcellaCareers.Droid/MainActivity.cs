using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using ExcellaCareers.Services;
using ExcellaCareers.Services.Impl;

namespace ExcellaCareers.Droid
{
    [Activity (Label = "Excella Careers", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        private readonly IHtmlScraper htmlScraper;

        private readonly ICareerHtmlParser careerHtmlParser;
        
        public MainActivity()
        {
            this.htmlScraper = new HtmlScraper();
            this.careerHtmlParser = new CareerHtmlParser();
        }

        protected override async void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);
            SetContentView (Resource.Layout.Main);
            
            var webResponse = await this.htmlScraper.Scrape(Resources.GetString(Resource.String.careers_url));

            var jobs = this.careerHtmlParser.ParseHtml(webResponse);
            
            this.ListAdapter = new JobListItemAdapter(this, Resource.Layout.CareerListItem, jobs.ToList());

            this.ListView.ItemClick += (sender, e) =>
            {
                var item = this.ListView.GetItemAtPosition(e.Position);
                var sendIntent = new Intent();
                sendIntent.SetAction(Intent.ActionSend);
                sendIntent.PutExtra(Intent.ExtraText, "This is my text to send.");
                sendIntent.SetType("text/plain");
                StartActivity(Intent.CreateChooser(sendIntent, "Share With..."));
            };
        }
    }
}


