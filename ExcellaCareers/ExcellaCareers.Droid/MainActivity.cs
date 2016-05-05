using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Android.App;
using Android.Widget;
using Android.OS;
using HtmlAgilityPack;

namespace ExcellaCareers.Droid
{
    [Activity (Label = "Excella Careers", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);
            SetContentView (Resource.Layout.Main);
            
            var webResponse = GetWebContent();

            var jobs = parse(webResponse);
            var jobStrings = jobs.Select(j => $"{j.Title}\n{j.Url.GetLeftPart(UriPartial.Path).ToString()}").ToList();
            
            this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, jobStrings);
        }

        private string GetWebContent()
        {
            var request = WebRequest.Create("https://careers-excella.icims.com/jobs/search?in_iframe=1");
            var response = request.GetResponse();

            var stream = response.GetResponseStream();
            var streamReader = new StreamReader(stream, Encoding.Default);
            var responseText = streamReader.ReadToEnd();

            streamReader.Close();
            stream.Close();
            response.Close();

            return responseText;
        }

        private IEnumerable<Job> parse(string html)
        {
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();

            // filePath is a path to a file containing the html
            htmlDoc.LoadHtml(html);

            if (htmlDoc.DocumentNode != null)
            {
                var jobsTable =
                    htmlDoc.DocumentNode.Descendants("table")
                        .First( t =>
                                t.Attributes.Contains("class") &&
                                t.Attributes["class"].Value.Contains("iCIMS_JobsTable"));
                var body = jobsTable.Descendants("tBody").First();
                var jobCells = body.Descendants("tr").Select(tr => tr.Descendants("td").First());

                var jobList = new List<Job>();

                foreach (var jobCell in jobCells)
                {
                    var link = jobCell.Descendants("a").First();
                    jobList.Add(new Job { Title = link.InnerText.Trim(), Url = new Uri(link.Attributes["href"].Value) });
                }

                return jobList;
            }

            return null;
        }
    }

    public class Job
    {
        public string Title { get; set; }

        public Uri Url { get; set; }
    }
}


