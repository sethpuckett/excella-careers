using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Support.V7.App;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using ExcellaCareers.Model;
using ExcellaCareers.Services;
using ExcellaCareers.Services.Impl;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace ExcellaCareers.Droid.Activities
{
    [Activity(Label = "Excella Careers", MainLauncher = true, Icon = "@drawable/ExcellaLogoIcon", Theme = "@style/SplashTheme", NoHistory = true)]
    public class SplashActivty : AppCompatActivity
    {
        private readonly IHtmlScraper htmlScraper;

        private readonly ICareerHtmlParser careerHtmlParser;

        public SplashActivty()
        {
            this.htmlScraper = new HtmlScraper(new WebRequestService());
            this.careerHtmlParser = new CareerHtmlParser();
        }

        protected override async void OnResume()
        {
            base.OnResume();

            var connectivity = CrossConnectivity.Current;
            if (!connectivity.IsConnected)
            {
                this.ShowNetworkError();
                return;
            }

            try
            {
                var jobs = await this.LoadJobs();
                this.LaunchMainActivity(jobs);
            }
            catch (WebException)
            {
                this.ShowNetworkError();
            }

        }

        private async Task<IEnumerable<Job>> LoadJobs()
        {
            var jobWebResponse = await this.htmlScraper.Scrape(Resources.GetString(Resource.String.careers_url));
            var jobs = this.careerHtmlParser.ParseJobList(jobWebResponse);

            // TODO: Detail scraping doesn't work. Need a way to get data from iframe
            //foreach (var job in jobs)
            //{
            //    var detailWebResponse = await this.htmlScraper.Scrape(job.Url.ToString());
            //    job.Details = this.careerHtmlParser.ParseJobDetails(detailWebResponse);
            //}

            return jobs;
        }

        private void LaunchMainActivity(IEnumerable<Job> jobs)
        {
            var intent = new Intent(Application.Context, typeof(CareerListActivity));
            intent.PutExtra("jobs", JsonConvert.SerializeObject(jobs));
            StartActivity(intent);
        }

        private void ShowNetworkError()
        {
            var alert = new Android.App.AlertDialog.Builder(this);
            alert.SetTitle("Network Error");
            alert.SetMessage("Unable to load careers! Please check your internet connection.");
            alert.SetPositiveButton("Okay", (senderAlert, args) => { });
            Dialog dialog = alert.Create();
            dialog.Show();
        }
    }
}