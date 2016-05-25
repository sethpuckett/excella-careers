using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Views;
using Android.Widget;
using ExcellaCareers.Model;

namespace ExcellaCareers.Droid.Common
{
    public class JobListItemAdapter: ArrayAdapter<Job> 
    {
        private IList<Job> Jobs { get; }

        public JobListItemAdapter(Context context, int textViewResourceId, IList<Job> jobs): 
            base(context, textViewResourceId, jobs)
        {
            this.Jobs = jobs;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            if (view == null)
            {
                var layoutInflator = (LayoutInflater)this.Context.GetSystemService(Context.LayoutInflaterService);
                view = layoutInflator.Inflate(Resource.Layout.CareerListItem, null);
            }

            var job = this.Jobs.ElementAt(position);

            if (job != null)
            {
                var title = (TextView) view.FindViewById(Resource.Id.title);
                var shareButton = view.FindViewById<ImageView>(Resource.Id.imageButtonShare);

                title?.SetText(job.Title, TextView.BufferType.Normal);

                shareButton.Click += (sender, e) =>
                {
                    var sendIntent = new Intent();
                    sendIntent.SetAction(Intent.ActionSend);
                    sendIntent.PutExtra(Intent.ExtraText, $"Check out this opportunity with Excella!{System.Environment.NewLine}{job.Url}");
                    sendIntent.PutExtra(Intent.ExtraSubject, "Opportunities with Excella");
                    sendIntent.SetType("text/plain");
                    this.Context.StartActivity(Intent.CreateChooser(sendIntent, "Share With..."));
                };
            }

            return view;
        }
    }
}