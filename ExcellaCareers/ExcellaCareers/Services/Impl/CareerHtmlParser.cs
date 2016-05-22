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
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            if (htmlDoc.DocumentNode == null)
            {
                return null;
            }

            var overviewNode = this.GetOverviewNode(htmlDoc);

            var details = new JobDetails();

            return details;
        }

        private IEnumerable<HtmlNode> GetJobCells(HtmlDocument htmlDoc)
        {
            var jobsTable = htmlDoc.DocumentNode.Descendants("table").First(t =>
                t.Attributes.Contains("class") &&
                t.Attributes["class"].Value.Contains("iCIMS_JobsTable"));
            var body = jobsTable.Descendants("tBody").First();
            return body.Descendants("tr").Select(tr => tr.Descendants("td").First());
        }

        private HtmlNode GetOverviewNode(HtmlDocument htmlDoc)
        {
            //iCIMS_InfoMsg iCIMS_InfoMsg_Job
            var node = htmlDoc.DocumentNode.Descendants("//h5[contains(text(),'Overview') and @class='iCIMS_InfoMsg iCIMS_InfoField_Job']");

            //var overviewHeader = htmlDoc.DocumentNode.Descendants("//div[@class='iCIMS_InfoMsg iCIMS_InfoField_Job']");

            //var jobsTable = htmlDoc.DocumentNode.Descendants("//div[(@class='iCIMS_InfoMsg_Job']").First(t =>
            //    t.Attributes.Contains("class") &&
            //    t.Attributes["class"].Value.Contains("iCIMS_JobsTable"));
            //var body = jobsTable.Descendants("tBody").First();
            //return body.Descendants("tr").Select(tr => tr.Descendants("td").First());

            throw new NotImplementedException();
        }
    }
}