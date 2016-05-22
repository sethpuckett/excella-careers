using System.Collections.Generic;
using ExcellaCareers.Model;

namespace ExcellaCareers.Services
{
    public interface ICareerHtmlParser
    {
        IEnumerable<Job> ParseJobList(string html);

        JobDetails ParseJobDetails(string html);

    }
}