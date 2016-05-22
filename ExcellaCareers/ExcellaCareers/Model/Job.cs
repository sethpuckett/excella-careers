using System;

namespace ExcellaCareers.Model
{
    public class Job
    {
        public string Title { get; set; }

        public JobDetails Details { get; set; }

        public Uri Url { get; set; }
    }
}