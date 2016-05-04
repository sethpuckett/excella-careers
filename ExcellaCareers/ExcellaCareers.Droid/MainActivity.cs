using System;
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
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			var txtMain = FindViewById<TextView> (Resource.Id.txtMain);
			var webResponse = GetWebContent();

			parse(webResponse);

			txtMain.Text = webResponse;
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

		private void parse(string html)
		{
			var htmlDoc = new HtmlAgilityPack.HtmlDocument();

			// filePath is a path to a file containing the html
			htmlDoc.LoadHtml(html);

			if (htmlDoc.DocumentNode != null)
			{
				var jobsTable =
					htmlDoc.DocumentNode.Descendants("table")
						.Where( t =>
								t.Attributes.Contains("class") &&
								t.Attributes["class"].Value.Contains("iCIMS_JobsTable"));
			}
		}
	}
}


