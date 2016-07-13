using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace ExcellaCareers.iOS
{
	public class JobTableViewSource : UITableViewSource
	{
		private IEnumerable<string> jobList;

		private const string CellIdentifier = "jobCell";

		public JobTableViewSource(IEnumerable<string> jobs)
		{
			this.jobList = jobs;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
			string item = jobList.ElementAt(indexPath.Row);

			//---- if there are no cells to reuse, create a new one
			if (cell == null)
			{ cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

			cell.TextLabel.Text = item;

			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return jobList.Count();
		}
	}
}

