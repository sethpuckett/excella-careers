using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExcellaCareers.Services.Impl
{
    public class HtmlScraper : IHtmlScraper
    {
        public async Task<string> Scrape(string url)
        {
            var request = WebRequest.Create(url);

            var response = await request.GetResponseAsync().ConfigureAwait(false);

            var stream = response.GetResponseStream();
            var streamReader = new StreamReader(stream, Encoding.UTF8);
            var responseText = streamReader.ReadToEnd();

            streamReader.Dispose();
            stream.Dispose();
            response.Dispose();

            return responseText;
        }
    }
}
