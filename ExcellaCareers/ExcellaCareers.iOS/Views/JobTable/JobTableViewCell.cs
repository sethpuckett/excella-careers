using Foundation;
using System;
using UIKit;

namespace ExcellaCareers.iOS
{
    public partial class JobTableViewCell : UITableViewCell
    {
        public Uri JobUrl { get; private set; }

        public string JobTitle { get; private set; }

        public JobTableViewCell (IntPtr p) : base (p)
        {

        }

        public JobTableViewCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
        {

        }

        public void UpdateCell (string job, Uri url)
        {
            this.jobLabel.Text = job;
            this.JobUrl = url;
            this.JobTitle = job;

            this.jobButton.TouchUpInside += (sender, e) => {
                if (this.ShareClicked != null) {
                    this.ShareClicked (this, e);
                }
            };
        }

        public event EventHandler ShareClicked;
    }
}