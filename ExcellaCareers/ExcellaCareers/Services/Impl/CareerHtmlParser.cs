using System;
using System.Collections.Generic;
using System.Linq;
using ExcellaCareers.Model;
using HtmlAgilityPack;

namespace ExcellaCareers.Services.Impl
{
    public class CareerHtmlParser : ICareerHtmlParser
    {
        public IEnumerable<Job> ParseJobList(string html)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            if (htmlDoc.DocumentNode == null)
            {
                return null;
            }

            var jobCells = this.GetJobCells(htmlDoc);

            var jobList = new List<Job>();
            foreach (var jobCell in jobCells)
            {
                var link = jobCell.Descendants("a").First();
                jobList.Add(new Job {Title = link.InnerText.Trim(), Url = new Uri(link.Attributes["href"].Value)});
            }

            return jobList;
        }

        public JobDetails ParseJobDetails(string html)
        {
            // TODO: Implement when detail scraping works
            throw new NotImplementedException();
        }

        private IEnumerable<HtmlNode> GetJobCells(HtmlDocument htmlDoc)
        {
            var jobsTable = htmlDoc.DocumentNode.Descendants("table").First(t =>
                t.Attributes.Contains("class") &&
                t.Attributes["class"].Value.Contains("iCIMS_JobsTable"));
            var body = jobsTable.Descendants("tBody").First();
            return body.Descendants("tr").Select(tr => tr.Descendants("td").First());
        }
    }
}