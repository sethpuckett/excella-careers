using System;

using UIKit;

namespace ExcellaCareers.iOS
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
			
		}

		public override void ViewDidLoad()
		{
			this.JobTableView.Hidden = true;
			this.LoadingLabel.Hidden = false;

			base.ViewDidLoad();
			string[] tableItems = new string[] { "Job 1", "Job 2", "Job 3" };
			this.JobTableView.Source = new JobTableViewSource(tableItems);

			this.JobTableView.Hidden = false;
			this.LoadingLabel.Hidden = true;
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

