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

		private static readonly NSString CellIdentifier = new NSString("jobCell");

		public JobTableViewSource(IEnumerable<Job> jobs)
		{
			this.jobList = jobs;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			// TODO: Update to not need null check
			var cell = tableView.DequeueReusableCell(CellIdentifier) as JobTableViewCell;
			var item = jobList.ElementAt(indexPath.Row);

			// if there are no cells to reuse, create a new one
			if (cell == null)
			{ 
				cell = new JobTableViewCell(CellIdentifier); 
			}

			cell.UpdateCell(item.Title, item.Url);

			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return jobList.Count();
		}
	}
}

