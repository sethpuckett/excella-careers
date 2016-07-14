using System;
using System.Collections.Generic;
using System.Linq;
using ExcellaCareers.Model;
using Foundation;
using UIKit;

namespace ExcellaCareers.iOS
{
	public class JobTableViewSource : UITableViewSource
	{
		private IEnumerable<Job> jobList;

		private const string CellIdentifier = "jobCell";

		public JobTableViewSource(IEnumerable<Job> jobs)
		{
			this.jobList = jobs;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(CellIdentifier);
			var item = jobList.ElementAt(indexPath.Row);

			//---- if there are no cells to reuse, create a new one
			if (cell == null)
			{ cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

			cell.TextLabel.Text = item.Title;

			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return jobList.Count();
		}
	}
}

