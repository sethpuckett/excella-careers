using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Support.V7.App;
using ExcellaCareers.Model;
using ExcellaCareers.Services;
using ExcellaCareers.Services.Impl;
using Newtonsoft.Json;

namespace ExcellaCareers.Droid.Activities
{
    [Activity(Label = "Excella Careers", MainLauncher = true, Icon = "@drawable/ExcellaLogo", Theme = "@style/SplashTheme", NoHistory = true)]
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

            var jobs = await this.LoadJobs();
            this.LaunchMainActivity(jobs);
        }

        private async Task<IEnumerable<Job>> LoadJobs()
        {
            try
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
            catch (WebException)
            {
                return null;
            }
        }

        private void LaunchMainActivity(IEnumerable<Job> jobs)
        {
            var intent = new Intent(Application.Context, typeof(CareerListActivity));
            intent.PutExtra("jobs", JsonConvert.SerializeObject(jobs));
            StartActivity(intent);
        }
        
    }
}