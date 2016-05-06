using System.Collections.Generic;
using ExcellaCareers.Model;

namespace ExcellaCareers.Services
{
    public interface ICareerHtmlParser
    {
        IEnumerable<Job> ParseHtml(string html);
    }
}