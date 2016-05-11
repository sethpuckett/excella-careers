using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ExcellaCareers.Model;
using Java.Lang;

namespace ExcellaCareers.Droid
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
                var email = (TextView)view.FindViewById(Resource.Id.url);

                title?.SetText(job.Title, TextView.BufferType.Normal);
                email?.SetText(job.Url.ToString(), TextView.BufferType.Normal);
            }

            return view;
        }
    }
}