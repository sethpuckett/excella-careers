using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExcellaCareers.Model;
using ExcellaCareers.Services;
using ExcellaCareers.Services.Impl;
using Foundation;
using UIKit;

namespace ExcellaCareers.iOS
{
	public partial class JobTableViewController : UIViewController
	{
		private readonly IHtmlScraper htmlScraper;

		private readonly ICareerHtmlParser careerHtmlParser;

		public JobTableViewController (IntPtr handle) : base (handle)
		{
			this.htmlScraper = new HtmlScraper(new WebRequestService());
			this.careerHtmlParser = new CareerHtmlParser();
		}

		public async override void ViewDidLoad()
		{
			this.LoadingLabel.Hidden = false;
			this.JobTableView.Hidden = true;

			var jobs = await this.LoadJobs();
            var tableSource = new JobTableViewSource (jobs, this);
            this.JobTableView.Source = tableSource;
            tableSource.ShareClicked += (sender, e) => {
                var cell = sender as JobTableViewCell;
                var activitiesItems = new NSString []
                {
                    (NSString)($"Check out this {cell.JobTitle} opportunity with Excella!{Environment.NewLine}{cell.JobUrl.GetLeftPart(UriPartial.Path)}")
                };
                var activityController = new UIActivityViewController (activitiesItems, null);
                activityController.SetValueForKey (NSObject.FromObject ("Opportunities with Excella"), new NSString ("subject"));
                this.PresentViewController (activityController, true, null);
            };

			this.JobTableView.ReloadData();

			this.LoadingLabel.Hidden = true;
			this.JobTableView.Hidden = false;

			base.ViewDidLoad();
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		private async Task<IEnumerable<Job>> LoadJobs()
		{
			// TODO: don't use magic string
			var jobWebResponse = await this.htmlScraper.Scrape("https://careers-excella.icims.com/jobs/search?in_iframe=1");
			var jobs = this.careerHtmlParser.ParseJobList(jobWebResponse);

			// TODO: Detail scraping doesn't work. Need a way to get data from iframe
			//foreach (var job in jobs)
			//{
			//    var detailWebResponse = await this.htmlScraper.Scrape(job.Url.ToString());
			//    job.Details = this.careerHtmlParser.ParseJobDetails(detailWebResponse);
			//}

			return jobs;
		}
	}
}

