using Foundation;
using System;
using UIKit;

namespace ExcellaCareers.iOS
{
    public partial class JobTableViewCell : UITableViewCell
    {
		private Uri jobUrl;

		public JobTableViewCell(IntPtr p) : base(p)
		{
			
		}

		public JobTableViewCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
        {

        }

		public void UpdateCell(string job, Uri url)
		{
			this.jobLabel.Text = job;
			this.jobUrl = url;

			this.jobButton.TouchUpInside += (sender, e) =>
			{

			};
		}
    }
}