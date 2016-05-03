using System;
using System.IO;
using System.Net;
using System.Text;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

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
		    txtMain.Text = webResponse;
		}

		private string GetWebContent()
		{
			var request = WebRequest.Create("https://careers-excella.icims.com/jobs/search");
			var response = request.GetResponse();

			var stream = response.GetResponseStream();
			var streamReader = new StreamReader(stream, Encoding.Default);
			var responseText = streamReader.ReadToEnd();

			streamReader.Close();
			stream.Close();
			response.Close();

			return responseText;
		}
	}
}


